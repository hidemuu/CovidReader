import React from 'react';
import { Grid } from '@material-ui/core';
import { Line, Bar } from 'react-chartjs-2';
import styles from "../components/styles/js/styles";

export default class ChartContainer extends React.Component {
    render() {
        const { labels, datasets, options, queryLabels } = this.props;
        return (
            <div>
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {queryLabels.map((label, index) => (
                        <Grid item className={styles.grid} xs={12}>
                            <Bar
                                data={{
                                    labels: labels,
                                    datasets: datasets.filter(d => { return d.label == label }),
                                }}
                                options={options} />
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}