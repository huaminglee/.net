<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Risk_Index" %>

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
                <div title="风险统计" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucRiskStatistics')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;风险统计&emsp;</b></p>
                    
                </div> 
                 <div id="dajtj" visible ="false" runat="server" title="业务数据统计" style="padding: 10px;">
                    <p onclick="MainFramCh('Main_Frame.aspx?action=ucArchiveTongji')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;业务数据统计&emsp;</b></p>
                    
                </div>
                 <div id="div_edu_manager" title="廉政教育统计" style="padding: 10px;" runat="server">
                    
                    <p onclick="MainFramCh('DailyQuestion.aspx')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;每日一题统计&emsp;</b></p>
                    
                    <p onclick="MainFramCh('/SysManege/Main_Frame.aspx?action=ucEduTestingList')"><b><span class="glyphicon glyphicon-list-alt"></span>&emsp;在线考试统计&emsp;</b></p>
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
