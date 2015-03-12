<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportantGoodsDetail.aspx.vb"
    Inherits="CMCFileManage.ImportantGoodsDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="BtnSave" class="button" runat="server" Text="保存" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                   <input type="button" class="button" value="返回" runat="server" id="BtnBack"
                onclick="javascript:history.go(-1);return false;">
                </td>
            </tr>
        </table>
    </div>
    <div style="float: left; width: 60%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label2" runat="server" Text="物品基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    實驗室名稱
                </td>
                <td>
                    <asp:DropDownList ID="DplLab" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    品名
                </td>
                <td>
                    <asp:TextBox ID="TxtGoodsName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    規格型號
                </td>
                <td>
                    <asp:TextBox ID="TxtStandars" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    廠牌
                </td>
                <td>
                    <asp:TextBox ID="TxtBrands" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    供應商
                </td>
                <td>
                    <asp:TextBox ID="TxtSupplier" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    主要技術要求
                </td>
                <td>
                    <asp:TextBox ID="TxtTecRequire" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    區域
                </td>
                <td>
                    <asp:DropDownList ID="DplQulocation" runat="server" Width="150px">
                    </asp:DropDownList>
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
    </div>
    <div style="float: right; width: 35%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/history.png" />
                    <asp:Label ID="Label1" runat="server" Text="變更記錄" Font-Bold="True" Font-Size="14px"></asp:Label>
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
    </form>
</body>
</html>
