/// <reference path="C:\KontorsprylarAB\Website\Website\Scripts/jquery-2.1.0-vsdoc.js" />

//Request url to info.aspx based on information in textboxes on start page
function GetRequest(username, password) {
    $.getJSON("svc/info.aspx?username=" + username + "&password=" + password).
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

function PrepareRequest() {
    var username = $('#username').val();
    var password = $('#password').val();

    GetRequest(username, password)
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
        })).append($('<ul class="dropdown-menu"><li><a href="#" data-toggle="modal" data-target="#changeUserInformationModal" onclick="ChangeUserInformation()">Change information</a></li><li><a href="products.aspx">Order history</a></li><li><a href="#" onclick="RemoveUserFromSession()">Log out</a></li></ul>'));
        if (user.IsAdmin === 1) {
            $('#adminList').append($('<a/>', {
                text: 'Admin',
                href: 'admin.aspx',
            }));
        }
    })
})

function FormSubmit()
{
    var Password = $("#newPassword").val();
    var Password2 = $("#newPasswordAgain").val();

    if (Password != Password2) {
        alert("Wrong password");
    }
    else {
        var Username = $("#newUsername").val();
        var Firstname = $("#newFirstName").val();
        var Lastname = $("#newLastName").val();
        var Street = $("#newStreet").val();
        var Zip = $("#newZip").val();
        var City = $("#newCity").val();
        var Country = $("#newCountry").val();
        var Phonenumber = $("#newPhoneNumber").val();
        var Email = $("#newEmail").val();
        $.getJSON("svc/info.aspx?CreateUser=1", { "Username": Username, "Password": Password, "Password2": Password2, "Firstname": Firstname, "Lastname": Lastname, "Street": Street, "Zip": Zip, "City": City, "Country": Country, "Phonenumber": Phonenumber, "Email": Email })
        .done(function (data) {
            console.log(data);
            GetRequest(Username, Password);
        });
    }
}

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
        $('#productDropDown').append('<li><a href="checkout.aspx">Checkout</a></li>');
    })
})