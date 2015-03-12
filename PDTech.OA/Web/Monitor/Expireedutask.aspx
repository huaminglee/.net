<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expireedutask.aspx.cs" Inherits="Monitor_Expireedutask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <section class="container">
        <div class="container-fluid">
            <fieldset>
                <legend><small class="text-primary">超期预警--教育任务</small></legend>
                <!-- 数据 -->
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-condensed table-bordered cursor">
                                <thead>
                                    <tr>
                                        <th>序号</th>
                                        <th>任务标题</th>
                                        <th>任务类型</th>
                                        <th>创建人</th>
                                        <th>创建时间</th>
                                        <th>来文单位</th>
                                      
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
             /***加载列表***/
             $.get("/Ajax/PublicQuery.ashx", { pageState: "expireEdutask", username: $("#hiduserid").val(), pageSize: pageSize },
               function (data) {
                   objTemp = $.parseJSON(data);//转换出总条数
                   totalNum = objTemp.TotalNum;//总条数
                   if (totalNum > 0) {
                       obj = $.parseJSON(objTemp.DataSources);//转换出数据源
                       $.each(obj, function (i) {
                           if (obj[i].is_expire < 0) {
                               strTable += "<tr class='danger'><td>" + obj[i].rowno + "</td><td title='" + obj[i].TITLE + "'>" + obj[i].TITLE.substring(0, 15) + "</td><td>" + obj[i].FILETYPE + "</td><td>" + obj[i].FULL_NAME + "</td><td>" + obj[i].CREATETIME + "</td><td>" + obj[i].COMPANY + "</td><td>" + obj[i].HOPEFINISHTIME + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
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
                                   strTable += "<tr class='danger'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                               }
                               else {
                                   strTable += "<tr class='warning'><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].type_name + "</td><td>" + obj[i].creator + "</td><td>" + obj[i].owner + "</td><td>" + obj[i].start_time + "</td><td>" + obj[i].step_name + "</td><td>" + obj[i].limit_time + "</td><td>" + (obj[i].risk_handle_archive_id == "" ? "<span class='glyphicon glyphicon-file' title='生成风险处置单' onclick='createRiskHandle(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");'>(生成风险处置单)</span>" : "<span class='glyphicon glyphicon-file' title='查看风险处置单' onclick='showRiskHandle(" + obj[i].risk_handle_archive_id + ");'>(已处理)</span>") + "</td><td class='text-center'><span class='glyphicon glyphicon-search' title='查看' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_type + ");'></span></td></tr>";
                               }
                           });
                           $("#tb_expireDocument").html(strTable);
                           strTable = "";
                       });
                     return true;//必写！否则点击下一页时无效！
                 }
             });
         }
            </script>
</body>
</html>
