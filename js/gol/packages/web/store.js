import { createStore, applyMiddleware } from 'redux'
import thunkMiddleware from 'redux-thunk'
import nextConnectRedux from 'next-connect-redux';
import { composeWithDevTools } from 'redux-devtools-extension/developmentOnly'
import rootReducer from './reducers'

export const initStore = (initialState) => {
    return createStore(rootReducer, initialState, composeWithDevTools(applyMiddleware(thunkMiddleware)))
}

export const connect = nextConnectRedux(initStore)