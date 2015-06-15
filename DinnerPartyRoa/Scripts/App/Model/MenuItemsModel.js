function MenuItemsModel() {
    // Ajax request to API.
    console.log('getMenuItems');
    $.ajax({
        type: "GET",
        url: "/api/MenuItems",
        contentType: "application/json",
        dataType: "json",
        success: function (items) {
            prepData(items);
        }

    });

}