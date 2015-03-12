<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllArchive_Task.aspx.cs" Inherits="Archive_AllArchive_Task" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>待处理公文</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
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
    <script src="/Script/swfupload/swfupload.js"></script>
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
</head>
<body>
    <form id="nForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel">
            <ContentTemplate>
                <section class="container">
                    <div class="container-fluid">
                        <fieldset>
                            <legend><small class="text-primary">办理公文</small></legend>
                            <!-- 查询条件 -->
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txtmName" class="input-group-addon">公文标题</label>
                                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="dplStatus" class="input-group-addon">公文办理状态</label>
                                        <asp:DropDownList ID="dplStatus" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px" data-options="panelHeight:'auto'">
                                            <asp:ListItem>---全部---</asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True">待处理工作</asp:ListItem>
                                            <asp:ListItem Value="1">已处理工作</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txtmName" class="input-group-addon">公文类型</label>
                                        <asp:DropDownList ID="dplTypeList" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                            <br />
                            <!-- 数据展示 -->
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <table class="table table-hover table-condensed table-bordered cursor">
                                            <thead>
                                                <tr>
                                                    <th>序号</th>
                                                    <th>公文类型</th>
                                                    <th>公文标题</th>
                                                    <th>送达时间</th>
                                                    <th>办理时限</th>
                                                    <th>附件</th>
                                                    <th>发送人</th>
                                                    <th>当前步骤</th>
                                                    <th>办理状态</th>
                                                    <th>办理类型</th>
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
                                                            <td title="<%# Eval("ARCHIVE_TITLE")%>"><%# S_App.Substr(Eval("ARCHIVE_TITLE").ToString(), 10) %></td>
                                                            <td><%# AidHelp.ShortTime(Eval("START_TIME")) %></td>
                                                            <td><%# AidHelp.ShortTime(Eval("LIMIT_TIME")) %></td>
                                                            <td>
                                                                <asp:Image runat="server" ID="imgStatus" Height="16" ImageUrl='<%# Eval("ATTACHMENT_COUNT").ToString()=="0"?"~/images/none.png":"~/images/mail-attachment.png" %>' />
                                                            </td>
                                                            <td><%# Eval("FULL_NAME") %></td>
                                                            <td><%# Eval("STEP_NAME") %></td>
                                                            <td><%# Eval("TASK_STATE").ToString() == "1" ? "已完成" : "待办中" %></td>
                                                            <td><%# Eval("TASK_TYPE").ToString() == "1" ? "抄 送" : "办 理" %></td>
                                                            <td>
                                                                <asp:HiddenField runat="server" ID="hidArchiveState" Value='<%# Eval("CURRENT_STATE") %>' />
                                                                <asp:HiddenField runat="server" ID="hidTaskState" Value='<%# Eval("TASK_STATE") %>' />
                                                                <asp:Label runat="server" ID="sHandle">
                                                                <a onclick='EditDetail(<%# Eval("ARCHIVE_ID") %>,<%# Eval("ARCHIVE_TASK_ID") %>,<%# Eval("ARCHIVE_TYPE") %>)'>办理</a> |</asp:Label>
                                                                <a onclick='showDetail(<%# Eval("ARCHIVE_ID") %>,<%# Eval("ARCHIVE_TASK_ID") %>,<%# Eval("ARCHIVE_TYPE") %>)'>查看</a>
                                                           <asp:LinkButton ID="lbdel" CommandName="del" OnClientClick="javascript:return confirm('确认要删除此文件吗?')" runat="server" CommandArgument='<%# Eval("ARCHIVE_ID") %>' Visible="false">删除</asp:LinkButton>
                                                                 </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <tr>
                                                            <td colspan="9">暂无数据</td>
                                                        </tr>
                                                    </EmptyDataTemplate>
                                                </Zore:Repeater>
                                            </tbody>
                                        </table>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    
    <script>
        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function EditDetail(archive_id, archive_task_id, archive_type) {
            var src;
            /***待办事项***/
            if (archive_task_id != undefined) {
                switch (archive_type) {
                    case 10:
                        src = "/Archive/newPieces.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 11:
                        src = "/Archive/NewWork.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 12:
                        src = "/Archive/NewUnitDoc.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 20: case 21: case 22: case 23:
                        src = "/Archive/newSupInfo.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 24:
                        src = "/Admin/newProposal.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 32:
                        src = "/Admin/newPersonnel.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 33:
                        src = "/Admin/sel_Finance.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 40: case 41: case 42: case 43: case 44:
                        src = "/Approve/newApprove.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 51:
                        src = "/Risk/newRisk.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                }
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '620px'],
                offset: ['20px', ''],
                iframe: { src: src }
            });
        }

        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function showDetail(archive_id, archive_task_id, archive_type) {
            var src;
            /***待办事项***/
            if (archive_task_id != undefined) {
                switch (archive_type) {
                    case 10:
                        src = "/Archive/selPieces.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 11:
                        src = "/Archive/selArchive.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 12:
                        src = "/Archive/selUnitDoc.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 20: case 21: case 22: case 23:
                        src = "/Archive/selSupInfo.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 24:
                        src = "/Admin/selProposal.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 32:
                        src = "/Admin/selPersonnal.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 33:
                        src = "/Admin/selFinance.aspx?arid=" + archive_id;
                        break;
                    case 40: case 41: case 42: case 43: case 44:
                        src = "/Approve/selApprove.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 51:
                        src = "/Risk/newRisk.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                }
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '620px'],
                offset: ['20px', ''],
                iframe: { src: src }
            });
        }

        /***点击公文任务办理后返回刷新页面***/
        function doRefresh() {
            document.getElementById('btnSearch').click();
        }
    </script>
</body>
</html>
