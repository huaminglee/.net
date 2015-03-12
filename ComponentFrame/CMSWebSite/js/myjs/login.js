var userBaseInfoService = new UserBaseInfoService();

//键盘监听
$(function () {
    $("#txtuserid").val(userBaseInfoService.loginId);
    document.onkeydown = function (evt) {
        var evt = window.event ? window.event : evt;
        //按下回车键提交
        if (evt.keyCode == 13) {
            login();
        }
    }
});
//登录
function login() {
    var loginid = $("#txtuserid").val();
    var password = $("#txtpassword").val();
    var md5Str = "";
    if (password!="")
        md5Str = b64_md5("P%y2K&ja" + password);
        
    if (loginid == "") {
        layer.tips('请输入登陆账号', $("#txtuserid"), {
            guide: 1,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        userBaseInfoService.Login(loginid, md5Str, "",
            function (data, status) {
                if (status == "success" || status == "ok") {
                    var result = $.parseJSON(data);
                    if (result.Code == "0") {
                        sessionStorage.setItem("LoginResult", data);
                        window.parent.location.href = "../index.html"
                    }
                    else {
                        alert(result.Msg);
                    }
                }
            });
    }
}