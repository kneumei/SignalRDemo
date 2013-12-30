$(function () {
    var chatHub = $.connection.chatHub;

    $("#alerts").hide();

    $.connection.hub.logging = true;

    chatHub.client.broadcastMessage = function (name, message) {
        $("#messages").append("<li>" + name + ": " + message + "</li>");
    }

    chatHub.client.userJoined = function () {
        $("#alerts").text("A new user joined the chat room!").slideDown("slow").delay(1500).slideUp("slow");
    }

    chatHub.client.userLeft = function (name) {
        $("#alerts").text(name + " left the chat room!").slideDown("slow").delay(1500).slideUp("slow");
    }

    $.connection.hub.start().done(function () {
        $("#send").click(function () {
            chatHub.server.send($("#Name").val(), $("#Message").val())
        });
    });
});