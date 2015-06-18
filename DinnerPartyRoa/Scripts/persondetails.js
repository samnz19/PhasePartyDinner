$(document).ready(function () {

    var array = [];
    var currentSelectedItem = "";

    $('#col1').on('click', 'li', function () {
        $('#currentorder').empty();
        currentSelectedItem = $.trim($(this).text());

        var orderDiv = $(this).find("div")[0];
        var orderId = $(orderDiv).data("menuitemid");

        $('#currentorderid').attr("value", orderId);
        $('#currentorder').attr("value", currentSelectedItem);
        $('#currentorder').css('color', 'blue');
    });

    array = GetNames();
    $("#name").autocomplete({
        source: array
    });

    $('#submitbutton').on('click', function (e) {
        e.preventDefault();
        var order = new Order();
        order.Item = $('#currentorder').val();
        order.ItemId = $('#currentorderid').val();

        order.User = $('#currentuser').val();

        $.ajax({
            type: 'POST',
            url: '/api/orders/',
            data: order,

            datatype: 'json',
            success: function () {

            }
        });

    });

});

function Order() {
    User = null;
    Item = null;
}

var GetNames = function () {

    var array = [];
    $.ajax({
        type: "GET",
        url: "https://api.github.com/orgs/enspiral-dev-academy/members",
        success: function (data) {

            for (var key in data) {
                array.push(data[key].login);
            }
        },
        error: function () {
            alert("wrong");
        }
    });
    return array;
}


