<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GridPerson.ascx.vb"
    Inherits="CMCFileManage.GridPerson" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="狀態">
                <ItemTemplate>
                    <asp:Label ID="LblPKID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.pkid").ToString() %>'></asp:Label>
                    <asp:Label ID="LbTypeInt" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.curtype").ToString() %>'></asp:Label>
                    <asp:Label ID="LbType" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CerNo" HeaderText="證書編號" />
            <asp:BoundField DataField="UserSid" HeaderText="工號" />
            <asp:BoundField DataField="UserName" HeaderText="姓名" />
            <asp:BoundField DataField="JobType" HeaderText="職系" />
            <asp:BoundField DataField="Intime" HeaderText="入廠日期" DataFormatString="{0:yyyy-MM-dd}"/>
            <asp:BoundField DataField="PostsTime" HeaderText="上崗日期" DataFormatString="{0:yyyy-MM-dd}"/>
            <asp:TemplateField Visible ="false"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                    </asp:ImageButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
