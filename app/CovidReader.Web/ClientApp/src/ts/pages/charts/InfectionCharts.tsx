import * as React from "react";
import Progress from "../../components/views/atoms/Progress";
import ChartScreen from "../../components/views/organisms/ChartScreen";
import getStateDate from "../../commons/functions/getStartDate";
import fetchData from "../../commons/functions/fetchData";
import getStringFromDate from "../../commons/functions/getStringFromDate";

//定数
const basepath = 'api/infection/';
const chartTypes = ['bar', 'bar', 'bar', 'bar', 'bar', 'bar'];
const labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者'];
const borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)'];
const backgroundColors = ['rgba(255,0,0,1)', 'rgba(0,255,0,1)', 'rgba(0,0,255,1)', 'rgba(255,255,0,1)', 'rgba(0,255,255,1)', 'rgba(255,0,255,1)'];
const borderWidthes = [1, 1, 1, 1, 1, 1];
const isEnables = [true, false, true, false, false, false];

export default class InfectionCharts extends React.Component<Model.IChartData, Field.IChartData> {

    //マウント時イベントハンドラ
    async componentDidMount() {
        await fetchData(basepath, this);
    }

    render(): JSX.Element {

        //データ取得完了後処理
        if (this.state.data != null) {

            //データ格納
            let startDate = getStateDate(this.props.endDate, this.props.dateFilter);

            console.log('draw start' + startDate + ' - ' + this.props.endDate);

            //指定calcの指定日付範囲のデータをクエリ
            const query = this.state.data.filter(item => { return item.calc == this.props.calc }).filter(item => { return item.date >= startDate && item.date <= this.props.endDate });
            //データラベル生成
            const chartLabels = query.map(item => { return getStringFromDate(item.date); });
            console.log(chartLabels);
            //各系列の描画パラメータ設定
            const chartItems = [
                query.map(item => { return item.deathNumber; }),
                query.map(item => { return item.cureNumber; }),
                query.map(item => { return item.patientNumber; }),
                query.map(item => { return item.recoveryNumber; }),
                query.map(item => { return item.severeNumber; }),
                query.map(item => { return item.testNumber; }),
            ]

            let chartData : Field.IChartData[] = [];
            let queryLabels :any[];
            queryLabels = [];
            let c = 0;
            for (let i = 0; i < labels.length; i++) {
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
            const options = {
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
                                callback: (value:any, index:any, values:any) => { return value + ''; }
                            }
                        }
                    ]
                }
            };

            

            this.state.chart.labels = chartLabels;
            this.state.chart.datasets = chartData;
            this.state.chart.options = options;

            return (
                <ChartScreen
                    chart={this.state.chart}
                    queryLabels={queryLabels}
                    isAll={this.props.isAll}
                />
            );

        } else {

            return (
                <Progress />

            );
        }
    }
}