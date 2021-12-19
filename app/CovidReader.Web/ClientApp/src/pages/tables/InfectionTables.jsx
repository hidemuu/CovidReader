import React from "react";
import TableTemplate from "../../templates/TableTemplate";

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

      return (
          <TableTemplate
              title={title}
              labels={labels}
              fields={fields}
              isEnables={isEnables}
              loading={this.state.loading}
              data={this.state.data}
              category={this.props.calc}
              endDate={this.props.endDate}
              dateFilter={this.props.dateFilter}
          />
          );
  }
}