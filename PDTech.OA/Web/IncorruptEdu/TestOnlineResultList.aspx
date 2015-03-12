<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestOnlineResultList.aspx.cs" Inherits="IncorruptEdu_TestOnlineResultList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>我的考试结果</title>
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
                    <legend><small class="text-primary">我的考试结果</small></legend>
                    <!-- 查询条件 -->
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtTitle" class="input-group-addon">试卷名称</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
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
                                            <th>试卷名称</th>
                                            <th>试题总数</th>
                                            <th>试卷总分</th>
                                            <th>考试得分</th>
                                            <th>考试时间</th>
                                            <th>操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpt_TestList" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %></td>
                                                    <td><%# Eval("TestName") %></td>
                                                    <td><%# Eval("TestCount") %></td>
                                                    <td><%# Eval("TestScore") %></td>
                                                    <td><%# GetTotalScore(Eval("AnswerGuid").ToString()) %></td>
                                                    <td><%# Eval("AnswerTime") %></td>
                                                    <td style="padding-left: 5px;"><a href='javascript:void(0);' onclick='showDetail("<%# Eval("TestGuid") %>","<%# Eval("AnswerGuid") %>")'>查看详细</a></td>
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
</body>
</html>
<script src="/jquery/1.9.1/jquery.min.js"></script>
<script src="/Script/layer/layer.min.js"></script>
<script src="/Script/common.js?t=" <%=t_rand %>></script>
<script type="text/javascript">
    function showDetail(tid, aid) {
        location.href = '/IncorruptEdu/ViewTestOnlineResult.aspx?t_id=' + tid + '&a_id=' + aid;
    }
</script>