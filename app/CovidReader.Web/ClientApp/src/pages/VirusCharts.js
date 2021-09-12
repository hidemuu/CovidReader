import React, { useState } from 'react';
import { Button, Grid, Typography, Modal, Paper, TextField, Fade } from '@material-ui/core';
import { Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import ListSubheader from '@material-ui/core/ListSubheader';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";
import Backdrop from "@material-ui/core/Backdrop";

export default class VirusCharts extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      viruses: [],
      loading: true,
    };
  }

  

  componentDidMount() {
    this.populateChartItemAsync();  
  }

  async populateChartItemAsync(){
    await fetch('api/virus')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        viruses: json,
        loading: false
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/Virus ---');
      console.error(error);
    });

  }

  render() {

    // const [progress, setProgress] = useState(false);

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

    if(!this.state.loading){
      console.log('draw start');
      const viruses = this.state.viruses;
      const deathLabel = '死亡者';
      const hospitalizationLabel = '入院者';
      const positivelabel = '陽性者';
      const recoveryLabel = '治癒者';
      const severeLabel = '重傷者';
      const testLabel = '検査者';
      const nationalTestLabel = '国立感染症研究所';
      const quarantineTestLabel = '検疫所';
      const careCenterTestLabel = '保健所';
      const civilCenterTestLabel = '民間検査';
      const collegeTestLabel = '大学';
      const medicalTestLabel = '医療機関';

      let chartLabels = viruses.map(virus => { return virus.date; });
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      let chartData = [];  
      chartData.push({
        label: deathLabel,
        data: viruses.map(virus => { return virus.deathNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: hospitalizationLabel,
        data: viruses.map(virus => { return virus.hospitalizationNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: positivelabel,
        data: viruses.map(virus => { return virus.positiveNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: recoveryLabel,
        data: viruses.map(virus => { return virus.recoveryNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: severeLabel,
        data: viruses.map(virus => { return virus.severeNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: testLabel,
        data: viruses.map(virus => { return virus.testNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: nationalTestLabel,
        data: viruses.map(virus => { return virus.nationalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: quarantineTestLabel,
        data: viruses.map(virus => { return virus.quarantineTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: careCenterTestLabel,
        data: viruses.map(virus => { return virus.careCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: civilCenterTestLabel,
        data: viruses.map(virus => { return virus.civilCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: collegeTestLabel,
        data: viruses.map(virus => { return virus.collegeTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: medicalTestLabel,
        data: viruses.map(virus => { return virus.medicalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,128,1)',
        borderWidth: 1
      });

      console.log('--- drawData : chartData -----');
      console.log(chartData);

      const data = {
        labels: chartLabels,
        datasets: chartData,
      };

      const dataCategory01 = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathLabel || d.label == hospitalizationLabel || d.label == positivelabel || d.label == recoveryLabel || d.label == severeLabel || d.label == testLabel}),
      };

      const dataDeath = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathLabel}),
      };

      const dataHospitalization = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == hospitalizationLabel}),
      };

      const dataPositive = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == positivelabel}),
      };

      const dataRecovery = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == recoveryLabel}),
      };

      const dataSevere = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == severeLabel}),
      };

      const dataTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == testLabel}),
      };

      const dataCategory02 = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == nationalTestLabel || d.label == quarantineTestLabel || d.label == careCenterTestLabel || d.label == civilCenterTestLabel || d.label == collegeTestLabel || d.label == medicalTestLabel}),
      };

      const dataNationalTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == nationalTestLabel}),
      };

      const dataQuarantineTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == quarantineTestLabel}),
      };

      const dataCareCenterTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == careCenterTestLabel}),
      };

      const dataCivilCenterTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == civilCenterTestLabel}),
      };

      const dataCollegeTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == collegeTestLabel}),
      };

      const dataMedicalTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == medicalTestLabel}),
      };

      const options = {
        //responsive: true,
        //maintainAspectRatio: false,
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
          {/* <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>一覧</div>
          </Typography>
          <Line  
              data={data} 
              options={options}/> */}
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>全国感染データ : 一覧</div>
          </Typography>
          <Line  
              data={dataCategory01} 
              options={options}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>全国感染データ : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataDeath} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataHospitalization} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataPositive} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataRecovery} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataSevere} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataTest} 
              options={options}/>
            </Grid>
          </Grid>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>全国検査データ : 一覧</div>
          </Typography>
          <Line  
              data={dataCategory02} 
              options={options}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>全国検査データ : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataNationalTest} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataQuarantineTest} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCareCenterTest} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCivilCenterTest} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCollegeTest} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataMedicalTest} 
              options={options}/>
            </Grid>
          </Grid>
        </div>
        
      );
    }else{

      // if (!progress) {
      //   return(
      //     <div className="App-header">
      //       <p>Loading...</p>
      //       {/* <PostForm setProgress={setProgress} setStatus={setStatus} /> */}
      //     </div>
        
      //   );
      // }
      // else{
      //   return (
      //     // <Backdrop className={useStyles.backdrop} open={progress}>
      //     //   <CircularProgress color="inherit" />
      //     // </Backdrop>
      //     <Backdrop className={useStyles.backdrop}>
      //       <CircularProgress color="inherit" />
      //     </Backdrop>
      //   );
      // }
      // return(
      //   <div className="App-header">
      //     <p>Loading...</p>
      //   </div>
      // );
      return (
        <CircularProgress color="inherit" />
        // <Backdrop className={useStyles.backdrop} open='true'>
        //   <CircularProgress color="inherit" />
        // </Backdrop>
      );
    }
    
    
  }
}