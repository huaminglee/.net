<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newProimplement.aspx.cs" Inherits="Admin_newProimplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>项目实施</title>
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
    <style type="text/css">
        .let2 {
            letter-spacing: 2px;
        }
        .let6 {
            letter-spacing: 6px;
        }
        
        
    </style>
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
                    <h3 id="title" runat="server">水务项目项目实施表</h3>
                    <hr />
                </div>
                <div class="con_b">
                    <table class="main_List" cellspacing="1" cellpadding="1" style="text-align: center;" border="0">

                        <tr>
                            <td class="auto-style5" style="text-align: right;">
                                <span>招标文件</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="fileBidDoc" style="display: none;" onchange="ConfirmFile_BidDoc();" />
                                <input type="button" class="btn" id="btnBidDoc" style="display: none;" value="上传附件" onclick="UploadBidDoc();" />
                            </td>
                        </tr>
                        <tr id="trBidDocFile" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>招标文件附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="BidDocname"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showBidDocList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_BidDocList" runat="server" OnItemDataBound="rpt_BidDocList_ItemDataBound">
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
                                <span>开标监督文件</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="filesupDoc" style="display: none;" onchange="ConfirmFile_supDoc();" />
                                <input type="button" class="btn" id="btnsupDoc" style="display: none;" value="上传附件" onclick="UploadsupDoc();" />
                            </td>
                        </tr>
                        <tr id="tr_supDoc" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>开标监督文件附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="supDocName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_supDocList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_supDocList" runat="server" OnItemDataBound="rpt_supDocList_ItemDataBound">
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
                                <span>中标通知书</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="filebidNotice" style="display: none;" onchange="ConfirmFile_bidNotice();" />
                                <input type="button" class="btn" id="btnbidNotice" style="display: none;" value="上传附件" onclick="UploadbidNotice();" />
                            </td>
                        </tr>
                        <tr id="tr_bidNotice" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>中标通知书附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="bidNoticeName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_ShowbidNoticeList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_bidNoticeList" runat="server" OnItemDataBound="rpt_bidNoticeList_ItemDataBound">
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
                                <span>合同</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="fileContract" style="display: none;" onchange="ConfirmFile_Contract();" />
                                <input type="button" class="btn" id="btnContract" style="display: none;" value="上传附件" onclick="UploadContract();" />
                            </td>
                        </tr>
                        <tr id="tr_Contract" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>合同附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="ContractName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_ShowContractList" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_ContractList" runat="server" OnItemDataBound="rpt_ContractList_ItemDataBound">
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
                                <span>开工备案</span>
                            </td>
                            <td class="con_item_left" colspan="3">
                                <input type="file" runat="server" id="filesRecord" style="display: none;" onchange="ConfirmFile_sRecord();" />
                                <input type="button" class="btn" id="btnsRecord" style="display: none;" value="上传附件" onclick="UploadsRecord();" />
                            </td>
                        </tr>
                        <tr id="tr_sRecord" style="display: none;">
                            <td class="auto-style5" style="text-align: right;"><span>开工备案附件</span></td>
                            <td class="con_item_left" colspan="3">
                                <span id="sRecordName"></span>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_ShowsRecord" visible="false">
                            <td class="auto-style5"></td>
                            <td class="con_item" colspan="3">
                                <table class="GridTitleCss">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_sRecordList" runat="server" OnItemDataBound="rpt_sRecordList_ItemDataBound">
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

                        <tr style="display: none;">
                            <td class="auto-style1" style="text-align: right;">
                                <span>预计完成时间</span></td>
                            <td class="auto-style2" colspan="3">
                                <input type="text" runat="server" class="input input152" id="txtPlan_EndTIME" onfocus="WdatePicker({isShowClear:false,readOnly:true})" /></td>
                        </tr>
                        <tr style="display: none;">
                            <td class="auto-style5" style="text-align: right; width:18%;">
                                <span>审核人</span></td>
                            <td class="auto-style3"  style="width:32%;">
                            <asp:Label runat="server" ID="lblUserName"></asp:Label>    
                            </td>
                             <td class="auto-style2" style="text-align: right; width:15%;">
                                <span>审核时间</span></td>
                            <td class="auto-style2" style="width:35%;">
                            <asp:Label runat="server" ID="lblAuditDate"></asp:Label>    
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="auto-style5" style="text-align: right;">
                                <span>备注</span></td>
                            <td class="auto-style3" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="inputArea664" MaxLength="999"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;" runat="server" id="tr_Opinion">
                            <td class="auto-style5" style="text-align: right;"><span>步骤是否完成</span></td>
                            <td class="con_item_left" colspan="3">
                                <asp:DropDownList ID="dplIs_End" runat="server" CssClass="ddlinput input152">
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 12px; display:none" id="tr_Att">
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
                    <asp:Button ID="btnSubmit" runat="server" style="display: none;" Text="审核" CssClass="btn_submit con_oper_btn let6" OnClick="btnAudit_Click" />
                    <asp:Button ID="btnSave" runat="server" style="display: none;" Text="保存" CssClass="btn_save con_oper_btn let6" OnClick="btnSave_Click" />
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
                <asp:HiddenField runat="server" ID="hidBidDoc" />
                <asp:HiddenField runat="server" ID="hidsupDoc" />
                <asp:HiddenField runat="server" ID="hidbidNotice" />
                <asp:HiddenField runat="server" ID="hidContract" />
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
            function UploadBidDoc() {
                $("#fileBidDoc").click();
            }
            function UploadsupDoc() {
                if ($("#hidBidDoc").val() == "1") {
                    $("#filesupDoc").click();
                }
                else {
                    layer.alert("招标文件尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadbidNotice() {
                if ($("#hidsupDoc").val() == "1") {
                    $("#filebidNotice").click();
                }
                else {
                    layer.alert("开标监督文件尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadContract() {
                if ($("#hidbidNotice").val() == "1") {
                    $("#fileContract").click();
                }
                else {
                    layer.alert("中标通知书尚未完成,不能操作此项目!", 8);
                }
            }
            function UploadsRecord() {
                if ($("#hidContract").val() == "1") {
                    $("#filesRecord").click();
                }
                else {
                    layer.alert("合同尚未完成,不能操作此项目!", 8);
                }
            }
            function ConfirmFile_BidDoc() {
                var file = $('#fileBidDoc').val();
                $("#BidDocname").html(file);
                $("#hidBidDoc").val("1");
                $("#trBidDocFile").show();
            }
            function ConfirmFile_supDoc() {
                var file = $('#filesupDoc').val();
                $("#supDocName").html(file);
                $("#hidsupDoc").val("1");
                $("#tr_supDoc").show();
            }
            function ConfirmFile_bidNotice() {
                var file = $('#filebidNotice').val();
                $("#bidNoticeName").html(file);
                $("#hidbidNotice").val("1");
                $("#tr_bidNotice").show();
            }
            function ConfirmFile_Contract() {
                var file = $('#fileContract').val();
                $("#ContractName").html(file);
                $("#hidContract").val("1");
                $("#tr_Contract").show();
            }
            function ConfirmFile_sRecord() {
                var file = $('#filesRecord').val();
                $("#sRecordName").html(file);
                $("#tr_sRecord").show();
            }
            function backPrevious() {
                var pId = $("#hidPId").val();
                window.location.href = '/Admin/Pro_Process.aspx?pId=' + pId + '&Isedit=' + $("#hidisedit").val() + '&tId=' + $("#hidtaskid").val();
            }
        </script>
    </form>
</body>
</html>
