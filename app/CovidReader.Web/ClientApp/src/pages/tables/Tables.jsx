import React from 'react';
import InfectionTables from './InfectionTables';

//感染データ、検査データテーブル一覧表示
export default class Tables extends React.Component {

    render() {

        return (
            <div>
                <InfectionTables calc='daily' endDate={new Date()} dateFilter='year'/>
            </div>
        );
        
    }

}