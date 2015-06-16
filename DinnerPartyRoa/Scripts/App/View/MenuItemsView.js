function prepData(items) {
    //Preparing data for display

    var htmlMenu = [];
    for (var i = 0; i < items.length; i++) {
        var html =
            "<div>" +
                "<p>" + items[i]["Title"] + "</p>" +
                "<img id='ItemPreview' src='data:image/jpeg;base64," + items[i]["Image"] + "'/>" +
                // "<img src='" + items[i]["Image"] + "'/>" +
            "</div>";
        htmlMenu.push(html);
    }
    injectHTML(htmlMenu);
}

function injectHTML(htmlMenu) {
    //

    for (var i = 0; i < htmlMenu.length; i++) {
        $('#menulist').append(htmlMenu[i]);
    }
}