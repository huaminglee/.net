<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcLog.ascx.vb" Inherits="CMCFileManage.UcLog" %>
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<div>
    <table>
        <tr>
            <td>
                �����G
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlType" Width="93px">
                </asp:DropDownList>
            </td>
            <td>
                ����G
            </td>
            <td>
                <input type="text" id="iStartDate" runat="server" onfocus="this.blur()" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    style="width: 100px" />��
                <input type="text" id="iEndDate" runat="server" onfocus="this.blur()" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    style="width: 100px" />
            </td>
            <td>
                �@�~���G
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtOperator"></asp:TextBox>
            </td>
            <td>
                ��H�G
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtObject"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkShowDetail" Text="��ܸԲӫH��" AutoPostBack="true" />
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Search.gif" />
            </td>
            <td>
                <asp:Literal runat="server" ID="litInfo" EnableViewState="false"></asp:Literal>
            </td>
        </tr>
    </table>
</div>
<div style="height: 10px">
</div>
<asp:GridView ID="gvLog" runat="server" AutoGenerateColumns="False" Width="100%"
    Font-Size="12px">
    <Columns>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�Ǹ�">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litNo" Text="<%#Container.DataItemIndex+1 %>"></asp:Literal>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�u��">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hylOperator" Text='<%#Eval("Operater") %>'></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�ާ@��H">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hylOperated" Text='<%#Eval("Operated") %>'></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�O���ɶ�">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litTime" Text='<%#Eval("Time") %>'></asp:Literal>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�O����IP">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litIP" Text='<%#Eval("IP") %>'></asp:Literal>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�O����MAC">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litMAC" Text='<%#Eval("MAC") %>'></asp:Literal>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="�ʧ@">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litAction" Text='<%#Eval("Action") %>'></asp:Literal>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="�Բ�">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litDetail" Text='<%#Eval("Extend01") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="�R���O��">
            <ItemTemplate>
                <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif"
                    CommandName="Delete"></asp:ImageButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<cc1:PagerControl ID="PagerControl1" runat="server">
</cc1:PagerControl>
