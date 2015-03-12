<%@ Page Language="vb" AutoEventWireup="false" Theme ="Default"  CodeBehind="NGItemReason.aspx.vb"
    Inherits="CMCFileManage.NGItemReason" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="NGItem.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <asp:Label ID="LbTitle" runat="server" Font-Size="20pt"></asp:Label>
            </div>
            <div>
                <a  href="javascript:Addnew()"> 
                    <asp:Image ID="Image1" tooltip="新增" runat="server" ImageUrl="~/Images/Icons/add.png" /></a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImbSave" runat="server" ImageUrl="~/Images/tick.png" ToolTip="保存" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="ImbLeave" runat="server" ImageUrl="~/Images/cross.png" ToolTip="離開" />
            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Width="100%" >
                    <Columns>
                        <asp:BoundField DataField="NGItemName" HeaderText="不滿意原因" HeaderStyle-HorizontalAlign="Left" />
                        <asp:TemplateField HeaderText="是否可自定義輸入" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LbIsTextBox" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container,"DataItem.IsWithTextBox") %>'>'></asp:Label>
                                <asp:CheckBox ID="CheIsTextBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif"
                                    CommandName="Delete"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:GridView>
            </div>
            <div style="display: none">
                <asp:Button ID="btn1" runat="server" Text="Button" />
                <asp:HiddenField ID="HidDeptItemPKID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
