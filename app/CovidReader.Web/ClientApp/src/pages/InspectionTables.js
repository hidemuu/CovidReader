import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

//定数
const basepath = 'api/inspection/calc/';

//検査データテーブル表示クラス
export default class InspectionTables extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      data: [],
      loading:true,
    };
  }

  //マウント時イベントハンドラ
  componentDidMount() {
    this.populateItemAsync(this.props.calc);  
  }

  //テーブルデータ取得
  async populateItemAsync(param){
    
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

  //レンダリング
  render() {

    //データ取得完了後処理
    if(!this.state.loading){
      console.log('draw start');
      const data = this.state.data;
      console.log(data);
      

      return(
        <div>
          <MaterialTable
            title={'検査状況'}
            columns={[
              {
                title: '日付',
                field: 'date',
              },
              { 
                title: '国立感染症研究所',
                field: 'nationalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '検疫所',
                field: 'quarantineTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '保健所',
                field: 'careCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '民間検査',
                field: 'civilCenterTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '大学',
                field: 'collegeTestNumber',
                cellStyle: { textAlign: 'right' },
              },
              {
                title: '医療機関',
                field: 'medicalTestNumber',
                cellStyle: { textAlign: 'right' },
              },
            ]}
            data={data}
            options={{
              //showTitle: false,
              paging: false,
              maxBodyHeight: 700,
              headerStyle: { position: 'sticky', top: 0 },
            }}
          />
          <p></p>         
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