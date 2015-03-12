<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPurview.ascx.cs" Inherits="UserControls_ucPurview" %>
<link rel="stylesheet" type="text/css" href="/CSS/PurTree.css" />
<link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
<div class="PurTree">
    <div class="TreeUl left">
        <asp:Label runat="server" ID="lblMark" Font-Size="12px"></asp:Label>
        <asp:TreeView ID="Tree_Purview" runat="server" CssClass="tree-node" Font-Size="12px" OnSelectedNodeChanged="Tree_Purview_SelectedNodeChanged" ForeColor="Black">
        </asp:TreeView>
    </div>
    <div class="Form_View right">
        <table class="Form_Main" cellpadding="0px" cellspacing="0px">
            <tr>
                <td>上级权限</td>
                <td>
                    <asp:Label ID="lblParent_Name" runat="server" Text="无"></asp:Label></td>
                <td class="ImpTips">&nbsp;</td>
            </tr>
            <tr>
                <td>权限名称</td>
                <td>
                    <asp:TextBox ID="txtRIGHT_NAME" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                <td class="ImpTips">*</td>
            </tr>
            <tr>
                <td>权限编码</td>
                <td>
                    <asp:TextBox ID="txtRIGHT_CODE" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                <td class="ImpTips">*</td>
            </tr>
            <tr>
                <td>权限排序</td>
                <td>
                    <asp:TextBox ID="txtSORT_NUM" runat="server" CssClass="input inpute" onblur="javascript:return check_isnum();" onkeydown="javascript:return check_isnum();" MaxLength="9"></asp:TextBox></td>
                <td class="ImpTips">*</td>
            </tr>
            <tr>
                <td>描述</td>
                <td>
                    <asp:TextBox ID="txtRIGHT_DESC" runat="server" CssClass="input inpute" TextMode="MultiLine" Height="160px" MaxLength="249"></asp:TextBox></td>
                <td class="ImpTips"></td>
            </tr>
            <tr>
                <td colspan="3">
                    <div class="Form_Main_Btnpanel">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="subBtn" OnClick="btnSave_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

