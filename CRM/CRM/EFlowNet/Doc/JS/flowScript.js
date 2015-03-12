/* Add Human or Dept Info End */

/* Mask Control Block Script Start */

function eflow_net_CoverMe() {
    $("div.window-mask").each(function() {
        var DownDivID = this.DownDivID;
        var oDownDiv = document.getElementById(DownDivID);
        if (oDownDiv) {
            this.style.height = oDownDiv.offsetHeight;
            this.style.width = oDownDiv.offsetWidth;
            pos = eflow_net_getAbsolutePos(oDownDiv);
            this.style.top = pos.yPos;
            this.style.left = pos.xPos;
        }
    });
}

function eflow_net_getAbsolutePos(el) {
    if (el) {
        var obj = new Object();

        obj.xPos = el.offsetLeft;
        obj.yPos = el.offsetTop;
        tempEl = el.offsetParent;
        while (tempEl != null) {
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

function CheckSelectUser(NextUser, NextStateID, CommandID, StopID, IsAutoID) {

    if ($("#" + IsAutoID + "").val() == 'false') {
        var ids = [];
        var actionInfo = $("#" + CommandID + "").val();
        var actionInfoList = actionInfo.split("^");
        var mCommandName = "";
        if (actionInfoList.length > 0) {
            var actionValue = actionInfoList[1].split(":");
            mCommandName = actionValue[5];
        }
        var IsEndState = $("#" + StopID + "").val();
        if (mCommandName == "Approve" && IsEndState == "false") {

            if ($('#HidHuiqian').val() == "1") {
                $('#FlowUserInfo').datagrid('selectAll');
            }
            var rows = $('#FlowUserInfo').datagrid('getSelections');
            if (rows == '') { $.messager.alert('warning', FlowSelectUAlert, 'warning'); return false; }
            else {
                for (var i = 0; i < rows.length; i++) {
                    ids.push("1:" + rows[i].UserPKID + ":" + rows[i].UserName + ":" + rows[i].UserSID);
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
                $("#" + NextUser + "").val("1:" + selected.UserPKID + ":" + selected.UserName);
                $('#SelectUserDialog').dialog('close');
                $('#DlgAdvice').css('display', 'none');
                ShowProgress();
                return true;
            }
            else {

                $.messager.alert('warning', FlowSelectReAlert, 'warning'); return false;
            }
        }
        else {
            $('#SelectUserDialog').dialog('close');
            $('#DlgAdvice').css('display', 'none');
            ShowProgress();
            return true;
        }
    }
    else {
        $('#SelectUserDialog').dialog('close');
        $('#DlgAdvice').css('display', 'none');
        ShowProgress();
        return true;
    }
}
$(document).ready(function() {
    eflow_net_CoverMe();
    $("#SelectUserDialog").dialog({
        modal: true,
        title: DialogTitle,
        width: 720,
        height: 400
    });
});
function ActionListValidate() {
        return $('form').form("validate");
}

/*DataSign Script Start*/
function MsgSign(Msg, DateSignID, CurUserName) {
    var UserName;
    var SignerEncrytString;
    var SignFileInfo;
    if (typeof (Signer) == "object") {
        try {
            SignerEncrytString = Signer.SignMsgHash(Msg);
            SignFileInfo = Signer.VerifyMsgHashStr(SignerEncrytString, Msg);

            var datas = SignFileInfo.split(',');

            for (var i = 0; i < datas.length; i++) {
                if (datas[i].indexOf('CN=') >= 0) { UserName = datas[i].substring(datas[i].indexOf('CN=') + 3); }
            }
            if (CurUserName != UserName) {
                alert("选择的数字签章与当前登录人员不同!");
                return false;

            }
            else {
                document.getElementById(DateSignID).value = String(SignerEncrytString);
                return true;

            }
        }
        catch (ex) {
            return false;
        }
    }
}


//SignPdf
function SignPdf(FileIDControl, SignFileControl, FileDicControl, SignFieldControl,BtnSureControl) {
    var info;
    var info2;
    var FileID = document.getElementById(FileIDControl).value;
    var SignFiled = document.getElementById(SignFieldControl).value;
    var SubFileDic = document.getElementById(FileDicControl).value;
    //Sign
    if (typeof (Signer) != "OBJECT") {
        // Signer = Signer;

        info = Signer.SignByName2(FileID, SignFiled, SubFileDic, "", "FOXCONN CA"); //第三個參數可以為"",默認會選擇自己電腦上的數字签章
        if (info == "true") {
            info2 = Signer.SignSuccessfulList();
            info2.split(",")
            var ResultList = info2.split(";");
            var ReturnFile = "";
            for (var i = 0; i < ResultList.length - 1; i++) {
                var mFileInfo = ResultList[i].split(",");
                ReturnFile = mFileInfo[2];
            }

            document.getElementById(SignFileControl).value = ReturnFile;
            document.getElementById(BtnSureControl).click();
            
        }
        else {
            alert("文件數字簽名失敗,請重試或者聯繫管理員!");
        }

    }
}
/*DataSign Script End*/