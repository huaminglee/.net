<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewDept.aspx.cs" Inherits="NewDept" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>新增部门</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBord.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <script>
        function ltips(msg) {
            $.layer({
                type: 1,
                shade: [0],
                area: ['200px', '20px'],
                title: false,
                border: [0],
                shade: [0],
                page: {
                    html: msg
                }
            });
        }
    </script>
</head>
<body>
    <form id="nForm" runat="server">
        <div class="NewDept">
            <table class="Form_Main" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td>上级部门</td>
                    <td>
                        <asp:DropDownList ID="ddlDept_List" runat="server" CssClass="input" Width="213" Height="30px"></asp:DropDownList></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>部门名称</td>
                    <td>
                        <asp:TextBox ID="txtDeptName" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>部门简称</td>
                    <td>
                        <asp:TextBox ID="txtDeptName_Jc" runat="server" CssClass="input inpute" MaxLength="50"></asp:TextBox></td>
                    <td class="ImpTips"></td>
                </tr>
                <tr>
                    <td>部门排序</td>
                    <td>
                        <asp:TextBox ID="txtSort" runat="server" CssClass="input inpute" onblur="javascript:return check_isnum();" onkeydown="javascript:return check_isnum();" MaxLength="9"></asp:TextBox></td>
                    <td class="ImpTips">*</td>
                </tr>
                <tr>
                    <td>部门描述</td>
                    <td>
                        <asp:TextBox ID="txtReMark" runat="server" CssClass="input inpute" TextMode="MultiLine" Height="60px" MaxLength="249"></asp:TextBox></td>
                    <td class="ImpTips"></td>
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
