import React from 'react';
import { Grid } from '@material-ui/core';
import LineChart from '../atoms/LineChart';
import BarChart from '../atoms/BarChart';
import styles from "../../styles/js/styles";

export default class ChartContainer extends React.Component {
    render() {
        const { labels, datasets, options, queryLabels, isBar } = this.props;
        return (
            <div>
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {queryLabels.map((label, index) => (
                        <Grid item className={styles.grid} xs={12}>
                            {isBar
                                ? <BarChart
                                    labels={labels}
                                    datasets={datasets.filter(d => { return d.label == label })}
                                    options={options} />
                                : <LineChart
                                    labels={labels}
                                    datasets={datasets.filter(d => { return d.label == label })}
                                    options={options} />}
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}