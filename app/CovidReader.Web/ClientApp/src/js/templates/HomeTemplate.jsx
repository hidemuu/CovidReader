import React from 'react';
import { Link } from "react-router-dom";
import Grid from '@material-ui/core/Grid';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import Creatable from 'react-select/creatable';
import img01 from '../../assets/img/img01.jpg';
import img02 from '../../assets/img/img02.jpg';
import img03 from '../../assets/img/img03.jpg';
import imgAreaPositiveTotal from '../../assets/img/area_positive_total.jpg';
import imgAreaPositiveTotalChart from '../../assets/img/area_positive_total_chart.jpg';
import imgCard from '../../assets/img/card.jpg';
import imgCure from '../../assets/img/cure.jpg';
import imgDeathTotal from '../../assets/img/death_total.jpg';
import imgPositiveTotal from '../../assets/img/positive_total.jpg';
import styles from "../components/styles/styles";

export default class HomeTemplate extends React.Component {
    render() {
        const { onClickUpdateButton, contentsTileData } = this.props;
        return (
            <div>
                <Grid container spacing={3}>
                    <Grid item xs={12}>
                        <h1 className={styles.h1}>新型コロナウイルス データ解析</h1>
                        <div className={styles.home}>
                            <Grid container justify="space-between">
                                <Grid item>
                                    <Grid container justify="fix-start" spacing={2}>
                                        <Grid item>
                                            <button className="btn btn-primary" onClick={onClickUpdateButton}>API Update</button><a> </a>
                                        </Grid>
                                        <Grid item>
                                            <Link to="/signin" className="btn btn-primary">SignIn</Link>
                                        </Grid>
                                        <Grid item>
                                            <Link to="/signup" className="btn btn-primary">SignUp</Link>
                                        </Grid>
                                    </Grid>
                                </Grid>
                                <Grid item>
                                    <Creatable></Creatable>
                                </Grid>
                            </Grid>
                        </div>
                    </Grid>
                    <Grid item xs={12}>
                        <h3>ダッシュボード</h3>
                        <div className={styles.home}>
                            <GridList cellHeight={400} className={styles.gridList} cols={3}>
                                {contentsTileData.map((tile) => (
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
                    </Grid>
                    <Grid item xs={12}>
                        <h3>全国の感染者数</h3>
                        <div className={styles.home}>
                            <GridList cellHeight={400} className={styles.gridList} cols={3}>
                                <GridListTile>
                                    <img src={imgPositiveTotal} alt={'test'} />
                                    <GridListTileBar
                                        title={'累計陽性者数'}
                                        subtitle={<span>{'chart'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgCure} alt={'test'} />
                                    <GridListTileBar
                                        title={'治療者数'}
                                        subtitle={<span>{'chart'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgDeathTotal} alt={'test'} />
                                    <GridListTileBar
                                        title={'累計死亡者数'}
                                        subtitle={<span>{'chart'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile cols={2}>
                                    <img src={imgAreaPositiveTotal} alt={'test'} />
                                    <GridListTileBar
                                        title={'地域別感染者数'}
                                        subtitle={<span>{'map'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgAreaPositiveTotalChart} alt={'test'} />
                                    <GridListTileBar
                                        title={'地域別感染者数'}
                                        subtitle={<span>{'chart'}</span>}
                                    />
                                </GridListTile>
                            </GridList>
                        </div>
                    </Grid>
                    <Grid item xs={12}>
                        <h3>人流の推移</h3>
                        <div className={styles.home}>
                            <GridList cellHeight={200} className={styles.gridList} cols={8}>
                                <GridListTile>
                                    <img src={imgCard} alt={'test'} />
                                    <GridListTileBar
                                        title={'test'}
                                        subtitle={<span>{'author'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgCard} alt={'test'} />
                                    <GridListTileBar
                                        title={'test'}
                                        subtitle={<span>{'author'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgCard} alt={'test'} />
                                    <GridListTileBar
                                        title={'test'}
                                        subtitle={<span>{'author'}</span>}
                                    />
                                </GridListTile>
                                <GridListTile>
                                    <img src={imgCard} alt={'test'} />
                                    <GridListTileBar
                                        title={'test'}
                                        subtitle={<span>{'author'}</span>}
                                    />
                                </GridListTile>
                            </GridList>
                        </div>
                    </Grid>
                    <Grid item xs={12}>
                        <div className={styles.home}>
                            <h3>参照元（ベースデータ）</h3>
                            <div className={styles.home}>
                                <ul>
                                    <li>政府機関 : <a href='https://corona.go.jp/dashboard/'>内閣官房</a> / <a href='https://portal.opendata.go.jp/'>厚生労働省</a></li>
                                    <li>ニュース : <a href='https://www3.nhk.or.jp/news/special/coronavirus/data-widget/'>NHK</a></li>
                                </ul>
                            </div>
                            <h3>APIリスト</h3>
                            <div className={styles.home}>
                                <ul>
                                    <li><strong>全国の感染状況</strong> : <a href='https://opendata.corona.go.jp/api/Covid19JapanAll'>Covid19JapanAll.json</a> <code> itemList </code><em> date </em> <em> name_jp </em> <em> npatient </em> </li>
                                    <li><strong>全国累積死亡者数</strong> : <a href='https://opendata.corona.go.jp/api/Covid19JapanNdeaths'>Covid19JapanNdeaths.json</a> <code>itemList</code> <em> date </em> <em> ndeaths </em></li>
                                    <li><strong>世界感染状況</strong> : <a href='https://opendata.corona.go.jp/api/OccurrenceStatusOverseas'>OccurrenceStatusOverseas.json</a> </li>
                                    <li><strong>全国医療機関の医療提供体制の状況</strong> : <a href='https://opendata.corona.go.jp/api/covid19DailySurvey'>covid19DailySurvey.json</a></li>
                                </ul>
                            </div>
                        </div>
                    </Grid>
                </Grid>




            </div>
        );
    }
}