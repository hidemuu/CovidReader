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
var core_1 = require("@material-ui/core");
var Paper_1 = require("@material-ui/core/Paper");
var styles_1 = require("../components/styles/js/styles");
var DashboardTemplate = /** @class */ (function (_super) {
    __extends(DashboardTemplate, _super);
    function DashboardTemplate() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DashboardTemplate.prototype.render = function () {
        return (React.createElement("div", { className: styles_1.default.board },
            React.createElement(core_1.Grid, { container: true, style: { paddingTop: 10, paddingBottom: 10 }, justifyContent: "flex-end", direction: "row" },
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 },
                    React.createElement(Paper_1.default, { className: styles_1.default.paper },
                        React.createElement(core_1.Typography, { variant: "h5", align: "center", className: styles_1.default.typography },
                            React.createElement("div", null, "\u30C1\u30E3\u30FC\u30C8")),
                        React.createElement(core_1.Grid, { container: true, style: { paddingTop: 10, paddingBottom: 10 }, justifyContent: "flex-end", direction: "row" },
                            React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 12 }, this.props.charts)))),
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 },
                    React.createElement(Paper_1.default, { className: styles_1.default.paper },
                        React.createElement(core_1.Typography, { variant: "h5", align: "center", className: styles_1.default.typography },
                            React.createElement("div", null, "\u30C6\u30FC\u30D6\u30EB")),
                        React.createElement(core_1.Grid, { container: true, style: { paddingTop: 10, paddingBottom: 10 }, justifyContent: "flex-end", direction: "row" },
                            React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 12 }, this.props.tables)))))));
    };
    return DashboardTemplate;
}(React.Component));
exports.default = DashboardTemplate;
//# sourceMappingURL=DashboardTemplate.js.map