function RemoveUserFromSession() {

    $.getJSON("svc/logOutUser.aspx").
        done(function (temp) {
        window.location.href = 'home.aspx';
    });
}