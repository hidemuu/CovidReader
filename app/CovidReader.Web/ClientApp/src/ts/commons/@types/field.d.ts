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

    export interface IChartTemplate {
        calc: string,
        isAll: boolean,
        endDate: Date,
        tabNumber: Number
    }

    export interface IChartData {
        data: IFetchData,
    }
    
}