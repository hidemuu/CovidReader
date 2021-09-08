import React from "react";

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

    if(!this.state.loading){
      console.log('draw start');
      const viruses = this.state.viruses;

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

    }else{
      
      return(
        <div className="App-header">
          <p>Loading...</p>
          
        </div>
      );
    }

  }
}