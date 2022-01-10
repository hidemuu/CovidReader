export default function getItems(df) {
  const keys = Object.keys(df[0]);
    console.log(keys);
    let result = [];
    for(let row in df) {
      const item = df[row];
      let unit = [];
      //ラベルデータ格納
      unit.push(item['date']);
      //チャートデータ格納
      for(let col in keys) {
        const key = keys[col];
        if(key != 'data') { continue; }
        //配列かどうかで分岐 配列ならforで詰め込む
        if(Array.isArray(item[key])) { for(let v in item[key]) { unit.push(item[key][v]); } }
        else if(item[key].indexOf(',') >= 0) { unit.push(item[key].split(',')); }
        else { unit.push(item[key]); }//title[col] == "data"
      }
      result.push(unit);//["2020/2/14","1","0","1","54"]
    }
    console.log('--- result : getChartData ---');
    console.log(result);
    return result;
}


