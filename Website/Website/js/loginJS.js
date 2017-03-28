/// <reference path="C:\KontorsprylarAB\Website\Website\Scripts/jquery-2.1.0-vsdoc.js" />

//Request url to info.aspx based on information in textboxes on start page
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (user) {
            console.log(user);
            if (user.IsAdmin === 0) {
                window.location.href = "/home.aspx";
            }
            else if (user.IsAdmin === 1) {
                window.location.href = "/admin.aspx";
            }
                //If user does not exist, or username and password doesnt match, the JSON object is set to "Error"
            if (user === "Error") {
                console.log(user);
                alert("Wrong username or password");
            }
        });
}

$(document).ready(function () {
    $.getJSON("svc/info.aspx?loggedin=1").done(function (user) {
        console.log(user);
        $('#loginButton').remove();
        $('#listSignUp').remove();
        $('#listLoginButton').addClass("dropdown");
        $('#listLoginButton').append($('<a/>', {
            href: '#',
            text: user.FirstName + " " + user.LastName,
            class: 'dropdown-toggle',
            'data-toggle': "dropdown",
        })).append($('<ul class="dropdown-menu"><li><a href="#">Change information</a></li><li><a href="products.aspx">Order history</a></li><li><a href="#" onclick="RemoveUserFromSession()">Log out</a></li></ul>'));
        
        if (user.IsAdmin === 1) {
            $('#adminList').append($('<a/>', {
                text: 'Admin',
                href: 'admin.aspx',
            }));
        }
    })
})

$(document).ready(function () {
    $.getJSON("svc/svc_cart.aspx?product=1").done(function (productList) {
        console.log(productList);
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

        $("#listShopCart").addClass("open");
        $("#listShopCart").attr("aria-expanded", "true");
    })
})