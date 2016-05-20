// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import * as ReactRedux from 'react-redux';
import * as ReactRouter from 'react-router';
import * as ReactRouterRedux from 'react-router-redux';
import * as reducers from '../reducers';

interface NextPageProps extends ReactRouter.RouteComponentProps<{}, {}> {
    goBack?: ReactRouterRedux.GoBackAction;
}

var NextPage: React.StatelessComponent<NextPageProps> = (props) => {
    const {goBack} = props;
    const query = props.location.query as { count: string };

    return (
        <div>
            <span>{query.count}</span>
            <br />
            <button onClick={() => goBack() }>GoBack</button>
        </div>
    )
}

function select(state: reducers.AppState): NextPageProps {
    return {};
}

export default ReactRedux.connect(select, {
    goBack: ReactRouter.browserHistory.goBack
})(NextPage);