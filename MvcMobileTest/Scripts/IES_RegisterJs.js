$(function () {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();

    $("input[type=submit], input[type=reset]").button()
    $("#datepicker").datepicker({
        showOn: "button",
        buttonImage: "../Content/images/calendar.png",
        buttonImageOnly: true,
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true,
        showAnim: "drop"
    });

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
                        $(location).attr('href', "Login");
                }
            }
        }
    });

    if (texto != "") {
        $("#dialog-message").removeAttr("title").dialog({ title: titulo });
        $("#dialog-message").dialog("open");
    }
});