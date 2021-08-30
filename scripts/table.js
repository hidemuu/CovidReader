$(() => {
    var uri = 'chart_item.json';
    //JSON取得
    $(document).ready(function () {
        // AJAXリクエスト送信
        $.getJSON(uri)
            .done(function (data) {
                // 成功時処理
                $.each(data, function (key, item) {
                    $('<tr>', { text: "" }).appendTo($('#mytable'));
                    $('<td>', { text: item.date }).appendTo($('#mytable'));
                    $('<td>', { text: item.data }).appendTo($('#mytable'));
                });
            });
    });

});