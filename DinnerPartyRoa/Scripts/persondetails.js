$(document).ready(function () {
   // alert('hi peepz');
    var array = [];
    var currentSelectedItem = "";

    $('#col1').on('click', 'li', function() {
        $('#currentorder').empty();
        currentSelectedItem = $.trim($(this).text());
        console.log(currentSelectedItem);
        $('#currentorder').attr("value", currentSelectedItem);
        $('#currentorder').css('color', 'blue');
    });

    array = GetNames();
    $("#name").autocomplete({
        source: array
    });
    
});



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
            //$("#CustomerDetailsList").empty();
            //$("#CustomerDetailsList").append("<li>Error getting data from server...</li>");
            alert("wrong");
        }
    });

    return array;
}

$('#submitbutton').on('click', function() {

    $.ajax({
        type: 'POST',
        url: '/api/orders/',
        success: function ()

    });
})