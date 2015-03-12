<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SysManege_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>成都市水务局综合管理系统</title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/common.js"></script>
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
    <![endif]-->  
    <script>
        $(function () {
            /***索引样式***/
            $("#leftMenu p").click(function () {
                //$("#leftMenu p").removeClass("bg-primary");//改变背景色
                //$(this).addClass("bg-primary");//改变背景色
                $("#leftMenu p > span").remove();
                $(this).append("<span class='glyphicon glyphicon-hand-left text-primary'></span>");
            });

            /***默认加载第一个模块***/
            $("#leftMenu p:first()").click();
        });
        function MainFramCh(Url) {
            $(document).find("#mainFrame").attr("src", Url);
        }
    </script>
</head>
<body>
    <!-- 整体框架 -->
    <div class="easyui-layout" style="width: 100%; height: 655px; margin: 0 auto;">
        <!-- 左侧菜单 -->
        <div data-options="region:'west'" style="width: 150px;">
            <div id="leftMenu" class="easyui-accordion cursor" style="border: 1px">
                <div title="基础数据" style="padding: 10px;">
                    <%--<p onclick="MainFramCh('Main_Frame.aspx?action=usBaseList&sAc=<%=Server.UrlEncode("交办单位") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;交办单位&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=usBaseList&sAc=<%=Server.UrlEncode("承办单位") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;承办单位&emsp;</b></p>--%>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=usBaseList&sAc=<%=Server.UrlEncode("来文单位") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;来文单位&emsp;</b></p>
                    <%--<p onclick="MainFramCh('Main_Frame.aspx?action=usBaseList&sAc=<%=Server.UrlEncode("发文单位") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;发文单位&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=usBaseList&sAc=<%=Server.UrlEncode("信访问题分类") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;信访问题分类&emsp;</b></p>--%>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucStencilList&type=<%=Server.UrlEncode("办理意见") %>')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;办理意见模板&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucLingualList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;文种模板&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucMeet_RoomList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;会议室&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucRoll_NewsList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;滚动新闻&emsp;</b></p>
                </div>
                <div title="部门管理" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucDepartment')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;部门管理&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucUserInfoList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;人员管理&emsp;</b></p>
                </div>
                <div title="权限管理" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=usRightInfoList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;权限管理&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucRoleList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;角色管理&emsp;</b></p>
                </div>
                <div title="廉政风险" style="padding: 10px;">
                    <p onclick="MainFramCh('DutyResponsibility.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;岗位职责&emsp;</b></p>
                    <p onclick="MainFramCh('DutyRiskInfo.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;岗位风险&emsp;</b></p>
                    <p onclick="MainFramCh('RiskControl.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;风险防控&emsp;</b></p>   
                </div>
                <%--<div title="廉政教育" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucEduTaskList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;教育任务&emsp;</b></p>
                    <p onclick="MainFramCh('/Risk/DailyQuestion.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;每日一题统计&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucEduQuestionList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试题库&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucEduTestingList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试统计&emsp;</b></p>
                </div>--%>
                <div title="后台管理" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucMsgList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;公告消息&emsp;</b></p>
                    <p onclick="MainFramCh('/SysManege/DocumentQuery.aspx?pageState=document')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;公文查询&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucMeetingList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;会议通知&emsp;</b></p>
                    <p onclick="MainFramCh('/SysManege/ArchiveManage.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;公文管理&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucOnlineList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线用户&emsp;</b></p>
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucOperationLog')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;操作日志&emsp;</b></p>
                </div>
            </div>
        </div>
        <!-- 右侧内容 -->
        <div data-options="region:'center'" style="border: 1px; height: inherit; overflow-y: hidden;">
            <iframe id="mainFrame" name="mainFrame" title="content" style="height: inherit; width: 100%; border: 1px; overflow-y: hidden; "></iframe>
        </div>
    </div>
</body>
</html>