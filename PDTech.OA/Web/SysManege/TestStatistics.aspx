<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestStatistics.aspx.cs" Inherits="SysManege_TestStatistics" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>在线考试统计</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/detail.css?t=" <%=t_rand %> />
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
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
                    <!-- 统计图 -->
                    <div class="row">
                        <div style="width:100%">
                            <div id="columnContainer" style="height: 500px; "></div>
                        </div>
                    </div>
            </div>
        </section>
    </form>
</body>
</html>

<script type="text/javascript">
    var nameOptions = new Array();
    var scoreOptions = new Array();
    function loadChart() {
        $.getJSON('/Risk/UserControls/Ajax.aspx?rand=' + Math.random().toString(), { queryState: "score",tid:'<%=testId %>' },
            function (data) {
                nameOptions.length = 0;
                scoreOptions.length = 0;
                if (data.length == 0) { $("#columnContainer").empty(); return; }
                for (var i = 0; i < data.length; i++) {
                    nameOptions[i] = [data[i].name];
                    scoreOptions[i] = [data[i].value];
                }
                createChart('columnContainer', '分数统计', data[0].total);
        });
    }

    function createChart(id, name, total) {
        $('#' + id).highcharts({
            chart: {
                        type: 'column'
                    },
                    title: {
                        text: '在线考试成绩统计'
                    },
                    xAxis: {
                        categories: nameOptions
                    },
                    yAxis: {
                        min: 0,
                        max: total,
                        title: {
                            text: '分数[总分:' + total + '分]'
                        }
                    },
                    tooltip: {
                        headerFormat: '<span style="font-size:10px"><b>{point.key}</b></span><table>',
                        pointFormat: '<tr><td style="color:{series.color};padding:0"><b>{series.name}: </b></td>' +
                            '<td style="padding-left:3px"><b>{point.y} 分</b></td></tr>',
                        footerFormat: '</table>',
                        shared: true,
                        useHTML: true
                    },
                    plotOptions: {
                        column: {
                            pointPadding: 0.2,
                            borderWidth: 0
                        }
                    },
                    series: [{
                                name: '试卷[<%=testName%>]',
                                data: scoreOptions

                            }]
        })
    };

    $(function () {
        loadChart();
    });
</script>

