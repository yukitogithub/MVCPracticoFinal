//var timeoutID
$(document).ready(function () {
    $("#save").attr('disabled', "disabled");
    timeoutID = window.setTimeout(TimeOut, time);
    timerID = window.setTimeout(Timer, 1000);
    $("#timerlbl").text(number);
    $("input[name=answer]", "#answers").click(function () {
        $("#save").removeAttr('disabled');
        $("#save").attr('title', "Guardá tu respuesta y continuá con la siguiente");
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
    }
});
function Timer() {
    number = number - 1;
    if (number > -1) {
        $("#timerlbl").text(number);
        timerID = window.setTimeout(Timer, 1000);
    }
    else {
        //TimeOut();
        window.clearTimeout(timerID);
    }
};
function TimeOut() {
    $("#p-dialog-message").text("Se te agotó el tiempo para responder la pregunta");
    $("#p-dialog-result").text("");
    $("#p-dialog-title").text("TIEMPO AGOTADO!");
    $("#buttonok").removeAttr('style');
    $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='TiempoAgotado()'/>");
    $("#popupDialog").popup("open");
    //implemento acá un timeout por si no hace click en el botón ok en 5 segundos
    window.clearTimeout(timeoutID);
    window.setTimeout(function () {
        TiempoAgotado();
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
        $("#p-dialog-result").text("");
        $("#p-dialog-title").text("ERROR");
        $("#buttonok").removeAttr('style');
        $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='OK()'/>");
        $("#popupDialog").popup("open");
    }
};
function End() {
    var questionid = $("#questionid").attr("value");
    var answerid = $("input[name=answer]:checked", "#answers").val();
    window.clearTimeout(timeoutID);
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
                $("#p-dialog-result").text("");
                $("#p-dialog-title").text("ERROR");
                $("#buttonok").removeAttr('style');
                $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='OK()'/>");
                $("#popupDialog").popup("open");
            }
            else {
                if (data.message != "") {
                    $("#p-dialog-message").text("El resultado de tu respuesta es: ");
                    $("#p-dialog-result").text(data.result);
                    $("#testresult").text(data.testresult);
                    $("#p-dialog-title").text("RESULTADO PARCIAL");
                    $("#message").attr("value", data.message);
                    $("#buttonok").removeAttr('style');
                    $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='TestTerminado()'/>");
                    $("#popupDialog").popup("open");
                }
                else {
                    $("#p-dialog-message").text("El resultado de tu respuesta es: ");
                    $("#p-dialog-result").text(data.result);
                    $("#p-dialog-title").text("RESULTADO PARCIAL");
                    $("#buttonok").attr("style", 'display:none;');
                    $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='OK()'/>");
                    $("#popupDialog").popup("open");
                    window.setTimeout(function () {
                        $("#popupDialog").popup("close");
                        timeoutID = window.setTimeout(TimeOut, $("#timeperanswer").attr("value"));
                        timerID = window.setTimeout(Timer, 1000);
                        number = $("#timeperanswer").attr("value") / 1000;
                        $("#timerlbl").text(number); 
                        }, 5000);
                    $("#questionid").attr("value", data.question.ID);
                    $("#question").text(data.question.question);
                    $("#actualquestionnumber").attr("value", data.aqn);
                    $("#actualquestionnumber2").text(data.aqn);
                    $("#answers input").each(function (i, element) {
                        $(element).attr("id", data.question.Answers[i].ID);
                        $(element).attr("value", data.question.Answers[i].ID);
                    });
                    $("#answers label").each(function (j, elem) {
                        $(elem).attr("for", data.question.Answers[j].ID);
                        $(elem).text(data.question.Answers[j].answer);
                        $(elem).removeClass("ui-radio-on").addClass("ui-radio-off");
                    });
//                    timeoutID = window.setTimeout(TimeOut, 45000);
                    $("#save").attr('disabled', "disabled");
                    $("#save").removeAttr('title');
                    $("input[name=answer]", "#answers").click(function () {
                        $("#save").removeAttr('disabled');
                        $("#save").attr('title', "Guardá tu respuesta y continuá con la siguiente");
                    });
                    $("#actualtime").attr("value", data.at);
                }
            }
        },
        error: function (data) {
            alert('Hubo un Error! Inténtalo nuevamente');
        }
    });
};
function OK() {
    $("#popupDialog").popup("close");
};
function TiempoAgotado() {
    $("#popupDialog").popup("close");
    Next();
};
function TestTerminado() {
    $("#p-dialog-message").text($("#message").attr("value") + ". El resultado total de tu test fue: ");
    $("#p-dialog-result").text($("#testresult").text());
    $("#p-dialog-title").text("TERMINASTE EL TEST!");
    $("#buttonok").removeAttr('style');
    $("#buttonok").html("OK <input type='button' data-enhanced='true' data-transition='flow' value='OK' onclick='MostrarTestResult()'/>");
    $("#popupDialog").popup("open");
};
function MostrarTestResult() {
    window.onbeforeunload = null;
    window.onunload = null;
    $(location).attr('href', "Index");
};