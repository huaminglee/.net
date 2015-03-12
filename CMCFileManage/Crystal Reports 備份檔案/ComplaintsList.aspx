<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="ComplaintsList.aspx.vb"
    Inherits="CMCFileManage.ComplaintsList" %>

<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <%-- <script type="text/javascript">
        $(document).ready(function() {
            zhedie();
        });
        function zhedie() {
            var index = 1;
            var strSex = "";
            var pertotal = 0;
            $.each($('#GridView1 tr'), function(t, own) {
                if (index == t) {
                    strSex = $(own).children().get(0).innerText;
                    $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                    $(own).addClass("rows_" + index);
                    $(own).children('td').get(0).innerHTML = "<a  href='#'  onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\">" + strSex + "</a>";
                }
                else if (t > 0) {
                    if (!isNaN($(own).children().get(0).innerText) && ($(own).children().get(0).innerText) != " ") {   //如果分組依據為數字則失效
                        $(own).addClass("rows_" + index + "_child");
                        pertotal += 1;
                        $(own).hide();
                    }
                    else {
                        if (($(own).children().get(0).innerText) != " ") {
                            $(".rows_" + index).children('td').get(9).innerHTML = pertotal
                            pertotal = 0;
                            index = t;
                            strSex = $(own).children().get(0).innerText;
                            $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                            $(own).addClass("rows_" + index);
                            $(own).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\">" + strSex + "</a>";
                        }
                        else {
                            $(".rows_" + index).children('td').get(9).innerHTML = "" + pertotal;
                        }
                    }
                }
            })

        }
        function ShowDetail(classname, moname) {
            var size = $("." + classname).size();
            if (size > 0) {
                $("." + classname).toggle();
            }
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="search">
        <ul class="searchli">
            <li class="LiAdd "><a target="_self"  href="ComplaintsDetail.aspx">新增</a></li>
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <li>
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblDocUniqueID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.eFlowDocID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="_self"  runat="server" ToolTip="查看" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="區域" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                    DataField="QyuLocation">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="被投訴單位" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                    DataField="BeComplaintsDept">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="記錄編號" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                    DataField="RecordNO">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="投訴時間" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                    DataField="ComplaintsDate" DataFormatString="{0:yyyy-MM-dd}">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="期望完成時間" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                    DataField="HopeFinishTime" DataFormatString="{0:yyyy-MM-dd}">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="投訴事件簡述" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbDesc" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ComplaintsDesc") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否結案" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LbIsfinished" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsFinished")  %>'
                            Visible="false"></asp:Label>
                        <asp:Label ID="LbIsFinishedShow" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/trash.png" CommandName="Delete">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="數量" />
            </Columns>
        </asp:GridView>
    </div>
    <div id="page">
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    </form>
</body>
</html>
