<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QcFilePrint.aspx.vb" Inherits="CMCFileManage.QcFilePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style11
        {
            width: 100%;
        }
        .cssnovisible
        {
            display: none;
        }
        .cssvisible
        {
            display: inline;
        }
    </style>

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        $(function() {
            doPrint();
        });
        function doPrint() {
            var bdhtml = window.document.body.innerHTML;

            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            PageSetup_Null();
            window.print();
        }
        var hkey_root, hkey_path, hkey_key
        hkey_root = "HKEY_CURRENT_USER"
        hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"

        // 设置页眉页脚为空
        function PageSetup_Null() {
            try {
                var RegWsh = new ActiveXObject("WScript.Shell");
                hkey_key = "header";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
                hkey_key = "footer";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
            }
            catch (e) { }
        }
        // 设置页眉页脚为默认值
        function PageSetup_Default() {
            try {
                var RegWsh = new ActiveXObject("WScript.Shell");
                hkey_key = "header";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P");
                hkey_key = "footer";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d");
            }
            catch (e) { }
        } 
    </script>

</head>
<body scroll="Auto">
    <form id="form1" runat="server">
    <!--startprint-->
    <div align="center">
        <div style="font-size: 14px; width: 700px; font-family: SimSun;" align="left">
            <div align="center" style="font-size: 24px;">
                <asp:Label ID="LbTitle" runat="server" Text="文件新版發行通知單" Font-Names="標楷體"></asp:Label>
            </div>
            <div>
                <table class="style11">
                    <tr>
                        <td align="left" colspan="3">
                            適用範圍&nbsp; ：
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CKBcq" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterValue1") %> '
                                        runat="server" />
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <asp:CheckBox ID="CKBcq" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterValue1") %> '
                                        runat="server" />
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            文件變更號：<asp:Label ID="LbRecordNo" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            生效日期：<asp:Label ID="LbEffectDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table width="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000"
                    bordercolordark="#FFFFFF">
                    <tr>
                        <td rowspan="10" style="width: 70px" align="center">
                            <asp:Label ID="Label4" runat="server" Text="本欄由提案人填寫" Width="12px"></asp:Label>
                        </td>
                        <td align="center" width="15%">
                            提案單位：
                        </td>
                        <td width="15%">
                            <asp:Label ID="LbApplyDept" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="15%" align="center">
                            提案人：
                        </td>
                        <td width="10%">
                            <asp:Label ID="LbApplyUser" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="15%" align="center">
                            提案日期：
                        </td>
                        <td width="20%">
                            <asp:Label ID="LbApplydate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            版次：
                        </td>
                        <td>
                            <asp:Label ID="LbFileVersion" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            總頁數：
                        </td>
                        <td>
                            <asp:Label ID="LbTotalpages" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            名稱：
                        </td>
                        <td>
                            <asp:Label ID="LbFileName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            文件編號：
                        </td>
                        <td>
                            <asp:Label ID="LbFileBH" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                        <td align="center">
                            變更原因：
                        </td>
                        <td colspan="3">
                            <asp:Label ID="LbChangeReason" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left">
                            變更前說明：<asp:Label ID="LbChangebef" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                        <td colspan="3" align="left">
                            變更後說明：<asp:Label ID="LbChangeaft" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            實驗室技術負責人：
                        </td>
                        <td colspan="5" align="left">
                            <asp:Label ID="Lblabtecnicperson" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="left">
                            會簽方式：
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="書面會簽" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="會議會簽" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBox3" runat="server" Text="無需會簽" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="40px">
                            <div style="float: left">
                                分發單位：</div>
                            <div style="float: right">
                                發行紙檔份數</div>
                        </td>
                        <td colspan="3">
                            <div style="float: left">
                                分發單位：</div>
                            <div style="float: right">
                                發行紙檔份數</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <table width="100%">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <td align="left" width="50%" nowrap="true" valign="top">
                                            <asp:CheckBox ID="CHBdept" Style="float: left" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterText") %> '
                                                runat="server" />
                                            <div id="divzdnums" runat="server" style="float: right;" class="cssnovisible">
                                                <asp:TextBox ID="TxtzdNums" Width="20px" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                                    Text="0" runat="server" BorderStyle="None" BorderColor="White"></asp:TextBox>份
                                            </div>
                                        </td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            是否教育訓練：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="center">
                            教育訓練單位：
                        </td>
                        <td>
                            <asp:Label ID="LbTeachDept" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                        <td align="center">
                            共發行紙檔文件份數：
                        </td>
                        <td>
                            <asp:Label ID="LbZdfenshu" runat="server" Text="Label"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2" style="width: 70px" align="center">
                            <asp:Label ID="Label1" runat="server" Text="核定" Width="12px"></asp:Label>
                        </td>
                        <td>
                            中心技術負責人：
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td>
                            中心質量負責人：
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="30px">
                            最高管理者核定：
                        </td>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="back1" visible="false" runat="server">
                        <td rowspan="2" style="width: 70px" align="center">
                            <asp:Label ID="Label2" runat="server" Text="本欄由品保填寫" Width="12px"></asp:Label>
                        </td>
                        <td colspan="3" height="40px">
                            <div style="float: left">
                                回收單位：</div>
                            <div style="float: right">
                                回收紙檔份數</div>
                        </td>
                        <td colspan="3">
                            <div style="float: left">
                                回收單位：</div>
                            <div style="float: right">
                                回收紙檔份數</div>
                        </td>
                    </tr>
                    <tr id="back2" visible="false" runat="server">
                        <td colspan="6">
                            <table width="100%">
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <td align="left" width="50%">
                                            <asp:CheckBox ID="CHBdept" Style="float: left" Text='<%# DataBinder.Eval(Container.DataItem,"ParameterText") %> '
                                                runat="server" />
                                            <div id="divzdnums" runat="server" style="float: right" class="cssnovisible">
                                                <asp:TextBox ID="TxtzdNums" Width="20px" class="easyui-numberbox" data-options="min:0,max:100,required:true,precision:0"
                                                    Text="0" runat="server" BorderStyle="None" BorderColor="White"></asp:TextBox>份
                                            </div>
                                        </td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!--endprint-->
    </form>
</body>
</html>
