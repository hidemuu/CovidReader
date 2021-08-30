$(() => {
    //---- パラメータ ----------
    const chartType = 'line';
    
    //---- Canvas描画 ---------
    function drawChart(data, configs) {
        //データ成形
        let chartLabels = [],//ラベル（項目はひとつ）
            chartData01 = [],//データ系列の数だけ設定
            chartData02 = [],
            chartData03 = [],
            chartData04 = []; 
        for(let row in data) {
            const item = data[row];
            const labelItem = item[0];
            const dataItem = item[1];
            chartLabels.push(labelItem);
            for (let i = 0; i < dataItem.length; i++){
                if (i == 0) {chartData01.push(dataItem[0]);}//データ系列の数だけ設定
                else if (i == 1) {chartData02.push(dataItem[1]);}
                else if (i == 2) {chartData03.push(dataItem[2]);}
                else if (i == 3) {chartData04.push(dataItem[3]);}
                //labels[i] = json[i].date;
            }            
        };
        console.log('--- chartLabels -----');
        console.log(chartLabels);
        console.log('--- chartData -----');
        console.log(chartData01);
        console.log(chartData02);
        console.log(chartData03);
        console.log(chartData04);
        
        //コンフィグ成形
        let chartIds = [],
            chartTitles = [],
            chartTypes = [],
            chartBackgroundColors = [],
            chartBorderColors = [],
            chartBorderWidthes = [];

        for(let row in configs){
            const config = configs[row];
            chartIds.push(config[0]);
            chartTitles.push(config[1]);
            chartTypes.push(config[2]);
            chartBackgroundColors.push(config[3]);
            chartBorderColors.push(config[4]);
            chartBorderWidthes.push(config[5]);
        }
        console.log('--- chartConfig -----');
        console.log(chartIds);
        console.log(chartTitles);
        console.log(chartTypes);
        console.log(chartBackgroundColors);
        console.log(chartBorderColors);
        console.log(chartBorderWidthes);

        //ブラウザ更新
        if (window.name != "chart") {
            //alert("リロードしました");
            location.reload();
            window.name = "chart";
          } else {
            window.name = "";
          }
        
        //Canvas描画
        let myChart = new Chart($('#myChart')[0].getContext('2d'), {
            type: chartTypes[0],
            data: {
                labels: chartLabels,
                datasets: [
                    {
                        label: chartTitles[0],
                        data: chartData01,
                        borderColor: chartBorderColors[0],
                        backgroundColor: chartBackgroundColors[0],
                        borderWidth: chartBorderWidthes[0]
                    },
                    {
                        label: chartTitles[1],
                        data: chartData02,
                        borderColor: chartBorderColors[1],
                        backgroundColor: chartBackgroundColors[1],
                        borderWidth: chartBorderWidthes[1]
                    },
                    {
                        label: chartTitles[2],
                        data: chartData03,
                        borderColor: chartBorderColors[2],
                        backgroundColor: chartBackgroundColors[2],
                        borderWidth: chartBorderWidthes[2]
                    },
                    {
                        label: chartTitles[3],
                        data: chartData04,
                        borderColor: chartBorderColors[3],
                        backgroundColor: chartBackgroundColors[3],
                        borderWidth: chartBorderWidthes[3]
                    },
                ]//データ系列の数だけ準備
            },
            options: {
                //responsive: true,
                //maintainAspectRatio: false,
                legend: {
                    //display: false
                },
                title: {
                    display: true,
                    text: 'title'
                },
                scales: {
                   yAxes: [{
                     ticks: {
                       suggestedMax: 40,
                       suggestedMin: 0,
                       stepSize: 10,
                       callback: function(value, index, values){
                         return  value +  ''
                       }
                     }
                   }]
                 },
             }
        });
    }

    function getChartData(dt){
        let result = [],
            keys = Object.keys(dt[0]);
        console.log("--- keyデータ ---");
        console.log(keys);
        for(let row in dt) {
            const item = dt[row];
            let unit = [];
            //ラベルデータ格納
            unit.push(item['date']);//{"data":["1324","123","5564"],"date":"2020/1/14"}  title:[0:"data",1:"date"] data[0,1,2…]["date"]
            //チャートデータ格納
            for(let col in keys) {//data[row].data==["1324","123","5564"] data[row].date
                const key = keys[col];
                if(key != 'data') continue;//"date"
                //配列かどうかで分岐 配列ならforで詰め込む
                if(Array.isArray(item[key])) {
                    for(let v in item[key]) {
                        unit.push(item[key][v]);
                    }
                } else if(item[key].indexOf(',') != -1) {
                    unit.push(item[key].split(','));
                } else {
                    unit.push(item[key]);//title[col] == "data"
                }
            }
            result.push(unit);//["2020/2/14","1","0","1","54"]
        }
        console.log('--- chartアイテム ---');
        console.log(result);
        return result;
    }

    function getConfigData(fileName){
        let result = [];
        $.getJSON(fileName)
        .done((data) => {
            // 成功時処理
            console.log("getConfig - getJSON成功");
            console.log("--- JSONデータ ---");
            console.log(data);
            let keys = Object.keys(data[0]);
            console.log("--- keyデータ ---");
            console.log(keys);
            for(let row in data) {
                const item = data[row];
                let unit = [];
                unit.push(item['id']);
                unit.push(item['name']);
                unit.push(item['chart_type']);
                unit.push(item['background_color']);
                unit.push(item['border_color']);
                unit.push(item['border_width']);
                result.push(unit);//["id","name","type","color",…]
            }
            console.log('--- chartConfig ---');
            console.log(result);
            
        }).fail(function(jqXHR, textStatus, errorThrown){
            // 失敗時処理
            console.log("getConfig - getJSON失敗");    
            console.log("jqXHR : " + jqXHR.status); // httpステータス
            console.log("textStatus : " + textStatus);  // タイムアウト、パースエラー
            console.log("errorThrown : " + errorThrown.message);    // エラーの詳細情報
        }).always(function(){
            // 常時実行処理

        });
        return result;
    }

    //----- 主幹シーケンス --------
    function main_json(fileName, configs) {
        $.getJSON(fileName)
        .done((data) => {
            // 成功時処理
            console.log("getChart - getJSON成功");
            console.log("--- JSONデータ ---");
            console.log(data);
            drawChart(getChartData(data), configs);
        }).fail(function(jqXHR, textStatus, errorThrown){
            // 失敗時処理
            console.log("getChart - getJSON失敗");    
            console.log("jqXHR : " + jqXHR.status); // httpステータス
            console.log("textStatus : " + textStatus);  // タイムアウト、パースエラー
            console.log("errorThrown : " + errorThrown.message);    // エラーの詳細情報
        }).always(function(){
            // 常時実行処理

        });
    }
    
    function main_csv(fileName, configs) {
        let req = new XMLHttpRequest();
        req.open('GET', fileName, true);
        req.onload = () => {
            let csvData = [],
                lines = req.responseText.replace('\r\n', '\n').replace('\r', '\n').split('\n'),
                title = lines[0].split(',');
            for(let row in lines) {
                csvData.push(lines[row].split(','));
            }
            drawChart(csvData, configs);
        };
        req.send(null);
    };

    function main_file(configs) {
        let form = document.forms.$('#chartform');
        form.myfile.addEventListener('change', function(e) {
          let result = e.target.files[0]; //読み込んだファイル情報を取得
          console.log( result );
          let reader = new FileReader();
          reader.readAsText( result );  //読み込んだファイルの中身を取得する
          //ファイルの中身を取得後に処理を行う
          reader.addEventListener( 'load', function() {
            form.output.textContent = reader.result; 
            json = JSON.parse(reader.result);
            console.log(json);
            drawChart(getChartData(json), configs);
          })
        })
    }

    function main(chartFileName, configFileName){
        console.log('running...');
        console.log(chartFileName);
        console.log(configFileName);
        //グラフコンフィグ取得
        let configs = getConfigData(configFileName);
        //Canvas描画
        if (chartFileName.includes('.json')) { main_json(chartFileName, configs); }
        else if (chartFileName.includes('.csv')) { main_csv(chartFileName, configs); }
        else if (chartFileName = '') { main_file(configs); }
        else { console.log('対応していないファイル形式が指定されています [json/csv/]'); }
    }
    
    //---- メインスクリプト ------------
    main('chart_item.json', 'chart_config.json');
    
    });
