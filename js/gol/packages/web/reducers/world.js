import { 
	NEXT_GEN,
	RESYNC
} from '../actions/actionTypes'

const arrayToObject = (a) => a.reduce((a,c,i)=> {a[i]=c; return a;}, {})

const INITIAL_STATE = {}

export default function(state = INITIAL_STATE, action) {
	switch(action.type) {
		case NEXT_GEN:
			const { updates } = action.payload
			const newState = { ...state }

			Object.keys(updates).forEach(i => {
				Object.keys(updates[i]).forEach(j => {
					newState[i][j] = updates[i][j]
				})
			})

			return newState;

		case RESYNC:
			const { world } = action.payload;
			return arrayToObject(world.map(r => arrayToObject(r)))

		default:
			return state
	}
}
