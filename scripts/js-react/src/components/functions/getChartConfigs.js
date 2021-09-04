export default function getChartConfigs(df) {
    const keys = Object.keys(df[0]);
    console.log(keys);
    let result = [];
    for(let row in df) {
      const item = df[row];
      result.push([
        item['id'],
        item['name'],
        item['chart_type'],
        item['background_color'],
        item['border_color'],
        item['border_width']
      ]);//["id","name","type","color",…]
    }
    console.log('--- result : getChartConfig ---');
    console.log(result);
    return result;
  }