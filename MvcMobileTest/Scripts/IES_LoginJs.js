$(function () {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();

    $("input[type=submit]").button()

    $("#dialog-message").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
                if (texto != "") {
                    if (titulo == "ERROR")
                        $("#p-dialog-message").empty();
                }
            }
        }
    });

    if (texto != "") {
        $("#dialog-message").removeAttr("title").dialog({ title: titulo });
        $("#dialog-message").dialog("open");
    }
});