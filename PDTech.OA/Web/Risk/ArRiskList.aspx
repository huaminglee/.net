<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArRiskList.aspx.cs" Inherits="Risk_ArRiskList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>风险处置表格</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
    <link href="/css/Sys.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/common.js?t="<%=t_rand %>></script>
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="/Script/js/highcharts.js"></script>
</head>
<body>
    <form runat="server" id="rFrom">
        <asp:ScriptManager runat="server" ID="ScriptManager">
        </asp:ScriptManager>
        <section class="container">
            <div class="container-fluid">
                <fieldset>
                    <legend><small class="text-primary">风险监察</small></legend>
                    <!-- 查询条件 -->
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="deptList" class="input-group-addon">处室</label>
                                <select id="deptList" class="easyui-combobox" style="width:150px;height:35px;">
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="dplUserList" class="input-group-addon">人员</label>
                                <select id="dplUserList" class="easyui-combobox" style="width:150px;height:35px;">
                                </select>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="dplBusinessType" class="input-group-addon">业务类型</label>
                                <asp:DropDownList ID="dplBusinessType" runat="server" CssClass="easyui-combobox" Height="35px" Width="120px" data-options="panelHeight:'auto'">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtTitle" class="input-group-addon">公文标题</label>
                                <input type="text" runat="server" id="txtmName" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <br />

                    <!-- 查询条件（2） -->
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtsTime" class="input-group-addon">开始时间</label>
                                <asp:TextBox runat="server" ID="txtsTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="120px" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txteTime" class="input-group-addon">结束时间</label>
                                <asp:TextBox runat="server" ID="txteTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="120px" />
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                                <ContentTemplate>
                                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <br />
                    <!-- 数据展示 -->
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel0">
                                    <ContentTemplate>
                                        <table class="table table-hover table-condensed table-bordered cursor">
                                            <thead>
                                                <tr>
                                                    <th>序号</th>
                                                    <th>公文类型</th>
                                                    <th>提醒类型</th>
                                                    <th>公文标题</th>
                                                    <th>送达时间</th>
                                                    <th>办理时限</th>
                                                    <th>责任处室</th>
                                                    <th>责任人员</th>
                                                    <th>当前步骤</th>
                                                    <th>管理</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <Zore:Repeater ID="rpt_taskList" runat="server" OnItemDataBound="rpt_taskList_ItemDataBound" OnItemCommand="rpt_taskList_ItemCommand">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                                            <td><%# Eval("ARCHIVE_TYPE_NAME") %></td>
                                                            <td><%# Eval("REMIND_TYPE_NAME") %></td>
                                                            <td title="<%# Eval("ARCHIVE_TITLE")%>"><a href="javascript:void(0);" onclick='showDetail(<%# Eval("ARCHIVE_TYPE") %>,<%# Eval("ARCHIVE_ID") %>)'><%# S_App.Substr(Eval("ARCHIVE_TITLE").ToString(), 10) %></a></td>
                                                            <td><%# AidHelp.ShortTime(Eval("START_TIME")) %></td>
                                                            <td><%# AidHelp.ShortTime(Eval("LIMIT_TIME")) %></td>
                                                            <td><%# Eval("RES_DEPT") %></td>
                                                            <td><%# Eval("RES_USER") %></td>
                                                            <td><%# Eval("STEP_NAME") %></td>
                                                            <td>
                                                                <a href="javascript:void(0);" onclick='newRisk(<%# Eval("ARCHIVE_TYPE") %>,<%# Eval("ARCHIVE_ID") %>,<%# Eval("OVER_TIME_RISK_REMIND_ID") %>,<%# Eval("REMIND_TYPE") %>,<%# Eval("RESPONSE_USER_ID") %>)'>生成风险处置单</a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <tr>
                                                            <td colspan="11">暂无数据</td>
                                                        </tr>
                                                    </EmptyDataTemplate>
                                                </Zore:Repeater>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- 分页 -->
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                                runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                                PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Always"
                                OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                                HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                            </AspNetPager:AspNetPager>
                        </div>
                    </div>
                </fieldset>
            </div>
        </section>
        <asp:HiddenField runat="server" ID="hidDeptName" />
        <asp:HiddenField runat="server" ID="hidDeptId" />
        <asp:HiddenField runat="server" ID="hidUserName" />
        <asp:HiddenField runat="server" ID="hidUserID" />
    </form>
    <script type="text/javascript">
        //新建风险处置
        function newRisk(ptypeId, p_Id, rId, rmID, uid) {
            $.layer({
                type: 2,
                title: '新建风险处置',
                iframe: { src: '/Risk/newArRisk.aspx?ptype=' + ptypeId + '&p_Id=' + p_Id + '&rId=' + rId + '&rmID=' + rmID + '&uid=' + uid + '' },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }
        //办理风险处置
        function doWork(tID, arId) {
            $.layer({
                type: 2,
                title: '办理风险处置',
                iframe: { src: '/Risk/newArRisk.aspx?tId=' + tID + '&arId=' + arId },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }
        //查看风险处置
        function selWork(arId) {
            $.layer({
                type: 2,
                title: '查看风险处置',
                iframe: { src: '/Risk/sel_risk.aspx?arId=' + arId + '' },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }
        //模拟查询点击
        function doRefresh() {
            document.getElementById('<%=btnSearch.ClientID %>').click();
        }
        //查看
        function showDetail(archive_type, archive_id) {
            switch (archive_type) {
                case 10:
                    src = "/Archive/sel_Generalpieces.aspx?arid=" + archive_id + "";
                    break;
                case 11:
                    src = "/Archive/sel_Ordinarypieces.aspx?arid=" + archive_id + "";
                    break;
                case 12:
                    src = "/Archive/sel_UnitDoc.aspx?arid=" + archive_id + "";
                    break;
                case 20: case 21: case 22: case 23:
                    src = "/Archive/sel_supInfo.aspx?arid=" + archive_id + "";
                    break;
                case 24:
                    src = "/Admin/sel_Proposal.aspx?arid=" + archive_id + "";
                    break;
                case 32:
                    src = "/Admin/sel_Personnal.aspx?arid=" + archive_id + "";
                    break;
                case 33:
                    src = "/Admin/selFinance.aspx?pid=" + archive_id + "";
                    break;
                case 40: case 41: case 42: case 43: case 44:
                    src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                    break;
                case 51:
                    src = "/Risk/sel_risk.aspx?arid=" + archive_id + "";
                    break;
            }
            $.layer({
                type: 2,
                title: "公文查看",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '600px'],
                offset: ['10px', ''],
                iframe: { src: src }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#deptList').combobox({
                url: '/Risk/UserControls/Ajax.aspx?queryState=dept',
                valueField: '_department_id',
                textField: '_department_name',
                onSelect: function () {
                    $("#dplUserList").combobox('clear');
                    $("#hidDeptId").val($('#deptList').combobox('getValue'));
                    $("#hidDeptName").val($('#deptList').combobox('getText'));
                    if ($("#hidDeptId").val() != 0) {
                        $('#dplUserList').combobox({
                            url: '/Risk/UserControls/Ajax.aspx?queryState=user&queryId=' + $("#hidDeptId").val(),
                            valueField: '_user_id',
                            textField: '_full_name',
                            panelHeight: 'auto'
                        });
                        $('#dplUserList').combobox('setValue', '0');
                    }
                }
            });

            $('#dplUserList').combobox({
                onSelect: function () {
                    $("#hidUserId").val($('#dplUserList').combobox('getValue'));
                    $("#hidUserName").val($('#dplUserList').combobox('getText'));
                }
            });
        });
    </script>
</body>
</html>
