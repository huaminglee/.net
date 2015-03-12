<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GeneralArchive.ascx.cs" Inherits="Archive_UserControls_GeneralArchive" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>

<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">普通办件</small></legend>
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
                            <asp:ListItem>(全部)</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">待处理工作</asp:ListItem>
                            <asp:ListItem Value="1">已处理工作</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="NewArchive()" value="添&ensp;加" />
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
                                    <th>紧急程度</th>
                                    <th>送达时间</th>
                                    <th>办理时限</th>
                                    <th>附件</th>
                                    <th>发送人</th>
                                    <th>当前步骤</th>
                                    <th>办理状态</th>
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
                                            <td><%# Enum.Parse(typeof(EArchiveUrgency), Eval("PRI_LEVEL").ToString()) %></td>
                                            <td><%# AidHelp.ShortTime(Eval("START_TIME")) %></td>
                                            <td><%# AidHelp.ShortTime(Eval("LIMIT_TIME")) %></td>
                                            <td>
                                                <asp:Image runat="server" ID="imgStatus" Height="16" ImageUrl='<%# Eval("ATTACHMENT_COUNT").ToString()=="0"?"~/images/none.png":"~/images/mail-attachment.png" %>' />
                                            </td>
                                            <td><%# Eval("FULL_NAME") %></td>
                                            <td><%# Eval("STEP_NAME") %></td>
                                            <td><%# Eval("TASK_STATE").ToString() == "1" ? "已完成" : "待办中" %></td>
                                            <td>
                                                <asp:HiddenField runat="server" ID="hidArchiveState" Value='<%# Eval("CURRENT_STATE") %>' />
                                                <asp:HiddenField runat="server" ID="hidTaskState" Value='<%# Eval("TASK_STATE") %>' />
                                                <asp:Label runat="server" ID="sHandle">
                                <a href="javascript:void(0);" onclick='doWork(<%# Eval("ARCHIVE_TASK_ID") %>,<%# Eval("ARCHIVE_ID") %>)'>办理</a> |</asp:Label>
                                                <a href="javascript:void(0);" onclick='selWork(<%# Eval("ARCHIVE_TASK_ID") %>,<%# Eval("ARCHIVE_ID") %>)'>查看</a>|
                            <asp:LinkButton ID="lbtnCollect" runat="server" CommandName="Collect" CommandArgument='<%# Eval("ARCHIVE_ID") %>'>收藏</asp:LinkButton>
                                            <asp:LinkButton ID="lbdel" OnClientClick="javascript:return confirm('确认要删除此文件吗?')" CommandName="del" runat="server" CommandArgument='<%# Eval("ARCHIVE_ID") %>' Visible="false">删除</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="11">暂无数据</td>
                                        </tr>
                                    </EmptyDataTemplate>
                                </Zore:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <hr />
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
<script>
    //新增公文
    function NewArchive() {
        $.layer({
            type: 2,
            title: '新建公文',
            iframe: { src: '/Archive/NewWork.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    //办理公文
    function doWork(tID, arId) {
        $.layer({
            type: 2,
            title: '办理公文',
            iframe: { src: '/Archive/NewWork.aspx?tId=' + tID + '&arId=' + arId },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    //查看公文
    function selWork(tID, arId) {
        $.layer({
            type: 2,
            title: '查看公文',
            iframe: { src: '/Archive/selArchive.aspx?tId=' + tID + '&arId=' + arId },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
    function Close() {
        doRefresh();
        layer.closeAll();
    }
</script>
