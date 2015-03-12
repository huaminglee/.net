<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeptShowInfo.aspx.cs" Inherits="DeptShowInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门信息详情</title>
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
                        <asp:Label ID="txtParentName" runat="server" Text=""></asp:Label></td>

                </tr>
                <tr>
                    <td>部门名称</td>
                    <td>
                        <asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>部门简称</td>
                    <td>
                        <asp:Label ID="txtDeptName_Jc" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>部门排序</td>
                    <td>
                        <asp:Label ID="txtSort" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>部门描述</td>
                    <td>
                        <asp:Label ID="txtReMark" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
