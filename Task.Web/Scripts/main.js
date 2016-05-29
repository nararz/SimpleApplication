function LeaveGroup(groupId, userId, url) {
    var data = { GroupId: groupId, UserId: userId };
    $.ajax({
        url: url,
        dataType: "json",
        data: data,
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        },
        error: function (data) {
            alert(data);
        }
    });
}

function JoinTheGroup(groupId, userId, url) {
    var data = { GroupId: groupId, UserId: userId };
    $.ajax({
        url: url,
        dataType: "json",
        data: data,
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        },
        error: function (data) {
            alert(data);
        }
    });
}

function AddGroup(groupId, index) {
    if ($('#' + index).prop('checked') == false) {
        $('#' + "Groups_"+index+"__Id").val(0);
    }
    else {
        $('#' + "Groups_" + index + "__Id").val(groupId);
    }
}