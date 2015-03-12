<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDepartment.ascx.cs" Inherits="UserControls_ucDepartment" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">部门</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtDeptName" class="input-group-addon">部门名称</label>
                        <asp:TextBox ID="txtDeptName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="DeptOpnShow()" value="添&ensp;加" />
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
                                    <th>部门名称</th>
                                    <th>部门说明</th>
                                    <th>管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_DeptList" runat="server" OnItemCommand="rpt_DeptList_ItemCommand">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("DEPARTMENT_NAME") %> </td>
                                            <td><%# Eval("REMARK") %></td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='ShowDeptInfo(<%# Eval("DEPARTMENT_ID") %>)'>查看 </a>| 
                                                <a href='javascript:void(0);' onclick='ModifyDeptInfo(<%# Eval("DEPARTMENT_ID") %>)'>编辑</a> |
                                                <a href='javascript:void(0);' onclick="SetPersonShow(<%# Eval("DEPARTMENT_ID") %>);">指定人员</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="4">暂无数据</td>
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
    //新建部门
    function DeptOpnShow() {
        $.layer({
            type: 2,
            title: '新建部门',
            iframe: { src: '/SysManege/NewDept.aspx' },
            maxmin: true,
            area: ['395px', '360px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //查看部门
    function ShowDeptInfo(id) {
        $.layer({
            type: 2,
            title: '查看部门',
            iframe: { src: '/SysManege/DeptShowInfo.aspx?dId=' + id },
            maxmin: true,
            area: ['395px', '360px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //编辑部门
    function ModifyDeptInfo(id) {
        $.layer({
            type: 2,
            title: '编辑部门',
            iframe: { src: '/SysManege/NewDept.aspx?dId=' + id },
            maxmin: true,
            area: ['395px', '360px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //指定部门默认接收人员
    function SetPersonShow(id) {
        $.layer({
            type: 2,
            title: '编辑部门信息',
            iframe: { src: '/SysManege/Dept_DefaultPerson.aspx?dId=' + id },
            maxmin: true,
            area: ['388px', '405px'],
            border: [1, 0.2, '#000', true],
            offset: ['60px', '']
        });
    }
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
</script>
