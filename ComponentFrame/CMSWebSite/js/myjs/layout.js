var obj, strTable = "", pageSize = 10, currentPage = 1, totalNum;
var layoutInfoService = new LayoutInfoService();

$(function () {
    loadlist();
});
function loadlist() {
    layoutInfoService.GetLayoutInfoListCount("", "1",
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
    layoutInfoService.GetLayoutInfoList("", "1",pageIndex, pageSize,
          function (data, status) {
              var objTemp = $.parseJSON(data);//转换出总条数
              var curtotalNum = objTemp._Items.length;//总条数
              if (curtotalNum > 0) {
                  obj = objTemp._Items;//转换出数据源
                  $.each(obj, function (i) {
                      
                      strTable += "<tr><td style='width:5%;text-align:center'>" + (((pageIndex - 1) * pageSize) + (i + 1)) + "</td>" +
                          "<td style='width:25%;text-align:left'>" + obj[i].LName.substring(0, 15) + "</td>" +
                          "<td style='width:15%;text-align:center'>" + (obj[i].LayType == 1 ? "详细模板" : "布局模板") + "</td>" +
                          "<td style='width:15%;text-align:center'>" + (obj[i].TempType == 1 ? "默认模板" : "用户模板") + "</td>" +
                          "<td style='width:15%;text-align:center'>" + obj[i].BelongPage + "</td>" +
                          "<td style='width:15%;text-align:center'>" + obj[i].Owner + "</td>" +
                          "<td style='width:10%;text-align:center'><span onclick=sellayinfo(" + obj[i].LID + ")>查看</span>|<span onclick=dellayinfo(" + obj[i].LID + ")>删除</span></td></tr>";
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
function Newlayout() {
    $.layer({
        type: 2,
        title: '新增布局页面',
        iframe: { src: 'newlayout.html?pagename=index.html' },
        maxmin: true,
        area: ['650px', '500px'],
        border: [1, 0.2, '#000', true],
        shadclose: true,
        offset: ['20px', '']
    });
}
function sellayinfo(lid) {
    JumpParent("indexDesign.html?layouttype=0&lid=" + lid);
}
function dellayinfo(lid) {
    layoutInfoService.DelLayputinfo(lid,
        function (data, status) {
            loadlist();
        });
}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}