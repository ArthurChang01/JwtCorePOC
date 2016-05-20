// A '.tsx' file enables JSX support in the TypeScript compiler,
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import {createStore, combineReducers} from 'redux';
import { Provider} from 'react-redux';
import {Router, Route, IndexRoute, browserHistory} from 'react-router';
import * as ReactRouterRedux from 'react-router-redux';

import {reducer} from './reducers/count';
import * as action from './actions/count';
import {App} from './components/App';
import IndexPage from './components/IndexPage';
import NextPage from './components/NextPAge';

const reducers = combineReducers({
    reducer,
    routing: ReactRouterRedux.routerReducer
});

const store = createStore(reducers);
const history = ReactRouterRedux.syncHistoryWithStore(browserHistory, store);

ReactDOM.render(
    <Provider store={store}>
        <div>
            <Router history={history}>
                <Route path="/" component={App}>
                    <IndexRoute component={IndexPage} />
                </Route>   
                <Route path="/first" component={IndexPage} />
                <Route path="/next" component={NextPage} />
            </Router>
        </div>
    </Provider>
    ,document.getElementById('content'));
