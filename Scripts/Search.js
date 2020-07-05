$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    
    $("#search").click(function (e) {
        e.preventDefault();
        var dat = $("#search-box").val();
        window.location.href = $("#_root").val() + "Home/SearchProduct?dat=" + dat;
    });
    $("#plus").click(function (e) {
        window.location = ($("#_root").val() + "Home/AddProduct");
    });
    $(".delete").click(function () {
        data = {
            Productid: $(this).find(".Productid").val()
        }
    });
    $("#deleteButton").click(function () {
        
        $.post($("#_root").val() + "Home/DeleteProduct", data, function (r) {
            if (r.Success) {
                window.location = ($("#_root").val() + "Home/Dashboard");
            }
        });
    });
    $('.collapse').collapse();
    $("#main").click(function (e) {
        window.location = ($("#_root").val() + "Home/Dashboard");
    });
});