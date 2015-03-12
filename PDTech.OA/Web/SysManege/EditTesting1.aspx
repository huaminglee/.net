<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTesting1.aspx.cs" Inherits="SysManege_EditTesting1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            border: none;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/CSS/Sys.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t=" <%=t_rand %> />
    <script type="text/javascript" src="../jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js?t=" <%=t_rand %>></script>
    <script type="text/javascript">
        function isCheckAll(checkAll) {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                if (items[i].type == "checkbox") {
                    items[i].checked = checkAll.checked;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Manage_Center_title" style="margin: 0 auto; width: 880px">
            廉政教育在线测试试卷
        </div>
        <div class="Manage_MainList" style="margin: 0 auto; width: 880px">
            <div class="Manage_MainList_top left" style="width: 880px">
                <div class="Fillet_lt_m left" style="width: 880px"></div>
                <div class="MainList_top_c left" style="width: 880px"></div>
                <div class="Fillet_rt_m left" style="width: 880px"></div>
            </div>
            <div class="MainList_Query left" style="width: 880px">
                <table>
                    <tr>
                        <td class="td_t">试卷名称：</td>
                        <td class="tdl">
                            <asp:TextBox ID="txtTestName" runat="server" CssClass="input inputb" Width="300px"></asp:TextBox>
                        </td>
                        <td class="td_t">
                            <asp:Button ID="btnSave" runat="server" Text="保存 " CssClass="searchBtn" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MainList_box left" style="width: 880px">
                <table class="main_tabList" cellpadding="0px" cellspacing="0px" style="width: 880px">
                    <tr>
                        <th style="width: 5%;">
                            <input name="chkAll" type="checkbox" onclick="isCheckAll(this)" />
                        </th>
                        <th style="width: 90%;">题目</th>
                        <th style="width: 5%; padding-left: 10px;">分值</th>
                    </tr>
                    <asp:Repeater ID="rpt_QuestionList" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="chbSelect" name="chbSelect" />
                                    <asp:Label ID="lbQUID" runat="server" Text='<%# Eval("EDU_Q_GUID")%>' Visible="false"></asp:Label>
                                </td>
                                <td><%# GetTitle(Eval("TITLE").ToString()) %></td>
                                <td><%# Eval("SCORE") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="PagerArea left" style="width: 880px">
                <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                    runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Always"
                    OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                    HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                </AspNetPager:AspNetPager>
            </div>
            <div class="Manage_MainList_down left" style="width: 880px">
                <div class="Fillet_ld_m left" style="width: 880px"></div>
                <div class="MainList_down_c left" style="width: 880px"></div>
                <div class="Fillet_rd_m left" style="width: 880px"></div>
            </div>
        </div>
    </form>
</body>
</html>
