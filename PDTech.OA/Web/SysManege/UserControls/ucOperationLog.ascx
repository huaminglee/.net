<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucOperationLog.ascx.cs" Inherits="SysManege_UserControls_ucOperationLog" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<%@ Register Assembly="myControl" Namespace="myControl" TagPrefix="Zore" %>
<script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">操作日志</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-2">
                    <div class="input-group">
                        <label for="txt_startTime" class="input-group-addon">开始</label>
                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="input-group">
                        <label for="txt_endTime" class="input-group-addon">结束</label>
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">操作内容</label>
                        <asp:TextBox ID="txtContent" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtmName" class="input-group-addon">操作人</label>
                        <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control"></asp:TextBox>

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
                                    <th>序号</th>
                                    <th>操作人</th>
                                    <th>操作类型</th>
                                    <th>操作内容</th>
                                    <th>IP</th>
                                    <th>操作时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <Zore:Repeater ID="rpt_OperationLogList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# GetUserName((decimal)Eval("OPERATOR_USER")) %></td>
                                            <td><%# Eval("OPERATION_TYPE") %></td>
                                            <td><%# CutLength(Eval("OPERATION_DESC").ToString()) %></td>
                                            <td><%# Eval("HOST_IP")%></td>
                                            <td><%# Eval("OPERATION_TIME") %></td>
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
