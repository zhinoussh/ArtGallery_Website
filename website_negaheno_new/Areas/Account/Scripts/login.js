var LoginSuccess = function (result) {

    if (result.status != null && result.status == "fail") {
        $("alert_login").html("Username or password is incorrect");
    }
    else {
        location.href = result.url;
    }
}

var LoginFail = function () {
    alert('login failed');
}