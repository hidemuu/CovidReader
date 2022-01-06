import * as React from "react";
import ChartSelector from '../molecules/ChartSelector';
import ChartContainer from '../molecules/ChartContainer';
import TypographyLabel from '../atoms/TypographyLabel';

type Props = {
    chartLabels: string[];
    chartData: object[];
    options: object[];
    queryLabels: string[];
    isAll: boolean;
};

export default class ChartScreen extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <div>
                {this.props.isAll ?
                    <div>
                        <TypographyLabel content="一覧" />
                        <ChartSelector
                            labels={this.props.chartLabels}
                            datasets={this.props.chartData}
                            options={this.props.options}
                            isBar={false} />
                    </div > :
                    <div>
                        <TypographyLabel content="個別" />
                        <ChartContainer
                            labels={this.props.chartLabels}
                            datasets={this.props.chartData}
                            options={this.props.options}
                            queryLabels={this.props.queryLabels}
                            isBar={true} />
                    </div>}
            </div>
        );
    }
}