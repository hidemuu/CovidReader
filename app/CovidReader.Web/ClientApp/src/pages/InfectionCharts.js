import React, { useState } from 'react';
import { Button, Grid, Typography, Modal, Paper, TextField, Fade } from '@material-ui/core';
import { Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";

export default class VirusCharts extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      infections: [],
      viraltests: [],
      infectiontotals: [],
      viraltesttotals: [],
      loadinginfections:true,
      loadingviraltests:true,
      loadinginfectiontotals:true,
      loadingviraltesttotals:true,
    };
  }

  

  componentDidMount() {
    this.populateChartItemAsync();  
  }

  async populateChartItemAsync(){

    await fetch('api/infection')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        infections: json,
        loadinginfections: false
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/Infection ---');
      console.error(error);
    });

    await fetch('api/infectiontotal')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        infectiontotals: json,
        loadinginfectiontotals: false
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/InfectionTotal ---');
      console.error(error);
    });

    await fetch('api/viraltest')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        viraltests: json,
        loadingviraltests: false
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/ViralTest ---');
      console.error(error);
    });

    await fetch('api/viraltesttotal')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        viraltesttotals: json,
        loadingviraltesttotals: false
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/ViralTestTotal ---');
      console.error(error);
    });

  }

  render() {

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

    if(!this.state.loadinginfections && !this.state.loadingviraltests && !this.state.loadinginfectiontotals && !this.state.loadingviraltesttotals){
      console.log('draw start');
      const infections = this.state.infections;
      const deathLabel = '死亡者';
      const cureLabel = '入院者';
      const patientlabel = '陽性者';
      const recoveryLabel = '治癒者';
      const severeLabel = '重傷者';
      const testLabel = '検査者';
      const infectiontotals = this.state.infectiontotals;
      const deathTotalLabel = '累計' + deathLabel;
      const cureTotalLabel = '累計' + cureLabel;
      const patientTotallabel = '累計' + patientlabel;
      const recoveryTotalLabel = '累計' + recoveryLabel;
      const severeTotalLabel = '累計' + severeLabel;
      const testTotalLabel = '累計' + testLabel;
      const viraltests = this.state.viraltests;
      const nationalTestLabel = '国立感染症研究所';
      const quarantineTestLabel = '検疫所';
      const careCenterTestLabel = '保健所';
      const civilCenterTestLabel = '民間検査';
      const collegeTestLabel = '大学';
      const medicalTestLabel = '医療機関';
      const viraltesttotals = this.state.viraltesttotals;
      const nationalTestTotalLabel = '累計' + nationalTestLabel;
      const quarantineTestTotalLabel = '累計' + quarantineTestLabel;
      const careCenterTestTotalLabel = '累計' + careCenterTestLabel;
      const civilCenterTestTotalLabel = '累計' + civilCenterTestLabel;
      const collegeTestTotalLabel = '累計' + collegeTestLabel;
      const medicalTestTotalLabel = '累計' + medicalTestLabel;

      let chartLabels = infections.map(infection => { return infection.date; });
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);

      let chartData = [];  
      chartData.push({
        label: deathLabel,
        data: infections.map(infection => { return infection.deathNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: cureLabel,
        data: infections.map(infection => { return infection.cureNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: patientlabel,
        data: infections.map(infection => { return infection.patientNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: recoveryLabel,
        data: infections.map(infection => { return infection.recoveryNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: severeLabel,
        data: infections.map(infection => { return infection.severeNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: testLabel,
        data: infections.map(infection => { return infection.testNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: nationalTestLabel,
        data: viraltests.map(viraltest => { return viraltest.nationalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: quarantineTestLabel,
        data: viraltests.map(viraltest => { return viraltest.quarantineTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: careCenterTestLabel,
        data: viraltests.map(viraltest => { return viraltest.careCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: civilCenterTestLabel,
        data: viraltests.map(viraltest => { return viraltest.civilCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: collegeTestLabel,
        data: viraltests.map(viraltest => { return viraltest.collegeTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: medicalTestLabel,
        data: viraltests.map(viraltest => { return viraltest.medicalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: deathTotalLabel,
        data: infectiontotals.map(infection => { return infection.deathNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: cureTotalLabel,
        data: infectiontotals.map(infection => { return infection.cureNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: patientTotallabel,
        data: infectiontotals.map(infection => { return infection.patientNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: recoveryTotalLabel,
        data: infectiontotals.map(infection => { return infection.recoveryNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: severeTotalLabel,
        data: infectiontotals.map(infection => { return infection.severeNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: testTotalLabel,
        data: infectiontotals.map(infection => { return infection.testNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: nationalTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.nationalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: quarantineTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.quarantineTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: careCenterTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.careCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: civilCenterTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.civilCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: collegeTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.collegeTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: medicalTestTotalLabel,
        data: viraltesttotals.map(viraltest => { return viraltest.medicalTestNumber; }),
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

      const dataInfection = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathLabel || d.label == cureLabel || d.label == patientlabel || d.label == recoveryLabel || d.label == severeLabel || d.label == testLabel}),
      };

      const dataDeath = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathLabel}),
      };

      const dataCure = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == cureLabel}),
      };

      const dataPatient = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == patientlabel}),
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

      const dataViralTest = {
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

      const dataInfectionTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathTotalLabel || d.label == cureTotalLabel || d.label == patientTotallabel || d.label == recoveryTotalLabel || d.label == severeTotalLabel || d.label == testTotalLabel}),
      };

      const dataDeathTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == deathTotalLabel}),
      };

      const dataCureTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == cureTotalLabel}),
      };

      const dataPatientTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == patientTotallabel}),
      };

      const dataRecoveryTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == recoveryTotalLabel}),
      };

      const dataSevereTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == severeTotalLabel}),
      };

      const dataTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == testTotalLabel}),
      };

      const dataViralTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == nationalTestTotalLabel || d.label == quarantineTestTotalLabel || d.label == careCenterTestTotalLabel || d.label == civilCenterTestTotalLabel || d.label == collegeTestTotalLabel || d.label == medicalTestTotalLabel}),
      };

      const dataNationalTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == nationalTestTotalLabel}),
      };

      const dataQuarantineTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == quarantineTestTotalLabel}),
      };

      const dataCareCenterTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == careCenterTestTotalLabel}),
      };

      const dataCivilCenterTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == civilCenterTestTotalLabel}),
      };

      const dataCollegeTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == collegeTestTotalLabel}),
      };

      const dataMedicalTestTotal = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == medicalTestTotalLabel}),
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
              data={dataInfection} 
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
              data={dataCure} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataPatient} 
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
            <div>累計全国感染データ : 一覧</div>
          </Typography>
          <Line  
              data={dataInfectionTotal} 
              options={options}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>累計全国感染データ : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataDeathTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCureTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataPatientTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataRecoveryTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataSevereTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataTestTotal} 
              options={options}/>
            </Grid>
          </Grid>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>全国検査データ : 一覧</div>
          </Typography>
          <Line  
              data={dataViralTest} 
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
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>累計全国検査データ : 一覧</div>
          </Typography>
          <Line  
              data={dataViralTestTotal} 
              options={options}/>
          <Typography variant="h3" align="center" className={useStyles.typography}>
            <div>累計全国検査データ : 個別</div>
          </Typography>
          <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataNationalTestTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataQuarantineTestTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCareCenterTestTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCivilCenterTestTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataCollegeTestTotal} 
              options={options}/>
            </Grid>
            <Grid item className={useStyles.grid} xs={6}>
              <Bar  
              data={dataMedicalTestTotal} 
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