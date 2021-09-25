import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

export default class InfectionTables extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
    };
  }

  componentDidMount() {
    this.populateChartItemAsync(this.props.calc);  
  }

  async populateChartItemAsync(param){
    
    const basepath = 'api/infection/calc/';

    await fetch(basepath + param)
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
        data: json,
        loading: false,
      });
    })
    .catch((error) =>{
      console.error('--- fetch error ' + basepath + this.props.calc + '---');
      console.error(error);
    });

  }

  render() {

    if(!this.state.loading){
      console.log('draw start');
      const data = this.state.data;
      console.log(data);
      

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
            data={data}
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