import * as React from "react";
import { Line } from 'react-chartjs-2';

type Props = {
    labels: string[];
    datasets: object[];
    options: object[];
};

export default class BarChart extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <Line
                data={{
                    labels: this.props.labels,
                    datasets: this.props.datasets,
                }}
                options={this.props.options} />
        );
    }
}