<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlListAction.ascx.vb"
    Inherits="CRM.ListAction" %>
<div style="width: 100%">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:LinkButton ID="LnkAdd" runat="server">新增</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LnkDelete" runat="server">刪除</asp:LinkButton>
            </td>
            <td align="right" id="tdSearch" runat="server">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList ID="DDLSearchType" runat="server">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="DDLSearchValue" runat="server">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:TextBox ID="TxtSearch1" runat="server"></asp:TextBox>
                        </td>
                        <td id="tdTime2" runat="server">
                            ~<asp:TextBox ID="TxtSearch2" runat="server" onfocus="setDay(this)"></asp:TextBox>
                        </td>
                        <td valign="middle" >  <div style="margin-right:10px; margin-left:4px;">
                            <asp:Button ID="BtnSearch" runat="server" Text="搜索" />    &nbsp;
                            <asp:Button ID="BtnReset" runat="server" Text="重置" />
                                    &nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/Excel.gif" Visible="false"/></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
