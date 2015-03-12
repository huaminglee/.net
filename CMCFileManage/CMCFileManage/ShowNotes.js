$(function() {
LoadMessage(-3);
});
var Initload = 0;

var i = 0;
var timeout = 20000;
function LoadMessage(SerType) {
    $.ajax({
        url: "action/WebService.asmx/GetSysNews",
        data: { 'SercvicePKID': "" + SerType + "" },
        dataType: 'xml',
        type: "post",
        success: function(result) {
            var PagePiaoFu = "[";
            var PageTopContent = "";
            $(result).find("Table").each(function() {

                var adType = $(this).find("AdInfoType").text();
                var Ptitle = $(this).find("NewTitle").text();
                var PContent = myHTMLDeCode($(this).find("NewContent").text());
                //if (adType == "0") {
                $.messager.defaults = { ok: "關閉)" };
                $.messager.show({ width: 300, height: 200, title: Ptitle, msg: PContent, timeout: timeout, showType: 'fade' });
                timeout = timeout - 5000;

                //                }
                //                else if (adType == "1") {
                //                    $.messager.defaults = { ok: "關閉)" };
                //                    $.messager.alert(Ptitle, PContent);
                //                }
                //                else if (adType == "2") {
                //                    PContent = "<div>" + PContent + "</div>";
                //                    PagePiaoFu = PagePiaoFu + "{'img':'" + PContent + "','title':'" + Ptitle + "','z-index':'100'},";
                //                }
                //                else if (adType == "3") {
                //                    PageTopContent = PageTopContent + PContent;
                //                }
            });
            if (PagePiaoFu.length > 2) {
                PagePiaoFu = PagePiaoFu.substring(0, PagePiaoFu.length - 1);
                PagePiaoFu = PagePiaoFu + ']';
                PagePiaoFu = eval(PagePiaoFu);
                $.floatingAd({ delay: 60, isLinkClosed: true, ad: PagePiaoFu });
            }
            if (PageTopContent != "") {
                PageBT(PageTopContent);
            }
        },
        error: function(x, e, errorThrown) {
            alert(x.responseText);
        }
    });
}
function myHTMLEnCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, "&amp;");
    s = s.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    // s = s.replace(/ /g, "&nbsp;");
    s = s.replace(/\'/g, "&#39;");
    s = s.replace(/\"/g, "&quot;");
    s = s.replace(/\n/g, "<br>");
    return s;
}

function myHTMLDeCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&amp;/g, "&");
    s = s.replace(/&lt;/g, "<");
    s = s.replace(/&gt;/g, ">");
    // s = s.replace(/&nbsp;/g, " ");
    s = s.replace(/&#39;/g, "\'");
    s = s.replace(/&quot;/g, "\"");
    s = s.replace(/<br>/g, "\n");
    return s;
}
var piaofuClose = 0;
function PageBT(DivContent) {
    DivContent = DivContent + " <p align=\"right\"><a href=JavaScript:; onclick=\"ads.style.visibility='hidden';ads.style.display='none';piaofuClose=1;\"><img border=0 src=../Images/close1.gif></a></p>";
    //加載打開該頁面時查找廣告並顯示，然後兩分鐘後自動消失
    var refresh_tab = $('#tabs').tabs('getSelected');
    var refresh_tab = $('#tabs').tabs('getSelected');
    if (refresh_tab && refresh_tab.find('iframe').length > 0) {
        var _refresh_ifram = refresh_tab.find('iframe')[0];
        if (_refresh_ifram.attachEvent) {
            _refresh_ifram.attachEvent("onload", function() {
                if (piaofuClose == 0) {
                    var IframeWindow = _refresh_ifram.contentWindow;

                    var div = document.createElement("div");
                    div.setAttribute('id', 'ads');
                    div.setAttribute('style', 'display:none;');
                    div.innerHTML = DivContent;
                    IframeWindow.document.body.insertBefore(div, IframeWindow.document.body.firstChild);
                    var ads = $(window.frames[_refresh_ifram.id].document).find("#ads");
                    ads.slideDown(3000, function() {
                        setTimeout(function() { ads.slideUp(3000); piaofuClose = 1; }, 6000);
                    });

                }
            });
        }
    }
}