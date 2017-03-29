function ChangeUserInformation() {

    $.getJSON("svc/info.aspx?loggedin=1").done(function (user) {

        console.log(user);
        $("#changeFirstName").val(user.FirstName);
        $("#changeLastName").val(user.LastName);
        $("#changeStreet").val(user.Street);
        $("#changeZip").val(user.Zip);
        $("#changeCity").val(user.City);
        $("#changeCountry").val(user.Country);
        $("#changePhoneNumber").val(user.PhoneNumber);
        $("#changeEmail").val(user.Email);

        }
)
}

function FormChangesSubmit() {
    var firstName = $("#changeFirstName").val();
    var lastName = $("#changeLastName").val();
    var street = $("#changeStreet").val();
    var zip = $("#changeZip").val();
    var city = $("#changeCity").val();
    var country = $("#changeCountry").val();
    var phoneNumber = $("#changePhoneNumber").val();
    var email = $("#changeEmail").val();
    alert("I am an alert box!");


    $.getJSON("svc/info.aspx?UpdateUser=1", { "Firstname": firstName, "Lastname": lastName, "Street": street, "City": city, "Zip": zip, "Country": country, "Phonenumber": phoneNumber, "Email": email })
     .done(function (data) {
         console.log(data);
     })
}



