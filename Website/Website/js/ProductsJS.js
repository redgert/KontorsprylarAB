$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});
$(document).ready(function () {
    $.getJSON("/svc/productInfo.aspx").done(function (product) {
        console.log(product);
        var counter = 0;
        var $myRow;
        product.forEach(function (data) {
            $('#Products').append('<div id="modal' + data.ProductID + '" class="modal fade" role="dialog"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal">&times;</button><h4 class="modal- title">' + data.ShortDescription + '</h4></div>' +
                '<div class="modal-body"><form class="form-inline"><div class="form-group"><img src="' + data.URL + '" class = "img-responsive" style="max-height: 400px; max-width: 100%;"></img></div></br><div class="form-group">' +
                '<label style="font-size: 20px;">' + data.LongDescription + '</label></div></br><label style="font-size: 20px;">' + "Kr " + data.Price + '</label></br><div class="form-group"><button class="btn btn-default" onclick= BuyProduct(' + data.ProductID + ');>Buy now</button></div></form></div><div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">Close</button></div></div></div></div');
            
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
                title: data.ShortDescription,
                'data-toggle': "modal",
                'data-target': '#modal' + data.ProductID,
                style: "text-decoration: none; font-size: 25px; color: black;"
            });

            $($myColumn).append($myHref);

            $($myHref).append($('<img/>', {
                src: data.URL,
                class: "img-responsive",
                style: "max-height: 250px; max-width: 100%;"
            }))

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
                    text: "Kr " + product.Price
                }))
            });
            
            $('#productDropDown').append('<li><a href="checkout.aspx">Checkout</a></li>');

            $("#listShopCart").addClass("open");
            $("#listShopCart").attr("aria-expanded", "true");
        })
    });
}








