<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StandardSearchManageDetail.aspx.vb"
    Inherits="CMCFileManage.StandardSearchManageDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/AddQCFileDetail.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div style="width: 100%">
                    <div style="float: left">
                        <asp:LinkButton ID="LinkEdit" Visible="false" class="easyui-linkbutton" plain="true"
                            iconCls="icon-edit" runat="server">編輯</asp:LinkButton>
                        <asp:LinkButton ID="LinkSave" class="easyui-linkbutton" plain="true" iconCls="icon-save"
                            runat="server">保存</asp:LinkButton>
                        <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton" plain="true" iconCls="icon-back"
                            runat="server">離開</asp:LinkButton>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div style="font-size: 20px; color: #009933; font-family: 標楷體;" align="center">
                    <asp:Label ID="LBtitle" runat="server" Text="標準查詢記錄清單"></asp:Label>
                </div>
                <div style="clear: both">
                    <hr />
                </div>
                <div style="float: left; width: 60%">
                    <table width="100%" style="height: 300px" border="1" cellspacing="0" cellpadding="0"
                        bordercolor="#000000" bordercolordark="#FFFFFF">
                        <tr>
                            <td bgcolor="#E4F1FA" colspan="2" height="50">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ico/baseinfo.png" />
                                <asp:Label ID="Label1" runat="server" Text="基本資料" Font-Bold="True" Font-Size="14px"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                所屬實驗室
                            </td>
                            <td>
                                <asp:DropDownList Width="153px" ID="DPLSearchDept" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#E5E5E5">
                                區域位置
                            </td>
                            <td>
                                <asp:DropDownList ID="DPLQyLocation" Width="153px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F3F3F3">
                                季度
                            </td>
                            <td>
                                <asp:DropDownList ID="DPLSearchJD" Width="153px" runat="server">
                                    <asp:ListItem>第一季度</asp:ListItem>
                                    <asp:ListItem>第二季度</asp:ListItem>
                                    <asp:ListItem>第三季度</asp:ListItem>
                                    <asp:ListItem>第四季度</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F3F3F3">
                                查新時間
                            </td>
                            <td>
                                <asp:TextBox ID="TxtSearchTime" Width="150px" class="Wdate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F3F3F3">
                                查新人
                            </td>
                            <td>
                                <asp:TextBox ID="TxtSearchUser" Width="150px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F3F3F3">
                                附件
                            </td>
                            <td>
                                &nbsp;
                                <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                                <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#F3F3F3">
                                備註
                            </td>
                            <td>
                                <asp:TextBox ID="TxtRemark" Width="150px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: right; width: 37%">
                    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                        bordercolor="#999999">
                        <tr>
                            <td bgcolor="#E4F1FA" height="50">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ico/history.png" />
                                <asp:Label ID="Label2" runat="server" Text="變更履歷" Font-Bold="True" Font-Size="14px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ChangeUser" HeaderText="變更人" />
                                        <asp:TemplateField HeaderText="變更時間">
                                            <ItemTemplate>
                                                <asp:Label ID="LbChangeTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ChangeTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
