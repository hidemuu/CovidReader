import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/infection/calc/';
const chartTitle = '全国感染状況';
const deathLabel = '死亡者';
const cureLabel = '入院者';
const patientlabel = '陽性者';
const recoveryLabel = '治癒者';
const severeLabel = '重傷者';
const testLabel = '検査者';

//感染データチャート生成クラス
export default class InfectionCharts extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
      category: '',
    };
  }

  componentDidMount() {
    this.populateChartItemAsync(this.props.calc);  
  }

  async populateChartItemAsync(param){

    console.log(basepath + param);
    await fetch(basepath + param)
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        data: json,
        loading: false,
        category: param,
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error ' + basepath + this.props.calc + '---');
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
      //データラベル生成
      let chartLabels = data.map(item => { return item.date; });
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      //各系列の描画パラメータ設定
      let chartData = [];  
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: deathLabel,
        data: data.map(item => { return item.deathNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: cureLabel,
        data: data.map(item => { return item.cureNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: patientlabel,
        data: data.map(item => { return item.patientNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: recoveryLabel,
        data: data.map(item => { return item.recoveryNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: severeLabel,
        data: data.map(item => { return item.severeNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,255,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: testLabel,
        data: data.map(item => { return item.testNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,255,1)',
        borderWidth: 1
      });
      
      console.log('--- drawData : chartData -----');
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
        <div>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>{chartTitle} / {this.state.category} : 一覧</div>
          </Typography>
          <Line  
              data={{
                labels: chartLabels,
                datasets: chartData,
              }} 
              options={options}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>{chartTitle} / {this.state.category} : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == deathLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == cureLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == patientlabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == recoveryLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == severeLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label == testLabel}),
              }} 
              options={options}/>
            </Grid>
          </Grid>
          
        </div>
        
      );
    }else{

      return (
        <CircularProgress color="inherit" />
        
      );
    }
    
    
  }
}