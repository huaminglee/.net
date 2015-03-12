<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InternalAuditList.aspx.vb"
    Inherits="CMCFileManage.InternalAuditList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <div id="search">
        <ul class="searchli">
            <li id="add" runat="server" class="LiAdd"><a id="addnew" runat="server" target="MainFrame"
                href="#"><span>新增文件 </span></a></li>
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <li>
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <br />
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelect" class="chkselect" runat="server" onclick="SelectSingleCheckBoxClick(window.event);" />
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Qulocation" HeaderText="區域" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="RecordNO" HeaderText="記錄編號" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Name" HeaderText="名稱" HeaderStyle-HorizontalAlign="Left"
                    ItemStyle-HorizontalAlign="Left" />
                <asp:TemplateField HeaderText="制定日期" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblApplyTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FormulDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
