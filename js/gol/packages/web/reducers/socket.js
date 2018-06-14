import { 
	INIT_SOCKET
} from '../actions/actionTypes'

const INITIAL_STATE = {}

export default function(state = INITIAL_STATE, action) {
	switch(action.type) {
		case INIT_SOCKET:
			const { socket } = action.payload
			return socket

		default:
			return state
	}
}
