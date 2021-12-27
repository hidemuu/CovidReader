import React from 'react';
import LineChart from '../components/views/atoms/LineChart';
import ChartContainer from '../components/views/molecules/ChartContainer';
import TypographyLabel from '../components/views/atoms/TypographyLabel';

export default class ChartTemplate extends React.Component {
    render() {
        const { chartLabels, chartData, options, queryLabels, disp } = this.props;
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
                    <ChartContainer
                        labels={chartLabels}
                        datasets={chartData}
                        options={options}
                        queryLabels={queryLabels}
                        isBar={true}
                    />
                </div>
            );
        }
    }
}