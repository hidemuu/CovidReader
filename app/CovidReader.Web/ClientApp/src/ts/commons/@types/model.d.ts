declare namespace Model {

    // Label
    export interface ILabel {
        content: string,
    }

    export interface IArticle {
        title: string,
    }

    // Chart
    export interface IChart {
        labels: string[],
        datasets: object[],
        options: object[],
    }

    export interface IChartType {
        isBar: boolean,
    }

    export interface IChartSelector {
        chart: IChart,
        type: IChartType,
    }

    export interface IChartContainer {
        chart: IChart,
        type: IChartType,
        queryLabels: string[],
    }

    export interface IChartScreen {
        chart: IChart,
        queryLabels: string[],
        isAll: boolean,
    }

    export interface IChartTemplate {
        dailyAllCharts: Function,
        dailyUnitCharts: Function,
        totalAllCharts: Function,
        totalUnitCharts: Function,
    }

    export interface IChartData {
        calc: string,
        endDate: string,
        dateFilter: Number,
    }

    // Table
    export interface ITable {
        title: string,
        columns: object[],
        data: object[],
    }

    //Tab
    export interface IDateTab {
        onSelectTab: Function,
        selectedTabIndex: Number,
        onChangeDatepicker: Function,
        selectedDate: Date,
    }

    // Navigation
    export interface INav {
        url: string,
        content: string,
    }

    export interface INavBar {
        urls: INavBarItem[],
        name: string,
        toggleNavbar: React.MouseEventHandler,
        isCollapsed: boolean,
    }

    export interface INavBarItem {
        url: string,
        content: string,
    }

    export interface INavMenuTemplate {
        collapsed: boolean,
    }

    // Home
    export interface IHomeTemplate {
        onClickUpdateButton: React.MouseEventHandler,
        contentsTileData: object[],
    }

    // Dashboard

    export interface IDashboardTemplate {
        charts: Function;
        tables: Function;
    }

    // Auth
    export interface IAuthUser {
        userId: string,
    }

    export type OperationType = {
        login: (userId: string) => void
        logout: () => void
    }

    // Layout
    export interface ILayout {
        location: object,
        children: object,
    }

}