webpackJsonp([0],[
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(1);


/***/ },
/* 1 */
/***/ function(module, exports, __webpack_require__) {

	// A '.tsx' file enables JSX support in the TypeScript compiler,
	// for more information see the following page on the TypeScript wiki:
	// https://github.com/Microsoft/TypeScript/wiki/JSX
	"use strict";
	var __extends = (this && this.__extends) || function (d, b) {
	    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
	    function __() { this.constructor = d; }
	    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
	};
	var React = __webpack_require__(2);
	var ReactDOM = __webpack_require__(3);
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


/***/ },
/* 2 */,
/* 3 */
/***/ function(module, exports, __webpack_require__) {

	/**
	 * ReactDOM v15.0.2
	 *
	 * Copyright 2013-present, Facebook, Inc.
	 * All rights reserved.
	 *
	 * This source code is licensed under the BSD-style license found in the
	 * LICENSE file in the root directory of this source tree. An additional grant
	 * of patent rights can be found in the PATENTS file in the same directory.
	 *
	 */
	// Based off https://github.com/ForbesLindesay/umd/blob/master/template.js
	;(function(f) {
	  // CommonJS
	  if (true) {
	    module.exports = f(__webpack_require__(2));

	  // RequireJS
	  } else if (typeof define === "function" && define.amd) {
	    define(['react'], f);

	  // <script>
	  } else {
	    var g;
	    if (typeof window !== "undefined") {
	      g = window;
	    } else if (typeof global !== "undefined") {
	      g = global;
	    } else if (typeof self !== "undefined") {
	      g = self;
	    } else {
	      // works providing we're not in "use strict";
	      // needed for Java 8 Nashorn
	      // see https://github.com/facebook/react/issues/3037
	      g = this;
	    }
	    g.ReactDOM = f(g.React);
	  }

	})(function(React) {
	  return React.__SECRET_DOM_DO_NOT_USE_OR_YOU_WILL_BE_FIRED;
	});


/***/ }
]);