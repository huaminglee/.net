/*
    index.html页面的用户JS
*/
var pagename;
var gridster;
var selectSkin = null;
var savedSkin = null;
var skinName;
var userBaseInfoService = new UserBaseInfoService();
var skinInfoService = new SkinInfoService();
var layoutInfoService = new LayoutInfoService();

$(function () {
    if (userBaseInfoService.loginResult == null && pagename != "login.html") {
        window.location.href = "login.html";
        return;
    }

    //设置单元格的行个数
    gridCount = 48;
    //算出单元格大小
    gridSize = Math.round(($(window).width()-20) / gridCount);
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
    //加载页面
    LoadPageModel();

    //鼠标移动和点击，实现皮肤预览
    $("#skinContainer div img").mouseover(function () {
        $("#skinEffectContainer img").attr("src", $(this).attr("src"));
    });

    $("#skinContainer div").click(function () {
        $(this).siblings().children("div").remove(".glyphicon");
        selectSkin = $(this).children("img").attr("src");
        $(this).prepend("<div style='float: left;position: absolute;color: green;top:auto;' class='glyphicon glyphicon-ok-sign'></div>");
    });

    //预览区显示选中的皮肤效果
    $("#skinContainer").mouseout(function () {
        if (selectSkin != null) {
            $("#skinEffectContainer img").attr("src", selectSkin);
        }
    });
});

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}
function loadUserSkin() {
    skinInfoService.GetUserSkinInfo(
         function (data, status) {
            if (data != null && data != "") {
                var objTemp = $.parseJSON(data); //转换成JSON数据
                //加载用户皮肤
                if (objTemp != null && objTemp.Sname !=null&& objTemp.Sname != "") {
                    var skinPathFileName = objTemp.Sname.split('.');
                    if (skinPathFileName&&skinPathFileName.length > 0) {
                        var skinFileName = skinPathFileName[0].split('/');
                        if (skinFileName&&skinFileName.length > 0) {
                            skinName = "myskin/" + skinFileName[skinFileName.length - 1] + ".css";
                            sessionStorage.setItem("skinName", skinName);
                            sessionStorage.setItem("skinFileName", skinFileName[skinFileName.length - 1]);
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
                                        if(skinHref.length>1)
                                            iframeSkinTemp.attr("href", "/myskin/" + skinFileName[skinFileName.length - 1] + "-" + skinHref[skinHref.length - 1]);
                                        else {
                                            iframeSkinTemp.attr("href", "/myskin/" + skinFileName[skinFileName.length - 1] + ".css");
                                        }
                                        //if (window.frames[i].name.indexOf("containershow.html") > -1) {
                                        //    window.frames[i].loadskin(skinName);
                                        //}
                                        //检查模块皮肤是否存在,不存在则不为该lo模块换肤
                                        //$.ajax("../../myskin/" + skinFileName[skinFileName.length - 1] + "-" + skinHref[skinHref.length - 1],
                                        //    {
                                        //        type: "get",
                                        //        timeout: 10000,
                                        //        success: function () {
                                        //            iframeSkinTemp.attr("href", "../myskin/" + skinFileName[skinFileName.length - 1] + "-" + skinHref[skinHref.length - 1]);
                                        //        },
                                        //        error: function () { }
                                        //    }
                                        //);
                                    }
                                } 
                            }//iframe换肤结束
                        }//加载用户皮肤结束
                    }
                }

                //设置皮肤预览皮肤和选中皮肤
                selectSkin = objTemp.Sname;
                $("#skinEffectContainer img").attr("src", objTemp.Sname);
                $("#skinContainer div").find("img[src='" + objTemp.Sname + "']").each(function () {
                    $(this).siblings("div").remove(".glyphicon");
                    $(this).parent("div").prepend("<div style='float: left;position: absolute;color: green;top:auto;' class='glyphicon glyphicon-ok-sign'></div>");
                });
            }
        });
}

