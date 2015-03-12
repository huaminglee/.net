<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDutyResponsibility.aspx.cs" Inherits="SysManege_AddDutyResponsibility" %>
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
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
        <script src="/Script/html5shiv/3.7.0/html5shiv.js"></script>
    <![endif]-->
</head>
<body style="background-color:#f7f9f9;">
    <section class="container" style="width: 43%;">
        <fieldset>
            <legend>添加岗位职责</legend>
            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="company" class="col-sm-2 control-label">所在单位</label>
                    <div class="col-sm-10" style="white-space:nowrap;">
                        <select id="company" class="form-control">
                        </select>
                        <span style="color:red;">*</span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txt_riskName" class="col-sm-2 control-label">岗位名称</label>
                    <div class="col-sm-10" style="white-space:nowrap;">
                        <input id="txt_riskName" type="text" class="form-control" maxlength="30">
                        <span style="color:red;">*</span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txt_gwzz" class="col-sm-2 control-label">岗位职责</label>
                    <div class="col-sm-10" style="white-space:nowrap;">
                        <textarea id="txt_gwzz" class="form-control" rows="5" maxlength="2000"></textarea>
                        <span style="color:red;">*</span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txt_gwry" class="col-sm-2 control-label">岗位人员</label>
                    <div class="col-sm-10" style="white-space:nowrap;">
                        <input id="txt_gwry" type="text" class="form-control">
                        <span style="color:red;">*</span>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-7 pull-right">
                        <button id="btn_save" type="button" class="btn btn-primary">保&ensp;存</button>&emsp;&emsp;
                        <button id="btn_back" type="button" class="btn btn-primary">返&ensp;回</button>
                    </div>
                </div>
                <input id="h_val" type="hidden" />
            </form>
        </fieldset>
    </section>
    <!-- 模态窗口 -->
    <div class="modal fade bs-example-modal-sm" id="confirm" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="confirmLabel"><span class="glyphicon glyphicon-exclamation-sign"></span><b>&ensp;提示</b></h5>
                </div>
                <div class="modal-body">
                    <h5 id="h5_info" class="text-center"><b></b></h5>
                </div>
            </div>
        </div>
    </div>
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, strHtml = "", $company = $("#company");
        $(function () {
            /***加载所在单位***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "company" },
              function (data) {
                  obj = $.parseJSON(data);
                  $.each(obj, function (i) {
                      //组织字符串效率高于遍历append
                      strHtml += "<option value='" + obj[i].department_id + "'>├" + obj[i].department_name + "</option>";
                  });
                  $company.html(strHtml).children("option:eq(0)").text(obj[0].department_name);//去除第一个"├"
                  $company.children("option:last").text("└" + obj[obj.length - 1].department_name);//将最后一个"├"替换为"└"
              });

            /***岗位人员***/
            $("#txt_gwry").focus(function () {
                $(this).val("").attr("disabled", "disabled");
                $.layer({
                    type: 2,
                    title: '添加岗位人员',
                    maxmin: true,
                    //shadeClose: true, //开启点击遮罩关闭层
                    shade: [0], //不显示遮罩
                    area: ['700px', '460px'],
                    offset: ['50px', ''],
                    iframe: { src: 'AddRiskPerson.aspx' },
                    close: function (index) {
                        $("#txt_gwry").val("").removeAttr("disabled");
                    }
                });
            });

            /***保存***/
            $("#btn_save").click(function () {
                if ($.trim($("#txt_riskName").val()) != "" && $.trim($("#txt_gwzz").val()) != "" && $.trim($("#h_val").val()) != "") {
                    var cVal = $("#company").find("option:selected").val();//获取下拉框选中的值
                    $.post("/Ajax/PublicSave.ashx",
                        {
                            pageState: "gwzz",
                            company: cVal,
                            txt_riskName: $("#txt_riskName").val(),
                            txt_gwzz: $("#txt_gwzz").val(),
                            h_val: $("#h_val").val()
                        },
                       function (data) {
                           $("#h5_info").addClass("text-success").removeClass("text-danger").children().text(data);
                           $("#confirm").modal();
                       });
                }
                else {
                    $("#h5_info").addClass("text-danger").removeClass("text-success").children().text("请输入信息！");
                    $("#confirm").modal();
                }
            });

            /***返回***/
            $("#btn_back").click(function () {
                window.location.href = "DutyResponsibility.aspx";
            });

            /***弹出模态窗口之后***/
            $("#confirm").on("shown.bs.modal", function (e) {
                window.setTimeout(function () {
                    $("#confirm").modal("hide");
                }, 2000);
            });

            /***关闭模态窗口之后***/
            $("#confirm").on("hidden.bs.modal", function (e) {
                $("#txt_riskName,#txt_gwzz,#txt_gwry,#h_val").val(null);
            });
        });
    </script>
</body>
</html>
