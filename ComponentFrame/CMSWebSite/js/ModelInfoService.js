/*

 @Name: pengesoft 模块管理服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function ModelInfoService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/ModelInfoService.assx");
}
//继承基类的方法
ModelInfoService.prototype = new BaseService();

//定义自己的方法体
ModelInfoService.prototype = {
    //获取模块总数
    GetModelCount: function (callback) {
        this.Post(
            this.baseUrl + "/GetModelCount",
            { uTag: this.uTag },
            callback);
    },

    //获取模块列表
    GetModelList: function (currentPage, PageSize, callback) {
        this.Post(
            this.baseUrl + "/GetModelList",
            { uTag: this.uTag,currentPage: currentPage, PageSize: PageSize },
            callback);
    },

    //新增模块
    AddModelInfo: function (modelInfo, callback) {
        this.Post(
            this.baseUrl + "/AddModelInfo",
            { uTag: this.uTag,modelInfo: modelInfo },
            callback);
    },

    //删除模块
    DelModelInfo: function (mId, callback) {
        this.Post(
            this.baseUrl + "/DelModelInfo",
            { uTag: this.uTag,mId: mId },
            callback);
    }
}