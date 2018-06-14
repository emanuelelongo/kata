import { 
	SWITCH_CELL,
	ADD_PATTERN
} from '../actions/actionTypes'

const arrayToObject = (a) => a.reduce((a,c,i)=> {a[i]=c; return a;}, {})

const INITIAL_STATE = arrayToObject(
	Array(5).fill(
		arrayToObject(
			Array(5).fill(0)
		)
	)
)

export default function(state = INITIAL_STATE, action) {
	switch(action.type) {
		case SWITCH_CELL:
			const {x, y} = action.payload;
			return {
				...state, 
				[x]: {
					...state[x], 
					[y]: (state[x][y] > 0) ?  0 : 1
				}
			};
		case ADD_PATTERN:
			return {...INITIAL_STATE}

		default:
			return state
	}
}
