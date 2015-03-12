/*页面全局变量声明－开始*/
//定义克隆层
var cloneDiv;
//定义记录鼠标的XY坐标
var ePageX;
var ePageY;
var layoutinfoData;
var containerindex = -999;
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
//EndURL参数
var loginId;
var toolsDivObjIsMove = true;
var modellistsCurrent_public;

var modelInfoService = new ModelInfoService();
var layoutInfoService = new LayoutInfoService();
/*页面全局变量声明－结束*/

$(function () {
    loginId = layoutInfoService.loginId;
    //取得URL参数
    sessionStorage.removeItem("modellistsCurrentObj");
    lid = getQueryString("lid");
    pagename = getQueryString("pagename");
    owner = getQueryString("owner");
    modeltype = getQueryString("modeltype");
    layouttype = getQueryString("layouttype");
    designthis = getQueryString("designthis");

    //设置单元格的行个数
    gridCount = 48;
    //算出单元格大小
    gridSize = Math.round(($(window).width() - 40) / gridCount);


    gridster = $(".gridster").gridster({        
        widget_selector: "div",
        widget_margins: [1, 1],
        min_cols: gridCount,
        max_cols: gridCount,
        avoid_overlapped_widgets: true,
        widget_base_dimensions: [gridSize - 2, gridSize - 2],
        autogenerate_stylesheet: true,
        resize: {
            enabled: (layouttype != null && layouttype == 2) ? true : true
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

    //从服务中加载
    var gridsettStr = sessionStorage.getItem("gridsterForResize");
    if (gridsettStr != undefined && gridsettStr != null) {

        var gridsettObj = JSON2.parse(gridsettStr);
        gridster.remove_all_widgets();

        for (var i = 0; i < gridsettObj.length; i++) {
            var modelObj = gridsettObj[i];
            if (modelObj.MContent.indexOf("containershow.html") > -1) {
                var lid = modelObj.MContent.substring(modelObj.MContent.indexOf("?lid=") + 5, modelObj.MContent.length);
                modelObj.MContent = "modelcontainer.html?lid=" + lid;
                if (modelObj.MContent == null || modelObj.MContent == undefined || modelObj.MContent == '') {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header>"
                + "<iframe src='' name='" + modelObj.MContent + "'></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);
                }
                else {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><iframe src='/iframes/"
                + modelObj.MContent + "' name='" + modelObj.MContent + "' ></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);

                }
            }
            else {
                if (modelObj.MContent == null || modelObj.MContent == undefined || modelObj.MContent == '') {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt>"
                + "</quilt><iframe src=''></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);


                }
                else {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src='/iframes/"
                + modelObj.MContent + "'></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);

                }
            }
                
        }

        sessionStorage.removeItem("gridsterForResize");

    }
    else if (lid != undefined && lid != null) {
            layoutInfoService.GetUserLayoutinfobyid(lid,
                function (data, status) {
                    objTemp = $.parseJSON(data); //转换出总条数
                    layoutinfoData = objTemp;
                    //动态加载模块
                    var modellistsCurrent = $.parseJSON(layoutinfoData.LModelList)._Items; //存放当前模板中的模块
                    loadModellistsCurrent(modellistsCurrent);
                    //转换为json字符串存到本地
                    sessionStorage.setItem("modellistsCurrentObj", JSON2.stringify(layoutinfoData));
                }
            );       
    }
    else {
        $(".gridster").css("height", parent.innerHeight + "px");
    }

    //从服务中加载
    modelInfoService.GetModelList(0, -1,
        function (data, status) {
            var objTemp = $.parseJSON(data); //转换出总条数
            //动态加载模块
            var modellistAll = objTemp._Items; //存放当前模板中的模块
            loadModellistAll(modellistAll);
        }
    );
    $(".module-tools-close").mousemove(function (e) {
        var closeDiv = $(this);
        closeDiv.css("opacity", "0.5");
    });

    $(".module-tools-close").mouseout(function (e) {
        var closeDiv = $(this);
        closeDiv.css("opacity", "1");
    });

    $(".module-tools-close").click(function (e) {
        saveinfo();
    });
    $(".module-hear-ico").mousedown(function (e) {
        if (toolsDivObjIsMove) {
            $("#module-tools-id").addClass("module-tools_pagetop");
            $("#module-tools-id").removeClass("module-tools");
            toolsDivObjIsMove = false;
        } else {
            $("#module-tools-id").addClass("module-tools");
            $("#module-tools-id").removeClass("module-tools_pagetop");
            toolsDivObjIsMove = true;
        }
    });

    BindResize();

});
function BindResize() {
    var timer = 0;
    $(window).resize(function () {
        clearTimeout(timer);
        timer = setTimeout(function () {
            var modelsf = gridster.serialize();

            sessionStorage.setItem("gridsterForResize", JSON2.stringify(modelsf));

            location.replace(location);
            if (modelsf.length == 0) {
                $(".gridster").css("height", parent.innerHeight + "px");
            }
        }, 200);
    });
}
function loadModellistsCurrent(modellistsCurrent) {
    //加载模块到当前页面
    if (modellistsCurrent != undefined && modellistsCurrent != null) {
        for (var i = 0; i < modellistsCurrent.length; i++) {
            var modelObj = modellistsCurrent[i];
            if (modelObj.MContent.indexOf("containershow.html") > -1) {
                var lid = modelObj.MContent.substring(modelObj.MContent.indexOf("?lid=") + 5, modelObj.MContent.length);
                modelObj.MContent = "modelcontainer.html?lid=" + lid;
                if (layouttype != null && layouttype == 2) {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header>"
                + "<iframe src=''  name='" + modelObj.MContent + "'></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);


                }
                else {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><iframe src='/iframes/"
                + modelObj.MContent + "'  name='" + modelObj.MContent + "'></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);

                }
            }
            else {
                if (layouttype != null && layouttype == 2) {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt>"
                + "</quilt><iframe src=''></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);


                }
                else {
                    gridster.add_widget("<div MID='id1' MName=" + modelObj.MName + " MContent=" + modelObj.MContent
                + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src='/iframes/"
                + modelObj.MContent + "'></iframe></div>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow);

                }
            }
            
        }
    }
}

function loadModellistAll(modellistAll) {
    //取得模块工具对象
    var moduleToolsObj = $(".module-tools #moduleAllIco #moduleAllIcoMove ul");
    //加载所有模块到当前页面的工具栏上
    if (modellistAll != undefined && modellistAll != null) {
        for (var i = 0; i < modellistAll.length; i++) {
            var modelObj = modellistAll[i];
            var modelObjDiv = $('<li title="' + modelObj.MName + '" MID="' + modelObj.MId + '" MName="' + modelObj.MName + '" Sizex="' + modelObj.Sizex + '" Sizey="' + modelObj.Sizey + '" MContent="' + modelObj.MContent
                + '"  style="float:left; left:5px; height: 100px; width: 100px;"><a><div class="menu_img"  style="background-image: url(/Image/' + modelObj.Pico + ');background-repeat:repeat;"><div><span>' + modelObj.MName + '</span></a></li>');
            moduleToolsObj.append(modelObjDiv);
        }
    }

    //调用绑定事件
    BindModuleEvent();
    BottomToolsLoad();
}

//取得URL参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}
 
/*绑定模块工具栏事件*/
function BindModuleEvent() {
    //鼠标在body上并且在模块层触发克隆层动作
    $("body .module-tools #moduleAllIco #moduleAllIcoMove li").mousedown(function () {
        cloneDiv = $(this).clone(); //克隆当前事件对象
        var containobj = { mid: cloneDiv[0].attributes["mid"].value, mname: cloneDiv[0].attributes["mname"].value, mcontent: cloneDiv[0].attributes["mcontent"].value, Sizex: cloneDiv[0].attributes["Sizex"].value, Sizey: cloneDiv[0].attributes["Sizey"].value };

        sessionStorage.setItem("containercloneDiv", JSON.stringify(containobj));
    });
    $("body .module-tools #moduleAllIco #moduleAllIcoMove li").mouseup(function () {
        cloneDiv = null;
        sessionStorage.removeItem("containercloneDiv");
    });
    //克隆层的鼠标样式设置
    $("body").mousemove(function (event) {
        event = event || window.event;
        ePageX = event.pageX;
        ePageY = event.pageY;
        if (cloneDiv != undefined) {
            $("body").css("cursor", "move");
            cloneDiv.offset({
                top: ePageY,
                left: ePageX
            }).css("display", "block");
        }
    });

    //右键取消复制
    $("body").mousedown(function (e) {
        if (e.which == 3) {
            $("body").css("cursor", "auto");
            cloneDiv = null;
            sessionStorage.removeItem("containercloneDiv");
        }

    });

    //鼠标松开后触发
    $("body").mouseup(function (event) {

        event = event || window.event;
        ePageX = event.pageX;
        ePageY = event.pageY;
        if (cloneDiv != undefined && sessionStorage.getItem("containercloneDiv")!=null) {
            var midStr = cloneDiv.attr("mid");
            var mnameStr = cloneDiv.attr("mname");
            var mcontentStr = cloneDiv.attr("mcontent");
            var sizexStr = parseInt(cloneDiv.attr("Sizex"));
            var sizeyStr = parseInt(cloneDiv.attr("Sizey"));
            var colStr = Math.round(ePageX / gridSize);
            var rowStr = Math.round(ePageY / gridSize);
            //if (layouttype != null && layouttype == 2) {


            //}
            //else {
            //    gridster.add_widget("<div MID=" + midStr + " MName=" + mnameStr + " MContent=" + mcontentStr + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src='/iframes/" +
            //    mcontentStr + "'></iframe></div>", sizexStr, sizeyStr, colStr, rowStr);

            //}
            if (gridster.$widgets.length == 0) {
                gridster.add_widget("<div MID=" + midStr + " MName=" + mnameStr + " MContent=" + mcontentStr + " ><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src='/iframes/" +
            mcontentStr + "'></iframe></div>", sizexStr, sizeyStr, colStr, rowStr);
            }
            else {
                var downWidgets = gridster.get_widget_from_point(colStr, rowStr);
                downWidgets[0].childNodes[2].src = "/iframes/" + mcontentStr;
                downWidgets[0].attributes['mcontent'].value = mcontentStr;
                downWidgets[0].attributes['mname'].value = mnameStr;
                downWidgets[0].attributes['mid'].value = midStr;
            }
            sessionStorage.removeItem("containercloneDiv");
            cloneDiv = undefined;
        }

        $("body").css("cursor", "auto");
        //调用绑定模块上的事件
        BindEventForAddModule();
    });
    //调用绑定模块上的事件
    BindEventForAddModule();
}

//在添加模块后绑定模块上的事件
function BindEventForAddModule() {
    //模块关闭按钮事件
    $(".gridster div .module-close").click(function (e) {
        var moduleCurrentClose = $(this);
        var moduleCurrent = (moduleCurrentClose.parent()).parent();
        //取得模块元素将其移除
        gridster.remove_widget(moduleCurrent[0]);
    });

    $('.gridster div').contextmenu({
        target: '#context-menu2',
        before: function (e) {
            // This function is optional.
            // Here we use it to stop the event if the user clicks a span
            e.preventDefault();
            if (e.target.tagName == 'SPAN') {
                e.preventDefault();
                this.closemenu();
                return false;
            }
            //this.getMenu().find("li").eq(2).find('a').html("This was dynamically changed");
            return true;
        },
        onItem: function (context, e) {
            //e.currentTarget.textContent，tabIndex
            //取得当前右击模块的行列宽高
            var cWCol = parseInt(context.context.dataset.col);
            var cWRow = parseInt(context.context.dataset.row);
            var cWSizex = parseInt(context.context.dataset.sizex);
            var cWSizey = parseInt(context.context.dataset.sizey);

            //取得最小模块的宽、高并去掉宽、高一半及余数
            var cWSizexDivide = cWSizex % 2 == 0 ? (cWSizex / 2) : (cWSizex - 1) / 2;
            var cWSizeyDivide = cWSizey % 2 == 0 ? (cWSizey / 2) : (cWSizey - 1) / 2;



            var upW = gridster.get_widgets_width_byrow(cWCol, cWRow, 0, false);
            var downW = gridster.get_widgets_width_byrow(cWCol, cWRow, cWSizey, false);

            //取得指定模块上下列宽
            var upWAll = gridster.get_widgets_width_byrow(cWCol, cWRow, 0, true);
            var downWAll = gridster.get_widgets_width_byrow(cWCol, cWRow, cWSizey, true);

            //取得指定模块左侧行高及模块S
            var leftH = gridster.get_widgets_height_bycol(cWCol, cWRow);
            var leftWidgets = gridster.get_widgets_bycol(cWCol, cWRow);

            //取得指定模块右侧行高及模块S
            var rightH = gridster.get_widgets_height_bycol(cWCol, cWRow, cWSizex);
            var rightWidgets = gridster.get_widgets_bycol(cWCol, cWRow, cWSizex);

            //取得指定模块及右侧后面的所有对象
            var laterWidgets = gridster.get_widgets_from_bywidget("right", cWCol, cWRow, cWSizex, leftH);





            if (downW == undefined || downW == 0) {
                downW = gridCount - cWCol + 1;
            }
            switch (e.currentTarget.textContent) {
                case '上插入行':
                    addEmptyWidget_horizontal(upW, cWSizeyDivide, cWCol, cWRow);
                    break;
                case '下插入行':
                    addEmptyWidget_horizontal(downW, cWSizeyDivide, cWCol, cWRow + cWSizey);
                    break;
                case '左插入列':
                    cWSizexDivide = getWidgetSmallDivide(leftWidgets);
                    addEmptyWidget_vertical(cWSizexDivide, leftH, cWCol, cWRow, leftWidgets, laterWidgets, false, '', false);
                    break;
                case '右插入列':
                    cWSizexDivide = getWidgetSmallDivide(rightWidgets);
                    addEmptyWidget_vertical(cWSizexDivide, rightH, cWCol, cWRow, rightWidgets, rightWidgets, true, '', false);
                    break;
                case '水平拆分':
                    addEmptyWidget_horizontal_C(cWSizex, cWSizeyDivide, cWCol, cWRow, context, context, false);
                    break;
                case '纵向拆分':
                    addEmptyWidget_vertical(cWSizexDivide, cWSizey, cWCol, cWRow, context, context, false, '', false);
                    break;
                case '插入整行':
                    var $widgetsSortRow = gridster.get_widgets_byrow(cWCol, cWRow, 0, true);
                    var $widgetHear;
                    if ($widgetsSortRow) $widgetHear = $widgetsSortRow[0];
                    var hCol = parseInt($widgetHear.dataset.col);
                    var hRow = parseInt($widgetHear.dataset.row);
                    addEmptyWidget_horizontal(upWAll, cWSizeyDivide, hCol, hRow);
                    break;
                case '插入整列':
                    var $widgetsSortCol = gridster.get_widgets_bycol(cWCol, cWRow, 0, true);
                    var $widgetHearV;
                    if ($widgetsSortCol) $widgetHearV = $widgetsSortCol[0];
                    var hVCol = parseInt($widgetHearV.dataset.col);
                    var hVRow = parseInt($widgetHearV.dataset.row);
                    var hVSizex = parseInt($widgetHearV.dataset.sizex);

                    leftH = gridster.get_widgets_height_bycol(hVCol, hVRow);
                    leftWidgets = gridster.get_widgets_bycol(hVCol, hVRow);
                    laterWidgets = gridster.get_widgets_from_bywidget("right", hVCol, hVRow, hVSizex, leftH);

                    cWSizexDivide = getWidgetSmallDivide(leftWidgets);

                    addEmptyWidget_vertical(cWSizexDivide, leftH, hVCol, hVRow, leftWidgets, laterWidgets, false,'',false);
                    break;
                case '右插入容器':
                    cWSizexDivide = getWidgetSmallDivide(rightWidgets);
                    addEmptyWidget_vertical(cWSizexDivide, rightH, cWCol, cWRow, rightWidgets, rightWidgets, true, "/iframes/modelcontainer.html",true);
                    break;
                default:
            }
            return true;
        }
    });
}
//取得最小宽高一半
function getWidgetSmallDivide($widgets, direction) {
    var $widgetsSortSzie = [];

    $widgetsSortSzie = $widgets.sort(
        function (a, b) {
            if (direction) {
                var aSizey = parseInt(a.dataset.sizey);
                var bSizey = parseInt(b.dataset.sizey);
                if (aSizey < bSizey) return -1;
                if (aSizey > bSizey) return 1;
                return 0;
            } else {
                var aSizex = parseInt(a.dataset.sizex);
                var bSizex = parseInt(b.dataset.sizex);
                if (aSizex < bSizex) return -1;
                if (aSizex > bSizex) return 1;
                return 0;
            }
        }
    );

    var smW = $widgetsSortSzie[0];

    if (direction) {
        var smWy = parseInt(smW.dataset.sizey);
        return (smWy % 2 == 0 ? (smWy / 2) : (smWy - 1) / 2);
    } else {
        var smWx = parseInt(smW.dataset.sizex);
        return (smWx % 2 == 0 ? (smWx / 2) : (smWx - 1) / 2);
    }
}


//水平拆分
function addEmptyWidget_horizontal_C(sizex, sizey, dCol, dRow, $widgets, $laterWidgets, direction) {
    var upSizey = sizey;
    var downSizey = 0;

    if (direction) {
        upSizey = 0;
        downSizey = sizex;
    }

    var $widgetsSort = [];


    $widgetsSort = $laterWidgets.sort(
            function (a, b) {
                var aRow = parseInt(a.dataset.row);
                var bRow = parseInt(b.dataset.row);
                var aCol = parseInt(a.dataset.col);
                var bCol = parseInt(b.dataset.col);
                if (aCol > bCol) return -1;
                if (aCol < bCol) return 1;
                if (aRow > bRow && aCol == bCol) return -1;
                if (aRow < bRow && aCol == bCol) return 1;
                if (aRow == bRow && aCol == bCol) return 0;
                return 0;
            }
        );

    $.each($widgetsSort, function (i, element) {
        var eRow = parseInt(element.dataset.row);
        var eCol = parseInt(element.dataset.col);
        var eSizex = parseInt(element.dataset.sizex);
        var eSizey = parseInt(element.dataset.sizey);
        gridster.remove_widget(element);

        if (isHave($widgets, eCol, eRow)) {
            gridster.add_widget(element.outerHTML,
                eSizex, eSizey - sizey, dCol, dRow + upSizey);
            if (direction) {
                downSizey = eSizey - downSizey;
            }
        } else {
            gridster.add_widget(element.outerHTML,
                eSizex, eSizey, eCol, eRow);
        }

    });
    gridster.add_widget("<div MID='id1' MName='' MContent=''><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src=''></iframe></div>",
        sizex, sizey, dCol, dRow - downSizey);
}

//上下加行
function addEmptyWidget_horizontal(sizex, sizey, dCol, dRow, $widgets) {
    gridster.add_widget("<div MID='id1' MName='' MContent=''><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src=''></iframe></div>",
        sizex, sizey, dCol, dRow);
}
//左右加行
function addEmptyWidget_vertical(sizex, sizey, dCol, dRow, $widgets, $laterWidgets, direction,containerurl,iscontainer) {
    var rightSizex = sizex;
    var leftSizex = 0;

    //判断是在左边还是在右边默认为左边，设置为true则为右边
    if (direction) {
        rightSizex = 0;
        leftSizex = sizex;
    }

    var $widgetsSort = [];


    $widgetsSort = $laterWidgets.sort(
            function (a, b) {
                var aRow = parseInt(a.dataset.row);
                var bRow = parseInt(b.dataset.row);
                var aCol = parseInt(a.dataset.col);
                var bCol = parseInt(b.dataset.col);
                if (aRow > bRow) return -1;
                if (aRow < bRow) return 1;
                if (aRow == bRow && aCol > bCol) return -1;
                if (aRow == bRow && aCol < bCol) return 1;
                if (aRow == bRow && aCol == bCol) return 0;
                return 0;
            }
        );

    $.each($widgetsSort, function (i, element) {
        var eRow = parseInt(element.dataset.row);
        var eCol = parseInt(element.dataset.col);
        var eSizex = parseInt(element.dataset.sizex);
        var eSizey = parseInt(element.dataset.sizey);
        gridster.remove_widget(element);

        if (isHave($widgets, eCol, eRow)) {
            gridster.add_widget(element.outerHTML,
                eSizex - sizex, eSizey, dCol + rightSizex, dRow);
            if (direction) {
                leftSizex = eSizex - sizex;
            }
        } else {
            gridster.add_widget(element.outerHTML,
                eSizex, eSizey, eCol, eRow);
        }

    });
    if (iscontainer) {
        var framename = "modelcontainer.html?lid=" + containerindex;
        var mname = "modelcontainer" + containerindex;
        gridster.add_widget("<div MID='id1' MName='" + mname + "' MContent='"+framename+"'><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><iframe name='" + framename + "' src='" + containerurl + "'></iframe></div>",
        sizex, sizey, dCol + leftSizex, dRow);
        containerindex++;
    }
    else {        
        gridster.add_widget("<div MID='id1' MName='' MContent=''><header>|||<span class='module-close'><img src='/Image/Close_W.png' alt='关闭' class='img-rounded'></span></header><quilt></quilt><iframe src='" + containerurl + "'></iframe></div>",
        sizex, sizey, dCol + leftSizex, dRow);
    }
    
}

function isHave($widgets, eCol, eRow) {
    var isTrue = false;
    $.each($widgets, function (ndex, el) {
        var tcol = el.dataset.col;
        var trow = el.dataset.row;
        if (tcol == eCol && trow == eRow) {
            isTrue = true;
            return false;
        }
    });
    return isTrue;
}

//保存模块信息
function saveinfo() {
    //先保存容器布局信息
    var modelcontainers = new Array();
    $.each(gridster.$widgets, function (i,widget) {
        if (widget.attributes["mcontent"].value.indexOf("modelcontainer.html")>-1) {
            modelcontainers.push(widget.attributes["mcontent"].value);
        }
    });
    for (i = 0; i < modelcontainers.length; i++) {
        var lid = window.frames[modelcontainers[i]].saveinfo(layouttype);
        $.each(gridster.$widgets, function (j, widget) {
            if (widget.attributes["mcontent"].value == modelcontainers[i]) {
                widget.attributes["mcontent"].value = "containershow.html?lid="+lid;
                return false;
            }
        });        
    }
    //取得所有模块信息
    var models = gridster.serialize();


    var modellistsCurrentStr = sessionStorage.getItem("modellistsCurrentObj"); //获取b的值

    if (modellistsCurrentStr == undefined) {
        modellistsCurrentStr = '{"LID":0,"LName":"","LModelList":"","LayType":"1","TempType":"1","Owner":"everyone","BelongPage":"","Isusing":1,"Remark":"","ExtendFields1":"","ExtendFields2":"","ExtendFields3":"","CreateTime":""}';
    }
    var modellistsCurrentObj = JSON2.parse(modellistsCurrentStr);
    modellistsCurrentObj.LModelList = "{\"MaxID\":\"0\",\"_Items\":" + JSON2.stringify(models) + "}";

    if (modellistsCurrentObj.LID != undefined && modellistsCurrentObj.LID != null && modellistsCurrentObj.LID != 0
        && layouttype == 0) {
        layoutInfoService.UpdateUserLayoutinf(modellistsCurrentObj.Owner, modellistsCurrentObj.BelongPage,JSON.stringify(modellistsCurrentObj),
            function (data, status) {
                if (designthis != null && designthis == 1) {
                    window.location.href = modellistsCurrentObj.BelongPage;
                }
                else {
                    window.location.href = "index.html";
                }
            });
    } else {        
        modellistsCurrentObj.BelongPage = pagename;
        modellistsCurrentObj.TempType = modeltype;
        modellistsCurrentObj.LayType = 1;
        modellistsCurrentObj.CreateTime = new Date();
        if (layouttype == undefined || layouttype == 'undefined') {
            modellistsCurrentObj.LName = loginId + "自定义布局";
        }
        else if (layouttype == 2) {
            modellistsCurrentObj.LName = loginId + "使用布局模板" + modellistsCurrentObj.LName + "添加";
        }
        else {
            modellistsCurrentObj.LName = loginId + "使用详细模板" + modellistsCurrentObj.LName + "添加";;
        }
        layoutInfoService.AddUserLayoutinfsync(owner == null ? loginId : owner, pagename, JSON.stringify(modellistsCurrentObj),
                function (data, status) {
                    if (designthis != null && designthis == 1) {
                        window.location.href = pagename;
                    }
                    else {
                        window.location.href = "index.html"
                    }              
                });
            }
}

//加载事件
function BottomToolsLoad() {
    //Get our elements for faster access and set overlay width
    var div = $('div.sc_menu'),
        ul = $('ul.sc_menu'),
        ulPadding = 15;

    //Get menu width
    var divWidth = div.width();

    //Remove scrollbars	
    div.css({ overflow: 'hidden' });

    //Find last image container
    var lastLi = ul.find('li:last-child');

    //When user move mouse over menu
    div.mousemove(function (e) {
        //As images are loaded ul width increases,
        //so we recalculate it each time
        var ulWidth = lastLi[0].offsetLeft + lastLi.outerWidth() + ulPadding;
        var left = (e.pageX - div.offset().left) * (ulWidth - divWidth) / divWidth;
        div.scrollLeft(left);
    });
}

//window.onresize=function() {
//    var gridsett=gridster.$widgets;

//    sessionStorage.setItem("gridsterForResize", JSON2.stringify(gridster));

//    window.location.reload();
//}  


