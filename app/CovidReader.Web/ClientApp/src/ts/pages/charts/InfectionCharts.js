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
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Progress_1 = require("../../components/views/atoms/Progress");
var ChartScreen_1 = require("../../components/views/organisms/ChartScreen");
var getStartDate_1 = require("../../commons/functions/getStartDate");
var fetchData_1 = require("../../commons/functions/fetchData");
//定数
var basepath = 'api/infection/';
var chartTypes = ['bar', 'bar', 'bar', 'bar', 'bar', 'bar'];
var labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者'];
var borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)'];
var backgroundColors = ['rgba(255,0,0,1)', 'rgba(0,255,0,1)', 'rgba(0,0,255,1)', 'rgba(255,255,0,1)', 'rgba(0,255,255,1)', 'rgba(255,0,255,1)'];
var borderWidthes = [1, 1, 1, 1, 1, 1];
var isEnables = [true, false, true, false, false, false];
var InfectionCharts = /** @class */ (function (_super) {
    __extends(InfectionCharts, _super);
    //コンストラクタ
    function InfectionCharts(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            data: null,
            chart: null,
        };
        return _this;
    }
    //マウント時イベントハンドラ
    InfectionCharts.prototype.componentDidMount = function () {
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, (0, fetchData_1.default)(basepath, this)];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    InfectionCharts.prototype.render = function () {
        var _this = this;
        //データ取得完了後処理
        if (this.state.data != null) {
            //データ格納
            var startDate_1 = (0, getStartDate_1.default)(this.props.endDate, this.props.dateFilter);
            console.log('draw start' + startDate_1 + ' - ' + this.props.endDate);
            //指定calcの指定日付範囲のデータをクエリ
            var query = this.state.data.filter(function (item) { return item.calc == _this.props.calc; }).filter(function (item) { return item.date >= startDate_1 && item.date <= _this.props.endDate; });
            //データラベル生成
            var chartLabels = query.map(function (item) { return item.date; });
            console.log(chartLabels);
            //各系列の描画パラメータ設定
            var chartItems = [
                query.map(function (item) { return item.deathNumber; }),
                query.map(function (item) { return item.cureNumber; }),
                query.map(function (item) { return item.patientNumber; }),
                query.map(function (item) { return item.recoveryNumber; }),
                query.map(function (item) { return item.severeNumber; }),
                query.map(function (item) { return item.testNumber; }),
            ];
            var chartData = [];
            var queryLabels = [];
            var c = 0;
            for (var i = 0; i < labels.length; i++) {
                if (isEnables[i] === true) {
                    chartData.push({
                        type: chartTypes[c],
                        label: labels[c],
                        data: chartItems[c],
                        borderColor: borderColors[c],
                        backgroundColor: backgroundColors[c],
                        borderWidth: borderWidthes[c],
                    });
                    queryLabels.push(labels[c]);
                    c++;
                }
            }
            console.log(chartData);
            //チャートオプション設定
            var options = {
                legend: {
                //display: false
                },
                title: {
                    display: true,
                    text: 'title'
                },
                scales: {
                    yAxes: [
                        {
                            ticks: {
                                suggestedMax: 40,
                                suggestedMin: 0,
                                stepSize: 10,
                                callback: function (value, index, values) { return value + ''; }
                            }
                        }
                    ]
                }
            };
            this.state.chart.labels = chartLabels;
            this.state.chart.datasets = chartData;
            this.state.chart.options = options;
            return (React.createElement(ChartScreen_1.default, { chart: this.state.chart, queryLabels: queryLabels, isAll: this.props.isAll }));
        }
        else {
            return (React.createElement(Progress_1.default, null));
        }
    };
    return InfectionCharts;
}(React.Component));
exports.default = InfectionCharts;
//# sourceMappingURL=InfectionCharts.js.map