export default function fetchItems(basepath) {
    console.log(basepath);
    fetch(basepath)
    .then((response) => {
        if (response.status === 200) {
          return response.json();
        } else {
          throw new Error();
        }
      })
    .then((json) => {
      console.log(json);
      return json;      
    })
    .catch((error) =>{
      console.error('--- fetch error ' + basepath +  '---');
      console.error(error);
    });
    return [];
}