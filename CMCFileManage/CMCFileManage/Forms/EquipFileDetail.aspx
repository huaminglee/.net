<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipFileDetail.aspx.vb"
    Inherits="CMCFileManage.EquipFileDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="Ie6addbgiframe.js" type="text/javascript"></script>
</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div>
                    <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
                </div>
                <div style="clear: both">
                </div>
                <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
                    <asp:Label ID="Label1" runat="server" Text="儀器設備附件"></asp:Label>
                    <hr />
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
                                align="left" width="400px">
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        所屬實驗室
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DPLDept" runat="server" Width="155px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        區域位置
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DPLQuLocation" runat="server" Width="155px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        設備名稱
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DPLEquipname" runat="server" Width="155px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        管制號碼
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DPLEquipcontrolno" runat="server" Width="155px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        廠商
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTManuFacturer" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        附件名稱
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTDetailName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        附件管制號碼
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTDetailControlNO" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        儀器型號
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTEquipModel" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        序列號
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTSerialNumber" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        主要規格
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTMainSpecification" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        數量
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTEquipNum" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        放置地點
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTEquipLocation" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        保管人
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTKeepUser" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#E5E5E5">
                                        備註
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TXTRemark" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="clear: both">
                </div>
                <div align="left" style="color: #CC0000; font-size: 16px; font-family: 標楷體">
                    文件變更履歷</div>
                <div>
                    <hr />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="400px">
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
                    <hr />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
