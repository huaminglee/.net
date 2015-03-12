<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CTLGEPNGReason.ascx.vb" Inherits="CTLGEPNGReason" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
<asp:datagrid id="Datagrid1" style="DISPLAY: none; VISIBILITY: hidden" runat="server" AutoGenerateColumns="False"
	ShowHeader="False" AllowSorting="True" Width="100%">
	<ItemStyle CssClass="GridItem"></ItemStyle>
	<HeaderStyle CssClass="GridHead"></HeaderStyle>
	<Columns>
		<asp:TemplateColumn>
			<ItemStyle Wrap="False" Width="150"></ItemStyle>
			<ItemTemplate>
				<asp:CheckBox id="chkNgReason" runat="server"></asp:CheckBox>
				<asp:Label id="lblNGItemName" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NGItemName") %>' >
				</asp:Label>
				<asp:Label id=lblPKID Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PKID") %>' Visible="False">
				</asp:Label>
				
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn>
			<ItemTemplate>
				<asp:Label id="lblIsWithTextBox" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsWithTextBox") %>' Visible="False">
				</asp:Label>
				<asp:TextBox id="txtNgReasonInput" Visible="False" Width="100%" runat="server"></asp:TextBox>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
