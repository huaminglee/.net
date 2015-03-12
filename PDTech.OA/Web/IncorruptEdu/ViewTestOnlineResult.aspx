<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTestOnlineResult.aspx.cs" Inherits="IncorruptEdu_ViewTestOnlineResult" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    .ddlinput
    {
        padding: 2px 3px;
        background: #fff;
        font-size: 1em;
        color: #000;
    }

    .notice_emal
    {
        width: 16px;
        height: 10px;
        overflow: hidden;
        background: url(../images/topsem_tag.png) no-repeat -82px -234px;
        margin: 0 auto;
    }

    .notice_emal_unread
    {
        background-position: -82px -246px;
    }

    .notice_unread td
    {
        font-weight: bold;
    }

    .btnIsRead
    {
        width: 120px;
        height: 27px;
        background-color: #f7ae1e;
        border-radius: 3px;
        padding-left: 10px;
        font-size: 14px;
        line-height: 26px;
        cursor: pointer;
        text-align: center;
        letter-spacing: 3px;
        border:none;
    }
</style>
    <link rel="stylesheet" type="text/css" href="/CSS/Sys.css?t="<%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t="<%=t_rand %> />
    <script type="text/javascript" src="../jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js?t="<%=t_rand %>></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Manage_Center_title" style="margin:0 auto;">
    我的考试结果
</div>
<div class="Manage_MainList" style="margin:0 auto;">
    <div class="Manage_MainList_top left">
        <div class="Fillet_lt_m left"></div>
        <div class="MainListNew_top_c left"></div>
        <div class="Fillet_rt_m left"></div>
    </div>
    <div class="MainListNew_Query left">
        <table>
            <tr>
                <td class="td_t">试卷名称：</td>
                <td class="tdl">
                    <asp:Label ID="lbTitle" runat="server" Text="" ForeColor="Blue"></asp:Label>
                </td>
                <td class="td_t">总分：</td>
                <td class="tdl">
                    <asp:Label ID="lbTotal" runat="server" Text="" ForeColor="Blue"></asp:Label>
                </td>
                <td class="td_t">我的得分：</td>
                <td class="tdl">
                    <asp:Label ID="lbScore" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="MainListNew2_box left">
        <table class="main_newtabList" cellpadding="0px" cellspacing="0px">
            <asp:Repeater ID="rpt_TestResultList" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><p style="white-space:normal;word-break:break-all;font-weight:bold;word-wrap : break-word;"><%# Container.ItemIndex+1+AspNetPager.PageSize*(AspNetPager.CurrentPageIndex-1) %>、<%# Eval("TITLE") %></p></td>
                    </tr>
                    <tr>
                        <td>A、<%# Eval("OPTIONA") %></td>
                    </tr>
                    <tr>
                        <td>B、<%# Eval("OPTIONB") %></td>
                    </tr>
                    <tr>
                        <td>C、<%# Eval("OPTIONC") %></td>
                    </tr>
                    <%# returnStr(Convert.ToString(Eval("OPTIOND"))) %>
                    <tr>
                        <td>您的选择：<span style="color:blue;"><%# GetSelectOption(Eval("EDU_Q_GUID").ToString()) %></span>，正确答案：<span style="color:red;"><%# Eval("ANSWER") %></span></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="PagerAreaNew2 left">
        <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
            PageSize="2" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
            OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
            HorizontalAlign="Center" ShowPageSizeBox="False" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
        </AspNetPager:AspNetPager>
    </div>
    <div class="Manage_MainList_down left">
        <div class="Fillet_ld_m left"></div>
        <div class="MainListNew_down_c left"></div>
        <div class="Fillet_rd_m left"></div>
    </div>
</div>
    </form>
</body>
</html>

