var useRecordService = new QuickUseRecordService();
$(function () {
    useRecordService.GetUsualQuick(2, 6,
    function (data, status) {
        var strTable = '';
        var objTemp = $.parseJSON(data);
        var modellistAll = objTemp._Items;
        if (modellistAll != undefined && modellistAll != null) {
            for (var i = 1; i < modellistAll.length + 1; i++) {
                var modelObj = modellistAll[i - 1];
                strTable += "<button type='button' class='btn btn-link' data-toggle='modal' onclick='openquick(" + modelObj.QId + ")' data-target='#dBase' style='padding: 7px 10px;'> <img style='width:80px' src='../Image/QuickIco/" + modelObj.QPico + "'><br />" + modelObj.QName + "</button>"

            }
        }
        $('#QuickEntrytj').html(strTable);
    });


});
function openquick(qid) {    
    useRecordService.AddQuickUse(qid, 2,
        function (data, status) { });
}