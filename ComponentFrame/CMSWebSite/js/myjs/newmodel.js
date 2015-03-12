//确认添加模块
function confirmadd() {
    var modelname, modelpage, piconame, owner, belonepage, remark, sizex, sizey, minx, miny, maxx, maxy;
    modelname = $("#modelname").val();
    modelpage = $("#contentpage").val();
    piconame = $("#picofile").val();
    owner = $("#iowner").val();
    belonepage = $("#belonepage").val();
    remark = $("#remark").val();
    sizex = $("#sizex").val();
    sizey = $("#sizey").val();
    minx = $("#minx").val();
    miny = $("#miny").val();
    maxx = $("#maxx").val();
    maxy = $("#maxy").val();

    if (modelname == "" || modelname == null) {
        layer.tips('请输入模块名称', $("#modelname"), {
            guide: 3,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else if (modelpage == "" || modelpage == null) {
        layer.tips('请输入模块内容', $("#contentpage"), {
            guide: 3,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else if (piconame == "" || piconame == null) {
        layer.tips('请选择模块图标', $("#picofile"), {
            guide: 3,
            time: 2,
            style: ['background-color:#F26C4F; color:#fff', '#F26C4F'],
            maxWidth: 150
        });
    }
    else {
        var modelInfo = new ModelInfo();
        modelInfo.MName = modelname;
        modelInfo.MContent = modelpage;
        modelInfo.Pico = getNameByPath(piconame);
        modelInfo.BelongPage = belonepage;
        modelInfo.RightLevel = owner;
        modelInfo.Remark = remark;
        modelInfo.Sizex = sizex == "" ? 0 : sizex;
        modelInfo.Sizey = sizey == "" ? 0 : sizey;
        modelInfo.MinSizex = minx == "" ? 0 : minx;
        modelInfo.MinSizey = miny == "" ? 0 : miny;
        modelInfo.MaxSizex = maxx == "" ? 0 : maxx;
        modelInfo.MaxSizey = maxy == "" ? 0 : maxy;

        var modelJson = JSON.stringify(modelInfo);

        var modelInfoService = new ModelInfoService();
        //保存结果
        modelInfoService.AddModelInfo(modelJson,
            function (data, status) {
                var code = parseInt(data);
                if (code == 0) {
                    parent.loadlist();
                    window.parent.layer.closeAll();
                    alert("添加成功！");
                }
                else {
                    alert("添加失败！");
                }
            });
    }
}
function getNameByPath(path) {
    //从路径中截取图片名[包括后缀名]
    var filename;
    if (path.indexOf("\\") > 0)//如果包含有"/"号 从最后一个"/"号+1的位置开始截取字符串
    {
        filename = path.substring(path.lastIndexOf("\\") + 1, path.length);
    }
    else {
        filename = path;
    }
    return filename;
}