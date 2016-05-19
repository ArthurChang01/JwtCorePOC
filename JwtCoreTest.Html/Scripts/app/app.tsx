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
    private inputs: { username?: HTMLInputElement; password?:HTMLInputElement } = {};

    _login(e) {
        e.preventDefault();

        let username = this.inputs.username.value,
            password = this.inputs.password.value;
        let url = `http://localhost:15267/api/Accounts?userName=${username}&password=${password}`;
        $.getJSON(url).done((resp) => {
            alert(resp.access_token);
        });
    }

    render() {
        return <div>
                <form onSubmit={this._login.bind(this)}>
                <input type="text" placeholder="UserName" ref={username => this.inputs.username = username} />
                <input type="password" placeholder="Password" ref={password => this.inputs.password = password} />
                    <input type="submit" value="submit" />
                </form>
            </div>;
    }
}

ReactDOM.render(<AppComponent />, document.getElementById('content'));
