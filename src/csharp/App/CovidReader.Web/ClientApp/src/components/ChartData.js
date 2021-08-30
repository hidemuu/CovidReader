import React, { Component } from 'react';

export class ChartData extends Component {
    static displayName = ChartData.name;

    constructor(props) {
        super(props);
        this.state = { chartItems: [], loading: true };
    }

    componentDidMount() {
        this.populateChartItemData();
    }

    static renderChartItemsTable(chartItems) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {chartItems.map(chartItem =>
                        <tr key={chartItem.date}>
                            <td>{chartItem.date}</td>
                            <td>{chartItem.temperatureC}</td>
                            <td>{chartItem.temperatureF}</td>
                            <td>{chartItem.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ChartData.renderChartItemsTable(this.state.chartItems);

        return (
            <div>
                <h1 id="tabelLabel" >Chart Items</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateChartItemData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ chartItems: data, loading: false });
    }
}