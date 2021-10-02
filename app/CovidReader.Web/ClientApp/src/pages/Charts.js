import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import InfectionCharts from './InfectionCharts';
import InspectionCharts from './InspectionCharts';

var startDate;
var dateFilter;
var tabNumber;

//感染データ、検査データチャート一覧表示
export default class Charts extends React.Component {

    //コンストラクタ
    constructor(props) {
        super(props);
    }

    //マウント時イベントハンドラ
    componentDidMount() {

    }

    //タブセレクトイベント
    handleTabSelect(index, last) {
        console.log('Selected tab: ' + index + ', Last tab: ' + last);
        tabNumber = index;
        if (index == 0){
            dateFilter = 'week';
        }
        else if (index == 1){
            dateFilter = 'month';
        }
        else if (index == 2){
            dateFilter = 'year';
        }
    }

    //週表示ボタンクリックイベント
    handleWeeklyButtonClick() {
        dateFilter = 'week';
    }
    //月表示ボタンクリックイベント
    handleMonthlyButtonClick() {
        dateFilter = 'month';
    }
    //年表示ボタンクリックイベント
    handleYearlyButtonClick() {
        dateFilter = 'year';
    }
    //カレンダークリックイベント
    handleDatepickerChanged(date) {
        startDate = date;
    }

    //レンダリング
    render() {

        startDate = new Date();
        dateFilter = 'all';
        tabNumber = 1;

        //スタイル設定
        const useStyles = makeStyles((theme) => ({
            typography: {
            marginTop: theme.spacing(0),
            marginBottom: theme.spacing(0),
            },
            grid: {
            margin: "auto",
            },
            button: {
            marginTop: "auto",
            marginBottom: theme.spacing(5),
            width: "250px",
            height: "200px",
            fontSize: "30px",
            margin: theme.spacing(1),
            },
            backdrop: {
            color: "#fff"
            },
        }));

        return (
            <div>
                <Tabs onSelect={this.handleTabSelect} selectedIndex={this.tabNumber}>
                    <TabList>
                        <Tab>週</Tab>
                        <Tab>月</Tab>
                        <Tab>年</Tab>
                    </TabList>
                    <TabPanel>
                        <h2>週報</h2>
                    </TabPanel>
                    <TabPanel>
                        <h2>月報</h2>
                    </TabPanel>
                    <TabPanel>
                        <h2>年報</h2>
                    </TabPanel>
                </Tabs>
                <DatePicker selected={startDate} onChange={(date) => this.handleDatepickerChanged(date)} />
                {/* <button className="btn btn-primary" onClick={this.handleWeeklyButtonClick}>週</button>
                <button className="btn btn-primary" onClick={this.handleMonthlyButtonClick}>月</button>
                <button className="btn btn-primary" onClick={this.handleYearlyButtonClick}>年</button> */}
                <Typography variant="h5" align="center" className={useStyles.typography}>
                    <div>全国感染状況 : 日報</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justify="flex-end" direction="row">
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='daily' disp='all'/>
                    </Grid>
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='daily' disp='units'/>
                    </Grid>
                </Grid>
                <Typography variant="h5" align="center" className={useStyles.typography}>
                    <div>全国感染状況 : 累計</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justify="flex-end" direction="row">
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='total' disp='all'/>
                    </Grid>
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='total' disp='units'/>
                    </Grid>
                </Grid>
                
                {/* <InspectionCharts calc='daily'/>
                <InspectionCharts calc='total'/> */}
            </div>
        );

    }

}