<%@ Control Language="vb" AutoEventWireup="false" Codebehind="CtlGMPNGReasonReport.ascx.vb" Inherits="CMCFileManage.CtlGMPNGReasonReport" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:datagrid id="Datagrid1" runat="server" AutoGenerateColumns="False" ShowHeader="False" AllowSorting="True"
	Width="100%">
	<ItemStyle CssClass="GridItem"></ItemStyle>
	<HeaderStyle CssClass="GridHead"></HeaderStyle>
	<Columns>
		<asp:TemplateColumn>
			<ItemTemplate>
				<asp:Label id="lblIsWithTextBox" Runat="server"></asp:Label>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
