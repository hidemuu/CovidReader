import React from "react";
import BootstrapTable from "react-bootstrap-table-next";
import { Container } from 'reactstrap';
//import cellEditFactory, { Type } from "react-bootstrap-table2-editor";
import getItems from "../components/functions/getItems";
import getTableConfigs from "../components/functions/getTableConfigs";

export default class Tables extends React.Component {

  constructor(props) {
    super(props);
    this.state={
      loadingitem: false,
      loadingconfig: false,
    };
  }

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
          config: getTableConfigs(json),
          loadingconfig: true
        });

      })
      .catch((error) =>{
        console.error('--- fetch error 02 ---');
        console.error(error);
      });
  }

  

  render() {

    if(this.state.loadingitem && this.state.loadingconfig){
    console.log('draw start');
      
    const configs = this.state.config;
    let columns = [{ dataField: 'date', text: 'date', sort: true, editable: false }];
    for(let i in configs){
      columns.push({ dataField: 'data' + i, text: configs[i][0], sort: true, editable: false });
    }
    // { dataField: "type", text: "Type", sort: true, editable: true
        // // editor: {
        // //     type: Type.SELECT,
        // //     getOptions: () => types.map((type) => { return { value: type, label: type } })
        // //   } 
        // },
    
    console.log('--- makeColumns ---');
    console.log(columns);

    const items = this.state.data;
    let data = [];
    for(let row in items){
      const item = items[row];
      let tmp = { date: item[0] };
      for(let i in item[1]){ tmp['data' + i] = item[1][i]; }
      data.push(tmp);
    }
    console.log('--- makeData ---');
    console.log(data);
    // const data = [
      //   { date: *, data: "**"},
      //   { date: *, data: "**"},
      // ]

    return (
        <Container style={{ width: "800px" }}>
        <BootstrapTable
          data={data}             // データ
          columns={columns}       // カラム定義
          keyField="date"           // キー
          bootstrap4={true}       // Bootstrap4を指定。デフォルトではBootstrap3
          bordered={true}         // 表のボーダー
          //cellEdit={cellEditFactory({ mode: "click", blurToSave: true })}  // セルの編集を有効にする
        />
      </Container>
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