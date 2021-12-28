import React from "react";
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import InfectionCharts from './InfectionCharts';
import DateTab from "../../components/views/organisms/DateTab";
import ChartTemplate from "../../templates/ChartTemplate";

//感染データ、検査データチャート一覧表示
export default class Charts extends React.Component {

    //コンストラクタ
    constructor(props) {
        super(props);
        this.state={
            endDate: new Date(),
            dateFilter: 'all',
            tabNumber: 2,
          };
    }

    //マウント時イベントハンドラ
    componentDidMount() {

    }

    //タブセレクトイベント
    handleTabSelect(index, last) {
        console.log('Selected tab: ' + index + ', Last tab: ' + last);
        this.setState({tabNumber: index});
        if (index == 0){
            this.setState({dateFilter: 'week'});
        }
        else if (index == 1){
            this.setState({dateFilter: 'month'});
        }
        else if (index == 2){
            this.setState({dateFilter: 'year'});
        }
    }

    //カレンダークリックイベント
    handleDatepickerChanged(date) {
        this.setState({endDate: date});
    }

    //レンダリング
    render() {
        return (
            <div>
                <DateTab
                    selectedTabIndex={this.state.tabNumber}
                    onSelectTab={(index, last) => this.handleTabSelect(index, last)}
                    selectedDate={this.state.endDate}
                    onChangeDatepicker={(date) => this.handleDatepickerChanged(date)}
                />
                <ChartTemplate
                    dailyAllCharts={<InfectionCharts calc='daily' isAll={true} endDate={this.state.endDate} dateFilter={this.state.dateFilter} />}
                    dailyUnitCharts={<InfectionCharts calc='daily' isAll={false} endDate={this.state.endDate} dateFilter={this.state.dateFilter} />}
                    totalAllCharts={<InfectionCharts calc='total' isAll={true} endDate={this.state.endDate} dateFilter={this.state.dateFilter} />}
                    totalUnitCharts={<InfectionCharts calc='total' isAll={false} endDate={this.state.endDate} dateFilter={this.state.dateFilter} />}
                />
            </div>
        );

    }

}