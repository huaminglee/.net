<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PersonTecFileList.aspx.vb"
    Inherits="CMCFileManage.PersonTecFileList" %>

<%@ Register Src="../UCtl/GridPersonDept.ascx" TagName="GridPersonDept" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="OutFileGrid.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div id="search">
                    <ul class="searchli">
                        <li id="add" runat="server" class="LiAdd"><a id="addnew" runat="server" target="MainFrame"
                            href="#"><span>新增文件 </span></a></li>
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                            <li>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem Selected="True">在職</asp:ListItem>
                                    <asp:ListItem>轉出</asp:ListItem>
                                    <asp:ListItem>離職</asp:ListItem>
                                </asp:RadioButtonList>
                            </li>
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
                    <asp:GridView ID="GridView1" Visible="false" runat="server" AutoGenerateColumns="False"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Qulocation" HeaderText="區域" />
                            <asp:BoundField DataField="Dept" HeaderText="部門" />
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
                            <asp:BoundField DataField="Intime" HeaderText="入廠日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="PostsTime" HeaderText="上崗日期" />
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" Visible="false" ItemStyle-HorizontalAlign="Left">
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
                <div id="GridTop">
                    <asp:GridView ID="GridViewTop" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="區域位置">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbQuLocation" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.QuLocation") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:GridPersonDept ID="GridPersonDept1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" ItemStyle-Width="50px">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
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
                    <asp:HiddenField ID="HiddenType" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
