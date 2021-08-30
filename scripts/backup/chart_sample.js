$(() => {

const jsonPath = 'data.json',
	csvPath = 'data.csv',
	chartType = 'bar';

function drawChart(title, data) {
	let tmpLabels = [],//ラベル（項目はひとつ）
		tmpData = [];//データ系列の数だけ設定

	for(let row in data) {
		tmpLabels.push(data[row][0]);
		tmpData.push(data[row][1]);//データ系列の数だけ設定
	};
//tmpLabels = tmpLabels.slice(0, -1);
//エクセルでCSVファイルを作るとデータの最後にカンマ（,）が追加されて、グラフに空白列が増えてしまうので最後のカンマを削除する

	let myChart = new Chart($('#myChart')[0].getContext('2d'), {
		type: chartType,
		data: {
			labels: tmpLabels,
			datasets: [{
				label: title,
				data: tmpData
			}]//データ系列の数だけ準備
		},
		options: {}
	});
}

function main_json(labelColumn) {
	$.getJSON("data.json", data => {
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
	});
}

function main_csv() {
	let req = new XMLHttpRequest();
	req.open('GET', csvPath, true);
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

main_json(1);//['死亡者数', '日付'] [1]がlabel
//main_csv();
});
