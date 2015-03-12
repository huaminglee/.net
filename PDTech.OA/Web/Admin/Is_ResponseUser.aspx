<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Is_ResponseUser.aspx.cs" Inherits="Admin_Is_ResponseUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=<%=t_rand %>" />
    <link href='/CSS/Recipient.css?t=' <%=t_rand %> rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css?t=<%=t_rand %>" rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="../Script/seal/AddSeal.js"></script>
</head>
<body>
    <form id="rForm" runat="server">
        <div class="Main_Body_u">
            <div class="con_h_u">
                <div class="con_r">填写提交意见 </div>
                <div class="con_Option"><span>选项设置</span></div>
            </div>
            <div class="con_s">
                <div class="con_temp">
                    <span>
                        <input type="button" id="btnSave_Op" class="btn btn_four" style="margin-left: 15px;" value="新增模板" onclick="AddOp_temp();" /></span>
                    <input type="button" id="btnRead_Op" class="btn btn_four" value="模板读入" onclick="ShowHandelTemp();" />
                </div>
            </div>
            <div class="con_c_u">
                <div class="con_say">
                    <div class="con_idea_u">
                        <textarea runat="server" id="txtIdea" name="txtIdea" style="resize: none; height: 390px;" class="txtArea"></textarea>
                    </div>
                </div>
                <div class="con_Optionw">
                    <div id="Option_setting" class="con_option_box">

                        <div class="chgDate left" runat="server" id="deadline">
                            <span class="RemindDate">办理时限<asp:TextBox ID="txtInComingDate" runat="server" Width="158px" CssClass="inputx Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></span>
                        </div>
                        <div class="Chg_remind_tible t35 left">
                            <span class="IsRemind">
                                <input type="checkbox" id="IS_SEND_SMS_NOW" style="width: 14px; height: 14px; vertical-align: middle; margin-bottom: 4px;" class="inputcheckbox" runat="server" />
                                是否立即短信提醒</span>
                        </div>
                        <div class="Chg_remind_tible left" runat="server" id="workdeadline">
                            <span class="IsRemind">
                                <input type="checkbox" style="width: 14px; height: 14px; vertical-align: middle; margin-bottom: 4px;" class="inputcheckbox" runat="server" id="IS_SEND_SMS_LIMIT" />
                                工作到期是否短信提醒</span>
                        </div>
                        <div class="RemindObject left" runat="server" id="TipsDate">
                            <span class="RemindDate">提醒对象：
                                <asp:DropDownList ID="ddlRemindUser" runat="server" Width="152px" Height="30px"></asp:DropDownList>
                            </span>
                            <br />
                            <span class="RemindDate">提醒时间：
                                <asp:DropDownList ID="ddlRemindDate" runat="server" Width="152px" Height="30px"></asp:DropDownList>
                            </span>
                        </div>
                    </div>
                    <fieldset>
                        <legend>
                            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></legend>
                        <div id="seal" style="height:0px; width:0px; POSITION:relative"></div>
                    </fieldset>
                </div>
            </div>
            <div class="con_btn">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn_submit con_oper_btn" OnClick="btnSubmit_Click" Text="提交" OnClientClick="return doSubmit()" />&nbsp;&nbsp;
                <input type="button" id="btnClose" class="btn_back con_oper_btn" value="关闭" onclick="window.parent.doRefresh(); window.parent.layer.closeAll();" />
                <input type="button" id="btnReturn" class="btn_back con_oper_btn" value="返回" onclick="BackToArchive();" />
                <asp:HiddenField runat="server" ID="hidUserList" />
                <asp:HiddenField runat="server" ID="hidAction" />
                <asp:HiddenField runat="server" ID="hidArchiveId" />
                <asp:HiddenField runat="server" ID="hidArchiveType" />
                <asp:HiddenField runat="server" ID="hidTaskID" />
                <asp:HiddenField runat="server" ID="hidCode" />
                <input type="hidden" id="sealdata" name="sealdata" />
                <input type="hidden" id="hidProtectedData" name="hidProtectedData" />
                <input type="hidden" id="hidIsNeedSign" name="hidIsNeedSign" />
            </div>
        </div>
        <script>
            $(function () {
                $("#hidIsNeedSign").val('<%=isNeedSign %>');
            });

            ///判断数组中是否存在该数据  存在返回true 否则返回false
            function contains(arr, obj) {
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i] === obj) {
                        return true;
                    }
                }
                return false;
            }
            ///新增办理意见模板
            function AddOp_temp() {
                $.layer({
                    type: 2,
                    title: '新增办理意见模板',
                    iframe: { src: '/Admin/AddHandleOp.aspx' },
                    maxmin: true,
                    area: ['408px', '245px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['20px', '']
                });
            }
            ///弹出办理意见模板
            function ShowHandelTemp() {
                $.layer({
                    type: 2,
                    title: '办理意见模板',
                    iframe: { src: '/Admin/selHandleOpList.aspx' },
                    maxmin: true,
                    area: ['510px', '530px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['20px', '']
                });
            }
            ///切换盖章和取消印章
            function switching(value) {
                if (value == '盖章') {
                    doAddSeal('<%=S_App.javaScriptEscape(protectDatas) %>' + $("#txtIdea").val() + "&", "seal", 60, 10);
                    $("#btnSeal").val("取消")
                } else {
                    $("#seal").empty();
                    $("#btnSeal").val("盖章")
                }
            }
            function stripscript(str) {
                str = str.replace(/"/g, "");
                str = str.replace(/</g, "");
                str = str.replace(/>/g, "");
                return str;
            }
            function doSubmit() {
                var flag = $("#hidIsNeedSign").val();
                var action = $("#hidAction").val();
                if (flag == "1" && action != "copy") {
                    if (window.confirm("是否电子签章？")) {
                        var temp = '<%=S_App.javaScriptFilter(protectDatas) %>' + stripscript($("#txtIdea").val()) + "&";
                        if (doAddSeal(temp, "seal", 60, 10)) {
                            return true;
                        } else {
                            return false;
                        }
                    }
                    else { return true; }
                } else {
                    //不需要签章，直接提交
                    return true;
                }
            }

            /***返回公文信息提交界面查看详细（需要传递多个ID时，调用此方法）***/
            function BackToArchive() {
                var src;
                var archive_id = $("#hidArchiveId").val();
                var archive_task_id = $("#hidTaskID").val();
                var archive_type = $("#hidArchiveType").val();
                /***待办事项***/
                if (archive_task_id != undefined) {
                    switch (archive_type) {
                        case "10":
                            src = "/Archive/newPieces.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "11":
                            src = "/Archive/NewWork.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "12":
                            src = "/Archive/NewUnitDoc.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "20": case "21": case "22": case "23":
                            src = "/Archive/newSupInfo.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                            break;
                        case "24":
                            src = "/Admin/newProposal.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "32":
                            src = "/Admin/newPersonnel.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "33":
                            src = "/Admin/sel_Finance.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                        case "40": case "41": case "42": case "43": case "44": case "61": case "62":
                            src = "/Approve/newApprove.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                            break;
                        case "51":
                            src = "/Risk/newRisk.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                            break;
                    }
                }
                window.location.href = src;
            }
        </script>
        <script type="text/javascript">
            function ShowOpinion(msg) {
                $("#txtIdea").val(msg);
                layer.closeAll();
            }
        </script>
    </form>
</body>
</html>
