<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PersonTecFileDetail.aspx.vb"
    Inherits="CMCFileManage.PersonTecFileDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function Saveuserinfo() {
            var Result = false; Result = $("#userinfo").form("validate");
            if (Result) {
                document.getElementById('LinkSave').click(); return true; // $('#LinkSave').click();
            } else { return false; }
        }
    </script>

    <style type="text/css">
        .style11
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="userinfo">
        <table width="100%">
            <tr>
                <td>
                    <asp:Image ID="Image5" runat="server" ImageUrl="../Images/blank.jpg" />
                    <div style="float: left">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
                            runat="server">編輯</asp:LinkButton>
                        <a href="#" class="easyui-linkbutton" runat="server" visible="false" iconcls="icon-save"
                            id="btnSave" plain="true" onclick="Saveuserinfo()">保存</a>
                        <asp:LinkButton ID="LinkSave" Style="display: none" class="easyui-linkbutton" plain="true"
                            iconCls="icon-save" runat="server">保存</asp:LinkButton>
                        <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton" plain="true" iconCls="icon-back"
                            runat="server">離開</asp:LinkButton>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="title" align="center">
                        <asp:Label ID="Label1" runat="server" Text="人員技術檔案" Font-Size="16"></asp:Label>
                    </div>
                    <hr />
                    <table width="100%">
                        <tr>
                            <td width="50%">
                                <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                                    bordercolordark="#FFFFFF" align="left" width="100%">
                                    <tr>
                                        <td width="150px">
                                            部門
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DplDept" runat="server" Width="153px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            姓名
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            工號
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtUserSid" CssClass="easyui-validatebox" invalidMessage="該人員已經存在!"
                                                required="true" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            區域
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DplQulocation" runat="server" Width="153px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            職系
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtJobType" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            管理職
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtPosition" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            證書編號
                                        </td>
                                        <td>
                                            <asp:Label ID="LbCerNo" runat="server" CssClass="easyui-validatebox" invalidMessage="日期未選擇!"
                                                required="true" Text=""></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            入廠日期
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIntime" CssClass="easyui-validatebox" invalidMessage="日期未選擇!"
                                                required="true" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            上崗日期
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtPostsTime" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            上崗資料
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtPostsRemark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            其它培訓資料
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtOtherRemark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            目前狀態
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RDOCurType" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Selected="True" Value="1">在職</asp:ListItem>
                                                <asp:ListItem Value="2">轉出</asp:ListItem>
                                                <asp:ListItem Value="3">離職</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            備註
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtRemark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                                    bordercolor="#999999">
                                    <tr>
                                        <td bgcolor="#E4F1FA" height="50">
                                            <asp:Image ID="Image2" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                                            <asp:Label ID="Label6" runat="server" Text="上崗資料" Font-Bold="True" Font-Size="14px"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td bgcolor="#E4F1FA" height="50">
                                            <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                                            <asp:Label ID="Label8" runat="server" Text="其它資料" Font-Bold="True" Font-Size="14px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                                            <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                                            <uc1:UcFileDetail ID="UcFileDetail4" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div style="clear: both">
                    </div>
                    <div>
                        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                            bordercolor="#999999">
                            <tr>
                                <td bgcolor="#E4F1FA" height="50">
                                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/history.png" />
                                    <asp:Label ID="Label10" runat="server" Text="文件變更履歷" Font-Bold="True" Font-Size="14px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ChangeUser" HeaderText="變更人" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" />
                                            <asp:TemplateField HeaderText="變更時間" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
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
    </div>
    </form>
</body>
</html>
