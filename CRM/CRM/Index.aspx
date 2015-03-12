<%@ Page Language="vb" AutoEventWireup="false" Theme="Default" CodeBehind="Index.aspx.vb"
    Inherits="CRM.Index" %>

<%@ Register Src="UCtl/UcWorkWaitFor.ascx" TagName="UcWorkWaitFor" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
        }
        a
        {
            text-decoration: none;
            color: #00c6ff;
        }
        h1
        {
            font: 4em normal Arial, Helvetica, sans-serif;
            padding: 20px;
            margin: 0;
            text-align: center;
        }
        h1 small
        {
            font: 0.2em normal Arial, Helvetica, sans-serif;
            text-transform: uppercase;
            letter-spacing: 0.2em;
            line-height: 5em;
            display: block;
        }
        h2
        {
            font-weight: 700;
            color: #bbb;
            font-size: 20px;
        }
        h2, p
        {
            margin-bottom: 10px;
        }
        @font-face
        {
            font-family: 'BebasNeueRegular';
            src: url('BebasNeue-webfont.eot');
            src: url('BebasNeue-webfont.eot?#iefix') format('embedded-opentype'), url('BebasNeue-webfont.woff') format('woff'), url('BebasNeue-webfont.ttf') format('truetype'), url('BebasNeue-webfont.svg#BebasNeueRegular') format('svg');
            font-weight: normal;
            font-style: normal;
        }
        .container
        {
            width: 960px;
            margin: 0 auto;
            overflow: hidden;
        }
        #Date
        {
            font-weight: bold;
            font-family: 'BebasNeueRegular' , Arial, Helvetica, sans-serif;
            font-size: 15px;
            text-align: center;
            text-shadow: 0 0 5px #00c6ff;
        }
        ul
        {
            font-weight: bold;
            color: Green;
            margin: 0 auto;
            padding: 0px;
            list-style: none;
            text-align: center;
        }
        ul li
        {
            display: inline;
            font-size: 20px;
            text-align: center;
            font-family: 'BebasNeueRegular' , Arial, Helvetica, sans-serif;
            text-shadow: 0 0 5px #00c6ff;
        }
        #point
        {
            position: relative;
            -moz-animation: mymove 1s ease infinite;
            -webkit-animation: mymove 1s ease infinite;
            padding-left: 10px;
            padding-right: 10px;
        }
        @-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}@-moz-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}
    </style>
    <link href="CSS/reset.css" rel="stylesheet" type="text/css" />
    <link href="CSS/indexstyle.css" rel="stylesheet" type="text/css" />
    <link href="CSS/invalid.css" rel="stylesheet" type="text/css" />

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="NewScript/simpla.jquery.configuration.js" type="text/javascript"></script>

    <script src="NewScript/facebox.js" type="text/javascript"></script>

    <script src="NewScript/jquery.wysiwyg.js" type="text/javascript"></script>

    <script src="NewScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            // Create two variable with the names of the months and days in an array
            var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]

            // Create a newDate() object
            var newDate = new Date();
            // Extract the current date from Date object
            newDate.setDate(newDate.getDate());
            // Output the day, date, month and year    
            $('#Date').html(dayNames[newDate.getDay()] + " " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

            setInterval(function() {
                // Create a newDate() object and extract the seconds of the current time on the visitor's
                var seconds = new Date().getSeconds();
                // Add a leading zero to seconds value
                $("#sec").html((seconds < 10 ? "0" : "") + seconds);
            }, 1000);

            setInterval(function() {
                // Create a newDate() object and extract the minutes of the current time on the visitor's
                var minutes = new Date().getMinutes();
                // Add a leading zero to the minutes value
                $("#min").html((minutes < 10 ? "0" : "") + minutes);
            }, 1000);

            setInterval(function() {
                // Create a newDate() object and extract the hours of the current time on the visitor's
                var hours = new Date().getHours();
                // Add a leading zero to the hours value
                $("#hours").html((hours < 10 ? "0" : "") + hours);
            }, 1000);

        });
        function addcalendar() {

            var title = $("#facebox #TxtTitle").val();
            var xiangxi = $("#facebox #Txtmiaoshu").val();
            var begintime = $("#facebox #TxtStartDate").val();
            var endtime = $("#facebox #TxtEndDate").val();
            var dotime = $("#facebox #TxtDoDate").val();

            $("#HiddenTitle").val(title);
            $("#Hiddenxiangxi").val(xiangxi);
            $("#Hiddenstart").val(begintime);
            $("#Hiddenend").val(endtime);
            $("#Hiddendo").val(dotime)
            $("#Btnaddclendar").click();

        }
        function resetpassword() {
            window.open("/CRM/Forms/ChangePassword.aspx",
		"",
		"width=320,height=150,left=400,top=380,resizable=no");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div style="float: right">
        <div id="Date">
        </div>
        <ul>
            <li id="hours"></li>
            <li id="point">:</li>
            <li id="min"></li>
            <li id="point">:</li>
            <li id="sec"></li>
        </ul>
    </div>
    <div style="float: left">
       <table width="100%">
            <tr>
                <td width="220px">
                    <div style="float: left; width: 100px;" align="center">
                        <asp:Image ID="Image1" runat="server" Width="90" Height="100" ImageUrl="UserPhoto/defaultimg.jpg" />
                        <br />
                        <br />
                    </div>
                    <div style="float: right; width: 120px;">
                        <br />
                        <a id="username" runat="server" href="Forms/UserADVInfo.aspx" style="font-size: 18px;
                            text-transform: none; color: #333333; text-decoration: none;" title="編輯個人資料">UserName</a>
                        <asp:Image ID="Image5" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/cusico.png" />
                        <br />
                        <asp:Label ID="LbJibenxinxi" runat="server" Font-Size="12px" ForeColor="#999999"></asp:Label>
                    </div>
                </td>
                <td width="30px">
                </td>
                <td valign="top">
                    &nbsp; &nbsp; <a href="#" class="button " heigth="30px" onclick="resetpassword()"
                        title="修改密碼">修改密碼</a> &nbsp; &nbsp; &nbsp; &nbsp; <a id="setagent" runat ="server"  href="http://cmc.efoxconn.com/eFlowNet/Forms/HR/AgentDetail.aspx"
                            target="_blank" class="button " heigth="30px" title="設定代理">設定代理</a> &nbsp;
                    &nbsp; &nbsp; &nbsp; <a href="Forms/UserADVInfo.aspx" class="button " heigth="30px"
                        title="編輯個人資料">編輯個人資料</a>
                </td>
                <td valign="top" align="left">
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div style="float: left; width: 70%;">
        <div style="width: 100%;">
            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td bgcolor="#E6E6E6" height="30" valign="middle" style="font-size: 14px; font-weight: bold">
                        <asp:Image ID="Image6" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/waitfor.png" />
                        代辦事項
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:UcWorkWaitFor ID="UcWorkWaitFor1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="eventinfo" style="width: 100%; display :none ">
            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td bgcolor="#E6E6E6" height="30" valign="middle" style="font-size: 14px; font-weight: bold">
                        <asp:Image ID="Image9" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/calendar.png" />
                        日程提醒 <a href="#messages" rel="modal">添加<asp:Image ID="Image2" runat="server" ImageUrl="Images/add.png" /></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%" onmouseover="c=this.style.backgroundColor;this.style.backgroundColor='#79B900'"
                                    onmouseout="this.style.backgroundColor=c">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image3" runat="server" ImageUrl="Images/calentix.jpg" Height="30" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Lbtitle" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Title")%>'></asp:Label><br />
                                            <asp:Label ID="Lbxiangxi" Visible="false" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Xiangxi")%>'></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Extend2")%>'></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="IMBFinish" ToolTip="已完成" runat="server" CommandName="finish"
                                                ImageUrl="~/Images/Finish.gif" />
                                            <asp:ImageButton ID="IMBDelete" CommandName="Delete" ToolTip="移除" runat="server"
                                                ImageUrl="~/Images/Delete.gif" />
                                            <asp:Label ID="LbPKID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID") %>'></asp:Label>
                                            <asp:Label ID="LbIsdeal" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsDeal") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="LbShow" runat="server" Text="當前沒有添加日程信息" Visible="False" ForeColor="#993333"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </div>
    <div style="float: right; width: 25%">
        <div id="contactbirthinfo" style="width: 100%;" align="left">
            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td bgcolor="#E6E6E6" height="30" valign="middle" style="font-size: 14px; font-weight: bold">
                        <asp:Image ID="Image7" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/birthday.png" />
                        聯繫人生日提醒
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="近期沒有聯繫人過生日。"></asp:Label>
                        <asp:DataList ID="DataList2" runat="server">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.UserName") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LbBirth" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Birthday") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LbDays" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
        <div style ="display :none " >
            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td bgcolor="#E6E6E6" height="30" valign="middle" style="font-size: 14px; font-weight: bold">
                        <asp:Image ID="Image4" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/Warning.gif" />
                        逾期未完成工作
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbshow3" runat="server" Text="沒有逾期未完成工作。" ForeColor="#336600"></asp:Label>
                        <asp:DataList ID="DataList3" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td height="50px">
                                            <asp:Label ID="Lbtitle" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Title")%>'></asp:Label><br />
                                            <asp:Label ID="Lbxiangxi" Visible="false" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Xiangxi")%>'></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%#  DataBinder.Eval(Container,"DataItem.Extend2")%>'></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="IMBFinish" ToolTip="已完成" runat="server" CommandName="finish"
                                                ImageUrl="~/Images/Finish.gif" />
                                            <asp:ImageButton ID="IMBDelete" CommandName="Delete" ToolTip="移除" runat="server"
                                                ImageUrl="~/Images/Delete.gif" />
                                            <asp:Label ID="LbPKID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.PKID") %>'></asp:Label>
                                            <asp:Label ID="LbIsdeal" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IsDeal") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF"
                bordercolor="#999999">
                <tr>
                    <td bgcolor="#E6E6E6" height="30" valign="middle" style="font-size: 14px; font-weight: bold">
                        <asp:Image ID="Image8" runat="server" Style="vertical-align: middle" ImageUrl="~/Images/ico/personal.png" />
                        個人資料
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    電話
                                </td>
                                <td>
                                    <asp:Label ID="Lbphone" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    性別
                                </td>
                                <td>
                                    <asp:Label ID="Lbsex" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    生日
                                </td>
                                <td>
                                    <asp:Label ID="Lbbirth" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    地址
                                </td>
                                <td>
                                    <asp:Label ID="Lbaddr" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    學歷
                                </td>
                                <td>
                                    <asp:Label ID="Lbdegree" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="Btnaddclendar" runat="server" Text="Button" />
        <asp:HiddenField ID="HiddenTitle" runat="server" />
        <asp:HiddenField ID="Hiddenxiangxi" runat="server" />
        <asp:HiddenField ID="Hiddenstart" runat="server" />
        <asp:HiddenField ID="Hiddenend" runat="server" />
        <asp:HiddenField ID="Hiddendo" runat="server" />
    </div>
    <div id="messages" style="display: none">
        <!-- Messages are shown when a link with these attributes are clicked: href="#messages" rel="modal"  -->
        <h3>
            添加日程</h3>
        <p>
            <strong>標題</strong>
        </p>
        <asp:TextBox ID="TxtTitle" runat="server" Width="97.5%"></asp:TextBox>
        <p>
            <strong>事件簡述</strong>
        </p>
        <asp:TextBox ID="Txtmiaoshu" runat="server" Width="97.5%" TextMode="MultiLine" Height="50px"></asp:TextBox>
        <p>
            活動時間:<asp:TextBox ID="TxtDoDate" runat="server" Width="180px"></asp:TextBox>
            <br />
            提醒時間:<asp:TextBox ID="TxtStartDate" runat="server" Width="80px"></asp:TextBox>至<asp:TextBox
                ID="TxtEndDate" runat="server" Width="80px"></asp:TextBox></p>
        <a class="button " onclick="addcalendar()">添加</a>
    </div>
    </form>
</body>
</html>
