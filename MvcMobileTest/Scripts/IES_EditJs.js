$(function () {
    $("#cancel").click(function () {
        $(location).attr('href', "../../Home/Index/");
    });

    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();

    $("input[type=submit], input[type=button]").button()

    $("#dialog-message").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
                if (texto != "") {
                    if (titulo == "ERROR")
                        $("#p-dialog-message").empty();
                    else
                        $(location).attr('href', "../../Home/Index/");
                }
            }
        }
    });

    if (texto != "") {
        $("#dialog-message").removeAttr("title").dialog({ title: titulo });
        $("#dialog-message").dialog("open");
    };

    $("#update").attr('disabled', "disabled");
    $("#phone").keypress(function () {
        if ($(this).val() != '') {
            $("#update").removeAttr("disabled");
        }
    });
    $("#email").keypress(function () {
        if ($(this).val() != '') {
            $("#update").removeAttr("disabled");
        }
    });


});