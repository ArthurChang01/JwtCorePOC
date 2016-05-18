// A '.tsx' file enables JSX support in the TypeScript compiler,
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var React = require('react');
var ReactDOM = require('react-dom');
var AppComponent = (function (_super) {
    __extends(AppComponent, _super);
    function AppComponent() {
        _super.apply(this, arguments);
    }
    AppComponent.prototype.render = function () {
        return React.createElement("div", null, "Hi");
    };
    return AppComponent;
}(React.Component));
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = AppComponent;
ReactDOM.render(React.createElement(AppComponent, null), document.getElementById('content'));
