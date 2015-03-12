<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingList.aspx.cs" Inherits="Meeting_MeetingList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>会议</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">
        <section class="container">
            <div class="container-fluid">
                <fieldset>
                    <legend><small class="text-primary">会议通知</small></legend>
                    <!-- 查询条件 -->
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtmName" class="input-group-addon">会议名称</label>
                                <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-sm-1">
                            <input type="button" class="btn btn-primary" onclick="addMeeting()" value="添&ensp;加" />
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
                                            <th style="width:40%;">会议名称</th>
                                            <th>发起人</th>
                                            <th>会议地点</th>
                                            <th>开始时间</th>
                                            <th>结束时间</th>
                                            <th>主持人</th>
                                            <th>承办部门</th>
                                            <th>详细</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpt_MeetingList" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %></td>
                                                    <td><a title="<%# Eval("TITLE") %>" href='#' style="color:#333;"><%# S_App.Substr(Eval("TITLE").ToString(),20) %></a></td>
                                                    <td><%# GetUserName(decimal.Parse(Eval("SENDER").ToString())) %></td>
                                                    <td><%# Eval("LOCATION") %></td>
                                                    <td><%# Eval("START_TIME") %></td>
                                                    <td><%# Eval("END_TIME") %></td>
                                                    <td><%# GetUserName(decimal.Parse(Eval("HOST_USER").ToString())) %></td>
                                                    <td><%# Eval("DEPT") %></td>
                                                    <td><a href='javascript:void(0);' onclick='viewMeeting(<%# Eval("MEETING_ID") %>)'>查看</a></td>
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
    </form>
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/swfupload/swfupload.js"></script>
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
    <script type="text/javascript">
        function addMeeting() {
            $.layer({
                type: 2,
                title: '新建会议',
                iframe: { src: '/Meeting/EditMeeting.aspx' },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }

        function viewMeeting(id) {
            $.layer({
                type: 2,
                title: '查看会议',
                iframe: { src: '/Meeting/ViewMeeting.aspx?mid=' + id },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }

        function doRefresh() {
            document.getElementById('<%=btnSearch.ClientID %>').click();
        }

    function doClose() {
        doRefresh();
        layer.closeAll();
    }
    </script>
</body>
</html>