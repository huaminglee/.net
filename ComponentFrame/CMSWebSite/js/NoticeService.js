/*

 @Name: pengesoft 公告服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function NoticeService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/NoticeInfoService.assx");
}
//继承基类的方法
NoticeService.prototype = new BaseService();

//定义自己的方法体
NoticeService.prototype ={
    //发布公告
    Announcement:function(title, content, author, callback) {
        this.Post(
            this.baseUrl + "/Announcement",
            { uTag: this.uTag, title: title, content: content, author: author },
            callback);
    },
    //获取公告
    GetNotice:function(Guid, callback) {
        this.Post(
            this.baseUrl + "/GetNotice",
            { uTag: this.uTag, Guid: Guid },
            callback);
    },
    //获取公告列表
    QueryNoticeList:function(count, callback) {
        this.Post(
            this.baseUrl+"/QueryNoticeList",
            { uTag: this.uTag, count: count },
            callback);
    },
    //查询公告分页列表
    QueryNoticePageList:function(param, pageIndex, pageSize, callback) {
        this.Post(
            this.baseUrl+"/QueryNoticePageList",
            { uTag: this.uTag, param: param, pageIndex: pageIndex, pageSize: pageSize },
            callback);
    },
    //查询公告数量
    QueryNoticeCount:function(param, callback) {
        this.Post(
            this.baseUrl+"/QueryNoticeCount",
            { uTag: this.uTag, param: param },
            callback);
    },
    //删除公告列表
    DeleteNoticeList:function(guidList, callback) {
        this.Post(
            this.baseUrl+"/DeleteNoticeList",
           { uTag: this.uTag, guidList: guidList },
           callback);
    }
}