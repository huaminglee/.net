<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipFileList.aspx.vb"
    Inherits="CMCFileManage.EquipFileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/GridQy.ascx" TagName="GridQy" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="EquipManage.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div id="add" style="float: left" class="LiAddequip" runat="server">
                     <a target="MainFrame" href="EquipFileDetail.aspx">新增設備附件</a> 
                </div>
                <div style="float: left" id="search">
                    <ul class="searchli">
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
                    </ul>
                </div>
                <div style="clear: both">
                </div>
                <div>
                    <asp:GridView ID="GridViewTop" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="實驗室">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbApplydept" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.EquipDept") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:GridQy ID="GridQy1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                    background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                    &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
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
                                    <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="實驗室" DataField="EquipDept" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="區域位置" DataField="QyLocation" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="設備名稱" DataField="EquipName" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="附件名" DataField="DetailName" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="管制號碼" DataField="ControlNO" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="儀器型號" DataField="EquipModel" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="數量" DataField="EquipNum" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="ManuFacturer" HeaderText="廠商" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="MainSpecification" HeaderText="規格" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="EquipLocation" HeaderText="地點" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="KeepUser" HeaderText="保管人" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Extend1" HeaderText="備註" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                                    </asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
                <div id="page">
                    <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
                    </cc1:PagerControl>
                </div>
                <div style="display: none">
                    <asp:Button ID="BtnSetFileCssShow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetFileCSSHid" runat="server" Text="Button" />
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSSshow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSShidd" runat="server" Text="Button" />
                    <asp:HiddenField ID="Hiddenparenetindex" runat="server" />
                    <asp:HiddenField ID="HiddenQyRowindex" runat="server" />
                    <asp:HiddenField ID="HiddencursetcssQyindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurrowindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurdeptname" runat="server" />
                    <asp:HiddenField ID="Hiddencursetcssfileindex" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
