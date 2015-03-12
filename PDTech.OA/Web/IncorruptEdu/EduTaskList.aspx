<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduTaskList.aspx.cs" Inherits="IncorruptEdu_EduTaskList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>教育任务</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link href="/css/aspnetpager.css?t=" <%=t_rand %> rel="stylesheet" />
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    
    <script type="text/javascript">
        function showDetail(id) {
            $.layer({
                type: 2,
                title: '查看任务',
                iframe: { src: '/IncorruptEdu/ViewEduTask.aspx?edu_id=' + id },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }
    </script>
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
                    <legend><small class="text-primary">我的教育任务</small></legend>
                    <!-- 查询条件 -->
                    <div id="dquery" runat="server"  class="row">
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txtmName" class="input-group-addon">任务标题</label>
                                <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="ddlType" class="input-group-addon">任务类型</label>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="easyui-combobox" Height="35px" Width="150px"></asp:DropDownList>
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
                                            <th>任务标题</th>
                                            <th>任务类型</th>
                                            <th>创建人</th>
                                            <th>创建时间</th>
                                            <th>来文单位</th>
                                            <th>详细</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpt_EducationList" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %></td>
                                                    <td><%# Eval("TITLE") %></td>
                                                    <td><%# Eval("FILETYPE") %></td>
                                                    <td><%# GetUserName((decimal)Eval("CREATOR")) %></td>
                                                    <td><%# Eval("CREATETIME") %></td>
                                                    <td><%# Eval("COMPANY") %></td>
                                                    <td><a href='javascript:void(0);' onclick='showDetail(<%# Eval("EDUCATION_ID") %>)'>查看</a></td>
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
