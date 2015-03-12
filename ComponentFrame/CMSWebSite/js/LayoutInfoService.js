/*

 @Name: pengesoft 布局管理服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function LayoutInfoService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/LayoutinfoService.assx");
}
//继承基类的方法
LayoutInfoService.prototype = new BaseService();

//定义自己的方法体
LayoutInfoService.prototype = {
    //获取用户布局信息  如无相关布局信息则返回默认布局信息
    GetUserLayoutinfo:function(PageName, RoleName, callback) {
    this.Post(
        this.baseUrl + "/GetUserLayoutinfo",
        { uTag: this.uTag, UserID: this.loginId, PageName: PageName, RoleName: RoleName },
        callback);
    },

    //新增用户布局信息(创建时间传null)
    AddUserLayoutinf: function (UserID,PageName, MLayoutInfo, callback) {
        this.Post(
            this.baseUrl + "/AddUserLayoutinf",
            { uTag: this.uTag, UserID: UserID, PageName: PageName, MLayoutInfo: MLayoutInfo },
            callback);
    },

    //更新用户布局信息
    UpdateUserLayoutinf: function (UserID,PageName, MLayoutInfo, callback) {
        this.Post(
            this.baseUrl + "/UpdateUserLayoutinf",
            { uTag: this.uTag, UserID: UserID, PageName: PageName, MLayoutInfo: MLayoutInfo },
            callback);
    },

    //获取布局总数
    GetLayoutInfoListCount:function(PageName, LayType, callback) {
        this.Post(
            this.baseUrl + "/GetLayoutInfoListCount",
            { uTag: this.uTag, uID: this.loginId, PageName: PageName, LayType: LayType },
            callback);
    },

    //获取布局模板列表
    GetLayoutInfoList:function(PageName, LayType, currentPage, PageSize, callback) {
        this.Post(
            this.baseUrl + "/GetLayoutInfoList",
            { uTag: this.uTag, uID: this.loginId, PageName: PageName, LayType: LayType, currentPage: currentPage, PageSize: PageSize },
            callback);
    },

    //获取布局信息
    GetUserLayoutinfobyid:function(lid, callback) {
        this.Post(
            this.baseUrl + "/GetUserLayoutinfobyid",
            { uTag: this.uTag, lid: lid },
            callback);
    },

    //删除布局信息
    DelLayputinfo:function(lid, callback) {
        this.Post(
            this.baseUrl + "/DelLayputinfo",
            { uTag: this.uTag, lid: lid },
            callback);
    },
    //异步新增布局
    AddUserLayoutinfsync: function (UserID,PageName, MLayoutInfo, callback) {
        $.ajax({
            url: this.baseUrl + "/AddUserLayoutinf",
            data: {
                uTag: this.uTag,
                UserID: UserID,
                PageName: PageName,
                MLayoutInfo: MLayoutInfo,
            },
            async: false,
            type: "POST",
            dataType: "json",
            success: callback
        }); 
    }
}