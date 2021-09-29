import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/inspection/calc/';
const chartTitle = '全国検査状況';
const nationalTestLabel = '国立感染症研究所';
const quarantineTestLabel = '検疫所';
const careCenterTestLabel = '保健所';
const civilCenterTestLabel = '民間検査';
const collegeTestLabel = '大学';
const medicalTestLabel = '医療機関';

//検査データチャート生成クラス
export default class InspectionCharts extends React.Component {

  //コンストラクタ
  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
      category: '',
    };
  }

  //マウント時イベントハンドラ
  componentDidMount() {
    this.populateChartItemAsync(this.props.calc);  
  }

  //チャートデータ取得
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

      let chartData = [];  
      
      //各系列の描画パラメータ設定
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: nationalTestLabel,
        data: data.map(item => { return item.nationalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: quarantineTestLabel,
        data: data.map(item => { return item.quarantineTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: careCenterTestLabel,
        data: data.map(item => { return item.careCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: civilCenterTestLabel,
        data: data.map(item => { return item.civilCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: collegeTestLabel,
        data: data.map(item => { return item.collegeTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,128,1)',
        borderWidth: 1
      });
      chartData.push({
        type: 'bar',
        yAxisID: 'y-axis',
        label: medicalTestLabel,
        data: data.map(item => { return item.medicalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,128,1)',
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

      //チャートオプション設定（Y2軸用）
      const dualoptions = {
        responsive: true,
        
        scales: {
          
          yAxes: [
            {
              id: 'y-axis',
              position: 'left',
              scaleLabel: {
                display: true,
                labelString: '日報',
              },
              ticks: {
                beginAtZero: true,
                suggestedMax: 40,
                suggestedMin: 0,
                stepSize: 10,
                callback: (value, index, values) => { return value + ''; }
              },
            },
          ],
        }, 
        plugins: {
          datalabels: {
            display: true,
            anchor: 'end',
            align: 'right',
            formatter(value) {
              if (value === null || value === 0) {
                return '';
              }
              return `${value}%`
            },
          },
          layout: {
            padding: {
              right: 50,
            },
          },
        },    
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
              options={dualoptions}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>{chartTitle} / {this.state.category} : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                  labels: chartLabels,
                  datasets: chartData.filter(d => {return d.label === nationalTestLabel})
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label === quarantineTestLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label === careCenterTestLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label === civilCenterTestLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label === collegeTestLabel}),
              }} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={{
                labels: chartLabels,
                datasets: chartData.filter(d => {return d.label === medicalTestLabel}),
              }} 
              options={options}/>
            </Grid>
          </Grid>
        </div>
        
      );
    
    //データ取得中処理
    }else{
      return (
        <CircularProgress color="inherit" />
      );
    }
    
    
  }
}