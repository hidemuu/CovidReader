import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import InfectionCharts from './InfectionCharts';
import InspectionCharts from './InspectionCharts';

//感染データ、検査データチャート一覧表示
export default class Charts extends React.Component {

    render() {

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
                <Grid container style={{ paddingTop: 30 }} justify="flex-end" direction="row">
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='daily'/>
                    </Grid>
                    <Grid item className={useStyles.grid} xs={6}>
                        <InfectionCharts calc='total'/>
                    </Grid>
                </Grid>
                
                {/* <InspectionCharts calc='daily'/>
                <InspectionCharts calc='total'/> */}
            </div>
        );

    }

}