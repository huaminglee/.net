<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTioblist.ascx.cs" Inherits="Archive_UserControls_ucTioblist" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>

<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">三重一大</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">公文标题</label>
                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
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
                                  
                                    <th>添加时间</th>
                                  
                                    
                                    <th>发送人</th>
                                  
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
                                            <td>
                                                <asp:Label ID="lbarchtypename" runat="server" Text='<%# Eval("ARCHIVE_NO") %>'></asp:Label>
                                                <asp:Label ID="lbarchivetype" Visible="false"  runat="server" Text='<%# Eval("ARCHIVE_TYPE") %>'></asp:Label>
                                                <asp:Label ID="lbarchtypename2" Visible="false"  runat="server" Text='<%# Eval("ARCHIVE_TYPE_NAME") %>'></asp:Label>
                                                
                                            </td>
                                            <td title="<%# Eval("ARCHIVE_TITLE")%>"><%# S_App.Substr(Eval("ARCHIVE_TITLE").ToString(), 10) %></td>
                                            <td><%# AidHelp.ShortTime(Eval("CREATE_TIME")) %></td>
                                             
                                           
                                            <td> <asp:Label ID="lbcreator" runat="server" Text='<%# Eval("CREATOR") %>'></asp:Label></td>
                                            <td>
                                                <asp:HiddenField runat="server" ID="hidArchiveState" Value='<%# Eval("CURRENT_STATE") %>' />
                                                <asp:Label runat="server" ID="sHandle">
                                               </asp:Label>
                                                <a onclick='selWork(<%# Eval("ARCHIVE_ID") %>)'>查看</a>
                                                <asp:LinkButton ID="lbedit" CommandArgument='<%# Eval("ARCHIVE_ID") %>' Visible="false" CommandName="edit" runat="server"> 编辑</asp:LinkButton>
                                                
                                                <%--<asp:LinkButton ID="lbtnCollect" runat="server" CommandName="Collect" CommandArgument='<%# Eval("ARCHIVE_ID") %>'>收藏</asp:LinkButton>--%>
                                                <asp:LinkButton ID="lbdel"  CommandName="del" runat="server" OnClientClick="javascript:return confirm('确认要删除此文件吗?')" CommandArgument='<%# Eval("ARCHIVE_ID") %>' Visible="false">删除</asp:LinkButton>
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
            iframe: { src: '/Archive/NewTiob.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    };
    //办理公文
    function doWork(arId) {
        $.layer({
            type: 2,
            title: '办理公文',
            iframe: { src: '/Archive/NewTiob.aspx?arId=' + arId },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    //查看公文
    function selWork(arId) {
        $.layer({
            type: 2,
            title: '查看公文',
            iframe: { src: '/Archive/selTiobnoedit.aspx?arId=' + arId },
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