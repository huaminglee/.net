<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FortheProcess.aspx.cs" Inherits="Admin_FortheProcess" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看办理流程</title>
    <link rel="stylesheet" type="text/css" href="/CSS/Sys_list.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t=<%=t_rand %>" />

    <style type="text/css">
        .let2
        {
            letter-spacing: 2px;
        }

        .let6
        {
            letter-spacing: 6px;
        }

        .right
        {
            margin-right: 29px;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="Manage_Center_title left">
            办理流程列表
            <input type="button" id="btnReturn" class="btn_back con_oper_btn let6 right" value="返回" onclick="window.history.go(-1);" />
            <input type="button" runat="server" onclick="ShowPrint();" id="btnPrint" value="打印" class="btn_Print con_oper_btn_p let6 right" />
        </div>
        <div class="Manage_MainList left">
            <div class="Manage_MainList_top left">
                <div class="Fillet_lt_m left"></div>
                <div class="MainList_top_c left"></div>
                <div class="Fillet_rt_m left"></div>
            </div>
            <div class="MainList_box left">
                <table class="main_tabList" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <th style="width: 5%;">序号</th>
                        <th style="width: 10%;">步骤名称</th>
                        <th style="width: 10%;">当前办理人员</th>
                        <th style="width: 9%;">送达时间</th>
                        <th style="width: 9%;">办理时限</th>
                        <th style="width: 12%;">结束办理时间</th>
                        <th style="width: 20%;">办理说明</th>
                        <th style="width: 5%;">状态</th>
                        <th style="width: 20%;">管理</th>
                    </tr>
                    <Zore:Repeater ID="rpt_taskList" runat="server" OnItemCommand="rpt_taskList_ItemCommand" OnItemDataBound="rpt_taskList_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex+1+AspNetPager.PageSize*(AspNetPager.CurrentPageIndex-1) %> </td>
                                <td><%# Eval("STEP_NAME") %></td>
                                <td><%# Eval("FULL_NAME") %></td>
                                <td><%# AidHelp.ShortTime(Eval("START_TIME")) %></td>
                                <td><%# AidHelp.ShortTime(Eval("LIMIT_TIME")) %></td>
                                <td><%# AidHelp.ShortTime(Eval("END_TIME")) %></td>
                                <td><%# Eval("TASK_REMARK") %></td>
                                <td>
                                    <asp:HiddenField runat="server" ID="hidOt_Type" Value='<%# Eval("TASK_TYPE")%>' />
                                    <asp:HiddenField runat="server" ID="hidOt_State" Value='<%# Eval("TASK_STATE")%>' />
                                    <asp:Label runat="server" ID="stateStr"></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField runat="server" ID="hidArchiveId" Value='<%# Eval("ARCHIVE_ID")%>' />
                                    <asp:HiddenField runat="server" ID="hidArchiveType" Value='<%# Eval("ARCHIVE_TYPE")%>' />
                                    <asp:HiddenField runat="server" ID="hidArchive_Task_Id" Value='<%# Eval("ARCHIVE_TASK_ID")%>' />
                                    <asp:HiddenField runat="server" ID="hidRiskId" Value='<%# Eval("RISK_HANDLE_ARCHIVE_ID")%>' />
                                    <asp:LinkButton ID="lbntGnt" runat="server" CommandName="Gnt">生成风险处置单</asp:LinkButton>
                                    <asp:LinkButton ID="lbntSel" runat="server" CommandName="Sel">查看风险处置单</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="7">暂无数据</td>
                            </tr>
                        </EmptyDataTemplate>
                    </Zore:Repeater>
                </table>
            </div>
            <div id="name" style="height: 0px; width: 0px; POSITION: relative">
                <%if (allSealData.Length > 0)
                  {
                      string[] sealdata = allSealData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                      for (int i = 0; i < sealdata.Length; i++)
                      {
                          int x = 150 * i + (i + 1) * 5;
                          var p_data = protectList[i];
                %>
                <object id="sealobj" classid="CLSID:C1FB7513-9A44-4C64-B653-63C6965D7F4C" width="150" height="150" style="left: <%=x %>px; position: absolute; top: 200px;">
                    <param name="Authority" value="0" />
                    <param name="ProtectedData" value="<%=S_App.javaScriptFilter(p_data) %>" />
                    <param name="SignedDataStoreElement" value="<%= i %>">
                    <!--将印章数据保存到name为sealdata的input字段中以便提交到服务器-->
                    <param name="DrawMode" value="18" />
                    <!--使用透明和自适应的方式显示印章-->
                    <param name="DrawModeUnsign" value="0" />
                    <!--签章前显示的印章图案:0=空白-->
                </object>
                <input type="hidden" id="<%= i %>" name="<%= i %>" value="<%=sealdata[i]  %>">
                <%}
                  } %>
            </div>
            <div class="PagerArea left">
                <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                    runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Never"
                    OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                    HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                </AspNetPager:AspNetPager>
            </div>
            <div class="Manage_MainList_down left">
                <div class="Fillet_ld_m left"></div>
                <div class="MainList_down_c left"></div>
                <div class="Fillet_rd_m left"></div>
            </div>
        </div>
        <script>
            function editRisk(ptypeId, ptId, p_arId) {
                window.location.href = '/Risk/newRisk.aspx?ptype=' + ptypeId + '&p_arId=' + p_arId + '&ptId=' + ptId + '';
            }
            //打印公文办理信息
            function ShowPrint() {
                var arid =<%=Archive_id%>
                window.location.href = "Archive_Print.aspx?Archive_Id=" + arid;
            }
        </script>
    </form>
</body>
</html>
