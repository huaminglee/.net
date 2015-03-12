<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="CRM.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/stylenew.css" rel="stylesheet" type="text/css" />
    <link href="CSS/default.css" rel="stylesheet" type="text/css" />

    <script src="js/menu.js" type="text/javascript"></script>

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="NewScript/Ifream.js" type="text/javascript"></script>

</head>
<body onload="javascript:border_left('left_tab1','left_menu_cnt1');">
    <form id="form1" runat="server">
    <table id="indextablebody" cellpadding="0">
        <thead>
            <tr>
                <th>
                    <div id="logo" title="用户管理后台">
                    </div>
                </th>
                <th>
                    <a style="color: #16547E">用户 ：admin</a>&nbsp;&nbsp; <a style="color: #16547E">身份 ：超级管理员</a>&nbsp;&nbsp;
                    <a href="javascript:window.location.reload()" target="content3">隐藏工作台</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                    <a href="javascript:window.location.reload()" target="content3">管理首页</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                    <a href="help" target="_blank">使用帮助</a>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="menu">
                    <ul class="bigbtu">
                        <li id="now01"><a title="安全退出" href="#">安全退出</a></li>
                        <li id="now02"><a title="系統首頁" href="#">系統首頁</a></li>
                    </ul>
                </td>
                <td class="tab">
                    <ul id="tabpage1">
                        <%--<li id="tab1" title="管理首页"><span id="spanTitle">管理首页</span></li>--%>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="t1">
                    <div id="contents">
                        <table cellpadding="0">
                            <tr class="t1">
                                <td>
                                    <div class="menu_top">
                                    </div>
                                </td>
                            </tr>
                            <tr class="t2">
                                <td>
                                    <div id="menu" class="menu">
                                        <ul class="tabpage2">
                                            <li id="left_tab1" title="操作菜单" onclick="javascript:border_left('left_tab1','left_menu_cnt1');">
                                                <span>報價單管理</span></li>
                                        </ul>
                                        <div id="left_menu_cnt1" class="left_menu_cnt">
                                            <ul id="dleft_tab1">
                                                <li class="now11"><a target="MainFrame" href="Quotation/QuotationDetail.aspx">新增報價單</a></li>
                                                <li class="now12"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=0">我的報價單</a></li>
                                                <li class="now13"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=1">待送審報價單</a></li>
                                                <li class="now14"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=3">待主管審核</a></li>
                                                <li class="now15"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=2">待生成PDF</a></li>
                                                <li class="now16"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=4">待客戶回傳</a></li>
                                                <li class="now17" runat="server" visible="false"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=99">
                                                    已填單測試中</a></li>
                                                <li><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=88">異常結案待處理</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab2" onclick="javascript:border_left('left_tab2','left_menu_cnt2');"
                                                title="操作菜单"><span>我的工作</span></li>
                                        </ul>
                                        <div id="left_menu_cnt2" class="left_menu_cnt">
                                            <ul id="dleft_tab2">
                                                <li class="now11" id="Li3" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=77">
                                                    報價單待審核</a></li>
                                                <li class="now11" id="reportsh" visible="false" runat="server"><a target="MainFrame"
                                                    href="Quotation/ReportDetailList.aspx?Type=2">報告待審核</a></li>
                                                <li class="now11" id="Li2" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=0">
                                                    進行中案件</a></li>
                                                <li class="now11" id="Li1" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=10">
                                                    已結案</a></li>
                                                <li class="now11" id="yichang" runat="server" visible="false"><a target="MainFrame"
                                                    href="Quotation/QuotationList.aspx?Type=88">異常結案待處理</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab3" onclick="javascript:border_left('left_tab3','left_menu_cnt3');"
                                                title="報告處理"><span>報告處理</span></li>
                                        </ul>
                                        <div id="left_menu_cnt3" class="left_menu_cnt">
                                            <ul id="dleft_tab3">
                                                <li class="now11" id="work4" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=99">
                                                    測試案件待處理</a></li>
                                                <li class="now11" id="work1" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=1">
                                                    測試完成待處理</a></li>
                                                <li class="now11" id="worke2" runat="server"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=2">
                                                    待主管審核</a></li>
                                                <li class="now11"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=55">
                                                    待寄樣品</a></li>
                                                <li class="now11"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=77">
                                                    待寄發票</a></li>
                                                <li class="now11" id="work3" runat="server"><a target="MainFrame" href="Quotation/QuotationList.aspx?Type=10">
                                                    已結案</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab4" onclick="javascript:border_left('left_tab4','left_menu_cnt4');"
                                                title="經管工作"><span>經管工作</span></li>
                                        </ul>
                                        <div id="left_menu_cnt4" class="left_menu_cnt">
                                            <ul id="dleft_tab4">
                                                <li class="now11"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=3">
                                                    收款確認</a></li>
                                                <li class="now11"><a target="MainFrame" href="Quotation/ReportDetailList.aspx?Type=66">
                                                    開發票</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab5" onclick="javascript:border_left('left_tab5','left_menu_cnt5');"
                                                title="對賬統計"><span>對賬統計</span></li>
                                        </ul>
                                        <div id="left_menu_cnt5" class="left_menu_cnt">
                                            <ul id="dleft_tab5">
                                                <li id="duizhang" runat="server"><a target="MainFrame" href="Quotation/ReconcieldList.aspx">
                                                    待對賬</a></li>
                                                <li><a target="MainFrame" href="Quotation/Statistics.aspx">報價單統計</a></li>
                                                <li id="leadreport" runat="server" visible="false"><a target="MainFrame" href="Quotation/LeaderReport.aspx">
                                                    綜合統計</a></li>
                                                <li><a target="MainFrame" href="Quotation/jinguantongji.aspx">應收統計</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab6" onclick="javascript:border_left('left_tab6','left_menu_cnt6');"
                                                title="系統管理"><span>系統管理</span></li>
                                        </ul>
                                        <div id="left_menu_cnt6" class="left_menu_cnt">
                                            <ul id="dleft_tab6">
                                                <li><a target="MainFrame" href="Forms/ContactList.aspx?Type=0">用戶管理</a></li>
                                                <li><a target="MainFrame" href="Forms/CustomersList.aspx?IsManage=1">客戶管理</a></li>
                                                <li><a target="MainFrame" href="Forms/TestItemManage.aspx">測試項目管理</a></li>
                                                <li><a target="MainFrame" href="Forms/Syssetting.aspx">系統設定</a></li>
                                                <li><a target="MainFrame" href="Gonggao/SysNewsList.aspx">網站消息</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab7" onclick="javascript:border_left('left_tab7','left_menu_cnt7');"
                                                title="系統公告"><span>系統公告</span></li>
                                        </ul>
                                        <div id="left_menu_cnt7" class="left_menu_cnt">
                                            <ul id="dleft_tab7">
                                                <li><a target="MainFrame" href="Gonggao/SysNewsList.aspx">CRM公告</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab8" onclick="javascript:border_left('left_tab8','left_menu_cnt8');"
                                                title="個人中心"><span>個人中心</span></li>
                                        </ul>
                                        <div id="left_menu_cnt8" class="left_menu_cnt">
                                            <ul id="dleft_tab8">
                                                <li><a target="MainFrame" href="Forms/UserADVInfo.aspx">我的個人信息</a></li>
                                                <li id="cus" runat="server" visible="false"><a target="MainFrame" href="Forms/CustomerDetail.aspx">
                                                    我的公司信息</a></li>
                                                <li id="yewu4" runat="server"><a target="MainFrame" href="Forms/CustomersList.aspx">
                                                    我的客戶</a></li>
                                                <li><a target="MainFrame" href="Forms/ContactManage.aspx?Type=2">我的聯繫人</a></li>
                                                <li><a target="MainFrame" href="Forms/MyWebFile.aspx">我的網絡硬盤</a></li>
                                                <li><a target="MainFrame" href="Forms/UserLog.aspx">登陸日誌</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab9" onclick="javascript:border_left('left_tab9','left_menu_cnt9');"
                                                title="市場管理"><span>市場管理</span></li>
                                        </ul>
                                        <div id="left_menu_cnt9" class="left_menu_cnt">
                                            <ul id="dleft_tab9">
                                                <li><a target="MainFrame" href="Forms/MarketPlanList.aspx">營銷活動管理</a></li>
                                                <li><a target="MainFrame" href="Forms/BusOppList.aspx">業務機會管理</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <ul class="tabpage2">
                                            <li id="left_tab10" onclick="javascript:border_left('left_tab10','left_menu_cnt10');"
                                                title="客戶關懷"><span>客戶關懷</span></li>
                                        </ul>
                                        <div id="left_menu_cnt10" class="left_menu_cnt">
                                            <ul id="dleft_tab10">
                                                <li><a target="MainFrame" href="http://10.162.197.5/cmcfilemanage/Forms/ComplaintsList.aspx">
                                                    客戶投訴</a></li>
                                                <li style="display: none"><a target="MainFrame" href="Forms/GMPCSIList.aspx">客戶滿意度</a></li>
                                            </ul>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <tr class="t3">
                                        <td>
                                            <div class="menu_end">
                                            </div>
                                        </td>
                                    </tr>
                        </table>
                    </div>
                </td>
                <td class="t2">
                    <div id="cnt">
                        <div id="dtab1">
                            <iframe id="iframe1" name="MainFrame" src="Index.aspx" onload="iFrameHeight()" frameborder="0">
                            </iframe>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
 <div style="display: none">
        <asp:HiddenField ID="HidInitUrl" runat="server" />
        <asp:HiddenField ID="HidInitTitle" runat="server" />
    </div>
    <script>
        //修改标题
        function show_title(str) {
            document.getElementById("spanTitle").innerHTML = str;
        }
    </script>

    </form>
</body>
</html>
