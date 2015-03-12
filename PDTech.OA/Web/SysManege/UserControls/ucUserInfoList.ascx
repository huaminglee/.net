<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserInfoList.ascx.cs" Inherits="UserControls_ucUserInfoList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>

<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">用户</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtUserName" class="input-group-addon">用户名称</label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="dplStatus" class="input-group-addon">部门</label>
                        <asp:DropDownList ID="dplDempList" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="NewUserInfoShow()" value="添&ensp;加" />
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
                                    <th>登录账号</th>
                                    <th>姓名</th>
                                    <th>电话号码</th>
                                    <th>手机号码</th>
                                    <th>启用状态</th>
                                    <th>部门名称</th>
                                    <th style="width:110px">分管部门</th>
                                    <th>管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_UserList" runat="server" OnItemCommand="rpt_UserList_ItemCommand">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("LOGIN_NAME") %> </td>
                                            <td><%# Eval("FULL_NAME") %></td>
                                            <td><%# Eval("PHONE") %></td>
                                            <td><%# Eval("MOBILE") %></td>
                                            <td>
                                                <asp:Image runat="server" ID="imgStatus" ImageUrl='<%# Eval("IS_DISABLE").ToString() == "0" ? "~/images/ico_yes.gif" : "~/images/ico_no.gif" %>' />
                                            </td>
                                            <td><%# Eval("DEPARTMENT_NAME") %></td>
                                            <td><%# Eval("OwnerDeptNames") %></td>
                                            <td>
                                                <a href='javascript:void(0);' onclick='ShowUserInfo(<%# Eval("USER_ID") %>)'>查看 </a>| 
                                                <a href='javascript:void(0);' onclick='ModUserInfo(<%# Eval("USER_ID") %>)'>编辑</a> |
                                                <asp:LinkButton ID="lbtnDel" runat="server" CommandName="nRemove" CommandArgument='<%# Eval("USER_ID") %>'>禁用</asp:LinkButton>|
                                                <asp:LinkButton ID="lbtnOk" runat="server" CommandName="nEnable" CommandArgument='<%# Eval("USER_ID") %>'>启用</asp:LinkButton>|
                                                <a href="javascript:void(0);" onclick='SetPurview(<%# Eval("USER_ID") %>);'>权限编辑</a> |
                                                <a href="javascript:void(0);" onclick='SetDeptOwner(<%# Eval("USER_ID") %>);'>分管部门</a> |
                                                <asp:LinkButton ID="lbtnResetPwd" OnClientClick="javascript:return confirm('确定要重置此用户的密码吗?')" runat="server" CommandName="resetPwd" CommandArgument='<%# Eval("USER_ID") %>'>重置密码</asp:LinkButton>
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
    //新建用户
    function NewUserInfoShow() {
        $.layer({
            type: 2,
            title: '新建用户',
            iframe: { src: '/SysManege/NewUserInfo.aspx' },
            maxmin: true,
            area: ['395px', '480px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //查看用户
    function ShowUserInfo(id) {
        $.layer({
            type: 2,
            title: '查看用户',
            iframe: { src: '/SysManege/UserShowInfo.aspx?uId=' + id },
            maxmin: true,
            area: ['395px', '480px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //编辑用户
    function ModUserInfo(id) {
        $.layer({
            type: 2,
            title: '编辑用户',
            iframe: { src: '/SysManege/NewUserInfo.aspx?uId=' + id },
            maxmin: true,
            area: ['395px', '480px'],
            border: [1, 0.2, '#000', true],
            offset: ['100px', '']
        });
    };
    //编辑用户权限
    function SetPurview(uId) {
        $.layer({
            type: 2,
            title: '编辑用户权限',
            iframe: { src: '/SysManege/SetUser_Purview.aspx?uId=' + uId },
            maxmin: true,
            area: ['398px', '565px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    //设定分管部门
    function SetDeptOwner(uId) {
        $.layer({
            type: 2,
            title: '设定分管部门',
            iframe: { src: '/SysManege/SetUserDeptOwner.aspx?uId=' + uId },
            maxmin: true,
            area: ['398px', '565px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
</script>
