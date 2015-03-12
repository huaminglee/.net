var obj, strTable = "", pageSize = 10, currentPage = 1, totalNum;
var modelInfoService = new ModelInfoService();

$(function () {
    loadlist();
});
function loadlist() {
    modelInfoService.GetModelCount(
        function (data, status) {
            totalNum = data;
            if (totalNum > 0) {
                pageList(currentPage, pageSize, true);
            }
        });
}


/***分页***/
function pagination() {
    $("#pagination").pagination({
        total: totalNum,
        pageSize: pageSize,
        pageNumber: 1,//初始化当前页
        //点击分页按钮触发
        onSelectPage: function (page, pageSize) {
            pageList(page, pageSize, false)
            return true;//必写！否则点击下一页时无效！
        }
    });
}
//分页查询模板信息
function pageList(pageIndex, pageSize, isPage) {
    modelInfoService.GetModelList(pageIndex, pageSize,
          function (data, status) {
              var objTemp = $.parseJSON(data);//转换出总条数
              var curtotalNum = objTemp._Items.length;//总条数
              if (curtotalNum > 0) {
                  obj = objTemp._Items;//转换出数据源
                  $.each(obj, function (i) {
                      strTable += "<tr><td style='width:5%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                          "<td style='width:10%;text-align:center'>" + obj[i].MName.substring(0, 15) + "</td>" +
                          "<td style='width:20%;text-align:left'>" + obj[i].MContent + "</td>" +
                          "<td style='width:15%;text-align:center'>" + obj[i].Pico + "</td>" +
                          "<td style='width:10%;text-align:center'>" + obj[i].RightLevel + "</td>" +
                          "<td style='width:30%;text-align:left'>" + (obj[i].Remark!=null?obj[i].Remark : "")+ "</td>" +
                          "<td style='width:10%;text-align:center'><span onclick=delmodelinfo(" + obj[i].MId + ")>删除</span></td></tr>";
                  });
                  $("#tb_modellist").html(strTable);
                  strTable = "";
                  if (isPage) {
                      pagination();//分页
                  }
              }
              else {
                  $("#tb_modellist").html(strTable);
              }
          });
}
/***弹出iframe的关闭空方法***/
function doRefresh() { }
function Newmodel() {
    $.layer({
        type: 2,
        title: '新建模板',
        iframe: { src: 'newmodel.html?pagename=index.html' },
        maxmin: true,
        area: ['650px', '430px'],
        border: [1, 0.2, '#000', true],
        shadclose: true,
        offset: ['20px', '']
    });
}

function delmodelinfo(mid) {
    layer.confirm('确认要删除该模块，删除后无法恢复', function (index) {
        layer.closeAll();
        modelInfoService.DelModelInfo(mid,
            function (data, status) {
                loadlist();
            });
    });
}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}