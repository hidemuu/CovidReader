import React, { useState } from "react";
import { Grid, Typography } from '@material-ui/core';
import Paper from '@material-ui/core/Paper';
import yellow from "@material-ui/core/colors/yellow";
import { makeStyles } from '@material-ui/core/styles';
import DatePicker from "react-datepicker";
//import { DatePicker } from '@material-ui/pickers'
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
    root: {
      backgroundColor: "#F2F2F2",
    },
    typography: {
    marginTop: theme.spacing(0),
    marginBottom: theme.spacing(0),
    },
    grid: {
    margin: "auto",
    paddingTop: 10,
    paddingBottom: 10,
    paddingLeft: 10,
    paddingRight: 10,
    },
    paper: {
      margin: theme.spacing(1),
      marginTop: "auto",
      height: "700px",
      backgroundColor: "#FFF",
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
    color: "#FFF"
    },
  }));

  //タブセレクトイベント
  const handleTabSelect = (index, last) => {
    console.log('Selected tab: ' + index + ', Last tab: ' + last);
    setTabNumber(index);
    if (index === 0){
      setDateFilter('week');
      console.log('clicked weeklybutton');
    }
    else if (index === 1){
      setDateFilter('month');
      console.log('clicked monthlybutton');
    }
    else if (index === 2){
      setDateFilter('year');
      console.log('clicked yearlybutton');
    }
  }

  //カレンダークリックイベント
  const handleDatepickerChanged = (date) => {
    setEndDate(date);
  }

  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">
        <Grid item className={classes.grid} xs={9}>
          <Tabs onSelect={(index, last) => handleTabSelect(index, last)} selectedIndex={tabNumber}>
            <TabList>
              <Tab>週</Tab>
              <Tab>月</Tab>
              <Tab>年</Tab> 
            </TabList>
            {/* <TabPanel>
              <h2>週報</h2>
            </TabPanel>
            <TabPanel>
              <h2>月報</h2>
            </TabPanel>
            <TabPanel>
              <h2>年報</h2>
            </TabPanel> */}
          </Tabs>
        </Grid>
        <Grid item className={classes.grid} xs={3}>
          <DatePicker selected={endDate} onChange={(date) => handleDatepickerChanged(date)} />
        </Grid>       
      </Grid>

      <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">

          <Grid item className={classes.grid} xs={6}>
            <Paper className={classes.paper}>
              <Typography variant="h5" align="center" className={classes.typography}>
                <div>チャート</div>
              </Typography>
              <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">
                {/* <Grid item className={classes.grid} xs={12}>
                  <InfectionCharts calc='daily' disp='all' endDate={endDate} dateFilter={dateFilter}/>
                </Grid> */}
                <Grid item className={classes.grid} xs={12}>
                  <InfectionCharts calc='daily' disp='units' endDate={endDate} dateFilter={dateFilter}/>
                </Grid>
              </Grid>
            </Paper>
          </Grid>
        
          <Grid item className={classes.grid} xs={6}>
            <Paper className={classes.paper}>
              <Typography variant="h5" align="center" className={classes.typography}>
                <div>テーブル</div>
              </Typography>
              <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">
                <Grid item className={classes.grid} xs={12}>
                  <InfectionTables calc='daily' endDate={endDate} dateFilter={dateFilter}/>
                </Grid>
              </Grid>
            </Paper> 
          </Grid>
        

      </Grid>
      
    </div>
  );
};

export default Dashboard;