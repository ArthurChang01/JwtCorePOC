// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import {Link, browserHistory} from 'react-router';

export var App: React.StatelessComponent<React.Props<{}>> = (props) => (
    <div>
        <header>
            Links:
            {' '}
            <Link to="/">Home</Link>
            {' '}
            <Link to="/first">Index</Link>
            {' '}
            <Link to="/next">Next</Link>
        </header>
        <div>
            <button onClick={ () => browserHistory.push('/first') }>Go to Index</button>
        </div>
        <div style={{ marginTop: '1.5em' }}>{props.children}</div>
    </div>
);