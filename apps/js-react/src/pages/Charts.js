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

      //コンフィグ成形
      let chartIds = [], chartTitles = [], chartTypes = [], chartBackgroundColors = [], chartBorderColors = [], chartBorderWidthes = [];

      for(let row in configs) {
        const config = configs[row];
        chartIds.push(config[0]);
        chartTitles.push(config[1]);
        chartTypes.push(config[2]);
        chartBackgroundColors.push(config[3]);
        chartBorderColors.push(config[4]);
        chartBorderWidthes.push(config[5]);
      }
      console.log('--- drawData : chartConfig -----');
      console.log(chartIds);
      console.log(chartTitles);
      console.log(chartTypes);
      console.log(chartBackgroundColors);
      console.log(chartBorderColors);
      console.log(chartBorderWidthes);

      //データ成形
      //	ラベル（項目はひとつ）
      //	データ系列の数だけ設定
      let chartLabels = [], chartData = [];
      for(let row in items) {
        const item = items[row], dataItem = item[1];
        chartLabels.push(item[0]);
        while(chartData.length < dataItem.length) { chartData.push([]); }
      //データ系列の数だけ設定
        for(let i = 0; i < dataItem.length; i++) { chartData[i].push(dataItem[i]); }
      };
      console.log('--- drawData : chartLabels -----');
      console.log(chartLabels);
      console.log('--- drawData : chartData -----');
      console.log(chartData);

      const data = {
        labels: chartLabels,
        datasets: [
          {
            label: chartTitles[0],
					  data: chartData[0],
					  borderColor: chartBorderColors[0],
					  backgroundColor: chartBackgroundColors[0],
					  borderWidth: chartBorderWidthes[0]
          },
          {
            label: chartTitles[1],
            data: chartData[1],
            borderColor: chartBorderColors[1],
            backgroundColor: chartBackgroundColors[1],
            borderWidth: chartBorderWidthes[1]
          },
          {
            label: chartTitles[2],
            data: chartData[2],
            borderColor: chartBorderColors[2],
            backgroundColor: chartBackgroundColors[2],
            borderWidth: chartBorderWidthes[2]
          },
          {
            label: chartTitles[3],
            data: chartData[3],
            borderColor: chartBorderColors[3],
            backgroundColor: chartBackgroundColors[3],
            borderWidth: chartBorderWidthes[3]
          }
        ],
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