/*
    保存皮肤
*/
function saveSkin() {
    if (selectSkin != null) {
        var skinPathFileName = selectSkin.split('.');
        if (skinPathFileName.length > 0) {
            var skinFileName = skinPathFileName[0].split('/');
            if (skinFileName.length > 0) {
                var skinName = "myskin/" + skinFileName[skinFileName.length - 1] + ".css";
                sessionStorage.setItem("skinName", skinName);
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
                            if (window.frames[i].name.indexOf("containershow.html") > -1) {
                                window.frames[i].changeskin(selectSkin);
                            }
                            //检查模块皮肤是否存在,不存在则不为该模块换肤(用AJAX检查有问题，造成只有最后一次验证有效)
                            //$.ajax("../../myskin/" + skinFileName[skinFileName.length - 1]+"-" + skinHref[skinHref.length - 1],
                            //    {
                            //        type: "get",
                            //        timeout: 10000,
                            //        success: function () {
                            //            iframeSkinTemp.attr("href", "../myskin/" + skinFileName[skinFileName.length - 1] + "-" + skinHref[skinHref.length - 1]);
                            //        },
                            //        error: function () {
                            //        }
                            //    }
                            //);
                        }
                    }
                }//iframe换肤结束
            }
           
        }
    }

    //保存皮肤时先检查用户皮肤，如果用户已经选择过则更新，否则新增
    skinInfoService.GetUserSkinInfo(
        function (data, status) {
            var objTemp = $.parseJSON(data); //转换成json数据
            var newSkinInfo = {
                "SID": 0,
                "Uid": skinInfoService.loginId,
                "Sname": selectSkin
            };
            if (selectSkin==null) {
                alert("请先选择皮肤");
                return;
            }
            if (objTemp.SId!=0) {
                skinInfoService.UpdateUserSkinInfo(JSON.stringify(newSkinInfo),
                     function (data, status) {
                     });
            } else {
                skinInfoService.AddUserSkinInfo(JSON.stringify(newSkinInfo),
                    function (data, status) {
                    });
            }
        }
    );

}

/*
    页面布局管理操作
*/

//保存首页布局
function savaLayoutInfo() {
    //取得所有模块信息
    var models = gridster.serialize();
    var newlayinfo =
    {
        "LID": 0,
        "LName": "首页默认布局",
        "LModelList": "{\"MaxID\":\"0\",\"_Items\":" + JSON2.stringify(models) + "}",
        "LayType": "1",
        "TempType": "",
        "Owner": "",
        "BelongPage": pagename,
        "Remark": "",
        "ExtendFields1": "",
        "ExtendFields2": "",
        "ExtendFields3": "",
        "CreateTime": null
    };

    layoutInfoService.AddUserLayoutinf(pagename, JSON.stringify(newlayinfo),
        function (data, status) {
        });
}

//加载首页布局
function loadModellistAll(modellistAll) {
    //加载所有模块到当前页面的工具栏上
    if (modellistAll != undefined && modellistAll != null) {
        for (var i = 0; i < modellistAll.length; i++) {
            var modelObj = modellistAll[i];
            gridster.add_widget("<li MID=" + modelObj.MId + " MName=" + modelObj.MName + " MContent=" + modelObj.MContent + "><div class='iframecontain'><iframe name='" + modelObj.MContent + "' id='" + modelObj.MName + "' src='/iframes/" + modelObj.MContent + "'></iframe></div></li>", modelObj.Sizex, modelObj.Sizey, modelObj.DCol, modelObj.DRow).css("background", "white");
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

function LoadPageModel() {
    layoutInfoService.GetUserLayoutinfo(pagename, "everyone",
        function (data, status) {
            var objTemp = $.parseJSON(data); //转换出总条数
            var TempType = 0;

            if (objTemp.TempType == 1) {
                TempType = 1;
            }
            if (pagename == "index.html") {
                sessionStorage.setItem("LIDindex", objTemp.LID);
                sessionStorage.setItem("TempTypeindex", TempType);
                sessionStorage.setItem("PageNameindex", pagename);
            }
            sessionStorage.removeItem("LID");
            sessionStorage.setItem("LID", objTemp.LID);
            sessionStorage.setItem("TempType", TempType);
            sessionStorage.setItem("PageName", pagename);
        
            //动态加载模块
            var modellistsCurrent = $.parseJSON(objTemp.LModelList)._Items; //存放当前模板中的模块
            loadModellistAll(modellistsCurrent);
            loadUserSkin();
        });
}
//保存修改密码
function savePass() {
    var oldPassword = $("#oldPassword").val();
    var newPassword = $("#newPassword").val();
    var rePassword = $("#rePassword").val();

    if (newPassword != rePassword) {
        layer.tips('两次输入的密码不一致', $("#rePassword"), {
            guide: 2,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        $("#saveBtn").button('loading');
        var md5OldPass = "";
        if (oldPassword != "")
            md5OldPass = b64_md5("P%y2K&ja" + oldPassword);
        var md5newPass = "";
        if (newPassword != "")
            md5newPass = b64_md5("P%y2K&ja" + newPassword);

        userBaseInfoService.ChangePass(md5OldPass, md5newPass,
                function (data, status) {
                    if (data == "0") {
                        var result = $.parseJSON(data);
                        if (result == "0") {
                            $("#updatePassword").modal("toggle");
                            alert("修改成功");
                        }
                        else {
                            alert("修改失败");
                        }
                    }
                    else {
                        alert("修改失败");
                    }
                    $("#saveBtn").button('reset');
                });
    }
}
function setpagename(cpagename) {
    pagename = cpagename;
}
//弹出修改密码层
function modalUpdatePass() {
    $("#oldPassword").val("");
    $("#newPassword").val("");
    $("#rePassword").val("");
    $('#updatePassword').modal("show");
}
//弹出皮肤管理层
function modalUserSkin() {
    $('#myModal').modal("show");
}

