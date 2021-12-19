import React from "react";
import MaterialTable from 'material-table';
import CircularProgress from "@material-ui/core/CircularProgress";

const TableTemplate = ({
    title, labels, fields, isEnables, loading, data, category, endDate, dateFilter
}) => {
    //データ取得完了後処理
    if (!loading) {

        const startTime = performance.now(); // 開始時間

        console.log('draw start');
        let startDate = new Date(endDate);
        if (dateFilter == 'week') {
            startDate.setDate(startDate.getDate() - 7);
        } else if (dateFilter == 'month') {
            startDate.setDate(startDate.getDate() - 30);
        } else if (dateFilter == 'year') {
            startDate.setDate(startDate.getDate() - 365);
        } else {
            startDate.setDate(startDate.getDate() - 365);
        }

        const df = data.filter(item => { return item.calc == category }).filter(item => { return new Date(item.date) >= startDate && new Date(item.date) <= endDate });
        const query = df.map(item => {
            return {
                date: item.date,
                deathNumber: item.deathNumber,
                patientNumber: item.patientNumber,
            }
        });
        console.log(query);
        let tableColumns = [];
        let c = 0;
        for (let i = 0; i < labels.length; i++) {
            if (isEnables[i] === true) {
                tableColumns.push({
                    title: labels[c],
                    field: fields[c],
                    cellStyle: { textAlign: 'right' },
                });
                c++;
            }
        }

        const endTime = performance.now(); // 終了時間

        console.log(endTime - startTime); // 何ミリ秒かかったかを表示する

        return (
            <div>
                <MaterialTable
                    title={title}
                    columns={tableColumns}
                    data={query}
                    options={{
                        //showTitle: false,
                        paging: false,
                        // search: false,
                        // draggable: false,
                        // filtering: true,
                        maxBodyHeight: 500,
                        headerStyle: {
                            position: 'sticky',
                            top: 0,
                            minWidth: 150,
                        },
                    }}
                />
            </div>
        );

        //データ取得中処理
    } else {

        return (
            <CircularProgress color="inherit" />
        );
    }
}

export default TableTemplate;