<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SelectDept.aspx.vb" Inherits="CMCFileManage.SelectDept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CSIStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style11
        {
            width: 100%;
        }
    </style>
</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <div>
        <table class="style11">
            <tr>
                <td align="center" style="font-size: 20px; color: #339933; font-weight: normal;" 
                    valign="top">
                    請先選擇實驗室</td>
            </tr>
            <tr>
                <td>
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="100%">
            <ItemStyle Width="30%" />
            <ItemTemplate>
                <asp:LinkButton ID="linkDeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Text") %>'
                    CommandName="SearchDeptName" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Value") %>'
                     CssClass ="SkinObject" Font-Size="12px">
                </asp:LinkButton>
                <br />
                &nbsp;&nbsp;
            </ItemTemplate>
        </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
