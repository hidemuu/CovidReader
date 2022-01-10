import * as React from "react";
import { Link } from "react-router-dom";
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import styles from "../components/styles/styles";

export default class HomeTemplate extends React.Component<Model.IHomeTemplate> {

    render(): JSX.Element {
        return (
            <div>
                <h1>新型コロナウイルス データ解析</h1>
                <div className={styles().home}>
                    <GridList cellHeight={400} className={styles().gridList}>
                        <GridListTile key="Subheader" cols={2} style={{ height: 'auto' }}>
                        </GridListTile>
                        <GridListTile cols={2}>
                            <p><button className="btn btn-primary" onClick={this.props.onClickUpdateButton}>API Update</button> <Link to="/signin" className="btn btn-primary">SignIn</Link> <Link to="/signup" className="btn btn-primary">SignUp</Link></p>
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
                    </GridList>
                </div>
                <h3>コンテンツリスト</h3>
                <div className={styles().home}>
                    <GridList cellHeight={400} className={styles().gridList}>
                        <GridListTile key="Subheader" cols={2} style={{ height: 'auto' }}>
                        </GridListTile>
                        {/*{this.props.contentsTileData.map((tile) => (*/}
                        {/*    <GridListTile key={tile.img}>*/}
                        {/*        <img src={tile.img} alt={tile.title} />*/}
                        {/*        <GridListTileBar*/}
                        {/*            title={tile.title}*/}
                        {/*            subtitle={<span>{tile.author}</span>}*/}
                        {/*        />*/}
                        {/*    </GridListTile>*/}
                        {/*))}*/}
                    </GridList>
                </div>


            </div>
        );
    }
}