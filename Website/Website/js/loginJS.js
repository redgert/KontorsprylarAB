
//Request url to info.aspx based on information in textboxes on start page
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (user) {
            console.log(user);
            if (user.IsAdmin === 0) {
                window.location.href = "/home.aspx";
                //NEVER MIND THIS BELOW RIGHT NOW
                
            }
            else if (user.IsAdmin === 1) {
                window.location.href = "/home.aspx";
                //NEVER MIND THIS BELOW RIGHT NOW
                $('#admin').removeProp($('display'));
            }
            //If user does not exist, or username and password doesnt match, the JSON object is set to "Error"
            else if (user === "Error") {
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
        $('#listLoginButton').append($('<a/>', {
                    href: '#',
                    text: user.FirstName + " " + user.LastName,
        }));
        if (user.IsAdmin === 1) {
            $('#adminList').append($('<a/>', {
                text: 'Admin',
                href: 'admin.aspx',
            }));
        }
    })
})