<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipManageDetail.aspx.vb"
    Inherits="CMCFileManage.EquipManageDetail" %>

<%@ Register src="../EFlowNet/Doc/Modules/CtlWFActionList.ascx" tagname="CtlWFActionList" tagprefix="uc1" %>

<%@ Register src="../UCtl/UcFileDetail.ascx" tagname="UcFileDetail" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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

    <script src="../NewScript/UIHelper.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div >
        
        <uc1:CtlWFActionList ID="CtlWFActionList1" runat="server" />
        
    </div>
    <div style="clear: both">
    </div>
    <div align="center" style="color: #0066FF; font-size: 20px; font-family: 標楷體">
        <asp:Label ID="Label1" runat="server" Text="儀器設備清單"></asp:Label>
        <hr />
    </div>
    <div>
        <table border="1" cellspacing="0" cellpadding="0" bordercolor="#000000" bordercolordark="#FFFFFF"
            align="left" width="100%">
            <tr>
                <td bgcolor="#E5E5E5">
                    設備名稱
                </td>
                <td>
                    <asp:TextBox ID="TXTEquipName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    管制號碼
                </td>
                <td>
                    <asp:TextBox ID="TXTControlNO" runat="server"></asp:TextBox>
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
                    儀器型號
                </td>
                <td>
                    <asp:TextBox ID="TXTEquipModel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    主要規格
                </td>
                <td>
                    <asp:TextBox ID="TXTSpecification" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    所屬實驗室
                </td>
                <td>
                    <asp:DropDownList ID="DPLDept" runat="server" Width="153px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="#E5E5E5">
                    區域位置
                </td>
                <td>
                    <asp:DropDownList ID="DPLqyulocation" runat="server" Width="153px">
                    </asp:DropDownList>
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
                    有無附件
                </td>
                <td>
                    <asp:RadioButtonList ID="RDOIsHasDetail" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem>有</asp:ListItem>
                        <asp:ListItem>無</asp:ListItem>
                    </asp:RadioButtonList>
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
            <tr>
                <td bgcolor="#E5E5E5">
                    附件
                </td>
                <td>
                    &nbsp;
                    <uc2:UcFileDetail ID="UcFileDetail1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="編輯" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DetailName" HeaderText="附件名稱" />
                <asp:BoundField DataField="EquipModel" HeaderText="型號" />
                <asp:BoundField DataField="DetailControlNO" HeaderText="管制號碼" />
                <asp:BoundField DataField="SerialNumber" HeaderText="序列號" />
                <asp:BoundField DataField="MainSpecification" HeaderText="規格" />
                <asp:BoundField DataField="EquipNum" HeaderText="數量" />
                <asp:BoundField DataField="EquipLocation" HeaderText="放置地點" />
                <asp:BoundField DataField="KeepUser" HeaderText="保管人" />
                <asp:BoundField DataField="Extend5" HeaderText="備註" />
            </Columns>
        </asp:GridView>
    </div>
    <div align="left" style="color: #CC0000; font-size: 16px; font-family: 標楷體">
        文件變更履歷</div>
    <div>
        <hr />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            Width="100%" HorizontalAlign="Left">
            <Columns>
                <asp:BoundField DataField="ChangeUser" HeaderText="變更人" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
    <div style ="display :none ">
    <asp:HiddenField ID="HidCanEdit" runat ="server" Value ="0" />
    </div>
    </form>
</body>
</html>
