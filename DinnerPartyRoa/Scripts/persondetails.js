$(document).ready(function () {

    var array = [];
    var currentSelectedItem = "";

    array = GetNames();
    $("#currentuser").autocomplete({
        source: array
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

 });

function Order() {
    User = null;
    Item = null;
}

var GetNames = function () {

    var array = [];
    $.ajax({
        type: "GET",
        url: "https://api.github.com/orgs/enspiral-dev-academy/members?access_token=b71c0b279059b2b33bc5b2f0bac3db3807cd6826",
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









var menuApp = angular.module('menuApp', []);
console.log("HI");
menuApp.controller('ListCtrl', function ($scope, $http) {
    $http.get('/api/MenuItemsapi').success(function (dataAng) {
        console.log("Sup");
        $scope.meal = {};
        $scope.user = "";

        $scope.meals = dataAng;
        console.log($scope.meals);
        console.log($scope.meals[0].Title);

        $scope.menulist = function (meal) {
            console.log("IDK");
            console.log(meal);

            $scope.meal.Title = meal.Title;
            $scope.meal.Id = meal.Id;
            console.log($scope.meal);
        }

        $scope.submit = function() {

            //$scope.meal.User = user;
            //console.log(user);
            //console.log($scope.meal);

            var order = new Order();
            order.Item = $scope.meal.Title;
            order.ItemId = $scope.meal.Id;
            order.User = $scope.user;

            console.log("hereeeee", order);

            $http.post('/api/orders/', order).
                success(function () {
                    console.log("It worked");

                    $scope.meal = {};
                    $scope.user = "";
                    
                });
        }


    });

   

  
});


    








