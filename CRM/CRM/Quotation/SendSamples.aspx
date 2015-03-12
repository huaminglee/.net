<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SendSamples.aspx.vb" Inherits="CRM.SendSamples" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="title" align="center" style="font-size: 14px; font-family: simsun">
        寄樣品/發票
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" colspan="6">
                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label7" runat="server" Text="報價單信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                                        客戶</td>
                <td colspan="5">
                    <asp:Label ID="LbCustomer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    地址</td>
                <td>
                    <asp:Label ID="LbAddress" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td align="center">
                    收件人 </td>
                <td>
                    <asp:Label ID="LbContact" runat="server"></asp:Label>
                </td>
                <td align="center">
                                        郵箱</td>
                <td>
                    <asp:Label ID="LbEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    報價單號                </td>
                <td>
                    <asp:Label ID="LbQuotationNo" runat="server"></asp:Label>
                </td>
                <td align="center">
                                        報價人</td>
                <td colspan="3">
                    <asp:Label ID="LbQuoter" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    測試編號                </td>
                <td>
                    <asp:Label ID="LbTestNo" runat="server"></asp:Label>
                </td>
                <td align="center">
                                        樣品</td>
                <td colspan="3">
                    <asp:Label ID="LbSamples" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    快遞信息</td>
                <td colspan="5">
                    <asp:TextBox ID="TxtSendinfo" runat="server" Height="73px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:CheckBox ID="ChbIsmailCus" runat="server" Checked="True" Text="郵件通知客戶" />
                </td>
                <td colspan="5">
                    <asp:Button ID="BtnSendSamples" runat="server" Visible ="false"  Height="59px" Text="寄樣品"  class="button" Width="176px" />
                    <asp:Label ID="LbSendSapleTimes" Visible ="false"  runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSendFapiao" runat="server" Visible ="false"  Height="59px" Width="176px"  class="button" Text="寄發票" />
                    <asp:Label ID="LbSendFapiaoTime" Visible ="false"  runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSendAll" runat="server" Visible ="false"  Height="59px" Width="176px"  class="button" Text="寄樣品&發票" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
