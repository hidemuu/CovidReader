import React, { useState } from "react";
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import InfectionCharts from './InfectionCharts';
import InfectionTables from './InfectionTables';
import ComboBox from "../components/ComboBox";

const Dashboard = () => {

  const [dateFilter, setDateFilter] = useState('---');
  const [endDate, setEndDate] = useState(new Date());
  const [tabNumber, setTabNumber] = useState(2);

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

  //タブセレクトイベント
  const handleTabSelect = (index, last) => {
    console.log('Selected tab: ' + index + ', Last tab: ' + last);
    setTabNumber(index);
    if (index == 0){
      setDateFilter('week');
      console.log('clicked weeklybutton');
    }
    else if (index == 1){
      setDateFilter('month');
      console.log('clicked monthlybutton');
    }
    else if (index == 2){
      setDateFilter('year');
      console.log('clicked yearlybutton');
    }
  }

  //カレンダークリックイベント
  const handleDatepickerChanged = (date) => {
    setEndDate(date);
  }

  return (
    <div>
      <Tabs onSelect={(index, last) => handleTabSelect(index, last)} selectedIndex={tabNumber}>
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
      <DatePicker selected={endDate} onChange={(date) => handleDatepickerChanged(date)} />
      <h2>チャート</h2>
      <Typography variant="h5" align="center" className={useStyles.typography}>
        <div>全国感染状況 : 日報</div>
      </Typography>
      <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justify="flex-end" direction="row">
        <Grid item className={useStyles.grid} xs={6}>
          <InfectionCharts calc='daily' disp='all' endDate={endDate} dateFilter={dateFilter}/>
        </Grid>
        <Grid item className={useStyles.grid} xs={6}>
          <InfectionCharts calc='daily' disp='units' endDate={endDate} dateFilter={dateFilter}/>
        </Grid>
      </Grid>
      <h2>リスト</h2>
      <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justify="flex-end" direction="row">
        <Grid item className={useStyles.grid} xs={12}>
          <InfectionTables calc='daily'/>
        </Grid>
      </Grid>
    </div>
  );
};

export default Dashboard;