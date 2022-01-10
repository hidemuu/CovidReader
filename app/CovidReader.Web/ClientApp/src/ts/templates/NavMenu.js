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
var NavBar_1 = require("../components/views/molecules/NavBar");
var NavMenu = /** @class */ (function (_super) {
    __extends(NavMenu, _super);
    function NavMenu(props) {
        var _this = _super.call(this, props) || this;
        _this.toggleNavbar = _this.toggleNavbar.bind(_this);
        _this.state = {
            collapsed: true,
        };
        return _this;
    }
    NavMenu.prototype.toggleNavbar = function () {
        this.setState({
            collapsed: !this.props.collapsed
        });
    };
    NavMenu.prototype.render = function () {
        var urls = [];
        urls.push({ url: "/", content: "Home" });
        urls.push({ url: "/dashboard", content: "Dashboard" });
        urls.push({ url: "/charts", content: "Charts" });
        urls.push({ url: "/tables", content: "Tables" });
        urls.push({ url: "/settings", content: "Settings" });
        return (React.createElement(NavBar_1.default, { urls: urls, name: "Covid Reader", toggleNavbar: this.toggleNavbar, isCollapsed: !this.props.collapsed }));
    };
    NavMenu.displayName = NavMenu.name;
    return NavMenu;
}(React.Component));
exports.default = NavMenu;
//# sourceMappingURL=NavMenu.js.map