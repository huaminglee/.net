<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageAndMeeting2.aspx.cs" Inherits="Archive_MessageAndMeeting2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>公告通知</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
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
                <legend><small class="text-primary"><a href="javascript:void(0);" onclick="MainAreaCh('/Archive/MessageQuery.aspx');">公告查询</a></small>&nbsp;&nbsp;&nbsp;<small class="text-primary"><a href="javascript:void(0);" onclick="MainAreaCh('/Meeting/MeetingList.aspx');">通知查询</a></small></legend>
                <!-- 框架开始 -->
                <iframe id="mainWorkArea" name="mainWorkArea" src="/Archive/MessageQuery.aspx" style="width: 100%; height: 580px; border: 0px;"></iframe>
            </fieldset>
        </div> 
    </section>
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script>
        /***标签跳转***/
        function MainAreaCh(Url) {
            $(document).find("#mainWorkArea").attr("src", Url);
        }
    </script>
</body>
</html>
