<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newMsgInfo.aspx.cs" Inherits="Archive_newMsgInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新增公告</title>
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
    </style>
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                upload_url: "upload.aspx",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "1024 MB",
                file_types: "*.*",
                file_types_description: "所有文件",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                //对返回ID赋值
                upload_success_handler: function (file, serverData) {
                    if (serverData != "") {
                        var ids = $("#hidAttachmentIds").val();
                        if (ids != "") {
                            $("#hidAttachmentIds").val(ids + "," + serverData);
                            doRefresh();
                        }
                        else {
                            $("#hidAttachmentIds").val(serverData);
                            doRefresh();
                        }
                    }
                },
                button_text_top_padding: 0,
                button_text_left_padding: 20,

                button_cursor: SWFUpload.CURSOR.HAND,
                button_image_url: "../images/AddAttachbg.jpg",
                button_placeholder_id: "<%=HyAddAttach.ClientID %>",
                button_width: 83,
                button_height: 20,
                button_text: '<span class="theFont">添加附件</span>',
                button_text_style: '.theFont{font: 12px/1.5 "Lucida Grande",tahoma,arial,微软雅黑;}',
                // Flash Settings
                flash_url: "/Script/swfupload/swfupload.swf",	// Relative to this file
                flash9_url: "/Script/swfupload/swfupload_FP9.swf",	// Relative to this file

                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    upload_target: "divFileProgressContainer",
                    cancelButtonId: "btnCancel"
                },

                // Debug Settings
                debug: false
            });
        }
    </script>
</head>
<body onunload="FrameCloseAll();">
    <form id="mForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局公告消息笺"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 60px; text-align: right;"><span><a href="javascript:void(0);" onclick="showrUserList();" style="margin-right: 0px;">收件人</a></span></td>
                            <td class="con_item_left" style="white-space:nowrap;">
                                <input type="text" readonly="true" runat="server" id="txtRname" onfocus="showrUserList();" class="input input664" />
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 40px; text-align: right;"><span>主题</span></td>
                            <td class="con_item_left" style="white-space:nowrap;">
                                <asp:TextBox runat="server" ID="txtTitle" CssClass="input input664" MaxLength="149"></asp:TextBox>
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 40px; text-align: right;"><span>内容</span></td>
                            <td class="con_item_left" style="white-space:nowrap;">
                                <textarea runat="server" id="txtContent" class="inputArea664" maxlength="1999"></textarea>
                                <span style="color:red;">*</span>
                               </td>
                        </tr>
                        <tr style="height: 12px;" id="tr_Att">
                            <td class=""></td>
                            <td class="">
                                <asp:HyperLink ID="HyAddAttach" runat="server" Text="">添加附件</asp:HyperLink>
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
                                                    <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton></td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="con_oper">
                    <asp:CheckBox ID="chkIs_sendsms" runat="server" Text="发送手机短信" />
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn let6" OnClick="btnSubmit_Click"
                        Text="提交" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="CloseAllFrame();" />
                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click" Style="display: none;" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                <ContentTemplate>
                    <asp:HiddenField ID="hidAttachmentIds" runat="server" />
                    <asp:HiddenField ID="hidUserIds" runat="server" Value="" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script type="text/javascript">
        //模拟查询点击
        function doRefresh() {
            document.getElementById('<%=btnSearchList.ClientID %>').click();
        }
        ///选择公告消息接收人员
        function showrUserList() {
            $.layer({
                type: 2,
                title: '选择接收人员',
                iframe: { src: '/Archive/msgUserList.aspx' },
                maxmin: true,
                area: ['545px', '615px'],
                border: [1, 0.2, '#000', true],
                offset: ['10px', '']
            });
        }
        //设置接收人员
        function setreceiverUser(ids, names) {
            $("#hidUserIds").val(ids);
            $("#txtRname").val(names);
            layer.closeAll();
        }
        function FrameCloseAll() {
            $("#tr_Att").remove();
        }
        ///页面卸载的时候执行
        function CloseAllFrame() {
            $("#tr_Att").remove();
            window.parent.layer.closeAll();
        }
    </script>
</body>
</html>
