import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
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
    if(!this.state.loading){
      console.log('draw start');
      const data = this.state.data;
      const category = this.props.calc;
      //日付フィルタ ADD 2021.10.02
      const endDate = new Date(this.props.endDate);
      const dateFilter = this.props.dateFilter;
      let startDate = new Date(this.props.endDate);
      if(dateFilter == 'week'){
        startDate.setDate( startDate.getDate() - 7);
      }else if(dateFilter == 'month'){
        startDate.setDate( startDate.getDate() - 30);
      }else if(dateFilter == 'year'){
        startDate.setDate( startDate.getDate() - 365);
      }else{
        startDate.setDate( startDate.getDate() - 365);
      }

      const query = data.filter(item => { return item.calc ==  category}).filter(item => {return new Date(item.date) >= startDate && new Date(item.date) <= endDate});
      console.log(query);
      let tableColumns = [];
      let c = 0;
      for (let i = 0; i < labels.length; i++){
        if (isEnables[i] === true){
          tableColumns.push({
            title: labels[c],
            field: fields[c],
            cellStyle: { textAlign: 'right' },
          });
          c++;
        }
      }

      return(
        <div>
          <MaterialTable
            title={title}
            columns={tableColumns}
            data={query}
            options={{
              //showTitle: false,
              paging: false,
              // search: false,
              // draggable: false,
              // filtering: true,
              maxBodyHeight: 500,
              headerStyle: { 
                position: 'sticky', 
                top: 0,
                minWidth: 150,
               },
            }}
          />
        </div>
      );

    //データ取得中処理
    }else{
      
      return(
        <CircularProgress color="inherit" />
        // <div className="App-header">
        //   <p>Loading...</p>
        //   <CircularProgress color="inherit" />
        // </div>
      );
    }

  }
}