<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selTiobnoedit.aspx.cs" Inherits="Archive_selTiobnoedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新工作普通办件</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
     <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
   
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <style type="text/css">
        .let2 {
            letter-spacing: 2px;
        }

        .let6 {
            letter-spacing: 6px;
        }
    </style>
</head>
<body onunload="FrameCloseAll();">
    <form id="nForm" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="container-fluid text-center thisPadding">
                    <span runat="server" id="tipInfo"></span>
                    <h3 id="title" runat="server"></h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="text-align: right;">公文类型</td>
                            <td class="con_item_left" style="white-space: nowrap;">
                                <asp:Label ID="lbarchtype" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>标题</span>
                            </td>
                            <td class="con_item_left" style="white-space: nowrap;">
                                <asp:Label ID="lbtitle" runat="server" Text=""></asp:Label>
&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;内容</span>
                            </td>
                            <td class="con_item_left">
                                <asp:Label ID="lbcontent" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
                        <tr style="height: 12px;" id="tr_Att">
                            <td class=""></td>
                            <td class="">
                                
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="con_item"></td>
                            <td class="con_item">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="2">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_AttachmentList" runat="server" OnItemCommand="rpt_AttachmentList_ItemCommand" OnItemDataBound="rpt_AttachmentList_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="../images/attachlogo.jpg" /><%# Eval("FILE_NAME") %></td>
                                                <td>
                                                    <%# Eval("FULL_NAME") %>
                                                </td>
                                                <td>
                                                    <%# AidHelp.ShortTime(Eval("CREATE_TIME")) %>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPath" runat="server" Visible="false" Text='<%# Eval("FILE_PATH") %>'></asp:Label>
                                                    <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink></td>
                                                <td>
                                                   

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="con_oper">
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="CloseAllFrame();" />

                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click" Style="display: none;" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>
                <asp:HiddenField ID="hidAttachmentIds" runat="server" />
                <asp:HiddenField ID="hidAttachmentNames" runat="server" />
                <asp:HiddenField ID="hidTempName" runat="server" Value="" />
                <asp:HiddenField ID="hidArStatus" runat="server" />
                <asp:HiddenField ID="hidTaskStatus" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="fieldset flash" id="fsUploadProgress">
            <span class="legend"></span>
        </div>
        <span class="uploadprogressbar" id="ID_uploadprogressbar"></span>
        <div id="divFileProgressContainer" style="height: 3px; display: none;">
        </div>
        <div id="thumbnails">
        </div>
        <script type="text/javascript">
            //模拟查询点击
            function dofileRefresh() {
                document.getElementById('<%=btnSearchList.ClientID %>').click();
            }
            //查看流程
            function ShowTheProcess() {
                var arid =<%=arId%>
                window.location.href = "FortheProcess.aspx?ArId=" + arid;
            }
            ///选择文种
            function openSelectFile() {
                $.layer({
                    type: 2,
                    title: '选择文种',
                    iframe: { src: '/Archive/LingualList.aspx' },
                    maxmin: true,
                    area: ['575px', '490px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['30px', '']
                });
            }
            function hideAtt() {
                $("#tr_Att").hide();
            }
            ///页面卸载的时候执行
            function FrameCloseAll() {
                $("#tr_Att").remove();
            }
            ///页面卸载的时候执行
            function CloseAllFrame() {
                window.parent.layer.closeAll();
            }
           
        </script>
    </form>
</body>
</html>
