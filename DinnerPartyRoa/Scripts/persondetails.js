//AngularJs
var menuApp = angular.module('menuApp', []);

function Order() {
    User = null;
    Item = null;
}

menuApp.controller('ListCtrl', function ($scope, $http) {

    var array = [];
    $http.get("https://api.github.com/orgs/enspiral-dev-academy/members?access_token=b71c0b279059b2b33bc5b2f0bac3db3807cd6826&per_page=100")
        .success(function (data) {
            for (var key in data) {
                array.push(data[key].login);
            }

            $(function () {                                        //
                var userList = $("#currentuser").autocomplete({
                    source: array,
                    change: function (event, ui) {
                        var val = ui.item.value;
                        $('#currentuser').attr('value', val)
                    },
                });
            });
            $scope.gitdata = array;         
        });
 

    $scope.random = function () {
        // get the menu list randomly
        $http.get('/api/MenuItemsapi/')
        .then(function (response) {

            var $db = response.data;
            var $count = $db.length;
            var index = Math.floor(Math.random() * $count + 1);
            var $object = $db[index];
            console.log("randddddddddddd", $object);
            $scope.meal.Title = $object.Title;
            $scope.meal.Id = $object.Id;


        });

    }

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

        //$scope.test = function () {

        //    console.log($scope.user)                
        //}


        
        
        $scope.submit = function () {        
                           
            console.log($scope.user)               // doesnt registor jquery change as a change to scope       
            console.log($('#currentuser').val())


            var order = new Order();
            order.Item = $scope.meal.Title;
            order.ItemId = $scope.meal.Id;
            order.User = $('#currentuser').val();

            $http.post('/api/orders/', order).
                success(function () {
                    alert("Order Placed!")
                    console.log(order);
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
//    $('#currentorder').css('color', 'black');
//});

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


//var GetNames = function () {

//    var array = [];
//    $.ajax({
//        type: "GET",
//        url: "https://api.github.com/orgs/enspiral-dev-academy/members?access_token=b71c0b279059b2b33bc5b2f0bac3db3807cd6826&per_page=100",
//        success: function (data) {

//            for (var key in data) {
//                array.push(data[key].login);
//            }
//        },
//        error: function () {
//            alert("wrong");
//        }
//    });
//    return array;
//}