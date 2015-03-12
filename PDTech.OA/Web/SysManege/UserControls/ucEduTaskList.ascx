<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucEduTaskList.ascx.cs" Inherits="SysManege_UserControls_ucEduTaskList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">教育任务</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtTitle" class="input-group-addon">任务标题</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="ddlType" class="input-group-addon">任务类型</label>
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px" data-options="panelHeight:'auto'"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="addEducation()" value="添&ensp;加" />
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
                                    <th>任务标题</th>
                                    <th>任务类型</th>
                                    <th>创建人</th>
                                    <th>创建时间</th>
                                    <th>来文单位</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpt_EducationList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("TITLE") %></td>
                                            <td><%# Eval("FILETYPE") %></td>
                                            <td><%# GetUserName((decimal)Eval("CREATOR")) %></td>
                                            <td><%# Eval("CREATETIME")%></td>
                                            <td><%# Eval("COMPANY") %></td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='showDetail(<%# Eval("EDUCATION_ID") %>)'>详细</a> |
                                                <a href='javascript:void(0);' onclick='showReadState(<%# Eval("EDUCATION_ID") %>)'>接收状态</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
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
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }

    function doClose() {
        doRefresh();
        layer.closeAll();
    }

    function addEducation() {
        $.layer({
            type: 2,
            title: '新建教育任务',
            iframe: { src: '/SysManege/AddEduTask.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }

    function showDetail(eduid) {
        $.layer({
            type: 2,
            title: '查看教育任务',
            iframe: { src: '/IncorruptEdu/ViewEduTask.aspx?edu_id=' + eduid + "&flag=1" },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }

    ///查看接收状态
    function showReadState(eduid) {
        $.layer({
            type: 2,
            title: '查看接收状态',
            iframe: { src: '/SysManege/ShowEduReadState.aspx?edu_id=' + eduid },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
</script>
