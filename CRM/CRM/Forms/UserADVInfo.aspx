<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="UserADVInfo.aspx.vb"
    Inherits="CRM.UserADVInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyuinochange.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/locale/easyui-lang-zh_TW.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="UserADV.js" type="text/javascript"></script>

    <style type="text/css">
        #newPreview
        {
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);
        }
    </style>

    <script language="javascript" type="text/javascript">

        function PreviewImg(imgFile) {

            imgFile.select();

            var realpath = document.selection.createRange().text;

            if (CheckFile(imgFile)) {


                var oldimg = document.getElementById("Image1");
                if (oldimg != null) {
                    oldimg.style.display = "none";
                }

                var newPreview = document.getElementById("newPreview");
                newPreview.style.display = "block";
                newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = realpath;
            }

        }
 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkEdit" class="easyui-linkbutton" plain="true" iconCls="icon-edit"
            runat="server">修改</asp:LinkButton>
        <asp:LinkButton ID="LinkSave" Style="display: none" class="easyui-linkbutton" plain="true"
            iconCls="icon-save" runat="server">保存</asp:LinkButton>
        <a href="#" class="easyui-linkbutton" runat="server" visible="false" iconcls="icon-save"
            id="btnSave" plain="true" onclick="Saveuserinfo()">保存</a> <%--<a is="ishisback" runat="server"
                class="easyui-linkbutton" iconcls="icon-back" plain="true" onclick="self.location=document.referrer;">
                返回</a>--%>
                <asp:LinkButton ID="LinkBack"   class="easyui-linkbutton" plain="true"
            iconCls="icon-back" runat="server">返回</asp:LinkButton>
    </div>
    <div id="userinfo">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#FFFFFF"
            bordercolordark="#999999">
            <tr>
                <td align="right" style="color: #0099FF" width="100px">
                    姓名
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtName" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbName" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    身份證號
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtIDnumber" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbIDnumber" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td rowspan="3" width="150px" align="center" height="110px">
                    <div id="newPreview" style="width: 90px; height: 100px; position: relative; display: none;"
                        align="center">
                    </div>
                    &nbsp;<asp:Image ID="Image1" runat="server" Width="90" Height="100" Visible="false"
                        ImageUrl="~/UserPhoto/defaultimg.jpg" />
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    登錄名
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtUserSID" CssClass="easyui-validatebox" invalidMessage="登陸名已存在或包含非法字符!"
                        required="true" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbUserSID" runat="server" Text=""></asp:Label>
                    &nbsp; 
                    <asp:Label ID="LbNullIDinfo" Visible ="false"  runat="server" Text="（外部客戶建議使用郵箱作為登陸名。）"></asp:Label>
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    生日
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtBirthday" Text="1991-1-1" class="Wdate" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbBirthday" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    電話
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtPhone" Visible="false" class="easyui-validatebox" required="true"
                        missingmessage="電話為重要信息!" runat="server"></asp:TextBox>
                    <asp:Label ID="LbPhone" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    內部郵箱
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtEmail" Visible="false"  runat="server"></asp:TextBox>
                    <asp:Label ID="LbEmail" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    傳真
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtFax" runat="server"  Visible="False"></asp:TextBox>
                    <asp:Label ID="LbFax" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    外部郵箱
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtOutMail" runat="server" Visible="False" class="easyui-validatebox"
                        required="true" missingmessage="郵箱為重要信息!"></asp:TextBox>
                    <asp:Label ID="LbOutMail" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;<asp:FileUpload ID="FilePhoto" Visible="False" runat="server" onchange="PreviewImg(this)" />
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    職務
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtPosition" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbPosition" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    郵政編碼
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtZIPcode" Visible="False" class="easyui-numberbox" runat="server"></asp:TextBox>
                    <asp:Label ID="LbZIPcode" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    &nbsp;地址
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtAddress" runat="server" Visible="False"></asp:TextBox>
                    <asp:Label ID="LbAddress" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    學歷
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtDegree" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbDegree" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    專業
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtMajor" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbMajor" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    畢業院校
                </td>
                <td style="padding-left: 5px">
                    <asp:TextBox ID="TxtGraduated" Visible="False" runat="server"></asp:TextBox>
                    <asp:Label ID="LbGraduated" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    用戶類別
                </td>
                <td style="padding-left: 5px">
                    <asp:RadioButtonList ID="RDOUserCategory" Visible="False" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">內部客戶</asp:ListItem>
                        <asp:ListItem Value="2">外部客戶</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="LbUserCategory" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td align="right" style="color: #0099FF" width="100px">
                    性別
                </td>
                <td style="padding-left: 5px">
                    <asp:RadioButtonList ID="RDOsex" Visible="False" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                        <asp:ListItem Value="3" Selected="True">保密</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="LbSex" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
                <td width="150px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF" height="33px">
                    公司名
                </td>
                <td colspan="4" style="padding-left: 5px">
                    <input id="InpCustomerName" visible="False" runat="server" style="width: 500px"></input>
                    <asp:Image ID="Image2" Visible="False" Style="cursor: hand;" ToolTip="點擊選擇" ImageUrl="~/Images/search.png"
                        runat="server" onclick="GetCustomerDialog('#CustomerDialog', '#CustomerInfo', 'InpCustomerName', 'HiddenCustomerNmae','HiddenCustomerPKID')" />
                    <asp:Label ID="LbCustomerName" runat="server" Text=""></asp:Label>
                    &nbsp;<asp:HiddenField ID="HiddenCustomerNmae" Value="" runat="server" />
                    <asp:HiddenField ID="HiddenCustomerPKID" Value="0" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #0099FF">
                    說明
                </td>
                <td colspan="4" style="padding-left: 5px">
                    <asp:TextBox ID="TxtRemark" runat="server" Height="100px" TextMode="MultiLine" Width="500px"
                        Visible="False"></asp:TextBox>
                    <asp:Label ID="LbRemark" runat="server" Text=""></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="CustomerDialog" iconcls="icon-save" closed="true" title="請選擇客戶信息" runat="server">
        <div id="CustomerInfo" toolbar="#dlg-toolbar">
        </div>
        <div id="dlg-toolbar" style="display: none;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" style="padding-left: 2px">
                        <asp:Label ID="Label22" runat="server" Text="客戶名"></asp:Label>
                    </td>
                    <td style="text-align: right; padding-right: 2px">
                        <input class="easyui-searchbox" searcher="selectcustomer"></input>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
