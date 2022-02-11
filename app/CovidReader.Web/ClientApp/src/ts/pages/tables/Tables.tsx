import * as React from "react";
import dateFilterType from "../../commons/constants/dateFilterType";
import InfectionTables from './InfectionTables';

export default class Tables extends React.Component<{}, Field.ITableIndex> {


    render(): JSX.Element {
        return (
            <div>
                <InfectionTables calc='daily' endDate={new Date()} dateFilter={dateFilterType.YEAR}/>
            </div>
        );
    }
}