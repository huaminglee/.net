<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EdayQuestionundoList.aspx.cs" Inherits="IncorruptEdu_EdayQuestionundoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
     <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=<%=t_rand %>" />
     <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css?t=<%=t_rand %>" rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
            <div class="container-fluid">
                <fieldset>
                    <div class="row" style="display:none">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtsTime" class="input-group-addon">开始时间</label>
                                <asp:TextBox runat="server" ID="txtsTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="120px" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txteTime" class="input-group-addon">结束时间</label>
                                <asp:TextBox runat="server" ID="txteTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" Width="120px" />
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>

                    </div>



                    <legend><small class="text-primary">本月未做题目列表</small></legend>
                    <!-- 数据展示 -->
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-condensed table-bordered cursor">
                                    <thead>
                                        <tr>
                                            <th>序号</th>
                                            <th>题目</th>
                                          
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
                                                    <td><%# S_App.Substr(Eval("TITLE").ToString(),45) %></td>
                                                    
                                                    <td><a href='javascript:void(0);' onclick='showDetail(&apos;<%# Eval("EDU_Q_GUID") %>&apos;)'>答题</a></td>
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
                            <aspnetpager:aspnetpager id="AspNetPager" cssclass="paginator" currentpagebuttonclass="cpb"
                                runat="server" alwaysshow="false" firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页"
                                pagesize="10" prevpagetext="上一页" showcustominfosection="Left" showinputbox="Always" showpageindexbox="Always"
                                onpagechanged="AspNetPager_PageChanged" custominfotextalign="Left" layouttype="Table"
                                horizontalalign="Center" showpagesizebox="false" textbeforeinputbox="转到" textafterinputbox="页" custominfohtml="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" custominfosectionwidth="20%">
                            </aspnetpager:aspnetpager>
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
        function showDetail(eqid) {
            $.layer({
                type: 2,
                title: '每日一题',
                iframe: { src: '/EdayQuestion.aspx?eqid=' + eqid },
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
    </script>
</body>
</html>
