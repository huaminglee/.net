/**      
* 对Date的扩展，将 Date 转化为指定格式的String      
* 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q) 可以用 1-2 个占位符      
* 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)      
* eg:      
* (new Date()).pattern("Y-m-d h:m:s.S") ==> 2006-07-02 08:09:04.423      
* (new Date()).pattern("Y-m-d E H:m:s") ==> 2009-03-10 二 20:09:04      
* (new Date()).pattern("Y-m-d EE h:m:s") ==> 2009-03-10 周二 08:09:04      
* (new Date()).pattern("Y-m-d EEE h:m:s") ==> 2009-03-10 星期二 08:09:04      
* (new Date()).pattern("Y-m-d h:m:s.S") ==> 2006-07-02 8:9:4.18      
*/


Date.prototype.Dateformat = function(fmt) {
    var o = {
    "m+" : this.getMonth()+1<10? '0'+(this.getMonth()+1):this.getMonth()+1, //月份
    "d+" : this.getDate()<10?'0'+this.getDate():this.getDate(), //日
    "h+" : this.getHours()%12 == 0 ? 12 : this.getHours()%12, //小时
    "H+" : this.getHours(), //小时
    "i+" : this.getMinutes()<10?'0'+this.getMinutes():this.getMinutes(), //分
    "s+" : this.getSeconds()<10?'0'+this.getSeconds():this.getSeconds(), //秒
    "q+" : Math.floor((this.getMonth()+3)/3), //季度
    "S" : this.getMilliseconds() //毫秒
    };
    var week = {
    "0" : "\日",
    "1" : "\一",
    "2" : "\二",
    "3" : "\三",
    "4" : "\四",
    "5" : "\五",
    "6" : "\六"
    };
    if(/(Y+)/.test(fmt)){
        fmt=fmt.replace(RegExp.$1, (this.getFullYear()+""));//.substr(4 - RegExp.$1.length));
    }
    if(/(E+)/.test(fmt)){
        fmt=fmt.replace(RegExp.$1, ((RegExp.$1.length>1) ? (RegExp.$1.length>2 ? "\星\期" : "\周") : "")+week[this.getDay()+""]);
    }
    for(var k in o){
        if(new RegExp("("+ k +")").test(fmt)){
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));
        }
    }
    return fmt;
}