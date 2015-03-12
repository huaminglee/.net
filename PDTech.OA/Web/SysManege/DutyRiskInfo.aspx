<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DutyRiskInfo.aspx.cs" Inherits="SysManege_DutyRiskInfo" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>岗位风险</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
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
                <legend><small class="text-primary">岗位风险</small></legend>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="company" class="input-group-addon">所在单位</label>
                            <select class="easyui-combobox" id="company" style="width:150px;height:35px;">
                                <option value="0">全部</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_dutyName" class="input-group-addon">岗位名称</label>
                            <input type="text" class="form-control" id="txt_dutyName">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_dutyRisk" class="input-group-addon">岗位风险</label>
                            <input type="text" class="form-control" id="txt_dutyRisk">
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="riskLevel" class="input-group-addon">风险等级</label>
                            <select class="easyui-combobox" id="riskLevel" style="width:150px;height:35px;" data-options="panelHeight:'auto'">
                                <option value="0">全部</option>
                                <option value="1">一级</option>
                                <option value="2">二级</option>
                                <option value="3">三级</option>
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
                                        <th>所在单位</th>
                                        <th>岗位名称</th>
                                        <th>岗位风险</th>
                                        <th>风险等级</th>
                                        <th>管理</th>
                                    </tr>
                                </thead>
                                <tbody id="tb_dutyRiskInfo"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
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
    <!-- 模态窗口 -->
    <div class="modal fade bs-example-modal-sm" id="delete" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title" id="myModalLabel"><span class="glyphicon glyphicon-info-sign"></span>&ensp;提示</h5>
                </div>
                <div class="modal-body">
                    确定删除吗？
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">取&ensp;消</button>
                    <button id="btn_delete_yes" type="button" class="btn btn-danger btn-sm">确&ensp;定</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, strTable = "", strOption = "<option value='0'>全部</option>", $company = $("#company"), id, pageSize = 10, currentPage = 1, totalNum;
        $(function () {
            /***加载所在单位***/
            //$.get("/Ajax/PublicQuery.ashx", { pageState: "company" },
            //  function (data) {
            //      obj = $.parseJSON(data);
            //      $.each(obj, function (i) {
            //          //组织字符串效率高于遍历append
            //          strOption += "<option value='" + obj[i].department_id + "'>├" + obj[i].department_name + "</option>";
            //      });
            //      $company.html(strOption).children("option:eq(1)").text(obj[0].department_name);//去除第一个"├"
            //      $company.children("option:last").text("└" + obj[obj.length - 1].department_name);//将最后一个"├"替换为"└"
            //  });

            /*加载所在单位*/
            loadCompany();

            /***加载岗位风险***/
            loadDutyRiskInfo();

            /***查询***/
            $("#btn_query").click(function () {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "gwfxMore",
                    company: $("#company").combobox('getValue'),
                    txt_dutyName: $.trim($("#txt_dutyName").val()),
                    txt_dutyRisk: $.trim($("#txt_dutyRisk").val()),
                    riskLevel: $("#riskLevel").combobox('getValue'),  //$("#riskLevel").find("option:selected").val(),
                    pageSize: pageSize
                },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      if (totalNum > 0) {  
                          $.each(obj, function (i) {
                              strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].department_name + "</td><td title='" + obj[i].duty_name + "'>" + obj[i].duty_name.substring(0, 15) + "</td><td title='" + obj[i].risk_name + "'>" + obj[i].risk_name.substring(0, 45) + "</td><td>" + obj[i].risk_level + "</td><td><span class='glyphicon glyphicon-remove text-danger' onclick='btnDelete(" + obj[i].duty_risk_id + ");'></span></td></tr>";
                          });  
                      }
                      $("#tb_dutyRiskInfo").html(strTable);
                      strTable = "";
                      pagination();//分页
                  });
            });

            /***添加***/
            $("#btn_add").click(function () {
                window.location.href = "AddDutyRiskInfo.aspx";
            });

            /***删除***/
            $("#btn_delete_yes").click(function () {
                $.get("/Ajax/PublicSave.ashx", {
                    pageState: "gwfxDel",
                    duty_risk_id: id
                },
                  function (data) {
                      $("#delete").modal("hide");
                  });
            });

            /***隐藏模态窗口之后***/
            $("#delete").on("hidden.bs.modal", function (e) {
                loadDutyRiskInfo();//重新加载岗位风险
            });
        });

        /*加载所在单位*/
        function loadCompany() {
            $('#company').combobox({
                url: '/Ajax/PublicQuery.ashx?pageState=company',
                valueField: 'department_id',
                textField: 'department_name',
            });
        }

        /***加载岗位风险***/
        function loadDutyRiskInfo() {
            $.get("/Ajax/PublicQuery.ashx", {
                pageState: "gwfxMore",
                company: $("#company").combobox('getValue'),
                txt_dutyName: $.trim($("#txt_dutyName").val()),
                txt_dutyRisk: $.trim($("#txt_dutyRisk").val()),
                riskLevel: $("#riskLevel").combobox('getValue'),
                pageSize: pageSize
            },
              function (data) {
                  objTemp = $.parseJSON(data);//转换出总条数
                  totalNum = objTemp.TotalNum;//总条数
                  if (totalNum > 0) {
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      $.each(obj, function (i) {
                          strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].department_name + "</td><td title='" + obj[i].duty_name + "'>" + obj[i].duty_name.substring(0, 15) + "</td><td title='" + obj[i].risk_name + "'>" + obj[i].risk_name.substring(0, 45) + "</td><td>" + obj[i].risk_level + "</td><td><span class='glyphicon glyphicon-remove text-danger' onclick='btnDelete(" + obj[i].duty_risk_id + ");'></span></td></tr>";
                      });
                      $("#tb_dutyRiskInfo").html(strTable);
                      strTable = "";
                      pagination();//分页
                  }
                  else {
                      $("#tb_dutyRiskInfo").html(strTable);
                  }
              });
        }

        /***分页***/
        function pagination() {
            $("#pagination").pagination({
                total: totalNum,
                pageSize: 10,
                pageNumber: 1,//初始化当前页
                //点击分页按钮触发
                onSelectPage: function (page, pageSize) {
                    $.get("/Ajax/PublicQuery.ashx", {
                        pageState: "gwfxMore",
                        company: $("#company").combobox('getValue'),
                        txt_dutyName: $.trim($("#txt_dutyName").val()),
                        txt_dutyRisk: $.trim($("#txt_dutyRisk").val()),
                        riskLevel: $("#riskLevel").combobox('getValue'),
                        currentPage: page,//当前页码
                        pageSize: pageSize//每页显示数量（全局变量）
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              strTable += "<tr><td>" + obj[i].rowno + "</td><td>" + obj[i].department_name + "</td><td title='" + obj[i].duty_name + "'>" + obj[i].duty_name.substring(0, 15) + "</td><td title='" + obj[i].risk_name + "'>" + obj[i].risk_name.substring(0, 45) + "</td><td>" + obj[i].risk_level + "</td><td><span class='glyphicon glyphicon-remove text-danger' onclick='btnDelete(" + obj[i].duty_risk_id + ");'></span></td></tr>";
                          });
                          $("#tb_dutyRiskInfo").html(strTable);
                          strTable = "";
                      });
                    return true;//必写！否则点击下一页时无效！
                }
            });
        }

        /***删除***/
        function btnDelete(duty_risk_id) {
            id = duty_risk_id;
            $("#delete").modal();
        }
    </script>
</body>
</html>