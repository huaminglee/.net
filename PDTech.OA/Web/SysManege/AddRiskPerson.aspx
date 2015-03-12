<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRiskPerson.aspx.cs" Inherits="SysManege_AddRiskPerson" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>添加岗位职责</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
        <script src="/Script/html5shiv/3.7.0/html5shiv.js"></script>
    <![endif]-->
</head>
<body>
    <label id="h_val" style="display:none;"></label>
    <section class="container">
        <!--人员列表-->
        <div class="row">
            <div class="col-xs-6">
                <fieldset>
                    <legend>人员列表</legend>
                    <div class="input-group">
                        <input id="txt_name" type="text" class="form-control" placeholder="请输入姓名...">
                        <span class="input-group-btn">
                            <button id="btn_query" class="btn btn-default" type="button"><span class="glyphicon glyphicon-search"></span></button>
                        </span>
                    </div>
                    <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                    <div class="easyui-panel" style="height: 270px; margin-top: 3%;">
                        <ul id="tt" class="easyui-tree" data-options="animate:true,checkbox:true,cascadeCheck:false,lines:true,onlyLeafCheck:true">
                        </ul>
                    </div>
                </fieldset>
            </div>
            <!--已选人员-->
            <div class="col-xs-6">
                <fieldset>
                    <legend>已选人员</legend>
                    <div id="yxry"></div>
                </fieldset>
            </div>
        </div>
        <button id="btn_save" type="button" class="btn btn-primary pull-right">保&ensp;存</button>
    </section>
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!-- 最新 EasyUI 核心 JavaScript 文件 -->
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        //获取当前窗口索引以便执行layer.close方法（"window.name"是固定写法，不是某个控件的ID，官方demo有错误）
        var index = parent.layer.getFrameIndex(window.name);
        var valArr = [], returnVal = [];
        var val, nodes;
        $(function () {
            $("#tt").tree({
                onCheck: function (node, checked) {
                    nodes = $("#tt").tree("getChecked");//获取选中值
                    val = "";//如果不赋值空，则会变成"undefined"
                    $("#yxry a").remove();//清空已选人员
                    /***拼接分配人员数据，此处获取属性值时，需比较实体类PersonTree中获取***/
                    $.each(nodes, function (i, n) {
                        /***当前模块只需要人员数据，所以过滤部门数据***/
                        if (nodes[i].status == "person") {
                            val += nodes[i].text + "," + nodes[i].id + ";";
                            /***进行分配***/
                            $("#yxry").append("<a class='btn btn-default btn-block'>" + nodes[i].text + "<button id='" + nodes[i].id + "' name='" + nodes[i].status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        }
                    });
                    valArr = val.substr(0, val.length - 1).split(";");//将所有checked数据拆分为数组
                    returnVal = [];
                    /***取出已选人员的姓名***/
                    $.each(valArr, function (i, n) {
                        returnVal.push(valArr[i].split(",", 1));//存入数组
                    });
                    window.parent.document.getElementById("txt_gwry").value = returnVal.join(",");//赋值给父窗体的文本框（仅用于现实）
                    window.parent.document.getElementById("h_val").value = val;//赋值给父窗体的隐藏控件（用于父窗体的保存）
                },
                method: 'get',
                url: "/Ajax/PublicQuery.ashx?pageState=gwry&txt_name=" + $.trim($("#txt_name").val()) + ""
            });
            
            /***保存***/
            $("#btn_save").click(function () {
                window.parent.document.getElementById("txt_gwry").disabled = "";//启用父窗体控件
                parent.layer.close(index);//关闭弹出的iframe
            });

            /***查询***/
            $("#btn_query").click(function () {
                $("#tt").tree({
                    method: 'get',
                    url: "/Ajax/PublicQuery.ashx?pageState=gwry&txt_name=" + encodeURI($("#txt_name").val()) + ""//中文参数需编码后传递（后台不用解码）
                });
            });
        })

        /***每个已选人员的关闭***/
        function mbtnClose(btn) {
            /***nodes为当前已选人员***/
            $.each(nodes, function (i, n) {
                /***匹配所有已选人员是否为点击删除的已选人员***/
                if (nodes[i].id == $(btn).attr("id")) {
                    /***匹配成功，取消选择***/
                    $("#tt").tree("update", {
                        target: nodes[i].target,
                        checked: false
                    });
                }
            });
        }
    </script>
</body>
</html>