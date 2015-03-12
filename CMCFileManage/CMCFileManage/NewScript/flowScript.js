$(document).ready(function() {
    eflow_net_CoverMe();
    $("#SelectUserDialog").dialog({
        modal: true,
        title: "請選擇人員信息",
        width: 720,
        height: 400
    });
});

/* Mask Control Block Script Start */
function eflow_net_CoverMe() {
    $("div.window-mask").each(function(i, item) {
        var DownDivID = jQuery(item).attr('DownDivID');

        var oDownDiv = document.getElementById(DownDivID);
        if (oDownDiv) {
            pos = eflow_net_getAbsolutePos(oDownDiv);
            jQuery(item).css({ height: oDownDiv.offsetHeight, width: oDownDiv.offsetWidth, top: pos.yPos, left: pos.xPos });

        }
    });
}

function eflow_net_getAbsolutePos(el) {
    if (el) {
        var obj = new Object();

        obj.xPos = el.offsetLeft;
        obj.yPos = el.offsetTop;
        tempEl = el.offsetParent;
        while (tempEl != null && tempEl != document.body) {
            obj.xPos += tempEl.offsetLeft;
            obj.yPos += tempEl.offsetTop;
            tempEl = tempEl.offsetParent;
        }

        return obj;
    }
}
/* Mask Control Block Script End */



function ShowProgress() {
    $('body').toggleLoading();

}

function CheckSelectUser(NextUser, NextStateID, CommandID, StopID) {
    var ids = [];
    var actionInfo = $("#" + CommandID + "").val();
    var actionInfoList = actionInfo.split("^");
    var mCommandName = "";
    if (actionInfoList.length > 0) {
        var actionValue = actionInfoList[1].split(":");
        mCommandName = actionValue[4];
    }
    var IsEndState = $("#" + StopID + "").val();
    if (mCommandName == "Approve" && IsEndState == "false") {
        var rows = $('#FlowUserInfo').datagrid('getSelections');
        if (rows == '') { $.messager.alert('warning', '請選擇人員!', 'warning'); return false; }
        else {
            for (var i = 0; i < rows.length; i++) {
                ids.push(rows[i].UserPKID + ":" + rows[i].UserName);
                $("#" + NextStateID + "").val(rows[i].NextStateID);
            }
            $("#" + NextUser + "").val(ids.join('^'));
            $('#SelectUserDialog').dialog('close');
            $('#DlgAdvice').css('display', 'none');
            ShowProgress();
            return true;
        }
    }
    else if (mCommandName == "Rejection") {
        var selected = $('#FlowUserInfo').datagrid('getSelected');
        if (selected) {
            $("#" + NextStateID + "").val(selected.NextStateID);
            $("#" + NextUser + "").val(selected.UserPKID + ":" + selected.UserName);
            $('#SelectUserDialog').dialog('close');
            $('#DlgAdvice').css('display', 'none');
            ShowProgress();
            return true;
        }
        else {

            $.messager.alert('warning', '請選擇駁回人員!', 'warning'); return false;
        }
    }
    else {
        $('#SelectUserDialog').dialog('close');
        $('#DlgAdvice').css('display', 'none');
        ShowProgress();
        return true;
    }


}

