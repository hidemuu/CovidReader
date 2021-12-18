export default function getStartDate(endDate, dateFilter) {
    let startDate = endDate;
    if(dateFilter == 'week'){
        startDate.setDate( startDate.getDate() - 7);
    }else if(dateFilter == 'month'){
        startDate.setDate( startDate.getDate() - 30);
    }else if(dateFilter == 'year'){
        startDate.setDate( startDate.getDate() - 365);
    }else{
        startDate.setDate( startDate.getDate() - 365);
    }
    return startDate;
}