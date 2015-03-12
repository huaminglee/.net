<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEduTask.aspx.cs" Inherits="IncorruptEdu_ViewEduTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>查看详细</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" type="text/css" href="/CSS/public.css?t=" <%=t_rand %> />
    <link rel="stylesheet" type="text/css" href="/CSS/detail.css?t=" <%=t_rand %> />
    <style type="text/css">
        .let2 {
            letter-spacing: 2px;
        }

        .let6 {
            letter-spacing: 6px;
        }

        p {
            text-indent: 2em;
        }

        .pervideo{
            color:white;
            font-size:16px;
            background-color:green;
            margin-right:10px;
        }
    </style>
    <script type="text/javascript" src="/jquery/1.8.3/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Script/layer/layer.min.js"></script>
    <script type="text/javascript" src="jwplayer.js"></script>
    
</head>
<body>
    <form id="mForm" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <div class="main">
            <div class="content">
                <div class="con_h">
                    <asp:Label runat="server" ID="lbTopTitle" Text="成都市水务局教育任务"></asp:Label>
                </div>
                <div class="con_b">
                    <table class="main_msgList" cellspacing="1" cellpadding="1" style="text-align: center" border="0">
                        <tr>
                            <td style="text-align: right;"><span>任务标题</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbTitle"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>任务类型</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbType"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>创建人</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbCreator"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>创建时间</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbCreatTime"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">完成时限</td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p><asp:Label ID="lbhopefinishtime" runat="server" Text=""></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>来文单位</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbCompany"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>接收人</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <asp:Label runat="server" ID="lbReceiver"></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"><span>备注</span></td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                    <%--<asp:TextBox runat="server" ID="txtRemark" Width="100%" ReadOnly="true" Style="resize: none;" TextMode="MultiLine" Height="120px" MaxLength="1000"></asp:TextBox>--%>
                                    <asp:Label runat="server" ID="txtRemark"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr id="dtvideo">
                            <td style="text-align: right;">视频</td>
                            <td class="con_item_left" style="width: 650px; text-align: left;">
                                <p>
                                <asp:Label ID="lbvideos" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hidvideos" runat="server" />
                                     </p>
                                <div id="myElement"></div>
                                   
                               
                            </td>
                        </tr>
                        <tr runat="server" id="tr_showList" visible="false">
                            <td style="text-align: right;"></td>
                            <td class="con_item" style="padding-left: 30px;">
                                <table class="GridTitleCss" style="width: 100%;">
                                    <tr>
                                        <th style="width: 40%;">附件名称</th>
                                        <th style="width: 20%;">上传人员</th>
                                        <th style="width: 20%;">上传时间</th>
                                        <th style="width: 20%;" colspan="1">操作</th>
                                    </tr>
                                    <asp:Repeater ID="rpt_AttachmentList" runat="server" OnItemDataBound="rpt_AttachmentList_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="../images/attachlogo.jpg" /><%# Eval("FILE_NAME") %></td>
                                                <td>
                                                    <%# Eval("FULL_NAME") %>
                                                </td>
                                                <td>
                                                    <%# AidHelp.ShortTime(Eval("CREATE_TIME")) %>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPath" runat="server" Visible="false" Text='<%# Eval("FILE_PATH") %>'></asp:Label>
                                                    <asp:HyperLink runat="server" ID="hlDown" ForeColor="#215493" Font-Underline="false" Text="下载"></asp:HyperLink></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                    
                </div>
                <div class="con_oper">
                    <input type="button" id="btnReturn" class="btn_back con_oper_btn let6" value="关闭" onclick="window.parent.layer.closeAll();" />
                </div>
            </div>
        </div>
        <div style="display:none">
            <asp:Button ID="btnfinishvideo" runat="server" Text="" OnClick="btnfinishvideo_Click" />
            <asp:HiddenField ID="hidvideoscount" Value="0" runat="server" />
            <asp:HiddenField ID="hidwatchvideoscount" Value="0" runat="server" />
            <asp:HiddenField ID="hideuid" runat="server" />
        </div>
        <script>
            $(function () {
                jwplayer.key = "743RsJZT/QeapgAr1cIWL8WMzikXSxnm+mvjmQ==";
                initlbvideo();
            });
            function initlbvideo() {
                if ($("#hidvideos").val() != "0") {
                    $("#dtvideo").show();
                    var videos = $("#hidvideos").val();
                    var ss = videos.split(";");
                    $("#hidvideoscount").val(ss.length);
                    for (var i = 0; i < ss.length; i++) {
                        $("#lbvideos").append('<a class="pervideo" onclick="palyvideo(\'' + ss[i] + '\')">' + ss[i] + "</a>")
                    }

                }
                else {
                    $("#dtvideo").hide();
                }

            }
            function palyvideo(videoname) {
                var videosrc = "../database/Videos/Custom/" + videoname;
                jwplayer("myElement").setup({
                    file: videosrc,
                    events: {
                        onComplete: function () {
                             
                            $("#hidwatchvideoscount").val(parseInt($("#hidwatchvideoscount").val()) + 1);
                            if (parseInt($("#hidwatchvideoscount").val()) == $("#hidvideoscount").val()) {
                                $("#btnfinishvideo").click();
                            }
                           
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
