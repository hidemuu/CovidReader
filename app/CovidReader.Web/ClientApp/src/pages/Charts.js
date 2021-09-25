import React from 'react';
import InfectionCharts from './InfectionCharts';
import InspectionCharts from './InspectionCharts';

//感染データ、検査データチャート一覧表示
export default class Charts extends React.Component {

    render() {

        return (
            <div>
                <InfectionCharts calc='daily'/>
                {/* <InfectionCharts calc='total'/> */}
                <InspectionCharts calc='daily'/>
                {/* <InspectionCharts calc='total'/> */}
            </div>
        );

    }

}