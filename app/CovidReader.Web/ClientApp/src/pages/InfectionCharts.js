import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/infection/';
const chartTitle = '全国感染状況';
const labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者']; //EDIT 2021.09.29 ラベルデータをユニーク変数名から配列に変更（汎用化）
const borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)']; //ADD 2021.09.29 ボーダー色を宣言
const backgroundColors = ['rgba(255,0,0,1)','rgba(0,255,0,1)','rgba(0,0,255,1)','rgba(255,255,0,1)','rgba(0,255,255,1)','rgba(255,0,255,1)']; //ADD 2021.09.29 背景色を宣言

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
    this.populateChartItemAsync();  
  }

  //チャートデータ取得
  async populateChartItemAsync(){

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

    //スタイル設定
    const useStyles = makeStyles((theme) => ({
      typography: {
        marginTop: theme.spacing(0),
        marginBottom: theme.spacing(0),
      },
      grid: {
        margin: "auto",
      },
      button: {
        marginTop: "auto",
        marginBottom: theme.spacing(5),
        width: "250px",
        height: "200px",
        fontSize: "30px",
        margin: theme.spacing(1),
      },
      backdrop: {
        color: "#fff"
      },
    }));

    //データ取得完了後処理
    if(!this.state.loading){
      console.log('draw start');
      //データ格納
      const data = this.state.data;
      const category = this.props.calc;
      const disp = this.props.disp;

      const query = data.filter(item => { return item.calc ==  category});
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
      for (let i = 0; i < labels.length; i++){
        chartData.push({
          type: 'bar',
          yAxisID: 'y-axis',
          label: labels[i],
          data: chartItems[i],
          borderColor: borderColors[i],
          backgroundColor: backgroundColors[i],
          borderWidth: 1
        });
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

      //デザイン
      if(disp == 'all'){
        return (
          <div>
            <Typography variant="h5" align="center" className={useStyles.typography}>
              <div>一覧</div>
            </Typography>
            <Line  
                data={{
                  labels: chartLabels,
                  datasets: chartData,
                }} 
                options={options}/>
          </div>
        );
      }
      else{
        return (
          <div>
            <Typography variant="h5" align="center" className={useStyles.typography}>
              <div>個別</div>
            </Typography>
            <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
              {labels.map((label, index) => (
                <Grid item className={useStyles.grid} xs={6}>
                <Bar  
                data={{
                  labels: chartLabels,
                  datasets: chartData.filter(d => {return d.label == label}),
                }} 
                options={options}/>
              </Grid>
              ))}
            </Grid>
          </div>
          
        );
      }
      
    }else{

      return (
        <CircularProgress color="inherit" />
        
      );
    }
    
    
  }
}