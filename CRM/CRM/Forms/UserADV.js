var UserInit = 0;
var DataID = "";
//$(document).ready(function() {
//$('#userinfo').form.invalid();
//});
function GetCustomers(DataTableID, IsSingle) {
    $(DataTableID).datagrid({
        url: '../action/JqueryS.ashx?Method=Customer',
        queryParams: { CustomerName: '' },
        width: 670,
        height: 330,
        fitColumns: true,
        nowrap: false,
        rownumbers: true,
        loadMsg: "正在獲取數據,請稍候....",
        pagination: true,
        singleSelect: IsSingle,
        columns: [[
                    { field: 'PKID', hidden: true },
					{ field: 'CustomerID', title: '編號', width: 100 },
					{ field: 'CustomerName', title: '客戶名', width: 200 },
					{ field: 'CustomerEnglishName', title: '英文名', width: 140 },
					{ field: 'Industry', title: '行業', width: 200 }
				]]
    });
    $(DataTableID).datagrid('selectRow', 0);
}
function Saveuserinfo() {
    var Result = false;

    Result = $("#userinfo").form("validate");

    if (Result) {
        document.getElementById('LinkSave').click();
        return true;
        // $('#LinkSave').click();
    }
    else {
        return false;
    }
    

}
function selectcustomer(value) {
    var query = { CustomerName: value };
    $(DataID).datagrid('options').queryParams = query; //把查询条件赋值给datagrid内部变量
    $(DataID).datagrid('reload');
}
function GetCustomerDialog(DialogID, DataTableID, InpCustomerName, HidCustomerName, HidCustomerPKID) {
    $(DialogID).dialog({
        modal: true,
        title: "請選擇部門信息",
        width: 700,
        height: 400,
        buttons: [{
            text: 'Ok',
            iconCls: 'icon-ok',
            handler: function() {
                var selected = $(DataTableID).datagrid('getSelected');
                if (selected) {
                    if (InpCustomerName != undefined) {
                        document.getElementById(InpCustomerName).value = selected.CustomerName;
                        $('#' + InpCustomerName).value = selected.CustomerName;
                        $('#' + HidCustomerName).val(selected.CustomerName);
                        $('#' + HidCustomerPKID).val(selected.PKID);
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
            GetCustomers(DataTableID, true);
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
    function CheckFile(obj) {
        var array = new Array('gif', 'jpeg', 'png', 'jpg');
        if (obj.value == '') {
            alert("請選擇要上傳的圖片!");
            return false;
        }
        else {
            var fileContentType = obj.value.match(/^(.*)(\.)(.{1,8})$/)[3];
            var isExists = false;
            for (var i in array) {
                if (fileContentType.toLowerCase() == array[i].toLowerCase()) {
                    isExists = true;
                    return true;
                }
            }
            if (isExists == false) {
                alert("文件類型不正確!");
                return false;
            }
            return false;
        }
    }