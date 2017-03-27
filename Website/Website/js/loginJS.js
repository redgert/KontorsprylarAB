
//Request url to info.aspx based on information in textboxes on start page
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (user) {
            console.log(user);
            if (user.IsAdmin === 0) {
                window.location.href = "/home.aspx";
            }
            else if (user.IsAdmin === 1) {
                window.location.href = "/home.aspx";
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