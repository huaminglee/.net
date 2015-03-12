<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditQuestion.aspx.cs" Inherits="SysManege_EditQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>编辑试题</title>
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
                layer.alert("题目不能为空！");
                return false;
            } else if ($("#txtOptionA").val() == "") {
                layer.alert("选项A不能为空！");
                return false;
            } else if ($("#txtOptionB").val() == "") {
                layer.alert("选项B不能为空！");
                return false;
            } else if ($("#txtOptionC").val() == "") {
                layer.alert("选项C不能为空！");
                return false;
            } else if ($("#txtOptionD").val() == "") {
                layer.alert("选项D不能为空！");
                return false;
            }
            return true;
        }

        function doContinue() {
            if (window.confirm("新增试题成功！\r\n是否继续添加？")) {
                //window.parent.doRefresh();
                $("#txtTitle").val("");
                $("#txtOptionA").val("");
                $("#txtOptionB").val("");
                $("#txtOptionC").val("");
                $("#txtOptionD").val("");
                $("#ddlScore").find("option[value='1']").attr("selected", true);
                $("input[type=radio]:eq(0)").attr("checked", "checked");
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
                    <asp:Label runat="server" ID="lbTopTitle" Text="廉政教育在线测试题库"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>题目</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtTitle" CssClass="input inputArea664_60" Style="resize: none;" TextMode="MultiLine" MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>选项A</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtOptionA" CssClass="input inputArea664_60"  Style="resize: none;" TextMode="MultiLine"  MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>选项B</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtOptionB" CssClass="input inputArea664_60"  Style="resize: none;" TextMode="MultiLine"  MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>选项C</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtOptionC" CssClass="input inputArea664_60" Style="resize: none;" TextMode="MultiLine"  MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>选项D</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtOptionD" CssClass="input inputArea664_60" Style="resize: none;" TextMode="MultiLine" MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>分值</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:DropDownList ID="ddlScore" runat="server" CssClass="input input69">
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <%--<asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>答案</span></td>
                            <td class="con_item_left" colspan="3">
                                <div class="rblStyle">
                                    <asp:RadioButtonList ID="rblOption" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="A" Selected="True" >A</asp:ListItem>
                                        <asp:ListItem Value="B" >B</asp:ListItem>
                                        <asp:ListItem Value="C" >C</asp:ListItem>
                                        <asp:ListItem Value="D" >D</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
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