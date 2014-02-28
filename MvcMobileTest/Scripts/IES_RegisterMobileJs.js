$(function () {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();
    $("input[type='date']").prop("data-role", "date");

    $("#datepicker").datepicker({
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true,
        showAnim: "drop"
    });

    if (texto != "") {
        $("#popupDialog").popup("open")
        clearTimeout(fallback);

        // Fallback in case the browser doesn't fire a load event
        var fallback = setTimeout(function () {
            $("#popupDialog").popup("open");
        }, 100);
    }
});

function OK() {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();
    $("#popupDialog").popup("close");
    if (texto != "") {
        if (titulo != "ERROR")
            $(location).attr('href', "Login");
    }
}