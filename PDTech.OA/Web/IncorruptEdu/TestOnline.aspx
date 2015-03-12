<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestOnline.aspx.cs" Inherits="IncorruptEdu_TestOnline" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="AspNetPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    .ddlinput
    {
        padding: 2px 3px;
        background: #fff;
        font-size: 1em;
        color: #000;
    }

    .notice_emal
    {
        width: 16px;
        height: 10px;
        overflow: hidden;
        background: url(../images/topsem_tag.png) no-repeat -82px -234px;
        margin: 0 auto;
    }

    .notice_emal_unread
    {
        background-position: -82px -246px;
    }

    .notice_unread td
    {
        font-weight: bold;
    }

    .btnIsRead
    {
        width: 120px;
        height: 27px;
        background-color: #f7ae1e;
        border-radius: 3px;
        padding-left: 10px;
        font-size: 14px;
        line-height: 26px;
        cursor: pointer;
        text-align: center;
        letter-spacing: 3px;
        border:none;
    }
</style>
    <link rel="stylesheet" type="text/css" href="/CSS/Sys.css?t="<%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/aspnetpager.css?t="<%=t_rand %> />
    <script type="text/javascript" src="../jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Script/common.js?t="<%=t_rand %>></script>
    <script type="text/javascript">window.history.forward();</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Manage_Center_title" style="margin:0 auto;">
    在线考试
