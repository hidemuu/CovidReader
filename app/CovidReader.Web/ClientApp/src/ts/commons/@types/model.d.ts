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
        labels: object[],
        datasets: object[],
        options: object,
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
        queryLabels: object[],
    }

    export interface IChartScreen {
        chart: IChart,
        queryLabels: object[],
        isAll: boolean,
    }

    export interface IChartTemplate {
        dailyAllCharts: JSX.Element,
        dailyUnitCharts: JSX.Element,
        totalAllCharts: JSX.Element,
        totalUnitCharts: JSX.Element,
    }

    export interface IChartData {
        calc: string,
        endDate: Date,
        isAll: boolean,
        dateFilter: Number,
    }

    // Table
    export interface ITable {
        title: string,
        columns: object[],
        data: object[],
    }

    export interface ITableData {
        calc: string,
        endDate: Date,
        dateFilter: Number,
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
        charts: JSX.Element;
        tables: JSX.Element;
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