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
    const columns = [
        { dataField: 'date', text: 'date', sort: true, editable: false },
        { dataField: 'data01', text: configs[0][0], sort: true, editable: false },
        { dataField: 'data02', text: configs[1][0], sort: true, editable: false },
        { dataField: 'data03', text: configs[2][0], sort: true, editable: false },
        { dataField: 'data04', text: configs[3][0], sort: true, editable: false },
        // { dataField: "type", text: "Type", sort: true, editable: true
        // // editor: {
        // //     type: Type.SELECT,
        // //     getOptions: () => types.map((type) => { return { value: type, label: type } })
        // //   } 
        // },
    ]
    console.log('--- makeColumns ---');
    console.log(columns);

    const items = this.state.data;
    const data = [];
    for (let row in items){
      data.push({ date: items[row][0], data01: items[row][1][0], data02: items[row][1][1], data03: items[row][1][2], data04: items[row][1][3] });
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