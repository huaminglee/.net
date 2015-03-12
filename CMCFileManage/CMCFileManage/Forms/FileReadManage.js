var SubEditIndex = 0;
var CanAdd = true;
var SampleEditIndex = 0;
var CodeData;
var combocname;
var txtname;
$(function() {
    //Initcombox()
    $('#FileDialog').parent().bgiframe();
    $('#FileDialog').bgiframe();
    $('#SelectUserDialog').parent().bgiframe();
    $('#SelectUserDialog').bgiframe();
    

});
function Initcombox() {
    //  $('#FileBH1').click(function() {
    InitfileComobobox("FileBH1", "txtFilename1");
    // })
    //    $('#FileBH2').click(function() {
    InitfileComobobox("FileBH2", "txtFilename2");
    //  })
    // $('#FileBH3').click(function() {
    InitfileComobobox("FileBH3", "txtFilename3");
    //  })
    // $('#FileBH4').click(function() {
    InitfileComobobox("FileBH4", "txtFilename4");
    // })
    // $('#FileBH5').click(function() {
    InitfileComobobox("FileBH5", "txtFilename5");
    //})
    // $('#FileBH6').click(function() {
    InitfileComobobox("FileBH6", "txtFilename6");
    //})
    // $('#FileBH7').click(function() {
    InitfileComobobox("FileBH7", "txtFilename7");
    // })
    // $('#FileBH8').click(function() {
    InitfileComobobox("FileBH8", "txtFilename8");
    // })
    // $('#FileBH9').click(function() {
    InitfileComobobox("FileBH9", "txtFilename9");
    // })
    // $('#FileBH10').click(function() {
    InitfileComobobox("FileBH10", "txtFilename10");
    // })
}
function InitfileComobobox(combocname, txtname) { //綁定費用代碼
    var mSelectCode = $('#' + "Hidden" + combocname).val();
    if (CodeData == undefined) {
        $.ajax({
            url: "FileReadManageDetail.aspx/GetFileInfo",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                CodeData = msg.d
                $('#' + combocname).combobox({
                    width: '106',
                    data: CodeData,
                    required: true,
                    panelHeight: "200",
                    valueField: 'Key',
                    textField: 'Value',
                    onLoadSuccess: function() {
                        if (mSelectCode != "") {
                            $('#' + combocname).combobox('setText', mSelectCode);
                        }

                    },
                    onSelect: function(rowDate) {

                        $('#hidExpenseCode').val(rowDate.innerText);
                        var DepIndex = rowDate.value.indexOf("$") + 1;
                        $('#' + txtname).val(rowDate.value.substring(DepIndex, rowDate.value.length));
                        $('#' + "Hidden" + combocname).val(rowDate.innerText)
                    },
                    onChange: function(newValue, oldValue) {
                        $('#hidExpenseCode').val("");
                        $('#' + txtname).val("");

                    }
                });
            }
        });
    }
    else {
        $('#' + combocname).combobox({
            width: '106',
            data: CodeData,
            required: true,
            panelHeight: "200",
            valueField: 'Key',
            textField: 'Value',
            onLoadSuccess: function() {
                if (mSelectCode != "") {
                    $('#' + combocname).combobox('setText', mSelectCode);
                }

            },
            onSelect: function(rowDate) {

                $('#hidExpenseCode').val(rowDate.innerText);
                var DepIndex = rowDate.value.indexOf("$") + 1;
                $('#' + txtname).val(rowDate.value.substring(DepIndex, rowDate.value.length));
                $('#' + "Hidden" + combocname).val(rowDate.innerText)
            },
            onChange: function(newValue, oldValue) {
                $('#' + "Hidden" + combocname).val("");
                $('#' + txtname).val("");


            }
        });

    }
}


//選擇文件

var UserInit = 0;
var DataID = "";
//$(document).ready(function() {
//$('#userinfo').form.invalid();
//});
function GetFile(DataTableID, IsSingle) {
    $(DataTableID).datagrid({
        url: '../action/JqueryS.ashx?Method=GetFile',
        queryParams: { FileName: '' },
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
					{ field: 'FileBH', title: '文件編號', width: 100 },
					{ field: 'FileName', title: '文件名', width: 200 },
					{ field: 'FileLayer', title: '文件階層', width: 140 },
					{ field: 'ApplyDept', title: '申請單位', width: 140 },
					{ field: 'EffectDate', title: '生效日期', width: 200 }
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
    var query = { FileName: value };
    $(DataID).datagrid('options').queryParams = query; //把查询条件赋值给datagrid内部变量
    $(DataID).datagrid('reload');
}
function GetFileDialog(DialogID, DataTableID, DropDownList1) {
    $(DialogID).dialog({
        modal: true,
        title: "請選擇文件信息",
        bgiframe: true,
        width: 700,
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
                    var Curfilecount = parseInt($("#LbFileCount").html());
                    document.getElementById("HiddenFileCount").value = Curfilecount + rows.length;

                    $("#LbFileCount").html(Curfilecount + rows.length);
                    if (Curfilecount + rows.length > 10) {
                        rows.length = 10 - Curfilecount;
                    }
                    // document.getElementById("BtnBindDPL").click();


                    for (var i = Curfilecount; i < Curfilecount + rows.length; i++) {
                        document.getElementById("file" + (i + 1)).style.display = "inline";
                        document.getElementById("FileBH" + (i + 1)).value = rows[i - Curfilecount].FileBH;
                        document.getElementById("HiddenFileBH" + (i + 1)).value = rows[i - Curfilecount].FileBH;
                        document.getElementById("HiddenFileName" + (i + 1)).value = rows[i - Curfilecount].FileName;
                        document.getElementById("txtFilename" + (i + 1)).value = rows[i - Curfilecount].FileName;
                        //                        UserNameIDS.push(rows[i].UserName);           賦值
                        //                        UserIDS.push(rows[i].UserSID);

                    }
                    if (Curfilecount > 0) {
                        document.getElementById("delete" + Curfilecount.toString()).style.display = "none";
                    }
                    document.getElementById("delete" + (Curfilecount + rows.length).toString()).style.display = "inline";
                    if (rows.length < 10) {
                        for (var i = Curfilecount + rows.length; i < 10; i++) {
                            document.getElementById("file" + (i + 1)).style.display = "none";
                        }
                    }


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
            GetFile(DataTableID, false);
        }
        $(DataTableID).datagrid('clearSelections');
        UserInit = 1;
        parent.iFrameHeight();
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
    function ReadTypechange(dplid, index) {
        var ddl = document.getElementById(dplid);
        var dindex = document.getElementById(dplid).selectedIndex;
        if (dindex != -1) {
            var readtype = ddl.options[dindex].text;
            if (readtype == "受控紙檔" || readtype == "非受控紙檔") {
                document.getElementById("fenshu" + index.toString()).style.display = "inline";
            }
            else {
                document.getElementById("fenshu" + index.toString()).style.display = "none";
            }
            if (readtype == "其它") {
                document.getElementById("shuoming" + index.toString()).style.display = "inline";
            }
            else {
                document.getElementById("shuoming" + index.toString()).style.display = "none";
            }
        }
    }
    function deletecur(index) {
        var Curfilecount = parseInt($("#LbFileCount").html());
        $("#LbFileCount").html(Curfilecount - 1)
        document.getElementById("HiddenFileCount").value = Curfilecount - 1;
        document.getElementById("file" + index.toString()).style.display = "none";
        if (index > 1) {
            document.getElementById("delete" + (index - 1).toString()).style.display = "inline";
        }
        document.getElementById("delete" + index.toString()).style.display = "none";
    }
