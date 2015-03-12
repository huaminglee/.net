<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="Syssetting.aspx.vb"
    Inherits="CRM.Syssetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div title="公司信息" style="display: none">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label8" runat="server" Text="公司基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    公司代號
                    <asp:TextBox ID="TxtDH" runat="server"></asp:TextBox>
                    區號
                    <asp:TextBox ID="TxtQH" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnSave" runat="server" class="button" Text="保存" />
                </td>
            </tr>
        </table>
    </div>
    <div title="優惠比例設置">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ico/cog_32x32.png" />
                    <asp:Label ID="Label1" runat="server" Text="優惠比例設置" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="角色名" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="LbRole" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.RoleName") %>'></asp:Label>
                                    <asp:Label ID="LbJuese" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="One" HeaderText="一級用戶" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Two" HeaderText="二級用戶" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Left">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Three" HeaderText="三級用戶" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Four" HeaderText="四級用戶" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Five" HeaderText="五級用戶" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="100" UpdateText="保存">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999" align="center">
            <tr>
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label2" runat="server" Text="客戶等級說明" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnSaveRemark" runat="server" Text="保存" />
            </tr>
            <tr align="center">
                <td style="font-weight: bold" width="10%">
                    客戶等級
                </td>
                <td style="font-weight: bold">
                    說明
                </td>
            </tr>
            <tr align="center">
                <td>
                    一級
                </td>
                <td>
                    <asp:TextBox ID="TxtCusOne" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    二級
                </td>
                <td>
                    <asp:TextBox ID="TxtCusTwo" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    三級
                </td>
                <td>
                    <asp:TextBox ID="TxtCusThree" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    四級
                </td>
                <td>
                    <asp:TextBox ID="TxtCusFour" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td>
                    五級
                </td>
                <td>
                    <asp:TextBox ID="TxtCusFive" runat="server" Width="80%"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
