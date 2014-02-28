$(document).ready(function () {
    $("input[type=button]").button().tooltip();
    $("#save").tooltip();
    $("#answers").buttonset();
    $("#answers").children("label").removeClass("ui-corner-left").addClass("myradiobutton");
    $("#answers").children("label").removeClass("ui-corner-right").addClass("myradiobutton");
    $("#save").attr('disabled', "disabled");
    $("#next").tooltip();
    $("#end").tooltip();
    $("#dialog-message").dialog({
        autoOpen: false,
        modal: true,
        title: "Message",
        draggable: false,
        resizable: false,
        buttons: {
        }
    });
    timeoutID = window.setTimeout(TimeOut, time);
    timerID = window.setTimeout(Timer, 1000);
    $("#timerlbl").text(number);
    $("input[name=answer]", "#answers").click(function () {
        $("#save").removeAttr('disabled');
        $("#save").attr('title', "Guardá tu respuesta y continuá con la siguiente");
        $("#save").tooltip();
    });
    if (history.forward(1) != null) {
        history.replace(history.forward(1));
    };
    window.onbeforeunload = function (e) {
        var e = e || window.event;
        var msg = "Si salís de la página se te dará por terminado el test!";

        // For IE and Firefox
        if (e) {
            e.returnValue = msg;
        }

        // For Safari / chrome
        return msg;
    };
    window.onunload = function () {
        End();
    };
});
function Timer() {
    number = number - 1;
    if (number > -1) {
        $("#timerlbl").text(number);
        timerID = window.setTimeout(Timer, 1000);
    }
    else {
        TimeOut();
        window.clearTimeout(timerID);
    }
};
function TimeOut() {
    $("#p-dialog-message").text("Se te agotó el tiempo para responder la pregunta");
    $("#p-dialog-result").text("");
    $("#dialog-message").dialog({
        autoOpen: false,
        modal: true,
        title: "TIEMPO AGOTADO!",
        draggable: false,
        resizable: false,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
                Next();
            }
        }
    }).dialog("open");
    //implemento acá un timeout por si no hace click en el botón ok en 5 segundos
    window.clearTimeout(timeoutID);
    window.setTimeout(function () {
        $("#dialog-message").dialog("close");
        Next();
    }, 5000);
};
function Next() {
    var questionid = $("#questionid").attr("value");
    window.clearTimeout(timeoutID);
    window.clearTimeout(timerID);
    Enviar(questionid, "0", $("#actualquestionnumber").attr("value"), '"Next"');
};
function Save() {
    var questionid = $("#questionid").attr("value");
    var answerid = $("input[name=answer]:checked", "#answers").val();
    if (answerid != null) {
        window.clearTimeout(timeoutID);
        window.clearTimeout(timerID);
        Enviar(questionid, answerid, $("#actualquestionnumber").attr("value"), '"Save"');
    } else {
        $("#p-dialog-message").text("Tenés que seleccionar alguna de las respuestas!");
        $("#dialog-message").dialog({
            autoOpen: false,
            modal: true,
            title: "ERROR",
            draggable: false,
            resizable: false,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        }).dialog("open");
    }
};
function End() {
    var questionid = $("#questionid").attr("value");
    var answerid = $("input[name=answer]:checked", "#answers").val();
    window.clearTimeout(timeoutID)
    window.clearTimeout(timerID);
    if (answerid != null) {
        Enviar(questionid, answerid, $("#actualquestionnumber").attr("value"), '"End"');
    } else {
        Enviar(questionid, "0", $("#actualquestionnumber").attr("value"), '"End"');
    }
};
function Enviar(QuestionId, AnswerId, ActualQuestionNumber, Method) {
    var ActualTime = $("#actualtime").attr("value");
    $.ajax({
        type: "POST",
        url: '../Home/Question',
        data: "{'question':" + QuestionId + ", 'answer':" + AnswerId + ", 'actualquestionnumber':" + ActualQuestionNumber + ", 'actualtime': '" + ActualTime + "', 'method':" + Method + "}",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.error != "") {
                $("#p-dialog-message").text(data.error);
                $("#dialog-message").dialog({
                    autoOpen: false,
                    modal: true,
                    title: "ERROR",
                    draggable: false,
                    resizable: false,
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                        }
                    }
                }).dialog("open");
            }
            else {
                if (data.message != "") {
                    $("#p-dialog-message").text("El resultado de tu respuesta es: ");
                    $("#p-dialog-result").text(data.result);
                    $("#dialog-message").dialog({
                        autoOpen: false,
                        modal: true,
                        title: "RESULTADO PARCIAL",
                        draggable: false,
                        resizable: false,
                        buttons: {
                            Ok: function () {
                                $("#p-dialog-message").text(data.message + ". El resultado total de tu test fue: ");
                                $("#p-dialog-result").text(data.testresult);
                                $("#dialog-message").dialog({
                                    autoOpen: false,
                                    modal: true,
                                    title: "TERMINASTE EL TEST!",
                                    draggable: false,
                                    resizable: false,
                                    buttons: {
                                        Ok: function () {
                                            $(this).dialog("close");
                                            window.onbeforeunload = null;
                                            window.onunload = null;
                                            $(location).attr('href', "Index");
                                        }
                                    }
                                }).dialog("open");
                            }
                        }
                    }).dialog("open");
                }
                else {
                    $("#p-dialog-message").text("El resultado de tu respuesta es: ");
                    $("#p-dialog-result").text(data.result);
                    $("#dialog-message").dialog({
                        autoOpen: false,
                        modal: true,
                        title: "RESULTADO PARCIAL",
                        draggable: false,
                        resizable: false,
                        buttons: {
                        }
                    }).dialog("open");
                    window.setTimeout(function () {
                        $("#dialog-message").dialog("close");
                        timeoutID = window.setTimeout(TimeOut, $("#timeperanswer").attr("value"));
                        timerID = window.setTimeout(Timer, 1000);
                        number = $("#timeperanswer").attr("value") / 1000;
                        $("#timerlbl").text(number);
                    }, 5000);
                    $("#questionid").attr("value", data.question.ID);
                    $("#question").text(data.question.question);
                    $("#actualquestionnumber").attr("value", data.aqn);
                    $("#actualquestionnumber2").text(data.aqn);
                    var str = "";
                    $.each(data.question.Answers, function (index, item) {
                        str = str + "<input name='answer' id=" + item.ID + " type='radio' value=" + item.ID + " /><label for=" + item.ID + ">" + item.answer + "</label><br />";
                    });
                    $("#answers").html(str);
                    $("#save").attr('disabled', "disabled");
                    $("#save").removeAttr('title');
                    $("#save").tooltip();
                    $("input[name=answer]", "#answers").click(function () {
                        $("#save").removeAttr('disabled');
                        $("#save").attr('title', "Guardá tu respuesta y continuá con la siguiente");
                        $("#save").tooltip();
                    });
                    $("#answers").buttonset();
                    $("#answers").children("label").removeClass("ui-corner-left").addClass("myradiobutton");
                    $("#answers").children("label").removeClass("ui-corner-right").addClass("myradiobutton");
                    $("#actualtime").attr("value",data.at);
                }
            }
        },
        error: function (data) {
            alert('Hubo un Error! Inténtalo nuevamente');
        }
    });
};