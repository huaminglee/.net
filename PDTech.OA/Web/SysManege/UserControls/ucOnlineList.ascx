<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucOnlineList.ascx.cs" Inherits="SysManege_UserControls_ucOnlineList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">在线用户</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-1">
                    <asp:Button ID="btnRefresh" runat="server" Text="刷&ensp;新" CssClass="btn btn-primary" OnClick="btnRefresh_Click" />
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
                                    <th>登录名</th>
                                    <th>姓名</th>
                                    <th>部门</th>
                                    <th>最后登录时间</th>
                                    <th>最后登录IP</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_UserList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("LOGIN_NAME") %> </td>
                                            <td><%# Eval("FULL_NAME") %></td>
                                            <td><%# Eval("DEPARTMENT_NAME") %></td>
                                            <td><%# Eval("LAST_DATE") %></td>
                                            <td><%# Eval("LAST_IP") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="6">暂无数据</td>
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
