<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>成都市水务局综合管理系统</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/login.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!--[if lt IE 8]>   
        <script type="text/javascript">  
            alert("您的系统IE版本太低，请升级到IE8！");
            location.href = '/Upload/IE8-WindowsXP-x86-CHS.exe';
        </script> 
    <![endif]-->
</head>
<body>
    <!--头部开始-->
    <header class="master">

    </header>
    <!--头部结束-->
        
    <!--内容开始-->
    <section class="container">
        <div class="forms pull-right">
            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <div id="alert" class="alert alert-danger" hidden="hidden"></div>
                    <label for="txt_uname" class="col-sm-2 control-label">账号</label>
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                        <input type="text" class="form-control" id="txt_uname" autofocus="autofocus" placeholder="请输入帐号..." maxlength="20">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txt_upwd" class="col-sm-2 control-label">密码</label>
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                        <input type="password" class="form-control" id="txt_upwd" placeholder="请输入密码..." maxlength="20">
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <div class="checkbox">
                            <label>
                                <input id="ck_rmbUser" type="checkbox">
                                记住密码
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button id="btn_submit" type="button" class="btn btn-primary btn-lg btn-block" disabled="disabled">登&emsp;录</button>
                    </div>
                </div>
            </form>
        </div>
    </section>
    <!--内容结束-->

    <!--底部开始-->
    <footer class="master">
        <br />
        <p class="text-center small">主办：成都市水务局&ensp;Copyright©1999-2013&nbsp;All&nbsp;Rights&nbsp;Reserved</p>
        <p class="text-center small">地址：成都市高新区蜀锦路68号&emsp;电话/传真：（028）61882800&ensp;61882811&emsp;邮编：610042</p>
    </footer>
    <!--底部结束-->

    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/cookie/jquery.cookie.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        /***页面加载***/
        $(function () {
            if (window != top) {
                top.location.href = location.href;//顶级页面
            }
            $("#btn_submit").html("登&emsp;录").removeAttr("disabled");//火狐刷新时无法启用此按钮，所以加载时调用
            $("#txt_uname").focus();
            if ($.cookie("rmbUser") == "true") {
                $("#ck_rmbUser").attr("checked", true);
                $("#txt_uname").val($.cookie("uname"));
                $("#txt_upwd").val($.cookie("pwd"));
            }

            /***回车登录***/
            $("#txt_uname,#txt_upwd,#ck_rmbUser").keydown(function (e) {
                var curKey = e.which;
                if (curKey == 13) {
                    if ($.cookie("uname") != null && $("#txt_uname").val() != $.cookie("uname")) {
                        $("#ck_rmbUser").attr("checked", false);//更换用户登录时，默认不保存密码
                    }
                    publicLogin();
                    return false; //防止自动提交submit导致bug
                }
            });

            /***登录按钮***/
            $("#btn_submit").click(function () {
                publicLogin();
            });
        })

        /***记住账号密码（cookie）***/
        function save() {
            if ($("#ck_rmbUser").is(":checked")) {
                var str_uname = $("#txt_uname").val();
                var str_pwd = $("#txt_upwd").val();
                $.cookie("rmbUser", "true", { expires: 1000 }); //存储一个带7天期限的cookie
                $.cookie("uname", str_uname, { expires: 1000 });
                $.cookie("pwd", str_pwd, { expires: 1000 });
            }
            else {
                $.cookie("rmbUser", "false", { expire: -1 });
                $.cookie("uname", "", { expires: -1 });
                $.cookie("pwd", "", { expires: -1 });
            }
        }

        /***登录***/
        function publicLogin() {
            /***账号密码同时不为空时，提交查询密码校验***/
            if ($("#txt_uname").val() && $("#txt_upwd").val() != "" && $("#btn_submit").attr("disabled") != "disabled") {
                $("#btn_submit").html("登录中......").attr("disabled", "disabled");//优化用户体验（修改按钮文字并禁用）
                $.ajax({
                    type: "post",
                    cache: false,
                    url: "/Ajax/Login.ashx",
                    data: "uname=" + $("#txt_uname").val() + "&upwd=" + $("#txt_upwd").val() + "",
                    success: function (msg) {
                        if (msg == "已登录") {
                            window.location.href = "MainBoard.aspx";
                        }
                        else {
                            var back = msg.split('|');
                            if (back[0] == "登录成功") {
                                save();//登录成功时记住密码
                                if (parseInt(back[1]) > 0) {
                                    window.location.href = "MainBoard.aspx";
                                } else {
                                    window.location.href = "EdayQuestion.aspx";
                                }
                            }
                            else {
                                $("#btn_submit").html("登&emsp;录");
                                window.setTimeout(function () {
                                    $("#btn_submit").removeAttr("disabled");//2秒后还原按钮文字并启用，防止恶意提交
                                }, 2000);
                                switch (msg) {
                                    case "您输入的密码有误":
                                        $("#txt_uname").attr("placeholder", "请输入帐号...").closest(".form-group").removeClass("has-error");//优化用户体验（还原加载样式）
                                        $("#txt_upwd").focus().closest(".form-group").addClass("has-error");//添加错误样式
                                        $(".alert").removeAttr("hidden").html(msg + "，<a href='#'>忘记密码</a>？");
                                        break;
                                    case "您输入的账号有误":
                                        $("#txt_upwd").attr("placeholder", "请输入密码...").closest(".form-group").removeClass("has-error");//优化用户体验（还原加载样式）
                                        $("#txt_uname").focus().closest(".form-group").addClass("has-error");//添加错误样式
                                        $(".alert").removeAttr("hidden").html(msg + "，<a href='#'>忘记账号</a>？");
                                        break;
                                }
                            }
                        }
                    }
                });
            }
                /***严格判断账号或密码输入有误***/
            else {
                /***账号和密码同时为空***/
                if ($("#txt_uname").val() == "" && $("#txt_upwd").val() == "") {
                    $("#txt_uname,#txt_upwd").closest(".form-group").addClass("has-error");//添加错误样式
                    $("#alert").removeAttr("hidden").html("请输入账号和密码");
                }
                /***账号为空***/
                if ($("#txt_uname").val() == "" && $("#txt_upwd").val() != "") {
                    $("#txt_upwd").closest(".form-group").removeClass("has-error");
                    $("#txt_uname").focus().closest(".form-group").addClass("has-error");//添加错误样式
                    $("#alert").removeAttr("hidden").html("请输入账号，<a href='#'>忘记账号</a>？");
                }
                /***密码为空***/
                if ($("#txt_upwd").val() == "" && $("#txt_uname").val() != "") {
                    $("#txt_uname").closest(".form-group").removeClass("has-error");
                    $("#txt_upwd").focus().closest(".form-group").addClass("has-error");//添加错误样式
                    $("#alert").removeAttr("hidden").html("请输入密码，<a href='#'>忘记密码</a>？");
                }
            }
        }
    </script>
</body>
</html>