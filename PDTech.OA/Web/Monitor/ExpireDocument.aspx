<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpireDocument.aspx.cs" Inherits="Monitor_ExpireDocument" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>超期预警--日常办公公文</title>
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hiduserid" runat="server" />
    </form>
    <section class="container">
        <div class="container-fluid">
            <fieldset>
                <legend><small class="text-primary">超期预警--日常办公公文</small></legend>
                <!-- 查询条件（一） -->
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_title" class="input-group-addon">公文标题</label>
                            <input type="text" class="form-control" id="txt_title">
                            
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="txt_fileNum" class="input-group-addon">文件编号</label>
                            <input type="text" class="form-control" id="txt_fileNum">
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <label for="txt_startTime" class="input-group-addon">开始</label>
                            <input type="text" class="form-control" id="txt_startTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <label for="txt_endTime" class="input-group-addon">结束</label>
                            <input type="text" class="form-control" id="txt_endTime" readonly="true" onclick="WdatePicker();">
                        </div>
                    </div>
                </div>
                <br />
                <!-- 查询条件（二） -->
                <div class="row">
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="company" class="input-group-addon">所在部门</label>
                            <select id="company" class="easyui-combobox" style="width:150px;height:35px;">
                                <option value="0">全部</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group">
                            <label for="company" class="input-group-addon">公文类型</label>
                            <select id="archiveType" class="easyui-combobox" style="width:150px;height:35px;">
                                <option value="0">全部</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <label for="company" class="input-group-addon">风险处置</label>
                            <select id="riskHandle" class="easyui-combobox" style="width:90px;height:35px;" data-options="panelHeight:'auto'">
                                <option value="0">全部</option>
                                <option value="1">未处理</option>
                                <option value="2">已处理</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <button type="button" class="btn btn-primary" id="btn_query">查&ensp;询</button>
                    </div>
                </div>
                <br />
                <!-- 数据 -->
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-condensed table-bordered cursor">
                                <thead>
                                    <tr>
                                        <th>序号</th>
                                        <th>公文标题</th>
                                        <th>公文类型</th>
                                        <th>发送人</th>
                                        <th>承办人</th>
                                        <th>处室</th>
                                        <th>送达时间</th>
                                        <th>当前步骤</th>
                                        <th>办理时限</th>
                                        <th>风险处置单</th>
                                        <th class="text-center">管理</th>
                                    </tr>
                                </thead>
                                <tbody id="tb_expireDocument"></tbody>
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
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script src="/Script/My97DatePicker/WdatePicker.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, strTable = "", strOption = "<option value='0'>全部</option>", $company = $("#company"), $archiveType = $("#archiveType"), pageSize = 10, currentPage = 1, totalNum;
        $(function () {
            /***加载所在部门***/
            $('#company').combobox({
                url: '/Ajax/PublicQuery.ashx?pageState=company',
                valueField: 'department_id',
                textField: 'department_name',
            });
            //$.get("/Ajax/PublicQuery.ashx", { pageState: "company" },
            //  function (data) {
            //      obj = $.parseJSON(data);
            //      $.each(obj, function (i) {
            //          //组织字符串效率高于遍历append
            //          strOption += "<option value='" + obj[i].department_id + "'>├" + obj[i].department_name + "</option>";
            //      });
            //      $company.html(strOption).children("option:eq(1)").text(obj[0].department_name);//去除第一个"├"
            //      $company.children("option:last").text("└" + obj[obj.length - 1].department_name);//将最后一个"├"替换为"└"
            //      strOption = "<option value='0'>全部</option>";
            //  });

            /***加载公文类型***/
            $('#archiveType').combobox({
                url: '/Ajax/PublicQuery.ashx?pageState=archiveTypeOption',
                valueField: 'archive_type',
                textField: 'type_name',
            });
            //$.get("/Ajax/PublicQuery.ashx", { pageState: "archiveTypeOption" },
            //  function (data) {
            //      obj = $.parseJSON(data);
            //      $.each(obj, function (i) {
            //          //组织字符串效率高于遍历append
            //          strOption += "<option value='" + obj[i].archive_type + "'>" + obj[i].type_name + "</option>";
            //      });
            //      $archiveType.html(strOption);
            //      strOption = "<option value='0'>全部</option>";
            //  });

            /***加载列表***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "expireDocument", username: $("#hiduserid").val(), pageSize: pageSize },
              function (data) {
                  objTemp = $.parseJSON(data);//转换出总条数
                  totalNum = objTemp.TotalNum;//总条数
                  if (totalNum > 0) {
                      obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                      $.each(obj, function (i) {
                          if (obj[i].is_expire < 0) {
                              strTable += "<tr class='danger'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                          }
                          else {
                              strTable += "<tr class='warning'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                          }
                      });
                      $("#tb_expireDocument").html(strTable);
                      strTable = "";
                      pagination();//分页
                  }
                  else {
                      $("#tb_expireDocument").html(strTable);
                  }
              });

            /***查询***/
            $("#btn_query").click(function () {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "expireDocument",
                    username:$("#hiduserid").val(),
                    txt_title: $.trim($("#txt_title").val()),
                    txt_fileNum: $.trim($("#txt_fileNum").val()),
                    txt_startTime: $("#txt_startTime").val(),
                    txt_endTime: $("#txt_endTime").val(),
                    company: $('#company').combobox('getValue'),            //$("#company").find("option:selected").val(),
                    archiveType: $('#archiveType').combobox('getValue'),    //$("#archiveType").find("option:selected").val(),
                    riskHandle: $('#riskHandle').combobox('getValue'),      //$("#riskHandle").find("option:selected").val(),
                    pageSize: pageSize
                },
                  function (data) {
                      objTemp = $.parseJSON(data);//转换出总条数
                      totalNum = objTemp.TotalNum;//总条数
                      if (totalNum > 0) {
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              if (obj[i].is_expire < 0) {
                                  strTable += "<tr class='danger'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                              }
                              else {
                                  strTable += "<tr class='warning'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                              }
                          });
                          $("#tb_expireDocument").html(strTable);
                          strTable = "";
                          pagination();//分页
                      }
                      else {
                          $("#tb_expireDocument").html(strTable);
                      }
                  });
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
                        pageState: "expireDocument",
                        username: $("#hiduserid").val(),
                        txt_title: $.trim($("#txt_title").val()),
                        txt_fileNum: $.trim($("#txt_fileNum").val()),
                        txt_startTime: $("#txt_startTime").val(),
                        txt_endTime: $("#txt_endTime").val(),
                        company: $('#company').combobox('getValue'),    //$("#company").find("option:selected").val(),
                        archiveType: $('#archiveType').combobox('getValue'),    //$("#archiveType").find("option:selected").val(),
                        riskHandle: $('#riskHandle').combobox('getValue'),  //$("#riskHandle").find("option:selected").val(),
                        currentPage: page,//当前页码
                        pageSize: pageSize//每页显示数量（全局变量）
                    },
                      function (data) {
                          objTemp = $.parseJSON(data);//转换出总条数
                          totalNum = objTemp.TotalNum;//总条数
                          obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                          $.each(obj, function (i) {
                              if (obj[i].is_expire < 0) {
                                  strTable += "<tr class='danger'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                              }
                              else {
                                  strTable += "<tr class='warning'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].owner_dept + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                              }
                          });
                          $("#tb_expireDocument").html(strTable);
                          strTable = "";
                      });
                    return true;//必写！否则点击下一页时无效！
                }
            });
        }

        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function showDetail(archive_id, archive_type) {
            var src;
            /***公文查询***/
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
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '560px'],
                offset: ['20px', ''],
                iframe: { src: src }
            });
        }

        /***生成风险处置单***/
        function createRiskHandle(archive_id, archive_task_id, archive_type) {
            $.layer({
                type: 2,
                title: "生成风险处置单",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '560px'],
                offset: ['20px', ''],
                iframe: { src: '/Risk/newRisk.aspx?ptype=' + archive_type + '&p_arId=' + archive_id + '&ptId=' + archive_task_id + '' }
            });
        }

        /***查看风险处置单***/
        function showRiskHandle(risk_handle_archive_id) {
            $.layer({
                type: 2,
                title: "查看风险处置单",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '560px'],
                offset: ['20px', ''],
                iframe: { src: '/Risk/sel_risk.aspx?arId=' + risk_handle_archive_id + '' }
            });
        }

        /***弹出iframe的关闭空方法***/
        function doRefresh() { }
    </script>
</body>
</html>