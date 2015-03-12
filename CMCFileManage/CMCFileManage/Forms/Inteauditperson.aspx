<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inteauditperson.aspx.vb"
    Inherits="CMCFileManage.Inteauditperson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/UserDialog.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div style="font-size: 14px">
                    點擊圖標選擇人員后點擊添加
                    <asp:Image ID="Image2" Style="cursor: hand;" ToolTip="點擊選擇" ImageUrl="~/Images/search.png"
                        runat="server" />
                    姓名：<asp:Label ID="LbUserName" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenUserPKID" runat="server" />
                    工號：<asp:Label ID="LbUserSid" runat="server" Font-Size="14px" ForeColor="#3366FF"></asp:Label>
                    郵箱：<asp:Label ID="LbUserEmail" runat="server" Text="" Font-Size="14px" ForeColor="#3366FF"></asp:Label>
                    電話：<asp:Label ID="LbUserPhone" runat="server" Text="" Font-Size="14px" ForeColor="#3366FF"></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">能編輯</asp:ListItem>
                        <asp:ListItem Value="0">不能編輯</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="BtnAdd" runat="server" Text="添加" />
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LBpkid" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.pkid") %>'></asp:Label>
                                    <asp:Label ID="LbUserpkid" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Userpkid") %>'></asp:Label>
                                    <asp:Label ID="LbRolePKID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.RolePKID") %>'></asp:Label>
                                    <asp:LinkButton ID="LinkEdit" CommandName="editup" runat="server">編輯</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                        ID="LinkSave" Visible="false" CommandName="saveup" runat="server">更新</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                            ID="LinkCancle" runat="server" CommandName="cancleed" Visible="false">取消</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="姓名" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="UserSid" HeaderText="工號" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="UserEmail" HeaderText="郵箱" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="UserPhone" HeaderText="電話" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="能否編輯" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbIscanedit" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.IsCanEdit") %>'></asp:Label>
                                    <asp:RadioButtonList ID="RdoIscanedit" Visible="false" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="1">能編輯</asp:ListItem>
                                        <asp:ListItem Value="0">不能編輯</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                                    </asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="BGDialog" iconcls="icon-save" closed="true" title="請選擇人員信息" runat="server">
                    <div id="CodeUserInfo" toolbar="#dlg-toolbar">
                    </div>
                    <div id="dlg-toolbar" style="display: none;">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                                    <asp:Label ID="Label22" runat="server" Text="姓名"></asp:Label>
                                </td>
                                <td style="text-align: right; padding-right: 2px">
                                    <input class="easyui-searchbox" searcher="selectUser"></input>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
