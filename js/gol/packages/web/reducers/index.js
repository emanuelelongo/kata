import { combineReducers } from 'redux'
import socket from './socket'
import age from './age'
import world from './world'
import patternEditor from './patternEditor'

const rootReducer = combineReducers({
	socket,
	age,
	world,
	patternEditor
})

export default rootReducer
