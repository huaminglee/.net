<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditMeeting.aspx.cs" Inherits="Meeting_EditMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新增会议</title>
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
                layer.alert("会议名称不能为空！");
                return false;
            } else if ($("#txtContent").val() == "") {
                layer.alert("会议内容不能为空！");
                return false;
            } else if ($("#txtLocation").val() == "") {
                layer.alert("会议地点不能为空！");
                return false;
            } else if ($("#txtStartTime").val() == "") {
                layer.alert("开始时间不能为空！");
                return false;
            } else if ($("#txtEndTime").val() == "") {
                layer.alert("结束时间不能为空！");
                return false;
            } else if (Date.parse($("#txtStartTime").val().replace("-", "/")) >= Date.parse($("#txtEndTime").val().replace("-", "/"))) {
                layer.alert("结束时间必须大于开始时间！");
                return false;
            } else if ($("#txtDepartment").val() == "") {
                layer.alert("承办部门不能为空！");
                return false;
            } else if ($("#txtHostUser").val() == "") {
                layer.alert("主持人不能为空！");
                return false;
            } else if ($("#txtReceiveUser").val() == "") {
                layer.alert("参会人员不能为空！");
                return false;
            }
            return true; //
        } 
    </script>
</head>

<body onunload="FrameCloseAll();">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局会议通知"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>会议名称</span></td>
                            <td class="con_item_left" colspan="3">
                                <input type="text" runat="server" id="txtTitle" class="input input650" maxlength="150" />
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>会议内容</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtContent" CssClass="input inputArea650_60" Style="resize: none;" TextMode="MultiLine" MaxLength="1000"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span><a href="javascript:void(0);" onclick="selectMRoom();" style="margin-right: 0px;">会议地点</a></span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtLocation" CssClass="input input650" MaxLength="60"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>开始时间</span></td>
                            <td class="con_item_left" style="width:225px;">
                                <asp:TextBox runat="server" ID="txtStartTime" CssClass="input Wdate input152" MaxLength="32" onFocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',minDate:'%y-%M-%d %H:%m'})"></asp:TextBox></td>
                            <td class="con_item" style="width: 100px; text-align: right;"><span style="color:red">*</span><span>结束时间</span></td>
                            <td class="con_item_left" style="width:225px;">
                                <asp:TextBox runat="server" ID="txtEndTime" CssClass="input Wdate input152" MaxLength="32" onFocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm',minDate:'%y-%M-%d %H:%m'})"></asp:TextBox></td>
                        </tr>
                        <%--<tr>
                            <td class="con_item" style="width: 40px; text-align: right;"><span>结束时间</span></td>
                            <td class="con_item_left">
                                <asp:TextBox runat="server" ID="TextBox4" CssClass="input" Width="720px" MaxLength="32"></asp:TextBox></td>
                        </tr>--%>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span>承办部门</span></td>
                            <td class="con_item_left" style="width:225px;">
                                <asp:TextBox runat="server" ID="txtDepartment" CssClass="input input152" MaxLength="50"></asp:TextBox></td>
                            <td class="con_item" style="width: 100px; text-align: right;"><span style="color:red">*</span><span><a href="javascript:void(0);" onclick="selectHUser();" style="margin-right: 0px;">主持人</a></span></td>
                            <td class="con_item_left" style="width:225px;">
                                <asp:TextBox runat="server" ID="txtHostUser" CssClass="input input152"  MaxLength="50" onfocus="selectHUser();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span style="color:red">*</span><span><a href="javascript:void(0);" onclick="selectRUser();" style="margin-right: 0px;">参会人员</a></span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtReceiveUser" TextMode="MultiLine" CssClass="input inputArea650_60" MaxLength="50" onfocus="selectRUser();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="width: 150px; text-align: right;"><span>非本局参会人员</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox runat="server" ID="txtOtherPerson" CssClass="input input664" MaxLength="150"></asp:TextBox></td>
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
                    <asp:CheckBox ID="chkIs_sendsms" runat="server" Text="发送手机短信" />
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn let6" 
                        OnClientClick=" return checkInput();" Text="提交" OnClick="btnSubmit_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click"  Style="display: none;" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                <ContentTemplate>
                    <asp:HiddenField ID="hidRoomID" runat="server" />
                    <asp:HiddenField ID="hidRUserID" runat="server" />
                    <asp:HiddenField ID="hidHUserID" runat="server" />
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

        function selectMRoom() {
            $.layer({
                type: 2,
                title: '选择会议地点',
                iframe: { src: '/Meeting/SelectMRoom.aspx' },
                maxmin: true,
                area: ['580px', '500px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }

        function selectRUser() {
            $.layer({
                type: 2,
                title: '选择参会人员',
                iframe: { src: '/Archive/msgUserList.aspx' },
                maxmin: true,
                area: ['545px', '485px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }
        //设置参会人员
        function setreceiverUser(ids, names) {
            $("#hidRUserID").val(ids);
            $("#txtReceiveUser").val(names);
            layer.closeAll();
        }

        function selectHUser() {
            $.layer({
                type: 2,
                title: '选择主持人',
                iframe: { src: '../Meeting/SelectHUser.aspx' },
                maxmin: true,
                area: ['545px', '485px'],
                border: [1, 0.2, '#000', true],
                offset: ['30px', '']
            });
        }
        //设置主持人
        function setHUser(ids,names) {
            $("#hidHUserID").val(ids);
            $("#txtHostUser").val(names);
            layer.closeAll();
        }
        ///页面卸载的时候执行
        function FrameCloseAll() {
            $("#tr_Att").remove();
        }
    </script>
</body>
</html>
