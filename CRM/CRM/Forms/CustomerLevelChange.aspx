<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="CustomerLevelChange.aspx.vb"
    Inherits="CRM.CustomerLevelChange" %>
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="CustomerLevelChange.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <table width="99%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td align="right" style="color: #0099FF" width="100px">
                    客戶名
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    客戶編號
                </td>
                <td style="margin-left: 40px" width="160px">
                    &nbsp;
                    <asp:Label ID="LbCustomerID" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    添加人
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbInsertPerson" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    添加時間
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbInserDate" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" style="color: #0099FF">
                    總交易金額
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbDealamcount" runat="server" Text="200"></asp:Label>
                </td>
                <td align="right" style="color: #0099FF">
                    上次交易時間
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbLastDealDate" runat="server" Text="2012-12-8"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    變更原因
                </td>
                <td colspan="5">
                    &nbsp;
                    <asp:TextBox ID="TxtChangeReason" runat="server" Width="500px"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    當前客戶等級
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="LbOldGrade" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                </td>
                <td align="right" style="color: #0099FF">
                    變更為
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="DPLNewGrade" onchange="dpllayerchange()" runat="server">
                        <asp:ListItem Value="P">潛在客戶</asp:ListItem>
                        <asp:ListItem Value="N">洽談中</asp:ListItem>
                        <asp:ListItem Value="D">交易客戶</asp:ListItem>
                        <asp:ListItem Value="F">凍結客戶</asp:ListItem>
                        <asp:ListItem Value="O">流失客戶</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="Txtlevel"  class="easyui-numberbox" style="display :none " Text ="0" runat="server" Width="50px"></asp:TextBox>
                    <asp:Label ID="Lbji" style="display :none" runat="server" Text="級"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;
                    
                    &nbsp;
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:LinkButton ID="LinkSave" class="easyui-linkbutton" plain="true" iconCls="icon-save" runat="server">確認變更</asp:LinkButton>
                </td>
                <td align="right">
                   <asp:LinkButton ID="LinkBack" class="easyui-linkbutton" plain="true" iconCls="icon-back" runat="server">取消</asp:LinkButton></td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div style ="clear :both ">
    
    </div>
    <div style="font-size: 16px; color: #0066CC;">
        變更記錄</div>
        <div style ="clear :both ">
    
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="99%">
            <Columns>
                <asp:BoundField DataField="ChangePerson" HeaderText="變更人" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="RecordCreated" HeaderText="變更時間" HeaderStyle-HorizontalAlign="Left" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField HeaderText="原等級" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbOldGrade" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.OldGrade") %>'>
                        </asp:Label><asp:Label ID="LbOldGradeShow" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="新等級" HeaderStyle-HorizontalAlign="Left">
                   <ItemTemplate >
                   <asp:Label ID="LbNewGrade" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.NewGrade") %>'>
                        </asp:Label><asp:Label ID="LbNewGradeShow" runat="server" Text=""></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="變更原因" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate >
                    <asp:Label ID="LbReason" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Reason") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="Pager">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    </form>
</body>
</html>
