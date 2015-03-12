<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dept_DefaultPerson.aspx.cs" Inherits="SysManege_Dept_DefaultPerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>部门指定接收人员</title>
    <link rel="stylesheet" type="text/css" href="/CSS/MainBoard.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/PurTree.css" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            chkSel();
        });
            function chkSel() {
                $('input[name="rbtn_chk"]').each(function () {
                    if (this.value == $("#hidUserId").val())
                        $(this).attr("checked", "checked");
                });
            };
    </script>
</head>
<body>
    <form id="uFrom" runat="server">
        <div class="NewDept">
            <table class="Form_Main_CSS" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td class="Form_Main_td" style="width: 100px;">部门名称</td>
                    <td class="Form_Main_td">
                        <asp:Label ID="txtDeptName" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="Form_Main_td">指定人员</td>
                    <td class="Form_Main_td" style="height: 280px">
                        <div class="purTree_r">
                            <asp:Label runat="server" ID="lblMark" Font-Size="12px"></asp:Label>
                            <table class="Form_Main_user" cellpadding="0px" cellspacing="0px">
                                <asp:Repeater ID="rpt_PersonList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;<input type="radio" name='rbtn_chk' id="rbtn_chk" onclick="GetValue(this);"  value='<%# Eval("USER_ID") %>'/>&nbsp;
                                                <%# Eval("FULL_NAME") %> [<%# Eval("LOGIN_NAME") %>]
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="Form_Main_td" colspan="2" style="height: 36px; line-height: 36px; text-align: center;">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="subBtn" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
            <asp:HiddenField ID="hidUserId" runat="server" Value="" />
        </div>
        <script type="text/javascript">
            function GetValue(e) {
                $("#hidUserId").val($(e).val());
            }
    </script>
    </form>
</body>
</html>
