<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRoll_NewsList.ascx.cs" Inherits="SysManege_UserControls_ucRoll_NewsList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">新闻</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtTitle" class="input-group-addon">新闻标题</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="doAdd()" value="添&ensp;加" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnRoll" runat="server" Text="设为滚动" CssClass="btn btn-primary" OnClientClick="return doDel('确定设为滚动吗？')" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnNotRoll" runat="server" Text="取消滚动" CssClass="btn btn-primary" OnClientClick="return doDel('确定取消滚动吗？')" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnDel" runat="server" Text="删&ensp;除" CssClass="btn btn-danger" OnClientClick="return doDel('确定删除选择的新闻吗？')" />
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
                                    <th>
                                        <input name="chkAll" type="checkbox" onclick="isCheckAll(this)" />
                                    </th>
                                    <th>新闻标题</th>
                                    <th>创建人</th>
                                    <th>创建时间</th>
                                    <th>是否滚动</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_NewsDataList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chbSelect" name="chbSelect" />
                                                <asp:Label ID="lbNewsID" runat="server" Text='<%# Eval("NEWS_ID")%>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%# Eval("NEWS_TITLE") %> </td>
                                            <td><%# GetUserName(decimal.Parse(Eval("CREATOR").ToString())) %> </td>
                                            <td><%# Eval("CREATE_TIME") %> </td>
                                            <td><%# Convert.ToInt32(Eval("IS_ROLLING")) == 1 ? "是" : "否" %> </td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='doEdit(<%# Eval("NEWS_ID") %>)'>编辑</a>
                                            </td>
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
<script>
    //全选
    function isCheckAll(checkAll) {
        var items = document.getElementsByTagName("input");
        for (i = 0; i < items.length; i++) {
            if (items[i].type == "checkbox") {
                items[i].checked = checkAll.checked;
            }
        }
    }
    //新建新闻
    function doAdd() {
        $.layer({
            type: 2,
            title: '新建新闻',
            iframe: { src: '/SysManege/EditRollNews.aspx?' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    //编辑新闻
    function doEdit(id) {
        $.layer({
            type: 2,
            title: '编辑新闻',
            iframe: { src: '/SysManege/EditRollNews.aspx?news_id=' + id },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
    function doClose() {
        doRefresh();
        layer.closeAll();
    }
    function doDel(msg) {
        var a = $("input[type='checkbox']:checked").length;
        if (a == 0) {
            alert("请至少选择一个！");
            return false;
        } else {
            if (confirm(msg)) {
                return true;
            } else {
                return false;
            }
        }
    }
</script>
