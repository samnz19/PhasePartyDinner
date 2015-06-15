function MenuItemsModel() {
    // Ajax request to API.
    console.log('getMenuItems');
    $.ajax({
        type: "GET",
        url: "/api/MenuItems",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (items) {
            prepData(items);
        }

    });

}