</div>
<div class="Manage_MainList" style="margin:0 auto;">
    <div class="Manage_MainList_top left">
        <div class="Fillet_lt_m left"></div>
        <div class="MainListNew_top_c left"></div>
        <div class="Fillet_rt_m left"></div>
    </div>
    <div class="MainListNew_Query left">
        <table style="width:100%;">
            <tr>
                <td style="text-align:center;">
                    <b>试卷：</b><span style="font-weight:bold;"><asp:Label ID="lbTestName" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label></span>
                </td>
            </tr>
        </table>
    </div>
    <div class="MainListNew_box left">
        <table class="main_newtabList" cellpadding="0px" cellspacing="0px">
            <%for (int i = np.StartPosition; i < toModel.QuestionCollection.Count && i < (np.StartPosition + np.PageCount); i++)%>
                    <%{ %>
            <tr>
                <td><div style="font-weight:bold; white-space:normal;word-break:break-all;word-wrap : break-word;"><%=i+1 %>、<%=toModel.QuestionCollection[i].Title %></div></td>
            </tr>
            <tr>
                <td>
                    <table id="rblOption">
                        <tr>
                            <td>
                                <%if(toModel.QuestionCollection[i].SelectValue == "A"){ %>
                                <input id="option_<%=i %>_A" type="radio" index="0" checked group="option_<%=toModel.QuestionCollection[i].QuestionID %>_0" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=A" onclick="selectOption(this)" /><label for="option_<%=i %>_A">A、<%=toModel.QuestionCollection[i].OptionA %></label>
                                <%}else{ %>
                                <input id="option_<%=i %>_A" type="radio" index="0" group="option_<%=toModel.QuestionCollection[i].QuestionID %>_0" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=A" onclick="selectOption(this)" /><label for="option_<%=i %>_A">A、<%=toModel.QuestionCollection[i].OptionA %></label>
                                <%} %>
                            </td></tr>
                        <tr>
                            <td>
                                <%if(toModel.QuestionCollection[i].SelectValue == "B"){ %>
                                <input id="option_<%=i %>_B" type="radio" index="1" checked group="option_<%=toModel.QuestionCollection[i].QuestionID %>_1" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=B" onclick="selectOption(this)" /><label for="option_<%=i %>_B">B、<%=toModel.QuestionCollection[i].OptionB %></label>
                                <%}else{ %>
                                <input id="option_<%=i %>_B" type="radio" index="1"  group="option_<%=toModel.QuestionCollection[i].QuestionID %>_1" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=B" onclick="selectOption(this)" /><label for="option_<%=i %>_B">B、<%=toModel.QuestionCollection[i].OptionB %></label>
                                <%} %>
                            </td></tr>
                        <tr>
                            <td>
                                <%if(toModel.QuestionCollection[i].SelectValue == "C"){ %>
                                <input id="option_<%=i %>_C" type="radio" index="2" checked group="option_<%=toModel.QuestionCollection[i].QuestionID %>_2" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=C" onclick="selectOption(this)" /><label for="option_<%=i %>_C">C、<%=toModel.QuestionCollection[i].OptionC %></label>
                                <%}else{ %>
                                <input id="option_<%=i %>_C" type="radio" index="2" group="option_<%=toModel.QuestionCollection[i].QuestionID %>_2" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=C" onclick="selectOption(this)" /><label for="option_<%=i %>_C">C、<%=toModel.QuestionCollection[i].OptionC %></label>
                                <%} %>
                            </td></tr>
                        <%if (!string.IsNullOrEmpty(toModel.QuestionCollection[i].OptionD)){ %>
                        <tr>
                            <td>
                                <%if(toModel.QuestionCollection[i].SelectValue == "D"){ %>
                                <input id="option_<%=i %>_D" type="radio" index="3" checked group="option_<%=toModel.QuestionCollection[i].QuestionID %>_3" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=D" onclick="selectOption(this)" /><label for="option_<%=i %>_D">D、<%=toModel.QuestionCollection[i].OptionD %></label>
                                <%}else{ %>
                                <input id="option_<%=i %>_D" type="radio" index="3" group="option_<%=toModel.QuestionCollection[i].QuestionID %>_3" name="<%=toModel.QuestionCollection[i].QuestionID %>" value="<%=toModel.QuestionCollection[i].QuestionID %>=D" onclick="selectOption(this)" /><label for="option_<%=i %>_D">D、<%=toModel.QuestionCollection[i].OptionD %></label>
                                <%} %>
                            </td></tr>
                        <%} %>
                    </table>
                 </td>
            </tr> 
            <%} %>      
        </table>
    </div>
    <div class="PagerAreaNew left">
        <table style="width:100%">
            <tr align="center">                       
                <td>
                    <asp:Button ID="btnPrevPage" Text="上一页" OnClientClick="return check()" runat="server" CssClass="pageBtn" BorderStyle="None"
                        Font-Bold="true" BackColor="Transparent" OnClick="btnPrevPage_Click" />&nbsp;
                    <asp:Button ID="btnNextPage" Text="下一页" OnClientClick="return check()" runat="server" CssClass="pageBtn" BorderStyle="None"
                        Font-Bold="true" BackColor="Transparent" OnClick="btnNextPage_Click"  />&nbsp;
                    <asp:Button ID="btnSubmit" Text="提交 " OnClientClick="return check()" runat="server" CssClass="pageBtn" BorderStyle="None"
                        Font-Bold="true" BackColor="Transparent" OnClick="btnSubmit_Click"  />&nbsp;
                    <asp:HiddenField ID="hidPageIndex" runat="server" /><asp:HiddenField ID="hidResult" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="Manage_MainList_down left">
        <div class="Fillet_ld_m left"></div>
        <div class="MainListNew_down_c left"></div>
        <div class="Fillet_rd_m left"></div>
    </div>
</div>
    </form>
</body>
</html>
<script type="text/javascript">
    function selectOption(obj) {
        var index = $(obj).attr("index");
        var optionid = $(obj).attr("name");
        var list = $("input[group^='option_" + optionid + "']");
        for (var i = 0; i < list.length; i++) {
            if (i == index) {
                $(list[i]).attr("checked", "checked");
            } else {
                $(list[i]).removeAttr("checked");
            }
        }
    }

    function check() {
        var list = $("input[type='radio']:checked");
        for (var i = 0; i < list.length; i++) {
            $("#hidResult").val($("#hidResult").val() + $(list[i]).attr("value") + ";");
        }
    }
</script>
