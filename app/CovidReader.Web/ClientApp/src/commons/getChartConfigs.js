export default function getChartConfigs(df) {
    const keys = Object.keys(df[0]);
    console.log(keys);
    let result = [];
    for(let row in df) {
      const item = df[row];
      // result.push({
      //   id: item['id'],
      //   name: item['name'],
      //   chartType: item['chartType'],
      //   backgroundColor: item['backgroundColor'],
      //   borderColor: item['borderColor'],
      //   borderWidth: item['borderWidth']
      // });//["id","name","type","color",…]
      result.push([
        item['id'],
        item['name'],
        item['chartType'],
        item['backgroundColor'],
        item['borderColor'],
        item['borderWidth'],
        item['category']
      ]);//["id","name","type","color",…]
    }
    console.log('--- result : getChartConfig ---');
    console.log(result);
    return result;
  }