import React, { useState } from 'react';
import InfectionTables from './InfectionTables';
import InspectionTables from './InspectionTables';

//感染データ、検査データテーブル一覧表示
export default class Tables extends React.Component {

    render() {

        return (
            <div>
                <InfectionTables calc='daily' endDate={new Date()} dateFilter='year'/>
                {/* <InspectionTables calc='daily'/> */}
            </div>
        );
        
    }

}