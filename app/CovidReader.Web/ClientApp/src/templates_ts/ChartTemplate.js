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
require("react-datepicker/dist/react-datepicker.css");
require("react-tabs/style/react-tabs.css");
var styles_1 = require("../components/styles/js/styles");
var ChartTemplate = /** @class */ (function (_super) {
    __extends(ChartTemplate, _super);
    function ChartTemplate() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ChartTemplate.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement(core_1.Typography, { variant: "h5", align: "center", className: styles_1.default.typography },
                React.createElement("div", null, "\u5168\u56FD\u611F\u67D3\u72B6\u6CC1 : \u65E5\u5831")),
            React.createElement(core_1.Grid, { container: true, style: { paddingTop: 30, paddingBottom: 50 }, justifyContent: "flex-end", direction: "row" },
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 }, this.props.dailyAllCharts),
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 }, this.props.dailyUnitCharts)),
            React.createElement(core_1.Typography, { variant: "h5", align: "center", className: styles_1.default.typography },
                React.createElement("div", null, "\u5168\u56FD\u611F\u67D3\u72B6\u6CC1 : \u7D2F\u8A08")),
            React.createElement(core_1.Grid, { container: true, style: { paddingTop: 30, paddingBottom: 50 }, justifyContent: "flex-end", direction: "row" },
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 }, this.props.totalAllCharts),
                React.createElement(core_1.Grid, { item: true, className: styles_1.default.grid, xs: 6 }, this.props.totalUnitCharts))));
    };
    return ChartTemplate;
}(React.Component));
exports.default = ChartTemplate;
//# sourceMappingURL=ChartTemplate.js.map