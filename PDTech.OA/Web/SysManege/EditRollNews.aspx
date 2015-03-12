<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRollNews.aspx.cs" Inherits="SysManege_EditRollNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>编辑新闻</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/detail.css?t=" <%=t_rand %> />
    <style type="text/css">
        .let2
        {
            letter-spacing: 2px;
        }

        .let6
        {
            letter-spacing: 6px;
        }
        .rblStyle{width:100%;height:auto;}  
        .rblStyle input{border-style:none;} 
        #rblOption tr td { padding:0px 30px 0px 0px;  font-size:larger; }
    </style>
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <script type="text/javascript">
        function checkInput() {
            if ($("#txtTitle").val() == "") {
                layer.alert("新闻标题不能为空！");
                return false;
            } else if ($("#txtContent").val() == "") {
                layer.alert("新闻内容不能为空！");
                return false;
            } 
            return true;
        }

        function doContinue() {
            if (window.confirm("新增新闻成功！\r\n是否继续添加？")) {
                //window.parent.doRefresh();
                $("#txtTitle").val("");
                $("#txtContent").val("");
                $("#ddlIsRolling").find("option[value='0']").attr("selected", true);
            } else {
                window.parent.doRefresh();
                window.parent.layer.closeAll();
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="滚动新闻"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 120px; text-align: right;"><span>新闻标题</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtTitle" CssClass="input input664" Style="resize: none;" MaxLength="30"></asp:TextBox>
                                 
                            </td>
                            <td>
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 120px; text-align: right;"><span>新闻内容</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtContent" CssClass="input inputArea664" Style="resize: none;" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                            </td>
                            <td>
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 120px; text-align: right;"><span>是否滚动</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:DropDownList ID="ddlIsRolling" runat="server" CssClass="input input69">
                                    <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="con_oper">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn_submit con_oper_btn let6" 
                        OnClientClick=" return checkInput();" Text="保存" OnClick="btnSave_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.doClose();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
