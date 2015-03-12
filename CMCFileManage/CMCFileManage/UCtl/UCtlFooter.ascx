<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UCtlFooter.ascx.vb"
    Inherits="CMCFileManage.UCtlFooter" %>
<table cellspacing="0" cellpadding="0" align="center" border="0" width="100%">
    <tr>
        <td colspan="2" valign="middle" align="center">
            <span id="lblCopyright">Copyright&nbsp;<asp:Label ID="LblVersionInfo" runat="server"
                Text="Label"></asp:Label>
                by CMC R&amp;D II</span>&nbsp;華南檢測中心系統整合實驗室
        </td>
    </tr>
    <tr>
        <td valign="top" align="center" nowrap="nowrap">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="60" nowrap="nowrap">
                        <asp:HyperLink ID="HlSystemInfo" runat="server" ForeColor="Red">系統信息</asp:HyperLink>
                    </td>
                    <td width="90" nowrap="nowrap">
                        <asp:HyperLink ID="HLAccount" runat="server" ForeColor="Blue">我的帳戶信息</asp:HyperLink>
                    </td>
                    <td>
                        <span>建議與反饋:王清雲(26741)</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
