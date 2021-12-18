export default function makeChartDataSets(labels, chartItems, borderColors, backgroundColors) {

  let results;
  
  results = [
    {
    type: 'bar',
    yAxisID: 'y-axis',
    label: labels[0],
    data: chartItems[0],
    borderColor: borderColors[0],
    backgroundColor: backgroundColors[0],
    borderWidth: 1
    },
    {
      type: 'bar',
      yAxisID: 'y-axis',
      label: labels[1],
      data: chartItems[1],
      borderColor: borderColors[1],
      backgroundColor: backgroundColors[1],
      borderWidth: 1
    },
    {
      type: 'bar',
      yAxisID: 'y-axis',
      label: labels[2],
      data: chartItems[2],
      borderColor: borderColors[2],
      backgroundColor: backgroundColors[2],
      borderWidth: 1
    },
    {
      type: 'bar',
      yAxisID: 'y-axis',
      label: labels[3],
      data: chartItems[3],
      borderColor: borderColors[3],
      backgroundColor: backgroundColors[3],
      borderWidth: 1
    },
    {
      type: 'bar',
      yAxisID: 'y-axis',
      label: labels[4],
      data: chartItems[4],
      borderColor: borderColors[4],
      backgroundColor: backgroundColors[4],
      borderWidth: 1
    },
    {
      type: 'bar',
      yAxisID: 'y-axis',
      label: labels[5],
      data: chartItems[5],
      borderColor: borderColors[5],
      backgroundColor: backgroundColors[5],
      borderWidth: 1
    }
  ];
    
    return result;
  }