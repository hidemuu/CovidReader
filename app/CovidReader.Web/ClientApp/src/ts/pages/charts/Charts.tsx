import * as React from "react";
import "react-datepicker/dist/react-datepicker.css";
import 'react-tabs/style/react-tabs.css';
import InfectionCharts from './InfectionCharts';
import DateTab from "../../components/views/organisms/DateTab";
import ChartTemplate from "../../templates/ChartTemplate";
import dateFilterType from "../../commons/constants/dateFilterType";


export default class Charts extends React.Component<null, Field.IChartIndex> {

    //コンストラクタ
    constructor(props) {
        super(props);
        this.state = {
            endDate: new Date(),
            tabNumber: dateFilterType.YEAR,
        };
    }

    //マウント時イベントハンドラ
    componentDidMount() {

    }

    //タブセレクトイベント
    onSelectTab(index, last) {
        this.setState({ tabNumber: index });
    }

    //カレンダークリックイベント
    onChangeDatepicker(date) {
        this.setState({ endDate: date });
    }

    render(): JSX.Element {
        return (
            <div>
                <DateTab
                    selectedTabIndex={this.state.tabNumber}
                    onSelectTab={(index, last) => this.onSelectTab(index, last)}
                    selectedDate={this.state.endDate}
                    onChangeDatepicker={(date) => this.onChangeDatepicker(date)}
                />
                <ChartTemplate
                    dailyAllCharts={<InfectionCharts calc='daily' isAll={true} endDate={this.state.endDate} dateFilter={this.state.tabNumber} />}
                    dailyUnitCharts={<InfectionCharts calc='daily' isAll={false} endDate={this.state.endDate} dateFilter={this.state.tabNumber} />}
                    totalAllCharts={<InfectionCharts calc='total' isAll={true} endDate={this.state.endDate} dateFilter={this.state.tabNumber} />}
                    totalUnitCharts={<InfectionCharts calc='total' isAll={false} endDate={this.state.endDate} dateFilter={this.state.tabNumber} />}
                />
            </div>
        );
    }
}