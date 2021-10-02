import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/infection/';

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
      const query = data.filter(item => { return item.calc ==  category})
      console.log(query);
      

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
            data={query}
            options={{
              //showTitle: false,
              paging: false,
              // search: false,
              // draggable: false,
              filtering: true,
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

    //データ取得中処理
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