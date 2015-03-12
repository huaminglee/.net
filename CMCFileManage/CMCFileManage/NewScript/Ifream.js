function SetContent(ContentUrl, name, ShowSub) {
    document.getElementById("rightiframe").src = ContentUrl
    return false;
}
$(function() {
    //    if (window.screen) {
    //        window.moveTo(0, 0); //登錄系統使窗體最大化
    //        window.resizeTo(screen.availWidth, screen.availHeight);
    //    }
    var topifram = document.getElementById("topiframe");
    var leftiframe = document.getElementById("leftiframe");
    var rightiframe = document.getElementById("rightiframe");
    var IEwidth = $(window).width();
    var IEheigth = $(window).height();
    var topweb = document.frames ? document.frames["topiframe"].document : ifm.contentDocument;
    var leftweb = document.frames ? document.frames["leftiframe"].document : ifm.contentDocument;
    var rightweb = document.frames ? document.frames["rightiframe"].document : ifm.contentDocument;
    // document.getElementById("content").width = IEwidth - 20;

    if (topifram != null && topweb != null && topweb.body != null) {
        topifram.height = topweb.body.scrollHeight;
        topifram.width = IEwidth;
    }
    if (leftiframe != null && leftweb != null) {
        leftiframe.height = IEheigth - topifram.height-5 ;
    }
    if (rightiframe != null && rightweb != null) {
        rightiframe.height = IEheigth - topifram.height-5 ;
        rightiframe.width = IEwidth - 200;

    }
    if ($('#HidInitUrl').val() != "") {
        SetContent($('#HidInitUrl').val(), $('#HidInitTitle').val());
    }
   
});
function windresize() {
    var topifram = document.getElementById("topiframe");
    var leftiframe = document.getElementById("leftiframe");
    var rightiframe = document.getElementById("rightiframe");
    var IEwidth = $(window).width();
    var IEheigth = $(window).height();
    var topweb = document.frames ? document.frames["topiframe"].document : ifm.contentDocument;
    var leftweb = document.frames ? document.frames["leftiframe"].document : ifm.contentDocument;
    var rightweb = document.frames ? document.frames["rightiframe"].document : ifm.contentDocument;
  //  document.getElementById("content").width = IEwidth - 20;

    if (topifram != null && topweb != null && topweb.body != null) {
        topifram.height = topweb.body.scrollHeight;
        topifram.width = IEwidth;
    }
    if (leftiframe != null && leftweb != null) {
        leftiframe.height = IEheigth - topifram.height-5 ;
    }
    if (rightiframe != null && rightweb != null) {
        rightiframe.height = IEheigth - topifram.height-5 ;
        rightiframe.width = IEwidth -180;

    }
   
}
function iFrameHeight() {
    var IEwidth = $(window).width();
    var IEheigth = $(window).height();
    var rightiframe = document.getElementById("rightiframe");
    var topifram = document.getElementById("topiframe");
    var rightweb = document.frames ? document.frames["rightiframe"].document : ifm.contentDocument;
    if (rightiframe != null && rightweb != null) {
        rightiframe.height = IEheigth - topifram.height - 20;
        rightiframe.width = IEwidth - 180;

    }
//    var ifm = document.getElementById("rightiframe");
//    var subWeb = document.frames ? document.frames["rightiframe"].document : ifm.contentDocument;
//   
//        var IEwidth = $(window).width() < 850 ? 820 : $(window).width() - 2;
//        if (ifm != null && subWeb != null) {
//            if (subWeb.body.scrollHeight + 20 < 450) {
//                ifm.height = 450
//                if (IEwidth - 300 < 800) {
//                    ifm.width = 800;
//                }
//                else {
//                    ifm.width = IEwidth - 300;
//                }

//            }
//            else {
//                if (IEwidth - 300 < 800) {
//                    ifm.width = 800;
//                }
//                else {
//                    ifm.width = IEwidth - 300;
//                }
//                ifm.height = subWeb.body.scrollHeight + 20;
//            }
//        }
    
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
