import mathjs from 'mathjs'
import io from 'socket.io-client'
import {
	INIT_SOCKET,
	NEXT_GEN,
	RESYNC,
	DIRT,
	SWITCH_CELL,
	ADD_PATTERN
} from './actionTypes'

import {
	RESYNC_MSG,
	NEXT_GEN_MSG,
	DIRT_MSG,
	ADD_PATTERN_MSG
} from './messageTypes'

export function initSocket() {
	return (dispatch, getState) => {
		const socket = io('http://localhost:3001/')
		socket.on(RESYNC_MSG, (data) => {
			const {matrix, nextAge} = data
			dispatch(resync(matrix, nextAge))
    	})
    	socket.on(NEXT_GEN_MSG, (data) => {
    		const {updates, nextAge} = data
    		dispatch(nextGen(updates, nextAge))
    	})
    	dispatch({
    		type: INIT_SOCKET,
    		payload: {socket}
    	})
    }
}

export function resync(matrix, nextAge) {
	const world = mathjs.type.SparseMatrix.fromJSON(matrix).toArray()
	return {
		type: RESYNC,
		payload: {world, nextAge}
	}
}

export function nextGen(updates, nextAge) {
	return (dispatch, getState)	=> {
		const { age, socket } = getState()
		if((age + 1) != nextAge) {
			socket.emit(DIRT_MSG)
			dispatch({type: DIRT})
			return
		}

		dispatch({
			type: NEXT_GEN,
			payload: {updates, nextAge}
		})
	}
}

export function switchCell(x, y) {
	return (dispatch, getState) => {
		dispatch({
			type: SWITCH_CELL,
			payload: {x, y}
		})
	}
}

export function addPattern() {
	return (dispatch, getState) => {
		const { socket, patternEditor} = getState()
		let pattern = []
		Object.keys(patternEditor).forEach(i => {
			Object.keys(patternEditor[i]).forEach(j => {
				pattern[i] = pattern[i] || []
				pattern[i][j] = patternEditor[i][j]
			})
		})
		socket.emit(ADD_PATTERN_MSG, pattern)

		dispatch({
			type: ADD_PATTERN
		})
	}
}
