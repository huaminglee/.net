/*

 @Name: pengesoft 基础服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function BaseService(baseUrl) {
    this.baseUrl = baseUrl; //服务基础地址
    this.uTag = "";         //登录码
    this.loginId = "";      //登录名
    this.loginResult = $.parseJSON(sessionStorage.getItem("LoginResult"));//登录结果对象

    //初始化登录名、登录码
    if (this.loginResult != null) {
        this.uTag = this.loginResult.Utag;
        this.loginId = this.loginResult.LoginId;
    }

    //定义方法
    this.Post = function (url, data, callback) {
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        //POST方式 - 向指定的资源提交要处理的数据
        return $.post(url, data, callback);
    }
}
