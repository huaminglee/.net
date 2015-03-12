<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMeet_RoomList.ascx.cs" Inherits="SysManege_UserControls_ucMeet_RoomList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">会议室</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">会议室名称</label>
                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="NewmRoom()" value="添&ensp;加" />
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
                                    <th style="width:60px;">序号</th>
                                    <th style="width:200px;">会议室名称</th>
                                    <th >会议室描述</th>
                                    <th style="width:150px;">管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_mRoomDataList" runat="server" OnItemCommand="rpt_mRoomDataList_ItemCommand">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("MEETING_ROOM_NAME") %> </td>
                                             <td title="<%# Eval("ROOM_DESC")%>"><%# S_App.Substr(Eval("ROOM_DESC").ToString(), 30) %></td>
                                             
                                            <td>
                                                <a href='javascript:void(0);' onclick='ModRoom(<%# Eval("MEETING_ROOM_ID") %>)'>编辑 </a>|
                                                <asp:LinkButton ID="lbtnDel" OnClientClick="javascript:return confirm('确认要删除此会议室吗?')" runat="server" CommandName="nDel" CommandArgument='<%# Eval("MEETING_ROOM_ID") %>'>删除</asp:LinkButton>
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
    //新建会议室
    function NewmRoom() {
        $.layer({
            type: 2,
            title: '新建会议室',
            iframe: { src: '/SysManege/NewMeeting_room.aspx?' },
            maxmin: true,
            area: ['395px', '222px'],
            border: [1, 0.2, '#000', true],
            offset: ['50px', '']
        });
    };
    //编辑会议室
    function ModRoom(id) {
        $.layer({
            type: 2,
            title: '编辑会议室',
            iframe: { src: '/SysManege/NewMeeting_room.aspx?mId=' + id },
            maxmin: true,
            area: ['395px', '222px'],
            border: [1, 0.2, '#000', true],
            offset: ['50px', '']
        });
    };
    //模拟查询点击
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }
</script>
