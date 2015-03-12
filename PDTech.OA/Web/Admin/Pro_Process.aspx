<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pro_Process.aspx.cs" Inherits="Admin_Pro_Process" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看项目步骤</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="水务项目工作流程"></asp:Label>
                   
                </div>
                <div>
                     <input type="button" runat="server" onclick="ShowPrint();" id="btnPrint" value="打印" class="btn_Print con_oper_btn_p let6 right" />
                </div>
                <div class="con_b">
                    <table class="main_stepList" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <th>步骤名称</th>
                            <th>风险点</th>
                            <th>责任处室</th>
                            <th>开始时间</th>
                            <th>完成时间</th>
                            <th>完成时限</th>
                            <th>完成状态</th>
                            <th>管理</th>
                        </tr>
                        <asp:Literal ID="ShowScript" runat="server" EnableViewState="False"></asp:Literal>
                    </table>
                </div>
                <div class="con_oper">
                    <asp:HiddenField runat="server" ID="hidPid" /><asp:HiddenField runat="server" ID="hidFlag" />
                    <asp:HiddenField runat="server" ID="hidTid" /><asp:HiddenField runat="server" ID="hidArId" />
                    <asp:HiddenField ID="hidtaskid" runat="server" />
                    <asp:HiddenField ID="hidarchid" runat="server" />
                    <asp:HiddenField ID="hidisedit" Value="0" runat="server" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="返回" onclick="backPrevious();" />
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function showStepDetail(Url, psId, e, name) {
                if (e == "1") {
                    window.location.href = Url + '?psId=' + psId + '&Isedit=' + $("#hidisedit").val() + '&tId=' + $("#hidtaskid").val();
                }
                else {
                    layer.alert(name+"步骤尚未完成,不能开始此步骤!",8);
                }
            }
            function backPrevious() {
                var pId = $("#hidPid").val();
                if ($("#hidisedit").val() == "1") {
                    window.location.href = '/Admin/sel_Finance.aspx?tId=' + $("#hidtaskid").val() + "&ArId=" + $("#hidarchid").val();
                }
                else {
                    window.location.href = '/Admin/selFinance.aspx?tId=' + $("#hidtaskid").val() + "&ArId=" + $("#hidarchid").val();
                }
                
            }
            function editRisk(ptypeId, p_arId, ptId) {
                window.location.href = '/Risk/newRisk.aspx?ptype=' + ptypeId + '&p_arId=' + p_arId + '&ptId=' + ptId + '';
            }
            function selrisk(arId) {
                window.location.href = '/Risk/sel_risk.aspx?arId=' + arId + '';
            }
            function ShowPrint() {
                var pid =<%=pId%>
                 window.location.href = "ProjectItem_Print.aspx?projectid=" + pid;
             }
        </script>
    </form>
</body>
</html>
