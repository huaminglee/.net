<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainBoard.aspx.cs" Inherits="MainBoard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>成都市水务局综合管理系统</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 整体布局 -->
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
        /* 激活BootStrap提供的Glyphicons Halflings字体图标 */
        @font-face {
          font-family: 'Glyphicons Halflings';
          src: url('/bootstrap/3.2.0/fonts/glyphicons-halflings-regular.eot');
          src: url('/bootstrap/3.2.0/fonts/glyphicons-halflings-regular.eot?#iefix') format('embedded-opentype'),
		        url('/bootstrap/3.2.0/fonts/glyphicons-halflings-regular.woff') format('woff'),
		        url('/bootstrap/3.2.0/fonts/glyphicons-halflings-regular.ttf') format('truetype'),
		        url('/bootstrap/3.2.0/fonts/glyphicons-halflings-regular.svg#glyphicons-halflingsregular') format('svg');
        }
    </style>
</head>
<body>
    <!-- 头部开始 -->
    <header class="master">
        <table style="width:100%">
            <tr style="height:30px">
                <td></td>
            </tr>
            <tr style="width: 100%; padding-top: 33px; padding-right: 30px;">
                <td>
                    <!-- 搜索框 -->
                    <div id="smallMenu" class="btn-group pull-right" style="float:right; margin-right:15px">
                        <div class="input-group"  style="width:150px">
                            <input type="text" class="form-control" placeholder="公文查询" id="txt_query" style="opacity: 0.5;"/>
                            <span class="input-group-btn">
                                <a class="btn btn-default" id="btn_query" style="opacity: 0.5;"><span class="glyphicon glyphicon-search"></span></a>
                            </span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height:17px"></td>
            </tr>
            <tr>
                <td style="width: 100%; overflow:hidden; white-space:nowrap">
                    <!-- 主菜单 -->
                    <div id="mainMenu" class="btn-group" style="width: 1281px;padding-left: 60px; ">
                        <button type="button" class="btn btn-link" id="btn_index" onclick="MainAreaCh('/Index.aspx');">
                            <span class="glyphicon glyphicon-home">&ensp;首&ensp;页</span>
                        </button>
                        <button type="button" class="btn btn-link" id="btn_work" runat="server" onclick="MainAreaCh('/Archive/Default.aspx');">
                            <span class="label label-danger pull-right" id="tip_bggl"></span>
                            <span class="glyphicon glyphicon-briefcase">&ensp;办公管理</span>
                        </button>
                        <button type="button" class="btn btn-link" id="btn_admin" runat="server" onclick="MainAreaCh('/Admin/Default.aspx');">
                            <span class="label label-danger pull-right" id="tip_xzqlyx"></span>
                            <span class="glyphicon glyphicon-user">&ensp;行政权力运行</span>
                        </button>
                        <button type="button" class="btn btn-link" id="btn_education" runat="server" onclick="MainAreaCh('/IncorruptEdu/Default.aspx');">
                             <span class="label label-danger pull-right" id="tip_lzjy"></span>
                            <span class="glyphicon glyphicon-pencil">&ensp;廉政教育</span>
                        </button>
                        <button type="button" class="btn btn-link" id="Button1" runat="server" onclick="MainAreaCh('/Monitor/Default.aspx');">
                            <span class="label label-danger pull-right" id="tip_fxcz"></span>
                            <span class="glyphicon glyphicon-bullhorn">&ensp;后台监控</span>
                        </button>
                        <%--<button type="button" class="btn btn-link" id="btn_monitor" runat="server" onclick="MainAreaCh('/Monitor/Default.aspx');">
                            <span class="glyphicon glyphicon-eye-open">&ensp;风险预警</span>
                        </button>
                        <button type="button" class="btn btn-link" id="btn_risk" runat="server" onclick="MainAreaCh('/Risk/Default.aspx');">
                            <span class="label label-danger pull-right" id="tip_fxcz"></span>
                            <span class="glyphicon glyphicon-bullhorn">&ensp;风险处置</span>
                        </button>--%>
                        <button type="button" class="btn btn-link" id="btn_Ass" runat="server" onclick="MainAreaCh('/Risk/Index.aspx');">
                            <span class="glyphicon glyphicon-bell">&ensp;综合评估</span>
                        </button>
                        <button type="button" class="btn btn-link" id="btn_system" runat="server" onclick="MainAreaCh('/SysManege/Default.aspx');">
                            <span class="glyphicon glyphicon-cog">&ensp;系统管理</span>
                        </button>
                    </div>
                </td>
            </tr>
            <tr style="width: 100%;">
                <td colspan="2" >
                <div class="panel panel-default text-primary" style="height: 35px; line-height: 35px; background-color: #f4fbff; border-bottom: 1px #dae0e4 solid;">
                    
                    <div>

                        <button type='button' class='btn btn-link' data-toggle='modal' data-target='#exit' style="float:right; margin-right:15px">
                            <span class="glyphicon glyphicon-send">&ensp;安全退出</span>
                        </button>
                    </div>
                    <!-- 顶部新闻 -->
                     <div id='marqueeNews' class="pull-right" style="width: 400px; line-height: 25px;">
                        <ul class="list-unstyled">
                            <li></li>
                        </ul>
                    </div>
                    <!-- 顶部提醒 -->
                    <div id="remind"></div>
                </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                   
                </td>
                 
            </tr>
        </table>
    </header>
    <!-- 头部结束 -->

    <!-- 框架开始 -->
    <iframe id="mainWorkArea" name="mainWorkArea" src="/Index.aspx" style="width: 100%;border: 0px;" onload="javascript:dyniframesize('mainWorkArea');"></iframe>
    <!-- 框架结束 -->

    <!-- 收藏夹 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="favorites" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="favoritesLabel"><span class="glyphicon glyphicon-phone"></span><b>&ensp;收藏夹</b></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-3" style="height: 420px; overflow: auto;">
                            <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                            <ul id="tt_favorites" class="easyui-tree" data-options="animate:true,lines:true"></ul>
                        </div>
                        <div class="col-xs-9" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered table-condensed cursor" style="text-align: center;">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center;">序号</th>
                                            <th style="text-align: center;">公文名称</th>
                                            <th style="text-align: center;">创建时间</th>
                                            <th style="text-align: center;">办理状态</th>
                                            <th style="text-align: center;">创建人</th>
                                            <th style="text-align: center;">管理</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_favorites">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 通讯录 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="contact" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="contactLabel"><span class="glyphicon glyphicon-phone"></span><b>&ensp;通讯录</b></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-4" style="height: 420px; overflow: auto;">
                            <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                            <ul id="tt_contact" class="easyui-tree" data-options="animate:true,lines:true"></ul>
                        </div>
                        <div class="col-xs-8" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered table-condensed" style="text-align: center;">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center;">姓名</th>
                                            <th style="text-align: center;">部门</th>
                                            <th style="text-align: center;">电话</th>
                                            <th style="text-align: center;">手机</th>
                                            <th style="text-align: center;">邮箱</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_contact">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 安全退出 模态窗口 -->
    <div class="modal fade bs-example-modal-sm" id="exit" tabindex="-1" role="dialog" aria-labelledby="exitLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="exitLabel"><span class="glyphicon glyphicon-exclamation-sign"></span><b>&ensp;提示</b></h5>
                </div>
                <div class="modal-body">
                    <h5 id="h5_info" class="text-danger text-center"><b>确定要退出吗？</b></h5>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">取&ensp;消</button>
                    <button id="btn_exit_yes" type="button" class="btn btn-danger btn-sm">确&ensp;定</button>
                </div>
            </div>
        </div>
    </div>
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!-- 最新 EasyUI 核心 JavaScript 文件 -->
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/vticker/jquery.vticker.min.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, strTable = "", timer = "", tipCount = 0, $marqueeNews = $("#marqueeNews"), $btnMenu = $("#mainMenu > button"),
            $tip_bggl = $("#tip_bggl"), $tip_xzqlyx = $("#tip_xzqlyx"), $tip_fxcz = $("#tip_fxcz"), $tip_lzjy = $("#tip_lzjy");
        $(function () {
            /***顶部提醒闪烁效果（需配合refreshTop()函数一起使用）***/
            setInterval(function () { $tip_bggl.text() == "" ? $tip_bggl.stop() : $tip_bggl.fadeOut(800).fadeIn(800) }, 800);
            setInterval(function () { $tip_xzqlyx.text() == "" ? $tip_xzqlyx.stop() : $tip_xzqlyx.fadeOut(800).fadeIn(800) }, 800);
            setInterval(function () { $tip_fxcz.text() == "" ? $tip_fxcz.stop() : $tip_fxcz.fadeOut(800).fadeIn(800) }, 800);
            setInterval(function () { $tip_lzjy.text() == "" ? $tip_lzjy.stop() : $tip_lzjy.fadeOut(800).fadeIn(800) }, 800);

            /***滚动新闻***/
            $.get("/Ajax/GetRollNews.ashx",
              function (data) {
                  $marqueeNews.children("ul").html(data);
                  $marqueeNews.vTicker({
                      showItems: 1,
                      padding: 5
                  });
              });

            /***顶部提醒***/
            refreshTop();//初次加载

            /***主菜单样式***/
            $btnMenu.attr("style", "color: white; font-size: 1.2em; font-family: 'Microsoft YaHei','Glyphicons Halflings'; text-decoration: blink;");
            $btnMenu.children("span").attr("style", "font-family: 'Microsoft YaHei','Glyphicons Halflings';");
            $("#btn_index").attr("style", "border-top-left-radius: 4px; border-top-right-radius: 4px; font-size: 1.2em; font-family: 'Microsoft YaHei','Glyphicons Halflings'; background-color:#f4fbff; text-decoration: blink;");

            /***主导航样式控制***/
            $btnMenu.click(function () {
                $btnMenu.attr("style", "color: white; font-size: 1.2em; font-family: 'Microsoft YaHei','Glyphicons Halflings'; text-decoration: blink;");
                $(this).attr("style", "border-top-left-radius: 4px; border-top-right-radius: 4px; font-size: 1.2em; font-family: 'Microsoft YaHei','Glyphicons Halflings'; background-color:#f4fbff; text-decoration: blink;");
            });

            /***公文查询***/
            $("#btn_query").click(function () {
                    window.open("/Archive/DocumentQuery.aspx?txt_query=" + encodeURI($.trim($("#txt_query").val())) + "", "mainWorkArea");//mainWorkArea为iframe的ID
            });

            /***公文查询（回车执行）***/
            $("#txt_query").keydown(function (e) {
                var curKey = e.which;
                if (curKey == 13 && $.trim($("#txt_query").val()) != "") {
                    window.open("/Archive/DocumentQuery.aspx?txt_query=" + encodeURI($.trim($("#txt_query").val())) + "", "mainWorkArea");//mainWorkArea为iframe的ID
                    return false; //防止自动提交submit导致bug
                }
            });

            /***收藏夹***/
            $("#favorites").on("show.bs.modal", function (e) {
                $("#tb_favorites").html("");
                $("#tt_favorites").tree({
                    onClick: function (node) {
                        $.get("/Ajax/PublicQuery.ashx", {
                            pageState: "favorites",
                            archiveType:  node.id
                        },
                          function (data) {
                              if (data != "null") {
                                  obj = $.parseJSON(data);
                                  $.each(obj, function (i) {
                                      strTable += "<tr><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].create_time + "</td><td>" + obj[i].current_state + "</td><td>" + obj[i].creator + "</td><td><span class='glyphicon glyphicon-remove text-danger' onclick='btnDelete(" + obj[i].favorite_id + ");'></span></td></tr>";
                                  });
                                  $("#tb_favorites").html(strTable);
                                  strTable = "";
                              }
                              else {
                                  $("#tb_favorites").html(strTable);
                              }
                          });
                    },
                    method: "get",
                    url: "/Ajax/PublicQuery.ashx?pageState=archiveType"
                });
            });

            /***通讯录***/
            $("#contact").on("show.bs.modal", function (e) {
                $("#tt_contact").tree({
                    onClick: function (node) {
                        $.get("/Ajax/PublicQuery.ashx", {
                            pageState: "contact",
                            id: node.id,
                            status: node.status
                        },
                          function (data) {
                              if (data != "null") {
                                  obj = $.parseJSON(data);
                                  //点击部门，"部门"列显示当前节点名称
                                  if (node.status == "department") {
                                      $.each(obj, function (i) {
                                          strTable += "<tr><td>" + obj[i]._full_name + "</td><td>" + node.text + "</td><td>" + obj[i]._phone + "</td><td>" + obj[i]._mobile + "</td><td>" + obj[i]._e_maile + "</td></tr>";
                                      });
                                      $("#tb_contact").html(strTable);
                                      strTable = "";
                                  }
                                      //点击人员，"部门"列显示父节点名称
                                  else {
                                      strTable += "<tr><td>" + obj._full_name + "</td><td>" + $("#tt_contact").tree("getParent", node.target).text + "</td><td>" + obj._phone + "</td><td>" + obj._mobile + "</td><td>" + obj._e_maile + "</td></tr>";
                                      $("#tb_contact").html(strTable);
                                      strTable = "";
                                  }
                              }
                              else {
                                  $("#tb_contact").html(strTable);
                              }
                          });
                    },
                    method: "get",
                    url: "/Ajax/PublicQuery.ashx?pageState=gwry"
                });
            });

            /***安全退出***/
            $("#btn_exit_yes").click(function () {
                $.get("/Ajax/PublicQuery.ashx", { pageState: "exit" },
                  function (data) {
                      $("#exit").modal("hide");
                      window.location.replace("/Login.aspx");//replace();替换页面，不可返回上一个页面
                      //window.open("/Login.aspx", "_top");
                  });
            });
            //$("#exit").on("hidden.bs.modal", function (e) {
            //    alert($(e.relatedTarget).val());
            //    window.location.replace("Login.aspx");//replace();替换页面，不可返回上一个页面
            //});
        });

        //改变iframe页面的高度,不然加载高于css设定的600px的页面ff等浏览器会超出隐藏. ajax加载的超过高度要提前设定iframe内容的高度.
        function autoHeight(obj) {
            $(obj).height($(obj).contents().height() + 20);
        }
        var tipchange = 0;
        /***顶部提醒***/
        function refreshTop() {
            timer != "" ? clearTimeout(timer) : null;//卸载当前定时刷新，避免多个定时刷新同时运行
            $.get("/Ajax/PublicQuery.ashx", { pageState: "remind" })
            .done(function (data) {
                var curtipchange = 0;
                $("#remind").html(data);//加载提醒内容
                tipCount = 0;//初始化闪烁图标的值
                /***办公管理***/
                $("#rcgw > a").text() == "" ? null : tipCount += parseInt($("#rcgw > a").text());//日常公文
                $("#dbgz > a").text() == "" ? null : tipCount += parseInt($("#dbgz > a").text());//督办工作
                $("#ggxx > a").text() == "" ? null : tipCount += parseInt($("#ggxx > a").text());//公告消息
                $("#hytz > a").text() == "" ? null : tipCount += parseInt($("#hytz > a").text());//会议通知
                tipCount == 0 ? $tip_bggl.text("") : $tip_bggl.text(tipCount);
                curtipchange = curtipchange + tipCount;
                tipCount = 0;//初始化闪烁图标的值
                /***行政权力运行***/
                $("#rsrm > a").text() == "" ? null : tipCount += parseInt($("#rsrm > a").text());//人事任免
                $("#swgcxm > a").text() == "" ? null : tipCount += parseInt($("#swgcxm > a").text());//水务工程项目
                $("#xzsp > a").text() == "" ? null : tipCount += parseInt($("#xzsp > a").text());//行政审批、技术审查
                tipCount == 0 ? $tip_xzqlyx.text("") : $tip_xzqlyx.text(tipCount);
                curtipchange = curtipchange + tipCount;
                tipCount = 0;//初始化闪烁图标的值
                /***风险处置***/
                $("#fxczd > a").text() == "" ? null : tipCount += parseInt($("#fxczd > a").text());//风险处置单
                $("#cqfxczd > a").text() == "" ? null : tipCount += parseInt($("#cqfxczd > a").text());//风险处置单
                tipCount == 0 ? $tip_fxcz.text("") : $tip_fxcz.text(tipCount);
                curtipchange = curtipchange + tipCount;
                tipCount = 0;//初始化闪烁图标的值
                //廉政教育
                $("#jyrw > a").text() == "" ? null : tipCount += parseInt($("#jyrw > a").text());//教育任务
                $("#zxks > a").text() == "" ? null : tipCount += parseInt($("#zxks > a").text());//在线考试
                tipCount == 0 ? $tip_lzjy.text("") : $tip_lzjy.text(tipCount);
                curtipchange = curtipchange + tipCount;
                tipCount = 0;

                //if (tipchange != 0 ) {
                //    this.focus();
                //    this.blur();
                //    document.title = "成都市水务局综合管理系统" + curtipchange;
                //}
                tipchange = curtipchange;
            });
            timer = window.setTimeout(refreshTop, 30000);//30秒定时刷新，并设定刷新ID，卸载刷新时使用
        }

        /***弹出iFrame查看详细***/
        function showDetail(archive_id, archive_type) {
            var src;
            /***“三重一大”***/
            switch (archive_type) {
                case 10:
                    src = "/Archive/sel_Generalpieces.aspx?arid=" + archive_id + "";
                    break;
                case 11:
                    src = "/Archive/sel_Ordinarypieces.aspx?arid=" + archive_id + "";
                    break;
                case 12:
                    src = "/Archive/sel_UnitDoc.aspx?arid=" + archive_id + "";
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
            }
            $.layer({
                type: 2,
                title: "收藏夹",
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '500px'],
                offset: ['100px', ''],
                iframe: { src: src }
            });
        }

        /***删除收藏夹***/
        function mbtnDelete(favorite_id) {
            $.get("/Ajax/PublicSave.ashx", {
                pageState: "scjDel",
                favorite_id: favorite_id
            },
              function (data) {
                  $("#favorites").modal("hide");
              });
        }

        /***标签跳转***/
        function MainAreaCh(Url) {
            $(document).find("#mainWorkArea").attr("src", Url);
        }

        function doViewNews(id) {
            $.layer({
                type: 2,
                title: '查看新闻',
                iframe: { src: '/Admin/RollNewsDetail.aspx?news_id=' + id },
                maxmin: true,
                area: ['985px', '585px'],
                border: [1, 0.2, '#000', true],
                offset: ['20px', '']
            });
        }

        /***弹出iframe的关闭空方法***/
        function doRefresh() { }
        function dyniframesize(down) {
            var pTar = null;
            if (document.getElementById) {
                pTar = document.getElementById(down);
            }
            else {
                eval('pTar = ' + down + ';');
            }
            if (pTar && !window.opera) {
                //begin resizing iframe 
                pTar.style.display = "block"
                if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) {
                    //ns6 syntax 
                    if (pTar.contentDocument.body.offsetHeight < 600) {
                        pTar.height = 600;
                    } else {
                        pTar.height = pTar.contentDocument.body.offsetHeight;
                    }
                   
                    pTar.width = pTar.contentDocument.body.scrollWidth ;
                }
                else if (pTar.Document && pTar.Document.body.scrollHeight) {
                    //ie5+ syntax 
                    if (pTar.contentDocument.body.offsetHeight < 600) {
                        pTar.height = 600;
                    } else {
                        pTar.height = pTar.Document.body.scrollHeight;
                    }
                    
                    pTar.width = pTar.Document.body.scrollWidth;
                }
            }
        }
    </script>
</body>
</html>