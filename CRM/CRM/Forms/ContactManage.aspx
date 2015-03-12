<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="ContactManage.aspx.vb"
    Inherits="CRM.ContactManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/locale/easyui-lang-zh_TW.js" type="text/javascript"></script>

    <script src="ContactManage.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnSearch">
    <div>
        <table>
            <tr>
                <td colspan="4">
                    搜尋：<input id="InpSearch" runat="server" class="easyui-searchbox" searcher="searchcontact"
                        style="width: 720px"></input>
                    <asp:Button ID="BtnSearch" Style="display: none" runat="server" Text="Button" />
                </td>
            </tr>
            <tr>
                <td>
                    添加： 姓名<asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenContactPKID" Value="0" runat="server" />
                    <asp:Image ID="Image2" Style="cursor: hand;" ToolTip="點擊選擇" ImageUrl="~/Images/search.png"
                        runat="server" onclick="GetContactDialog('#ContactDialog', '#ContactInfo', 'TxtName', 'HiddenContactPKID','TxtSID','TxtCustomerName')" />
                </td>
                <td>
                    帳號<asp:TextBox ID="TxtSID" runat="server"></asp:TextBox>
                </td>
                <td>
                    公司<asp:TextBox ID="TxtCustomerName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="LinkAdd" class="easyui-linkbutton" iconcls="icon-add" runat="server">添加到我的聯繫人</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="姓名" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="UserSID" HeaderText="帳號" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="Extend1" HeaderText="電話" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="Extend4" HeaderText="帳號郵箱" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="Position" HeaderText="職務" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                
                <asp:BoundField DataField="CustomerName" HeaderText="公司名" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" Visible ="false"  runat="server" ToolTip="刪除" ImageUrl="../Images/ico/trash.png"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="Pager">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    <div id="ContactDialog" iconcls="icon-save" closed="true" title="請選擇聯繫人信息" runat="server">
        <div id="ContactInfo" toolbar="#dlg-toolbar">
        </div>
        <div id="dlg-toolbar" style="display: none;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                        <asp:Label ID="Label22" runat="server" Text="姓名"></asp:Label>
                    </td>
                    <td style="text-align: right; padding-right: 2px">
                        <input class="easyui-searchbox" searcher="selectcontact"></input>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
