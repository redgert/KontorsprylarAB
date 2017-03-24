

//requestString = "";

//function GetRequest() {
//    var username = $('#textboxUserName').text
//    var password = $('#textboxPassowrd').text
//    requestString = String Join(http.localhost.dodo)
//};
$(document).ready(function () {
    alert("hello");
});
function GetRequest() {
    $.getJSON("svc/info.aspx?username=pattzor&password=gillarintejava").done(function (data) {
        alert("Done!");
        console.log(data);
    })
};