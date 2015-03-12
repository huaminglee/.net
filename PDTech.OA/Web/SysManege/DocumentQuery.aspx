<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentQuery.aspx.cs" Inherits="SysManege_DocumentQuery" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>公文查询</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
        <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <section class="container">
        <div class="container-fluid">
            <fieldset>
                <legend><small class="text-primary">公文查询</small></legend>
                <!-- 查询条件 -->
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_title" class="input-group-addon">公文标题</label>
                            <input type="text" class="form-control" id="txt_title">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_fileNum" class="input-group-addon">文件编号</label>
                            <input type="text" class="form-control" id="txt_fileNum">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_startTime" class="input-group-addon">开始时间</label>
                            <input type="text" class="form-control" id="txt_startTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_endTime" class="input-group-addon">结束时间</label>
                            <input type="text" class="form-control" id="txt_endTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>  
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="deptList" class="input-group-addon">部门</label>
                            <select id="deptList" class="easyui-combobox" style="width:150px;height:35px;">
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="dplUserList" class="input-group-addon">人员</label>
                            <select id="dplUserList" class="easyui-combobox" style="width:150px;height:35px;">
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="company" class="input-group-addon">公文类型</label>
                            <select class="easyui-combobox" id="archiveType" style="width:150px;height:35px;">
                                <option value="0">全部</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-1">
                        <button type="button" class="btn btn-primary" id="btn_query">查&ensp;询</button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-condensed table-bordered cursor">
                                <thead>
                                    <tr>
                                        <th>序号</th>
                                        <th>公文标题</th>
                                        <th>公文类型</th>
                                        <th>紧急程度</th>
                                        <th>创建时间</th>
                                        <th>附件</th>
                                        <th>发送人</th>
                                        <th>当前步骤</th>
                                    </tr>
                                </thead>
                                <tbody id="tb_document"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- 分页 -->
                <div class="row">
                    <div class="col-xs-12 text-center">
                           <div id="pagination" class="easyui-pagination" data-options="
                            total:0,
                            pageSize:10,
                            layout:['first','prev','sep','links','sep','next','last','manual'],
                            beforePageText:'转到',
                            afterPageText:'页',
                            displayMsg:' 共 {total} 条记录，当前显示 {from} 到 {to}条'
                            "></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </section>

    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, str = "", strTable = "", strOption = "<option value='0'>全部</option>", $archiveType = $("#archiveType"), pageSize = 10, currentPage = 1, totalNum;
        $(function () {
            /***加载公文类型***/
            //$.get("/Ajax/PublicQuery.ashx", { pageState: "archiveTypeOption" },
            //  function (data) {
            //      obj = $.parseJSON(data);
            //      $.each(obj, function (i) {
            //          //组织字符串效率高于遍历append
            //          strOption += "<option value='" + obj[i].archive_type + "'>" + obj[i].type_name + "</option>";
            //      });
            //      $archiveType.html(strOption);
            //      strOption = "<option value='0'>全部</option>";
            //  });
            $('#archiveType').combobox({
                url: '/Ajax/PublicQuery.ashx?pageState=archiveTypeOption',
                valueField: 'archive_type',
                textField: 'type_name',
            });

            $('#deptList').combobox({
                url: '/Risk/UserControls/Ajax.aspx?queryState=dept',
                valueField: '_department_id',
                textField: '_department_name',
                //panelHeight: 'auto',
                onSelect: function () {
                    $("#dplUserList").combobox('clear');
                    if ($('#deptList').combobox('getValue') != 0) {
                        $('#dplUserList').combobox({
                            url: '/Risk/UserControls/Ajax.aspx?queryState=user&queryId=' + $('#deptList').combobox('getValue'),
                            valueField: '_user_id',
                            textField: '_full_name',
                            panelHeight: 'auto'
                        });
                        $('#dplUserList').combobox('setValue', '0');
                    }
                }
            });

            str = getQueryString("txt_query");//获取Get值
            /***点击首页查询跳转至本页***/
            if (str != "" && str != null) {
                $.get("/Ajax/PublicQuery.ashx", { pageState: "document", txt_query: str, pageSize: pageSize },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      if (totalNum > 0) {
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'><td>" + obj[i].sort_rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 10) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].pri_level + "</td><td>" + obj[i].create_time + "</td><td>" + (obj[i].attachment_count != "0" ? "<span class='glyphicon glyphicon-paperclip'></span>" : "") + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].current_step_id + "</td></tr>";
                          });  
                      }
                      $("#tb_document").html(strTable);
                      strTable = "";
                      pagination();//分页
                      str = "";//清空首页跳转本页面传递的查询条件，防止后面追加
                  });
            }
                /***页面正常加载***/
            else {
                $.get("/Ajax/PublicQuery.ashx", { pageState: "document", pageSize: pageSize },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      if (totalNum > 0) {
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'><td>" + obj[i].sort_rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 10) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].pri_level + "</td><td>" + obj[i].create_time + "</td><td>" + (obj[i].attachment_count != "0" ? "<span class='glyphicon glyphicon-paperclip'></span>" : "") + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].current_step_id + "</td></tr>";
                          });  
                      }
                      $("#tb_document").html(strTable);
                      strTable = "";
                      pagination();//分页
                  });
            }

            /***查询***/
            $("#btn_query").click(function () {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "document",
                    txt_title: $.trim($("#txt_title").val()),
                    txt_fileNum: $.trim($("#txt_fileNum").val()),
                    txt_startTime: $("#txt_startTime").val(),
                    txt_endTime: $("#txt_endTime").val(),
                    deptname: $('#deptList').combobox('getValue'),
                    username: $('#dplUserList').combobox('getValue'),
                    archiveType: $("#archiveType").combobox('getValue'),   //$("#archiveType").find("option:selected").val(),
                    pageSize: pageSize
                },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      if (totalNum > 0) {
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'><td>" + obj[i].sort_rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 10) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].pri_level + "</td><td>" + obj[i].create_time + "</td><td>" + (obj[i].attachment_count != "0" ? "<span class='glyphicon glyphicon-paperclip'></span>" : "") + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].current_step_id + "</td></tr>";
                          });
                      }
                      $("#tb_document").html(strTable);
                      strTable = "";
                      pagination();//分页
                  });
            });
        });

        /***分页***/
        function pagination() {
            $("#pagination").pagination({
                total: totalNum,
                pageSize: 10,
                pageNumber: 1,//初始化当前页
                //点击分页按钮触发
                onSelectPage: function (page, pageSize) {
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "document",
                        txt_query: str,
                        txt_title: $.trim($("#txt_title").val()),
                        txt_fileNum: $.trim($("#txt_fileNum").val()),
                        txt_startTime: $("#txt_startTime").val(),
                        txt_endTime: $("#txt_endTime").val(),
                        deptname: $('#deptList').combobox('getValue'),
                        username: $('#dplUserList').combobox('getValue'),
                        archiveType: $("#archiveType").combobox('getValue'), //$("#archiveType").find("option:selected").val(),
                        currentPage: page,//当前页码
                        pageSize: pageSize//每页显示数量（全局变量）
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'><td>" + obj[i].sort_rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 10) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].pri_level + "</td><td>" + obj[i].create_time + "</td><td>" + (obj[i].attachment_count != "0" ? "<span class='glyphicon glyphicon-paperclip'></span>" : "") + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].current_step_id + "</td></tr>";
                          });
                          $("#tb_document").html(strTable);
                          strTable = "";
                      });
                    return true;//必写！否则点击下一页时无效！
                }
            });
        }

        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function showDetail(archive_id, archive_type) {
            var src;
            /***公文查询***/
            switch (archive_type) {
                case 10:
                    src = "/Archive/sel_Generalpieces.aspx?arid=" + archive_id + "";
                    break;
                case 11:
                    src = "/Archive/sel_Ordinarypieces.aspx?arid=" + archive_id + "";
                    break;
                case 12:
                    src = "/Archive/sel_UnitDoc.aspx?arid=" + archive_id + "";
                    break;
                case 20: case 21: case 22: case 23:
                    src = "/Archive/sel_supInfo.aspx?arid=" + archive_id + "";
                    break;
                case 24:
                    src = "/Admin/sel_Proposal.aspx?arid=" + archive_id + "";
                    break;
                case 32:
                    src = "/Admin/sel_Personnal.aspx?arid=" + archive_id + "";
                    break;
                case 33:
                    src = "/Admin/selFinance.aspx?arid=" + archive_id + "";
                    break;
                case 40: case 41: case 42: case 43: case 44:
                    src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                    break;
                case 51:
                    src = "/Risk/sel_risk.aspx?arid=" + archive_id + "";
                    break;
                case 61: case 62:
                    src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                    break;
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '520px'],
                offset: ['20px', ''],
                iframe: { src: src }
            });
        }

        //获取参数值方法
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return r[2];//因IIS有自动解码功能，所以此处忽略解码，如有需要可改动decodeURI(r[2])。
            return null;
        }

        /***弹出iframe的关闭空方法***/
        function doRefresh() { }
    </script>
</body>
</html>
