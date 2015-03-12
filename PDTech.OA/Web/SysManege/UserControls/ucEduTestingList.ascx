<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucEduTestingList.ascx.cs" Inherits="SysManege_UserControls_ucEduTestingList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">在线考试统计</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtTitle" class="input-group-addon">试卷名称</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="addTesting()" value="添加试卷" />
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
                                    <th>试卷名称</th>
                                    <th>试题数</th>
                                    <th>总分</th>
                                    <th>创建人</th>
                                    <th>创建时间</th>
                                    <th>统计结果</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpt_TestingList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("TESTNAME") %></td>
                                            <td><%# Eval("TESTCOUNT") %></td>
                                            <td><%# Eval("SCORE") %></td>
                                            <td><%# GetUserName((decimal)Eval("CREATOR")) %></td>
                                            <td><%# Eval("CREATETIME")%></td>
                                            <td><a href='javascript:void(0);' onclick='showStatistics("<%# Eval("EDU_T_GUID") %>")'>查看</a></td>
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

    function addTesting() {
        $.layer({
            type: 2,
            title: '新建试卷',
            iframe: { src: '/SysManege/EditTesting.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }

    function showStatistics(tid) {
        $.layer({
            type: 2,
            title: '查看统计',
            iframe: { src: '/SysManege/TestStatistics1.aspx?t_id=' + tid },
            maxmin: true,
            area: ['985px', '555px'],
            border: [1, 0.2, '#000', true],
            offset: ['10px', '']
        });
    }
</script>
