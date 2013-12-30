﻿$(function () {
    var myConnection = $.connection("/signalrchat");

    myConnection.received(function (data) {
        $("#messages").append("<li>" + data.Name + ': ' + data.Message + "</li>");
    });

    myConnection.error(function (error) {
        console.warn(error);
    });

    myConnection.start()
        .promise()
        .done(function () {
            $("#send").click(function () {
                var myName = $("#Name").val();
                var myMessage = $("#Message").val();
                myConnection.send(JSON.stringify({ name: myName, message: myMessage }));
            })
        });
});