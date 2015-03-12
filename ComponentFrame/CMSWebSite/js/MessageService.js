/*

 @Name: pengesoft 消息服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function MessageService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/MessageService.assx");
}
//继承基类的方法
MessageService.prototype = new BaseService();

//定义自己的方法体
MessageService.prototype = {
    //发送消息 
    SendMessage:function(Recipients, Message, callback){
        this.Post(
            this.baseUrl + "/SendMessage",
            { uTag: this.uTag, Recipients: Recipients, Message: Message },
            callback);
    },
    // 获取消息
    GetMessage:function(Guid, callback) {
        this.Post(
            this.baseUrl + "/GetMessage",
            { uTag: this.uTag, Guid: Guid},
            callback);
    },
    //查询消息总数
    QueryMessageCount:function(StateCode, callback) {
        this.Post(
            this.baseUrl + "/QueryMessageCount",
            { uTag: this.uTag, StateCode: StateCode },
            callback);
    },
    //查询消息分页列表
    QueryMessagePageList:function(StateCode, pageIndex, pageSize, callback) {
        this.Post(
            this.baseUrl + "/QueryMessagePageList",
            { uTag: this.uTag, StateCode: StateCode, pageIndex: pageIndex, pageSize: pageSize },
            callback);
    },
    //标记消息列表
    MarkMessageList:function(MessageGuids, StateCode, callback) {
        this.Post(
            this.baseUrl + "/MarkMessageList",
           { uTag: this.uTag, MessageGuids: MessageGuids, StateCode: StateCode },
           callback);
    },
    //标记消息
    MarkMessage:function(Guid, StateCode, callback) {
        this.Post(
            this.baseUrl + "/MarkMessage",
           { uTag: this.uTag, Guid: Guid, StateCode: StateCode },
           callback);
    },
    //删除消息列表
    DeleteMessageList:function(MessageGuids, callback) {
        this.Post(
           this.baseUrl + "/DeleteMessageList",
          { uTag: this.uTag, MessageGuids: MessageGuids },
          callback);
    }
}