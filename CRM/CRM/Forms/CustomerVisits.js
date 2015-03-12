$(function() {
    InitSampleInfo();
});
var IEwidth = $(window).width() < 1000 ? 980 : $(window).width() - 20;
var SampleEditIndex = -1;
var lastIndex = -1;
var mSamplerow = 0; //測試物品記錄總數
var curindex = 0;
var CanAdd = true;
document.onmousewheel = function(evt) {
    evt = evt ? evt : event;
    parent.iFrameHeight();
}
function InitSampleInfo() {
    var Columnstring = "[["
    Columnstring = Columnstring + "{title:'No',field:'SampleXH',width:50,formatter:function(value,row,index){return (index+1)}},"
    Columnstring = Columnstring + "{ field:'PKID',hidden:true},"
    Columnstring = Columnstring + "{ field:'Name',title:'姓名',width:'100',editor: { type: 'validatebox', options: {required: true} }},{field:'Contact',title:'聯繫方式',width:'200',editor:{type: 'validatebox',options: {required: true} }},"
    Columnstring = Columnstring + "{ field:'Post',title:'職務',width:'100',editor: { type: 'validatebox', options: {required: true} }},{field:'WorkContent',title:'工作執掌',width:'300',editor:{type: 'validatebox',options: {required: true} }},{field:'Remark',title:'備註',width:'300',editor:{type: 'validatebox',options: {required: true} }}"


    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    SampleInfo(Columnstring);
}

function SampleInfo(FieldInfo) {//綁定樣品信息
    var Toolbar = "";
    CanAdd = $('#HiddenCanAdd').val() == "True";
    if (CanAdd) { Toolbar = "#SampleButtons" }
    $('#SampleTable').datagrid({
        width: IEwidth,
        height: 'auto',
        toolTip: CanAdd ? '雙擊進行編輯' : "",
        toolbar: Toolbar,
        url: $('#HiddenPKID').val() != "0" ? '../action/JqueryS.ashx?Method=VisitsInfo&PKID=' + $('#HiddenPKID').val() : "",
        columns: FieldInfo,
        onSelect: function(rowIndex) {
            if (lastIndex != rowIndex) {
                $('#btnDelete').linkbutton('enable');
            }
        },
        onLoadSuccess: function(dateInfo) {
            mSamplerow = dateInfo.rows.length;
        },
        onDblClickRow: function(rowIndex, row) {

        if (lastIndex != rowIndex && CanAdd) {
                if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
                    $('#SampleTable').datagrid('endEdit', lastIndex);

                    $('#SampleTable').datagrid('beginEdit', rowIndex);
                    $('#btnSave').linkbutton('enable');
                    $('#btnCancel').linkbutton('enable');

                    SaveSample(1);
                }
            }
            lastIndex = rowIndex;
        },
        detailFormatter: function(index, row) {
            return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>';
        }

    });
}
function AddSample() {//添加樣品信息,首先保存申請單信息
    //    document.getElementById('LinkGetPDF').style.display = "inline";
    var SampleIndex = $('#SampleTable').datagrid('getRows').length;
    for (var index = 0; index < SampleIndex; index++) {
        $('#SampleTable').datagrid('collapseRow', index);
        IsExpand = false;
    }
    var Result = $("form").form("validate");
    if (Result) {
        var applyPKID = $("#HiddenPKID").val();
        if (applyPKID == "0") {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "CustomerVisitDetail.aspx/SaveCustomerVisitsInfo",
                data: "{'mVisitsinfo':{'CustomerPKID':'" + $('#HiddenCustomerPKID').val() + "','CustomerName':'" + $('#TxtCustomerName').val() + "','CustomerName':'" + $('#HiddenCustomerName').val() + "'}}",
                dataType: 'json',
                success: function(msg) {
                    $("#HiddenPKID").val(msg.d);
                    parent.iFrameHeight();
                }
            });
        }

        if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
            $('#SampleTable').datagrid('endEdit', lastIndex);
            $('#SampleTable').datagrid('insertRow', { index: SampleIndex,
                row: {
                    PKID: 0,
                    numbers: 1

                }
            });

            $('#btnSave').linkbutton('enable');
            $('#btnDelete').linkbutton('enable');
            $('#SampleTable').datagrid('beginEdit', SampleIndex);
            lastIndex = SampleIndex;

        }
    }
}


