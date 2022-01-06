import * as React from "react";
import { Grid, Typography } from '@material-ui/core';
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import styles from "../components/styles/js/styles";

type Props = {
    dailyAllCharts: Function;
    dailyUnitCharts: Function;
    totalAllCharts: Function;
    totalUnitCharts: Function;
};

export default class ChartTemplate extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <div>
                <Typography variant="h5" align="center" className={styles.typography}>
                    <div>全国感染状況 : 日報</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles.grid} xs={6}>
                        {this.props.dailyAllCharts}
                    </Grid>
                    <Grid item className={styles.grid} xs={6}>
                        {this.props.dailyUnitCharts}
                    </Grid>
                </Grid>
                <Typography variant="h5" align="center" className={styles.typography}>
                    <div>全国感染状況 : 累計</div>
                </Typography>
                <Grid container style={{ paddingTop: 30, paddingBottom: 50 }} justifyContent="flex-end" direction="row">
                    <Grid item className={styles.grid} xs={6}>
                        {this.props.totalAllCharts}
                    </Grid>
                    <Grid item className={styles.grid} xs={6}>
                        {this.props.totalUnitCharts}
                    </Grid>
                </Grid>
            </div>
        );
    }
}