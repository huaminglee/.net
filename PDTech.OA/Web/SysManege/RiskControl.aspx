<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiskControl.aspx.cs" Inherits="SysManege_RiskControl" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>风险防控</title>
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
        <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <section class="container">
        <div class="container-fluid">
            <fieldset>
                <legend><small class="text-primary">风险防控</small></legend>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="riskType" class="input-group-addon">风险模块类型</label>
                            <select class="easyui-combobox" id="riskType" style="width:150px;height:35px;" data-options="panelHeight:'auto'">
                                <option value="0">---请选择---</option>
                                <option value="OA_WORKFLOW_STEP">日常办公公文</option>
                                <option value="SW_PROJECT_STEP">水务项目</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="riskModule" class="input-group-addon">风险模块</label>
                            <select class="easyui-combobox" id="riskModule" style="width:150px;height:35px;" data-options="panelHeight:'auto'">
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="riskStep" class="input-group-addon">风险步骤</label>
                            <select class="easyui-combobox" id="riskStep" style="width:150px;height:35px;" data-options="panelHeight:'auto'">
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-1">
                        <button type="button" class="btn btn-primary" id="btn_query">查&ensp;询</button>
                    </div>
                    <div class="col-sm-1">
                        <button type="button" class="btn btn-primary" id="btn_add">添&ensp;加</button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-condensed table-bordered cursor">
                                <thead>
                                    <tr>
                                        <th>序号</th>
                                        <th>风险类型</th>
                                        <th>风险等级</th>
                                        <th>风险点</th>
                                        <th>防范措施</th>
                                        <th>管理</th>
                                    </tr>
                                </thead>
                                <tbody id="tb_risk"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- 分页 -->
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <div id="pagination" class="easyui-pagination" data-options="
                            total:0,
                            pageSize:10,
                            layout:['first','prev','sep','links','sep','next','last','manual'],
                            beforePageText:'转到',
                            afterPageText:'页',
                            displayMsg:' 共 {total} 条记录，当前显示 {from} 到 {to}条'
                            "></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </section>
    <!-- 个人信息 模态窗口 -->
    <div class="modal fade" id="risk" tabindex="-1" role="dialog" aria-labelledby="uInfoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="riskLabel"><span class="glyphicon glyphicon-eye-open"></span><b>&ensp;风险防控</b></h5>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="txt_riskPoint" class="col-sm-2 control-label">风险点</label>
                            <div class="col-sm-10">
                                <textarea id="txt_riskPoint" class="form-control" rows="3" maxlength="250"></textarea><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_riskResolve" class="col-sm-2 control-label">防范措施</label>
                            <div class="col-sm-10">
                                <textarea id="txt_riskResolve" class="form-control" rows="3" maxlength="250"></textarea><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_remark" class="col-sm-2 control-label">备注</label>
                            <div class="col-sm-10">
                                <textarea id="txt_remark" class="form-control" rows="3" maxlength="250"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">风险等级</label>
                            <div class="col-sm-10">
                                <div class="radio">
                                    <select id="riskLevel" class="easyui-combobox" style="width:150px;height:35px;" data-options="panelHeight:'auto'">
                                        <option value="1" selected>一级</option>
                                        <option value="2">二级</option>
                                        <option value="3">三级</option>
                                    </select>
                                </div>
                            </div>
                            <input type="hidden" id="h_id" />
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">取&ensp;消</button>
                    <button id="btn_risk_save" type="button" class="btn btn-danger btn-sm">保&ensp;存</button>
                </div>
            </div>
        </div>
    </div>
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
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, objIndex, strOption = "", strTable = "", state = "", pageSize = 10, currentPage = 1, totalNum,
            $riskType = $('#riskType'), $riskModule = $('#riskModule'), $riskStep = $('#riskStep');
        $(function () {
            /***风险模块类型***/
            $riskType.combobox({
                onChange: function () {
                    $('#riskModule').combobox('clear');
                    $('#riskStep').combobox('clear');
                    if ($riskType.combobox('getValue') == "OA_WORKFLOW_STEP") {
                        /***加载风险模块--日常办公公文***/
                        $('#riskModule').combobox({
                            url: '/Ajax/PublicQuery.ashx?pageState=riskModule',
                            valueField: 'flow_template_id',
                            textField: 'flow_template_name',
                            onSelect: function () {
                                if ($riskType.combobox('getValue') == "OA_WORKFLOW_STEP" && $riskModule.combobox('getValue') != '0') {
                                    $('#riskStep').combobox({
                                        url: '/Ajax/PublicQuery.ashx?pageState=riskStep&flow_template_id=' + $("#riskModule").combobox('getValue'),
                                        valueField: 'step_id',
                                        textField: 'step_name'
                                    });
                                    $('#riskStep').combobox('setValue', '0');
                                } else if ($riskModule.combobox('getValue') == '0') {
                                    $('#riskStep').combobox('clear');
                                }
                            }
                        });
                    }
                    /***加载风险模块--水务项目***/
                    else if ($('#riskType').combobox('getValue') == "SW_PROJECT_STEP") {
                        $('#riskModule').combobox({
                            url: '/Ajax/PublicQuery.ashx?pageState=riskModule2',
                            valueField: 'flow_template_id',
                            textField: 'flow_template_name',
                            onSelect: function () {
                                if ($riskType.combobox('getValue') == "SW_PROJECT_STEP" && $riskModule.combobox('getValue') != '0') {
                                    $('#riskStep').combobox({
                                        url: '/Ajax/PublicQuery.ashx?pageState=projectStep&project_type=' + $('#riskModule').combobox('getValue'),
                                        valueField: 'step_id',
                                        textField: 'step_name'
                                    });
                                    $('#riskStep').combobox('setValue', '0');
                                } else if ($riskModule.combobox('getValue') == '0') {
                                    $('#riskStep').combobox('clear');
                                }
                            }
                        });
                    }
                    else {
                        $('#riskModule').combobox('clear');
                        $('#riskStep').combobox('clear');
                    }
                    $('#riskModule').combobox('setValue', '0');
                }
            });

            $.get("/Ajax/PublicQuery.ashx", {
                pageState: "riskControl",
                pageSize: pageSize
            },
                     function (data) {
                         objTemp = $.parseJSON(data);//转换出总条数
                         totalNum = objTemp.TotalNum;//总条数
                         if (totalNum > 0) {
                             obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                             $.each(obj, function (i) {
                                 strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].level_name + "</td><td title='" + obj[i].risk_point + "'>" + obj[i].risk_point.substring(0, 15) + "</td><td title='" + obj[i].risk_resolve + "'>" + obj[i].risk_resolve.substring(0, 20) + "</td><td><span class='glyphicon glyphicon-cog' id='" + obj[i].rowno + "' onclick='editRisk(this);'></span></td></tr>";
                             });
                             $("#tb_risk").html(strTable);
                             strTable = "";
                             pagination();//分页
                         }
                         else {
                             $("#tb_risk").html(strTable);//清空值
                         }
                     });

            /***查询***/
            $("#btn_query").click(function () {
                if ($("#riskType").combobox('getValue') == '0') {
                    $("#h5_info").addClass("text-danger").removeClass("text-success").children().text("请先选择风险模块类型！");
                    $("#confirm").modal("show");//弹出添加窗口
                } else {
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "riskControl",
                        riskType: $("#riskType").combobox('getValue'),    //$riskType.find("option:selected").val(),
                        riskModule: $("#riskModule").combobox('getValue'),    //$riskModule.find("option:selected").val(),
                        riskStep: $("#riskStep").combobox('getValue'),    //$riskStep.find("option:selected").val(),
                        pageSize: pageSize
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          if (totalNum > 0) {
                              obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                              $.each(obj, function (i) {
                                  strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].level_name + "</td><td title='" + obj[i].risk_point + "'>" + obj[i].risk_point.substring(0, 15) + "</td><td title='" + obj[i].risk_resolve + "'>" + obj[i].risk_resolve.substring(0, 20) + "</td><td><span class='glyphicon glyphicon-cog' id='" + obj[i].rowno + "' onclick='editRisk(this);'></span></td></tr>";
                              });
                              $("#tb_risk").html(strTable);
                              strTable = "";
                              pagination();//分页
                          }
                          else {
                              $("#tb_risk").html(strTable);//清空值
                          }
                      });
                }
            });

            /***添加***/
            $("#btn_add").click(function () {
                state = "add";//修改为“添加”状态（为区分添加和更新）
                if ($("#riskType").combobox('getValue') != "0" && $("#riskType").combobox('getValue') != null &&
                    $("#riskModule").combobox('getValue') != "0" && $("#riskModule").combobox('getValue') != null &&
                    $("#riskStep").combobox('getValue') != "0" && $("#riskStep").combobox('getValue') != null) {
                    /***判断当前步骤是否已有风险防控***/
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "riskControl",
                        riskType: $("#riskType").combobox('getValue'),  //$riskType.find("option:selected").val(),
                        riskModule: $("#riskModule").combobox('getValue'),  //$riskModule.find("option:selected").val(),
                        riskStep: $("#riskStep").combobox('getValue'),  //$riskStep.find("option:selected").val(),
                        pageSize: pageSize
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          if (totalNum > 0) {
                              $("#h5_info").addClass("text-danger").removeClass("text-success").children().text("当前步骤已有风险防控！");
                              $("#confirm").modal("show");//弹出添加窗口
                          }
                          else {
                              $("#tb_risk").html(strTable);//清空值
                              $("#pagination").hide();//隐藏分页控件
                              $("#txt_riskPoint,#txt_riskResolve,#txt_remark,#h_id").val("");//清空值
                              $('#riskLevel').combobox('setValue', '1');//$("#riskLevel option").removeAttr("selected").eq(0).attr("selected", true);//默认选中第一个
                              $("#risk").modal("show");
                          }
                      });
                }
                else {
                    $("#h5_info").addClass("text-danger").removeClass("text-success").children().text("请选择步骤后再添加！");
                    $("#confirm").modal("show");
                }
            });

            /***保存***/
            $("#btn_risk_save").click(function () {
                if ($.trim($("#txt_riskPoint").val()) != "" && $.trim($("#txt_riskResolve").val()) != "") {
                    $.post("/Ajax/PublicSave.ashx", {
                        pageState: state == "add" ? "riskAdd" : "riskUpdate",
                        riskType: $("#riskType").combobox('getValue'), //$riskType.find("option:selected").val(),
                        riskStep: $("#riskStep").combobox('getValue') != "0" && $("#riskStep").combobox('getValue') != null ? $("#riskStep").combobox('getValue') : obj[objIndex].step_id,
                        //riskStep: $riskStep.find("option:selected").val() != "0" && $riskStep.find("option:selected").val() != null ? $riskStep.find("option:selected").val() : obj[objIndex].step_id,
                        riskLevel: $("#riskLevel").combobox('getValue'), //$("#riskLevel").find("option:selected").val(),
                        h_id: $("#h_id").val(),
                        txt_riskPoint: $("#txt_riskPoint").val(),
                        txt_riskResolve: $("#txt_riskResolve").val(),
                        txt_remark: $("#txt_remark").val()
                    },
                      function (data) {
                          $("#risk").modal("hide");//隐藏添加模态窗口
                          $("#btn_query").click();//执行查询方法，刷新列表
                      });
                }
                else {
                    $("#txt_riskPoint,#txt_riskResolve").parent("div").addClass("has-error");//添加错误样式
                }
            });

            /***关闭添加模态窗口之后***/
            $("#risk").on("hidden.bs.modal", function (e) {
                $("#txt_riskPoint,#txt_riskResolve").parent("div").removeClass("has-error");//清空错误样式
            });

            /***弹出模态窗口之后***/
            $("#confirm").on("shown.bs.modal", function (e) {
                window.setTimeout(function () {
                    $("#confirm").modal("hide");
                }, 1500);
            });
        });

        /***分页***/
        function pagination() {
            $("#pagination").pagination({
                total: totalNum,
                pageSize: 10,
                pageNumber: 1,//初始化当前页
                //点击分页按钮触发
                onSelectPage: function (page, pageSize) {
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "riskControl",
                        riskType: $("#riskType").combobox('getValue'),  //$riskType.find("option:selected").val(),
                        riskModule: $("#riskModule").combobox('getValue'),  //$riskModule.find("option:selected").val(),
                        riskStep: $("#riskStep").combobox('getValue'),  //$riskStep.find("option:selected").val(),
                        currentPage: page,//当前页码
                        pageSize: pageSize//每页显示数量（全局变量）
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].level_name + "</td><td title='" + obj[i].risk_point + "'>" + obj[i].risk_point.substring(0, 15) + "</td><td title='" + obj[i].risk_resolve + "'>" + obj[i].risk_resolve.substring(0, 20) + "</td><td><span class='glyphicon glyphicon-cog' id='" + obj[i].rowno + "' onclick='editRisk(this);'></span></td></tr>";
                          });
                          $("#tb_risk").html(strTable);
                          strTable = "";
                      });
                    return true;//必写！否则点击下一页时无效！
                }
            });
        }

        /***编辑***/
        function editRisk(btn) {
            /***通过<button>的id属性获取数据源中的“序号”列***/
            /***通过此序号从现有数据源中获取数据，避免再次查询***/
            objIndex = ($(btn).attr("id") - 1 + "").length > 1 ? (($(btn).attr("id") - 1 + "").substring(1)) : $(btn).attr("id") - 1;//每次分页结束生成新的数据源，索引只可能在0-9区间
            $("#txt_riskPoint").val(obj[objIndex].risk_point);//风险点
            $("#txt_riskResolve").val(obj[objIndex].risk_resolve);//防范措施
            $("#txt_remark").val(obj[objIndex].remark);//备注
            $("#h_id").val(obj[objIndex].risk_point_id);//风险防控ID
            $('#riskLevel').combobox('setValue', obj[objIndex].risk_level);
            //$("#riskLevel option").removeAttr("selected").eq(obj[objIndex].risk_level - 1).attr("selected", true);//风险等级
            state = "update";//修改为“更新”状态（为区分添加和更新）
            $("#risk").modal("show");//弹出编辑窗口
        }
    </script>
</body>
</html>