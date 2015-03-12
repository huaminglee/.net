$(function () {
    //先通过off()方法解除，再通过on()绑定  
    $(document).off("click", Jump).on("click", "[data-model]", Jump);
});
//执行页面间跳转
function Jump(e) {
    //事件运行代码
    var model = $(this).attr("data-model");
    var url = $(this).attr("data-target");
    
    if (model == "parent") { 
            //跳出父级
            JumpParent(url);
         
    }
    else if (model == "tab") {
        //tab标签切换跳转
        AddTabSelf(url);
    }
    else if (model == "container") {
        var mframes = parent.parent.document.getElementsByTagName("iframe");
        $.each(mframes, function (i,cframe) {
            if (cframe.id.indexOf("modelcontainer") > -1) {
                ChangeOtherIframe(cframe.id, url);
            }
        }
        );
        
    }
    else {
        //默认内部跳转
        JumpSelf(url);
    }
}

//改变其它模块url
function ChangeOtherIframe(TargetIframe, TargetURL) {
    if (window.parent.parent.document.getElementById(TargetIframe) != null) {
        window.parent.parent.document.getElementById(TargetIframe).src = TargetURL;
    }
    else {
        JumpParent(TargetURL);
    }
    
}
//模块自己内部跳转
function JumpSelf(tourl) {
    window.location.href = tourl;
}
//模块父级跳转
function JumpParent(tourl) {
    window.parent.location.href = tourl;
}
//模块自身添加tab
function AddTabSelf(addurl) {
    //todo:
}