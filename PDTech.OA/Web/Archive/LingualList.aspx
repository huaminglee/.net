<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LingualList.aspx.cs" Inherits="Archive_LingualList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文种列表</title>
    <link href="/CSS/public.css" rel="stylesheet" />
    <link href="/CSS/popMain.css?t=" <%=t_rand %> rel="stylesheet" />
    <script src="/jquery/1.8.3/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            chkSel();
        });
        function chkSel() {
            $('input[name="rbtn_chk"]').each(function () {
                if (this.value == $("#hidTempId").val())
                    $(this).attr("checked", "checked");
            });
        };
        function GetValue(e) {

            $("#hidTempId").val($(e).val());
        }
        function GetTrValue(e) {
            $(e).children("td").children("input[type=radio]").attr("checked", "checked");
            $("#hidTempId").val(($(e).children("td").children("input[type=radio]").val()));
        }
        function openSelectFile() {
            window.parent.$("#hidTempName").val($("#hidTempId").val());
            window.parent.$("#txtDocType").val($("#hidTempId").val());
            window.parent.layer.closeAll();
        }
    </script>
</head>
<body>
    <form id="pForm" runat="server">
        <div id="TheProcess" class="TheProcess">
            <div class="MainQuery left">
                <asp:TextBox ID="txtName" runat="server" CssClass="inputx inputd"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="subBtn" OnClick="btnSearch_Click" />
                <input type="button" value="确定" class="subBtn" onclick="openSelectFile();" />
                <input type="button" value="关闭" class="subBtn" onclick="window.parent.layer.closeAll();" />
            </div>
            <div class="con_c left">
                <table class="main_tabList" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <th style="width: 20%;">选择</th>
                        <th style="width: 30%;">文种名称</th>
                        <th style="width: 50%;">文种简称</th>
                    </tr>
                    <asp:Repeater ID="rpt_tempList" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr onclick="GetTrValue(this);">
                                <td>&nbsp;&nbsp;<input type="radio" name='rbtn_chk' id="rbtn_chk" onclick="GetValue(this);" value='<%# Eval("BASE_JC") %>' />&nbsp;</td>
                                <td><%# Eval("BASE_NAME") %> </td>
                                <td><%# Eval("BASE_JC") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

            </div>
            <div class="PagerArea left">
                <AspNetPager:AspNetPager ID="AspNetPager" CssClass="paginator" CurrentPageButtonClass="cpb"
                    runat="server" AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PageSize="10" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Always" ShowPageIndexBox="Always"
                    OnPageChanged="AspNetPager_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
                    HorizontalAlign="Center" ShowPageSizeBox="false" TextBeforeInputBox="转到" TextAfterInputBox="页" CustomInfoHTML="共%RecordCount%条记录,当前显示第%CurrentPageIndex%页" CustomInfoSectionWidth="20%">
                </AspNetPager:AspNetPager>
            </div>
        </div>
        <asp:HiddenField ID="hidTempId" runat="server" Value="" />
    </form>
</body>
</html>
