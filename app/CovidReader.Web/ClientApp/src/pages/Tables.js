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
      loading:false,
    };
  }

  componentDidMount() {
    this.populateChartItemAsync();
    
  }

  async populateChartItemAsync(){
    
    await fetch('api/chartitem')
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
        data: getItems(json),
      });
      
    })
    .catch((error) =>{
      console.error('--- fetch error api/ChartItem ---');
      console.error(error);
    });

    await fetch('api/chartconfig')
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
        config: getTableConfigs(json),
      });

    })
    .catch((error) =>{
      console.error('--- fetch error api/ChartConfig ---');
      console.error(error);
    });

    this.setState({
      loading: true
    })

  }

  

  render() {

    if(this.state.loading){
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