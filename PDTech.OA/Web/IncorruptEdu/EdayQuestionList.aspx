<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EdayQuestionList.aspx.cs" Inherits="IncorruptEdu_EdayQuestionList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>每日一题</title>
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
                    <legend><small class="text-primary">我的每日一题</small></legend>
                    <!-- 查询条件 -->
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="input-group">
                                <label for="txtTitle" class="input-group-addon">题目</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                        <%if (flag == 1)
                          { %>
                        <div class="col-sm-1">
                            <input type="button" value="返&ensp;回" class="btn btn-primary" onclick="location.href = '/Risk/DailyQuestion.aspx'" />
                        </div>
                        <%} %>
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
                                            <th>题目</th>
                                            <%--<th>选择答案</th>--%>
                                             <th>回答次数</th>
                                            <th>正确答案</th>
                                            <th>答题时间</th>
                                            <th>操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpt_EdayQuestionList" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %></td>
                                                    <td><%# S_App.Substr(GetTitle(Eval("EDU_Q_GUID").ToString()),45) %></td>
                                                    <%--<td><%# Eval("ANSWER").ToString() == "" ? "<跳过>" : Eval("ANSWER") %></td>--%>
                                                   <td><%# Eval("STATE") %></td>
                                                     <td><span style="color: red"><%# GetAnswer(Eval("EDU_Q_GUID").ToString()) %></span></td>
                                                    <td><%# Eval("ANSWER_TIME") %></td>
                                                    <td><a href='javascript:void(0);' onclick='showDetail(<%# Eval("EDAY_Q_ID") %>)'>查看</a></td>
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
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
    <script type="text/javascript">
        function showDetail(edayid) {
            $.layer({
                type: 2,
                title: '查看题目',
                iframe: { src: '/IncorruptEdu/EdayQuestionDetail.aspx?eday_id=' + edayid },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }
    </script>
</body>
</html>
