
function GetRequest() {
    $.getJSON("svc/info.aspx?username=" + $("#username").val() + "&password=" + $("#password").val()).
        done(function (data) {
            alert(data);
            console.log(data);
            window.location.href = "/successlogin.aspx"
        });
};