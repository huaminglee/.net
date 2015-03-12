<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucArchiveTongji.ascx.cs" Inherits="Risk_UserControls_ucArchiveTongji" %>
<asp:ScriptManager runat="server" ID="ScriptManager">
</asp:ScriptManager>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">业务数据统计</small></legend>
            <!-- 查询条件（1） -->
            <%--<div class="row">
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
            <br />--%>
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
               
                
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    
                            <asp:Button ID="btnSearch" runat="server" Text="按类型分类查询" CssClass="btn btn-primary"  OnClick="btnSearch_Click" />
                       
                </div>
                 <div class="col-sm-3">
                    
                            <asp:Button ID="btnSerachPerson" runat="server" Text="按人员分类查询" CssClass="btn btn-primary"  OnClick="btnSearchP_Click" />
                       
                </div>
                 <div class="col-sm-3">
                    
                            <asp:Button ID="btnSearchDept" runat="server" Text="按部门分类查询" CssClass="btn btn-primary"  OnClick="btnSearchD_Click" />
                       
                </div>
            </div>
            <br />
            <!-- 数据展示 -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive">
                         
                        <asp:GridView ID="GridView1" class="table table-hover table-condensed table-bordered cursor" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="ARCHIVE_TYPE_NAME" HeaderText="业务类型" />
                                <asp:BoundField DataField="Totalnum" HeaderText="业务总数" />
                                
                                <asp:TemplateField HeaderText="已办数量">
                                    <ItemTemplate>
                                        <asp:Label ID="lbfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未办数量">
                                    <ItemTemplate>
                                         <asp:Label ID="lbunfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvPerson" class="table table-hover table-condensed table-bordered cursor" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvPerson_RowDataBound" ShowFooter="True" Visible="False">
                            <Columns>
                                <asp:BoundField DataField="FULL_NAME" HeaderText="人员" />
                                <asp:BoundField DataField="Totalnum" HeaderText="业务总数" />
                                
                                <asp:TemplateField HeaderText="已办数量">
                                    <ItemTemplate>
                                        <asp:Label ID="lbfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未办数量">
                                    <ItemTemplate>
                                         <asp:Label ID="lbunfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvDept" class="table table-hover table-condensed table-bordered cursor" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvDept_RowDataBound" ShowFooter="True" Visible="False">
                            <Columns>
                                <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="部门" />
                                <asp:BoundField DataField="Totalnum" HeaderText="业务总数" />
                                
                                <asp:TemplateField HeaderText="已办数量">
                                    <ItemTemplate>
                                        <asp:Label ID="lbfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="未办数量">
                                    <ItemTemplate>
                                         <asp:Label ID="lbunfinished" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <!-- 统计图 -->
           <%-- <div class="row">
                <div class="col-xs-6 text-center">
                    <div id="Extcontainer" style="float: left; height: 345px;"></div>
                </div>
                <div class="col-xs-6 text-center">
                    <div id="Viocontainer" style="float: left; height: 345px;"></div>
                </div>
            </div>--%>
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
       // loadhighs();
    });

    var $deptName, $userName, $title, $sdate, $edate, $archiveno, $business;
    var seriesOptions = new Array();
    function loadhighs() {
        $("#Extcontainer").html("");
        $("#Viocontainer").html("");
        $deptName = $("#deptList").find("option:selected").text();
        $userName = $("#dplUserList").find("option:selected").text();
    
        $sdate = $("#<%=txtsTime.ClientID%>").val();
        $edate = $("#<%=txteTime.ClientID%>").val();
       
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
                text: "风险处置/" + name
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