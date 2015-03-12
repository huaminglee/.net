var userBaseInfoService = new UserBaseInfoService();
var messageService = new MessageService();

$(function () {
    var msgCount = sessionStorage.getItem("MsgCount");
    
    if ($("#suname") && $("#suname").length > 0) {
        $("#suname")[0].innerHTML = userBaseInfoService.loginResult.FullName;
    }
    if (msgCount > 0) {
        $("#messagecount").text(msgCount);
        $("#msg_comment").fadeOut(800).fadeIn(800)
    }


    //每五秒执行一次refreshMsg方法
    window.setInterval("refreshMsg()", 5000);
    //不停地闪烁消息图标
    window.setInterval("twinkle()", 800);
});
//跳转至设计页面
function goIndexDesign() {
    window.parent.location.href = "../indexDesign.html?designthis=1&lid=" + sessionStorage.getItem("LIDindex") + "&layouttype=" + sessionStorage.getItem("TempTypeindex") + "&pagename=" + sessionStorage.getItem("PageNameindex") + "&owner=" + $.parseJSON(sessionStorage.getItem("LoginResult")).LoginId + "&modeltype=2";
}
//退出系统
function logout() {
    parent.layer.confirm("您要退出系统吗", function () {
        userBaseInfoService.Logout(
        function (data, status) {
            //确认退出
            sessionStorage.removeItem("LoginResult");
            window.parent.location.href = "../login.html";
        });
    })
}
//定时刷新系统消息
function refreshMsg() {
    messageService.QueryMessageCount(1,
        function (data, status) {
            //判断是否有新消息
            if (parseInt(data) > 0) {
                $("#messagecount").text(data);
            }
            else {
                $("#messagecount").text("");
            }
            sessionStorage.setItem("MsgCount", data);
        });
}
//闪烁消息
function twinkle() {
    $("#messagecount").text() == "" ? $("#msg_comment").stop() : $("#msg_comment").fadeOut(800).fadeIn(800);
}
//弹出修改密码层
function UpdetePass() {
    //修改密码
    window.parent.modalUpdatePass();
}
//弹出皮肤管理层
function modalSkin() {
    window.parent.modalUserSkin();
}