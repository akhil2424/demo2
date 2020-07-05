$(function () {
    $("#Updateproduct").click(function (e) {
        e.preventDefault();
        if ($(this).closest('form').valid()) {
            $.post($("#_root").val() + "Home/UpdateProduct", $('form').serialize(), function (r) {
                if (r.Success) {
                    window.location = ($("#_root").val() + "Home/dashboard");
                }
                else {
                    alert("Error")
                }
            });
        }
    });
    $("#cancelButton").click(function () {
        window.history.back();

    });
});