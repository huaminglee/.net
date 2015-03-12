<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usRightInfoList.ascx.cs" Inherits="SysManege_UserControls_usRightInfoList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">权限</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtRiName" class="input-group-addon">权限名称</label>
                        <asp:TextBox ID="txtRiName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="NewPurviewInfoShow()" value="添&ensp;加" />
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
                                    <th>权限编码</th>
                                    <th>权限名称</th>
                                    <th>上级权限名称</th>
                                    <th>权限描述</th>
                                    <th>管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_PurviewList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("RIGHT_CODE") %> </td>
                                            <td><%# Eval("RIGHT_NAME") %></td>
                                            <td><%# Eval("PARENT_NAME") %></td>
                                            <td><%# Eval("RIGHT_DESC") %></td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='PurviewInfoShow(<%# Eval("RIGHT_ID") %>)'>查看 </a>| 
                                                <a href='javascript:void(0);' onclick='ModInfoShow(<%# Eval("RIGHT_ID") %>)'>编辑</a>
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
    //新建权限
    function NewPurviewInfoShow() {
        $.layer({
            type: 2,
            title: '新建权限',
            iframe: { src: '/SysManege/NewPurview.aspx' },
            maxmin: true,
            area: ['539px', '450px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //查看权限
    function PurviewInfoShow(rid) {
        $.layer({
            type: 2,
            title: '查看权限',
            iframe: { src: '/SysManege/PurviewInfo.aspx?rId=' + rid },
            maxmin: true,
            area: ['388px', '278px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //编辑权限
    function ModInfoShow(rid) {
        $.layer({
            type: 2,
            title: '编辑权限',
            iframe: { src: '/SysManege/NewPurview.aspx?rId=' + rid },
            maxmin: true,
            area: ['539px', '450px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
</script>
