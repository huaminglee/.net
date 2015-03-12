<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipManageList.aspx.vb"
    Inherits="CMCFileManage.EquipManageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <div id="Divdoaction" runat="server">
        <table>
            <tr>
                <td class="LiAddequip">
                    <a target="MainFrame" href="EquipManageDetail.aspx">新增設備清單 </a>
                </td>
                <td class="LiAddequipfile">
                    <a target="MainFrame" href="EquipFileDetail.aspx">新增設備附件</a>
                </td>
                <td>
                    <ul class="searchli">
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="實驗室" DataField="EquipDept" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="區域位置" DataField="QyLocation" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="設備名稱" DataField="EquipName" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField HeaderText="管制號碼" DataField="ControlNO" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="儀器型號">
                    <ItemTemplate>
                        <asp:Label ID="LbEquipModel" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.EquipModel").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="主要規格">
                    <ItemTemplate>
                        <asp:Label ID="LbSpecification" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Specification").ToString() %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="有無附件" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbisHasDetail" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsHasDetail").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="LbshowisHasDetail" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/trash.png"
                            CommandName="Delete"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div id="page">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    </form>
</body>
</html>
