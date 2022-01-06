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
var react_router_dom_1 = require("react-router-dom");
var GridList_1 = require("@material-ui/core/GridList");
var GridListTile_1 = require("@material-ui/core/GridListTile");
var styles_1 = require("../components/styles/js/styles");
var HomeTemplate = /** @class */ (function (_super) {
    __extends(HomeTemplate, _super);
    function HomeTemplate() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HomeTemplate.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement("h1", null, "\u65B0\u578B\u30B3\u30ED\u30CA\u30A6\u30A4\u30EB\u30B9 \u30C7\u30FC\u30BF\u89E3\u6790"),
            React.createElement("div", { className: styles_1.default.home },
                React.createElement(GridList_1.default, { cellHeight: 400, className: styles_1.default.gridList },
                    React.createElement(GridListTile_1.default, { key: "Subheader", cols: 2, style: { height: 'auto' } }),
                    React.createElement(GridListTile_1.default, { cols: 2 },
                        React.createElement("p", null,
                            React.createElement("button", { className: "btn btn-primary", onClick: this.props.onClickUpdateButton }, "API Update"),
                            " ",
                            React.createElement(react_router_dom_1.Link, { to: "/signin", className: "btn btn-primary" }, "SignIn"),
                            " ",
                            React.createElement(react_router_dom_1.Link, { to: "/signup", className: "btn btn-primary" }, "SignUp")),
                        React.createElement("h3", null, "\u30D9\u30FC\u30B9\u30C7\u30FC\u30BF"),
                        React.createElement("ul", null,
                            React.createElement("li", null,
                                "\u653F\u5E9C\u6A5F\u95A2 : ",
                                React.createElement("a", { href: 'https://corona.go.jp/dashboard/' }, "\u5185\u95A3\u5B98\u623F"),
                                " / ",
                                React.createElement("a", { href: 'https://portal.opendata.go.jp/' }, "\u539A\u751F\u52B4\u50CD\u7701")),
                            React.createElement("li", null,
                                "\u30CB\u30E5\u30FC\u30B9 : ",
                                React.createElement("a", { href: 'https://www3.nhk.or.jp/news/special/coronavirus/data-widget/' }, "NHK"))),
                        React.createElement("p", null),
                        React.createElement("h3", null, "API\u30EA\u30B9\u30C8"),
                        React.createElement("ul", null,
                            React.createElement("li", null,
                                React.createElement("strong", null, "\u5168\u56FD\u306E\u611F\u67D3\u72B6\u6CC1"),
                                " : ",
                                React.createElement("a", { href: 'https://opendata.corona.go.jp/api/Covid19JapanAll' }, "Covid19JapanAll.json"),
                                " ",
                                React.createElement("code", null, " itemList "),
                                React.createElement("em", null, " date "),
                                " ",
                                React.createElement("em", null, " name_jp "),
                                " ",
                                React.createElement("em", null, " npatient "),
                                " "),
                            React.createElement("li", null,
                                React.createElement("strong", null, "\u5168\u56FD\u7D2F\u7A4D\u6B7B\u4EA1\u8005\u6570"),
                                " : ",
                                React.createElement("a", { href: 'https://opendata.corona.go.jp/api/Covid19JapanNdeaths' }, "Covid19JapanNdeaths.json"),
                                " ",
                                React.createElement("code", null, "itemList"),
                                " ",
                                React.createElement("em", null, " date "),
                                " ",
                                React.createElement("em", null, " ndeaths ")),
                            React.createElement("li", null,
                                React.createElement("strong", null, "\u4E16\u754C\u611F\u67D3\u72B6\u6CC1"),
                                " : ",
                                React.createElement("a", { href: 'https://opendata.corona.go.jp/api/OccurrenceStatusOverseas' }, "OccurrenceStatusOverseas.json"),
                                " "),
                            React.createElement("li", null,
                                React.createElement("strong", null, "\u5168\u56FD\u533B\u7642\u6A5F\u95A2\u306E\u533B\u7642\u63D0\u4F9B\u4F53\u5236\u306E\u72B6\u6CC1"),
                                " : ",
                                React.createElement("a", { href: 'https://opendata.corona.go.jp/api/covid19DailySurvey' }, "covid19DailySurvey.json")))))),
            React.createElement("h3", null, "\u30B3\u30F3\u30C6\u30F3\u30C4\u30EA\u30B9\u30C8"),
            React.createElement("div", { className: styles_1.default.home },
                React.createElement(GridList_1.default, { cellHeight: 400, className: styles_1.default.gridList },
                    React.createElement(GridListTile_1.default, { key: "Subheader", cols: 2, style: { height: 'auto' } })))));
    };
    return HomeTemplate;
}(React.Component));
exports.default = HomeTemplate;
//# sourceMappingURL=HomeTemplate.js.map