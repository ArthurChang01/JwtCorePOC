// A '.tsx' file enables JSX support in the TypeScript compiler,
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import * as $ from 'jquery';
import 'jquery-CORS';

export class LogIn {
    public UserName: string;

    public Password: string;
}


export default class AppComponent extends React.Component<any, any>{
    componentWillMount() {
        let dto:LogIn = new LogIn();
        dto.UserName = "string";
        dto.Password = "P@ssw0rd";

        $.getJSON(`http://localhost:15267/api/Accounts?userName=${dto.UserName}&password=${dto.Password}`).done(function (data) {
            console.log(data.access_token);
        });
    }

    render() {
        return <div>Hi</div>;
    }
}

ReactDOM.render(<AppComponent />, document.getElementById('content'));
