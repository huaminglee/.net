<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContactList.aspx.vb" Inherits="CRM.ContactList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="ContactManage.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="Divdoaction" style ="float :left; width: 100px;" runat="server" 
        align="left">
        <a class="easyui-linkbutton" plain="true" iconcls="icon-add" href="UserADVInfo.aspx?IsAdd=1">新增用戶 </a>
    </div>
    <div style ="float :left ">
        搜尋：<input id="InpSearch" runat="server" class="easyui-searchbox" searcher="searchcontact"
            style="width: 600px"></input>
        <asp:Button ID="BtnSearch" Style="display: none" runat="server" Text="Button" />
    </div>
    <div style ="clear:both "></div>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LbContactPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="姓名" />
                <asp:BoundField DataField="UserSID" HeaderText="登陸名" />
                <asp:BoundField DataField="CustomerName" HeaderText="公司" />
                <asp:BoundField DataField="Position" HeaderText="職位" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="../Images/ico/trash.png"
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
    </form>
</body>
</html>
