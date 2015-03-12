$(function() {
    CanAdd = $('#HidCanAdd').val();
    FileInit();


});
var CanAdd = "0";
var CustomerData;
var IEwidth = $(window).width() < 1000 ? 980 : $(window).width() - 20;
function FileInit() {
    FileUrl = '../action/JqueryS.ashx?Method=GetreportInfo&PKID=' + $('#HiddenQuotationPKID').val();
    $('#Filetable').datagrid({
        width: IEwidth*0.98,
        url: FileUrl,
        toolbar: CanAdd == "1" ? "#FileButtons" : '#FileButtonsDoenload',
        columns: [[
                    { title: 'ff', field: 'ck1', checkbox: true },
                    { field: 'FileID', title: 'ID', hidden: true },
					{ field: 'FileName', title: '文件名稱', width: 200 },
					{ field: 'FileSize', title: '文件大小', width: 100 },
					{ field: 'Extend2', title: '上傳人', width: 100 },
					{ field: 'Extend1', title: '說明', width: 250 }
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
                            'script': '../action/AjaxUploadHandler.ashx?PKID=' + $('#HiddenQuotationPKID').val(),
                            'scriptData': { 'ParentCategory': '2', 'ParentSubCategory': '2', 'uploader': $('#Hidcuruser').val() },
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
                        url: "../Quotation/ReportDetailDetail.aspx/DeleteFile",
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
    document.getElementById("Txtcustomer").style.display = "none";
    FileInit();

}
document.onmousewheel = function(evt) {
    evt = evt ? evt : event;
    parent.iFrameHeight();
}