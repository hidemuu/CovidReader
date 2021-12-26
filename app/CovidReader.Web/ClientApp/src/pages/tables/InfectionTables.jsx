import React from "react";
import getStateDate from "../../commons/getStartDate";
import CircularProgress from "@material-ui/core/CircularProgress";
import Table from "../../components/views/atoms/Table";
const basepath = 'api/infection/';
const title = '感染状況';
const labels = ['日付', '死亡者数', '入院者数', '陽性者数', '回復者数', '重傷者数', '検査数'];
const fields = ['date', 'deathNumber', 'cureNumber', 'patientNumber', 'recoveryNumber', 'severeNumber', 'testNumber'];
const isEnables = [true, true, false, true, false, false, false];

//感染データテーブル生成クラス
export default class InfectionTables extends React.Component {

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

  //テーブルデータ取得
  async populateItemAsync(){
    
    await fetch(basepath)
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
      console.error('--- fetch error ' + basepath + '---');
      console.error(error);
    });

  }

  //レンダリング
  render() {

      //データ取得完了後処理
      if (!this.state.loading) {

          const startTime = performance.now(); // 開始時間

          console.log('draw start');
          let startDate = getStateDate(this.props.endDate, this.props.dateFilter);

          const df = this.state.data.filter(item => { return item.calc == this.props.calc }).filter(item => { return new Date(item.date) >= startDate && new Date(item.date) <= this.props.endDate });
          const query = df.map(item => {
              return {
                  date: item.date,
                  deathNumber: item.deathNumber,
                  patientNumber: item.patientNumber,
              }
          });
          console.log(query);
          let tableColumns = [];
          let c = 0;
          for (let i = 0; i < labels.length; i++) {
              if (isEnables[i] === true) {
                  tableColumns.push({
                      title: labels[c],
                      field: fields[c],
                      cellStyle: { textAlign: 'right' },
                  });
                  c++;
              }
          }

          const endTime = performance.now(); // 終了時間

          console.log(endTime - startTime); // 何ミリ秒かかったかを表示する

          return (
              <Table
                  title={title}
                  columns={tableColumns}
                  data={query}
              />
          );

          //データ取得中処理
      } else {

          return (
              <CircularProgress color="inherit" />
          );
      }

      
  }
}