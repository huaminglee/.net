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
}  // �u�X�Ҧ�����

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
}  // �u�X�Ҧ�����

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
}  // �u�X�Ҧ�����(�i�ǻ��Ѽ�)



function openNewWin(strUrl, width, height) {
    var win;
    var top = (screen.height - height) / 2 - 20;
    var left = (screen.width - width) / 2;
    win = window.open(strUrl, "NewWindow", "toolbar=no,width=" + width + ",height=" + height + ",menubar=no,scrollbars=yes,resizable=no,status=no,center=yes,top=" + top + ",left=" + left);
    win.focus();
}  //���}�@�ӷs����

function openNewWin(strUrl, strName) {
    var win;
    var height = screen.height * 0.4;
    var width = screen.width * 0.4;
    var top = (screen.height - height) / 2 - 20;
    var left = (screen.width - width) / 2;
    win = window.open(strUrl, strName, "toolbar=no,width=" + width + ",height=" + height + ",menubar=no,scrollbars=yes,resizable=no,status=no,center=yes,top=" + top + ",left=" + left);
    win.focus();
}  //���}�@�ӷs����


function openNewWinAutoMaximize(strUrl, strName) {
    var win;
    win = window.open(strUrl, strName, "toolbar=no,menubar=yes,scrollbars=yes,resizable=yes,status=yes");
    win.focus();
    win.moveTo(0, 0);
    win.resizeTo(screen.availWidth, screen.availHeight);
}  // �u�X�@�ӳ̤j�ƪ��L�u�������		


function openNewWinAutoMaxWithoutToolbar(strUrl, strName) {
    var win;
    win = window.open(strUrl, strName, "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,status=yes");
    win.focus();
    win.moveTo(0, 0);
    win.resizeTo(screen.availWidth, screen.availHeight);
} // �u�X�@�ӳ̤j�ƪ����u�������	


function freshParentWindow() {
    var oP;
    if (window.opener != null)
        oP = window.opener;
    else
        if (window.parent != null)
        oP = window.parent;
    if (oP != null) oP.location.href = oP.location.href;
}  //��s������,�����ɦb�l����W��s�ɷ|����



//function freshParentWindow() {
//    var oP;
//    if (window.opener != null)
//        oP = window.opener;
//    else
//        if (window.parent != null)
//        oP = window.parent;
//    if (oP != null) oP.location.reload();
//}  //��s������,�����ɦb�l����W��s�ɷ|����

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
}  //��s������


function closeSelf() {
    window.close();
}  //��������
