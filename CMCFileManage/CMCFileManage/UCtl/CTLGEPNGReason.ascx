<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CTLGEPNGReason.ascx.vb"
    Inherits="CMCFileManage.CTLGEPNGReason" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript" id="clientEventHandlersJS">
function CheckInput(oCheckBox,TxtBox)
{
var TxtValue=document.getElementById(TxtBox);

			if (oCheckBox.checked)
			{
				if (TxtValue.value=="")
				{
					alert("為了我們能提供更好的服務，請填寫不滿意原因！");
					return false;
				}
			}
	return true;
}
</script>
<asp:DataGrid ID="Datagrid1"  runat="server" style="DISPLAY: none"
    AutoGenerateColumns="False" ShowHeader="False" AllowSorting="True" Width="100%">
    <ItemStyle CssClass="GridItem"></ItemStyle>
    <HeaderStyle CssClass="GridHead"></HeaderStyle>
    <Columns>
        <asp:TemplateColumn>
            <ItemStyle Wrap="False" Width="150"></ItemStyle>
            <ItemTemplate>
                <asp:CheckBox ID="chkNgReason" runat="server"></asp:CheckBox>
                <asp:Label ID="lblNGItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NGItemName") %>'>
                </asp:Label>
                <asp:Label ID="lblPKID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PKID") %>'
                    Visible="False">
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:Label ID="lblIsWithTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsWithTextBox") %>'
                    Visible="False">
                </asp:Label>
                <asp:TextBox ID="txtNgReasonInput" Visible="False" Width="100%" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>
