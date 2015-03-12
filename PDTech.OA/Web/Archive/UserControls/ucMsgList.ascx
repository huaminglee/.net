<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMsgList.ascx.cs" Inherits="Archive_UserControls_ucMsgList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">收信箱</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">公告标题</label>
                        <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="dplStatus" class="input-group-addon">阅读状态</label>
                        <asp:DropDownList ID="dplStatus" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px" data-options="panelHeight:'auto'">
                            <asp:ListItem>(全部)</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">待阅读</asp:ListItem>
                            <asp:ListItem Value="1">已阅读</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnRead" runat="server" CssClass="btn btn-primary" Text="全部标记已读" OnClick="btnRead_Click" />
                </div>
            </div>
            <br />
            <!-- 数据展示 -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive">
                        <table class="table table-hover table-condensed cursor" id="msgList">
                            <thead>
                                <tr>
                                    <th>
                                        <input name="CheckAll" id="CheckAll" type="checkbox" value="" onclick="SelectAllCheckboxes(this, 'msgList', 'CheckAll');" />
                                    </th>
                                    <th>发送人</th>
                                    <th>
                                        <div class="notice_emal"></div>
                                    </th>
                                    <th>公告标题</th>
                                    <th>发送时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater runat="server" ID="rptMsgList">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input name="CheckBox" id="CheckBox" runat="server" type="checkbox" value='<%# Eval("MESSAGE_ID") %>' onclick="chkChecked(this, 'msgList', 'CheckAll');" />
                                            </td>
                                            <td><%# Eval("SENDER_FULLNAME") %></td>
                                            <td>
                                                <a href="javascript:void(0);" onclick='showMsgInfo(<%# Eval("MESSAGE_ID") %>);'>
                                                    <div class="<%# Eval("READ_STATUS").ToString() == "0" ? "notice_emal notice_emal_unread" : "notice_emal" %>"></div>
                                                </a>
                                            </td>
                                            <td><a onclick='showMsgInfo(<%# Eval("MESSAGE_ID") %>);'><%# S_App.Substr(Eval("MESSAGE_TITLE").ToString(), 50) %></a></td>
                                            <td><%# Eval("MESSAGE_SEND_TIME") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td colspan="5">暂无数据</td>
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
    //查看公告
    function showMsgInfo(id) {
        $.layer({
            type: 2,
            title: '查看公告',
            iframe: { src: '/Archive/msgInfo.aspx?mId=' + id + '' },
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
