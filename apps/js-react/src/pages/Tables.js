import React from "react";
import BootstrapTable from "react-bootstrap-table-next";
import { Container } from 'reactstrap';
//import cellEditFactory, { Type } from "react-bootstrap-table2-editor";

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
          data: json,
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
          config: json,
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

      // const data = [
      //   { date: *, data: "**"},
      //   { date: *, data: "**"},
      // ]

    const columns = [
        { dataField: "date", text: "Date", sort: true, editable: false },
        { dataField: "data", text: "Data", sort: true, editable: false },
        // { dataField: "type", text: "Type", sort: true, editable: true
        // // editor: {
        // //     type: Type.SELECT,
        // //     getOptions: () => types.map((type) => { return { value: type, label: type } })
        // //   } 
        // },
    ]

    return (
        <Container style={{ width: "600px" }}>
        <BootstrapTable
          data={this.state.data}             // データ
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