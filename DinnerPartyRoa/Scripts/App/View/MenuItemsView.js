function prepData(items) {
    //Preparing data for display

    var htmlMenu = [];
    for (var i = 0; i < items.length; i++) {
        console.log(items[i]);
        var html =
            "<div>" +
                "<p>" + items[i]["Title"] + "</p>" +
                "<img id='ItemPreview' src='data:image/jpeg;base64,'" + Image + "'/>" +
                // "<img src='" + items[i]["Image"] + "'/>" +
            "</div>";
        htmlMenu.push(html);
    }
    console.log('prepData:' + htmlMenu);
    injectHTML(htmlMenu);
}

function injectHTML(htmlMenu) {
    //
    console.log('htmlMenu:' + htmlMenu);

    for (var i = 0; i < htmlMenu.length; i++) {
        $('#menulist').append(htmlMenu[i]);
    }
}