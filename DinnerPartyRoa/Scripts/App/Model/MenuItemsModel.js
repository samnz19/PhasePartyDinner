function MenuItemsModel() {
    // Ajax request to API.
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