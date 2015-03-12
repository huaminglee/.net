$(function() {
    if ($('#HiddenCanSelectCus').val() == "1") {
        Initcustomer();
    }
    CanAdd = $('#HidCanAdd').val();
    if (CanAdd == "1") {
        FileInit();
    }


});
var CanAdd = "0";
var CustomerData;
function Initcustomer() {
    var selectCustomer = $('HiddenCustomerName').val();
    if (CustomerData == undefined) {
        $.ajax({
            url: "FileShare.aspx/GetAllCustomer",
            contentType: "application/json",
            type: "post",
            data: "",
            dataType: 'json',
            success: function(msg) {
                CustomerData = msg.d
                $('#Txtcustomer').combobox({
                    width: '300',
                    data: CustomerData,
                    required: true,
                    valueField: 'Key',
                    textField: 'Value',
                    panelHeight: '200', required: true,
                    onLoadSuccess: function() {
                        if (selectCustomer != undefined) {
                            $('#Txtcustomer').combobox('setText', selectCustomer);
                        }
                    },
                    onSelect: function(rowDate) {

                        $('#HiddenCustomerPKID').val(rowDate.value);
                        $('#HiddenCustomerName').val(rowDate.innerText);
                        Getcustomeruseinfo($('#HiddenCustomerPKID').val());
                        // document.getElementById("Button2").click();

                    },
                    onChange: function(newValue, oldValue) {



                    }
                });
            }
        });
    }
}
function Getcustomeruseinfo(CustomerPKID) {
    $.ajax({
        url: "FileShare.aspx/GetCustomerUseinfo",
        contentType: "application/json",
        type: "post",
        data: "{'CustomerPKID': '" + CustomerPKID + "'}",
        dataType: 'json',
        success: function(msg) {
            $('#Lbtongji').html(msg.d);
            if ((msg.d).indexOf('請刪除部份文件后再上傳') > -1) {
                $('#HidCanAdd').val("0");
                CanAdd = "0"
                document.getElementById("FileTab").style.display = "none";
            }
            else {
                document.getElementById("FileTab").style.display = "inline";
                $('#HidCanAdd').val("1");
                CanAdd = "1";

            }
        }
    });
}
function FileInit() {
    FileUrl = '../action/JqueryS.ashx?Method=GetFileInfo&PKID=' + $('#hidPKID').val();
    $('#Filetable').datagrid({
        url: FileUrl,
        toolbar: CanAdd == "1" ? "#FileButtons" : '#FileButtonsDoenload',
        columns: [[
                    { title: 'ff', field: 'ck1', checkbox: true },
                    { field: 'FileID', title: 'ID', hidden: true, width: 300 },
					{ field: 'FileName', title: '文件名稱', width: 300 },
					{ field: 'FileSize', title: '文件大小', width: 100 },
					{ field: 'Extend1', title: '上傳人', width: 250 },
					{ field: 'Extend2', title: '說明', width: 250 }
				]],
        onSelect: function(rowIndex) {

            $('#BtnFileDelete').linkbutton('enable');

        },
        onSelectAll: function() {
            $('#BtnFileDelete').linkbutton('enable');
        },
        onUnselectAll: function() {
            $('#BtnFileDelete').linkbutton('disable');
        }
    });
    if (CanAdd == "0") {
        $("#BtnFileAdd").linkbutton('disable');
        $("#FileInfo").css("display", "none");
    }
    else {
        $("#FileInfo").uploadify(
                        {
                            'uploader': '../NewScript/uploadScript/uploadify.swf',
                            'fileExt': '*',
                            'fileDesc': '請選擇上傳的文件',
                            'script': '../action/AjaxUploadHandler.ashx?PKID=' + $('#hidPKID').val(),
                            'scriptData': { 'ParentCategory': '3', 'ParentSubCategory': $('#HiddenCustomerPKID').val(), 'uploader': $('#Hidcuruser').val() },
                            'hideButton': true,
                            'buttonText': '',
                            'buttonImg': '../Images/selectFile.PNG',
                            'cancelImg': '../Images/Delete.gif',
                            'queueID': 'fileQueue',
                            'width': 120,
                            'height': 30,
                            'wmode': 'transparent',
                            'auto': false,
                            'multi': true,
                            'onSelect': function() {
                                $('#BtnFileUpload').linkbutton('enable');
                                $('#DivFileDesc').show();
                            },
                            'onComplete': function() {
                                $('#Filetable').datagrid('reload');
                            }
                        });
    }
}

function UploadFile() {

    $('#FileInfo').uploadifySettings('scriptData', { 'FileDesc': $('#TxtFileDesc').val() });
    $('#FileInfo').uploadifyUpload();
    $('#BtnFileUpload').linkbutton('disable');
    $('#TxtFileDesc').val("");
    $('#DivFileDesc').hide();
}
function DeleteFile() {
    var rows = $('#Filetable').datagrid('getSelections');
    if (rows) {
        $.messager.confirm('confirm', '確定要刪除選中的記錄嗎？', function(r) {
            if (r) {
                for (var i = 0; i < rows.length; i++) {
                    var index = $('#Filetable').datagrid('getRowIndex', rows[i]);
                    $('#Filetable').datagrid('deleteRow', index);
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json",
                        url: "AddFileShareDetail.aspx/DeleteFile",
                        data: "{'FileID':'" + rows[i].FileID + "'}",
                        dataType: 'json'
                    });
                }
                $('#BtnFileDelete').linkbutton('disable');

            }
        });
    }
}

function Download(id) {
    var rows;

    //清空之前的內容，防止干擾
    $('#HidFileID').val('');

    rows = $('#' + id).datagrid('getChecked');
    if (rows.length > 0) {
        $('#FileDialog').dialog('close');
        var index;
        if (rows.length == 1) {
            $('#HidFileID').val(rows[0].FileID);
            $('#HidFileName').val(rows[0].FileName);

            // $('#ImageTestDown').click();
            setTimeout('__doPostBack(\'ImageTestDown\',\'\')', 0);
        }
        else {
            for (index = 0; index < rows.length; index++) {
                if ($('#HidFileID').val() == '') {
                    $('#HidFileID').val(rows[index].FileID);
                }
                else {
                    $('#HidFileID').val($('#HidFileID').val() + ',' + rows[index].FileID);
                }

            }
            // $('#ImageTestDown').click();
            setTimeout('__doPostBack(\'ImageTestDown\',\'\')', 0);

        }
    }
    else {
        $.messager.alert('Warning', '請選擇要下載的文件！');
    }
}
function Saveinfo() {
    if ($("form").form("validate")) {

        var applyPKID = $("#hidPKID").val();
        if (applyPKID == "0") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "AddFileShareDetail.aspx/SaveInfo",
                data: "{'curAddFileShareInfo':{'CustomerName':'" + $('#HiddenCustomerName').val() + "','CustomerPKID':'" + $('#HiddenCustomerPKID').val() + "'}}",
                dataType: 'json',
                async: false,
                success: function(msg) {
                    $("#hidPKID").val(msg.d);

                }
            });
        }
    }
}
function confirmthis() {
    Saveinfo();
    $("#LbCustomerName").html($('#HiddenCustomerName').val());
    
    var classElements = [], allElements = document.getElementsByTagName('span');
    for (var i = 0; i < allElements.length; i++) {
        if (allElements[i].className == 'combo') {
            allElements[i].style.display = "none";

        }
    }
    document.getElementById("Txtcustomer").style.display = "none";
    document.getElementById("lbtishi").style.display = "none";
    document.getElementById("confthis").style.display = "none";
    
    FileInit();

}
 