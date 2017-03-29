$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});
$(document).ready(function () {
    $.getJSON("/svc/productInfo.aspx").done(function (product) {
        console.log(product);
        var counter = 0;
        var $myRow;
        product.forEach(function (data) {
            if (counter % 3 === 0 || counter === 0) {
                $myRow = $('<div/>', {
                    class: 'row',
                    style: "margin-bottom: 20px;"
                });

                $('#Products').append($myRow);
            }
            console.log(data);

            var $myColumn = $('<div/>', {
                class: "col-sm-4"
            });

            $($myRow).append($myColumn)

            $($myColumn).append($('<p/>', {
                text: data.ShortDescription,
                style: "font-size: 25px; font-weight: bold; width: 100%; text-align: left; margin-bottom: 30px; "
            }));

            var $myHref = $('<a/>', {
                href: '#',
                'data-toggle': "popover",
                title: data.ShortDescription,
                'data-content': "<div><p>" + data.LongDescription + "</p><p>" + data.Price + " SEK</p><button type='button' class='btn btn-default' onClick='BuyProduct(" + data.ProductID + ");'>Add To Chart</button> </div>",
                'data-html': true,
                'data-trigger': "focus",
                style: "text-decoration: none; font-size: 25px; color: black;"
            });

            $($myColumn).append($myHref);

            $($myHref).append($('<img/>', {
                src: data.URL,
                class: "img-responsive",
                style: "max-height: 250px; max-width: 100%;"
            }))
            $('[data-toggle="popover"]').popover();

            var $myButton = $('<button/>', {
                class: "btn btn-default",
                text: 'Add To Chart  ',
                onclick: 'BuyProduct(' + data.ProductID + ')',
            });

            $myButton.append($('<span/>', {
                class: "glyphicon glyphicon-shopping-cart"
            }));
            
            $($myColumn).append($('<p/>', {
                text: "Kr " + data.Price,
                style: "font-size: 25px;"
            }))
            $($myColumn).append($myButton);
            $($myColumn).append($('<p/>', {
                text: "",
                style: "margin-bottom: 50px; border-bottom-style: solid;"
            }))
            counter++;
        });
    });
});

function BuyProduct(productID) {
    console.log(productID);
    $.getJSON("svc/svc_cart.aspx?prodid=" + productID).done(function (data) {
        $.getJSON("svc/svc_cart.aspx?product=1").done(function (productList) {
            console.log(productList);
            $('#productDropDown').empty()
            productList.forEach(function (product) {
                console.log(product);
                var $newLi = ($('<li/>', {
                    text: product.ShortDescription,
                    style: "font-size: 20px; text-align: left;"
                }))
                $('#productDropDown').prepend($newLi)

                $newLi.append($('<p/>', {
                    text: product.Price
                }))
            });
            
            $('#productDropDown').append('<li><a href="checkout.aspx">Checkout</a></li>');

            $("#listShopCart").addClass("open");
            $("#listShopCart").attr("aria-expanded", "true");
        })
    });
}








