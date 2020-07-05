$(function () {
    $("#Addnewproduct").click(function (e) {
        e.preventDefault();
        if ($(this).closest('form').valid()) {
            var data = {
                Productname: $("#Productname").val(),
                Description: $("#Description").val(),
                Price: $("#Price").val()
            }
            $.post($("#_root").val() + "Home/AddProducts", data, function (r) {
                if (r.success) {
                    window.location = ($("#_root").val() + "Home/dashboard");
                }
                else alert(r.errmsg);
            });
        }
    });
    $("#cancelButton").click(function () {
        window.history.back();
    });
});