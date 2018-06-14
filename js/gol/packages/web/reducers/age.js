import { 
	RESYNC,
	NEXT_GEN
} from '../actions/actionTypes'

const INITIAL_STATE = -1

export default function(state = INITIAL_STATE, action) {
	switch(action.type) {
		case RESYNC:
		case NEXT_GEN:
			const { nextAge } = action.payload
			return nextAge

		default:
			return state
	}
}
