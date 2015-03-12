<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EdayQuestion.aspx.cs" Inherits="EdayQuestion" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>成都市水务局综合管理系统</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">history.go(1); </script>
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function checkValue() {
            var n = $("input:checked").length;
            //var selected = $('input[name=rblOption:checked]').val();
            //alert(n);
            if (n == 0) {
                alert("您还未答题！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body style="background-image: url('/images/login_bg.jpg')">
    <form runat="server">
        <asp:HiddenField ID="hidbuzuoquestionid" runat="server" />
        <div class="container-fluid" style="width: 695px; margin: 10% auto; height: 481px; background-size: 100% 100%; background-image: url('/images/EveryDayQuestion.png')">
            <!-- 题目开始 -->
            <div class="row" style="margin-top: 20%;">
                <div class="col-sm-12">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </div>
            </div>
            <!-- 题目结束 -->

            <!-- 选择项开始 -->
            <div class="row" style="margin-top: 5%;">
                <div class="col-sm-12">
                    <asp:RadioButtonList ID="rblOption" runat="server" Width="90%">
                    </asp:RadioButtonList>
                </div>
            </div>
            <!-- 选择项结束 -->

            <!-- 按钮开始 -->
            <div class="row" style="margin-top: 5%;">
                <div class="col-sm-4">
                </div>
          <%--      <div class="col-sm-2">
                    <asp:Button ID="btnSkip" runat="server" Text="跳&ensp;过" CssClass="btn btn-default" OnClick="btnSkip_Click" />
                </div>--%>
                <div class="col-sm-2">
                    <asp:Button ID="btnSubmit" runat="server" Text="确&ensp;定" CssClass="btn btn-primary" OnClick="btnSubmit_Click" OnClientClick="return checkValue()" />
                </div>
            </div>
            <!-- 按钮结束 -->
            <asp:HiddenField ID="hidQuestionId" runat="server" Value="" />
            <asp:HiddenField ID="hidScore" runat="server" Value="" />
            <asp:HiddenField ID="hidAnswer" runat="server" Value="" />
            <asp:HiddenField ID="hidAnswerTitle" runat="server" Value="" />
            <asp:HiddenField ID="hidanswertimes" Value="0" runat="server" />
        </div>
    </form>
</body>
</html>