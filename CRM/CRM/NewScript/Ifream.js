function SetContent(ContentUrl, name, ShowSub) {
    $('#iframe1')[0].src = ContentUrl
    return false;
}
$(function() {
    if (window.screen) {
        window.moveTo(0, 0); //登錄系統使窗體最大化
        window.resizeTo(screen.availWidth, screen.availHeight);

    }

    if ($('#HidInitUrl').val() != "") {
        SetContent($('#HidInitUrl').val(), $('#HidInitTitle').val());
    }

});
function iFrameHeightadd() {
    var ifm = document.getElementById("iframe1");
    var subWeb = document.frames ? document.frames["iframe1"].document : ifm.contentDocument;
    if (ifm != null && subWeb != null) {
        if (subWeb.body.scrollHeight + 20 < 540) {
            ifm.height = 750;
        }
        else {
            ifm.height = subWeb.body.scrollHeight + 300;
        }
    }

}
function iFrameHeight() {
    var ifm = document.getElementById("iframe1");
    var subWeb = document.frames ? document.frames["iframe1"].document : ifm.contentDocument;
   
        var IEwidth = $(window).width() < 850 ? 820 : $(window).width() - 2;
        if (ifm != null && subWeb != null) {
            if (subWeb.body.scrollHeight <500) {
                ifm.height = 560;
                if (IEwidth - 300 < 800) {
                    ifm.width = 800;
                }
                else {
                    ifm.width = IEwidth - 300;
                }

            }
            else {
                if (IEwidth - 300 < 800) {
                    ifm.width = 800;
                }
                else {
                    ifm.width = IEwidth - 300;
                }
                ifm.height = subWeb.body.scrollHeight+60;
            }
        }
    
}

function dyniframesize(down) {
    var pTar = null;
    if (document.getElementById) {
        pTar = document.getElementById(down);
    }
    else {
        eval('pTar = ' + down + ';');
    }
    if (pTar && !window.opera) {
        //begin resizing iframe 
        pTar.style.display = "block"
        if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) {
            //ns6 syntax 
            pTar.height = pTar.contentDocument.body.offsetHeight + 20;
            pTar.width = pTar.contentDocument.body.scrollWidth;
        }
        else if (pTar.Document && pTar.Document.body.scrollHeight) {
            //ie5+ syntax 
            pTar.height = pTar.Document.body.scrollHeight + 20;
            pTar.width = pTar.Document.body.scrollWidth;
        }
    }
}