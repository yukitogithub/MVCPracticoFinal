$(function () {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();

    if (texto != "") {
        $("#popupDialog").popup("open")
        clearTimeout(fallback);

        // Fallback in case the browser doesn't fire a load event
        var fallback = setTimeout(function () {
            $("#popupDialog").popup("open");
        }, 100);
    }

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

function OK() {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();
    $("#popupDialog").popup("close");
    if (texto != "") {
        if (titulo != "ERROR")
            $(location).attr('href', "../../Home/Index");
    }
}