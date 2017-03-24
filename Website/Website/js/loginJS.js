
//Request url to info.aspx based on information in textboxes on start page

function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (user) {
            console.log(user);
            if (user.IsAdmin == 0) {
                window.location.href = "/home.aspx"
            }
            else if (user.IsAdmin == 1) {
                window.location.href = "/admin.aspx"
            }
            //If user does not exist, or username and password doesnt match, the JSON object is set to "Error"
            else if (user == "Error") {
                console.log(data);
                alert("Wrong username or password");
            }
        });
};