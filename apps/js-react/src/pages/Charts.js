import React, { Fragment } from 'react';
import { Line } from 'react-chartjs-2';

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
          data: this.getChartItem(json),
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
          config: this.getChartConfig(json),
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

  // getData() {
  //   const { data, labels } = fetchData(this.state.date); //日付に基づいた何らかのデータ取得処理
  //   this.setState({ data: data, labels: labels });
  // }

  getChartItem(dt) {
    const keys = Object.keys(dt[0]);
    console.log(keys);
    let result = [];
    for(let row in dt) {
      const item = dt[row];
      let unit = [];
      //ラベルデータ格納
      unit.push(item['date']);
      //チャートデータ格納
      for(let col in keys) {
        const key = keys[col];
        if(key != 'data') { continue; }
        //配列かどうかで分岐 配列ならforで詰め込む
        if(Array.isArray(item[key])) { for(let v in item[key]) { unit.push(item[key][v]); } }
        else if(item[key].indexOf(',') >= 0) { unit.push(item[key].split(',')); }
        else { unit.push(item[key]); }//title[col] == "data"
      }
      result.push(unit);//["2020/2/14","1","0","1","54"]
    }
    console.log('--- result : getChartData ---');
    console.log(result);
    return result;
  }
  
  getChartConfig(dt) {
    const keys = Object.keys(dt[0]);
    console.log(keys);
    let result = [];
    for(let row in dt) {
      const item = dt[row];
      result.push([
        item['id'],
        item['name'],
        item['chart_type'],
        item['background_color'],
        item['border_color'],
        item['border_width']
      ]);//["id","name","type","color",…]
    }
    console.log('--- result : getChartConfig ---');
    console.log(result);
    return result;
      
  }

  

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
            data: chartData[0],
            // 省略
          },
        ],
      };
      const options = {
        // 省略
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