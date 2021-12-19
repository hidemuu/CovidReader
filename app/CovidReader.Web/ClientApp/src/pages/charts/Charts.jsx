import React from "react";
import { Grid, Typography } from '@material-ui/core';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import InfectionCharts from './InfectionCharts';
import InspectionCharts from './InspectionCharts';
import styles from "../../components/styles/js/styles";

//感染データ、検査データチャート一覧表示
export default class Charts extends React.Component {

    //コンストラクタ EDIT 2021.10.02 state追加
    constructor(props) {
        super(props);
        this.state={
            endDate: new Date(),
            dateFilter: 'all',
            tabNumber: 2,
          };
    }

    //マウント時イベントハンドラ
    componentDidMount() {

    }

    //タブセレクトイベント
    handleTabSelect(index, last) {
        console.log('Selected tab: ' + index + ', Last tab: ' + last);
        this.setState({tabNumber: index});
        if (index == 0){
            this.setState({dateFilter: 'week'});
        }
        else if (index == 1){
            this.setState({dateFilter: 'month'});
        }
        else if (index == 2){
            this.setState({dateFilter: 'year'});
        }
    }

    //カレンダークリックイベント
    handleDatepickerChanged(date) {
        this.setState({endDate: date});
    }

    //レンダリング
    render() {
        
        return (
            <div>
                <Tabs onSelect={(index, last) => this.handleTabSelect(index, last)} selectedIndex={this.state.tabNumber}>
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
                <DatePicker selected={this.state.endDate} onChange={(date) => this.handleDatepickerChanged(date)} />
                <Typography variant="h5" align="center" className={styles.typography}>
                    <div>全国感染状況 : 日報</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles.grid} xs={6}>
                        <InfectionCharts calc='daily' disp='all' endDate={this.state.endDate} dateFilter={this.state.dateFilter}/>
                    </Grid>
                    <Grid item className={styles.grid} xs={6}>
                        <InfectionCharts calc='daily' disp='units' endDate={this.state.endDate} dateFilter={this.state.dateFilter}/>
                    </Grid>
                </Grid>
                <Typography variant="h5" align="center" className={styles.typography}>
                    <div>全国感染状況 : 累計</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles.grid} xs={6}>
                        <InfectionCharts calc='total' disp='all' endDate={this.state.endDate} dateFilter={this.state.dateFilter}/>
                    </Grid>
                    <Grid item className={styles.grid} xs={6}>
                        <InfectionCharts calc='total' disp='units' endDate={this.state.endDate} dateFilter={this.state.dateFilter}/>
                    </Grid>
                </Grid>
            </div>
        );

    }

}