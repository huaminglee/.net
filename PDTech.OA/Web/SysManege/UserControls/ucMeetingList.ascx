<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMeetingList.ascx.cs" Inherits="SysManege_UserControls_ucMeetingList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">会议通知</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">会议名称</label>
                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
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
                                    <th>会议名称</th>
                                    <th>会议地点</th>
                                    <th>开始时间</th>
                                    <th>结束时间</th>
                                    <th>发起人</th>
                                    <th>承办部门</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_MeetingList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td title="<%# Eval("TITLE")%>"><%# S_App.Substr(Eval("TITLE").ToString(), 30) %></td>
                                            <td><%# Eval("LOCATION") %></td>
                                            <td><%# Eval("START_TIME") %></td>
                                            <td><%# Eval("END_TIME")%></td>
                                            <td><%# GetUserName(decimal.Parse(Eval("SENDER").ToString())) %></td>
                                            <td><%# Eval("DEPT") %></td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='viewMeeting(<%# Eval("MEETING_ID") %>)'>详细</a> |
                                                <a href='javascript:void(0);' onclick='showReadState(<%# Eval("MEETING_ID") %>)'>接收状态</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="8">暂无数据</td>
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
    function viewMeeting(mid) {
        $.layer({
            type: 2,
            title: '查看会议',
            iframe: { src: '/Meeting/ViewMeeting.aspx?mid=' + mid },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }

    ///查看会议通知接收状态
    function showReadState(mid) {
        $.layer({
            type: 2,
            title: '查看会议通知接收状态',
            iframe: { src: '/SysManege/ShowMeetRead.aspx?mid=' + mid },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
</script>
