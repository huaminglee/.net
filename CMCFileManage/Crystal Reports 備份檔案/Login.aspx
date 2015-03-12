<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="CMCFileManage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Shortcut Icon" href="favicon.ico" />
    <title>登入</title>
    <style type="text/css">
        a
        {
            color: #008EE3;
        }
        a:link
        {
            text-decoration: none;
            color: #008EE3;
        }
        A:visited
        {
            text-decoration: none;
            color: #666666;
        }
        A:active
        {
            text-decoration: underline;
        }
        A:hover
        {
            text-decoration: underline;
            color: #0066CC;
        }
        A.b:link
        {
            text-decoration: none;
            font-size: 12px;
            font-family: "Helvetica,微软雅黑,宋体";
            color: #FFFFFF;
        }
        A.b:visited
        {
            text-decoration: none;
            font-size: 12px;
            font-family: "Helvetica,微软雅黑,宋体";
            color: #FFFFFF;
        }
        A.b:active
        {
            text-decoration: underline;
            color: #FF0000;
        }
        A.b:hover
        {
            text-decoration: underline;
            color: #ffffff;
        }
        .table1
        {
            border: 1px solid #CCCCCC;
        }
        .font
        {
            font-size: 12px;
            text-decoration: none;
            color: #999999;
            line-height: 20px;
        }
        .input
        {
            font-size: 12px;
            color: #999999;
            text-decoration: none;
            border: 0px none #999999;
        }
        td
        {
            font-size: 12px;
            color: #007AB5;
        }
        form
        {
            margin: 1px;
            padding: 1px;
        }
        input
        {
            border: 0px;
            height: 26px;
            color: #007AB5; .unnamed1{border:thinnone#FFFFFF;}
        .unnamed1
        {
            border: thin none #FFFFFF;
        }
        select
        {
            border: 1px solid #cccccc;
            height: 18px;
            color: #666666; .unnamed1{border:thinnone#FFFFFF;}
        body
        {
            background-repeat: no-repeat;
            background-color: #9CDCF9;
            background-position: 0px 0px;
        }
        .tablelinenotop
        {
            border-top: 0px solid #CCCCCC;
            border-right: 1px solid #CCCCCC;
            border-bottom: 0px solid #CCCCCC;
            border-left: 1px solid #CCCCCC;
        }
        .tablelinenotopdown
        {
            border-top: 1px solid #eeeeee;
            border-right: 1px solid #eeeeee;
            border-bottom: 1px solid #eeeeee;
            border-left: 1px solid #eeeeee;
        }
        .style6
        {
            font-size: 9pt;
            color: #7b8ac3;
        }
    </style>

    <script type="text/javascript" language="javascript">
        if (window != top)
            top.location.href = "Login.aspx";



        function ChangeHumanIDToUpCase() {
            var HumanID = document.all["TxtUserName"].value;
            document.all["TxtUserName"].value = HumanID.toUpperCase();
        }
        
    </script>

</head>
<body style="width: 100%; height: 100%; background-color: #9CDCF9">
    <form id="form1" runat="server">
    <table width="681" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 120px">
        <tr>
            <td width="353" height="259" align="center" valign="bottom" background="Newstyle/login_1.gif">
                &nbsp;
            </td>
            <td width="195" background="Newstyle/login_2.gif">
                <table width="190" height="106" border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr>
                        <td colspan="2" height="50" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="60" height="30" align="left">
                            工號
                        </td>
                        <td>
                            <asp:TextBox ID="TxtUserName" Style="background: url(Newstyle/login_6.gif) repeat-x;
                                border: solid 1px #27B3FE; height: 20px; background-color: #FFFFFF" onkeyup="ChangeHumanIDToUpCase()"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="left">
                            密碼
                        </td>
                        <td>
                            <asp:TextBox ID="TxtPassword" Style="background: url(Newstyle/login_6.gif) repeat-x;
                                border: solid 1px #27B3FE; height: 20px; background-color: #FFFFFF" runat="server"
                                TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="40" colspan="2" align="center">
                            <div id="wronginfo" visible="false" runat="server">
                                <img src="Newstyle/tip.gif" width="16" height="16">
                                請勿非法登陸！
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td heigth="30" colspan="2">
                            &nbsp;
                            <asp:CheckBox ID="chkRem" runat="server" ForeColor="Black" Text="記住" TextAlign="Right" />
                            <asp:DropDownList ID="DPLChangqu" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Button1" Style="background: url(Newstyle/login_5.gif) no-repeat"
                                runat="server" Text="Sign In" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="133" background="Newstyle/login_3.gif">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
