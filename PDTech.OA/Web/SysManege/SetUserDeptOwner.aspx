<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetUserDeptOwner.aspx.cs" Inherits="SysManege_SetUserDeptOwner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>用户权限编辑</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/PurTree.css" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="uFrom" runat="server">
        <div class="NewDept">
            <table class="Form_Main_CSS" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td class="Form_Main_td" style="width: 100px;">用户登录名</td>
                    <td class="Form_Main_td">
                        <asp:Label ID="txtrName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="Form_Main_td">分管部门</td>
                    <td class="Form_Main_td" style="height: 380px">
                        <div class="purTree_r">
                            <asp:Label runat="server" ID="lblMark" Font-Size="12px"></asp:Label>
                            <asp:TreeView ID="RightTree" runat="server" ImageSet="Simple" NodeIndent="10" ShowCheckBoxes="All"
                                ShowLines="True" CssClass="TreeMenu" ExpandDepth="1">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="False" ForeColor="#DD5555" />
                                <SelectedNodeStyle Font-Names="Tahoma" Font-Size="8pt" Font-Underline="True" ForeColor="#DD5555"
                                    HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="Form_Main_td" colspan="2" style="height: 36px; line-height: 36px; text-align: center;">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="subBtn" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
            <asp:HiddenField ID="RightValue" runat="server" Value="" />
        </div>
    </form>
</body>
</html>
