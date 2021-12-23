import React, { useState } from "react";
import { Grid, Typography } from '@material-ui/core';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import DateTabTemplate from "../../templates/DateTabTemplate";
import DashboardTemplate from "../../templates/DashboardTemplate";
import InfectionCharts from '../charts/InfectionCharts';
import InfectionTables from '../tables/InfectionTables';
import styles from "../../components/styles/js/styles";

const Dashboard = () => {

  const [dateFilter, setDateFilter] = useState('---');
  const [endDate, setEndDate] = useState(new Date());
  const [tabNumber, setTabNumber] = useState(2);

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

    return (
        <div className={styles().board}>
            {/*<DateTabTemplate dateFilter={ dateFilter } />*/}
            <Grid container style={{ paddingTop: 10, paddingBottom: 10 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles().grid} xs={9}>
                        <Tabs onSelect={(index, last) => handleTabSelect(index, last)} selectedIndex={tabNumber}>
                            <TabList>
                                <Tab>週</Tab>
                                <Tab>月</Tab>
                                <Tab>年</Tab>
                            </TabList>
                        </Tabs>
                    </Grid>
                    <Grid item className={styles().grid} xs={3}>
                        <DatePicker selected={endDate} onChange={(date) => handleDatepickerChanged(date)} />
                    </Grid>
            </Grid>
            <DashboardTemplate
                charts={<InfectionCharts calc='daily' disp='units' endDate={endDate} dateFilter={dateFilter} />}
                tables={<InfectionTables calc='daily' endDate={endDate} dateFilter={dateFilter} />}
            />
        </div>
  );
};

export default Dashboard;