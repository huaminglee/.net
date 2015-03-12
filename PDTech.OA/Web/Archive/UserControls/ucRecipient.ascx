<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRecipient.ascx.cs" Inherits="Archive_UserControls_ucRecipient" %>

<div class="Main_Body">
    <div class="con_h">
        <div class="con_p"><span>人员列表(复选框选择)</span></div>
        <div class="con_r"><span>接收人员</span></div>
    </div>
    <div class="con_s">
        <div class="con_Query">
            <input type="text" id="txtPersonName" class="input inpute" />
            <input type="button" id="btnSearch" class="btn btn_four" value="人员查询" />&nbsp;
        </div>
        <div class="con_temp">
            <span>
                <input type="button" id="btnSave" class="btn btn_four" value="保存模板" /></span>
            <input type="button" id="btnRead" class="btn btn_four" value="模板读入" />
        </div>
    </div>
    <div class="con_c">
        <div class="con_tree">
            <div class="easyui-panel" style="height: 333px; border: none;">
                <ul id="tt" class="easyui-tree" data-options="animate:true,checkbox:true,cascadeCheck:false,lines:true,onlyLeafCheck:false">
                </ul>
            </div>
        </div>
        <div class="con_say">
            <fieldset>
                <legend>已选人员</legend>
                <div id="yxry"></div>
            </fieldset>
        </div>
    </div>
</div>
<script>
    //获取当前窗口索引以便执行layer.close方法（"window.name"是固定写法，不是某个控件的ID，官方demo有错误）
    var valArr = [], returnVal = [];
    var val, nodes;
    $(function () {
        $("#tt").tree({
            onCheck: function (node, checked) {
                nodes = $("#tt").tree("getChecked");//获取选中值
                val = "";//如果不赋值空，则会变成"undefined"
                $("#yxry a").remove();//清空已选人员
                /***拼接分配人员数据，此处获取属性值时，需比较实体类PersonTree中获取***/
                $.each(nodes, function (i, n) {
                    /***当前模块只需要人员数据，所以过滤部门数据***/
                    if (nodes[i].status == "person") {
                        val += nodes[i].text + "," + nodes[i].id + ";";
                        /***进行分配***/
                        $("#yxry").append("<a class='btn-default btn-block'>" + nodes[i].text + "<button id='" + nodes[i].id + "' name='" + nodes[i].status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                    }
                    if (nodes[i].status == "department") {
                        if (nodes[i].duid != "undefined" && nodes[i].duid.length != 0) {
                            val += nodes[i].text + "," + nodes[i].id + ";";
                            /***进行分配***/
                            $("#yxry").append("<a class='btn-default btn-block'>" + nodes[i].text + "<button id='" + nodes[i].id + "' name='" + nodes[i].status + "' type='button' class='close' title='关闭' onclick='mbtnClose(this);'><span aria-hidden='true'>&times;</span><span class='sr-only'>Close</span></button></a>");
                        } else {
                            layer.alert("此部门没有指定接收人员!", 8);
                            $("#tt").tree("update", {
                                target: nodes[i].target,
                                checked: false
                            });
                        }
                    }
                });
                valArr = val.substr(0, val.length - 1).split(";");//将所有checked数据拆分为数组
                returnVal = [];
                /***取出已选人员的姓名***/
                $.each(valArr, function (i, n) {
                    returnVal.push(valArr[i].split(",", 1));//存入数组
                });
                window.parent.document.getElementById("txt_gwry").value = returnVal.join(",");//赋值给父窗体的文本框（仅用于现实）
                window.parent.document.getElementById("h_val").value = val;//赋值给父窗体的隐藏控件（用于父窗体的保存）
            },
            method: 'get',
            url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($.trim($("#txtPersonName").val())) + ""
        });

        /***查询***/
        $("#btnSearch").click(function () {
            $("#tt").tree({
                method: 'get',
                url: "/Ajax/Public_Tree.ashx?pageState=gwry&txt_name=" + encodeURIComponent($.trim($("#txtPersonName").val())) + ""
            });
        });
    })

    /***每个已选人员的关闭***/
    function mbtnClose(btn) {
        /***nodes为当前已选人员***/
        $.each(nodes, function (i, n) {
            /***匹配所有已选人员是否为点击删除的已选人员***/
            if (nodes[i].id == $(btn).attr("id")) {
                /***匹配成功，取消选择***/
                $("#tt").tree("update", {
                    target: nodes[i].target,
                    checked: false
                });
            }
        });
    }
</script>

