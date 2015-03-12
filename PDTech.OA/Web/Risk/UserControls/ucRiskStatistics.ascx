<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRiskStatistics.ascx.cs" Inherits="Risk_UserControls_ucRiskStatistics" %>

<asp:ScriptManager runat="server" ID="ScriptManager">
</asp:ScriptManager>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">风险评估统计</small></legend>
            <!-- 查询条件（1） -->
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
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="dplBusinessType" class="input-group-addon">业务类型</label>
                        <asp:DropDownList ID="dplBusinessType" runat="server" CssClass="easyui-combobox" Height="35px" Width="120px" data-options="panelHeight:'auto'">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtTitle" class="input-group-addon">风险标题</label>
                        <input type="text" runat="server" id="txtTitle" class="form-control" />
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
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtArchiveNo" class="input-group-addon">业务件号</label>
                        <asp:TextBox ID="txtArchiveNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel">
                        <ContentTemplate>
                            <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClientClick="loadhighs();" OnClick="btnSearch_Click" />
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
                                            <th style="width: 10%;">风险类型</th>
                                            <th style="width: 10%;">日常办公<asp:Label runat="server" ID="txtArchiveNum"></asp:Label></th>
                                            <th style="width: 10%;">督办工作<asp:Label runat="server" ID="txtSupNum"></asp:Label></th>
                                            <th style="width: 10%;">行政审批<asp:Label runat="server" ID="txtAdminNum"></asp:Label></th>
                                            <th style="width: 10%;">人事任免<asp:Label runat="server" ID="txtPersonnelNum"></asp:Label></th>
                                            <th style="width: 10%;">水务工程项目<asp:Label runat="server" ID="txtProjectNum"></asp:Label></th>
                                            <th style="width: 10%;">教育任务<asp:Label ID="txtEdutaskNum" runat="server"></asp:Label>
                                            </th>
                                            <th style="width: 10%;">在线考试<asp:Label ID="txtOnlinetestNum" runat="server"></asp:Label>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr style="cursor: pointer;" > 
                                            <%--onclick="MainFramCh('Main_Frame.aspx?action=ucExtList&type=超期风险')"--%>
                                            <td>
                                                <asp:Label runat="server" ID="txtExtended" ForeColor="OrangeRed" Text="超期风险"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAichive" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtSup" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAdmin" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtPersonel" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtProject" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="txtEduTask" runat="server" ForeColor="OrangeRed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOnlineTest" runat="server" ForeColor="OrangeRed"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="cursor: pointer;" >
                                            <%--onclick="MainFramCh('Main_Frame.aspx?action=ucExtList&type=违规风险')"--%>
                                            <td>
                                                <asp:Label runat="server" ID="txtExtended0" ForeColor="OrangeRed" Text="违规风险"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAichive0" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtSup0" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAdmin0" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtPersonel0" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtProject0" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr style="cursor: pointer;" >
                                            <%--onclick="MainFramCh('Main_Frame.aspx?action=ucExtList&type=监督督查')"--%>
                                            <td>
                                                <asp:Label runat="server" ID="txtExtended_O" ForeColor="OrangeRed" Text="监督督查"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAichive_O" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtSup_O" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtAdmin_O" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtPersonel_O" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="txtProject_O" ForeColor="OrangeRed"></asp:Label></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- 统计图 -->
            <div class="row">
                <div class="col-xs-6 text-center">
                    <div id="Extcontainer" style="float: left; height: 345px;"></div>
                </div>
                <div class="col-xs-6 text-center">
                    <div id="Viocontainer" style="float: left; height: 345px;"></div>
                </div>
            </div>
        </fieldset>
    </div>
</section>
<asp:HiddenField runat="server" ID="hidDeptName" />
<asp:HiddenField runat="server" ID="hidDeptId" />
<asp:HiddenField runat="server" ID="hidUserName" />
<asp:HiddenField runat="server" ID="hidUserID" />

<script type="text/javascript">
    var strOption = "";
    var dId;
    $(function () {
        $('#deptList').combobox({
            url: '/Risk/UserControls/Ajax.aspx?queryState=dept',
            valueField: '_department_id',
            textField: '_department_name',
            onSelect: function () {
                $("#dplUserList").combobox('clear');
                $("#<%=hidDeptId.ClientID%>").val($('#deptList').combobox('getValue'));
                $("#<%=hidDeptName.ClientID%>").val($('#deptList').combobox('getText'));
                if ($("#<%=hidDeptId.ClientID%>").val() != 0) {
                    $('#dplUserList').combobox({
                        url: '/Risk/UserControls/Ajax.aspx?queryState=user&queryId=' + $("#<%=hidDeptId.ClientID%>").val(),
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
                $("#<%=hidUserID.ClientID%>").val($('#dplUserList').combobox('getValue'));
                $("#<%=hidUserName.ClientID%>").val($('#dplUserList').combobox('getText'));
            }
        });

        /*加载饼图*/
        loadhighs();
    });

    var $deptName, $userName, $title, $sdate, $edate, $archiveno, $business;
    var seriesOptions = new Array();
    function loadhighs() {
        $("#Extcontainer").html("");
        $("#Viocontainer").html("");
        $deptName = $("#deptList").find("option:selected").text();
        $userName = $("#dplUserList").find("option:selected").text();
        $title = $("#<%=txtTitle.ClientID%>").val();
        $business = $("#<%=dplBusinessType.ClientID%>").find("option:selected").text();
        $sdate = $("#<%=txtsTime.ClientID%>").val();
        $edate = $("#<%=txteTime.ClientID%>").val();
        $archiveno = $("#<%=txtArchiveNo.ClientID%>").val();
        $.getJSON('/Risk/UserControls/Ajax.aspx', {
            queryState: "Ext",
            deptname: encodeURIComponent($deptName),
            username: encodeURIComponent($userName),
            title: encodeURIComponent($title),
            business: encodeURIComponent($business),
            sdate: encodeURIComponent($sdate),
            edate: encodeURIComponent($edate),
            archiveno: encodeURIComponent($archiveno)
        }, function (data) {
            seriesOptions.length = 0; //清空
            if (data.length == 0) { return; }
            for (var i = 0; i < data.length; i++) {
                seriesOptions[i] = [data[i].name, data[i].value]
            }
            creaChart('Extcontainer', '类型');
        });
        $.getJSON('/Risk/UserControls/Ajax.aspx', {
            queryState: "Vio",
            deptname: encodeURIComponent($deptName),
            username: encodeURIComponent($userName),
            title: encodeURIComponent($title),
            business: encodeURIComponent($business),
            sdate: encodeURIComponent($sdate),
            edate: encodeURIComponent($edate),
            archiveno: encodeURIComponent($archiveno)
        }, function (data) {
            seriesOptions.length = 0; //清空
            if (data.length == 0) { return; }
            for (var i = 0; i < data.length; i++) {
                seriesOptions[i] = [data[i].name, data[i].value]
            }
            creaChart('Viocontainer', '部门');
        });
    }
    function creaChart(Id, name) {
        $('#' + Id).highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false
            },
            title: {
                text:"风险处置/"+ name
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>;数量: <b>{point.y}</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        color: '#000000',
                        connectorColor: '#000000',
                        format: '{point.name}: <b>{point.percentage:.1f}%</b>;数量: <b>{point.y}</b>'
                    },
                    showInLegend: true
                }
            },
            series: [{
                type: 'pie',
                name: '比例',
                data: seriesOptions,
            }]
        })
    };
</script>
