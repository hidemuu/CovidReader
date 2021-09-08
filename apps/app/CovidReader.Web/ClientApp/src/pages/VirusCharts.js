import React from 'react';
import { Line, Bar } from 'react-chartjs-2';

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

    if(!this.state.loading){
      console.log('draw start');
      const viruses = this.state.viruses;

      //全部入りチャート
      let chartLabels = viruses.map(virus => { return virus.date; });
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      let chartData = [];  
      chartData.push({
        label: 'death',
        data: viruses.map(virus => { return virus.deathNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'hospitalization',
        data: viruses.map(virus => { return virus.hospitalizationNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'positive',
        data: viruses.map(virus => { return virus.positiveNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'recovery',
        data: viruses.map(virus => { return virus.recoveryNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,255,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'severe',
        data: viruses.map(virus => { return virus.severeNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,255,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'test',
        data: viruses.map(virus => { return virus.testNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(255,0,255,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'nationalTest',
        data: viruses.map(virus => { return virus.nationalTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,0,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'quarantineTest',
        data: viruses.map(virus => { return virus.quarantineTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'careCenterTest',
        data: viruses.map(virus => { return virus.careCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,0,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'civilCenterTest',
        data: viruses.map(virus => { return virus.civilCenterTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(128,128,0,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'collegeTest',
        data: viruses.map(virus => { return virus.collegeTestNumber; }),
        borderColor: 'rgba(0, 0, 0, 0)',
        backgroundColor: 'rgba(0,128,128,1)',
        borderWidth: 1
      });
      chartData.push({
        label: 'medicalTest',
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

      const dataDeath = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'death'}),
      };

      const dataHospitalization = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'hospitalization'}),
      };

      const dataPositive = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'positive'}),
      };

      const dataRecovery = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'recovery'}),
      };

      const dataSevere = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'severe'}),
      };

      const dataTest = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'test'}),
      };

      const dataCategory01 = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'death' || d.label == 'hospitalization' || d.label == 'positive' || d.label == 'recovery' || d.label == 'severe' || d.label == 'test'}),
      };

      const dataCategory02 = {
        labels: chartLabels,
        datasets: chartData.filter(d => {return d.label == 'nationalTest' || d.label == 'quarantineTest' || d.label == 'careCenterTest' || d.label == 'civilCenterTest' || d.label == 'collegeTest' || d.label == 'medicalTest'}),
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
          <Line  
          data={data} 
          options={options}/>
          <Bar  
          data={dataDeath} 
          options={options}/>
          <Bar  
          data={dataHospitalization} 
          options={options}/>
          <Bar  
          data={dataPositive} 
          options={options}/>
          <Bar  
          data={dataRecovery} 
          options={options}/>
          <Bar  
          data={dataSevere} 
          options={options}/>
          <Bar  
          data={dataTest} 
          options={options}/>
          <Line  
          data={dataCategory01} 
          options={options}/>
          <Line  
          data={dataCategory02} 
          options={options}/>
        </div>
        
      );
    }else{
      
      return(
        <div className="App-header">
          <p>Loading...</p>
          
        </div>
      );
    }
    
    
  }
}