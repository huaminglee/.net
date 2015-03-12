<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ctlWFHistory.ascx.vb"
    Inherits="eWorkFlow.eFlowDoc.ctlWFHistory" %>
    <style type="text/css">
   #ctl00_PageBody_ctlWFHistory1_dgFlowHistory tr{ height:20px; line-height:20px;}
    </style>
<asp:GridView ID="dgFlowHistory" runat="server" AutoGenerateColumns="false" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="NO">
            <ItemTemplate>
                <asp:Label ID="LabNO" runat="server"></asp:Label>
                <asp:HiddenField ID="HidStateInstanceKeyID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.StateKeyID") %>' />
                <asp:HiddenField ID="HidTransactPKID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TransactPKID") %>' />
                <asp:HiddenField ID="HidTransactNumber" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TransactNumber") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblStateName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TemplateStateName") %>'>
                </asp:Label>
                <asp:HiddenField ID="HidSattePKID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TemplateStateID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="labPersonInfo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TransactUserName") %>'>
                </asp:Label>
                <asp:Label ID="LbEmail" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="HidTransactUserPKID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TransactUserPKID") %>' />
                <asp:HiddenField ID="HidTransactUSerID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TransactUserID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblTransactOption" Width="80" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TransactOption") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RecordCreateTime", "{0:yyyy-MM-dd HH:mm}") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="labComment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TransactResult") %>'>
                </asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTransactRemark" Text='<%# DataBinder.Eval(Container, "DataItem.TransactResult") %>'
                    runat="server"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="PDF">
            <ItemTemplate>
                <asp:HiddenField ID="HidDataFileGuid" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Extend2") %>' />
                <asp:ImageButton ID="btnDownload" CommandName="DownLoad" Visible="false" ImageUrl="~/Images/DownLoad.gif"
                    runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Extend2") %>'
                    OnInit="BtnCheckAduitPDFInit" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
