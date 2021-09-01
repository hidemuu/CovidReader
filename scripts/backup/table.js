$(() => {
    
    $(document).ready(function () {
        // AJAXリクエスト送信
        $.getJSON('chart_item.json')
            .done(function (data) {
                // 成功時処理
                $.each(data, function (key, item) {
                    $('<tr>', { text: "" }).appendTo($('#mytable'));
                    $('<td>', { text: item.date }).appendTo($('#mytable'));
                    $.each(item.data.split(','), function(index, value) {
                        $('<td>', { text: value }).appendTo($('#mytable'));
                    })
                });
            });

        $.getJSON('chart_config.json')
            .done(function(data){
                // 成功時処理
                $('<tr>', { text: "" }).appendTo($('#mythead'));
                $('<td>', { text: "Date" }).appendTo($('#mythead'));
                $.each(data, function (key, item) {
                    $('<td>', { text: item.name }).appendTo($('#mythead'));
                })
            });
    });


});