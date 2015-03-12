/*

 @Name: pengesoft 皮肤管理服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function SkinInfoService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/SkinInfoService.assx");
}
//继承基类的方法
SkinInfoService.prototype = new BaseService();

//定义自己的方法体
SkinInfoService.prototype = {
    //查询用户皮肤信息
    GetUserSkinInfo: function (callback) {
        this.Post(
            this.baseUrl + "/GetUserSkinInfo",
            { uTag: this.uTag, UserID: this.loginId },
            callback);
    },

    //添加用户皮肤信息
    AddUserSkinInfo: function (TSkinInfo, callback) {
        this.Post(
            this.baseUrl + "/AddUserSkinInfo",
            { uTag: this.uTag, UserID: this.loginId, TSkinInfo: TSkinInfo },
            callback);
    },

    //更新用户皮肤信息
    UpdateUserSkinInfo: function (TSkinInfo, callback) {
        this.Post(
            this.baseUrl + "/UpdateUserSkinInfo",
            { uTag: this.uTag, UserID: this.loginId, TSkinInfo: TSkinInfo },
            callback);
    }
}