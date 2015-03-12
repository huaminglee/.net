function DialogMove(left, top, dialogID) {
    var right, bottom;
    var bodyWidth = $("body").width();
    var bodyHeight = $("body").height();
    var dialogwidth = $(dialogID).width();
    var dialogHeight = $(dialogID).height();
    if (left < 0) {
        $(dialogID).dialog("move", { left: 0, top: top });
    } else if ((left + dialogwidth) > (bodyWidth)) {
        right = bodyWidth - dialogwidth - 50;
        $(dialogID).dialog("move", { left: right, top: top });
    }
    if (top < 0) {
        $(dialogID).dialog("move", { left: left, top: 0 });
    }
}
function GetUser(DataTableID, IsSingle) {
    $(DataTableID).datagrid({
        url: '../action/JqueryS.ashx?Method=CodeUder',
        queryParams: { UserID: '' },
        width: 600,
        height: 330,
        fitColumns: true,
        nowrap: false,
        rownumbers: true,
        loadMsg: "正在獲取數據,請稍候....",
        pagination: true,
        singleSelect: IsSingle,
        columns: [[
					{ field: 'AccountPKID', hidden: true },
					{ field: 'UserSID', title: '工號',width:100 },
					{ field: 'UserName', title: '姓名',width:100  },
					{ field: 'Email1', title: 'Email1',width:200  },
					{ field: 'Telphone', title: '分機號碼', width: 100 }
				]]
    });
    $(DataTableID).datagrid('selectRow', 0);
}
var DataID = "";
var UserInit = 0;
function GetUserDialog(DialogID, DataTableID, UserPKID, UserID, UserNameID, EmailID, TelphoneID) {
    $(DialogID).dialog({
        modal: true,
        title: "請選擇人員信息",
        width: 620,
        height: 400,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function() {
                var selected = $(DataTableID).datagrid('getSelected');
                if (selected) {
                    $('#' + UserPKID).val(selected.AccountPKID);
                    $('#' + UserID).html(selected.UserSID);
                    $('#' + UserNameID).html(selected.UserName);
                    $('#' + EmailID).html(selected.Email1);
                    $('#' + TelphoneID).html(selected.Telphone);
                    $(DialogID).dialog('close');

                }
                else {
                    alert('請選擇');
                }
            }
        }, {
            text: 'Cancel',
            handler: function() {
                $("#dlg-toolbar").hide();
                $(DialogID).dialog('close');
            }
}],
            onMove: function(left, top) {
                DialogMove(left, top, DialogID);
            }
        });

        $(DialogID).dialog('open');
        DataID = DataTableID;
        $("#dlg-toolbar").show();
        if (UserInit == 0) {
            GetUser(DataTableID, true);
        }
        UserInit = 1;
    }
    function GetMutliUserDialog(DialogID, DataTableID, UserID, UserNameID) {
        $(DialogID).dialog({
            modal: true,
            title: "請選擇人員信息",
            width: 600,
            height: 400,
            buttons: [{
                text: 'Ok',
                iconCls: 'icon-ok',
                handler: function() {
                    var rows = $(DataTableID).datagrid('getSelections');
                    if (rows == '') { $.messager.alert('warning', '請選擇!', 'warning'); return false; }
                    else {
                        var UserIDS = [];
                        var UserNameIDS = [];

                        for (var i = 0; i < rows.length; i++) {
                            UserNameIDS.push(rows[i].UserName);
                            UserIDS.push(rows[i].UserSID);
                        }
                        $(DataTableID).datagrid('clearSelections');
                        $('#' + UserID).val(UserIDS.join(';'));
                        $('#' + UserNameID).val(UserNameIDS.join(';'));
                        
                        $(DialogID).dialog('close');

                    }

                }
            }, {
                text: 'Cancel',
                handler: function() {
                    $("#dlg-toolbar").hide();
                    $(DialogID).dialog('close');
                }
}],
                onMove: function(left, top) {
                    DialogMove(left, top, DialogID);
                }
            });

            $(DialogID).dialog('open');
            DataID = DataTableID;
            $("#dlg-toolbar").show();
            if (UserInit == 0) {
                GetUser(DataTableID, false);
            }
            UserInit = 1;
        }
        var UserInit = 0;
        function selectUser(value) {
            var query = { UserID: value };
            $(DataID).datagrid('options').queryParams = query; //把查询条件赋值给datagrid内部变量
            $(DataID).datagrid('reload');
        }
        function getAuthorityUser(DialogID, DataTableID, SaveTableID, DeptPKID) {
            $(DialogID).dialog({
                modal: true,
                title: "請選擇人員信息",
                width: 620,
                height: 400,
                buttons: [{
                    text: 'Ok',
                    iconCls: 'icon-ok',
                    handler: function() {
                    var IsKeepUser = $("input:checked", "#IskeepUser").val();
                    var DeptName;
                    if (IsKeepUser == '0') {
                        DeptName = '';
                    }
                    else {
                        DeptName = $('#DeptName').val();
                    }
                        var rows = $(DataTableID).datagrid('getSelections');
                        var ids = [];
                        if (rows != '') {

                            for (var i = 0; i < rows.length; i++) {
                                ids.push(rows[i].UserName + ":" + rows[i].UserSID + ":" + rows[i].Email1 + ":" + rows[i].Telphone + ":" + $("#window").val() + ":" + $("#InfomationType").val() + ":" + IsKeepUser  + ":" + DeptName );
                            }
                            var selectUserInfo = ids.join('^');
                            $.ajax({
                                url: "DeptTree.aspx/SaveAuthorityUser",
                                contentType: "application/json",
                                type: "post",
                                data: "{'sUserInfo':'" + selectUserInfo + "','DeptPKID':'" + DeptPKID + "'}",
                                dataType: 'json',
                                success: function(msg) {

                                    alert('授權成功!');
                                    $(SaveTableID).datagrid('reload');
                                }
                            });

                            $(DialogID).dialog('close');
                        }
                        else {
                            alert('請選擇人員信息');
                        }
                    }
                }, {
                    text: 'Cancel',
                    handler: function() {
                        $("#dlg-toolbar").hide();
                        $(DialogID).dialog('close');
                    }
}],
                    onMove: function(left, top) {
                        DialogMove(left, top, DialogID);
                    }
                });

                $(DialogID).dialog('open');
                DataID = DataTableID;
                $("#dlg-toolbar").show();
                if (UserInit == 0) {
                    GetUser(DataTableID, false);
                }
                UserInit = 1;
            }
   

