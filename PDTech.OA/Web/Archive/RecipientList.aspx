<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipientList.aspx.cs" Inherits="Archive_RecipientList" %>

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
        <div class="Main_Body">
            <div class="con_h">
                <div class="con_p"><span>人员列表(复选框选择)</span></div>
                <div class="con_r"><span>接收人员</span></div>
                <div class="con_Option"><span>选项设置</span></div>
            </div>
            <div class="con_s">
                <div class="con_Query">
                    <input type="text" id="txtPersonName" class="input inpute" />
                    <input type="button" id="btnSearch" class="btn btn_four" value="人员查询" />&nbsp;
                </div>
                <div class="con_temp">
                    <span>
                        <input type="button" id="btnSave" class="btn btn_four" value="保存模板" onclick="saveTemp();" /></span>
                    <input type="button" id="btnRead" class="btn btn_four" value="模板读入" onclick="showTempList();" />
                </div>
            </div>
            <div class="con_c">
                <div class="con_tree">
                    <div class="easyui-panel" style="height: 383px; border: none;" id="treeList">
                        <ul id="tt" class="easyui-tree" data-options="animate:true,cascadeCheck:false,lines:true">
                        </ul>
                    </div>
                </div>
                <div class="con_say">
                    <div id="yxry" class="con_person"></div>
                    <fieldset>
                        <legend>填写提交意见 </legend>
                        <div class="con_idea">
                            <div class="con_otemp">
                                <span>
                                    <input type="button" id="btnSave_Op" class="btn btn_four" style="margin-left: 15px;" value="新增模板" onclick="AddOp_temp();" /></span>
                                <input type="button" id="btnRead_Op" class="btn btn_four" value="模板读入" onclick="ShowHandelTemp();" />
                            </div>
                            <textarea runat="server" id="txtIdea" name="txtIdea" style="resize: none;" class="txtArea"></textarea>
                        </div>
                    </fieldset>
                </div>
                <div class="con_Optionw">
                    <div id="Option_setting" class="con_option_box">

                        <div class="chgDate left" runat="server" id="deadline">
                            <span class="RemindDate">办理时限<asp:TextBox ID="txtInComingDate" runat="server" Width="158px"  CssClass="inputx Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></span>
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
                <asp:HiddenField runat="server" ID="hidCuurentStepId" />
                <asp:HiddenField runat="server" ID="hidCode" />
                <input type="hidden" id="sealdata" name="sealdata" />
                <input type="hidden" id="hidProtectedData" name="hidProtectedData" />
                <input type="hidden" id="hidIsNeedSign" name="hidIsNeedSign" />
            </div>
        </div>
        <script>
            //获取当前窗口索引以便执行layer.close方法（"window.name"是固定写法，不是某个控件的ID，官方demo有错误）
            var valArr = [], returnVal = [];
            var val, nodes;
            var Is_Multiplayer =<%=IS_ALLOW_MULTI_RECEIVE %> +"";
            $(function () {
                $("#tt").tree({
                    onClick: function (node) {
                        if (Is_Multiplayer == "1" || $("#hidAction").val()=="copy") {
                            if (node.status == "person" && !contains(valArr, node.id)) {
                                if (!contains(valArr, node.id))
                                    valArr.push(node.id);
                                /***进行分配***/
                                $("#yxry").append("<span class='btn-default btn-block'>" + node.text + "<button id='" + node.id + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></span>");
                            }
                            if (node.status == "department" && node.duid.length > 0 && !contains(valArr, node.duid)) {
                                if (!contains(valArr, node.duid))
                                    valArr.push(node.duid);
                                /***进行分配***/
                                $("#yxry").append("<span class='btn-default btn-block'>" + node.text + "<button id='" + node.duid + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></span>");
                            }
                            else if (node.status == "department" && (node.duid == "undefined" || node.duid == null || node.duid == "" || node.duid.length == 0)) {
                                layer.alert("此部门没有指定接收人员!", 8);
                            }
                            else if (contains(valArr, node.duid)) {
                                layer.alert("此部门指定接收人员已选择,不需要重复指定!", 8);
                            }
                        }
                        else if (Is_Multiplayer == "0") {
                        
                            if (node.status == "person") {
                                valArr[0] = node.id;
                                /***进行分配***/
                                $("#yxry").clearQueue();
                                $("#yxry").html("<span class='btn-default btn-block'>" + node.text + "<button id='" + node.id + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></span>");
                            }
                            else if (node.status == "department" && node.duid != null && node.duid.length > 0) {
                                valArr[0] = node.duid;
                                /***进行分配***/
                                $("#yxry").clearQueue();
                                $("#yxry").html("<span class='btn-default btn-block'>" + node.text + "<button id='" + node.duid + "' name='" + node.status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></span>");
                            }
                            else if (node.status == "department" && (node.duid == null|| node.duid == "undefined" || node.duid.length == 0)) {
                                layer.alert("此部门没有指定接收人员!", 8);
                            }
                        }
                        $("#hidUserList").val(valArr.join(","));
                    },
                    method: 'get',
                    url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($.trim($("#txtPersonName").val())) + "&action=" + $("#hidAction").val() + "&nId=" + $("#hidCuurentStepId").val() + ""
                });

                /***查询***/
                $("#btnSearch").click(function () {
                    $("#tt").tree({
                        method: 'get',
                        url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($("#txtPersonName").val()) + "&action=" + $("#hidAction").val() + "&nId=" + $("#hidCuurentStepId").val() + ""
                    });
                    $("#yxry").html("");
                });

                $("#hidIsNeedSign").val('<%=isNeedSign %>');
            })

            /***每个已选人员的关闭***/
            function mbtnClose(e) {
                $(e).parent("span").remove();
                valArr.splice(valArr.indexOf(e.id), 1);
              

                var personList = $('#<%=hidUserList.ClientID %>');
                var tempStr = (personList.val() + ',').replace(e.id + ',', '');
                if (tempStr.length > 0) {
                    personList.val(tempStr.substring(0, tempStr.length - 1));
                }
                else {
                    personList.val(tempStr);
                }

            }
            function hidTree() {
                $("#treeList").hide();
            }
            function getChecked(s) {
                var nodes = $('#tt').tree('getChecked');
                var s = s;
                for (var i = 0; i < nodes.length; i++) {
                    if (s != nodes[i].text)
                        $("#tt").tree("update", {
                            target: nodes[i].target,
                            checked: false
                        });
                }
            }
            ///判断数组中是否存在该数据  存在返回true 否则返回false
            function contains(arr, obj) {
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i] === obj) {
                        return true;
                    }
                }
                return false;
            }
            ///存入模板
            function saveTemp() {
                if ($("#hidUserList").val().length > 0) {
                    $.layer({
                        type: 2,
                        title: '新增模板',
                        iframe: { src: '/Archive/AddTemp.aspx?uIds=' + $("#hidUserList").val() },
                        maxmin: true,
                        area: ['410px', '130px'],
                        border: [1, 0.2, '#000', true],
                        offset: ['20px', '']
                    });
                }
                else {
                    layer.alert("请选择接收人员");
                }
            }
            ///弹出模板
            function showTempList() {
                $.layer({
                    type: 2,
                    title: '接收人员模板',
                    iframe: { src: '/Archive/selTempList.aspx?code=' + $("#hidCode").val() + "" },
                    maxmin: true,
                    area: ['510px', '530px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['20px', '']
                });
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
            function doConfirm() {
                var flag = $("#hidIsNeedSign").val();
                //alert(flag);
                //return false;

                if (flag == "1") {
                    //需要签章，先弹出签章页面
                    $.messager.defaults = { ok: "是", cancel: "否" };
                    $.messager.confirm('公文管理', '是否进行电子签章？', function (r) {
                        if (r) {
                            return doSealUp();
                        } else {
                            return true;
                        }
                    });
                } else {
                    //不需要签章，直接提交
                    return true;
                }               
            }
            function doSealUp(){
                var temp = '<%=S_App.javaScriptFilter(protectDatas) %>' + stripscript($("#txtIdea").val()) + "&";
                if (doAddSeal(temp, "seal", 60, 10)) {
                    if (window.confirm("确定提交吗？")) {
                        return true;
                    } else {
                        $("#seal").empty();
                        return false;
                    }
                } else {
                    return false;
                }
            }
            function checkInput() {
                var str = stripscript($("#txtIdea").val())
                $("#txtIdea").val(str);
                return true;
            }
            ///新增办理意见模板
            function AddOp_temp() {
                $.layer({
                    type: 2,
                    title: '新增办理意见模板',
                    iframe: { src: '/Archive/AddHandleOp.aspx' },
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
                    iframe: { src: '/Archive/selHandleOpList.aspx' },
                    maxmin: true,
                    area: ['510px', '530px'],
                    border: [1, 0.2, '#000', true],
                    offset: ['20px', '']
                });
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
            var arrId = [], arrName = [];
            function ShowTemp(ids, names) {
                arrId = ids.split(',');
                arrName = names.split(',');
                $("#hidUserList").val(ids);
                for (var i = 0; i < arrName.length; i++) {
                    $("#yxry").append("<span class='btn-default btn-block'>" + arrName[i] + "<button id='" + arrId[i] + "' name='person' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></span>");
                }
                layer.closeAll();
            }
            function ShowOpinion(msg) {
                $("#txtIdea").val(msg);
                layer.closeAll();
            }
        </script>
    </form>
</body>
</html>
