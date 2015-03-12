.<%@ Page Language="vb" AutoEventWireup="false" ValidateRequest="false" CodeBehind="SysNewsDetail.aspx.vb"
    Inherits="CMCFileManage.SysNewsDetail" %>

<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最新公告</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../IconsThemes/icon.css" rel="Stylesheet" type="text/css" />
    <link href="../NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../NewScript/jquery-1.7.2.min.js"></script>

    <script src="../NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript" defer="defer" src="../NewScript/easyloader.js"></script>

    <script type="text/javascript" src="../NewScript/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function() {
            $('#LinkSave').click(function() {
                if ($("#form1").form("validate")) {
                    return true;
                }
                else {
                    return false;
                }
            });
        });

        $(function() {
            $('#DDLServiceName').change(function() {
                var checkValue = $("#DDLServiceName").val();
                switch (checkValue) {
                    case "0":
                        $('#FWDecription').text("在登錄測試申請系統後在會首頁右下角提示該消息");
                        break;
                    case "-1":
                        $('#FWDecription').text("在開啟申請單時提示該消息");
                        break;
                    case "-2":
                        $('#FWDecription').text("在登錄CRM系統後提示該消息");
                        break;
                    case "-3":
                        $('#FWDecription').text("在登錄品質管理系統後提示該消息");
                        break;
                    default:
                        $('#FWDecription').text("在填寫申請單，選擇該測試類型時提示該消息");
                        break;
                }


            });
        })
    </script>

</head>
<body  style="background-image: url('../Images/ico/gonggao.png'); background-repeat: no-repeat">
    <form id="form1" runat="server">
    <div id="divedit" runat="server">
        <table>
            <tr>
                <td>
                    消息編號
                </td>
                <td>
                    <asp:TextBox ID="TxtID" ReadOnly="true" runat="server"></asp:TextBox>
                </td>
                <td>
                    消息主題
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNewsTitle" CssClass="easyui-validatebox" required="true" Width="550px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    發布範圍
                </td>
                <td>
                    <asp:DropDownList ID="DDLServiceName" Width="200" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    提醒結束時間
                </td>
                <td>
                    <asp:TextBox ID="txtEndTime" Width="120" CssClass="easyui-validatebox" required="true"
                        runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <font color="red">
                        <p id="FWDecription">
                            在登錄系統後在會首頁右下角提示該消息
                        </p>
                    </font>
                </td>
            </tr>
            <tr>
                <td>
                    消息內容
                </td>
                <td colspan="4">
                    <DNTB:WebEditor ID="WebEditor1" Width="780px" Skin="skin/xp/" MenuConfig="Custom3.config"
                        runat="server" LeftAreaAlign="center" LeftAreaWidth="38%" Height="350" RightAreaWidth="62%">
                    </DNTB:WebEditor>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center " colspan="4">
                    <asp:LinkButton ID="LinkSave" class="easyui-linkbutton" plain="true" iconCls="icon-ok"
                        runat="server">發佈</asp:LinkButton>
                    <asp:LinkButton ID="LinkCancel" class="easyui-linkbutton" plain="true" iconCls="icon-cancel"
                        runat="server">取消</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div id="sea" runat="server">
        <%--<table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#808080">--%>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="left" style="padding-left: 200px" width="50%">
                                公告作者：<asp:Label ID="LbZZ" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center">
                                公告日期：<asp:Label ID="LBDate" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-left: 200px">
                                發佈範圍：<asp:Label ID="LbFanwei" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                有效期至：<asp:Label ID="LbYOUxiaodate" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
       <%-- </table>--%>
        <br />
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#808080">
            <tr>
                <td style="font-weight: bold">
                    公告主題：<asp:Label ID="LbSubject" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
            bordercolor="#808080">
            <tr>
                <td style="font-weight: bold">
                    公告內容
                </td>
            </tr>
            <tr>
                <td style="font-size: 12px">
                    <asp:Label ID="LbContent" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkEdit" runat="server" class="easyui-linkbutton" iconCls="icon-edit"
                        plain="true" Visible="false">編輯</asp:LinkButton>
                    <asp:LinkButton ID="LinkClose" class="easyui-linkbutton" plain="true" iconCls="icon-cancel"
                        runat="server">關閉</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
