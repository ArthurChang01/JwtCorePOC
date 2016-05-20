import * as counterReducers from './count';
import * as Redux from 'redux';
import * as ReactRouterRedux from 'react-router-redux';
import Counter from '../states/counter';

export interface AppState {
    counter: Counter;
}

export const reducer = Redux.combineReducers({
    counter: counterReducers.reducer,
    routing: ReactRouterRedux.routerReducer
});