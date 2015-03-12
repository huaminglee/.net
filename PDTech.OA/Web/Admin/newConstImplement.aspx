<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newConstImplement.aspx.cs" Inherits="Admin_newConstImplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>建设实施</title>
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
        var swfo;
        window.onload = function () {
            swfu = new SWFUpload({
                upload_url: "upload_pro.aspx",
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
                    <h3 id="title" runat="server">水务项目建设实施表</h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center;" border="0">
                        <tr>
                            <td class="auto-style5" style="text-align: right;">
                                <span>开工备案</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="fileLoad" style="display: none;" onchange="ConfirmFile();" />
                                <input type="button" class="btn" id="btnUpload" style="display:none" value="上传附件" onclick="UploadFile();" />
                            </td>
                        </tr>
                        <tr id="trExamineFile" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>开工备案附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="Exname"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showExList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width:40%;">附件名称</th>
                                        <th style="width:20%;">上传人员</th>
                                        <th style="width:20%;">上传时间</th>
                                        <th style="width:20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_ExfileList" runat="server" OnItemDataBound="rpt_ExfileList_ItemDataBound">
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
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="text-align: right;">
                                <span>进度管理</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="load_plait" style="display: none;" onchange="ConfirmFile_plait();" />
                                <input type="button" class="btn" style="display:none" id="btnUpload_plait" value="上传附件" onclick="UploadFile_plait();" />
                            </td>
                        </tr>
                        <tr id="trPlaitFile" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>进度管理附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="plaitName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showplList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width:40%;">附件名称</th>
                                        <th style="width:20%;">上传人员</th>
                                        <th style="width:20%;">上传时间</th>
                                        <th style="width:20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_plaitList" runat="server" OnItemDataBound="rpt_plaitList_ItemDataBound">
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
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="text-align: right;">
                                <span>重大设计变更审批</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="loadacc" style="display: none;" onchange="ConfirmFile_Acc();" />
                                <input type="button" class="btn" style="display:none" id="btnAcc" value="上传附件" onclick="UploadFile_Acc();" />
                            </td>
                        </tr>
                        <tr id="tr_Acc" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>重大设计变更审批附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="AccName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_AccList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width:40%;">附件名称</th>
                                        <th style="width:20%;">上传人员</th>
                                        <th style="width:20%;">上传时间</th>
                                        <th style="width:20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_AccList" runat="server" OnItemDataBound="rpt_AccList_ItemDataBound">
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
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="auto-style1" style="text-align: right;">
                                <span>预计完成时间</span></td>
                            <td class="auto-style2" colspan="3">
                                <input type="text" runat="server" class="input input152" id="txtPlan_EndTIME" onfocus="WdatePicker({isShowClear:false,readOnly:true})" /></td>
                        </tr>
                        <tr style="display:none">
                            <td class="auto-style5" style="text-align: right; width:18%;">
                                <span>审核人</span></td>
                            <td class="auto-style3"  style="width:500px;">
                            <asp:Label runat="server" ID="lblUserName"></asp:Label>    
                            </td>
                             <td class="auto-style2" style="text-align: right; width:90px;">
                                <span>审核时间</span></td>
                            <td class="auto-style2" style="width:500px;">
                            <asp:Label runat="server" ID="lblAuditDate"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="auto-style5" style="text-align: right;">
                                <span>备注</span></td>
                            <td class="auto-style3" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" Style="resize: none;" TextMode="MultiLine" CssClass="inputArea664" MaxLength="999"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none" runat="server" id="tr_Opinion">
                            <td class="auto-style5" style="text-align: right;"><span>步骤是否完成</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:DropDownList ID="dplIs_End" runat="server" CssClass="ddlinput input152">
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr  style="height: 12px; display:none" id="tr_Att">
                            <td class="auto-style6"></td>
                            <td class="" colspan="3">
                                <asp:HyperLink ID="HyAddAttach" runat="server" Text="">添加附件</asp:HyperLink>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width:40%;">附件名称</th>
                                        <th style="width:20%;">上传人员</th>
                                        <th style="width:20%;">上传时间</th>
                                        <th style="width:20%;" colspan="2">操作</th>
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
                    <asp:Button ID="btnSubmit" runat="server" style="display:none" Text="审核" CssClass="btn_submit con_oper_btn let6" OnClick="btnAudit_Click" />
                    <asp:Button ID="btnSave" runat="server" style="display:none" Text="保存" CssClass="btn_save con_oper_btn let6" OnClick="btnSave_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="CloseAllFrame();" />
                    <input type="button" id="Button1" class="btn_back con_oper_btn let6" value="返回" onclick="backPrevious();" />
                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click" Style="display: none;" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>
                <asp:HiddenField ID="hidAttachmentIds" runat="server" />
                <asp:HiddenField ID="hidstate" runat="server" />
                <asp:HiddenField runat="server" ID="hidPId" />
                <asp:HiddenField runat="server" ID="hidEx" />
                <asp:HiddenField runat="server" ID="hidPlait" />
                <asp:HiddenField runat="server" ID="hidAcc" />
                <asp:HiddenField runat="server" ID="hidLogID" />
                <asp:HiddenField ID="hidisedit" Value="0" runat="server" />
                <asp:HiddenField ID="hidtaskid" Value="0" runat="server" />

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
            function UploadFile() {
                $("#fileLoad").click();
            }
            function UploadFile_plait() {
                if ($("#hidEx").val() == "1") {
                    $("#load_plait").click();
                }
                else {
                    layer.alert("开工备案尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc() {
                if ($("#hidPlait").val() == "1") {
                    $("#loadacc").click();
                }
                else {
                    layer.alert("质量安全进度管理尚未完成,暂不能操作此项!", 8);
                }
            }
            function ConfirmFile() {
                var file = $('#fileLoad').val();
                $("#Exname").html(file);
                $("#hidEx").val("1");
                $("#trExamineFile").show();
            }
            function ConfirmFile_plait() {
                var file = $('#load_plait').val();
                $("#plaitName").html(file);
                $("#hidPlait").val("1");
                $("#trPlaitFile").show();
            }
            function ConfirmFile_Acc() {
                var file = $('#loadacc').val();
                $("#AccName").html(file);
                $("#hidAcc").val("1");
                $("#tr_Acc").show();
            }

            function backPrevious() {
                var pId = $("#hidPId").val();
                window.location.href = '/Admin/Pro_Process.aspx?pId=' + pId + '&Isedit=' + $("#hidisedit").val() + '&tId=' + $("#hidtaskid").val();
            }
        </script>
    </form>
</body>
</html>
