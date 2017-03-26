
$(document).ready(function () {
    $.getJSON("/svc/productInfo.aspx").done(function (product) {
        console.log(product);
        product.forEach(function (data) {
            var $myRow = $('<div/>', { class: 'row' })
            $('#Products').append($myRow)
            console.log(data);

            $myRow.append($('<p/>', {
                class: 'productcontainer',
                text: data.ShortDescription
            }));
        });
    });
});

