$(document).ready(function () {
   // alert('hi peepz');
    var array = [];
    var currentSelectedItem = "";

    $('#col1').on('click', 'li', function() {
        $('#currentorder').empty();
        currentSelectedItem = $(this).text();
        $('#currentorder').append(currentSelectedItem);
        $('#currentorder').css('color', 'pink');
    });

    array = GetNames();
    $("#name").autocomplete({
        source: array
    });

    $('#submitbutton').click(function () {

        var orderItem = $('#currentorder').text();
        var username = $('#name').val();
        alert(orderItem);
        alert(username);

        updatingGithubtable(username, orderItem);
    });
    
});


var updatingGithubtable=function(name,item)
{    
    var orderdata='{"Name": ' + name + ', "Title": ' + item  +'}'; 

    $.ajax({
        type: "POST",
        url: "api/Submmit",
        data: JSON.stringify(orderdata),
        dataType: "json",
        contentType: "application/json",
        success: function () {
            alert("success");
            getCustomersData();
        },
        error: function () {
            alert("did not work");
        }
    });
}



var GetNames = function () {

    var array = []
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