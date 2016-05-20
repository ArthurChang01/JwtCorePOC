// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import * as ReactRouter from 'react-router';
import * as ReactRedux from 'react-redux';
import * as reducers from '../reducers';
import * as ReactRouterRedux from 'react-router-redux';
import * as actions from '../actions/count';

interface IndexPageProps extends ReactRouter.RouteComponentProps<{}, {}> {
    push?: ReactRouterRedux.PushAction;
    increment?: (x: number) => void;
    decrement?: (x: number) => void;
    count?: number;
}

var IndexPage: React.StatelessComponent<IndexPageProps> = (props) => (
    <div>
        <span>{ props.count } </span>
        <br />
        <button onClick={() => props.increment(1) }>Inc </button>
        <button onClick= {() => props.decrement(1) }>Dec </button>
        <hr />
        <button onClick={ () => props.push('/next?count=' + props.count) }>Go to next page</button>
    </div>
);

function select(state: reducers.AppState): IndexPageProps {
    return {
        count: state["reducer"]["count"]
    };
}

export default ReactRedux.connect(select,
{
    push: ReactRouter.browserHistory.push,
    increment: actions.increase,
    decrement: actions.decrease
})(IndexPage);