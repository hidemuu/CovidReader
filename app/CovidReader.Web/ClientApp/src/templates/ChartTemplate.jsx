import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import LineChart from '../components/views/atoms/LineChart';
import BarChart from '../components/views/atoms/BarChart';
import TypographyLabel from '../components/views/atoms/TypographyLabel';
import styles from "../components/styles/js/styles";

const ChartTemplate = ({
    chartLabels, chartData, options, queryLabels, disp
}) => {

    if (disp == 'all') {
        return (
            <div>
                <TypographyLabel content="一覧" />
                <LineChart
                    labels={chartLabels}
                    datasets={chartData}
                    options={options} />
            </div>
        );
    }
    else {
        return (
            <div>
                <TypographyLabel content="個別" />
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {queryLabels.map((label, index) => (
                        <Grid item className={styles.grid} xs={12}>
                            <BarChart
                                labels={chartLabels}
                                datasets={chartData.filter(d => { return d.label == label })}
                                options={options} />
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}
export default ChartTemplate;