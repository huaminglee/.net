
var parentwin = window.parent;
var rightiframe = parentwin.document.getElementById("rightiframe");
var windowwidth = rightiframe.width - 50;
var windowheigth = rightiframe.height - 50;
var curtype = $('#HiddenCurType').val();
function initgrid() {

    var Columnstring = "[["
    Columnstring = Columnstring + "{ field:'IsFinish',title:'結案狀態',formatter:function(value,rec){return value==1?'已結案':'未結案';}},"
    Columnstring = Columnstring + "{ field: 'Nums',width:300, title: '數量' }"
    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    $('#asgridview').datagrid({
        width: windowwidth,
        height: windowheigth,
        view: detailview,
        checkOnSelect: false,
        singleSelect: true,
        url: '../action/JqueryS.ashx?Method=GetZT',
        columns: Columnstring,
        onResize: function() {
            $('#asgridview').datagrid('fixRowHeight');

        },
        detailFormatter: function(index, row) {
            return '<div style="padding:2px"><table id="ddvzt-' + index + '"></table></div>';
        },
        onLoadSuccess: function(dateInfo) {
            servicelength = dateInfo.rows.length;
            for (var index = 0; index < dateInfo.rows.length; index++) {
                $('#asgridview').datagrid('collapseRow', index);
                IsExpand = false;
            }

        },
        onExpandRow: function(index, row) {
            GetDept('#ddvzt-' + index, index, row.IsFinish, 0);

        }

    });
}
function GetDept(tableID, index, IsFinish, ExistRow) {
    var fatherindex = index;
    var Columnstring = "[["
    Columnstring = Columnstring + "{title:'No',field:'fileXH',width:50,formatter:function(value,row,index){return (index+1)}},"
    Columnstring = Columnstring + "{ field:'ApplyDept',title:'實驗室' },"
    Columnstring = Columnstring + "{ field: 'Nums',width:300, title: '數量' }"
    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    $(tableID).datagrid({
        width: windowwidth - 100,
        height: "auto",
        view: detailview,
        checkOnSelect: false,
        singleSelect: true,
        url: '../action/JqueryS.ashx?Method=GetDeptByZT&IsFinished=' + IsFinish + '&RecordType=' + $('#HiddenCurType').val() + '',
        columns: Columnstring,
        detailFormatter: function(index, row) {
            return '<div style="padding:2px"><table id="ddvdept-' + fatherindex + '-' + index + '"></table></div>';
        },
        onResize: function() {
            $('#asgridview').datagrid('fixRowHeight');
            $('#asgridview').datagrid('fixDetailRowHeight', index);

        },
        onLoadSuccess: function(dateInfo) {
            servicelength = dateInfo.rows.length;
            for (var index = 0; index < dateInfo.rows.length; index++) {
                $(tableID).datagrid('collapseRow', index);
                IsExpand = false;
            }
            setTimeout(function() {
                $('#asgridview').datagrid('fixRowHeight');
                $('#asgridview').datagrid('fixDetailRowHeight', index);
            }, 0);
        },

        onExpandRow: function(index, row) {
            GetFile('#ddvdept-' + fatherindex + '-' + index, fatherindex, index, IsFinish, row.ApplyDept, tableID, 0);
            $(tableID).datagrid('fixRowHeight');
            $(tableID).datagrid('fixDetailRowHeight', index);
        }

    });
}
function GetFile(tableID, fatherindex, index, IsFinish, ApplyDept, fathertable, ExistRow) {
    var Columnstring = "[["
    Columnstring = Columnstring + "{ field:'PKID',hidden:true},"
    Columnstring = Columnstring + "{ field:'eFlowDocID',hidden:true},"
    Columnstring = Columnstring + "{ field:'FileName',title:'文件名' },"
    Columnstring = Columnstring + "{ field: 'FileBH', title: '文件號碼' },"
    Columnstring = Columnstring + "{ field: 'RecordNO', title: '變更號碼' },"
    Columnstring = Columnstring + "{ field: 'FileVersion', title: 'REV' },"
    Columnstring = Columnstring + "{ field: 'ToTalPage', title: '頁數' },"
    Columnstring = Columnstring + "{ field: 'EffectDate', title: '生效時間' }"
    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    $(tableID).datagrid({
        nowrap: true,
        rownumbers: true,
        idfield: 'PKID',
        width: windowwidth - 300,
        height: 'auto',
        checkOnSelect: false,
        singleSelect: true,
        loadMsg: '文件載入中，請稍後……',
        url: '../action/JqueryS.ashx?Method=GetFileByApplydeptandType&Type=' + $('#HiddenCurType').val() + '&applydepts=' + encodeURI(ApplyDept) + '&IsFinished=' + IsFinish + '',
        columns: Columnstring,
        onResize: function() {
            $(fathertable).datagrid('fixRowHeight');
            $(fathertable).datagrid('fixDetailRowHeight', index);
            $('#asgridview').datagrid('fixRowHeight');
            $('#asgridview').datagrid('fixDetailRowHeight', fatherindex);

        },
        onLoadSuccess: function(dateInfo) {
            setTimeout(function() {
                $(fathertable).datagrid('fixRowHeight');
                $(fathertable).datagrid('fixDetailRowHeight', index);
                $('#asgridview').datagrid('fixRowHeight');
                $('#asgridview').datagrid('fixDetailRowHeight', fatherindex);
            }, 0);
        },
        onDblClickRow: function(subIndex, row) {
            window.location.href = '../Forms/AddQCFileDetail.aspx?pkid=' + row.PKID + '&eFlowDocID=' + row.eFlowDocID + '&Type=' + $('#HiddenCurType').val();
        }

    });
}
function BindDepts(imageid, rowindex, isfi) {
    $('#Hiddencurrowindex').val(rowindex);
    $('#Hiddencurrowisfi').val(isfi);
    document.getElementById("Button3").click();
}

function ztchangeshow(childid,  rowindex) {
    if (document.getElementById(childid).style.display == "none") {
        document.getElementById("Hiddencursetcssdeptindex").value = rowindex;
        document.getElementById("BtnSetCSSshow").click();
    }
    else {
        document.getElementById("Hiddencursetcssdeptindex").value = rowindex;
        document.getElementById("BtnSetCSShidd").click();
    }
}
function BindFile(imageid, deptname, rowindex, isfini, buttonid) {
    $('#HiddenDeptRowindex').val(rowindex);
    $('#HiddenDeptIsfini').val(isfini);
    document.getElementById(buttonid).click();
}
function deptchangeshow(fatherindex, index, childid) {
    document.getElementById("Hiddenparenetindex").value = fatherindex;
    if (document.getElementById(childid).style.display == "none") {
        document .getElementById ("Hiddencursetcssfileindex").value=index;
        document.getElementById("BtnSetFileCssShow").click();
    }
    else {
        document.getElementById("Hiddencursetcssfileindex").value = index;
        document.getElementById("BtnSetFileCSSHid").click();
    }
}

