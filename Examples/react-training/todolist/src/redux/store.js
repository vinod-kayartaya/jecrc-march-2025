import {legacy_createStore as createStore, combineReducers} from 'redux'
import todoReducer from './reducers/todoReducer'

// here we collect all reducers and form a store

const rootReducer = combineReducers({todoReducer})
export default createStore(rootReducer);
