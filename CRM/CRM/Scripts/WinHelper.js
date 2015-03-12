///==========================Web window ==============================
function ShowModalDialog(url) {
    var pointX;
    var pointY;
    var param;
    var returnV;
    var height = screen.height * 0.4;
    var width = screen.width * 0.4;
    pointY = (screen.height - height) / 2;
    pointX = (screen.width - width) / 2;
    param = 'dialogLeft:' + pointX + ';dialogTop:' + pointY + ';dialogHeight:"+height+"px;dialogWidth:"+width+"px;center:No;help:No;scroll:Yes;resizable:yes;status:No;'
    returnV = window.showModalDialog(url, 0, param);
    return returnV;
}  // 彈出模式窗體

function ShowModalDialog(url, WindowWidth, WindowHeight) {
    var pointX;
    var pointY;
    var param;
    var returnV;
    var height = WindowHeight;
    var width = WindowWidth;
    pointY = (screen.height - height) / 2;
    pointX = (screen.width - width) / 2;
    param = "dialogLeft:" + pointX + ";dialogTop:" + pointY + ";dialogHeight:" + height + "px;dialogWidth:" + width + "px;center:No;help:No;scroll:Yes;resizable:yes;status:No;"
    returnV = window.showModalDialog(url, 0, param);
    return returnV;
}  // 彈出模式窗體

function ShowModalDialogByParams(url,Params,WindowWidth, WindowHeight) {
    var pointX;
    var pointY;
    var Styleparam;
    var returnV;
    var height = WindowHeight;
    var width = WindowWidth;
    pointY = (screen.height - height) / 2;
    pointX = (screen.width - width) / 2;
    Styleparam = "dialogLeft:" + pointX + ";dialogTop:" + pointY + ";dialogHeight:" + height + "px;dialogWidth:" + width + "px;center:No;help:No;scroll:Yes;resizable:yes;status:No;"
    returnV = window.showModalDialog(url, Params, Styleparam);
    return returnV;
}  // 彈出模式窗體(可傳遞參數)



function openNewWin(strUrl, width, height) {
    var win;
    var top = (screen.height - height) / 2 - 20;
    var left = (screen.width - width) / 2;
    win = window.open(strUrl, "NewWindow", "toolbar=no,width=" + width + ",height=" + height + ",menubar=no,scrollbars=yes,resizable=no,status=no,center=yes,top=" + top + ",left=" + left);
    win.focus();
}  //打開一個新窗體

function openNewWin(strUrl, strName) {
    var win;
    var height = screen.height * 0.4;
    var width = screen.width * 0.4;
    var top = (screen.height - height) / 2 - 20;
    var left = (screen.width - width) / 2;
    win = window.open(strUrl, strName, "toolbar=no,width=" + width + ",height=" + height + ",menubar=no,scrollbars=yes,resizable=no,status=no,center=yes,top=" + top + ",left=" + left);
    win.focus();
}  //打開一個新窗體


function openNewWinAutoMaximize(strUrl, strName) {
    var win;
    win = window.open(strUrl, strName, "toolbar=no,menubar=yes,scrollbars=yes,resizable=yes,status=yes");
    win.focus();
    win.moveTo(0, 0);
    win.resizeTo(screen.availWidth, screen.availHeight);
}  // 彈出一個最大化的無工具條窗體		


function openNewWinAutoMaxWithoutToolbar(strUrl, strName) {
    var win;
    win = window.open(strUrl, strName, "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,status=yes");
    win.focus();
    win.moveTo(0, 0);
    win.resizeTo(screen.availWidth, screen.availHeight);
} // 彈出一個最大化的有工具條窗體	


function freshParentWindow() {
    var oP;
    if (window.opener != null)
        oP = window.opener;
    else
        if (window.parent != null)
        oP = window.parent;
    if (oP != null) oP.location.href = oP.location.href;
}  //刷新父窗體,但有時在子窗體上刷新時會失效



//function freshParentWindow() {
//    var oP;
//    if (window.opener != null)
//        oP = window.opener;
//    else
//        if (window.parent != null)
//        oP = window.parent;
//    if (oP != null) oP.location.reload();
//}  //刷新父窗體,但有時在子窗體上刷新時會失效

function refreshParent() {
    if (window.opener != null) {
        window.opener.location.href = window.opener.location.href;
        if (window.opener.progressWindow) {
            window.opener.progressWindow.close();
        }
    }
    else {
        if (window.parent != null) {
            window.parent.location.reload();
        }
    }
    window.close();
}  //刷新父窗體


function closeSelf() {
    window.close();
}  //關閉窗體
