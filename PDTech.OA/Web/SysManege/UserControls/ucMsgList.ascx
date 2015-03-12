<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMsgList.ascx.cs" Inherits="SysManege_UserControls_ucMsgList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">公告消息</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">公告标题</label>
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
                                    <th style="width:5%;">序号</th>
                                    <th style="width:10%;">发送人</th>
                                    <th style="width:65%;">公告标题</th>
                                    <th style="width:10%;">发送时间</th>
                                    <th style="width:10%;">管理</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_MsgList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# Eval("SENDER_FULLNAME") %></td>
                                            <td><a onclick='showMsgInfo(<%# Eval("MESSAGE_ID") %>);'><%# S_App.Substr(Eval("MESSAGE_TITLE").ToString(), 25) %></a></td>
                                            <td><%# AidHelp.ShortTime(Eval("MESSAGE_SEND_TIME")) %></td>
                                            <td><a href="javascript:void(0);" onclick='ShowReadState("<%# Eval("MESSAGE_ID")%>");'>接收状态</a></td>
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
    ///查看公告信息接收状态
    function ShowReadState(mId) {
        $.layer({
            type: 2,
            title: '查看公告信息接收状态',
            iframe: { src: '/SysManege/ShowRead.aspx?Mid=' + mId + "" },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
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
    function doRefresh()
    { }
</script>
