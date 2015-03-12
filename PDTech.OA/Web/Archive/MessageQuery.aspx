<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageQuery.aspx.cs" Inherits="Archive_MessageQuery" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>公告查询</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <%--<link href="/easyui/1.3.6//default/easyui.css" rel="stylesheet" />--%>
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
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
                <legend><small class="text-primary">公告查询</small></legend>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_title" class="input-group-addon">公告标题</label>
                            <input type="text" class="form-control" id="txt_title">
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <label for="txt_startTime" class="input-group-addon">开始</label>
                            <input type="text" class="form-control" id="txt_startTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <label for="txt_endTime" class="input-group-addon">结束</label>
                            <input type="text" class="form-control" id="txt_endTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>
                    <div class="col-sm-5">
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
                                        <th>公告标题</th>
                                        <th>阅读状态</th>
                                        <th>发送时间</th>
                                    </tr>
                                </thead>
                                <tbody id="tb_message"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!--分页-->
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
        var obj, strTable = "", pageSize = 10, currentPage = 1, totalNum;
        $(function () {
            $.get("/Ajax/PublicQuery.ashx", { pageState: "message", pageSize: pageSize },
              function (data) {
                  objTemp = $.parseJSON(data);//转换出总条数
                  totalNum = objTemp.TotalNum;//总条数
                  if (totalNum > 0) {
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      $.each(obj, function (i) {
                          strTable += "<tr onclick='showDetail(" + obj[i].message_id + ");'><td>" + obj[i].rowno + "</td><td title='" + obj[i].message_title + "'>" + obj[i].message_title.substring(0, 20) + "</td><td>" + obj[i].read_status + "</td><td>" + obj[i].message_send_time + "</td></tr>";
                      });
                      $("#tb_message").html(strTable);
                      strTable = "";
                      pagination();//分页
                  }
                  else {
                      $("#tb_message").html(strTable);
                  }
              });

            /***查询***/
            $("#btn_query").click(function () {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "message",
                    txt_title: $.trim($("#txt_title").val()),
                    txt_startTime: $.trim($("#txt_startTime").val()),
                    txt_endTime: $.trim($("#txt_endTime").val()),
                    pageSize: pageSize
                },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      if (totalNum > 0) {
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].message_id + ");'><td>" + obj[i].rowno + "</td><td title='" + obj[i].message_title + "'>" + obj[i].message_title.substring(0, 20) + "</td><td>" + obj[i].read_status + "</td><td>" + obj[i].message_send_time + "</td></tr>";
                          });
                          $("#tb_message").html(strTable);
                          strTable = "";
                          pagination();//分页
                      }
                      else {
                          $("#tb_message").html(strTable);
                      }
                  });
            });
        });

        /***分页***/
        function pagination() {
            //totalNum = (totalNum % pageSize) == 0 ? (totalNum / pageSize) : Math.floor((totalNum / pageSize + 1));
            $("#pagination").pagination({
                total: totalNum,
                pageSize : 10,
                pageNumber: 1,//初始化当前页
                //点击分页按钮触发
                onSelectPage: function (page, pageSize) {
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "message",
                        txt_title: $.trim($("#txt_title").val()),
                        txt_startTime: $.trim($("#txt_startTime").val()),
                        txt_endTime: $.trim($("#txt_endTime").val()),
                        currentPage: page,//当前页码
                        pageSize: pageSize//每页显示数量（全局变量）
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              strTable += "<tr onclick='showDetail(" + obj[i].message_id + ");'><td>" + obj[i].rowno + "</td><td title='" + obj[i].message_title + "'>" + obj[i].message_title.substring(0, 20) + "</td><td>" + obj[i].read_status + "</td><td>" + obj[i].message_send_time + "</td></tr>";
                          });
                          $("#tb_message").html(strTable);
                          strTable = "";
                      });
                    return true;//必写！否则点击下一页时无效！
                }
            });
        }

        /***公告消息查看详细***/
        function showDetail(message_id) {
            $.layer({
                type: 2,
                title: "公告消息",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '520px'],
                offset: ['20px', ''],
                iframe: { src: '/Archive/msgInfo.aspx?mid=' + message_id + '' }
            });
        }

        /***弹出iframe的关闭空方法***/
        function doRefresh() {
            $("#btn_query").click();//刷新数据状态
        }
    </script>
</body>
</html>