import * as React from "react";
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import DateTab from "../../components/views/organisms/DateTab";
import DashboardTemplate from "../../templates/DashboardTemplate";
import InfectionCharts from '../charts/InfectionCharts';
import InfectionTables from '../tables/InfectionTables';
import dateFilterType from "../../commons/constants/dateFilterType";
import styles from "../../components/styles/styles";

export default class Dashboard extends React.Component<{}, Field.IDashboard> {

    //タブセレクトイベント
    onSelectTab = (index: number) => {
        this.setState({ selectedTabIndex: index });
    }

    //カレンダークリックイベント
    onChangeDatepicker = (date: Date) => {
        this.setState({ selectedDate: date });
    }

    render(): JSX.Element {
        return (
            <div className={styles().board}>
                <DateTab
                    selectedTabIndex={this.state.selectedTabIndex}
                    onSelectTab={(index: number) => this.onSelectTab(index)}
                    selectedDate={this.state.selectedDate}
                    onChangeDatepicker={(date: Date) => this.onChangeDatepicker(date)}
                />
                <DashboardTemplate
                    charts={<InfectionCharts calc='daily' isAll={false} endDate={this.state.selectedDate} dateFilter={this.state.selectedTabIndex} />}
                    tables={<InfectionTables calc='daily' endDate={this.state.selectedDate} dateFilter={this.state.selectedTabIndex} />}
                />
            </div>
        );
    }
}