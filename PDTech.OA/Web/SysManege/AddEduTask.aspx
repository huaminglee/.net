<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEduTask.aspx.cs" Inherits="SysManege_AddEduTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新增教育任务</title>
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
        p
        {
            padding-left:2em;
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
                upload_url: "../Archive/upload.aspx",
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

        function checkInput() {
            if ($("#txtTitle").val() == "") {
                layer.alert("任务标题不能为空！");
                return false;
            } else if ($("#txtSendUnit").val() == "") {
                layer.alert("来文单位不能为空！");
                return false;
            } else if ($("#txtReceiveUser").val() == "") {
                layer.alert("接收人员不能为空！");
                return false;
            } 
            return true;
        }
    </script>
</head>

<body onunload="FrameCloseAll();">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局教育任务"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>任务标题</span></td>
                            <td class="con_item_left" colspan="3">
                                <input type="text" runat="server" id="txtTitle" class="input input650" />
                            </td>
                        </tr> 
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>任务类型</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="input inputb"></asp:DropDownList></td>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>完成时限</span>
                                 </td>
                            <td class="con_item_left">
                                <asp:TextBox ID="pdthopefinishtime" runat="server" CssClass="input Wdate input140" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;">
                                <span style="color:red">*</span><span><a href="javascript:void(0);" onclick="selectCompany();" style="margin-right: 0px;">来文单位</a></span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtSendUnit" CssClass="input input650"  MaxLength="50" ></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span><a href="javascript:void(0);" onclick="selectRUser();" style="margin-right: 0px;">接收人员</a></span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtReceiveUser" TextMode="MultiLine" CssClass="input input650" MaxLength="50" onfocus="selectRUser()"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span>备注</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtRemark" CssClass="input inputArea664" Style="resize: none;" TextMode="MultiLine" MaxLength="1000"></asp:TextBox></td>
                             
                        </tr>
                        <tr style="height: 12px;" id="tr_Att">
                            <td class=""></td>
                            <td class="" colspan="3">
                                <asp:HyperLink ID="HyAddAttach" runat="server" Text="">添加附件</asp:HyperLink>
                               
                            </td>
                             
                        </tr>
                        <tr style="height: 12px;" id="tr_Att">
                            <td class="">&nbsp;</td>
                            <td class="" colspan="3">
                                 <a onclick="addvideo()" class="theFont"><img src="../images/video.png" width="14" style="padding-right:6px"/>添加视频</a></td>
                             
                        </tr>
                        <tr style="height: 12px;" id="tr_video">
                            <td class="">&nbsp;</td>
                            <td class="" colspan="3">
                                <asp:Label ID="lbselvideo" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hidselvideo" runat="server" />
                                </td>
                        </tr>
                            
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="con_item"></td>
                            <td class="con_item" colspan="3">
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
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn let6" 
                        OnClientClick=" return checkInput();" Text="提交" OnClick="btnSubmit_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.doClose();" />
                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click"  Style="display: none;" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                <ContentTemplate>
                    <asp:HiddenField ID="hidTempName" runat="server" />
                    <asp:HiddenField ID="hidRUserID" runat="server" />
                    <asp:HiddenField ID="hidAttachmentIds" runat="server" />
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
        </div>
    </form>
    <script type="text/javascript">
        function doRefresh() {
            document.getElementById('<%=btnSearchList.ClientID %>').click();
        }

        function selectCompany() {
            $.layer({
                type: 2,
                title: '选择来文单位',
                iframe: { src: '/Archive/Com_UnitList.aspx' },
                maxmin: true,
                area: ['545px', '485px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }

        function selectRUser() {
            $.layer({
                type: 2,
                title: '选择接收人员',
                iframe: { src: '/Archive/msgUserList.aspx' },
                maxmin: true,
                area: ['545px', '485px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }
        //设置接收人员
        function setreceiverUser(ids, names) {
            $("#hidRUserID").val(ids);
            $("#txtReceiveUser").val(names);
            layer.closeAll();
        }
        ///页面卸载的时候执行
        function FrameCloseAll() {
            $("#tr_Att").remove();
        }
        function addvideo() {
            $.layer({
                type: 2,
                title: '选择视频',
                iframe: { src: '/Archive/VideoList.aspx' },
                maxmin: true,
                area: ['545px', '485px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }
        function setvideo(selfiles) {
            $("#hidselvideo").val(selfiles);
            $("#lbselvideo").html(selfiles);
            layer.closeAll();
        }
    </script>
</body>
</html>
