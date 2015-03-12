/*
    index.htmlҳ����û�JS
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

    //���õ�Ԫ����и���
    gridCount = 48;
    //�����Ԫ���С
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
    //����ҳ��
    LoadPageModel();

    //����ƶ��͵����ʵ��Ƥ��Ԥ��
    $("#skinContainer div img").mouseover(function () {
        $("#skinEffectContainer img").attr("src", $(this).attr("src"));
    });

    $("#skinContainer div").click(function () {
        $(this).siblings().children("div").remove(".glyphicon");
        selectSkin = $(this).children("img").attr("src");
        $(this).prepend("<div style='float: left;position: absolute;color: green;top:auto;' class='glyphicon glyphicon-ok-sign'></div>");
    });

    //Ԥ������ʾѡ�е�Ƥ��Ч��
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
                var objTemp = $.parseJSON(data); //ת����JSON����
                //�����û�Ƥ��
                if (objTemp != null && objTemp.Sname !=null&& objTemp.Sname != "") {
                    var skinPathFileName = objTemp.Sname.split('.');
                    if (skinPathFileName&&skinPathFileName.length > 0) {
                        var skinFileName = skinPathFileName[0].split('/');
                        if (skinFileName&&skinFileName.length > 0) {
                            skinName = "myskin/" + skinFileName[skinFileName.length - 1] + ".css";
                            sessionStorage.setItem("skinName", skinName);
                            sessionStorage.setItem("skinFileName", skinFileName[skinFileName.length - 1]);
                            $("link[href*='myskin']").attr("href", skinName);
                            //ʵ��iframe�Ļ�������
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
                                        //���ģ��Ƥ���Ƿ����,��������Ϊ��loģ�黻��
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
                            }//iframe��������
                        }//�����û�Ƥ������
                    }
                }

                //����Ƥ��Ԥ��Ƥ����ѡ��Ƥ��
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
    ����Ƥ��
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
                //ʵ��iframe�Ļ�������
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
                            //���ģ��Ƥ���Ƿ����,��������Ϊ��ģ�黻��(��AJAX��������⣬���ֻ�����һ����֤��Ч)
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
                }//iframe��������
            }
           
        }
    }

    //����Ƥ��ʱ�ȼ���û�Ƥ��������û��Ѿ�ѡ�������£���������
    skinInfoService.GetUserSkinInfo(
        function (data, status) {
            var objTemp = $.parseJSON(data); //ת����json����
            var newSkinInfo = {
                "SID": 0,
                "Uid": skinInfoService.loginId,
                "Sname": selectSkin
            };
            if (selectSkin==null) {
                alert("����ѡ��Ƥ��");
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
    ҳ�沼�ֹ������
*/

//������ҳ����
function savaLayoutInfo() {
    //ȡ������ģ����Ϣ
    var models = gridster.serialize();
    var newlayinfo =
    {
        "LID": 0,
        "LName": "��ҳĬ�ϲ���",
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

//������ҳ����
function loadModellistAll(modellistAll) {
    //��������ģ�鵽��ǰҳ��Ĺ�������
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
            var objTemp = $.parseJSON(data); //ת����������
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
        
            //��̬����ģ��
            var modellistsCurrent = $.parseJSON(objTemp.LModelList)._Items; //��ŵ�ǰģ���е�ģ��
            loadModellistAll(modellistsCurrent);
            loadUserSkin();
        });
}
//�����޸�����
function savePass() {
    var oldPassword = $("#oldPassword").val();
    var newPassword = $("#newPassword").val();
    var rePassword = $("#rePassword").val();

    if (newPassword != rePassword) {
        layer.tips('������������벻һ��', $("#rePassword"), {
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
                            alert("�޸ĳɹ�");
                        }
                        else {
                            alert("�޸�ʧ��");
                        }
                    }
                    else {
                        alert("�޸�ʧ��");
                    }
                    $("#saveBtn").button('reset');
                });
    }
}
function setpagename(cpagename) {
    pagename = cpagename;
}
//�����޸������
function modalUpdatePass() {
    $("#oldPassword").val("");
    $("#newPassword").val("");
    $("#rePassword").val("");
    $('#updatePassword').modal("show");
}
//����Ƥ�������
function modalUserSkin() {
    $('#myModal').modal("show");
}

