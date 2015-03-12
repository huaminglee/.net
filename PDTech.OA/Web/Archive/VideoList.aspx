<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoList.aspx.cs" Inherits="Archive_VideoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=<%=t_rand %>" />
    <link href='/CSS/userTree.css?t=' <%=t_rand %> rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css?t=<%=t_rand %>" rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <%--<style>
        input{
            margin-left:50px !important ;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:20px;margin-left:15px">


            <asp:CheckBoxList ID="ckbvideolist" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" RepeatLayout="Flow">
            </asp:CheckBoxList>


        </div>
        <div class="con_btn">
            <input type="button" id="btnSubmit" class="btn_submit con_oper_btn" value="提交" onclick="OnOK();" />
            <input type="button" id="btnReturn" class="btn_back con_oper_btn" value="关闭" onclick="window.parent.doRefresh(); window.parent.layer.closeAll();" />
           
        </div>
        <script>
            function OnOK() {
                var selvideo="";
                $('#ckbvideolist input[type=checkbox]:checked').each(function ()
                {
                    selvideo+=$(this).val()+";"
                }
                );
                if (selvideo.length > 0) {
                    selvideo= selvideo.substring(0, selvideo.length - 1);
                }
                window.parent.setvideo(selvideo);
            }
        </script>
    </form>
</body>
</html>
