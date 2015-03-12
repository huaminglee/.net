var strTable = '';
var userBaseInfoService = new UserBaseInfoService();
$(function () {
    userBaseInfoService.GetWorkWaitfor(
    function (data, status) {
        var objTemp = $.parseJSON(data);
        var modellistAll = objTemp._Items;
        if (modellistAll != undefined && modellistAll != null && modellistAll.length > 0) {
            for (var i = 1; i < modellistAll.length + 1; i++) {
                var modelObj = modellistAll[i - 1];
                strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].WorkId + ");' href='#' class='list-group-item' style='color:#f0ad4e;'><span class='glyphicon glyphicon-flash' style='color:#f0ad4e;' title='还有" + Math.floor(obj[i].is_expire / 84600) + "天'></span><small class='text-primary'>【" + (obj[i].task_type == "1" ? obj[i].type_name + " — 抄送" : obj[i].type_name) + "】</small>" + obj[i].archive_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].limit_time + "</span></a>";
            }
        }
        else {
            strTable = "无待办事项";
        }
        $('#workwaitfor').html(strTable);
    }
);
});
function showDetail(WorkId) {
    window.parent.Location = "ShowFlow.aspx?WorkId=" + WorkId;
}