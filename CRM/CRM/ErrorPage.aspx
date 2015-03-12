<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ErrorPage.aspx.vb" Inherits="CRM.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top:8px;">
        <tr>
            <td nowrap>
                <img src="Images/12630051960.gif" border="0">&nbsp;&nbsp;
            </td>
            <td width="100%">
                <asp:Label ID="Label2" runat="server" Font-Size="16px" 
                    Font-Bold="True" ForeColor="Black">很抱歉，您的操作得不到系統的處理！請重試，如遇問題依然無法解決請與管理員聯繫！</asp:Label>
                <br />
                We&#39;re sorry but the page your are looking for is Not Found...<br />
                <br />
                仔細找過啦，沒有找到您要找的頁面。可能的原因是：</td>
        </tr>
        <tr>
            <td>
            </td>
            <td nowrap>
                &nbsp;&nbsp;
                <asp:Label ID="LblErrorMessage" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" nowrap>
                <font face="新細明體"></font>
                <br>
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" CssClass="ContentText">您可以通過下面的方式繼續進行操作！</asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" nowrap>
                <br>
                &nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="ContentText" 
                    Target="_parent">回到首頁</asp:HyperLink>&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="ContentText">回前一頁</asp:HyperLink>
                <br />
                <br />
                應用和系統整合實驗室 李金坪 26740</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
