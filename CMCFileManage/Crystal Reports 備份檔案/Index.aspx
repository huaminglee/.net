<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="CMCFileManage.Index" %>

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
        @-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}@-moz-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}</style>

    <script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>

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
    </script>

    <%--<script src="NewScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            zhedie();
        });
        function zhedie() {
            var index = 1;
            var strSex = "";
            var pertotal = 0;
            $.each($('#UcWorkWaitFor1_GridView1 tr'), function(t, own) {
                if (index == t) {
                    strSex = $(own).children().get(0).innerText;
                    $(own).html("<td bgcolor='#D7E3FF'  class='GroupExp'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td>");
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
                            $(".rows_" + index).children('td').get(2).innerHTML = pertotal;   //最後一組無法統計
                            pertotal = 0;
                            index = t;
                            strSex = $(own).children().get(0).innerText;
                            $(own).html("<td bgcolor='#D7E3FF'  class='GroupExp'></td><td bgcolor='#D7E3FF'></td><td bgcolor='#D7E3FF'></td>");
                            $(own).addClass("rows_" + index);
                            $(own).children('td').get(0).innerHTML = "<a   href='#' onclick=\"ShowDetail('rows_" + index + "_child','rows_" + index + "')\">" + strSex + "</a>";
                        }
                        else {
                            $(".rows_" + index).children('td').get(2).innerHTML = "" + pertotal;
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
    <div>
        <table width="500px" style="height: 250px" border="1" cellspacing="0" cellpadding="0"
            bordercolor="#000000" bordercolordark="#FFFFFF">
            <tr>
                <td bgcolor="#E5E5E5" colspan="2" height="60" 
                    style="font-size: 14px; font-weight: bold">
                    聯絡窗口
                </td>
            </tr>
            <tr>
                <td width="200px" valign="top">
                    華南&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    吳淞江檢測中心<br />
                    <br />
                    觀瀾&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    煙台&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    武漢&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    重慶&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    成都&nbsp;&nbsp;&nbsp; 檢測中心<br />
                    <br />
                    鄭州&nbsp;&nbsp;&nbsp; 檢測中心
                </td>
                <td valign="top">
                    王&nbsp;&nbsp;&nbsp; 宏:&nbsp;&nbsp;&nbsp;&nbsp; 560-69190<br />
                    <br />
                    化少杰:&nbsp;&nbsp;&nbsp;&nbsp;570-26761<br />
                    <br />
                    曹&nbsp;&nbsp;&nbsp; 威:&nbsp;&nbsp;&nbsp;&nbsp;568-82105<br />
                    <br />
                    孫愛霞:&nbsp;&nbsp;&nbsp;&nbsp;563-71217<br />
                    <br />
                    胡&nbsp;&nbsp;&nbsp; 文:&nbsp;&nbsp;&nbsp;&nbsp;567-22430<br />
                    <br />
                    王&nbsp;&nbsp;&nbsp; 俊:&nbsp;&nbsp;&nbsp;&nbsp;577-31346<br />
                    <br />
                    胡雨晴:&nbsp;&nbsp;&nbsp;&nbsp;573-31625<br />
                    <br />
                    許巧巧:&nbsp;&nbsp;&nbsp;&nbsp;579-74702<br />
                </td>
            </tr>
        </table>
    </div>
    <%--  <div>
           <uc1:UcWorkWaitFor ID="UcWorkWaitFor1" runat="server" />
    </div>--%>
    </form>
</body>
</html>
