<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OtherFileDetail.aspx.vb"
    Inherits="CMCFileManage.OtherFileDetail" %>

<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        .style11
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
            runat="server">編輯</asp:LinkButton>
        <asp:LinkButton ID="LinkSave" Visible="false" class="easyui-linkbutton" plain="true"
            iconCls="icon-save" runat="server">保存</asp:LinkButton>
        <asp:LinkButton ID="LinkLeave" class="easyui-linkbutton" plain="true" iconCls="icon-back"
            runat="server">離開</asp:LinkButton>
    </div>
    <div style="clear: both">
    </div>
    <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <hr />
    </div>
    <div align="left" style="color: #CC0000; font-size: 16px; font-family: 標楷體">
        HONG HAI PERCISION INDUSTRY CO.,LTD.
    </div>
    <div align="left" style="float: left; width: 50%">
        <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
            bordercolordark="#FFFFFF" align="left" width="100%">
            <tr >
                <td colspan="2" bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/personal.png" />
                    <asp:Label ID="Label5" runat="server" Text="文件基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr id="biaohao" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label2" runat="server" Text="文件編號"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtFileBH" runat="server"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label3" runat="server" Text="文件名稱"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtFileName" runat="server"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr id="banci" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label4" runat="server" Text="版次"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtStandardVersion" runat="server"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr id="laiyuan" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label7" runat="server" Text="文件來源"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtLaiyuan" runat="server"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr id="shiyanshi">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label9" runat="server" Text="所屬實驗室"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="DPLDepth" runat="server" Width="153px">
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr id="shenqingren" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label12" runat="server" Text="申請人"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtApplyUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="yyzt" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label13" runat="server" Text="標準應用狀態"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="CHBztck" runat="server" Text="參考" />
                    <asp:CheckBox ID="CHBztsy" runat="server" Text="使用" />
                </td>
            </tr>
            <tr id="ccfangshi" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label14" runat="server" Text="標準存儲方式"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="CHBcczd" runat="server" Text="紙檔" />
                    <asp:CheckBox ID="CHBccdzd" runat="server" Text="電子檔" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label15" runat="server" Text="區域位置"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DplQuyuLocation" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="remark" runat="server">
                <td bgcolor="#F3F3F3">
                    <asp:Label ID="Label11" runat="server" Text="備註"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtRemark" runat="server"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="float: right; width: 48%;">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image2" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label6" runat="server" Text="文件內容" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image3" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/topdf.png" />
                    <asp:Label ID="Label8" runat="server" Text="附加檔案" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="clear: both">
    </div>
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50">
                    <asp:Image ID="Image4" runat="server"  Style="vertical-align: middle" ImageUrl="~/Images/ico/history.png" />
                    <asp:Label ID="Label10" runat="server" Text="文件變更履歷" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ChangeUser" HeaderText="變更人" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
