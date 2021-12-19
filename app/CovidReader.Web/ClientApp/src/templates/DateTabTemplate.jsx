import React, { useState } from "react";
import { Grid } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';

const DateTabTemplate = () => {

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
        if (index === 0) {
            setDateFilter('week');
            console.log('clicked weeklybutton');
        }
        else if (index === 1) {
            setDateFilter('month');
            console.log('clicked monthlybutton');
        }
        else if (index === 2) {
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
                    </Tabs>
                </Grid>
                <Grid item className={classes.grid} xs={3}>
                    <DatePicker selected={endDate} onChange={(date) => handleDatepickerChanged(date)} />
                </Grid>
            </Grid>
        </div>
    );
};

export default DateTabTemplate;