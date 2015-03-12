<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusOppDetail.aspx.vb"
    Inherits="CRM.BusOppDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="BussOpp.js" type="text/javascript"></script>

    </head>
<body>
    <form id="form1" runat="server">
    <div id="title" style="height: 30px; font-size: 20px;" align="center">
        <asp:Label ID="LbTitle" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="LinkBack" class="easyui-linkbutton" iconcls="icon-back" plain="true"
            runat="server">返回列表</asp:LinkButton>
        &nbsp;&nbsp;<asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true"
            iconcls="icon-edit" runat="server">編輯</asp:LinkButton>
    </div>
    <div id="BussoppEdit" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="4" bgcolor="#E6E6E6">
                    <asp:Image ID="Image3" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label8" runat="server" Text="業務機會信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="80px">
                    業務機會名：
                </td>
                <td>
                    <asp:TextBox ID="TxtOpportName" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    機會所有人：
                </td>
                <td>
                    <asp:DropDownList ID="DPLOppOwoner" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    金額：
                </td>
                <td>
                    <asp:TextBox ID="TxtAmounts" text="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    客戶名：
                </td>
                <td>
                    <asp:TextBox ID="TxtCustomerName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    類型：
                </td>
                <td>
                    <asp:DropDownList ID="DPLType" runat="server">
                        <asp:ListItem>檢測</asp:ListItem>
                        <asp:ListItem>銷售</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    結束日期：
                </td>
                <td>
                    <asp:TextBox ID="TxtEndDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    階段：
                </td>
                <td>
                    <asp:DropDownList ID="DPLCategory" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    下一階段：
                </td>
                <td>
                    <asp:DropDownList ID="DPLNextCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    來源：
                </td>
                <td>
                    <asp:TextBox ID="TxtCustomerSources" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    可能性：
                </td>
                <td>
                    <asp:TextBox ID="TxtPossibility" text="0" class="easyui-numberbox" data-options="min:0,max:100,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    預期收入：</td>
                <td>
                    <asp:TextBox ID="TxtExcepIncome" text="0" class="easyui-numberbox" data-options="min:0,precision:0,required:true" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    備註：</td>
                <td>
                    <asp:TextBox ID="TxtRemark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="BtnSave" runat="server" Text="保存" />
&nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" runat="server" Text="取消" />
                </td>
            </tr>
        </table>
    </div>
    <div id="BussoppShow" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td colspan="4" bgcolor="#E6E6E6">
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/baseinfo.png" />
                    <asp:Label ID="Label1" runat="server" Text="業務機會信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="80px" align="right">
                    業務機會名：
                </td>
                <td>
                    <asp:Label ID="LbOpportName" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    機會所有人：
                </td>
                <td>
                    <asp:Label ID="LbOppOwoner" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    金額：
                </td>
                <td>
                    <asp:Label ID="LbAmounts" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    客戶名：
                </td>
                <td>
                    <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    類型：
                </td>
                <td>
                    <asp:Label ID="LbType" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    結束日期：
                </td>
                <td>
                    <asp:Label ID="LbEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    階段：
                </td>
                <td>
                    <asp:Label ID="LbCategory" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    下一階段：
                </td>
                <td>
                    <asp:Label ID="LbNextCategory" runat="server" Text=""></asp:Label>
                &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    來源：
                </td>
                <td>
                    <asp:Label ID="LbCustomerSources" runat="server" Text=""></asp:Label>
                &nbsp;</td>
                <td align="right">
                    可能性：
                </td>
                <td>
                    <asp:Label ID="LbPossibility" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    預期收入：</td>
                <td>
                    <asp:Label ID="LbExceptionIncome" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    備註：</td>
                <td>
                    <asp:Label ID="LbRemark" runat="server"></asp:Label>
                &nbsp;</td>
            </tr>
        </table>
    </div>
    <div id="markplan" runat="server">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="14px" 
                        Text="市場活動影響"></asp:Label>
                     <a id="addtomark" onclick ="addtomark()" class="easyui-linkbutton" iconcls="icon-add" plain="true">添加到市場影響</a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="LbMarkPlanpkid" runat="server" Visible ="false"  Text='<%#DataBinder.Eval(Container,"DataItem.pkid") %>'></asp:Label>
                                    <asp:HyperLink ID="HLDetail" Target="_self" runat="server" ToolTip="編輯" ImageUrl="../Images/ico/pen.png">查看</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MarkPlanName" HeaderText="市場活動名" />
                            <asp:BoundField DataField="Type" HeaderText="類型" />
                            <asp:BoundField DataField="Category" HeaderText="狀態" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="../Images/ico/trash.png"
                                        CommandName="Delete"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="busemptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/information.png" />
                        &nbsp;&nbsp;&nbsp; 沒有找到相關營銷活動，您可以新建或添加。</div>
                          <div id="sysinfo" runat ="server" align="center" >
        
        <table width ="100%">
            <tr>
                <td colspan="2" align ="left" style="font-size: 14px; font-weight: bold"  >
                    &nbsp;系統信息</td>
            </tr>
            <tr>
                <td style="margin-left: 40px">
                    創建人：<asp:Label ID="LbInsertPerson" runat="server"></asp:Label>
                </td>
                <td align="left">
                    上次修改人：<asp:Label ID="LbLastChange" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    
    <div style ="display :none ">
    <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:HiddenField ID="HiddenPKID" Value ="0" runat="server" />
    </div>
    </form>
</body>
</html>
