var typeNode;
function CallAjaxHandler(str, methodName, para) {
    jQuery.ajax({
        url: "AjaxHandler/AjaxFavoritHandler.ashx",
        data: { "MethodName": methodName,
            "Param": para
        },
        dataType: "json",
        async: true,
        cache: false,
        error: function() {
            $.messager.alert('提示', str + '失败', 'info');
        },
        success: function(ResultInfo) {
            if (ResultInfo.State == "error")
                $.messager.alert('提示', ResultInfo.Msg, 'info');
            else if (ResultInfo.State == "success") {
                switch (methodName) {
                    case "AddCollectType":
                        $('#collectTypeTree').tree('append', {
                            parent: typeNode.target,
                            data: [{
                                id: ResultInfo.Msg.KeyId,
                                text: ResultInfo.Msg.NodeName
}]
                            });
                            break;
                        case "ModifyCollectType":
                            $('#collectTypeTree').tree('update', {
                                target: typeNode.target,
                                text: ResultInfo.Msg
                            });
                            break;
                        case "DeleteCollectType":
                            $('#collectTypeTree').tree('remove', typeNode.target);
                            break;
                    }
                    $.messager.alert('提示', str + '成功', 'info');
                }
            }
        });
    }

    function GetLevelTwoNode(text) {
        var rootNode = $("#collectTypeTree").tree('getRoot')
        var children = $("#collectTypeTree").tree('getChildren', rootNode.target);
        for (var i = 0; i < children.length; i++) {
            if (children[i].text == text)
                return children[i];
        }
    }

    function SelectCollectType(obj, str) {
        $('#dialog').dialog({
            modal: true,
            title: '选择收藏类型',
            width: 280,
            height: 350,
            toolbar: [{
                text: '新建类型',
                iconCls: 'icon-add',
                handler: function() {
                    $.messager.prompt('请输入', '请输入新添加分类的名称：', function(nodeName) {
                        if (nodeName != "" && nodeName != undefined && nodeName != null) {
                            typeNode = GetLevelTwoNode(str)
                            var json = { "pId": typeNode.id, "nodeName": nodeName };
                            CallAjaxHandler("新增分类", "AddCollectType", json);
                        }
                    });
                }
            }, '-', {
                text: '修改类型',
                iconCls: 'icon-edit',
                handler: function() {
                    var selectedNode = $("#collectTypeTree").tree('getSelected');
                    if (selectedNode == null) {
                        $.messager.alert('提示', '请选择收藏类型!', 'info');
                        return false;
                    }
                    else if (selectedNode.text == "收藏夹" || selectedNode.text == "公文" || selectedNode.text == "公告消息") {
                        $.messager.alert('提示', '只能修改[公文]和[公告消息]下的类型!', 'info');
                        return false;
                    }
                    else {
                        $.messager.prompt('请输入', '请输入新的分类名称：', function(newNodeName) {
                            if (newNodeName != "" && newNodeName != undefined && newNodeName != null) {
                                typeNode = selectedNode;
                                var json = { "keyId": typeNode.id, "newNodeName": newNodeName };
                                CallAjaxHandler("修改类名", "ModifyCollectType", json);
                            }
                        });
                    }
                }
            }, '-', {
                text: '删除类型',
                iconCls: 'icon-remove',
                handler: function() {
                    var selectedNode = $("#collectTypeTree").tree('getSelected');
                    if (selectedNode == null) {
                        $.messager.alert('提示', '请选择收藏类型!', 'info');
                        return false;
                    }
                    else if (selectedNode.text == "收藏夹" || selectedNode.text == "公文" || selectedNode.text == "公告消息") {
                        $.messager.alert('提示', '只能删除[公文]和[公告消息]下的类型!', 'info');
                        return false;
                    }
                    else {
                        $.messager.confirm('确认', '确定要删除分类【' + selectedNode.text + '】吗?', function(r) {
                            if (r) {
                                typeNode = selectedNode;
                                var json = { "keyId": selectedNode.id };
                                CallAjaxHandler("删除分类", "DeleteCollectType", json);
                            }
                        });
                    }
                }
}],
                buttons: [{
                    text: '确定',
                    handler: function() {
                        var selectedNode = $("#collectTypeTree").tree('getSelected');
                        if (selectedNode == null || selectedNode.text == "收藏夹") {
                            $.messager.alert('提示', '请选择收藏类型!', 'info');
                            return false;
                        }
                        var dataKeyId = obj.parentElement.parentElement.getAttribute('key');
                        var dataType;
                        if (str == "公文")
                            dataType = 0;
                        else
                            dataType = 1;
                        var json = { "dataKeyId": dataKeyId, "collectTypeId": selectedNode.id, "dataType": dataType };
                        CallAjaxHandler("添加收藏", "AddCollectData", json);
                        $('#dialog').dialog('close', false);
                    }
                }, {
                    text: '取消',
                    handler: function() {
                        $('#dialog').dialog('close', false);
                    }
}]
                });
                $("#collectTypeTree").tree({
                    animate: false,
                    lines: true,
                    url: "AjaxHandler/AjaxGetTreeData.ashx",
                    onLoadSuccess: function(node, data) {
                        var root = $(this).tree('getRoot');
                        var children = $(this).tree('getChildren', root.target);
                        for (var i = 0; i < children.length; i++) {
                            if (str == "公文") {

                                if (children[i].text == "公告消息") {
                                    $(this).tree('remove', children[i].target);
                                }
                                else if (children[i].text == "公文") {
                                    $(this).tree('expand', children[i].target)
                                }
                            }
                            else if (str == "公告消息") {
                                if (children[i].text == "公文") {
                                    $(this).tree('remove', children[i].target);
                                }
                                else if (children[i].text == "公告消息") {
                                    $(this).tree('expand', children[i].target)
                                }
                            }
                        }
                    },
                    onClick: function(node) {
                        if (node.text == "收藏夹" || node.text == "公文" || node.text == "公告消息")
                            return false;
                    }
                });
                return false;
            }
        