<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTesting.aspx.cs" Inherits="SysManege_EditTesting" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>编辑试卷</title>
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
        function doChecked() {
            var temp = $("input[name='rblTestCount']:checked").val();
            //alert(temp);
            if (temp == "自定义") {
                $("#txtDefineCount").attr('disabled', false);
            } else {
                $("#txtDefineCount").attr('disabled', true);
            }
        }

        function isInteger() {
            var str = document.getElementById('txtDefineCount').value.trim();
            if (str.length > 0) {
                //reg = /^[-+]?\d*$/;
                reg = /^[1-9]+$/;
                if (!reg.test(str)) {
                    layer.alert("对不起，您输入的整数类型格式不正确!");//请将“整数类型”要换成你要验证的那个属性名称！
                    return false;
                } else {
                    return true;
                }
            }
        }

        //判断输入的字符是否为整数    
        function checkInput() {
            var temp = $("input[name='rblTestCount']:checked").val();
            var str = document.getElementById('txtDefineCount').value.trim();
            reg = /^[0-9]+$/;
            if ($("#txtTestName").val() == "") {
                layer.alert("试卷名称不能为空！");
                return false;
            } else if (temp == "自定义") {
                if ($("#txtDefineCount").val() == "") {
                    layer.alert("自定义试题数不能为空！");
                    return false;
                } else if (!reg.test($("#txtDefineCount").val()) || parseInt($("#txtDefineCount").val()) <= 0) {
                    layer.alert("对不起，您输入的整数类型格式不正确!");//请将“整数类型”要换成你要验证的那个属性名称！
                    return false;
                }
            }
            return true;
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="廉政教育在线测试试卷"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span>试卷名称</span></td>
                            <td class="con_item_left" colspan="2">
                                <asp:TextBox runat="server" ID="txtTestName" CssClass="input input500" Style="resize: none;" MaxLength="1000"></asp:TextBox><span style="color:red">*</span></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span>完成时限</span></td>
                            <td class="con_item_left" colspan="2">
                                <asp:TextBox ID="pdthopefinishtime" runat="server" CssClass="input Wdate input140" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span>试题数</span></td>
                            <td class="con_item" style="width:70px;">
                                <asp:RadioButtonList ID="rblTestCount" runat="server" Width="70px" CellPadding="10" onclick="doChecked()">                                 
                                    <asp:ListItem Text="30道" Value="30" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="50道" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100道" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="自定义" Value="自定义"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width:550px; vertical-align:bottom; padding-bottom:5px">
                                <asp:TextBox ID="txtDefineCount" runat="server" CssClass="input" Enabled="false"></asp:TextBox>
                                <span>&nbsp;(只能输入正整数)</span>
                            </td>
                        </tr> 
                    </table>
                </div>
                <div class="con_oper">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn_submit con_oper_btn let6" 
                        OnClientClick=" return checkInput();" Text="生成试卷" OnClick="btnConfirm_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.doClose();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
