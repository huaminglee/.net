var UserInit = 0;
var DataID = "";
function searchcontact() {
    var BtnSearch = document.getElementById("BtnSearch");
    BtnSearch.click();
}
function GetContact(DataTableID, IsSingle) {
    $(DataTableID).datagrid({
        url: '../action/JqueryS.ashx?Method=Contact',
        queryParams: { ContactName: '' },
        width: 500,
        height: 330,
        fitColumns: true,
        nowrap: false,
        rownumbers: true,
        loadMsg: "正在獲取數據,請稍候....",
        pagination: true,
        singleSelect: IsSingle,
        columns: [[
                    { field: 'PKID', hidden: true },
					{ field: 'UserName', title: '姓名', width: 100 },
					{ field: 'UserSID', title: '用戶名', width: 100 },
					{ field: 'CustomerName', title: '公司', width: 200 }

				]]
    });
    $(DataTableID).datagrid('selectRow', 0);
}
function GetContactDialog(DialogID, DataTableID, TxtName, HiddenContactPKID, TxtSID, TxtCustomerName) {
    $(DialogID).dialog({
        modal: true,
        title: "請選擇聯繫人信息",
        width: 530,
        height: 400,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function() {
                var selected = $(DataTableID).datagrid('getSelected');
                if (selected) {
                    if (HiddenContactPKID != undefined) {
                        document.getElementById(HiddenContactPKID).value = selected.PKID;
                        $('#' + TxtName).val(selected.UserName);
                        $('#' + TxtSID).val(selected.UserSID);
                        $('#' + TxtCustomerName).val(selected.CustomerName);
                    }
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
            GetContact(DataTableID, true);
        }
        UserInit = 1; 
    }
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
    function selectcontact(value) {
        var query = { ContactName: value };
        $(DataID).datagrid('options').queryParams = query; //把查询条件赋值给datagrid内部变量
        $(DataID).datagrid('reload');
    }
    function GetMutilContactDialog(DialogID, DataTableID, TxtName, HiddenField) {
        $(DialogID).dialog({
            modal: true,
            title: "請選擇人員信息",
            width: 530,
            height: 400,
            buttons: [{
                text: 'Ok',
                iconCls: 'icon-ok',
                handler: function() {
                    var rows = $(DataTableID).datagrid('getSelections');
                    if (rows == '') { $.messager.alert('warning', '請選擇!', 'warning'); return false; }
                    else {

                        var UserNameIDS = [];

                        for (var i = 0; i < rows.length; i++) {
                            UserNameIDS.push(rows[i].UserName);

                        }
                        $(DataTableID).datagrid('clearSelections');
                        $('#' + TxtName).val(UserNameIDS.join(';'));
                        document.getElementById(HiddenField).value = UserNameIDS.join(';');

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
                GetContact(DataTableID, false);
            }
            UserInit = 1;

        }