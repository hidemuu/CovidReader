import React from "react";
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import DateTab from "../../components/views/organisms/DateTab";
import DashboardTemplate from "../../templates/DashboardTemplate";
import InfectionCharts from '../charts/InfectionCharts';
import InfectionTables from '../tables/InfectionTables';
import dateFilterType from "../../commons/constants/dateFilterType";
import styles from "../../components/styles/styles";

export default class Dashboard extends React.Component {

    //コンストラクタ
    constructor(props) {
        super(props);
        this.state = {
            selectedDate: new Date(),
            selectedTabIndex: dateFilterType.YEAR,
        };
    }

    //タブセレクトイベント
    onSelectTab = (index, last) => {
        this.setState({ selectedTabIndex: index });
    }

    //カレンダークリックイベント
    onChangeDatepicker = (date) => {
        this.setState({ selectedDate: date });
    }

    render() {
        return (
            <div className={styles.board}>
                <DateTab
                    selectedTabIndex={this.state.selectedTabIndex}
                    onSelectTab={(index, last) => this.onSelectTab(index, last)}
                    selectedDate={this.state.selectedDate}
                    onChangeDatepicker={(date) => this.onChangeDatepicker(date)}
                />
                <DashboardTemplate
                    charts={<InfectionCharts calc='daily' isAll={false} endDate={this.state.selectedDate} dateFilter={this.state.selectedTabIndex} />}
                    tables={<InfectionTables calc='daily' endDate={this.state.selectedDate} dateFilter={this.state.selectedTabIndex} />}
                />
            </div>
        );
    }
}
