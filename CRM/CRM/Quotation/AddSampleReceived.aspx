<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddSampleReceived.aspx.vb"
    Inherits="CRM.AddSampleReceived" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="Stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="../NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="AddSampleRecevied.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ReadCard() {
            var a = 1;
            var b;
            var c;
            var com = new String(document.getElementById("DDLcomNum").value);

            com = com.charAt(com.length - 1);

            if (com == "") {
                alert("請檢查讀卡機連接");
            } else {

                var cardReader1 = document.getElementById("cardReader1");
                a = cardReader1.GetCardID(com);

                if (a == "") {
                    alert("請檢查讀卡機連接,請選擇正確的串口，放置好廠牌");
                } else {
                    var ss = a.split('|');
                    b = ss[0];
                    c = ss[1];
                    document.getElementById("TxtKDHumanNO").value = b; //工號
                    document.getElementById("TxtKDHumanName").value = c; //姓名
                    document.getElementById("Hiddenhumanno").value = b;
                    document.getElementById("Hiddenhumanname").value = c;
                }

            }

        }
        function btnRead_onclick() {
            ReadCard();
        }
    </script>

    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
        #btnRead
        {
            width: 154px;
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="title" align="center" 
        style="font-size: 20px; font-family: SimSun; font-weight: bold;">
        接收樣品</div>
    <div id="simplesinfo">
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" colspan="2">
                    <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/sample.png" />
                    <asp:Label ID="Label7" runat="server" Text="收件信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    客戶：
                </td>
                <td>
                    <asp:TextBox ID="TxtCustomerName" runat="server" Width="400px"></asp:TextBox>
                    &nbsp;輸入關鍵字以搜尋（客戶名為簡體中文）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    業務員：
                    <asp:Label ID="LbPersonIncharge" runat="server" ForeColor="Blue"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; 郵箱：<asp:Label ID="LbEmail" runat="server" ForeColor="#0033CC"></asp:Label>
                    <asp:HiddenField ID="HiddenCustomerPKID" Value="0" runat="server" />
                    <asp:HiddenField ID="HiddenCustomerName" runat="server" />
                    <asp:HiddenField ID="HiddenPersonIncharge" runat="server" />
                    <asp:HiddenField ID="HiddenEmail" runat="server" />
                    <asp:HiddenField ID="HiddenPersonSid" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    樣品：
                </td>
                <td>
                    <asp:TextBox ID="TxtSamples" runat="server" Width="400px"></asp:TextBox>
                    總數：<asp:TextBox ID="TxtSamplesNums" Text="1" runat="server" Width="56px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    快遞信息：
                </td>
                <td>
                    <asp:TextBox ID="TxtCourier" runat="server" Width="400px"></asp:TextBox>
                    單號：<asp:TextBox ID="TxtCourierNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    說明：
                </td>
                <td>
                    <asp:TextBox ID="TxtRemark" runat="server" Height="68px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    收件人員：
                </td>
                <td>
                    <asp:TextBox ID="TxtAcceptUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    收件日期：
                </td>
                <td>
                    <asp:TextBox ID="TxtReachTime" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    收件地點：
                </td>
                <td>
                    <asp:DropDownList ID="DplReceivedAddress" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnGet" runat="server" Height="46px" class="button" Text="收件并通知業務員" Width="145px" />
                </td>
            </tr>
        </table>
        <table id="signtable" runat="server" visible="false" width="100%" border="1" cellpadding="0"
            cellspacing="0" bordercolordark="#FFFFFF" bordercolor="#999999">
            <tr>
                <td bgcolor="#E6E6E6" height="50" colspan="4">
                    <asp:Image ID="Image1" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/birthday.png" />
                    <asp:Label ID="Label1" runat="server" Text="簽收人信息" Font-Bold="True" Font-Size="14px"></asp:Label>
                    &nbsp;
                </td>
                <td bgcolor="#E6E6E6" height="50">
                    &nbsp;</td>
            </tr>
            <tr>
                <td nowrap style="width: 80px;">
                    <span>簽收人工號： </span>
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="TxtKDHumanNO"></asp:TextBox>
                    <asp:HiddenField ID="Hiddenhumanno" runat="server" />
                    <asp:HiddenField ID="Hiddenhumanname" runat="server" />
                </td>
                <td style="width: 180px;">
                    <span>簽收人姓名： </span>
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="TxtKDHumanName"></asp:TextBox>
                    <asp:DropDownList ID="DDLcomNum" runat="server" Width="65px">
                        <asp:ListItem>COM1</asp:ListItem>
                        <asp:ListItem>COM2</asp:ListItem>
                        <asp:ListItem >COM3</asp:ListItem>
                        <asp:ListItem>COM4</asp:ListItem>
                        <asp:ListItem>COM5</asp:ListItem>
                        <asp:ListItem>COM6</asp:ListItem>
                        <asp:ListItem Selected="True">COM7</asp:ListItem>
                        <asp:ListItem>COM8</asp:ListItem>
                        <asp:ListItem>COM9</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left">
                    &nbsp;                    <div id="duka" runat ="server" >
                    <input id="btnRead" type="button" value="讀卡"  class="button" onclick="return btnRead_onclick()" />
                    <object id="cardReader1" classid="clsid:B6313872-8F4C-47A7-94D9-517949FAAF47" 
                            codebase="setup.exe">
                    </object>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 80px;">
                    <span class="ContentText">備註： </span>
                </td>
                <td align="left" colspan="4">
                    <asp:TextBox runat="server" ID="txtKDRemarkInfo" Width="400px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80px;">
                    簽收時間：
                </td>
                <td align="left" colspan="4">
                    <asp:Label ID="LbSigngtime" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px;">
                </td>
                <td align="left" colspan="4">
                    <asp:Button ID="Button1" runat="server" Height="46px"  class="button" Text="確定簽收" Width="154px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
