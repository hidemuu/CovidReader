import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/infection/';
const chartTypes = ['bar', 'bar', 'bar', 'bar', 'bar', 'bar'];
const yAxisIDs = ['y-axis', 'y-axis', 'y-axis', 'y-axis', 'y-axis', 'y-axis'];
const labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者']; //EDIT 2021.09.29 ラベルデータをユニーク変数名から配列に変更（汎用化）
const borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)']; //ADD 2021.09.29 ボーダー色を宣言
const backgroundColors = ['rgba(255,0,0,1)', 'rgba(0,255,0,1)', 'rgba(0,0,255,1)', 'rgba(255,255,0,1)', 'rgba(0,255,255,1)', 'rgba(255,0,255,1)']; //ADD 2021.09.29 背景色を宣言
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
      
      //データ格納
      const data = this.state.data;
      const category = this.props.calc;
      const disp = this.props.disp;
      //日付フィルタ ADD 2021.10.02
      const endDate = new Date(this.props.endDate);
      const dateFilter = this.props.dateFilter;
      let startDate = new Date(this.props.endDate);
      if(dateFilter === 'week'){
        startDate.setDate( startDate.getDate() - 7);
      }else if(dateFilter === 'month'){
        startDate.setDate( startDate.getDate() - 30);
      }else if(dateFilter === 'year'){
        startDate.setDate( startDate.getDate() - 365);
      }else{
        startDate.setDate( startDate.getDate() - 365);
      }

      console.log('draw start' + startDate + ' - ' + endDate);

      const query = data.filter(item => { return item.calc ==  category}).filter(item => {return new Date(item.date) >= startDate && new Date(item.date) <= endDate});
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
      for (let i = 0; i < labels.length; i++){
        if(isEnables[i] === true){
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
            <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
              {queryLabels.map((label, index) => (
                <Grid item className={useStyles.grid} xs={12}>
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