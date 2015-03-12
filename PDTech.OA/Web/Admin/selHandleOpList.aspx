<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selHandleOpList.aspx.cs" Inherits="Admin_selHandleOpList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>办理意见模板列表</title>
    <link rel="stylesheet" type="text/css" href="/CSS/public.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/Sys_list.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="tFrom" runat="server">
       <div class="temp">
            <div class="temp_t"><span>人员模板列表</span></div>
            <div class="temp_list">
                <table class="main_tempList" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <th style="width: 75%;">模板名称</th>
                        <th style="width: 25%;">管理</th>
                    </tr>
                    <asp:Repeater ID="rpt_tempList" runat="server" OnItemCommand="rpt_tempList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lbtn_GetUser" Width="100%" Height="100%" runat="server" CommandName="GetValue" CommandArgument='<%# Eval("TEMPLATE_VALUE")%>' ForeColor="#4f9cd0"><%# Eval("TEMPLATE_JC")%></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtn_del" runat="server" CommandName="tDel" CommandArgument='<%# Eval("TEMPLATE_ID")%>' ForeColor="#4f9cd0">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="temp_t"><span>办理意见信息</span></div>
            <div class="temp_list">
                <table class="main_tempList" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <th style="width:20%;">办理意见：</th>
                        <td style="width:80%;">
                            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div class="temp_Manager">
                <asp:Button ID="btnOK" runat="server" Text="确定" CssClass="btn_submit" OnClick="btnOK_Click"/>
                <input type="button" id="btnClose" value="关闭" class="btn_Close" onclick="window.parent.layer.closeAll();"/>
            </div>
        </div>
    </form>
</body>
</html>
