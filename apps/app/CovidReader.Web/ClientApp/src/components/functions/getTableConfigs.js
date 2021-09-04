export default function getTableConfigs(df) {
    const keys = Object.keys(df[0]);
    console.log(keys);
    let result = [];
    for(let row in df) {
      const item = df[row];
      result.push([
        item['name']
      ]);//["id","name","type","color",…]
    }
    console.log('--- result : getTableConfig ---');
    console.log(result);
    return result;

}