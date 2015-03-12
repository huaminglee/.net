<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportantGoodsList.aspx.vb"
    Inherits="CMCFileManage.ImportantGoodsList" %>

<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>
     <script type="text/javascript">
         function zhedie() {
             var index = 1;
             var strSex = "";
             var pertotal = 0;
             $.each($('#GridView1 tr'), function(t, own) {
                 if (index == t) {
                     strSex = $(own).children().get(0).innerText;

                     $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");

                     $(own).addClass("rows_" + index);
                     $(own).children('td').get(0).innerHTML = "<a  href='#'  onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\"><font color='red'>+</font>" + strSex + "</a>";
                 }
                 else if (t > 0) {
                     if (!isNaN($(own).children().get(0).innerText) && ($(own).children().get(0).innerText) != " ") {   //如果分組依據為數字則失效
                         $(own).addClass("rows_" + index + "_child");
                         pertotal += 1;
                         $(own).hide();
                     }
                     else {
                         if (($(own).children().get(0).innerText) != " ") {
                             $(".rows_" + index).children('td').get(8).innerHTML = pertotal
                             pertotal = 0;
                             index = t;
                             strSex = $(own).children().get(0).innerText;
                             $(own).html("<td bgcolor='#D7E3FF' width='10%' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
                             $(own).addClass("rows_" + index);
                             $(own).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\"><font color='red'>+</font>" + strSex + "</a>";
                         }
                         else {
                             $(".rows_" + index).children('td').get(8).innerHTML = "" + pertotal;
                         }
                     }
                 }
             })

         }
         function ShowDetail(classname, moname) {
             strSex = $("." + moname).children('td').get(0).innerText;
             if (strSex.substring(0, 1) == "+") {
                 strSex = strSex.substring(1, strSex.length);
                 $("." + moname).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('" + classname + "','" + moname + "')\"><font color='red'>-</font>" + strSex + "</a>";

             }
             else {
                 strSex = strSex.substring(1, strSex.length);
                 $("." + moname).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('" + classname + "','" + moname + "')\"><font color='red'>+</font>" + strSex + "</a>";

             }


             var size = $("." + classname).size();
             if (size > 0) {
                 $("." + classname).toggle();
             }
         }
    </script>
    
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <div id="search">
        <ul class="searchli">
            <li id="add" runat="server" class="LiAdd"><a id="addnew" runat="server" target="MainFrame"
                href="ImportantGoodsDetail.aspx" >新增文件</a></li>
            <li>
                <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
            <li>
                <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
            <li>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" class="button" runat="server" Text="按實驗室分組顯示" Height="30px" />
            </li>
        </ul>
    </div>
    <div style="clear: both">
    </div>
    <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
        background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
        &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%" ShowFooter="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                        <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                            Visible="False"></asp:Label>
                        <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/pen.png">查看</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GoodsName" HeaderText="品名" />
                <asp:BoundField DataField="Qulocation" HeaderText="區域" />
                <asp:BoundField DataField="LabName" HeaderText="實驗室" />
                <asp:BoundField DataField="Standars" HeaderText="規格型號" />
                <asp:BoundField DataField="Brands" HeaderText="廠牌" />
                <asp:BoundField DataField="Supplier" HeaderText="供應商" />
                <asp:BoundField DataField="TecRequir" HeaderText="技術規格" />
                <asp:BoundField HeaderText="數量" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/trash.png" CommandName="Delete">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
        </cc1:PagerControl>
    </div>
    </form>
</body>
</html>
