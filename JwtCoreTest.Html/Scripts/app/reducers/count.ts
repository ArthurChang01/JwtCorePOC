import * as constant from '../constants';
import * as actions from '../actions/count';
import * as ReactRouterRedux from 'react-router-redux';
import assign = require('object-assign');
import Counter from '../states/counter';

export function reducer(state = new Counter(), action: actions.Action): Counter {
    switch (action.type) {
        case constant.INCREASE:
        case constant.DECREASE:
            return changeCounterValue(state, action as actions.Counter);
        default:
            return state;
    }
}

function changeCounterValue(state: Counter, action: actions.Counter): Counter {
    switch (action.type) {
        case constant.INCREASE:
            var result = assign({}, state, {
                count: state.count + action.amount
            } as Counter);

            return result;
        case constant.DECREASE:
            var result = assign({}, state, {
                count: state.count - action.amount
            } as Counter);

            return result;
        default:
            return state;
    }
}
