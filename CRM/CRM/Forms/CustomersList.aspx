<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="CustomersList.aspx.vb"
    Inherits="CRM.CustomersList" %>
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../NewScript/jquery-1.7.2.min.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="CustomerList.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnSearch">
     <div style ="float :left; width: 100px;">
        <a href="#" id="NewItem" title="新增" class="easyui-linkbutton" plain="true" iconcls="icon-add">
            新增客戶</a>
    </div>
     <div id="search" style ="float :left ">
    搜尋：<input id ="InpSearch" runat ="server"  class="easyui-searchbox" searcher="searchcustomer" style="width: 600px"></input>
        <asp:Button ID="BtnSearch" style="display :none" runat="server" Text="Button" />
    </div>
   <div style ="clear :both "></div>
   <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="lbPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                        <asp:HyperLink ID="HLGetQuotation" Target="_self" runat="server" ToolTip="生成報價單" ImageUrl="../Images/ico/pin.png">生成報價單</asp:HyperLink>
                        <asp:HyperLink ID="HlCusvisits" Target="_self" runat="server" ToolTip="客戶拜訪" ImageUrl="../Images/ico/cusvisits.png">客戶拜訪</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CustomerName" HeaderText="客戶名稱" />
                <asp:BoundField DataField="CustomerID" HeaderText="客戶編號" />
                <asp:BoundField DataField="CustomerEnglishName" HeaderText="客戶英文名" />
                <asp:TemplateField HeaderText="客戶類別">
                    <ItemTemplate>
                        <asp:Label ID="LbCategory" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container,"DataItem.Category") %>'></asp:Label><asp:Label
                            ID="LbCategoryShow" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ToolTip ="刪除" ImageUrl="../Images/ico/trash.png"
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
