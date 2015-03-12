<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CRM._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Shortcut Icon" href="favicon.ico" />
    <title>客戶關係管理系統</title>
    <link href="CSS/reset.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/invalid.css" rel="stylesheet" type="text/css" />
    <link href="NewScript/themes/Default/easyui.css" rel="stylesheet" type="text/css" />

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="NewScript/jquery.easyui.min.js" type="text/javascript"></script>

    <script src="NewScript/simpla.jquery.configuration.js" type="text/javascript"></script>

    <script src="NewScript/facebox.js" type="text/javascript"></script>

    <script src="NewScript/jquery.wysiwyg.js" type="text/javascript"></script>

    <script src="NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="NewScript/Ifream.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function LoadMessage(SerType, isBottom) {

            $.ajax({
                type: "post",
                url: "action/WebService.asmx/GetSysNews",
                data: { 'SercvicePKID': "" + SerType + "" },
                dataType: 'xml',
                success: function(result) {
                    if (isBottom) {
                        var timeout = 10000;
                        var rowNumber = $(result).find("Table").length;
                        timeout = timeout * rowNumber;
                        showMessage(result, timeout);
                        setInterval(function() { showMessage(result, timeout) }, 600000);
                    }
                    else {
                        $(result).find("Table").each(function() {
                            var Ptitle = $(this).find("NewTitle").text();
                            var PContent = $(this).find("NewContent").text();
                            PContent = myHTMLDeCode(PContent);
                            $.messager.defaults = { ok: "關閉)" };
                            $.messager.alert(Ptitle, PContent);

                        });
                    }
                },
                error: function(x, e, errorThrown) {
                    // alert(errorThrown);
                    alert(x.responseText);
                }
            });
        }
        function showMessage(result, timeout) {
            $(result).find("Table").each(function() {
                var Ptitle = $(this).find("NewTitle").text();
                var PContent = $(this).find("NewContent").text();
                PContent = myHTMLDeCode(PContent);
                $.messager.defaults = { ok: "關閉)" };
                $.messager.show({ width: 300, height: 200, title: Ptitle, msg: PContent, timeout: timeout, showType: 'fade' });
                timeout = timeout - 5000;
            });
        }
        function myHTMLEnCode(str) {
            var s = "";
            if (str.length == 0) return "";
            s = str.replace(/&/g, "&amp;");
            s = s.replace(/</g, "&lt;");
            s = s.replace(/>/g, "&gt;");
            //  s = s.replace(/ /g, "&nbsp;");
            s = s.replace(/\'/g, "&#39;");
            s = s.replace(/\"/g, "&quot;");
            //  s = s.replace(/\n/g, "<br>");
            return s;
        }

        function myHTMLDeCode(str) {
            var s = "";
            if (str.length == 0) return "";
            s = str.replace(/&amp;/g, "&");
            s = s.replace(/&lt;/g, "<");
            s = s.replace(/&gt;/g, ">");
            // s = s.replace(/&nbsp;/g, " ");
            s = s.replace(/&#39;/g, "\'");
            s = s.replace(/&quot;/g, "\"");
            s = s.replace(/<br>/g, "\n");
            return s;
        }

        $(function() {
            LoadMessage(0, true);
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="body-wrapper">
        <div id="sidebar">
            <div id="sidebar-wrapper">
                <!-- Sidebar with logo and menu -->
                <h1 id="sidebar-title">
                    <a href="">客戶關係管理系統</a></h1>
                <!-- Logo (221px wide) -->
                <a target="MainFrame" href="Index.aspx">
                    <img id="logo" src="images/logomin.png" alt="客戶關係管理系統" width="180px" /></a>
                <!-- Sidebar Profile links -->
                <div id="profile-links">
                    Hello, <a id="username" runat="server" target="MainFrame" href="Forms/UserADVInfo.aspx">
                    </a>
                    <br />
                    <asp:LinkButton ID="LKBlogoOUT" runat="server">Sign Out</asp:LinkButton>
                </div>
                <ul id="main-nav">
                    <!-- Accordion Menu -->
                    <li><a class="nav-top-item current no-submenu" target="MainFrame" href="Index.aspx">
                        <!-- Add the class "no-submenu" to menu items with no sub menu -->
                        首頁 </a></li>
                    <li id="yewu1" visible="false" runat="server"><a href="" class="nav-top-item ">
                        <!-- Add the class "current" to current menu item -->
                        報價單管理 </a>
                        <ul>
                         <li id="inquote" runat ="server" visible ="false" ><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=90">所有進行中案件</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationDetail.aspx">新增報價單</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=0">我的報價單</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=1">待送審報價單</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=3">待主管審核</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=2">待生成PDF</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=4">待客戶回傳</a></li>
                            <li runat="server" visible="false"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=99">
                                已填單測試中</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=88">異常結案待處理</a></li>
                        </ul>
                    </li>
                    <li id="zhuguanwork" visible="false" runat="server"><a href="" class="nav-top-item ">
                        <!-- Add the class "current" to current menu item -->
                        我的工作 </a>
                        <ul>
                            <li id="Li3" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=77">
                                報價單待審核</a></li>
                            <li id="reportsh" visible="false" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=2">
                                報告待審核</a></li>
                            <li id="Li2" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=0">
                                進行中案件</a></li>
                            <li id="Li1" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=10">
                                已結案</a></li>
                            <li id="yichang" runat="server" visible="false"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=88">
                                異常結案待處理</a></li>
                                <li id="Li4" runat="server"><a target="MainFrame" href="Forms/CusVisitList.aspx?Type=3">
                                客戶拜訪待處理</a></li>
                                <li id="Li5" runat="server"><a target="MainFrame" href="Forms/CusVisitList.aspx?Type=4">
                                客戶拜訪已完成</a></li>
                        </ul>
                    </li>
                    <li id="Customerwork1" runat="server" visible="false"><a href="Quotation/QuotationList.aspx?Type=55"
                        class="nav-top-item no-submenu">測試進度查詢</a></li>
                    <li id="Customerwork2" runat="server" visible="false"><a href="Quotation/QuotationList.aspx?Type=54"
                        class="nav-top-item no-submenu">下載回傳報價單</a></li>
                    <li id="CustomerWork" runat="server" visible="false"><a href="Quotation/ReportDetailList.aspx?Type=10"
                        class="nav-top-item no-submenu">我的報告</a>
                        <%--<li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=4">待我回傳的報價單</a></li>
                            <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=7">待我下載報告</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=55">報價中案件</a></li>
                            <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=66">測試中案件</a></li>
                            <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=8">報告處理中案件</a></li>--%>
                    </li>
                    <li id="yewu3" visible="false" runat="server"><a href="" class="nav-top-item">測試管理</a><ul>
                        <li><a target="MainFrame" href="Quotation/TestApplyList.aspx?Type=3">倉庫待收件</a></li>
                        <li><a target="MainFrame" href="Quotation/TestApplyList.aspx?Type=4">實驗室待收件</a></li>
                        <li><a target="MainFrame" href="Quotation/TestApplyList.aspx?Type=5">測試中案件</a></li>
                        <li><a target="MainFrame" href="Quotation/TestApplyList.aspx?Type=6">測試已完成</a></li>
                    </ul>
                    </li>
                    <li id="yewu2" visible="false" runat="server"><a href="" class="nav-top-item">報告處理</a><ul>
                        <li id="work4" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=99">
                            測試案件待處理</a></li>
                        <li id="work1" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=1">
                            測試完成待處理</a></li>
                             <li ><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=3">
                            待確認收款</a></li>
                        <li id="worke2" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=2">
                            待主管審核</a></li>
                        <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=55">待寄樣品</a></li>
                        <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=77">待寄發票</a></li>
                         <li id="Allreport" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=70">
                            所有案件</a></li>
                        <li id="work3" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=10">
                            已結案</a></li>
                    </ul>
                    </li>
                    <li id="jinguan" runat="server" visible="false"><a href="" class="nav-top-item">經管工作
                    </a>
                        <ul>
                            <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=3">收款確認</a></li>
                            <li><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=66">開發票</a></li>
                        </ul>
                    </li>
                    <li id="Tongji" visible="false" runat="server"><a href="" class="nav-top-item">對賬統計</a><ul>
                        <li id="duizhang" runat="server"><a target="MainFrame" href="Quotation/ReconcieldList.aspx">
                            待對賬</a></li>
                        <li><a target="MainFrame" href="Quotation/Statistics.aspx">報價單統計</a></li>
                        <li id="leadreport" runat="server" visible="false"><a target="MainFrame" href="Quotation/LeaderReport.aspx">
                            綜合統計</a></li>
                        <li><a target="MainFrame" href="Quotation/jinguantongji.aspx">應收統計</a></li>
                    </ul>
                    </li>
                    <li id="store" visible="false" runat="server"><a href="" class="nav-top-item">倉庫管理
                    </a>
                        <ul>
                            <li><a target="MainFrame" href="Quotation/AddSampleReceived.aspx">收樣品</a></li>
                           <%-- <li><a target="MainFrame" href="Quotation/SendSampleList.aspx?Type=1">寄樣品</a></li>
                            <li><a target="MainFrame" href="Quotation/SendSampleList.aspx?Type=2">寄發票</a></li>--%>
                            <li><a target="MainFrame" href="Quotation/SampelReceivedList.aspx?Type=0">未签收</a></li>
                            <li><a target="MainFrame" href="Quotation/SampelReceivedList.aspx?Type=1">已签收</a></li>
                            <li><a target="MainFrame" href="Quotation/SampelReceivedList.aspx?Type=2">全部已收樣品</a></li>
                           <%-- <li><a target="MainFrame" href="Quotation/SendSampleList.aspx?Type=10">已寄樣品</a></li>
                            <li><a target="MainFrame" href="Quotation/SendSampleList.aspx?Type=20">已寄發票</a></li>--%>
                        </ul>
                    </li>
                    <li id="manage" visible="false" runat="server"><a href="" class="nav-top-item">系統管理
                    </a>
                        <ul>
                            <li><a target="MainFrame" href="Forms/ContactList.aspx?Type=0">用戶管理</a></li>
                            <li><a target="MainFrame" href="Forms/CustomersList.aspx?IsManage=1">客戶管理</a></li>
                            <li id="itemmanage" runat ="server" visible ="false" ><a target="MainFrame" href="Forms/TestItemManage.aspx">測試項目管理</a></li>
                            <li><a target="MainFrame" href="Forms/Syssetting.aspx">系統設定</a></li>
                            <li><a target="MainFrame" href="Gonggao/SysNewsList.aspx">網站消息</a></li>
                            <li id="sysuse" runat ="server" visible ="false" ><a target="MainFrame" href="Forms/UseStatistics.aspx">系統使用情況</a></li>
                        </ul>
                    </li>
                    <li id="gonggao" visible="false" runat="server"><a class="nav-top-item no-submenu"
                        target="MainFrame" href="Gonggao/SysNewsList.aspx">
                        <!-- Add the class "no-submenu" to menu items with no sub menu -->
                        系統公告 </a></li>
                    <li id="usercenter" visible="false" runat="server"><a href="" class="nav-top-item">個人中心
                    </a>
                        <ul>
                            <li><a target="MainFrame" href="Forms/UserADVInfo.aspx">我的個人信息</a></li>
                            <li id="cus" runat="server" visible="false"><a target="MainFrame" href="Forms/CustomerDetail.aspx">
                                我的公司信息</a></li>
                            <li id="yewu4" runat="server"><a target="MainFrame" href="Forms/CustomersList.aspx">
                                我的客戶</a></li>
                            <li><a target="MainFrame" href="Forms/ContactManage.aspx?Type=2">我的聯繫人</a></li>
                            <li><a target="MainFrame" href="Forms/MyWebFile.aspx">我的網絡硬盤</a></li>
                            <li><a target="MainFrame" href="Forms/UserLog.aspx">登陸日誌</a></li>
                            <li id="Li6" runat="server"><a target="MainFrame" href="Forms/CusVisitList.aspx?Type=1">
                                客戶拜訪待處理</a></li>
                                <li id="Li7" runat="server"><a target="MainFrame" href="Forms/CusVisitList.aspx?Type=2">
                                客戶拜訪已完成</a></li>
                        </ul>
                    </li>
                    <li id="divSell" visible="false" runat="server"><a href="" class="nav-top-item">市場管理
                    </a>
                        <ul>
                            <li><a target="MainFrame" href="Forms/MarketPlanList.aspx">營銷活動管理</a></li>
                            <li><a target="MainFrame" href="Forms/BusOppList.aspx">業務機會管理</a></li>
                        </ul>
                    </li>
                    <li id="DIVComplaints" visible="false" runat="server"><a href="" class="nav-top-item">
                        客戶關懷 </a>
                        <ul>
                            <li><a target="MainFrame" href="http://10.162.197.5/cmcfilemanage/Forms/ComplaintsList.aspx">
                                客戶投訴</a></li>
                            <li style="display: none"><a target="MainFrame" href="Forms/GMPCSIList.aspx">客戶滿意度</a></li>
                        </ul>
                    </li>
                </ul>
                <!-- End main-nav -->
            </div>
        </div>
        <div id="main-content">
            <div>
                <iframe id="iframe1" name="MainFrame" frameborder="0" marginheight="0" marginwidth="0"
                    scrolling="no" src="Index.aspx" onload="iFrameHeight()"></iframe>
            </div>
            <div id="footer">
                <small>&#169; Copyright 2013 CMC | <a href="#">Top</a> </small>
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:HiddenField ID="HidInitUrl" runat="server" />
        <asp:HiddenField ID="HidInitTitle" runat="server" />
    </div>
    </form>
</body>
</html>
