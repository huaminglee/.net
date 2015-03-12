<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUserInfo.aspx.cs" Inherits="NewUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>新增用户</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBord.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
</head>
<body>
    <form id="uFrom" runat="server">
        <div class="NewDept">
            <table class="Form_Main" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>部门名称</td>
                    <td>
                        <asp:DropDownList ID="ddlDept_List" runat="server" CssClass="input" Width="213"></asp:DropDownList></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>登录帐号</td>
                    <td>
                        <asp:TextBox ID="txtLoginName" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr runat="server" id="tr_Pwd">
                    <td>密码</td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="input inpute" MaxLength="16" TextMode="Password"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr runat="server" id="tr_rePwd">
                    <td>确认密码</td>
                    <td>
                        <asp:TextBox ID="txtRePwd" runat="server" CssClass="input inpute" MaxLength="16" TextMode="Password"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>姓名</td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>电话号码</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input inpute"  MaxLength="30" onblur="javascript:return check_isphone();" onkeydown="javascript:return check_isphone();"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>手机号码</td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="input inpute" onblur="javascript:return check_isnum();" onkeydown="javascript:return check_isnum();" MaxLength="11"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>职务</td>
                    <td>
                        <asp:TextBox ID="txtDutyInfo" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>显示名称</td>
                    <td>
                        <asp:TextBox ID="txtPublicName" runat="server" CssClass="input inpute" MaxLength="20"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>邮箱</td>
                    <td>
                        <asp:TextBox ID="txtEMaile" runat="server" CssClass="input inpute" MaxLength="100"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input inpute" MaxLength="2000"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>用户排序</td>
                    <td>
                        <asp:TextBox ID="txtSort" runat="server" CssClass="input inpute" onblur="javascript:return check_isnum();" onkeydown="javascript:return check_isnum();" MaxLength="11"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="Form_Main_Btnpanel">
                            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="subBtn" OnClick="btnSave_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
