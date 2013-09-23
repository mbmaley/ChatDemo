var chatHub = $.connection.chatHub;

chatHub.client.broadCastMessage = function (nickname, message)
{
    var messageToInsert = nickname + ": " + message + "\n";
    $('#chatArea').val(function (index, val) {
        return val + messageToInsert;
    });
};


$.connection.hub.start({ transport: 'longPolling' }).done(function ()
{
    $('#submit').click(function () {
        var nickname = $('#Nickname').val();
        var message = $('#Message').val();
        $('#Nickname').attr('readonly', true);
        chatHub.server.sendBroadCastMessage(nickname, message);
        $('#Message').val('').focus();
    });
});