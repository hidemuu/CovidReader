import React from "react";
import {Button} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import MaterialTable from 'material-table';

export default class VirusTables extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      viruses: [],
      loading:true,
    };
  }

  componentDidMount() {
    this.populateChartItemAsync();  
  }

  async populateChartItemAsync(){
    
    await fetch('api/virus')
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
        viruses: json,
        loading: false,
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/Virus ---');
      console.error(error);
    });
  }

  

  render() {

    const tableType = 0;

    if(!this.state.loading){
      console.log('draw start');
      const viruses = this.state.viruses;
      console.log('viruses');
      console.log(viruses);
      const classStyle = makeStyles ({
        tableContainer: {
          width: 1000,
          justifyContent: 'center'
        },
        table: {
          minWidth: 650,
        },
        table_sticky: {
          display: 'block',
          overflow: 'auto',
          overflowY: 'scroll',
          "& thead": {
            "& th": {
              position: 'sticky',
              top: 0,
              zIndex: 1,
              background: 'whitesmoke',
              borderTop: 'white',
              textAlign: 'center',
            }
          }
        }
      });
      if (tableType == 0){
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
                  field: 'hospitalizationNumber',
                  cellStyle: { textAlign: 'right' },
                },
                {
                  title: '陽性者数',
                  field: 'positiveNumber',
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
              data={viruses}
              options={{
                //showTitle: false,
                paging: false,
                maxBodyHeight: 700,
                headerStyle: { position: 'sticky', top: 0 },
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
              data={viruses}
              options={{
                //showTitle: false,
                paging: false,
                maxBodyHeight: 700,
                headerStyle: { position: 'sticky', top: 0 },
              }}
            />
          </div>
          
        );
        
        
      }
      else if (tableType == 1){
        return (
          <div>
            <TableContainer component={Paper} className={classStyle.tableContainer}>
              <Table className={classStyle.table_sticky} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>Death</TableCell>
                    <TableCell>Hospitalization</TableCell>
                    <TableCell>Positive</TableCell>
                    <TableCell>Recovery</TableCell>
                    <TableCell>Severe</TableCell>
                    <TableCell>Test</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                {viruses.map((virus) => (
                    <TableRow> 
                      <TableCell>{virus.date}</TableCell>
                      <TableCell>{virus.deathNumber}</TableCell>
                      <TableCell>{virus.hospitalizationNumber}</TableCell>
                      <TableCell>{virus.positiveNumber}</TableCell>
                      <TableCell>{virus.recoveryNumber}</TableCell>
                      <TableCell>{virus.severeNumber}</TableCell>
                      <TableCell>{virus.testNumber}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
            {/* <TableContainer component={Paper} className={classStyle.tableContainer}>
              <Table className={classStyle.table} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>NationalTest</TableCell>
                    <TableCell>QuarantineTest</TableCell>
                    <TableCell>CareCenter</TableCell>
                    <TableCell>CivilCenter</TableCell>
                    <TableCell>CollegeTest</TableCell>
                    <TableCell>MedicalTest</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                {viruses.map((virus) => (
                    <TableRow key={virus.date}> 
                      <TableCell>{virus.date}</TableCell>
                      <TableCell>{virus.nationalTestNumber}</TableCell>
                      <TableCell>{virus.quarantineTestNumber}</TableCell>
                      <TableCell>{virus.careCenterTestNumber}</TableCell>
                      <TableCell>{virus.civilCenterTestNumber}</TableCell>
                      <TableCell>{virus.collegeTestNumber}</TableCell>
                      <TableCell>{virus.medicalTestNumber}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer> */}
            
          </div>
          
        );

      }else{

        return (
          <div>
            <table className='table table-striped table-hover table-sm table-responsive table-sticky' aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Death</th>
                  <th>Hospitalization</th>
                  <th>Positive</th>
                  <th>Recovery</th>
                  <th>Severe</th>
                  <th>Test</th>
                  
                </tr>
              </thead>
              <tbody>
                {viruses.map(virus =>
                  <tr key={virus.date}>
                    <td>{virus.date}</td>
                    <td>{virus.deathNumber}</td>
                    <td>{virus.hospitalizationNumber}</td>
                    <td>{virus.positiveNumber}</td>
                    <td>{virus.recoveryNumber}</td>
                    <td>{virus.severeNumber}</td>
                    <td>{virus.testNumber}</td>
                    
                  </tr>
                )}
              </tbody>
            </table>
            <table className='table table-striped table-hover table-sm table-responsive table-sticky' aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>NationalTest</th>
                  <th>QuarantineTest</th>
                  <th>CareCenter</th>
                  <th>CivilCenter</th>
                  <th>CollegeTest</th>
                  <th>MedicalTest</th>
                </tr>
              </thead>
              <tbody>
                {viruses.map(virus =>
                  <tr key={virus.date}>
                    <td>{virus.date}</td>
                    <td>{virus.nationalTestNumber}</td>
                    <td>{virus.quarantineTestNumber}</td>
                    <td>{virus.careCenterTestNumber}</td>
                    <td>{virus.civilCenterTestNumber}</td>
                    <td>{virus.collegeTestNumber}</td>
                    <td>{virus.medicalTestNumber}</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        );
      }

    }else{
      
      return(
        <div className="App-header">
          <p>Loading...</p>
          
        </div>
      );
    }

  }
}