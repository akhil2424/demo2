$(function () {
    $("#LoginButton").click(function () {
        if ($(this).closest('form').valid()) {
            var data = {
                Email: $("signInForm #Email").val(),
                Password: $("signInForm #Password").val()
            }
            $.post($("#_root").val() + "Home/Login", data, function (r) { 
                if (r.success) {  
                    window.location = ($("#_root").val() + "Home/dashboard");
                }
                else alert("Invalid Email or Password");
                Email: $("#signInForm #Email").val('');
                Password: $("#signInForm #Password").val('');
            });
        }
    });
    $("#signUpButton").click(function () {
        if ($(this).closest('form').valid()) {
            var data = {
                Username: $("#signUpForm #Username").val(),
                Email: $("#signUpForm #Email").val(),
                Password: $("#signUpForm #Password").val()
            }
            $.post($("#_root").val() + "Home/SignUp", data, function (r) {
                if (r.success) {
                    $("#signInForm").show();
                    $("#signUpForm").hide();
                }
                else alert(r.errmsg);
            });
        }
    });
    $("#showSignUp").click(function () {
        $("#signInForm").fadeOut(300, function () {
            $("#signUpForm").fadeIn(500);
        });
    });
    $("#showSignIn").click(function () {
        $("#signInForm").show();
        $("#signUpForm").hide();
    });
});