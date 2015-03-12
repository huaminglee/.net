<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucEduQuestionList.ascx.cs" Inherits="SysManege_UserControls_ucEduQuestionList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<section class="container">
    <div class="container-fluid">
        <fieldset>
            <legend><small class="text-primary">在线考试题库</small></legend>
            <!-- 查询条件 -->
            <div class="row">
                <div class="col-sm-3">
                    <div class="input-group">
                        <label for="txtTitle" class="input-group-addon">题目</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnSearch" runat="server" Text="查&ensp;询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
                <div class="col-sm-1">
                    <input type="button" class="btn btn-primary" onclick="addQuestion()" value="添&ensp;加" />
                </div>
                <div class="col-sm-3">
                    <asp:FileUpload ID="filePath" runat="server" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnImport" runat="server" Text="导入试题" CssClass="btn btn-primary" UseSubmitBehavior="false" OnClick="btnImport_Click" />
                </div>
                <div class="col-sm-1">
                    <%--<a href="../../Upload/Template/在线考试试题模板.xls">下载模板</a>--%>
                    <%--<input type="button" class="btn btn-primary" onclick="location.href = '/Upload/Template/在线考试试题模板.xls'" value="下载模板" />--%>
                    <asp:Button ID="btnDownload" runat="server" Text="下载模板" CssClass="btn btn-primary" OnClick="btnDownload_Click"/>
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
                                    <th>题目</th>
                                    <th>分值</th>
                                    <th>添加时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpt_QuestionList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                            <td><%# S_App.Substr(Eval("TITLE").ToString(),45) %></td>
                                            <td><%# Eval("SCORE") %></td>
                                            <td><%# Eval("CREATETIME")%></td>
                                            <td style="text-align: center;">
                                                <a href='javascript:void(0);' onclick='editQuestion("<%# Eval("EDU_Q_GUID") %>")'>编辑</a>
                                            </td>
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

<script>
    function doRefresh() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }

    function doClose() {
        doRefresh();
        layer.closeAll();
    }

    function addQuestion() {
        $.layer({
            type: 2,
            title: '新建试题',
            iframe: { src: '/SysManege/EditQuestion.aspx' },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }

    function editQuestion(quid) {
        $.layer({
            type: 2,
            title: '编辑试题',
            iframe: { src: '/SysManege/EditQuestion.aspx?qu_id=' + quid },
            maxmin: true,
            area: ['985px', '585px'],
            border: [1, 0.2, '#000', true],
            offset: ['20px', '']
        });
    }
</script>
