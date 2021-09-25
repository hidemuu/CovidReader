import React, { useState } from 'react';
import InfectionTables from './InfectionTables';
import InspectionTables from './InspectionTables';

export default class Tables extends React.Component {

    render() {

        return (
            <div>
                <InfectionTables calc='daily'/>
                {/* <InspectionTables calc='daily'/> */}
            </div>
        );
        
    }

}