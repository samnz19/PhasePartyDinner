$(document).ready(function () {
   // alert('hi peepz');

    var currentSelectedItem = "";

    $('#col1').on('click', 'li', function() {
        $('#currentorder').empty();
        currentSelectedItem = $(this).text();
        $('#currentorder').append(currentSelectedItem);
        $('#currentorder').css('color', 'red');
    });


});