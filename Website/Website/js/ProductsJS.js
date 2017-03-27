$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});
$(document).ready(function () {
    $.getJSON("/svc/productInfo.aspx").done(function (product) {
        console.log(product);
        product.forEach(function (data) {
            var $myRow = $('<div/>', {
                class: 'container',
                style: "width: 100px; height: 100px; background-image: url('" + data.URL + "'); background-size: cover; margin-bottom: 10px;"
            });
            $('#Products').append($myRow);
            console.log(data);

            $($myRow).append($('<a/>', {
                href: '#',
                'data-toggle': "popover",
                title: data.ShortDescription,
                'data-content': "<div><p>" + data.LongDescription + "</p><p>" + data.Price + " SEK</p><button type='button' class='btn btn-default' onClick='BuyProduct(" + data.ProductID + ");'>Add To Chart</button> </div>",
                'data-html': true,
                text: data.ShortDescription,
                'data-trigger': "focus",
                style: "text-decoration: none; font-size: 20px;"
            }));
            $('[data-toggle="popover"]').popover();
        });
    });
});

function BuyProduct(productID) {
    console.log(productID);
    $.getJSON("svc/productInfo.aspx?prodid=" + productID).done(function (data) {
        console.log(data);
    });
}




  



