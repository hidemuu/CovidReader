import React, { Fragment } from 'react';
import { Line } from 'react-chartjs-2';
import getItems from "../components/functions/getItems";
import getChartConfigs from "../components/functions/getChartConfigs";

export default class Charts extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      loadingitem: false,
      loadingconfig: false,
    };
  }

  // handleClick(elements) {
  //   if (elements.length === 0) return;
  //   console.log(elements[0]._index);
  // }

  componentDidMount() {
    this.populateChartItemAsync();  
  }

  async populateChartItemAsync(){
    // this.setState({
    //   data: await getItems('api/chartitem'),
    // });
    await fetch('api/chartitem')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        data: getItems(json),
        loadingitem: true
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/ChartItem ---');
      console.error(error);
    });

    await fetch('api/chartconfig')
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        config: getChartConfigs(json),
        loadingconfig: true
      });

    })
    .catch((error) =>{
      console.error('--- fetch error api/ChartConfig ---');
      console.error(error);
    });
  }

  // componentDidUpdate(prevProps, prevState) {
  //   if (prevState.date !== this.state.date) {
  //     this.getData();
  //   }
  // }

  mappingChartData(config) {
    let chartData;
    // chartData.push({
      //   label: config.name,
      //   data: [],
      //   borderColor: config.borderColor,
      //   backgroundColor: config.backgroundColor,
      //   borderWidth: config.borderWidth
      // });  
      chartData = {
        label: config[1],
        data: [],
        borderColor: config[3],
        backgroundColor: config[4],
        borderWidth: config[5]
      };  
      return chartData;
  }
  

  render() {

    if(this.state.loadingitem && this.state.loadingconfig){
      console.log('draw start');
      const items = this.state.data;
      const configs = this.state.config;

      //個別チャート
      // let eachChartData = [];
      // let eachChartLabels = [];
      // let count = 0;
      // for(let row in configs){
      //   const config = configs[row];
      //   let data = [];
      //   data.push(this.mappingChartData(config));
      //   eachChartData.push(data);
      //   count++;
      // }
      // for(let row in items){
      //   const item = items[row];
      //   const date = item[0];
      //   const datas = item[1]; //コンマ区切り配列
      //   eachChartLabels.push(date);
      //   for(let i in datas) { 
          
      //     eachchartData[i].data.push(datas[i]);
      //   }
      // }

      //全部入りチャート
      let chartData = [];
      let chartLabels = [];
      for(let row in configs) {
        const config = configs[row];//id,title,type,bg,color,width
        chartData.push(this.mappingChartData(config));
      }
      for(let row in items) {
        const item = items[row];
        const date = item[0];
        const datas = item[1]; //コンマ区切り配列
        chartLabels.push(date);
        for(let i in datas) { chartData[i].data.push(datas[i]); }
      };
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      console.log('--- drawData : chartData -----');
      console.log(chartData);

      const data = {
        labels: chartLabels,
        datasets: chartData,
      };

      // const data01 = {
      //   labels: chartLabels,
      //   datasets: chartData[0],
      // };

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
          {/* <Line  
          data={data01} 
          options={options}/> */}
        </div>
        //<Fragment>
          //   <DatePicker date={date} onDateChange={ (newDate) => { return this.setState({ date: newDate }); }} /> //何らかの日付変更処理
          //   <Line data={data} options={options} />
          // </Fragment>
        
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