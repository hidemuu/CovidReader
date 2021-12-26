import React from 'react';
import CircularProgress from "@material-ui/core/CircularProgress";
import ChartTemplate from "../../templates/ChartTemplate";
import getStateDate from "../../commons/getStartDate";

//定数
const basepath = 'api/infection/';
const chartTypes = ['bar', 'bar', 'bar', 'bar', 'bar', 'bar'];
const labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者'];
const borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)'];
const backgroundColors = ['rgba(255,0,0,1)', 'rgba(0,255,0,1)', 'rgba(0,0,255,1)', 'rgba(255,255,0,1)', 'rgba(0,255,255,1)', 'rgba(255,0,255,1)'];
const borderWidthes = [1, 1, 1, 1, 1, 1];
const isEnables = [true, false, true, false, false, false];

//感染データチャート生成クラス
export default class InfectionCharts extends React.Component {

  //コンストラクタ
  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
    };
  }

  //マウント時イベントハンドラ
  componentDidMount() {
    this.populateItemAsync();  
  }

  //チャートデータ取得
  async populateItemAsync(){

    console.log(basepath);
    await fetch(basepath)
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        data: json,
        loading: false,
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error ' + basepath +  '---');
      console.error(error);
    });

  }

  //レンダリング
    render() {

        //データ取得完了後処理
        if (!this.state.loading) {

            //データ格納
            let startDate = getStateDate(this.props.endDate, this.props.dateFilter);
            
            console.log('draw start' + startDate + ' - ' + this.props.endDate);

            const query = this.state.data.filter(item => { return item.calc == this.props.calc }).filter(item => { return new Date(item.date) >= startDate && new Date(item.date) <= this.props.endDate });
            //データラベル生成
            const chartLabels = query.map(item => { return item.date; });
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

            let chartData = [];
            let queryLabels = [];
            let c = 0;
            for (let i = 0; i < labels.length; i++) {
                if (isEnables[i] === true) {
                    chartData.push({
                        type: chartTypes[c],
                        // yAxisID: yAxisIDs[c],
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
                                callback: (value, index, values) => { return value + ''; }
                            }
                        }
                    ]
                }
            };

            return (
                <ChartTemplate
                    chartLabels={chartLabels}
                    chartData={chartData}
                    options={options}
                    queryLabels={queryLabels}
                    disp={this.props.disp}
                />
            );

        } else {

            return (
                <CircularProgress color="inherit" />

            );
        }


      
  }
}