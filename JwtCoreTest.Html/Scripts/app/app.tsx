﻿// A '.tsx' file enables JSX support in the TypeScript compiler,
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import * as ReactDOM from 'react-dom';

export default class AppComponent extends React.Component<any, any>{
    render() {
        return <div>Hi</div>;
    }
}

ReactDOM.render(<AppComponent />, document.getElementById('content'));
