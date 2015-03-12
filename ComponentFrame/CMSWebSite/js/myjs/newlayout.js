var obj, strTable = "", pageSize = 5, currentPage = 1, totalNum;
var pagename, ltype, mtype;
var layoutInfoService = new LayoutInfoService();

$(function () {
    $("#lbhost").html(window.location.protocol+window.location.host + "/UserdefLayout/");
    mtype = getQueryString('mtype');
    if (mtype == '1') {//用户修改布局
        pagename = getQueryString('pagename');
        $("#inputpagename").val(pagename);
        //$("#inputpagename").attr("disabled", "disabled");
        $('input[name="modeltype"]').attr("disabled", "disabled");
        $("#RDmodeldefault")[0].checked = false;
        $("#RDmodeluser")[0].checked = true;
        $("#modelshow")[0].innerHTML = "用户";

    }
});
function changeways(e) {
    pagename = $("#inputpagename").val();

    if (e.checked) {
        ltype = e.value;
        loadlist();
    }
}
function loadlist() {
    layoutInfoService.GetLayoutInfoListCount( "", ltype,
        function (data, status) {
            totalNum = data;
            if (totalNum > 0) {
                pageList(currentPage, pageSize, true);
            }
        });
}
function selrow(e) {
    e.childNodes[0].childNodes[0].checked = true;

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
    layoutInfoService.GetLayoutInfoList("", ltype, pageIndex, pageSize,
            function (data, status) {
                var objTemp = $.parseJSON(data);//转换出总条数
                var curtotalNum = objTemp._Items.length;//总条数
                if (curtotalNum > 0) {
                    obj = objTemp._Items;//转换出数据源
                    $.each(obj, function (i) {
                        strTable += "<tr ><td><input type='radio' name='sellayout' value=" + obj[i].LID + " /></td><td>" + obj[i].LName.substring(0, 15) + "</td><td>" + (obj[i].LayType == 1 ? "详细模板" : "布局模板") + "</td><td>" + (obj[i].TempType == 1 ? "默认模板" : "用户模板") + "</td><td>" + obj[i].BelongPage + "</td><td>" + obj[i].Owner + "</td></tr>";
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
function confirmadd() {
    var pagename, owner, modeltype, layouttype;
    pagename = $("#inputpagename").val();
    owner = $("#iowner").val();
    if (pagename == "") {
        layer.tips('请输入页面名称', $("#inputpagename"), {
            guide: 1,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        var obj = $("#tb_modellist")[0].childNodes;
        var sellayoutid;
        $.each(obj, function (i) {
            var issel = obj[i].childNodes[0].childNodes[0].checked;
            if (issel) {
                sellayoutid = obj[i].childNodes[0].childNodes[0].value;
                return false;
            }
        });


        modeltype = $('input[name="modeltype"]:checked').val();
        layouttype = $('input[name="layouttype"]:checked').val();
        if (sellayoutid != undefined) {

            window.parent.parent.location.href = "indexDesign.html?designthis=1&lid=" + sellayoutid + "&pagename=UserdefLayout/" + pagename + "&owner=" + owner + "&modeltype=" + modeltype + "&layouttype=" + layouttype;
            window.parent.layer.closeAll();
        }
        else {

            window.parent.parent.location.href = "indexDesign.html?designthis=1&pagename=UserdefLayout/" + pagename + "&owner=" + owner + "&modeltype=" + modeltype + "&layouttype=" + layouttype;
            window.parent.layer.closeAll();
        }
    }

}
function changmodeltype(e) {
    if (e.checked) {
        if (e.value == '1') {
            $("#modelshow")[0].innerHTML = "权限";
        }
        else {
            $("#modelshow")[0].innerHTML = "用户";
        }
    }

}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}