<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyQuestion.aspx.cs" Inherits="Risk_DailyQuestion" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>每日一题统计</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="../Script/js/highcharts.js"></script>
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager">
        </asp:ScriptManager>
        <section class="container">
            <div class="container-fluid">
                <fieldset>
                    <legend><small class="text-primary">每日一题统计</small></legend>
                    <!-- 查询条件 -->
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="deptList" class="input-group-addon">部门</label>
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
                        <div class="col-sm-2">
                            <div class="input-group">
                                <label for="txtSDate" class="input-group-addon">开始</label>
                                <input type="text" runat="server" class="form-control" id="txtSDate" readonly="true" onclick="WdatePicker();" />
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="input-group">
                                <label for="txtEDate" class="input-group-addon">结束</label>
                                <input type="text" runat="server" class="form-control" id="txtEDate" readonly="true" onclick="WdatePicker();" />
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                                <ContentTemplate>
                                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" OnClientClick="loadChart()" />
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
                                                    <th>人员</th>
                                                    <th>总共答题</th>
                                                    <th>回答正确</th>
                                                    <th>回答错误</th>
                                                    <%--<th>跳过</th>--%>
                                                    <th>正确率</th>
                                                    <th>错误率</th>
                                                    <%--<th>跳过率</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpt_EdayQuestionList" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %></td>
                                                            <td><%# Eval("UserName") %></td>
                                                            <td><a href="javascript:void(0)" onclick="showDetail(<%# Eval("UserId") %>,0)"><%# Eval("TotalCount") %></a></td>
                                                            <td><a href="javascript:void(0)" onclick="showDetail(<%# Eval("UserId") %>,1)"><%# Eval("CorrectCount") %></a></td>
                                                            <td><a href="javascript:void(0)" onclick="showDetail(<%# Eval("UserId") %>,2)"><%# Eval("ErrorCount") %></a></td>
                                                            <%--<td><a href="javascript:void(0)" onclick="showDetail(<%# Eval("UserId") %>,3)"><%# Eval("SkipCount") %></a></td>--%>
                                                            <td><%# Eval("CorrectRate") %></td>
                                                            <td><%# Eval("ErrorRate") %></td>
                                                            <%--<td><%# Eval("SkipRate") %></td>--%>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
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
                            <asp:UpdatePanel runat="server" ID="UpdatePanel_t">
                                <ContentTemplate>
                                    <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                                        runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                                        PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Always"
                                        OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                                        HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                                    </AspNetPager:AspNetPager>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <!-- 统计图 -->
                    <div class="row" style="display:none">
                        <div class="col-xs-6 text-center">
                            <div id="Errcontainer" style="float: left; height: 350px;"></div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </section>
        <asp:HiddenField runat="server" ID="hidDeptId" />
        <asp:HiddenField runat="server" ID="hidUserId" />
        <asp:HiddenField runat="server" ID="hidDeptName" />
        <asp:HiddenField runat="server" ID="hidUserName" />
    </form>
</body>
</html>

<script type="text/javascript">
    $(function () {
        $('#deptList').combobox({
            url: '/Risk/UserControls/Ajax.aspx?queryState=dept',
            valueField: '_department_id',
            textField: '_department_name',
            onSelect: function () {
                $("#dplUserList").combobox('clear');
                $("#hidDeptId").val($('#deptList').combobox('getValue'));
                if ($("#hidDeptId").val() != 0) {
                    $('#dplUserList').combobox({
                        url: '/Risk/UserControls/Ajax.aspx?queryState=user&queryId=' + $("#hidDeptId").val(),
                        valueField: '_user_id',
                        textField: '_full_name'
                    });
                    $('#dplUserList').combobox('setValue', '0');
                }
            }
        });

        $('#dplUserList').combobox({
            onSelect: function () {
                $("#hidUserId").val($('#dplUserList').combobox('getValue'));
            }
        });

        loadChart();
    });

    function showDetail(uid, sid) {
        location.href = '/IncorruptEdu/EdayQuestionList.aspx?user_id=' + uid + "&state=" + sid;
    }

    var $deptId, $userId, $sDate, $eDate;
    var seriesOptions = new Array();
    function loadChart() {
        $deptId = $('#deptList').combobox('getValue');
        $userId = $('#dplUserList').combobox('getValue');
        $sDate = $("#<%=txtSDate.ClientID%>").val();
        $eDate = $("#<%=txtEDate.ClientID%>").val();
        $.getJSON('/Risk/UserControls/Ajax.aspx?rand=' + Math.random().toString(), {
            queryState: "Err",
            deptid: $deptId,
            userid: $userId,
            sdate: $sDate,
            edate: $eDate
        }, function (data) {
            seriesOptions.length = 0; //清空
            if (data.length == 0) { $("#Errcontainer").empty(); return; }
            for (var i = 0; i < data.length; i++) {
                seriesOptions[i] = [data[i].name, data[i].value]; //
            }
            createChart('Errcontainer', '每日一题/错误率');
        });
    }

    function createChart(id, name) {
        $('#' + id).highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
            },
            title: {
                text: name
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.y}%</b>;'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        color: '#000000',
                        connectorColor: '#000000',
                        format: '<b>{point.name}</b>: {point.y}%'
                    },
                }
            },
            series: [{
                type: 'pie',
                name: '错误率',
                data: seriesOptions,
            }]
        })
    };
</script>
