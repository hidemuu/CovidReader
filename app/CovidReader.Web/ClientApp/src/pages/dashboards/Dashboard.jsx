import React from "react";
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import DateTab from "../../components/views/organisms/DateTab";
import DashboardTemplate from "../../templates/DashboardTemplate";
import InfectionCharts from '../charts/InfectionCharts';
import InfectionTables from '../tables/InfectionTables';
import styles from "../../components/styles/js/styles";

export default class Dashboard extends React.Component {

    //コンストラクタ
    constructor(props) {
        super(props);
        this.state = {
            selectedDate: new Date(),
            selectedTabIndex: 2,
            dateFilter: 'all',
        };
    }

    //タブセレクトイベント
    onSelectTab = (index, last) => {
        console.log('Selected tab: ' + index + ', Last tab: ' + last);
        this.setState({ selectedTabIndex: index });
        if (index === 0) {
            this.setState({ dateFilter: 'week' });
            console.log('clicked weeklybutton');
        }
        else if (index === 1) {
            this.setState({ dateFilter: 'month' });
            console.log('clicked monthlybutton');
        }
        else if (index === 2) {
            this.setState({ dateFilter: 'year' });
            console.log('clicked yearlybutton');
        }
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
                    charts={<InfectionCharts calc='daily' isAll={false} endDate={this.state.selectedDate} dateFilter={this.state.dateFilter} />}
                    tables={<InfectionTables calc='daily' endDate={this.state.selectedDate} dateFilter={this.state.dateFilter} />}
                />
            </div>
        );
    }
}
