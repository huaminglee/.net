/*

 @Name: pengesoft 使用频度服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function QuickUseRecordService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/QuickUseRecordService.assx");
}
//继承基类的方法
QuickUseRecordService.prototype = new BaseService();

//定义自己的方法体
QuickUseRecordService.prototype = {
    //添加使用次数
    AddQuickUse:function(Qid, Qtype, callback) {
        this.Post(
            this.baseUrl + "/AddQuickUse",
            { uTag: this.uTag, Uid: this.loginId, Qid: Qid, Qtype: Qtype },
            callback);
    },

    //移除常用
    DelQuickUse:function(Qid, callback) {
        this.Post(
            this.baseUrl + "/GetUsualQuick",
            { uTag: this.uTag, Uid: this.loginId, Qid: Qid },
            callback);
    },

    //查询常用入口
    GetUsualQuick:function(Qtype, QNeedRecords, callback) {
        this.Post(
            this.baseUrl + "/GetUsualQuick",
            { uTag: this.uTag, Uid: this.loginId, Qtype: Qtype, QNeedRecords: QNeedRecords },
            callback);
    }
}