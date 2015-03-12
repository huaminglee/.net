<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridQy.ascx.vb" Inherits="CMCFileManage.GridQy" %>
<%@ Register Src="GridOutFile.ascx" TagName="GridOutFile" TagPrefix="uc1" %>
<%@ Register Src="GridOtherFile.ascx" TagName="GridOtherFile" TagPrefix="uc2" %>
<%@ Register src="GridEquip.ascx" tagname="GridEquip" tagprefix="uc3" %>
<%@ Register src="GridEquipFile.ascx" tagname="GridEquipFile" tagprefix="uc4" %>
<%@ Register src="GridStandartZT.ascx" tagname="GridStandartZT" tagprefix="uc5" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="區域" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Image ID="Image1" Style="cursor: hand;" runat="server" ImageUrl="../Images/addGrid.png" />
                    <asp:Label ID="LbQy" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.QyLocation")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <uc1:GridOutFile ID="GridOutFile1" runat="server" />
                   <%-- <uc2:GridOtherFile ID="GridOtherFile1" runat="server" />--%>
                    <uc3:GridEquip ID="GridEquip1" runat="server" />
                    <uc4:GridEquipFile ID="GridEquipFile1" runat="server" />
                    <uc5:GridStandartZT ID="GridStandartZT1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nums" HeaderText="數量" HeaderStyle-HorizontalAlign="Right"
                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
<asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" />














