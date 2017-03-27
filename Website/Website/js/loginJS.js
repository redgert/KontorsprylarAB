
//Request url to info.aspx based on information in textboxes on start page
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (user) {
            console.log(user);
            if (user.IsAdmin == 0) {
                window.location.href = "/home.aspx"
                //NEVER MIND THIS BELOW RIGHT NOW
                $('#loginButton').remove()
                $('#listLoginButton').append($('<p/>', {
                    text: user.FirstName + " " + user.LastName,
                    style: 'color: white'
                }))
            }
            else if (user.IsAdmin == 1) {
                window.location.href = "/admin.aspx"
                //NEVER MIND THIS BELOW RIGHT NOW
                $('#admin').removeProp($('display'));
            }
            //If user does not exist, or username and password doesnt match, the JSON object is set to "Error"
            else if (user == "Error") {
                console.log(user);
                alert("Wrong username or password");
            }
        });
};