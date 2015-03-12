<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OutFileDetail.aspx.vb"
    Inherits="CMCFileManage.OutFileDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UCtl/UcFileDetail.ascx" TagName="UcFileDetail" TagPrefix="uc1" %>
<%@ Register Src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" TagName="CtlWFActionList"
    TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/easyloader.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.bgiframe.js" type="text/javascript"></script>

    <script src="../NewScript/plugins/jquery.toggleLoading.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="Ie6addbgiframe.js" type="text/javascript"></script>

    <style type="text/css">
        .style11
        {
            width: 100%;
        }
    </style>
</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image5" runat="server" ImageUrl="../Images/blank.jpg" />
                <div>
                    <uc2:CtlWFActionList ID="CtlWFActionList1" runat="server" />
                </div>
                <div style="clear: both">
                </div>
                <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <hr />
                </div>
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <table style="height: 80px" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                                bordercolordark="#FFFFFF" align="left" width="100%">
                                <tr>
                                    <td bgcolor="#E4F1FA" colspan="2" height="50">
                                        <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/personal.png" />
                                        <asp:Label ID="Label8" runat="server" Text="文件基本信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="biaohao" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label2" runat="server" Text="文件編號"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFileBH" runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label3" runat="server" Text="文件名稱"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFileName" runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr id="banci" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label4" runat="server" Text="版次"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtStandardVersion" runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr id="yeshu" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label5" runat="server" Text="頁數"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txtyeshu" Text="0" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                            runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr id="zhangshu" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label6" runat="server" Text="份數"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFenshu" Text="0" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                            runat="server"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="laiyuan" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label7" runat="server" Text="文件來源"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtLaiyuan" runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr id="shiyanshi">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label9" runat="server" Text="所屬實驗室"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DPLDepth" runat="server" Width="153px">
                                        </asp:DropDownList>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label15" runat="server" Text="區域位置"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DplQuyuLocation" runat="server" Width="153px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="ccfangshi" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label14" runat="server" Text="標準存儲方式"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CHBcczd" runat="server" Text="紙檔" />
                                        <asp:CheckBox ID="CHBccdzd" runat="server" Text="電子檔" />
                                    </td>
                                </tr>
                                <tr id="buytime" runat="server" visible="false">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label19" runat="server" Text="購買時間"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtBuyTime" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="syyq" runat="server" visible="false">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label16" runat="server" Text="適用儀器"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtUseEquip" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="yongtu" runat="server" visible="false">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label17" runat="server" Text="用途"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtUseFor" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="beifendizhi" runat="server" visible="false">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label18" runat="server" Text="備份地址"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtBackupadd" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="remark" runat="server">
                                    <td bgcolor="#f3f3f3">
                                        <asp:Label ID="Label11" runat="server" Text="備註"></asp:Label>&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtRemark" runat="server" Width="90%"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                                bordercolor="#999999">
                                <tr>
                                    <td bgcolor="#E4F1FA" height="50">
                                        <asp:Image ID="Image2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/topdf.png" />
                                        <asp:Label ID="Label10" runat="server" Text="文件內容" Font-Bold="True" Font-Size="14px"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td bgcolor="#E4F1FA" height="50">
                                        <asp:Image ID="Image3" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/topdf.png" />
                                        <asp:Label ID="Label12" runat="server" Text="附加檔案" Font-Bold="True" Font-Size="14px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc1:UcFileDetail ID="UcFileDetail3" runat="server" />
                                        <uc1:UcFileDetail ID="UcFileDetail4" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <uc1:UcFileDetail ID="UcFileDetail2" runat="server" />
                                        <uc1:UcFileDetail ID="UcFileDetail1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <div style="clear: both">
                </div>
                <div>
                    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                        bordercolor="#999999">
                        <tr>
                            <td bgcolor="#E4F1FA" height="50">
                                <asp:Image ID="Image4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/ico/history.png" />
                                <asp:Label ID="Label13" runat="server" Text="文件變更履歷" Font-Bold="True" Font-Size="14px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="400px">
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
    </form>
</body>
</html>
