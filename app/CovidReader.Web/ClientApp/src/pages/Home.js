import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import ListSubheader from '@material-ui/core/ListSubheader';
import NoticeScreen from '../components/functions/NoticeScreen';
import SignIn from './SignIn';
import img01 from '../img/img01.jpg';
import img02 from '../img/img02.jpg';
import img03 from '../img/img03.jpg';
import img04 from '../img/img04.jpg';
import img05 from '../img/img05.jpg';

export default class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

    handleButtonClick() {
        fetch('api/home')
            .then((response) => {
                if (response.status === 200) {
                    return response.text();
                } else {
                    throw new Error();
                }
            })
            .then((data) => {
                alert(data);
            })
            .catch((error) => {
                alert("error");
                console.log(error);
            })
    }

    incrementCounter() {
      this.setState({
        currentCount: this.state.currentCount + 1
      });
    }

  render () {

    const useStyles = makeStyles((theme) =>
      createStyles({
        root: {
          display: 'flex',
          flexWrap: 'wrap',
          justifyContent: 'space-around',
          overflow: 'hidden',
          backgroundColor: theme.palette.background.paper,
        },
        gridList: {
          width: 500,
          height: 700,
        },
      }),
    );

    const tileData = [
      {
        img: img01,
        title: 'ダッシュボード',
        author: '',
      },
      {
        img: img02,
        title: '感染データチャート',
        author: '',
      },
      {
        img: img03,
        title: '感染データテーブル',
        author: '',
      },
      {
        img: img04,
        title: '登録',
        author: '',
      },
      {
        img: img05,
        title: 'モチーフ',
        author: '',
      },
    ];

    // const [commDlg, setCommDlg] = React.useState(false);
    // const execute = () => {}
    return (
      <div>
        <h1>新型コロナウイルス データ解析</h1>
        <div className={useStyles.root}>
          <GridList cellHeight={400} className={useStyles.gridList}>
            <GridListTile key="Subheader" cols={2} style={{ height: 'auto' }}>
              {/* <ListSubheader component="div">APIデータ</ListSubheader> */}
            </GridListTile>
            <GridListTile cols={2}>
              <p><button className="btn btn-primary" onClick={this.handleButtonClick}>API Update</button> <Link to="/signin" className="btn btn-primary">SignIn</Link> <Link to="/signup" className="btn btn-primary">SignUp</Link></p>
              <h3>ベースデータ</h3>
              <ul>
                <li>政府機関 : <a href='https://corona.go.jp/dashboard/'>内閣官房</a> / <a href='https://portal.opendata.go.jp/'>厚生労働省</a></li>
                <li>ニュース : <a href='https://www3.nhk.or.jp/news/special/coronavirus/data-widget/'>NHK</a></li>
              </ul>
              <p></p> 
              <h3>APIリスト</h3>
              <ul>
                <li><strong>全国の感染状況</strong> : <a href='https://opendata.corona.go.jp/api/Covid19JapanAll'>Covid19JapanAll.json</a> <code> itemList </code><em> date </em> <em> name_jp </em> <em> npatient </em> </li>
                <li><strong>全国累積死亡者数</strong> : <a href='https://opendata.corona.go.jp/api/Covid19JapanNdeaths'>Covid19JapanNdeaths.json</a> <code>itemList</code> <em> date </em> <em> ndeaths </em></li>
                <li><strong>世界感染状況</strong> : <a href='https://opendata.corona.go.jp/api/OccurrenceStatusOverseas'>OccurrenceStatusOverseas.json</a> </li>
                <li><strong>全国医療機関の医療提供体制の状況</strong> : <a href='https://opendata.corona.go.jp/api/covid19DailySurvey'>covid19DailySurvey.json</a></li>
              </ul>
            </GridListTile>
            {/* <GridListTile cols={1}>
              <SignIn></SignIn>
            </GridListTile> */}
          </GridList>
        </div>
        <h3>コンテンツリスト</h3>
        <div className={useStyles.root}>
          <GridList cellHeight={200} className={useStyles.gridList}>
            <GridListTile key="Subheader" cols={2} style={{ height: 'auto' }}>
              {/* <ListSubheader component="div">タイルリスト</ListSubheader> */}
            </GridListTile>
            {tileData.map((tile) => (
              <GridListTile key={tile.img}>
                <img src={tile.img} alt={tile.title} />
                <GridListTileBar
                  title={tile.title}
                  subtitle={<span>{tile.author}</span>}
                />
              </GridListTile>
            ))}
          </GridList>
        </div>
        
        {/* <div className={useStyles.root}>
          <GridList cellHeight={100} className={useStyles.gridList}>
            <GridListTile key="Subheader" cols={2} style={{ height: 'auto' }}>
              <ListSubheader component="div"> <code>ClientApp</code> テストコマンド</ListSubheader>
            </GridListTile>
            <GridListTile cols={1}>
              <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>
              <p><button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button></p>
            </GridListTile>
            <GridListTile cols={1}>
              <p><Link to="/signin" className="btn btn-primary">SignIn</Link></p>          
              <p><Link to="/signup" className="btn btn-primary">SignUp</Link></p>
            </GridListTile>
            <GridListTile cols={1}>
              <p><NoticeScreen></NoticeScreen></p>
            </GridListTile>
          </GridList>
        </div> */}

           
      </div>
    );
  }
}
