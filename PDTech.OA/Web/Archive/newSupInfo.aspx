<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newSupInfo.aspx.cs" Inherits="Archive_newSupInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>新工作普通办件</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
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
                            dofileRefresh();
                        }
                        else {
                            $("#hidAttachmentIds").val(serverData);
                            dofileRefresh();
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
                            <td class="con_item" style="text-align: right;">
                                <img src="/images/info.png" alt="" />
                                <a runat="server" id="aSendUnit" style="cursor: pointer; text-decoration: none;" onclick="openSelectUnit();">来文单位</a></td>
                            <td class="con_item_left" colspan="1">
                                <input type="text" runat="server" id="txtSendUnit" class="input input152" /></td>
                            <td class="con_item" style="text-align: right;">
                                <span class="">收文日期</span></td>
                            <td class="con_item_left">
                                <asp:TextBox ID="pdtInComingDate" runat="server" CssClass="input Wdate input140" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span class="">来文字号</span></td>
                            <td class="con_item_left" colspan="1">
                                <asp:TextBox ID="txtDispath" runat="server" CssClass="input input152" MaxLength="50"></asp:TextBox>
                            </td>
                            <td class="con_item" style="text-align: right;">
                                <span>收文编号</span>
                            </td>
                            <td class="con_item_left">
                                <asp:TextBox ID="txtRecNum" runat="server" CssClass="input input140" MaxLength="50"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span class="">紧急程度</span>
                            </td>
                            <td class="con_item_left" colspan="1">
                                <asp:DropDownList ID="dplUrgency" runat="server" CssClass="ddlinput input152">
                                </asp:DropDownList>
                            </td>
                            <td class="con_item" style="text-align: right;">
                                <span class="">“三重一大”公示</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList runat="server" ID="dplSzyd" CssClass="ddlinput input140"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>来文标题</span>
                            </td>
                            <td class="con_item_left" colspan="3" style="white-space:nowrap;">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="input input664" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备注</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" Style="resize: none;" TextMode="MultiLine" CssClass=" inputArea664" MaxLength="1000"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                 <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="height: 12px;" id="tr_Att">
                            <td class=""></td>
                            <td class="" colspan="5">
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
                    <asp:DropDownList ID="dplSkipList" runat="server" CssClass="ddlinput">
                    </asp:DropDownList>&nbsp;&nbsp;
                   
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn let6" OnClick="btnSubmit_Click"
                        Text="提交" />
                    <asp:Button ID="btnRevert" runat="server" CssClass="btn_back con_oper_btn let6" Visible="false" OnClick="btnRevert_Click" Text="退回" />
                    <input type="button" runat="server" id="btnProcess" onclick='ShowTheProcess()' value="办理流程" class="btn_Process con_oper_btn let2" />
                    <asp:Button ID="btnCc" runat="server" Text="抄送" CssClass="btn_Cc con_oper_btn let6" OnClick="btnCc_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn_save con_oper_btn let6" OnClick="btnSave_Click" />
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
            ///选择来文单位
            function openSelectUnit() {
                $.layer({
                    type: 2,
                    title: '选择来文单位',
                    iframe: { src: '/Archive/Com_UnitList.aspx' },
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
