import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

export default class InfectionTables extends React.Component {

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
    
    await fetch('api/infection/calc/daily')
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      } else {
        throw new Error();
      }
    })
    .then((json) => {
      console.log(json);
      this.setState({
        infections: json,
        loadinginfections: false,
      });
    })
    .catch((error) =>{
      console.error('--- fetch error api/Infection ---');
      console.error(error);
    });

    await fetch('api/infection/calc/total')
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

    await fetch('api/inspection/calc/daily')
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      } else {
        throw new Error();
      }
    })
    .then((json) => {
      console.log(json);
      this.setState({
        viraltests: json,
        loadingviraltests: false,
      });
    })
    .catch((error) =>{
      console.error('--- fetch error api/ViralTest ---');
      console.error(error);
    });

    await fetch('api/inspection/calc/total')
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

    if(!this.state.loadinginfections && !this.state.loadingviraltests && !this.state.loadinginfectiontotals && !this.state.loadingviraltesttotals){
      console.log('draw start');
      const infections = this.state.infections;
      const viraltests = this.state.viraltests;
      const infectiontotals = this.state.infectiontotals;
      const viraltesttotals = this.state.viraltesttotals;
      console.log('infections');
      console.log(infections);
      

      return(
        <div>
          <MaterialTable
            title={'感染状況'}
            columns={[
              {
                title: '日付',
                field: 'date',
              },
              { 
                title: '死亡者数',
                field: 'deathNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '入院者数',
                field: 'cureNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '陽性者数',
                field: 'patientNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '回復者数',
                field: 'recoveryNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '重傷者数',
                field: 'severeNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '検査数',
                field: 'testNumber',
                cellStyle: { textAlign: 'right' },
              },
            ]}
            data={infections}
            options={{
              //showTitle: false,
              paging: false,
              maxBodyHeight: 700,
              headerStyle: { 
                position: 'sticky', 
                top: 0,
                minWidth: 150,
               },
            }}
          />
          <p></p>
          <MaterialTable
            title={'検査状況'}
            columns={[
              {
                title: '日付',
                field: 'date',
              },
              { 
                title: '国立感染症研究所',
                field: 'nationalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '検疫所',
                field: 'quarantineTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '保健所',
                field: 'careCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '民間検査',
                field: 'civilCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '大学',
                field: 'collegeTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '医療機関',
                field: 'medicalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
            ]}
            data={viraltests}
            options={{
              //showTitle: false,
              paging: false,
              maxBodyHeight: 700,
              headerStyle: { position: 'sticky', top: 0 },
            }}
          />
          <p></p>
          <MaterialTable
            title={'累計感染状況'}
            columns={[
              {
                title: '日付',
                field: 'date',
              },
              { 
                title: '死亡者数',
                field: 'deathNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '入院者数',
                field: 'cureNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '陽性者数',
                field: 'patientNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '回復者数',
                field: 'recoveryNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '重傷者数',
                field: 'severeNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '検査数',
                field: 'testNumber',
                cellStyle: { textAlign: 'right' },
              },
            ]}
            data={infectiontotals}
            options={{
              //showTitle: false,
              paging: false,
              maxBodyHeight: 700,
              headerStyle: { 
                position: 'sticky', 
                top: 0,
                minWidth: 150,
               },
            }}
          />
          <p></p>
          <MaterialTable
            title={'累計検査状況'}
            columns={[
              {
                title: '日付',
                field: 'date',
              },
              { 
                title: '国立感染症研究所',
                field: 'nationalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '検疫所',
                field: 'quarantineTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '保健所',
                field: 'careCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '民間検査',
                field: 'civilCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '大学',
                field: 'collegeTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '医療機関',
                field: 'medicalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
            ]}
            data={viraltesttotals}
            options={{
              //showTitle: false,
              paging: false,
              maxBodyHeight: 700,
              headerStyle: { position: 'sticky', top: 0 },
            }}
          />
        </div>
        
      );

    }else{
      
      return(
        <div className="App-header">
          <p>Loading...</p>
          <CircularProgress color="inherit" />
          
        </div>
      );
    }

  }
}