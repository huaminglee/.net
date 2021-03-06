﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OtherFileList.aspx.vb"
    Inherits="CMCFileManage.OtherFileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eFlowWebControl" Namespace="eFlowWebControl" TagPrefix="cc1" %>
<%@ Register Src="../UCtl/GridQy.ascx" TagName="GridQy" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/newaction.css" rel="stylesheet" type="text/css" />

    <script src="../NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>


    <script src="Standartfile.js" type="text/javascript"></script>

    <%--<script type="text/javascript">
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
                    $(own).html("<td bgcolor='#D7E3FF' class='GroupExp' ></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
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
                            $(own).html("<td bgcolor='#D7E3FF'  class='GroupExp'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'><td bgcolor='#D7E3FF'></td></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td><td  bgcolor='#D7E3FF'></td>");
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
<body scroll="Auto">
    <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%">
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" ImageUrl="../Images/blank.jpg" />
                <div id="search">
                    <ul class="searchli">
                        <li id="add" runat="server" class="LiAdd"><a id="addnew" runat="server" target="MainFrame"
                            href="#"><span>新增文件 </span></a></li>
                        <li>
                            <asp:TextBox ID="TxtSearchCondition" class="text-input" runat="server" Width="500px"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="Button1" class="button" runat="server" Text="搜尋" Height="30px" /></li>
                    </ul>
                </div>
                <div style="clear: both">
                </div>
                <br />
                <div id="emptyinfo" runat="server" visible="false" style="width: 100%; height: 30px;
                    background-color: #DBE3FF; line-height: 30px; overflow: hidden;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/information.png" />
                    &nbsp;&nbsp;&nbsp; 沒有找到相關記錄，請嘗試其他選項。</div>
                <div>
                    <asp:GridView ID="GridViewTop" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="實驗室">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Style="cursor: hand;" ImageUrl="../Images/addGrid.png" />
                                    <asp:Label ID="LbApplydept" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.StandardDept") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:GridQy ID="GridQy1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nums" HeaderText="數量" ItemStyle-HorizontalAlign="Right"
                                ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowFooter="True">
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LblNo" Width="30px" runat="server" Text="<%# Container.DataItemIndex+1+PageSize*(PageIndex-1)%>"></asp:Label>
                                    <asp:Label ID="LblPKID" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID").ToString() %>'
                                        Visible="False"></asp:Label>
                                    <asp:HyperLink ID="HLDetail" Target="MainFrame" runat="server" ToolTip="查看" ImageUrl="~/Images/edit.gif">查看</asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="QYLocation" HeaderText="區域" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="StandardDept" HeaderText="實驗室" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="StandardName" HeaderText="標準名稱" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="StandardNumber" HeaderText="標準號碼" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="StandardVersion" HeaderText="REV" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="狀態" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="LbFileStatusnum" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.StandardStatus").ToString() %>'></asp:Label>
                                    <asp:Label ID="LbFileStatus" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StandardOrganize" HeaderText="標準組織" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" CommandName="Delete">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="數量" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="page">
                    <cc1:PagerControl ID="PagerControl1" Visible="false" runat="server" SkinID="PagerControlSkin">
                    </cc1:PagerControl>
                </div>
               
                <div style="display: none">
                 <asp:Button ID="BtnSetztcssshow" runat="server" Text="Button" />
                <asp:Button ID="BtnSetztcsshid" runat="server" Text="Button" />
                <asp:Button ID="BtnSetzzcssshow" runat="server" Text="Button" />
                <asp:Button ID="BtnSetzzcsshid" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetFileCssShow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetFileCSSHid" runat="server" Text="Button" />
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSSshow" runat="server" Text="Button" />
                    <asp:Button ID="BtnSetCSShidd" runat="server" Text="Button" />
                    <asp:HiddenField ID="Hiddenparenetindex" runat="server" />
                    <asp:HiddenField ID="HiddenQyRowindex" runat="server" />
                    <asp:HiddenField ID="HiddenztRowindex" runat="server" />
                    <asp:HiddenField ID="HiddenzzRowindex" runat="server" />
                    <asp:HiddenField ID="HiddencursetcssQyindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurrowindex" runat="server" />
                    <asp:HiddenField ID="Hiddencurdeptname" runat="server" />
                    <asp:HiddenField ID="Hiddencursetcssfileindex" runat="server" />
                    <asp:HiddenField ID="HiddenType" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
