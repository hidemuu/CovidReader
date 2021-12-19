import React from 'react';
import ChartTemplate from "../../templates/ChartTemplate";

//定数
const basepath = 'api/infection/';
const chartTypes = ['bar', 'bar', 'bar', 'bar', 'bar', 'bar'];
const yAxisIDs = ['y-axis', 'y-axis', 'y-axis', 'y-axis', 'y-axis', 'y-axis'];
const labels = ['死亡者', '入院者', '陽性者', '治癒者', '重傷者', '検査者']; //EDIT 2021.09.29 ラベルデータをユニーク変数名から配列に変更（汎用化）
const borderColors = ['rgba(0, 0, 0, 0)', 'rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)','rgba(0, 0, 0, 0)']; //ADD 2021.09.29 ボーダー色を宣言
const backgroundColors = ['rgba(255,0,0,1)', 'rgba(0,255,0,1)', 'rgba(0,0,255,1)', 'rgba(255,255,0,1)', 'rgba(0,255,255,1)', 'rgba(255,0,255,1)']; //ADD 2021.09.29 背景色を宣言
const borderWidthes = [1, 1, 1, 1, 1, 1];
const isEnables = [true, false, true, false, false, false];

//感染データチャート生成クラス
export default class InfectionCharts extends React.Component {

  //コンストラクタ
  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
    };
  }

  //マウント時イベントハンドラ
  componentDidMount() {
    this.populateItemAsync();  
  }

  //チャートデータ取得
  async populateItemAsync(){

    console.log(basepath);
    await fetch(basepath)
    .then((response) => response.json())
    .then((json) => {
      console.log(json);
      this.setState({
        data: json,
        loading: false,
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error ' + basepath +  '---');
      console.error(error);
    });

  }

  //レンダリング
  render() {
      return (
          <ChartTemplate
              chartTypes={chartTypes}
              labels={labels}
              borderColors={borderColors}
              backgroundColors={backgroundColors}
              borderWidthes={borderWidthes}
              isEnables={isEnables}
              loading={this.state.loading}
              data={this.state.data}
              category={this.props.calc}
              disp={this.props.disp}
              endDate={this.props.endDate}
              dateFilter={this.props.dateFilter}
          />
      );
  }
}