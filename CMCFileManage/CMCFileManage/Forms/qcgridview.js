$(function() {

  //  initgrid();
});
var parentwin = window.parent;
var rightiframe = parentwin.document.getElementById("rightiframe");
var windowwidth = rightiframe.width-50;
var windowheigth = rightiframe.height-50;

function initgrid() {
    var curtype = $('#HiddenCurType').val();
    if (curtype == 0) //一階二階文件
    {
        var Columnstring = "[["
        Columnstring = Columnstring + "{title:'No',field:'SampleXH',width:50,formatter:function(value,row,index){return (index+1)}},"
        Columnstring = Columnstring + "{ field:'LbServicePKID',title:'服務類別PKID',hidden:true},"
        Columnstring = Columnstring + "{ field: 'LbServiceName',width:300, title: '服務類別' }"
        Columnstring = Columnstring + ']]';
        Columnstring = eval(Columnstring);
    }
    else if (curtype == 1) //三階文件
    {
        var Columnstring = "[["
        Columnstring = Columnstring + "{title:'No',field:'fileXH',width:50,formatter:function(value,row,index){return (index+1)}},"
        Columnstring = Columnstring + "{ field:'ApplyDept',title:'實驗室' },"
        Columnstring = Columnstring + "{ field: 'Nums',width:300, title: '數量' }"
        Columnstring = Columnstring + ']]';
        Columnstring = eval(Columnstring);
        $('#asgridview').datagrid({
            width: windowwidth,
            height: windowheigth,
            view: detailview,
            checkOnSelect: false,
            singleSelect: true,
            url: '../action/JqueryS.ashx?Method=GetApplydeptByfilelayer&filelayer=' + $('#HiddenCurType').val() + '',
            columns: Columnstring,
            onResize: function() {
                $('#asgridview').datagrid('fixRowHeight');

            },
            detailFormatter: function(index, row) {
                return '<div style="padding:2px"><table id="ddvdept-' + index + '"></table></div>';
            },
            onLoadSuccess: function(dateInfo) {
                servicelength = dateInfo.rows.length;
                for (var index = 0; index < dateInfo.rows.length; index++) {
                    $('#asgridview').datagrid('collapseRow', index);
                    IsExpand = false;
                }

            },
            onExpandRow: function(index, row) {
                GetFilecategory('#ddvdept-' + index, index, row.ApplyDept, 0);

            }

        });
    }
    else if (curtype == 2) {   //四階文件
        var Columnstring = "[["
        Columnstring = Columnstring + "{title:'No',field:'fileXH',width:50,formatter:function(value,row,index){return (index+1)}},"
        Columnstring = Columnstring + "{ field:'ApplyDept',title:'實驗室' },"
        Columnstring = Columnstring + "{ field: 'Nums',width:300, title: '數量' }"
        Columnstring = Columnstring + ']]';
        Columnstring = eval(Columnstring);
        $('#asgridview').datagrid({
            width: windowwidth,
            height: windowheigth,
            view: detailview,
            checkOnSelect: false,
            singleSelect: true,
            url: '../action/JqueryS.ashx?Method=GetApplydeptByfilelayer&filelayer=' + $('#HiddenCurType').val() + '',
            columns: Columnstring,
            onResize: function() {
                $('#asgridview').datagrid('fixRowHeight');

            },
            detailFormatter: function(index, row) {
                return '<div style="padding:2px"><table id="ddvdept-' + index + '"></table></div>';
            },
            onLoadSuccess: function(dateInfo) {
                servicelength = dateInfo.rows.length;
                for (var index = 0; index < dateInfo.rows.length; index++) {
                    $('#asgridview').datagrid('collapseRow', index);
                    IsExpand = false;
                }

            },
            onExpandRow: function(index, row) {
                GetFourFile('#ddvdept-' + index, index, row.ApplyDept, 0);

            }

        });
    }

}
function GetFilecategory(tableID, index, ApplyDept, ExistRow) {
    var fatherindex = index;
    var Columnstring = "[["
    Columnstring = Columnstring + "{title:'No',field:'fileXH',width:50,formatter:function(value,row,index){return (index+1)}},"
    Columnstring = Columnstring + "{ field:'FileCategory',title:'文件類別' },"
    Columnstring = Columnstring + "{ field: 'Nums',width:300, title: '數量' }"
    Columnstring = Columnstring + ']]';
    Columnstring = eval(Columnstring);
    $(tableID).datagrid({
        width: windowwidth - 100,
        height: "auto",
        view: detailview,
        checkOnSelect: false,
        singleSelect: true,
        url: '../action/JqueryS.ashx?Method=GetFilecategoryByapplydepts&applydepts=' + encodeURI(ApplyDept) + '',
        columns: Columnstring,
        detailFormatter: function(index, row) {
            return '<div style="padding:2px"><table id="ddvcategory-' + fatherindex + '-' + index + '"></table></div>';
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
            GetFile('#ddvcategory-' + fatherindex + '-' + index, fatherindex, index, row.FileCategory, ApplyDept, tableID, 0);
            $(tableID).datagrid('fixRowHeight');
            $(tableID).datagrid('fixDetailRowHeight', index);
        }

    });
}
function GetFile(tableID, fatherindex, index, FileCategory, applydepts, fathertable, ExistRow) {
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
        url: '../action/JqueryS.ashx?Method=GetFilebyfilelayerandfilecategory&filecategore=' + encodeURI(FileCategory) + '&applydepts=' + encodeURI(applydepts) + '',
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
            window.location.href = '../Forms/QCFileDetail.aspx?pkid=' + row.PKID + '&eFlowDocID=' + row.eFlowDocID + '&Type=' + $('#HiddenCurType').val();
        }

    });
}
var IsExpand = false;
function GetFourFile(tableID, index, ApplyDept, ExistRow) {
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
        url: '../action/JqueryS.ashx?Method=GetFourFileByApplyDept&applydepts=' + encodeURI(ApplyDept) + '',
        columns: Columnstring,
        onResize: function() {
          
            $('#asgridview').datagrid('fixRowHeight');
            $('#asgridview').datagrid('fixDetailRowHeight', index);

        },
        onLoadSuccess: function(dateInfo) {
            setTimeout(function() {
              
                $('#asgridview').datagrid('fixRowHeight');
                $('#asgridview').datagrid('fixDetailRowHeight', index);
            }, 0);
        },
        onDblClickRow: function(subIndex, row) {
            window.location.href = '../Forms/QCFileDetail.aspx?pkid=' + row.PKID + '&eFlowDocID=' + row.eFlowDocID + '&Type=' + $('#HiddenCurType').val();
        }

    });

}
