<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="IncorruptEdu_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>成都市水务局综合管理系统</title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
    <![endif]-->
</head>
<body>
    <!-- 整体框架 -->
    <div class="easyui-layout" style="width: 100%; height: 655px; margin: 0 auto;">
        <!-- 左侧菜单 -->
        <div data-options="region:'west'" style="width: 150px;">
            <div id="leftMenu" class="easyui-accordion cursor" style="border: 1px">
                <div title="廉政教育" style="padding: 10px;">
                    <p onclick="MainFramCh('/IncorruptEdu/EduTaskList.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;我的教育任务&emsp;</b></p>
                    <p onclick="MainFramCh('/IncorruptEdu/EdayQuestionList.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;我的每日一题&emsp;</b></p>
                    <p onclick="MainFramCh('/IncorruptEdu/EdayQuestionundoList.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;补做每日一题&emsp;</b></p>
                    <p onclick="MainFramCh('/IncorruptEdu/EduTestList.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;我的在线考试&emsp;</b></p>
                    <p onclick="MainFramCh('/IncorruptEdu/TestOnlineResultList.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;我的考试情况&emsp;</b></p>
                    <p onclick="MainFramCh('/SysManege/Main_Frame.aspx?action=ucEduQuestionListsel')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试题库&emsp;</b></p>
                </div>
                <div id="div_edu_manager" title="廉政教育管理" style="padding: 10px;" runat="server">
                    <p onclick="MainFramCh('/SysManege/Main_Frame.aspx?action=ucEduTaskList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;教育任务列表&emsp;</b></p>
                    <p onclick="MainFramCh('/Monitor/DailyQuestion.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;所有每日一题&emsp;</b></p>
                    <p onclick="MainFramCh('/SysManege/Main_Frame.aspx?action=ucEduQuestionList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试题库&emsp;</b></p>
                    <p onclick="MainFramCh('/SysManege/Main_Frame.aspx?action=ucEduTestingList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试列表&emsp;</b></p>
                </div>
            </div>
        </div>
        <!-- 右侧内容 -->
         <div data-options="region:'center'" style="border: 1px; height: inherit; overflow-y: hidden;">
            <iframe id="mainFrame" name="mainFrame" title="content" style="height: inherit; width: 100%; border: 1px; overflow-y: hidden;"></iframe>
        </div>

    </div>
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/common.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script type="text/javascript">
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
</body>
</html>
