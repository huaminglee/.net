<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProjectList.ascx.cs" Inherits="Admin_UserControls_ucProjectList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">水务工程项目</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">项目名称</label>
                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="dplStatus" class="input-group-addon">办理状态</label>
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
                <div class="col-sm-2">
                    <input type="button" class="btn btn-primary" onclick="newProject();" value="添&ensp;加(规计处)" />
                    
                    
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="newProject2();" value="添&ensp;加(财务处)" />
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
                                    <th>备案处室</th>
                                    <th>项目名称</th>
                                    <th>备案日期</th>
                                    <th>备案人员</th>
                                    <th>办理状态</th>
                                    <th>管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_ProStepList" runat="server" OnItemDataBound="rpt_ProStepList_ItemDataBound" OnItemCommand="rpt_ProStepList_ItemCommand">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("PROJECT_TYPE").ToString() == "1" ? "规计处" : "财务处" %></td>
                                            <td><%# Eval("PROJECT_NAME") %></td>
                                            <td><%# AidHelp.ShortTime(Eval("CREATE_TIME")) %></td>
                                            <td><%# Eval("CFULL_NAME") %></td>
                                            <td><%# Eval("PROJECT_STATUS").ToString() == "1" ? "已完成" : "办理中" %></td>
                                            <td>
                                                 <asp:HiddenField runat="server" ID="hidArchiveState" Value='<%# Eval("CURRENT_STATE") %>' />
                                                <asp:HiddenField runat="server" ID="hidTaskState" Value='<%# Eval("TASK_STATE") %>' />
                                                <asp:HiddenField ID="hidownerid" Value='<%# Eval("OWNER_ID") %>' runat="server" />
                                                <asp:Label runat="server" ID="sHandle">
                            <a href="javascript:void(0);" onclick='doWork(<%# Eval("ARCHIVE_TASK_ID") %>,<%# Eval("ARCHIVE_ID") %>)'>办理</a> |</asp:Label>
                                                <a href="javascript:void(0);" onclick='selPro(<%# Eval("PROJECT_ID") %>)'>查看</a>
                                                <asp:LinkButton ID="lbdel" OnClientClick="javascript:return confirm('确认要删除此文件吗?')" CommandName="del" runat="server" CommandArgument='<%# Eval("ARCHIVE_ID") %>' Visible="false">删除</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="7">暂无数据</td>
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
<script>
    //新建项目
    function newProject() {
        $.layer({
            type: 2,
            title: '新建项目',
            iframe: { src: '/Admin/newFinance.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    function newProject2() {
        $.layer({
            type: 2,
            title: '新建项目',
            iframe: { src: '/Admin/newFinance.aspx?stype=2' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    //查看项目
    function selPro(pId) {
        $.layer({
            type: 2,
            title: '查看项目',
            iframe: { src: '/Admin/selFinance.aspx?pId=' + pId + '' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    function doWork(tID, arId) {
        $.layer({
            type: 2,
            title: '办理公文',
            iframe: { src: '/Admin/sel_Finance.aspx?tId=' + tID + '&arId=' + arId + '' },
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
