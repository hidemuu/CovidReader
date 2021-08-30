$(() => {
    //---- パラメータ ----------
    const chartType = 'line';
    
    //---- Canvas描画 ---------
    function drawChart(title, data) {
        let chartLabels = [],//ラベル（項目はひとつ）
            chartData = [];//データ系列の数だけ設定
    
        for(let row in data) {
            chartLabels.push(data[row][0]);
            chartData.push(data[row][1]);//データ系列の数だけ設定
        };
    
    
        let myChart = new Chart($('#myChart')[0].getContext('2d'), {
            type: chartType,
            data: {
                labels: chartLabels,
                datasets: [{
                    label: title,
                    data: chartData
                }]//データ系列の数だけ準備
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

    // ------ データ構造変換 -----------
    function json2Labels(json) {
        var labels = [];
        for (let i=0; i<json.length; i++){
          labels[i] = json[i].date;
        }
        return labels;
      }

      function json2Data(json) {
        var data = [];
        for (let i=0; i<json.length; i++){
          data[i] = json[i].data;
          //console.log(`date=${data[i].date}, data=${data[i].data}`);
        }
        return data;
    }

    //----- 主幹シーケンス --------
    function main_json(fileName, labelColumn) {
        $.getJSON(fileName)
        .done(function(data){
            // 成功時処理
            console.log("getJSON成功");
            console.log(data);
            let jsonData = [],
                title = Object.keys(data[0]);
            for(let row in data) {
                let unit = [];
                unit.push(data[row][title[labelColumn]]);
                for(let col in title) {
                    if(col == labelColumn) continue;
                    unit.push(data[row][title[col]]);
                }
                jsonData.push(unit);
            }
            drawChart(title[labelColumn], jsonData);
        }).fail(function(jqXHR, textStatus, errorThrown){
            // 失敗時処理
            console.log("getJSON失敗");    
            console.log("jqXHR : " + jqXHR.status); // httpステータス
            console.log("textStatus : " + textStatus);  // タイムアウト、パースエラー
            console.log("errorThrown : " + errorThrown.message);    // エラーの詳細情報
        }).always(function(){
            // 常時実行処理

        });
    }
    
    function main_csv(fileName) {
        let req = new XMLHttpRequest();
        req.open('GET', fileName, true);
        req.onload = () => {
            let csvData = [],
                lines = req.responseText.replace('\r\n', '\n').replace('\r', '\n').split('\n'),
                title = lines[0].split(',');
            for(let row in lines) {
                csvData.push(lines[row].split(','));
            }
            drawChart(title[0], csvData);
        };
        req.send(null);
    };

    function main_file() {
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
            let labels = json2Labels(json);
            let data = json2Data(json);
            drawChart(title[labelColumn], jsonData);
            //makeLineChart(data, labels);
          })
        })
    }

    function main(fileName, labelColumn){
        console.log('running...');
        console.log(fileName);
        if (fileName.includes('.json')) { main_json(fileName, labelColumn); }
        else if (fileName.includes('.csv')) { main_csv(fileName); }
        else if (fileName = '') { main_file(); }
        else { console.log('対応していないファイル形式が指定されています [json/csv/]'); }

    }
    
    //---- メインスクリプト ------------
    main('chart_item.json', 1);//['data', 'date'] [1]がlabel
    
    });