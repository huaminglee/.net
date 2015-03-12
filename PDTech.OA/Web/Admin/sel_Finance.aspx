<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sel_Finance.aspx.cs" Inherits="Admin_sel_Finance" %>

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
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="/Script/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="/Script/handlers.js"></script>
    <script type="text/javascript" src="/Script/common.js"></script>
    <style type="text/css">
        .let2 {
            letter-spacing: 2px;
        }

        .let6 {
            letter-spacing: 6px;
        }

        .auto-style1 {
            height: 26px;
        }

        .auto-style5 {
            width: 102px;
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
                    <h3>
                        <asp:Label ID="lbtitle" runat="server" Text="水务项目备案表"></asp:Label></h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>资金总额</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtMoneyTotal" runat="server" class="input input152" onblur="javascript:return check_isdecimal();" onkeydown="javascript:return check_isdecimal();" maxlength="11" /></td>
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
                            <td class="con_item" style="text-align: right;"><span>项目来源</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtProjectBasis" runat="server" class="input input152" /></td>
                            <td class="con_item" style="text-align: right;"><span>备案处室</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList ID="dplFILE_DEPT" runat="server" Enabled="false" CssClass="ddlinput input140">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;"><span>牵头处室</span></td>
                            <td class="con_item_left">
                                <asp:DropDownList runat="server" ID="dplRESPONSE_DEPT" CssClass="ddlinput inputp">
                                </asp:DropDownList>
                            </td>
                            <td class="con_item" style="text-align: right;"><span>备案时间</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtsTime" runat="server" class="input Wdate input140" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="con_item" style="text-align: right;"><span>预计完成时间</span></td>
                            <td class="con_item_left">
                                <input type="text" id="txtPlaneTime" runat="server" class="input Wdate input152" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                            </td>
                            <td class="con_item" style="text-align: right;"><%--<span>是否“三重一大”</span>--%></td>
                            <td class="con_item_left">
                                <%--<asp:DropDownList runat="server" ID="dplSzyd" Width="130px" Height="30px" CssClass="ddlinput"></asp:DropDownList>--%></td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>标题</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="input input664" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="con_item" style="text-align: right;">
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备注</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass=" inputArea664" MaxLength="999"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" style="display: none" id="tr_Opinion">
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
                                <asp:HiddenField ID="hidprojectid" runat="server" />
                                <table class="nav-justified">
                                    <tr id="gh" runat="server" visible="false">
                                        <td>

                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>审查意见</span>
                                                    </td>
                                                    <td>
                                                        <input type="file" runat="server" id="fileLoad_gh" style="display: none;" onchange="ConfirmFile_gh();" />
                                                        <input type="button" class="btn" id="btnUpload_gh" value="上传附件" onclick="UploadFile_gh();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_gh" style="display: none;">
                                                    <td class="auto-style1"><span>审查意见附件</span></td>
                                                    <td class="auto-style1"><span id="Exname_gh"></span></td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_gh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_gh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>

                                    </tr>
                                    <tr id="xmjys" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>审查意见</span>
                                                    </td>
                                                    <td>
                                                        <input type="file" runat="server" id="fileLoad_xmjys" style="display: none;" onchange="ConfirmFile_xmjys();" />
                                                        <input type="button" class="btn" id="btnUpload_xmjys" value="上传附件" onclick="UploadFile_xmjys();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_xmjys" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>审查意见附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="Exname_xmjys"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_xmjys" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_xmjys" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载">
                                                                            </asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>编制报告</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="load_plait_xmjys" style="display: none;" onchange="ConfirmFile_plait_xmjys();" />
                                                        <input type="button" class="btn" id="btnUpload_plait_xmjys" value="上传附件" onclick="UploadFile_plait_xmjys();" />
                                                    </td>
                                                </tr>
                                                <tr id="trPlaitFile_xmjys" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>编制报告附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="plaitName_xmjys"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showplList_xmjys" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_plaitList_xmjys" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>专家评审结果</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="loadacc_xmjys" style="display: none;" onchange="ConfirmFile_Acc_xmjys();" />
                                                        <input type="button" class="btn" id="btnAcc_xmjys" value="上传附件" onclick="UploadFile_Acc_xmjys();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Acc_xmjys" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>专家评审结果附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccName_xmjys"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_AccList_xmjys" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccList_xmjys" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="kxx" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>涉水专项论证</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileArg_kxx" style="display: none;" onchange="ConfirmFile_Arg_kxx();" />
                                                        <input type="button" class="btn" id="btnArg_kxx" value="上传附件" onclick="UploadFile_Arg_kxx();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_ArgFile_kxx" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>涉水专项论证附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ArgName_kxx"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ArgList_kxx" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ArgList_kxx" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>审查意见</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileLoad_kxx" style="display: none;" onchange="ConfirmFile_kxx();" />
                                                        <input type="button" class="btn" id="btnUpload_kxx" value="上传附件" onclick="UploadFile_kxx();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_kxx" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>审查意见附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="Exname_kxx"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_kxx" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_kxx" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>编制报告</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="load_plait_kxx" style="display: none;" onchange="ConfirmFile_plait_kxx();" />
                                                        <input type="button" class="btn" id="btnUpload_plait_kxx" value="上传附件" onclick="UploadFile_plait_kxx();" />
                                                    </td>
                                                </tr>
                                                <tr id="trPlaitFile_kxx" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>编制报告附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="plaitName_kxx"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showplList_kxx" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_plaitList_kxx" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>专家评审结果</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="loadacc_kxx" style="display: none;" onchange="ConfirmFile_Acc_kxx();" />
                                                        <input type="button" class="btn" id="btnAcc_kxx" value="上传附件" onclick="UploadFile_Acc_kxx();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Acc_kxx" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>专家评审结果附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccName_kxx"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_AccList_kxx" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccList_kxx" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="cbsj" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>定审结果</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileLoad_cbsj" style="display: none;" onchange="ConfirmFile_cbsj();" />
                                                        <input type="button" class="btn" id="btnUpload_cbsj" value="上传附件" onclick="UploadFile_cbsj();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_cbsj" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>定审结果附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="Exname_cbsj"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_cbsj" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_cbsj" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>会签结果</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="load_plait_cbsj" style="display: none;" onchange="ConfirmFile_plait_cbsj();" />
                                                        <input type="button" class="btn" id="btnUpload_plait_cbsj" value="上传附件" onclick="UploadFile_plait_cbsj();" />
                                                    </td>
                                                </tr>
                                                <tr id="trPlaitFile_cbsj" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>会签结果附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="plaitName_cbsj"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showplList_cbsj" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_plaitList_cbsj" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>领导签发</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="loadacc_cbsj" style="display: none;" onchange="ConfirmFile_Acc_cbsj();" />
                                                        <input type="button" class="btn" id="btnAcc_cbsj" value="上传附件" onclick="UploadFile_Acc_cbsj();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Acc_cbsj" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>领导签发附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccName_cbsj"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_AccList_cbsj" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccList_cbsj" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="sgzb" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>招标文件</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileArg_sgzb" style="display: none;" onchange="ConfirmFile_Arg_sgzb();" />
                                                        <input type="button" class="btn" id="btnArg_sgzb" value="上传附件" onclick="UploadFile_Arg_sgzb();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_ArgFile_sgzb" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>招标文件附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ArgName_sgzb"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ArgList_sgzb" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ArgList_sgzb" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>开标监督文件</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileLoad_sgzb" style="display: none;" onchange="ConfirmFile_sgzb();" />
                                                        <input type="button" class="btn" id="btnUpload_sgzb" value="上传附件" onclick="UploadFile_sgzb();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_sgzb" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>开标监督文件附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="Exname_sgzb"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_sgzb" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_sgzb" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>中标通知书</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="load_plait_sgzb" style="display: none;" onchange="ConfirmFile_plait_sgzb();" />
                                                        <input type="button" class="btn" id="btnUpload_plait_sgzb" value="上传附件" onclick="UploadFile_plait_sgzb();" />
                                                    </td>
                                                </tr>
                                                <tr id="trPlaitFile_sgzb" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>中标通知书附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="plaitName_sgzb"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showplList_sgzb" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_plaitList_sgzb" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>合同</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="loadacc_sgzb" style="display: none;" onchange="ConfirmFile_Acc_sgzb();" />
                                                        <input type="button" class="btn" id="btnAcc_sgzb" value="上传附件" onclick="UploadFile_Acc_sgzb();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Acc_sgzb" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>合同附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccName_sgzb"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_AccList_sgzb" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccList_sgzb" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="jsss" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>开工备案</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileLoad_jsss" style="display: none;" onchange="ConfirmFile_jsss();" />
                                                        <input type="button" class="btn" id="btnUpload_jsss" value="上传附件" onclick="UploadFile_jsss();" />
                                                    </td>
                                                </tr>
                                                <tr id="trExamineFile_jsss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>开工备案附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="Exname_jsss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showExList_jsss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ExfileList_jsss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
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
                                                        <input type="file" runat="server" id="load_plait_jsss" style="display: none;" onchange="ConfirmFile_plait_jsss();" />
                                                        <input type="button" class="btn" id="btnUpload_plait_jsss" value="上传附件" onclick="UploadFile_plait_jsss();" />
                                                    </td>
                                                </tr>
                                                <tr id="trPlaitFile_jsss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>进度管理附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="plaitName_jsss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showplList_jsss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_plaitList_jsss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
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
                                                        <input type="file" runat="server" id="loadacc_jsss" style="display: none;" onchange="ConfirmFile_Acc_jsss();" />
                                                        <input type="button" class="btn" id="btnAcc_jsss" value="上传附件" onclick="UploadFile_Acc_jsss();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Acc_jsss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>重大设计变更审批附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccName_jsss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_AccList_jsss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccList_jsss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="sczb" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified"></table>
                                        </td>

                                    </tr>
                                    <tr id="jgys" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>竣工验收申请</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileApply_jgys" style="display: none;" onchange="applyFile_jgys();" />
                                                        <input type="button" class="btn" id="btnApply_jgys" value="上传附件" onclick="UploadFile_Apply_jgys();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Apply_jgys" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>竣工验收申请附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ApplyName_jgys"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showApplyList_jgys" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_CompList_jgys" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>竣工验收鉴定书</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileAccep_jgys" style="display: none;" onchange="AccepFile_jgys();" />
                                                        <input type="button" class="btn" id="btnAccep_jgys" value="上传附件" onclick="UploadFile_Accep_jgys();" />
                                                    </td>
                                                </tr>

                                                <tr id="tr_Accep_jgys" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>竣工验收鉴定书附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="AccepName_jgys"></span>
                                                    </td>
                                                </tr>

                                                <tr runat="server" id="tr_AccepList_jgys" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_AccepList_jgys" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="hpj" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified"></table>
                                        </td>

                                    </tr>
                                    <tr id="sdjh" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>申报项目评审</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileProEva_sdjh" style="display: none;" onchange="ConfirmFile_ProEva_sdjh();" />
                                                        <input type="button" class="btn" id="btnProEva_sdjh" value="上传附件" onclick="UploadProEva_sdjh();" />
                                                    </td>
                                                </tr>
                                                <tr id="trProEvaFile_sdjh" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>申报项目评审附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ProEvaname_sdjh"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showProEvaList_sdjh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ProEvaList_sdjh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>申报项目签审</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileProExet_sdjh" style="display: none;" onchange="ConfirmFile_ProExet_sdjh();" />
                                                        <input type="button" class="btn" id="btnProExet_sdjh" value="上传附件" onclick="UploadProExet_sdjh();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_ProExet_sdjh" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>申报项目签审附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ProExetName_sdjh"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trProExetList_sdjh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ProExetList_sdjh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="sbjh" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>立项依据</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileProBasis_sbjh" style="display: none;" onchange="ConfirmFile_ProBasis_sbjh();" />
                                                        <input type="button" class="btn" id="btnProBasis_sbjh" value="上传附件" onclick="UploadProBasis_sbjh();" />
                                                    </td>
                                                </tr>
                                                <tr id="trProBasisFile_sbjh" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>立项依据附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ProBasisname_sbjh"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showProBasisList_sbjh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ProBasisList_sbjh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>项目资金计划</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filefPlan_sbjh" style="display: none;" onchange="ConfirmFile_fPlan_sbjh();" />
                                                        <input type="button" class="btn" id="btnfPlan_sbjh" value="上传附件" onclick="UploadfPlan_sbjh();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_fPlan_sbjh" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>项目资金计划附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="fPlanName_sbjh"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_fPlanList_sbjh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_fPlanList_sbjh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="xdjh" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>项目资金计划</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filefPlan_xdjh" style="display: none;" onchange="ConfirmFile_fPlan_xdjh();" />
                                                        <input type="button" class="btn" id="btnfPlan_xdjh" value="上传附件" onclick="UploadfPlan_xdjh();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_fPlan_xdjh" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>项目资金计划附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="fPlanName_xdjh"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_fPlanList_xdjh" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_fPlanList_xdjh" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="xmss" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>招标文件</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileBidDoc_xmss" style="display: none;" onchange="ConfirmFile_BidDoc_xmss();" />
                                                        <input type="button" class="btn" id="btnBidDoc_xmss" value="上传附件" onclick="UploadBidDoc_xmss();" />
                                                    </td>
                                                </tr>
                                                <tr id="trBidDocFile_xmss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>招标文件附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="BidDocname_xmss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_showBidDocList_xmss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_BidDocList_xmss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>开标监督文件</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filesupDoc_xmss" style="display: none;" onchange="ConfirmFile_supDoc_xmss();" />
                                                        <input type="button" class="btn" id="btnsupDoc_xmss" value="上传附件" onclick="UploadsupDoc_xmss();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_supDoc_xmss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>开标监督文件附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="supDocName_xmss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_supDocList_xmss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_supDocList_xmss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>中标通知书</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filebidNotice_xmss" style="display: none;" onchange="ConfirmFile_bidNotice_xmss();" />
                                                        <input type="button" class="btn" id="btnbidNotice_xmss" value="上传附件" onclick="UploadbidNotice_xmss();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_bidNotice_xmss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>中标通知书附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="bidNoticeName_xmss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowbidNoticeList_xmss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_bidNoticeList_xmss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>合同</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileContract_xmss" style="display: none;" onchange="ConfirmFile_Contract_xmss();" />
                                                        <input type="button" class="btn" id="btnContract_xmss" value="上传附件" onclick="UploadContract_xmss();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Contract_xmss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>合同附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="ContractName_xmss"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowContractList_xmss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_ContractList_xmss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>开工备案</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filesRecord_xmss" style="display: none;" onchange="ConfirmFile_sRecord_xmss();" />
                                                        <input type="button" class="btn" id="btnsRecord_xmss" value="上传附件" onclick="UploadsRecord_xmss();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_sRecord_xmss" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>开工备案附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="sRecordName"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowsRecord_xmss" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_sRecordList_xmss" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr id="zjbf" runat="server" visible="false">
                                        <td>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>付款申请</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filePay_zjbf" style="display: none;" onchange="ConfirmFile_Pay_zjbf();" />
                                                        <input type="button" class="btn" id="btnbidPay_zjbf" value="上传附件" onclick="UploadPay_zjbf();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Pay_zjbf" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>付款申请附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="PayName_zjbf"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowPayList_zjbf" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_PayList_zjbf" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>付款申请审核结果</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="filePayr_zjbf" style="display: none;" onchange="ConfirmFile_Payr_zjbf();" />
                                                        <input type="button" class="btn" id="btnPayr_zjbf" value="上传附件" onclick="UploadPayr_zjbf();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Payr_zjbf" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>付款申请审核结果附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="PayrName_zjbf"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowPayrList_zjbf" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_PayrList_zjbf" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style5" style="text-align: right;">
                                                        <span>资金拨付签审</span>
                                                    </td>
                                                    <td class="con_item_left" colspan="3">
                                                        <input type="file" runat="server" id="fileMoney_zjbf" style="display: none;" onchange="ConfirmFile_Money_zjbf();" />
                                                        <input type="button" class="btn" id="btnsMoney_zjbf" value="上传附件" onclick="UploadsMoney_zjbf();" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_Money_zjbf" style="display: none;">
                                                    <td class="auto-style5" style="text-align: right;"><span>资金拨付签审附件</span></td>
                                                    <td class="con_item_left" colspan="3">
                                                        <span id="MoneyName_zjbf"></span>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr_ShowMoney_zjbf" visible="false">
                                                    <td class="auto-style5"></td>
                                                    <td class="con_item" colspan="3">
                                                        <table class="GridTitleCss">
                                                            <tr>
                                                                <th style="width: 40%;">附件名称</th>
                                                                <th style="width: 20%;">上传人员</th>
                                                                <th style="width: 20%;">上传时间</th>
                                                                <th style="width: 20%;" colspan="1">操作</th>
                                                            </tr>
                                                            <asp:Repeater ID="rpt_MoneyList_zjbf" runat="server" OnItemDataBound="rpt_ExfileList_gh_ItemDataBound" OnItemCommand="rpt_ExfileList_gh_ItemCommand">
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
                                                                            <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink>
                                                                            <asp:HiddenField ID="hidcreateruser" Value='<%# Eval("CREATE_USER") %>' runat="server" />
                                                                            <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    
                                </table>

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
                                                    <asp:LinkButton ID="lbDel" runat="server" CommandName="DelItem" ForeColor="#215493" Font-Underline="false" CommandArgument='<%# Eval("ATTACHMENT_FILE_ID") %>'>删除</asp:LinkButton>

                                                </td>
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
                    <input type="button" runat="server" id="btnProcess" onclick='ShowTheProcess()' value="办理流程" class="btn_Process con_oper_btn let2" />
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn_save con_oper_btn let6" OnClick="btnSave_Click" />
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="CloseAllFrame();" />
                    <asp:Button ID="btnSearchList" runat="server" Text="获取附件" OnClick="btnSearchList_Click" Style="display: none;" />
                    <asp:HiddenField ID="hidtaskid" runat="server" />
                    <asp:HiddenField ID="hidarchid" runat="server" />
                    <asp:HiddenField ID="hidcurstepid" runat="server" />
                    <asp:HiddenField ID="hidpisID" runat="server" />
                    <asp:HiddenField runat="server" ID="hidUpload_xmjys" />
                    <asp:HiddenField runat="server" ID="hidPlait_xmjys" />
                    <asp:HiddenField runat="server" ID="hidAcc_xmjys" />
                    <asp:HiddenField runat="server" ID="hidArg_kxx" />
                    <asp:HiddenField runat="server" ID="hidEx_kxx" />
                    <asp:HiddenField runat="server" ID="hidPlait_kxx" />
                    <asp:HiddenField runat="server" ID="hidAcc_kxx" />
                    <asp:HiddenField runat="server" ID="hidEx_cbsj" />
                    <asp:HiddenField runat="server" ID="hidPlait_cbsj" />
                    <asp:HiddenField runat="server" ID="hidAcc_cbsj" />
                    <asp:HiddenField runat="server" ID="hidArg_sgzb" />
                    <asp:HiddenField runat="server" ID="hidEx_sgzb" />
                    <asp:HiddenField runat="server" ID="hidPlait_sgzb" />
                    <asp:HiddenField runat="server" ID="hidAcc_sgzb" />
                    <asp:HiddenField runat="server" ID="hidEx_jsss" />
                    <asp:HiddenField runat="server" ID="hidPlait_jsss" />
                    <asp:HiddenField runat="server" ID="hidAcc_jsss" />
                    <asp:HiddenField runat="server" ID="hidApply_jgys" />
                    <asp:HiddenField runat="server" ID="hidAccep_jgys" />
                    <asp:HiddenField runat="server" ID="hidProEva_sdjh" />
                    <asp:HiddenField runat="server" ID="hidProExet_sdjh" />
                    <asp:HiddenField runat="server" ID="hidProBasis_sbjh" />
                    <asp:HiddenField runat="server" ID="hidBidDoc_xmss" />
                    <asp:HiddenField runat="server" ID="hidsupDoc_xmss" />
                    <asp:HiddenField runat="server" ID="hidbidNotice_xmss" />
                    <asp:HiddenField runat="server" ID="hidContract_xmss" />
                    <asp:HiddenField runat="server" ID="hidbidPay_zjbf" />
                <asp:HiddenField runat="server" ID="hidPayr_zjbf" />


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
                            window.location.href = 'RecipientList.aspx?tId=' + tId + '&action=copy'
                        }
                    }
                });
            }
            //查看流程
            function ShowTheProcess() {
                var pId =<%=pId %>
                window.location.href = 'Pro_Process.aspx?Isedit=1&pId=' + pId + '&tId=' + $("#hidtaskid").val() + "&ArId=" + $("#hidarchid").val();
            }
            //各步骤意见处理
            function UploadFile_gh() {
                $("#fileLoad_gh").click();
            }
            function ConfirmFile_gh() {
                var file = $('#fileLoad_gh').val();
                $("#Exname_gh").html(file);
                $("#trExamineFile_gh").show();
            }
            function UploadFile_xmjys() {
                $("#fileLoad_xmjys").click();
            }
            function UploadFile_plait_xmjys() {
                if ($("#hidUpload_xmjys").val() == 1) {
                    $("#load_plait_xmjys").click();
                }
                else {
                    $("#load_plait_xmjys").click();
                   // layer.alert("出具技术审查意见尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc_xmjys() {
                if ($("#hidPlait_xmjys").val() == 1) {
                    $("#loadacc_xmjys").click();
                }
                else {
                    $("#loadacc_xmjys").click();
                    //layer.alert("编制报告尚未完成,暂不能操作此项!", 8);
                }
            }
            function ConfirmFile_xmjys() {
                var file = $('#fileLoad_xmjys').val();
                $("#Exname_xmjys").html(file);
                $("#hidUpload_xmjys").val("1");
                $("#trExamineFile_xmjys").show();
            }
            function ConfirmFile_plait_xmjys() {
                var file = $('#load_plait_xmjys').val();
                $("#plaitName_xmjys").html(file);
                $("#hidPlait_xmjys").val("1");
                $("#trPlaitFile_xmjys").show();
            }
            function ConfirmFile_Acc_xmjys() {
                var file = $('#loadacc_xmjys').val();
                $("#AccName_xmjys").html(file);
                $("#hidAcc_xmjys").val("1");
                $("#tr_Acc_xmjys").show();
            }

            function UploadFile_kxx() {
                if ($("#hidArg_kxx").val() == "1") {
                    $("#fileLoad_kxx").click();
                }
                else {
                    $("#fileLoad_kxx").click();
                   // layer.alert("涉水专项论证尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_plait_kxx() {
                if ($("#hidEx_kxx").val() == "1") {
                    $("#load_plait_kxx").click();
                }
                else {
                    $("#load_plait_kxx").click();
                    //layer.alert("出具技术审查意见或批复及报批尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc_kxx() {
                if ($("#hidPlait_kxx").val() == 1) {
                    $("#loadacc_kxx").click();
                }
                else {
                    $("#loadacc_kxx").click();
                    //layer.alert("编制报告尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Arg_kxx() {
                $("#fileArg_kxx").click();
            }
            function ConfirmFile_kxx() {
                var file = $('#fileLoad_kxx').val();
                $("#Exname_kxx").html(file);
                $("#hidEx_kxx").val("1");
                $("#trExamineFile_kxx").show();
            }
            function ConfirmFile_plait_kxx() {
                var file = $('#load_plait_kxx').val();
                $("#plaitName_kxx").html(file);
                $("#hidPlait_kxx").val("1");
                $("#trPlaitFile_kxx").show();
            }
            function ConfirmFile_Acc_kxx() {
                var file = $('#loadacc_kxx').val();
                $("#AccName_kxx").html(file);
                $("#hidAcc_kxx").val("1");
                $("#tr_Acc_kxx").show();
            }
            function ConfirmFile_Arg_kxx() {
                var file = $('#fileArg_kxx').val();
                $("#ArgName_kxx").html(file);
                $("#hidArg_kxx").val("1");
                $("#tr_ArgFile_kxx").show();
            }
            function UploadFile_cbsj() {
                $("#fileLoad_cbsj").click();
            }
            function UploadFile_plait_cbsj() {
                if ($("#hidEx_cbsj").val() == "1") {
                    $("#load_plait_cbsj").click();
                }
                else {
                    $("#load_plait_cbsj").click();
                    //layer.alert("定审结果尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc_cbsj() {
                if ($("#hidPlait_cbsj").val() == "1") {
                    $("#loadacc_cbsj").click();
                }
                else {
                    $("#loadacc_cbsj").click();
                    //layer.alert("会签结果尚未完成,暂不能操作此项!", 8);
                }
            }
            function ConfirmFile_cbsj() {
                var file = $('#fileLoad_cbsj').val();
                $("#Exname_cbsj").html(file);
                $("#hidEx_cbsj").val("1");
                $("#trExamineFile_cbsj").show();
            }
            function ConfirmFile_plait_cbsj() {
                var file = $('#load_plait_cbsj').val();
                $("#plaitName_cbsj").html(file);
                $("#hidPlait_cbsj").val("1");
                $("#trPlaitFile_cbsj").show();
            }
            function ConfirmFile_Acc_cbsj() {
                var file = $('#loadacc_cbsj').val();
                $("#AccName_cbsj").html(file);
                $("#hidAcc_cbsj").val("1");
                $("#tr_Acc_cbsj").show();
            }
            function UploadFile_sgzb() {
                if ($("#hidArg_sgzb").val() == "1") {
                    $("#fileLoad_sgzb").click();
                }
                else {
                    $("#fileLoad_sgzb").click();
                    //layer.alert("招标文件备案尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_plait_sgzb() {
                if ($("#hidEx_sgzb").val() == "1") {
                    $("#load_plait_sgzb").click();
                }
                else {
                    $("#load_plait_sgzb").click();
                    //layer.alert("开标监督尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc_sgzb() {
                if ($("#hidPlait_sgzb").val() == "1") {
                    $("#loadacc_sgzb").click();
                }
                else {
                    $("#loadacc_sgzb").click();
                    //layer.alert("中标通知书尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Arg_sgzb() {
                $("#fileArg_sgzb").click();
            }
            function ConfirmFile_sgzb() {
                var file = $('#fileLoad_sgzb').val();
                $("#Exname_sgzb").html(file);
                $("#hidEx_sgzb").val("1");
                $("#trExamineFile_sgzb").show();
            }
            function ConfirmFile_plait_sgzb() {
                var file = $('#load_plait_sgzb').val();
                $("#plaitName_sgzb").html(file);
                $("#hidPlait_sgzb").val("1");
                $("#trPlaitFile_sgzb").show();
            }
            function ConfirmFile_Acc_sgzb() {
                var file = $('#loadacc_sgzb').val();
                $("#AccName_sgzb").html(file);
                $("#hidAcc_sgzb").val("1");
                $("#tr_Acc_sgzb").show();
            }
            function ConfirmFile_Arg_sgzb() {
                var file = $('#fileArg_sgzb').val();
                $("#ArgName_sgzb").html(file);
                $("#hidArg_sgzb").val("1");
                $("#tr_ArgFile_sgzb").show();
            }
            function UploadFile_jsss() {
                $("#fileLoad_jsss").click();
            }
            function UploadFile_plait_jsss() {
                if ($("#hidEx_jsss").val() == "1") {
                    $("#load_plait_jsss").click();
                }
                else {
                    $("#load_plait_jsss").click();
                    //layer.alert("开工备案尚未完成,暂不能操作此项!", 8);
                }
            }
            function UploadFile_Acc_jsss() {
                if ($("#hidPlait_jsss").val() == "1") {
                    $("#loadacc_jsss").click();
                }
                else {
                    $("#loadacc_jsss").click();
                    //layer.alert("质量安全进度管理尚未完成,暂不能操作此项!", 8);
                }
            }
            function ConfirmFile_jsss() {
                var file = $('#fileLoad_jsss').val();
                $("#Exname_jsss").html(file);
                $("#hidEx_jsss").val("1");
                $("#trExamineFile_jsss").show();
            }
            function ConfirmFile_plait_jsss() {
                var file = $('#load_plait_jsss').val();
                $("#plaitName_jsss").html(file);
                $("#hidPlait_jsss").val("1");
                $("#trPlaitFile_jsss").show();
            }
            function ConfirmFile_Acc_jsss() {
                var file = $('#loadacc_jsss').val();
                $("#AccName_jsss").html(file);
                $("#hidAcc_jsss").val("1");
                $("#tr_Acc_jsss").show();
            }
            function UploadFile_Apply_jgys() {
                $("#fileApply_jgys").click();
            }
            function applyFile_jgys() {
                var file = $('#fileApply_jgys').val();
                $("#ApplyName_jgys").html(file);
                $("#hidApply_jgys").val("1");
                $("#tr_Apply_jgys").show();
            }
            function UploadFile_Accep_jgys() {
                if ($("#hidApply_jgys").val() == "1") {
                    $("#fileAccep_jgys").click();
                }
                else {
                    $("#fileAccep_jgys").click();
                    //layer.alert("竣工验收申请尚未完成,不能操作此项!", 8);
                }
            }
            function AccepFile_jgys() {
                var file = $('#fileAccep_jgys').val();
                $("#AccepName_jgys").html(file);
                $("#hidAccep_jgys").val("1");
                $("#tr_Accep_jgys").show();
            }
            function UploadProEva_sdjh() {
                $("#fileProEva_sdjh").click();
            }
            function UploadProExet_sdjh() {
                if ($("#hidProEva_sdjh").val() == "1") {
                    $("#fileProExet_sdjh").click();
                }
                else {
                    $("#fileProExet_sdjh").click();
                    //layer.alert("申报项目评审尚未完成,暂不能操作此项!", 8);
                }
            }
            function ConfirmFile_ProEva_sdjh() {
                var file = $('#fileProEva_sdjh').val();
                $("#ProEvaname_sdjh").html(file);
                $("#hidProEva_sdjh").val("1");
                $("#trProEvaFile_sdjh").show();
            }
            function ConfirmFile_ProExet_sdjh() {
                var file = $('#fileProExet_sdjh').val();
                $("#ProExetName_sdjh").html(file);
                $("#hidProExet_sdjh").val("1");
                $("#tr_ProExet_sdjh").show();
            }
            function UploadProBasis_sbjh() {
                $("#fileProBasis_sbjh").click();
            }
            function UploadfPlan_sbjh() {
                if ($("#hidProBasis_sbjh").val() == "1") {
                    $("#filefPlan_sbjh").click();
                }
                else {
                    $("#filefPlan_sbjh").click();
                    //layer.alert("立项依据尚未完成,不能操作此项!", 8);
                }
            }
            function ConfirmFile_ProBasis_sbjh() {
                var file = $('#fileProBasis_sbjh').val();
                $("#ProBasisname_sbjh").html(file);
                $("#hidProBasis_sbjh").val("1");
                $("#trProBasisFile_sbjh").show();
            }
            function ConfirmFile_fPlan_sbjh() {
                var file = $('#filefPlan_sbjh').val();
                $("#fPlanName_sbjh").html(file);
                $("#tr_fPlan_sbjh").show();
            }
            function UploadfPlan_xdjh() {
                $("#filefPlan_xdjh").click();
            }

            function ConfirmFile_fPlan_xdjh() {
                var file = $('#filefPlan_xdjh').val();
                $("#fPlanName_xdjh").html(file);
                $("#tr_fPlan_xdjh").show();
            }
            function UploadBidDoc_xmss() {
                $("#fileBidDoc_xmss").click();
            } 
            function UploadsupDoc_xmss() {
                if ($("#hidBidDoc_xmss").val() == "1") {
                    $("#filesupDoc_xmss").click();
                }
                else {
                    $("#filesupDoc_xmss").click();
                    //layer.alert("招标文件尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadbidNotice_xmss() {
                if ($("#hidsupDoc_xmss").val() == "1") {
                    $("#filebidNotice_xmss").click();
                }
                else {
                    $("#filebidNotice_xmss").click();
                    //layer.alert("开标监督文件尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadContract_xmss() {
                if ($("#hidbidNotice_xmss").val() == "1") {
                    $("#fileContract_xmss").click();
                }
                else {
                    $("#fileContract_xmss").click();
                    //layer.alert("中标通知书尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadsRecord_xmss() {
                if ($("#hidContract_xmss").val() == "1") {
                    $("#filesRecord_xmss").click();
                }
                else {
                    $("#filesRecord_xmss").click();
                    //layer.alert("合同尚未完成,不能操作此项目!", 8);
                }
            }
            function ConfirmFile_BidDoc_xmss() {
                var file = $('#fileBidDoc_xmss').val();
                $("#BidDocname_xmss").html(file);
                $("#hidBidDoc_xmss").val("1");
                $("#trBidDocFile_xmss").show();
            }
            function ConfirmFile_supDoc_xmss() {
                var file = $('#filesupDoc_xmss').val();
                $("#supDocName_xmss").html(file);
                $("#hidsupDoc_xmss").val("1");
                $("#tr_supDoc_xmss").show();
            }
            function ConfirmFile_bidNotice_xmss() {
                var file = $('#filebidNotice_xmss').val();
                $("#bidNoticeName_xmss").html(file);
                $("#hidbidNotice_xmss").val("1");
                $("#tr_bidNotice_xmss").show();
            }
            function ConfirmFile_Contract_xmss() {
                var file = $('#fileContract_xmss').val();
                $("#ContractName_xmss").html(file);
                $("#hidContract_xmss").val("1");
                $("#tr_Contract_xmss").show();
            }
            function ConfirmFile_sRecord_xmss() {
                var file = $('#filesRecord_xmss').val();
                $("#sRecordName_xmss").html(file);
                $("#tr_sRecord_xmss").show();
            }
            function UploadPay_zjbf() {
                $("#filePay_zjbf").click();
            }
            function UploadPayr_zjbf() {
                if ($("#hidbidPay_zjbf").val() == "1") {
                    $("#filePayr_zjbf").click();
                }
                else {
                    $("#filePayr_zjbf").click();
                    //layer.alert("付款申请尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadsMoney_zjbf() {
                if ($("#hidPayr_zjbf").val() == "1") {
                    $("#fileMoney_zjbf").click();
                }
                else {
                    $("#fileMoney_zjbf").click();
                    //layer.alert("付款申请审核结果尚未完成,不能操作此项目!", 8);
                }
            }
            function ConfirmFile_Pay_zjbf() {
                var file = $('#filePay_zjbf').val();
                $("#PayName_zjbf").html(file);
                $("#hidbidPay_zjbf").val("1");
                $("#tr_Pay_zjbf").show();
            }
            function ConfirmFile_Payr_zjbf() {
                var file = $('#filePayr_zjbf').val();
                $("#PayrName_zjbf").html(file);
                $("#hidPayr_zjbf").val("1");
                $("#tr_Payr_zjbf").show();
            }
            function ConfirmFile_Money_zjbf() {
                var file = $('#fileMoney_zjbf').val();
                $("#MoneyName_zjbf").html(file);
                $("#tr_Money_zjbf").show();
            }
        </script>
    </form>
</body>
</html>
