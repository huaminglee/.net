/*

 @Name: pengesoft 入口管理服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function QuickEntryService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/QuickEntryService.assx");
}
//继承基类的方法
QuickEntryService.prototype = new BaseService();

//定义自己的方法体
QuickEntryService.prototype = {
    //新增入口
    AddQuickentry:function(QName, QRemark, QPico, QTarget, DefaultSort, QType, callback) {
        this.Post(
                this.baseUrl + "/AddQuickentry",
                { uTag: this.uTag,QName:QName,QRemark:QRemark,QPico:QPico,QTarget:QTarget,DefaultSort:DefaultSort, QType:QType },
                callback);
    },

    //修改入口
    UpdateQuickentry:function(Qid, QName, QRemark, QPico, QTarget, DefaultSort, QType, callback) {
        this.Post(
            this.baseUrl + "/AddQuickentry",
            { uTag: this.uTag,Qid:Qid,QidQName:QName,QRemark: QRemark,QPico:QPico,QTarget:QTarget,DefaultSort:DefaultSort,QType:QType },
            callback);
    },

    //删除
    DelQuickentry:function(Qid, callback) {
        this.Post(
                this.baseUrl + "/AddQuickentry",
                { uTag: this.uTag,Qid:Qid },
                callback);
    },

    //查询默认列表
    GetDefaultList:function(Qtype, NeedRecords, qids, callback) {
        this.Post(
                this.baseUrl + "/AddQuickentry",
                { uTag:this.uTag,Qtype:Qtype,NeedRecords:NeedRecords,qids:qids },
                callback);
    }
}