function DeleteSample() {//刪除樣品信息
    //        debugger;
    if (lastIndex > -1) {

        $('#SampleTable').datagrid('deleteRow', lastIndex);
        lastIndex = -1;
        $('#btnDelete').linkbutton('disable');
        $('#btnSave').linkbutton('disable');
        return;
    }
    var row = $('#SampleTable').datagrid('getSelected');
    if (row) {
        $.messager.confirm('confirm', '確定要刪除選中的記錄嗎？', function(r) {
            if (r) {
                //                debugger;
                var index = $('#SampleTable').datagrid('getRowIndex', row);
                $('#SampleTable').datagrid('deleteRow', index);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "CustomerVisitDetail.aspx/DeletePerson",
                    data: "{'PersonPKID':'" + row.PKID + "'}",
                    dataType: 'json'
                });

                var subRow = 0;
                try {
                    subRow = $('#ddv-' + index).datagrid('getRows').length;
                }
                catch (e) {
                    subRow = 0;
                }
                if (subRow > 0) {
                    TestItemRow = TestItemRow - 1;
                }

                $('#SampleTable').datagrid('reload');
                IsExpand = true;
                $('#btnDelete').linkbutton('disable');
                lastIndex = -1;
            }
        });
    }
}
function SaveSample(IsUpdate) {//保存樣品信息
    if ($('#SampleTable').datagrid('validateRow', lastIndex)) {
        $('#SampleTable').datagrid('endEdit', lastIndex);
        var rows = $('#SampleTable').datagrid('getChanges');
        if (rows.length > 0) {
            var isReload = false;
            for (var i = 0; i < rows.length; i++) {
                var DataParam = "{'mPersonInfo':{'PKID':'" + rows[i].PKID + "','CustomerVisitsPKID':'" + $('#HiddenPKID').val()
                    + "','Name':'" + rows[i].Name + "','Post':'" + rows[i].Post + "','WorkContent':'" + rows[i].WorkContent + "','Remark':'" + rows[i].Remark

                    + "','Contact':'" + rows[i].Contact + "' }}",
                 DataParam = DataParam.replace(/undefined/g, '0');
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    async: false,
                    url: "CustomerVisitDetail.aspx/SavePersonInfo",
                    data: DataParam,
                    dataType: 'json', success: function(msg) {
                        if (IsUpdate == 0) {
                            if (mSamplerow > 0) {
                                if (rows[i].PKID == 0) {
                                    rows[i].PKID = msg.d;
                                    var refreshIndex = $('#SampleTable').datagrid('getRowIndex', rows[i])
                                    $('#SampleTable').datagrid('refreshRow', refreshIndex);
                                }
                            }
                        }
                    }
                });
            }
            if (IsUpdate == 0) {

                if (mSamplerow == 0) {
                    $("#SampleTable").datagrid('options').url = '../action/JqueryS.ashx?Method=VisitsInfo&PKID=' + $('#HiddenPKID').val();
                    
                    $('#SampleTable').datagrid('reload');
                }

                mSamplerow = $('#SampleTable').datagrid('getRows').length;
                $('#btnSave').linkbutton('disable');
                $('#btnCancel').linkbutton('disable');


            }
            $('#SampleTable').datagrid('acceptChanges');

            //  SaveUpdateAndCaluteteExpense();
            $('#btnSave').linkbutton('disable');
            $('#btnCancel').linkbutton('disable');
        }
        curindex = lastIndex;
        if (curindex == 0) {
            canexpen = 1;
        }
        lastIndex = -1;
        $('#btnAdd').linkbutton('enable');
    
    }

    // $('#SampleTable').datagrid('expandRow', curindex);
    // document.getElementById ('afaddsample').click();
}
