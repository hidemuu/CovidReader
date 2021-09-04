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

    fetch('chart_item.json')
      .then((response) => response.json())
      .then((json) => {
        console.log(json);
        this.setState({
          data: getItems(json),
          loadingitem: true
        });
        
      })
      .catch((error) =>{
        console.error('--- fetch error 01 ---');
        console.error(error);
      });

    fetch('chart_config.json')
      .then((response) => response.json())
      .then((json) => {
        console.log(json);
        this.setState({
          config: getChartConfigs(json),
          loadingconfig: true
        });

      })
      .catch((error) =>{
        console.error('--- fetch error 02 ---');
        console.error(error);
      });
  }

  // componentDidUpdate(prevProps, prevState) {
  //   if (prevState.date !== this.state.date) {
  //     this.getData();
  //   }
  // }

  
  

  render() {

    if(this.state.loadingitem && this.state.loadingconfig){
      console.log('draw start');
      const items = this.state.data;
      const configs = this.state.config;

      let chartLabels = [], chartData = [];//オブジェクト配列形式に変更

      //コンフィグ成形
      for(let row in configs) {
        const config = configs[row];//id,title,type,bg,color,width
        chartData.push({
          label: config[1],
          data: [],
          borderColor: config[3],
          backgroundColor: config[4],
          borderWidth: config[5]
        });  
      }
      
      //データ成形
      //	ラベル（項目はひとつ）
      //	データ系列の数だけ設定
      for(let row in items) {
        const item = items[row];
        chartLabels.push(item[0]);
        //データ系列の数だけ設定
        for(let i in item[1]) { chartData[i].data.push(item[1][i]); }
      };
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      console.log('--- drawData : chartData -----');
      console.log(chartData);

      const data = {
        labels: chartLabels,
        datasets: chartData,
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
        <Line  
          data={data} 
          // border_color={this.state.chartBorderColors[0]} 
          // background_color={this.state.chartBackgroundColors[0]} 
          // border_width={this.chartBorderWidthes[0]}
          options={options}/>
        // <Fragment>
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