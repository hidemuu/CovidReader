import * as React from "react";
import { Grid } from '@material-ui/core';
import ChartSelector from '../molecules/ChartSelector';
import styles from "../../styles/js/styles";

type Props = {
    isBar: boolean;
    queryLabels: string[];
    labels: string[];
    datasets: object[];
    options: object[];
};

export default class ChartContainer extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <div>
                <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                    {this.props.queryLabels.map((label, index) => (
                        <Grid item className={styles().grid} xs={12}>
                            {/*<ChartSelector*/}
                            {/*    labels={this.props.labels}*/}
                            {/*    datasets={this.props.datasets.filter(d => { return d.label === label })}*/}
                            {/*    options={this.props.options}*/}
                            {/*    isBar={this.props.isBar} />*/}
                        </Grid>
                    ))}
                </Grid>
            </div>
        );
    }
}