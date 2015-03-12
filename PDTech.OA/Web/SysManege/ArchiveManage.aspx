<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArchiveManage.aspx.cs" Inherits="SysManege_ArchiveManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>公文管理</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/Sys.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t=" <%=t_rand %> />
    <script src="/Script/common.js?t=" <%=t_rand %>></script>
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script> 
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script>
        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function showDetail(archive_id, archive_type) {
            var src;
            /***待办事项***/
            if (archive_id != undefined) {
                switch (archive_type) {
                    case 10:
                        src = "/Archive/sel_Generalpieces.aspx?arId=" + archive_id + "";
                        break;
                    case 11:
                        src = "/Archive/sel_Ordinarypieces.aspx?arId=" + archive_id + "";
                        break;
                    case 12:
                        src = "/Archive/sel_supInfo.aspx?arId=" + archive_id + "";
                        break;
                    case 20: case 21: case 22: case 23:
                        src = "/Archive/sel_supInfo.aspx?arid=" + archive_id + "";
                        break;
                    case 24:
                        src = "/Admin/sel_Proposal.aspx?arid=" + archive_id + "";
                        break;
                    case 32:
                        src = "/Admin/sel_Personnal.aspx?arid=" + archive_id + "";
                        break;
                    case 33:
                        src = "/Admin/selFinance.aspx?arid=" + archive_id + "";
                        break;
                    case 40: case 41: case 42: case 43: case 44:
                        src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                        break;
                    case 51:
                        src = "/Risk/sel_risk.aspx?arid=" + archive_id + "";
                        break;
                    case 61: case 62:
                        src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                        break;
                }
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '620px'],
                offset: ['20px', ''],
                iframe: { src: src }
            });
        }
        /**步骤转向**/
        function EditStep(archive_id) {
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['720', '630px'],
                offset: ['20px', ''],
                iframe: { src: 'ArchiveSteering.aspx?arId=' + archive_id }
            });
        }
        function doRefresh() {
            document.getElementById('<%=btnSearch.ClientID %>').click();
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
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel">--%>
            <%--<ContentTemplate>--%>
                <section class="container">
                    <div class="container-fluid">
                        <fieldset>
                            <legend><small class="text-primary">公文管理</small></legend>
                            <!-- 查询条件（1） -->
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txtmName" class="input-group-addon">公文状态</label>
                                        <asp:DropDownList ID="dplArchiveState" runat="server" CssClass="easyui-combobox" Height="35px" Width="190px" data-options="panelHeight:'auto'"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="dplStatus" class="input-group-addon">工作类别</label>
                                        <asp:DropDownList ID="dplArchiveType" runat="server" CssClass="easyui-combobox" Height="35px" Width="190px"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txtTitle" class="input-group-addon">公文标题</label>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!-- 查询条件（2） -->
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txt_startTime" class="input-group-addon">开始</label>
                                        <asp:TextBox runat="server" ID="txtsTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txt_endTime" class="input-group-addon">结束</label>
                                        <asp:TextBox runat="server" ID="txteTime" CssClass="form-control" onFocus="WdatePicker({isShowClear:false,readOnly:true})" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="input-group">
                                        <label for="txtArchiveNo" class="input-group-addon">文件编号</label>
                                        <asp:TextBox ID="txtArchiveNo" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                    <th>公文类型</th>
                                                    <th>公文标题</th>
                                                    <th>送达时间</th>
                                                    <th>当前状态</th>
                                                    <th>管理</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rpt_ArchiveList" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 + AspNetPager.PageSize * (AspNetPager.CurrentPageIndex - 1) %> </td>
                                                            <td><%# Eval("ARCHIVE_TYPE_NAME") %></td>
                                                            <td><%# Eval("ARCHIVE_TITLE") %></td>
                                                            <td><%# Eval("CREATE_TIME") %></td>
                                                            <td><%# Enum.Parse(typeof(EArchiveIsState), Eval("CURRENT_STATE").ToString()) %></td>
                                                            <td>
                                                                <a href="javascript:void(0);" onclick='EditStep(<%# Eval("ARCHIVE_ID") %>)'>转向</a>|
                                                                <a href="javascript:void(0);" onclick='showDetail(<%# Eval("ARCHIVE_ID") %>,<%# Eval("ARCHIVE_TYPE") %>)'>查看</a>
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
            <%--</ContentTemplate>--%>
       <%-- </asp:UpdatePanel>--%>
    </form>
</body>
</html>
