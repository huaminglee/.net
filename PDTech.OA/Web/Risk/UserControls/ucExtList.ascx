<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucExtList.ascx.cs" Inherits="Risk_UserControls_ucExtList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<asp:ScriptManager runat="server" ID="ScriptManager">
</asp:ScriptManager>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary" id="lblTab_Name" runat="server"></small></legend>
            <!-- 查询条件（1） -->
            <div class="row">
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
            <br />
            <!-- 查询条件（2） -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtsTime" class="input-group-addon">开始</label>
                        <asp:TextBox runat="server" ID="txtsTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="150px" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txteTime" class="input-group-addon">结束</label>
                        <asp:TextBox runat="server" ID="txteTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="150px" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtArchiveNo" class="input-group-addon">风险编号</label>
                        <asp:TextBox ID="txtArchiveNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel">
                        <ContentTemplate>
                            <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClientClick="loadhighs();" OnClick="btnSearch_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />
            <!-- 数据展示 -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel0">
                            <ContentTemplate>
                                <table class="table table-hover table-condensed table-bordered cursor">
                                    <thead>
                                        <tr>
                                            <th style="width: 5%;">序号</th>
                                            <th style="width: 7%;">风险类型</th>
                                            <th style="width: 15%;">风险标题</th>
                                            <th style="width: 6%;">风险等级</th>
                                            <th style="width: 8%;">创建时间</th>
                                            <th style="width: 8%;">办理时限</th>
                                            <th style="width: 7%;">风险编号</th>
                                            <th style="width: 7%;">处室</th>
                                            <th style="width: 5%;">附件</th>
                                            <th style="width: 5%;">办理人</th>
                                            <th style="width: 7%;">办理状态</th>
                                            <th style="width: 5%;">管理</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <Zore:Repeater ID="rpt_taskList" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                                    <td><%# Eval("RISKTYPE") %></td>
                                                    <td title="<%# Eval("ARCHIVE_TITLE")%>"><%# S_App.Substr(Eval("ARCHIVE_TITLE").ToString(), 10) %></td>
                                                    <td><%# Enum.Parse(typeof(EArchiveRiskLevel), Eval("PRI_LEVEL").ToString()) %></td>
                                                    <td><%# AidHelp.ShortTime(Eval("CREATE_TIME"))%></td>
                                                    <td><%# AidHelp.ShortTime(Eval("LIMIT_TIME")) %></td>
                                                    <td><%# Eval("ARCHIVE_NO") %></td>
                                                    <td><%# Eval("DEPT_NAME") %></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="imgStatus" Height="16" ImageUrl='<%# Eval("ATTACHMENT_COUNT").ToString() == "0" ? "~/images/none.png" : "~/images/mail-attachment.png" %>' />
                                                    </td>
                                                    <td><%# Eval("HANDLE_USER") %></td>
                                                    <td><%# Eval("CURRENT_STATE").ToString() == "2" ? "已完成" : "办理中" %></td>
                                                    <td>
                                                        <a href="javascript:void(0);" onclick='selWork(<%# Eval("ARCHIVE_ID") %>)'>查看</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <tr>
                                                    <td colspan="12">暂无数据</td>
                                                </tr>
                                            </EmptyDataTemplate>
                                        </Zore:Repeater>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- 分页 -->
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel_t">
                        <ContentTemplate>
                            <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                                runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                                PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Always"
                                OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                                HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                            </AspNetPager:AspNetPager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </fieldset>
    </div>
</section>
<asp:HiddenField runat="server" ID="hidDeptName" />
<asp:HiddenField runat="server" ID="hidDeptId" />
<asp:HiddenField runat="server" ID="hidUserName" />
<asp:HiddenField runat="server" ID="hidUserID" />
<script type="text/javascript">
    //查看公文
    function selWork(arId) {
        $.layer({
            type: 2,
            title: '公文查看',
            iframe: { src: '/Risk/sel_risk.aspx?arId=' + arId + '' },
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
    $(function () {
        $('#deptList').combobox({
            url: '/Risk/UserControls/Ajax.aspx?queryState=dept',
            valueField: '_department_id',
            textField: '_department_name',
            panelHeight: 'auto',
            onSelect: function () {
                $("#dplUserList").combobox('clear');
                $("#hidDeptId").val($('#deptList').combobox('getValue'));
                $("#hidDeptName").val($('#deptList').combobox('getText'));
                if ($("#hidDeptId").val() != 0) {
                    $('#dplUserList').combobox({
                        url: '/Risk/UserControls/Ajax.aspx?queryState=user&queryId=' + $("#hidDeptId").val(),
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
                $("#hidUserId").val($('#dplUserList').combobox('getValue'));
                $("#hidUserName").val($('#dplUserList').combobox('getText'));
            }
        });
    });
</script>
