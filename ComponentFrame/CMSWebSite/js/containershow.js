/*页面全局变量声明－开始*/
//定义克隆层
var cloneDiv;
//定义记录鼠标的XY坐标
var ePageX;
var ePageY;
var layoutinfoData;

var gridster;
var gridCount;
var gridSize;
//BeginURL参数
var lid;
var pagename;
var owner;
var modeltype;
var layouttype;
var designthis;

var toolsDivObjIsMove = true;
var modellistsCurrent_public;
var skinInfoService = new SkinInfoService();
var layoutInfoService = new LayoutInfoService();
/*页面全局变量声明－结束*/

$(function () {
    //取得URL参数
    sessionStorage.removeItem("containerCurrentObj");
    lid = getQueryString("lid");
    pagename = getQueryString("pagename");
    owner = getQueryString("owner");
    modeltype = getQueryString("modeltype");
    layouttype = getQueryString("layouttype");
    designthis = getQueryString("designthis");

    //设置单元格的行个数
    gridCount = 48;
    //算出单元格大小
    gridSize = Math.round(($(window).width()) / gridCount);


    gridster = $(".gridster > ul").gridster({
        widget_margins: [1, 1],
        min_cols: gridCount,
        max_cols: gridCount,
        avoid_overlapped_widgets: true,
        widget_base_dimensions: [gridSize - 2, gridSize - 2],
        autogenerate_stylesheet: true,
        resize: {
            enabled: false
        },
        draggable: {
            handle: 'header'
        },
        serialize_params: function ($w, wgd) {
            return {
                MID: $w.attr("MID"),
                MName: $w.attr("MName"),
                MContent: $w.attr("MContent"),
                DCol: wgd.col,
                DRow: wgd.row,
                Sizex: wgd.size_x,
                Sizey: wgd.size_y
            };
        }
    }).data('gridster');
    if (gridster) {
        gridster.disable();
    }
    if (lid != undefined && lid != null) {
        layoutInfoService.GetUserLayoutinfobyid(lid,
            function (data, status) {
                objTemp = $.parseJSON(data); //转换出总条数
                layoutinfoData = objTemp;
                //动态加载模块
                var modellistsCurrent = $.parseJSON(layoutinfoData.LModelList)._Items; //存放当前模板中的模块
                loadModellistsCurrent(modellistsCurrent);
                loadskin();
                //转换为json字符串存到本地
                sessionStorage.setItem("containerCurrentObj", JSON2.stringify(layoutinfoData));
            }
        );
    }
        //调用绑定事件
    else {
        $(".gridster").css("height", "100px");
    }
});
function loadModellistsCurrent(modellistsCurrent) {
    //加载模块到当前页面
    if (modellistsCurrent != undefined && modellistsCurrent != null) {
        for (var i = 0; i < modellistsCurrent.length; i++) {
            var modelObj = modellistsCurrent[i];
            gridster.add_widget("<li MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
            + " ><iframe src='/iframes/"
            + modelObj.MContent + "'></iframe></li>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);


        }
    }
}
function sleep(numberMillis) {
    var now = new Date();
    var exitTime = now.getTime() + numberMillis;
    while (true) {
        now = new Date();
        if (now.getTime() > exitTime) return;
    }
}
function changeskin(selectSkin) {
    if (selectSkin != null) {
        var skinPathFileName = selectSkin.split('.');
        if (skinPathFileName.length > 0) {
            var skinFileName = skinPathFileName[0].split('/');
            if (skinFileName.length > 0) {
                var skinName = "myskin/" + skinFileName[skinFileName.length - 1] + ".css";
                $("link[href*='myskin']").attr("href", skinName);
                //实现iframe的换肤功能
                if (window.frames.length > 0) {
                    for (var i = 0; i < window.frames.length; i++) {
                        var iframeSkin = $(window.frames[i].document).find("link[href*='myskin']");
                        if (iframeSkin != null && iframeSkin.length > 0) {
                            var skinHrefs;
                            var skinHref;
                            var iframeSkinTemp;
                            if (iframeSkin.length == 1) {
                                iframeSkinTemp = iframeSkin;
                            } else {
                                iframeSkinTemp = $(iframeSkin[0]);
                            }
                            skinHrefs = iframeSkinTemp.attr("href");
                            skinHref = skinHrefs.split('-');
                            if (skinHref.length > 1)
                                iframeSkinTemp.attr("href", "/myskin/" + skinFileName[skinFileName.length - 1] + "-" + skinHref[skinHref.length - 1]);
                            else {
                                iframeSkinTemp.attr("href", "/myskin/" + skinFileName[skinFileName.length - 1] + ".css");
                            }
                            //if ($(window.frames[i].name).indexOf("modelcontainer.html") > -1) {
                            //    $(window.frames[i]).changeskin(selectSkin);
                            //}                           
                        }
                    }
                }//iframe换肤结束
            }
        }

    }
}
function loadskin() {
    skinInfoService.GetUserSkinInfo(
         function (data, status) {
             var skinName = sessionStorage.getItem("skinName");
             var skinFileName = sessionStorage.getItem("skinFileName");
             $("link[href*='myskin']").attr("href", skinName);
             //实现iframe的换肤功能
             if (window.frames.length > 0) {
                 for (var i = 0; i < window.frames.length; i++) {
                     var iframeSkin = $(window.frames[i].document).find("link[href*='myskin']");
                     if (iframeSkin != null && iframeSkin.length > 0) {
                         var skinHrefs;
                         var skinHref;
                         var iframeSkinTemp;
                         if (iframeSkin.length == 1) {
                             iframeSkinTemp = iframeSkin;
                         } else {
                             iframeSkinTemp = $(iframeSkin[0]);
                         }
                         skinHrefs = iframeSkinTemp.attr("href");
                         skinHref = skinHrefs.split('-');
                         if (skinHref.length > 1)
                             iframeSkinTemp.attr("href", "/myskin/" + skinFileName + "-" + skinHref[skinHref.length - 1]);
                         else {
                             iframeSkinTemp.attr("href", "/myskin/" + skinFileName + ".css");
                         }
                         //if ($(window.frames[i].name).indexOf("modelcontainer.html") > -1) {
                         //    $(window.frames[i]).loadskin(skinName);
                         //}                
                     }
                 }
             }
         });
    
}


//取得URL参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}


