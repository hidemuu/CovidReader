"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_router_1 = require("react-router");
var Layout_1 = require("./pages/Layout");
var Home_1 = require("./pages/Home");
var Charts_1 = require("./pages/charts/Charts");
var Tables_1 = require("./pages/tables/Tables");
var Dashboard_1 = require("./pages/dashboards/Dashboard");
var App = /** @class */ (function (_super) {
    __extends(App, _super);
    function App() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    App.prototype.render = function () {
        return (React.createElement(Layout_1.default, null,
            React.createElement(react_router_1.Route, { exact: true, path: '/', component: Home_1.default }),
            React.createElement(react_router_1.Route, { path: "/dashboard", component: Dashboard_1.default }),
            React.createElement(react_router_1.Route, { path: "/charts", component: Charts_1.default }),
            React.createElement(react_router_1.Route, { path: "/tables", component: Tables_1.default })));
    };
    App.displayName = App.name;
    return App;
}(React.Component));
exports.default = App;
//# sourceMappingURL=App.js.map