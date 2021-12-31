import * as React from "react";
import { Grid } from '@material-ui/core';
import LineChart from '../atoms/LineChart';
import BarChart from '../atoms/BarChart';
import styles from "../../../styles/js/styles";

type Props = {
    isBar: boolean;
    labels: string[];
    datasets: object[];
    options: object[];
};

export default class ChartSelector extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <div>
                <Grid item className={styles.grid} xs={12}>
                    {this.props.isBar
                        ? <BarChart
                            labels={this.props.labels}
                            datasets={this.props.datasets}
                            options={this.props.options} />
                        : <LineChart
                            labels={this.props.labels}
                            datasets={this.props.datasets}
                            options={this.props.options} />}
                </Grid>
            </div>
        );
    }
}