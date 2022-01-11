declare namespace Field {

    // FetchData
    export interface IFetchData {
        id: object,
        index: Number,
        date: Date,
        calc: string,
        countryName: string,
        prefName: string,
        cityName: string,
        deathNumber: Number,
        cureNumber: Number,
        patientNumber: Number,
        recoveryNumber: Number,
        severeNumber: Number,
        testNumber: Number,
    }

    // Chart
    export interface IChartIndex {
        endDate: Date,
        tabNumber: Number
    }

    export interface IChartScreen {
        isAllType: Model.IChartType,
        type: Model.IChartType,
    }

    export interface IChartTemplate {
        calc: string,
        isAll: boolean,
        endDate: Date,
        tabNumber: Number
    }

    export interface IChartData {
        data: IFetchData[],
        chart: Model.IChart,
    }

    // Table
    export interface ITableIndex {
        endDate: Date,
        tabNumber: Number
    }

    export interface ITableData {
        data: IFetchData[],
        table: Model.ITable,
    }

    // Dashboard
    export interface IDashboard {
        selectedDate: Date,
        selectedTabIndex: Number,
    }


}