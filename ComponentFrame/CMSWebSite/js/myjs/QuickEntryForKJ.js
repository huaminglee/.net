var useRecordService = new QuickUseRecordService();
$(function () {    
    useRecordService.GetUsualQuick(1, 12,
    function (data, status) {
        var strTable = '';
        var objTemp = $.parseJSON(data); //转换出总条数
        var modellistAll = objTemp._Items; //存放当前模板中的模块
        if (modellistAll != undefined && modellistAll != null) {
            for (var i = 1; i < modellistAll.length + 1; i++) {
                var modelObj = modellistAll[i - 1];
                strTable += "<button type='button' onclick='openquick(" + modelObj.QId + ")' class='btn btn-link' data-toggle='modal' data-target='#dBase' style='padding: 7px 10px;'> <img style='width:80px' src='../Image/QuickIco/" + modelObj.QPico + "'><br />" + modelObj.QName + "</button>"
                if (i % 6 == 0) {
                    strTable += "</br>";
                }
            }
        }
        $('#QuickEntrykj').html(strTable);
    });


});
function openquick(qid) {    
    useRecordService.AddQuickUse(qid, 1,
       function (data, status) {
       });
}