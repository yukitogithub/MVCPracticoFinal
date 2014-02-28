$(function () {
    var texto = $("#p-dialog-message").text();
    var titulo = $("#p-dialog-title").text();
    $("#username").removeAttr('value').attr('data-clear-btn', "true").attr('data-enhanced', true);
    $("#password").removeAttr('value').attr('data-clear-btn', "true").attr('data-enhanced', true);
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
    $("#popupDialog").popup("close");
};