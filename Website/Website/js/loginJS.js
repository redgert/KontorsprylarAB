
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (data) {
            console.log(data);
            if (data.IsAdmin == 0) {
                window.location.href = "/home.aspx"
            }
            else if (data.IsAdmin == 1) {
                window.location.href = "/adminsida.aspx"
            }
            else if (data == "Error") {
                console.log(data);
                alert("Wrong username or password");
            }
        });
};