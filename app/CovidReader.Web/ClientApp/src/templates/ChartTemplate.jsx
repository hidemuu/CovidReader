import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { Line, Bar } from 'react-chartjs-2';
import CircularProgress from "@material-ui/core/CircularProgress";
import styles from "../components/styles/js/styles";

const ChartTemplate = ({
    chartTypes, labels, borderColors, backgroundColors, borderWidthes, isEnables, loading, data, category, disp, endDate, dateFilter
}) => {

    //データ取得完了後処理
    if (!loading) {

        //データ格納
        //日付フィルタ ADD 2021.10.02
        let startDate = new Date(endDate);
        if (dateFilter === 'week') {
            startDate.setDate(startDate.getDate() - 7);
        } else if (dateFilter === 'month') {
            startDate.setDate(startDate.getDate() - 30);
        } else if (dateFilter === 'year') {
            startDate.setDate(startDate.getDate() - 365);
        } else {
            startDate.setDate(startDate.getDate() - 365);
        }

        console.log('draw start' + startDate + ' - ' + endDate);

        const query = data.filter(item => { return item.calc == category }).filter(item => { return new Date(item.date) >= startDate && new Date(item.date) <= endDate });
        //データラベル生成
        const chartLabels = query.map(item => { return item.date; });
        console.log(chartLabels);
        //各系列の描画パラメータ設定
        const chartItems = [
            query.map(item => { return item.deathNumber; }),
            query.map(item => { return item.cureNumber; }),
            query.map(item => { return item.patientNumber; }),
            query.map(item => { return item.recoveryNumber; }),
            query.map(item => { return item.severeNumber; }),
            query.map(item => { return item.testNumber; }),
        ]

        let chartData = [];
        let queryLabels = [];
        let c = 0;
        for (let i = 0; i < labels.length; i++) {
            if (isEnables[i] === true) {
                chartData.push({
                    type: chartTypes[c],
                    // yAxisID: yAxisIDs[c],
                    label: labels[c],
                    data: chartItems[c],
                    borderColor: borderColors[c],
                    backgroundColor: backgroundColors[c],
                    borderWidth: borderWidthes[c],
                });
                queryLabels.push(labels[c]);
                c++;
            }

        }


        console.log(chartData);

        //チャートオプション設定
        const options = {
            legend: {
                //display: false
            },
            title: {
                display: true,
                text: 'title'
            },
            scales: {
                yAxes: [
                    {
                        ticks: {
                            suggestedMax: 40,
                            suggestedMin: 0,
                            stepSize: 10,
                            callback: (value, index, values) => { return value + ''; }
                        }
                    }
                ]
            }
        };

        //デザイン
        if (disp == 'all') {
            return (
                <div>
                    <Typography variant="h5" align="center" className={styles.typography}>
                        <div>一覧</div>
                    </Typography>
                    <Line
                        data={{
                            labels: chartLabels,
                            datasets: chartData,
                        }}
                        options={options} />
                </div>
            );
        }
        else {
            return (
                <div>
                    <Typography variant="h5" align="center" className={styles.typography}>
                        <div>個別</div>
                    </Typography>
                    <Grid container style={{ paddingTop: 30 }} justifyContent="flex-end" direction="row">
                        {queryLabels.map((label, index) => (
                            <Grid item className={styles.grid} xs={12}>
                                <Bar
                                    data={{
                                        labels: chartLabels,
                                        datasets: chartData.filter(d => { return d.label == label }),
                                    }}
                                    options={options} />
                            </Grid>
                        ))}
                    </Grid>
                </div>

            );
        }

    } else {

        return (
            <CircularProgress color="inherit" />

        );
    }
}

export default ChartTemplate;