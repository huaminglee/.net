<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newFinance.aspx.cs" Inherits="Admin_newFinance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>水务项目报备[新增]</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" href="/CSS/detail.css?t=" <%=t_rand %> />
    <link href="../CSS/newpage.css" rel="stylesheet" />
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
                    <%--<span runat="server" id="tipInfo"></span>--%>
                    <h3 id="title" runat="server"></h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>资金总额</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtMoneyTotal" runat="server" class="input input152" /></td>
                            <td class="con_item" style="text-align: right;"><span>资金来源</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtMoneySource" runat="server" class="input input140" maxlength="30" />
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>项目业主</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtHostUnit" runat="server" class="input input152" />
                            </td>
                            <td class="con_item" style="text-align: right;"><span>项目层级</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="dplOrgUnit" runat="server" CssClass="ddlinput input140">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>项目类别</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtProjectBasis" runat="server" class="input inputp" /></td>
                            <td class="con_item" style="text-align: right;"><span>备案处室</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="dplFILE_DEPT" runat="server" CssClass="ddlinput input140">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>牵头处室</span></td>
                            <td class="con_item_left" style="white-space:nowrap;">
                                <asp:DropDownList runat="server" ID="dplRESPONSE_DEPT" CssClass="ddlinput inputp">

                                </asp:DropDownList>
                                <span style="color:red;">*</span>
                            </td>
                            <td class="con_item" style="text-align: right;"><span>备案时间</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtsTime" runat="server" class="input input140" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="con_item" style="text-align: right;"><span>预计完成时间</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtPlaneTime" runat="server" class="input inputp" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                            </td>
                            <td class="con_item" style="text-align: right;"><%--<span>是否“三重一大”</span>--%></td>
                            <td class="con_item_left">
                                <%--<asp:DropDownList runat="server" ID="dplSzyd" Width="130px" Height="30px" CssClass="ddlinput"></asp:DropDownList>--%></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>项目名称</span>
                            </td>
                            <td class="con_item_left" colspan="3" style="white-space:nowrap;">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="input input664" MaxLength="50"></asp:TextBox>
                                <span style="color:red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备注</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="inputArea664" MaxLength="999"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_Opinion">
                            <td class="con_item" style="text-align: right;"><span>项目是否完成</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:DropDownList ID="dplIs_End" runat="server" CssClass="ddlinput input152">
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                 <asp:Literal ID="ShowOpList" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
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
                    <asp:DropDownList ID="dplSkipList" runat="server" CssClass="ddlinput" Height="30px">
                    </asp:DropDownList>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn let6" OnClick="btnSubmit_Click" Text="提交" />
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

            function hideAtt() {
                $("#tr_Att").hide();
            }
            ///页面卸载的时候执行
            function FrameCloseAll() {
                $("#tr_Att").remove();
            }
            ///页面卸载的时候执行
            function CloseAllFrame() {
                $("#tr_Att").remove();
                window.parent.layer.closeAll();
            }
            function ChgPerson(msg, tId) {
                $.layer({
                    shade: [0.2, '#000'],
                    area: ['auto', 'auto'],
                    border: [1, 0.2, '#000', true],
                    dialog: {
                        msg: msg,
                        btns: 1,
                        type: 4,
                        btn: ['确定'],
                        yes: function () {
                            window.location.href = 'RecipientList.aspx?tId=' + tId + '&action=Handle'
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
