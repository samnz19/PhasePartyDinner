$(document).ready(function () {

    var array = [];
    var currentSelectedItem = "";

   
    $('#menu').on('click', 'li', function () {
        $('#currentorder').empty();
        currentSelectedItem = $.trim($(this).text());

        var orderDiv = $(this).find("#data")[0];
        var orderId = $(orderDiv).data("menuitemid");

        $('#currentorderid').attr("value", orderId);
        $('#currentorder').attr("value", currentSelectedItem);
        $('#currentorder').css('color', 'black');
    });


    array = GetNames();

    $(function () {
        var userList = $("#currentuser").autocomplete({
            source: array,
            change: function(event, ui) {
                var val = ui.item.value;
                $('#currentuser').attr('value', val)
                //$('#currentuser').val(val)
                          },
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
        url: "https://api.github.com/orgs/enspiral-dev-academy/members?access_token=b71c0b279059b2b33bc5b2f0bac3db3807cd6826&per_page=100",
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





//AngularJs
var menuApp = angular.module('menuApp', []);

menuApp.controller('ListCtrl', function ($scope, $http) {
    $http.get('/api/MenuItemsapi').success(function (dataAng) {

        $scope.meal = {};
        $scope.user = "";

        $scope.meals = dataAng;
        console.log(dataAng)

        $scope.menulist = function (meal) {

            $scope.meal.Title = meal.Title;
            $scope.meal.Id = meal.Id;
            console.log(meal.Title)            
        }

        $scope.test = function () {

            console.log($scope.user)      // problem being that doesnt registor jquery change function as a change to scope        
           
        }
        
        $scope.submit = function () {
            
                           
            console.log($scope.user)              //uhmmmmmmmmmmm....nice autoupdate...
            console.log($('#currentuser').val()) //isnt this the same?


            var order = new Order();
            order.Item = $scope.meal.Title;
            order.ItemId = $scope.meal.Id;
            order.User = $('#currentuser').val();  //total legit..............

            $http.post('/api/orders/', order).
                success(function () {
                    alert("Order Placed!")

                    $scope.meal = {};
                    $scope.user = "";

                });
        }
    });
});










//$('#menu').on('click', 'li', function () {
//    $('#currentorder').empty();
//    currentSelectedItem = $.trim($(this).text());

//    var orderDiv = $(this).find("#data")[0];
//    var orderId = $(orderDiv).data("menuitemid");

//    $('#currentorderid').attr("value", orderId);
//    $('#currentorder').attr("value", currentSelectedItem);
//    $('#currentorder').css('color', 'blue');
//});


//$('#submitbutton').on('click', function (e) {
//    e.preventDefault();
//    var order = new Order();
//    order.Item = $('#currentorder').val();
//   order.ItemId = $('#currentorderid').val();

//    order.User = $('#currentuser').val();

//    $.ajax({
//        type: 'POST',
//        url: '/api/orders/',
//        data: order,

//        datatype: 'json',
//        success: function () {
//            alert("Order Placed!");
//        }
//    });

//});