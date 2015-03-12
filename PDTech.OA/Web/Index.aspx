<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!-- 移动设备优先 -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>成都市水务局综合管理系统</title>
    <!-- 最新 EasyUI 核心 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/bootstrap/easyui.css" rel="stylesheet" />
    <!-- EasyUI ICON图标 CSS 文件 -->
    <link href="/easyui/1.3.6/themes/icon.css" rel="stylesheet" />
    <!-- 最新 Bootstrap 核心 CSS 文件 -->
    <link href="/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/html5_layout.css" rel="stylesheet" />
    <!-- 兼容Html5和Css3 -->
    <!--[if lt IE 9]>
        <script src="/Script/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="/Script/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body  style="width: 100%; height: 100%;">
    <section style="width: 100%; padding-top: 0;">
        <table  id="frametable" style="width: 100%; height: 100%;">
            <tr>
                <td style="width:1.2%">
                    <div></div>
                </td>
                <td style="width:88.8%">
                    <table style="height:100%;width:100%;">
                        <tr style="height:10px">
                            <td><!-- 顶部空白 -->

                            </td>
                        </tr>
                        <tr>
                            <td style="width:54%;height:240px" ><!-- 公告通知 -->
                                <div class="panel panel-info" style="height: 240px; background-color: #fcfdfe; margin-bottom:0">
                                    <div class="panel-heading" style="font-size: 1.1em;"><span class="glyphicon glyphicon-comment"></span>&emsp;公告通知<a href="Archive/MessageAndMeeting2.aspx" class="pull-right cursor"><span class="glyphicon glyphicon-hand-right"></span>&emsp;更&ensp;多</a></div>
                                    <div class="list-group" id="ggxx">
                                        <img src="/images/loading.gif" style="margin-left: 270px; margin-top: 100px;" />
                                    </div>
                                </div>
                            </td>
                            <td style="width:1%">

                            </td>
                            <td style="width:44%"> <!-- “三重一大” -->
                                <div class="panel panel-info" style="height:  240px; background-color: #fcfdfe; margin-bottom:0">
                                    <div class="panel-heading" style="font-size: 1.1em;"><span class="glyphicon glyphicon-exclamation-sign"></span>&emsp;“三重一大”公示<a href="Archive/Moreszyd.aspx" class="pull-right cursor"><span class="glyphicon glyphicon-hand-right"></span>&emsp;更&ensp;多</a></div>
                                    <div class="list-group" id="major">
                                        <img src="/images/loading.gif" style="margin-left: 220px; margin-top: 100px;" />
                                    </div>
                                </div>
                            </td>
                            
                            <td style="width:1%">

                            </td>
                        </tr>
                        <tr style="height:20px">
                            <td><!--横向 中间空白 -->

                            </td>
                        </tr>
                        <tr>
                            <td style="width:54%; height:240px"><!-- 待办事项 -->
                                            
                                <div class="panel panel-info" style="height: 240px; background-color: #fcfdfe; margin-top:0; margin-bottom:auto">
                                    <div class="panel-heading" style="font-size: 1.1em;"><span class="glyphicon glyphicon-tags"></span>&emsp;待办事项<a href="Archive/AllArchive_Task.aspx" class="pull-right cursor"><span class="glyphicon glyphicon-hand-right"></span>&emsp;更&ensp;多</a></div>
                                    <div class="list-group" id="readyWork">
                                        <img src="/images/loading.gif" style="margin-left: 270px; margin-top: 100px;" />
                                    </div>
                                </div>
                            </td>
                            <%-- 中间竖向空白 --%>
                            <td style="width:1%">

                            </td>
                            <%-- 岗位风险岗位职责 --%>
                            <td style="width:44%">
                                <div style="height: 240px; background-color: #fcfdfe;">
                                    <table style="height:100%;width:100%; margin-top:0">
                            <!-- 岗位职责 -->
                                                <tr  style="height: 103px; background-color: #fcfdfe;" >
                                                    <td>
                                                        <div class="panel panel-info" style="height: 103px; background-color: #fcfdfe;  margin-bottom:0; overflow-y:auto">
                                                            <div class="panel-heading" style="font-size: 1.1em;"><span class="glyphicon glyphicon-tower"></span>&emsp;岗位职责</div>
                                                            <div class="list-group" style="padding: 5px 15px;">
                                                                <p id="responsibility">
                                                                    <img src="/images/loading.gif" style="margin-left: 205px; margin-top: 10px;" />
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                        <tr style="height: 20px; background-color: #fcfdfe;" >
                                            <td>

                                            </td>
                                        </tr>
                            <!-- 岗位风险 -->
                                                <tr style="height: 100px; background-color: #fcfdfe;" >
                                                    <td>
                                                        <div class="panel panel-danger" style="height: 110px; background-color: #fcfdfe;  margin-bottom:0; overflow-y:auto">
                                                            <div class="panel-heading" style="font-size: 1.1em;"><span class="glyphicon glyphicon-warning-sign"></span>&emsp;岗位风险及防范措施<a class="pull-right cursor" id="gwfxMore" data-toggle="modal" data-target="#dutyRisk"><span class="glyphicon glyphicon-hand-right"></span>&emsp;更&ensp;多</a></div>
                                                            <div class="list-group" style="padding: 5px 15px; overflow-y:auto">
                                                                <span id="risk_level" class="text-danger"></span><b class="text-left text-danger" id="risk"></b><br />
                                                                <br />
                                                                <b class="text-left text-danger" id="avoid"></b>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style=" height:10px">

                            </td>
                        </tr>
                    </table>
                </td>
                <%-- 右侧快捷通道 --%>
                <td  style="width:10%;height:520px; background-color: #fcfdfe;" >
                    <div class="panel panel-default"  id="toolbar" style="width: 100%; height: 100%; background-color: #f4fbff;">
                        <table style="width: 100%; height: 100%;">
                            <tr style="height: 10px;">
                                <td>
                                </td>
                                </tr>
                            <tr  style="height: 100%;">
                                <td>
                                    <button type="button" class="btn btn-link" id="btn_uInfo" data-toggle="modal" data-target="#uInfo" style="width: 100%; margin: 0 auto;"><span class="glyphicon glyphicon-user"></span>&nbsp;<%=Session["full_name"]%>，您好！</button>
                                    <div class="btn-group-vertical">
                                    </div>
                                    <hr />
                                    <%--<p class="text-center"><kbd>快捷通道</kbd></p>--%>
                                    <div class="btn-group-vertical" style="width: 100%; margin: 0;">
                                        <button type="button" class="btn btn-link" id="btn_dBase" data-toggle="modal" data-target="#dBase" style="padding: 7px 10px;">
                                            <span class="glyphicon glyphicon-book text-success" style="font-size: 3em;"></span><br />资料库</button>
                                        <button type="button" class="btn btn-link" id="btn_contact" data-toggle="modal" data-target="#contact" style="padding: 7px 10px;">
                                            <span class="glyphicon glyphicon-phone text-success" style="font-size: 3em;"></span><br />通讯录</button>
                                        <br />
                                        <button type='button' class='btn btn-link' data-toggle='modal' data-target='#favorites' style="padding: 7px 10px;">
                                            <span class="glyphicon glyphicon-folder-open text-success" style="font-size: 3em;"></span><br />收藏夹</button>
                                        <button type="button" class="btn btn-link" id="btn_cPwd" data-toggle="modal" data-target="#cPwd"">
                                            <span class="glyphicon glyphicon-lock text-success" style="font-size: 3em;"></span><br />修改密码</button>
                                    </div>
                                </td>
                            </tr>
                            </table>
                    </div>
                </td>
            </tr>
            <%-- 底部友情链接 --%>
            <tr>
                <td  style="width:1.2%"></td>
                <td colspan="4"  style="width:98.8%">
                <div class="panel panel-default" style=" padding-top:10px; background-color: #f4fbff;">
                    <table style="width:100%">
                        <tr>
                            <td style="width:1.2%">
                                <div></div>
                            </td>
                            <td style="width:8%"><img src="/images/Communicate.png" class="img-rounded" style="padding:2px 2px;" title="友情链接"/></td>
                            <%--<td style="width:10%"><p><a href="http://egov.chengdu.gov.cn/welcome.jsp" target="_blank">行政权力运行</a></p></td>
                            <td style="width:10%"><p><a href="http://pdf.cdwater.gov.cn:8080" target="_blank">政务信息平台</a></p></td>
                            <td style="width:10%"><p><a href="http://doc.cdwater.gov.cn:8080/manage" target="_blank">资料交换平台</a></p></td>--%>
                            <td style="width:22%">
                                 <select  id="select_xzbg" style="width:98%;" onchange="showLink(this.value, this)">
                                        <option value="">行政办公平台链接</option>
                                        <option value="http://egov.chengdu.gov.cn/welcome.jsp">行政权力运行平台</option>
                                        <option value="http://pdf.cdwater.gov.cn:8080">政务信息平台</option>
                                        <option value="http://doc.cdwater.gov.cn:8080/manage">资料交换平台</option>
                                    </select>
                            </td>
                            <td style="width:22%">
                                 <select  id="select_jjjc" style="width:98%;" onchange="showLink(this.value, this)">
                                        <option value="">纪检监察系统</option>
                                        <option value="http://www.ccdi.gov.cn/">中央纪委监察部</option>
                                        <option value="http://csr.mos.gov.cn/mos/cms/html/122/index.html">中国廉政网</option>
                                        <option value="http://www.lianzheng.com.cn/">中国反腐败倡廉网</option>
                                        <option value="http://www.scjc.gov.cn/">四川省监察厅</option>
                                        <option value="http://www.ljcd.gov.cn/">廉洁成都</option>
                                        <option value="http://www.qinfeng.gov.cn/">陕西秦风网</option>
                                        <option value="http://www.hnlzw.net/">海南廉政网</option>
                                        <option value="http://www.gxjjw.gov.cn/index.html">广西纪检监察网</option>
                                        <option value="http://www.jxlz.gov.cn/">江西廉政网</option>
                                        <option value="http://www.ahjjjc.gov.cn/">安徽纪检监察网</option>
                                        <option value="http://www.zjsjw.gov.cn/">浙江廉政在线</option>
                                        <option value="http://www.shjjjc.gov.cn/">上海纪检监察</option>
                                        <option value="http://jct.jl.gov.cn/">吉林省监察厅</option>
                                        <option value="http://www.sxlzw.gov.cn/">山西廉政网</option>
                                        <option value="http://www.hebxn.gov.cn/index.do?templet=index">河北效能网</option>
                                        <option value="http://www.tjjw.gov.cn/">天津纪检监察网</option>
                                        <option value="http://www.bjsupervision.gov.cn/">北京纪检监察网</option>
                                        <option value="http://www.njjj.gov.cn/www/jcj/2012/">钟山清风</option>
                                        <option value="http://jjc.cq.gov.cn/">重庆市监察局网站</option>
                                        <option value="http://www.szmj.gov.cn/">深圳明镜网</option>
                                        <option value="http://www.mirror.gov.cn/">山东纪检监察网</option>
                                        <option value="http://lianshi.gov.cn/">苏州廉石网</option>
                                        <option value="http://www.lnsjjjc.gov.cn/">辽宁纪检监察网</option>
                                    </select>
                            </td>
                            
                            <td style="width:22%">
                                 <select id="select_swxg" style="width:98%;"  onchange="showLink(this.value, this)">
                                        <option value="">水务相关网站</option>
                                        <option value="http://www.mwr.gov.cn">水利部</option>
                                        <option value="http://www.cdwater.gov.cn">成都水务局</option>
                                        <option value="http://www.scwater.gov.cn">四川水利网</option>
                                        <option value="http://www.bjwater.gov.cn">北京水务局</option>
                                        <option value="http://www.gzwater.gov.cn">广州水务局</option>
                                    </select>
                            </td>
                            
                            <td style="width:22%">
                                <select id="select_cds" style="width:98%;" onchange="showLink(this.value, this)">
                                        <option value="">成都市相关网站</option>
                                        <option value="http://www.cditv.cn/">成都广播电视台</option>
                                        <option value="http://www.newssc.org/">四川新闻网</option>
                                        <option value="http://www.chengdu.gov.cn/">中国·成都</option>
                                        <option value="http://www.chengdu.cn/">成都全搜索</option>
                                        <option value="http://sc.sina.com.cn/">新浪四川</option>
                                        <option value="http://cd.qq.com/">大成网</option>
                                    </select>
                            </td>
                            
<%--                            <td style="width:15%">

                            </td>
                            <td style="width:20%">
                                <div style="margin-right:10px">
                                   
                                   
                                    
                                </div>
                            </td>--%>
                        </tr>
                    </table>
                </div>
                </td>
            </tr>
        </table>
    </section>
    <!-- 岗位风险 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="dutyRisk" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="dutyRiskLabel"><span class="glyphicon glyphicon-warning-sign"></span><b>&ensp;岗位风险</b></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered table-condensed">
                                    <thead>
                                        <tr>
                                            <th class='text-center'>岗位风险</th>
                                            <th class='text-center'>防范措施</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_dutyRisk">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 资料库 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="dBase" tabindex="-1" role="dialog" aria-labelledby="dBaseLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <div class="row">
                        <div class="col-sm-3">
                            <h5 class="modal-title text-primary" id="dBaseLabel"><span class="glyphicon glyphicon-book"></span><b>&ensp;资料库</b></h5>
                        </div>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <label for="txt_fileName" class="input-group-addon">文件名</label>
                                <input type="text" class="form-control input-sm" id="txt_fileName">
                            </div>
                        </div>
                        <div class="col-sm-1">
                            <button type="button" class="btn btn-primary btn-sm" id="btn_dBase_query">查&ensp;询</button>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-3" style="height: 420px; overflow: auto;">
                            <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                            <ul id="tt" class="easyui-tree" data-options="animate:true,lines:true"></ul>
                        </div>
                        <div class="col-sm-9" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-condensed table-bordered cursor">
                                    <thead>
                                        <tr>
                                            <th>文件名</th>
                                            <th>修改时间</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_files">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 个人信息 模态窗口 -->
    <div class="modal fade" id="uInfo" tabindex="-1" role="dialog" aria-labelledby="uInfoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="uInfoLabel"><span class="glyphicon glyphicon-user"></span><b>&ensp;个人信息</b></h5>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="txt_name" class="col-sm-2 control-label">姓名</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="txt_name" value="<%=Session["full_name"]%>" disabled="disabled">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_dept" class="col-sm-2 control-label">部门</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="txt_dept" value="<%=Session["department_name"]%>" disabled="disabled">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_phone" class="col-sm-2 control-label">电话</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="txt_phone" maxlength="20">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_mPhone" class="col-sm-2 control-label">手机</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="txt_mPhone" maxlength="11">
                            </div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">取&ensp;消</button>
                    <button id="btn_uInfo_save" type="button" class="btn btn-danger btn-sm">确&ensp;定</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 通讯录 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="contact" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="contactLabel"><span class="glyphicon glyphicon-phone"></span><b>&ensp;通讯录</b></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-4" style="height: 420px; overflow: auto;">
                            <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                            <ul id="tt_contact" class="easyui-tree" data-options="animate:true,lines:true"></ul>
                        </div>
                        <div class="col-sm-8" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered table-condensed" style="text-align: center;">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center;">姓名</th>
                                            <th style="text-align: center;">部门</th>
                                            <th style="text-align: center;">电话</th>
                                            <th style="text-align: center;">手机</th>
                                            <th style="text-align: center;">邮箱</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_contact">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 修改密码 模态窗口 -->
    <div class="modal fade bs-example-modal-sm" id="cPwd" tabindex="-1" role="dialog" aria-labelledby="cPwdLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="cPwdLabel"><span class="glyphicon glyphicon-lock"></span><b>&ensp;修改密码</b></h5>
                </div>
                <div class="modal-body">
                    <div class="form-group has-feedback">
                        <label class="control-label" for="txt_oldPwd">旧密码</label>
                        <input type="password" class="form-control" id="txt_oldPwd" maxlength="16">
                        <span class="glyphicon form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <label class="control-label" for="txt_newPwd">新密码</label>
                        <input type="password" class="form-control" id="txt_newPwd" maxlength="16">
                        <span class="glyphicon form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <label class="control-label" for="txt_confirmPwd">确认密码</label>
                        <input type="password" class="form-control" id="txt_confirmPwd" maxlength="16">
                        <span class="glyphicon form-control-feedback"></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">取&ensp;消</button>
                    <button id="btn_cPwd_yes" type="button" class="btn btn-danger btn-sm">确&ensp;定</button>
                </div>
            </div>
        </div>
    </div>
        <!-- 收藏夹 模态窗口 -->
    <div class="modal fade bs-example-modal-lg" id="favorites" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h5 class="modal-title text-primary" id="favoritesLabel"><span class="glyphicon glyphicon-phone"></span><b>&ensp;收藏夹</b></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-3" style="height: 420px; overflow: auto;">
                            <!-- animate（动画效果），checkbox（多选框），cascadeCheck（是否全选），lines（虚线），onlyLeafCheck（是否关闭节点多选框） -->
                            <ul id="tt_favorites" class="easyui-tree" data-options="animate:true,lines:true"></ul>
                        </div>
                        <div class="col-xs-9" style="height: 420px; overflow: auto;">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered table-condensed cursor" style="text-align: center;">
                                    <thead>
                                        <tr>
                                            <th style="text-align: center;">序号</th>
                                            <th style="text-align: center;">公文名称</th>
                                            <th style="text-align: center;">创建时间</th>
                                            <th style="text-align: center;">办理状态</th>
                                            <th style="text-align: center;">创建人</th>
                                            <th style="text-align: center;">管理</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tb_favorites">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关&emsp;闭</button>
                </div>
            </div>
        </div>
    </div>
    <!-- jQuery文件务必在bootstrap.min.js 之前引入 -->
    <script src="/jquery/1.9.1/jquery.min.js"></script>
    <!-- 最新 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!-- 最新 EasyUI 核心 JavaScript 文件 -->
    <script src="/easyui/1.3.6/jquery.easyui.min.js"></script>
    <script src="/Script/layer/layer.min.js"></script>
    <script>
        /***Ajax全局设置***/
        $.ajaxSetup({ cache: false });
        var obj, strTable = "", timer = "";
        var re_zxs = /^\d+(\.\d+)?$/;//正小数
        var re_zzs = /^[0-9]*[1-9][0-9]*$/;//正整数
        $(function () {
            /***小菜单取消下划线***/
            $("#toolbar button").css("text-decoration", "blink").css("font-family", "Microsoft YaHei");

            /***岗位风险更多***/
            $("#dutyRisk").on("show.bs.modal", function (e) {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "gwfxIndexMore"
                },
                  function (data) {
                      if (data != "null" && data != "") {
                          obj = $.parseJSON(data);
                          $.each(obj, function (i) {
                                strTable += "<tr><td title='" + obj[i].risk_name + "'>" + obj[i].risk_name + "</td><td title='" + obj[i].avoid_metoh + "'>" + obj[i].avoid_metoh + "</td></tr>";
                                      
                          });
                          $("#tb_dutyRisk").html(strTable);
                          strTable = "";
                      }
                      else {
                          $("#tb_dutyRisk").html(strTable);
                      }
                  });
            });

            /***资料库***/
            $("#dBase").on("show.bs.modal", function (e) {
                $("#tt").tree({
                    onClick: function (node) {
                        $.get("/Ajax/PublicQuery.ashx", {
                            pageState: "file",
                            fullPath: node.fullPath
                        },
                          function (data) {
                              if (data != "null" && data != "") {
                                  obj = $.parseJSON(data);
                                  $.each(obj, function (i) {
                                      strTable += "<tr><td title='" + obj[i].text + "'><a target='_blank' href='" + obj[i].relativePath + "'>" + obj[i].text + "</a></td><td>" + obj[i].modifyTime + "</td></tr>";
                                  });
                                  $("#tb_files").html(strTable);
                                  strTable = "";
                              }
                              else {
                                  $("#tb_files").html(strTable);
                              }
                          });
                    },
                    method: "get",
                    url: "/Ajax/PublicQuery.ashx?pageState=folder"
                });
            });
            /***收藏夹***/
            $("#favorites").on("show.bs.modal", function (e) {
                $("#tb_favorites").html("");
                $("#tt_favorites").tree({
                    onClick: function (node) {
                        $.get("/Ajax/PublicQuery.ashx", {
                            pageState: "favorites",
                            archiveType: node.id
                        },
                          function (data) {
                              if (data != "null") {
                                  obj = $.parseJSON(data);
                                  $.each(obj, function (i) {
                                      strTable += "<tr><td>" + obj[i].rowno + "</td><td title='" + obj[i].archive_title + "' onclick='showDetail2(" + obj[i].archive_id + "," + obj[i].archive_type + ");'>" + obj[i].archive_title.substring(0, 15) + "</td><td>" + obj[i].create_time + "</td><td>" + obj[i].current_state + "</td><td>" + obj[i].creator + "</td><td><span class='glyphicon glyphicon-remove text-danger' onclick='mbtnDelete(" + obj[i].favorite_id + ");'></span></td></tr>";
                                  });
                                  $("#tb_favorites").html(strTable);
                                  strTable = "";
                              }
                              else {
                                  $("#tb_favorites").html(strTable);
                              }
                          });
                    },
                    method: "get",
                    url: "/Ajax/PublicQuery.ashx?pageState=archiveType"
                });
            });

            $("#btn_dBase_query").click(function () {
                $.get("/Ajax/PublicQuery.ashx", {
                    pageState: "file",
                    txt_fileName: $.trim($("#txt_fileName").val())
                },
                  function (data) {
                      if (data != "null" && data != "") {
                          obj = $.parseJSON(data);
                          $.each(obj, function (i) {
                              strTable += "<tr><td title='" + obj[i].text + "'><a target='_blank' href='" + obj[i].relativePath + "'>" + obj[i].text + "</a></td><td>" + obj[i].modifyTime + "</td></tr>";
                          });
                          $("#tb_files").html(strTable);
                          strTable = "";
                      }
                      else {
                          $("#tb_files").html(strTable);
                      }
                  });
            });

            /***个人信息***/
            $("#uInfo").on("show.bs.modal", function (e) {
                $.get("/Ajax/PublicQuery.ashx", { pageState: "uInfo" },
                  function (data) {
                      if (data != "null" && data != "") {
                          obj = $.parseJSON(data);
                          $("#txt_phone").val(obj._phone);
                          $("#txt_mPhone").val(obj._mobile);
                      }
                      else {
                          $("#txt_phone").val("无信息");
                          $("#txt_mPhone").val("无信息");
                      }
                  });
            });
            $("#btn_uInfo_save").click(function () {
                $.post("/Ajax/PublicSave.ashx", {
                    pageState: "uInfo",
                    txt_phone: $("#txt_phone").val(),
                    txt_mPhone: $("#txt_mPhone").val()
                },
                  function (data) {
                      $("#uInfo").modal("hide");
                  });
            });

            /***通讯录***/
            $("#contact").on("show.bs.modal", function (e) {
                $("#tt_contact").tree({
                    onClick: function (node) {
                        $.get("/Ajax/PublicQuery.ashx", {
                            pageState: "contact",
                            id: node.id,
                            status: node.status
                        },
                          function (data) {
                              if (data != "null" && data != "") {
                                  obj = $.parseJSON(data);
                                  //点击部门，"部门"列显示当前节点名称
                                  if (node.status == "department") {
                                      $.each(obj, function (i) {
                                          strTable += "<tr><td>" + obj[i]._full_name + "</td><td>" + node.text + "</td><td>" + obj[i]._phone + "</td><td>" + obj[i]._mobile + "</td><td>" + obj[i]._e_maile + "</td></tr>";
                                      });
                                      $("#tb_contact").html(strTable);
                                      strTable = "";
                                  }
                                      //点击人员，"部门"列显示父节点名称
                                  else {
                                      strTable += "<tr><td>" + obj._full_name + "</td><td>" + $("#tt_contact").tree("getParent", node.target).text + "</td><td>" + obj._phone + "</td><td>" + obj._mobile + "</td><td>" + obj._e_maile + "</td></tr>";
                                      $("#tb_contact").html(strTable);
                                      strTable = "";
                                  }
                              }
                              else {
                                  $("#tb_contact").html(strTable);
                              }
                          });
                    },
                    method: "get",
                    url: "/Ajax/PublicQuery.ashx?pageState=gwry"
                });
            });

            /***修改密码***/
            $("#txt_oldPwd").blur(function () {
                if ($.trim($("#txt_oldPwd").val() != "")) {
                    $.post("/Ajax/PublicQuery.ashx", {
                        pageState: "cPwd",
                        txt_oldPwd: $("#txt_oldPwd").val()
                    },
                      function (data) {
                          switch (data) {
                              case "yes":
                                  $("#txt_oldPwd").parent("div").removeClass("has-error").addClass("has-success").children("span").removeClass("glyphicon-remove").addClass("glyphicon-ok");
                                  break;
                              case "error":
                                  $("#txt_oldPwd").parent("div").removeClass("has-success").addClass("has-error").children("span").removeClass("glyphicon-ok").addClass("glyphicon-remove");
                                  break;
                          }
                      });
                }
            });
            $("#txt_newPwd,#txt_confirmPwd").blur(function () {
                if ($.trim($(this).val()) == "") {
                    $(this).parent("div").removeClass("has-success").addClass("has-error").children("span").removeClass("glyphicon-ok").addClass("glyphicon-remove");
                }
                else {
                    $(this).parent("div").removeClass("has-error").addClass("has-success").children("span").removeClass("glyphicon-remove").addClass("glyphicon-ok");
                    if ($("#txt_confirmPwd").val() != $("#txt_newPwd").val()) {
                        $("#txt_confirmPwd").parent("div").removeClass("has-success").addClass("has-error").children("span").removeClass("glyphicon-ok").addClass("glyphicon-remove");
                    }
                }
            });
            $("#btn_cPwd_yes").click(function () {
                if ($("#txt_oldPwd").next("span").attr("class") == "glyphicon form-control-feedback glyphicon-ok" &&
                    $("#txt_newPwd").next("span").attr("class") == "glyphicon form-control-feedback glyphicon-ok" &&
                    $("#txt_confirmPwd").next("span").attr("class") == "glyphicon form-control-feedback glyphicon-ok") {
                    $.post("/Ajax/PublicSave.ashx", {
                        pageState: "cPwd",
                        txt_confirmPwd: $("#txt_confirmPwd").val()
                    },
                      function (data) {
                          $("#cPwd").modal("hide");
                      });
                }
            });
            $("#cPwd").on("hide.bs.modal", function (e) {
                $("#txt_oldPwd,#txt_newPwd,#txt_confirmPwd").val(null);
                $("#txt_oldPwd,#txt_newPwd,#txt_confirmPwd").parent("div").removeClass("has-success has-error").children("span").removeClass("glyphicon-ok glyphicon-remove");
            });

            /***安全退出***/
            $("#btn_exit_yes").click(function () {
                $.get("/Ajax/PublicQuery.ashx", { pageState: "exit" },
                  function (data) {
                      $("#exit").modal("hide");
                      //window.location.replace("/Login.aspx");//replace();替换页面，不可返回上一个页面
                      window.open("/Login.aspx", "_top");
                  });
            });
            //$("#exit").on("hidden.bs.modal", function (e) {
            //    alert($(e.relatedTarget).val());
            //    window.location.replace("Login.aspx");//replace();替换页面，不可返回上一个页面
            //});

            /***加载当前时间***/
            //NowTime();

            /***加载待办事项，“三重一大”，公告***/
            refresh();

            /***加载岗位职责***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "gwzz" })
            .done(function (data) {
                $("#responsibility").text(data == "" ? "暂无" : data).attr("title", data);
            });

            /***加载岗位风险、防范措施***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "gwfx" })
            .done(function (data) {
                if (data != "null" && data != "") {
                    obj = $.parseJSON(data);
                    //风险等级
                    //switch (obj[0].risk_level) {
                    //    case "1":
                    //        $("#risk_level").html("<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>");
                    //        $("#avoid").html("&emsp;&emsp;&emsp;&nbsp;" + obj[0].avoid_metoh.substring(0, 23)).attr("title", obj[0].avoid_metoh);
                    //        break;
                    //    case "2":
                    //        $("#risk_level").html("<span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span>");
                    //        $("#avoid").html("&emsp;&emsp;&nbsp;" + obj[0].avoid_metoh.substring(0, 23)).attr("title", obj[0].avoid_metoh);
                    //        break;
                    //    case "3":
                    //        $("#risk_level").html("<span class='glyphicon glyphicon-star'></span>");
                    //        $("#avoid").html("&emsp;&nbsp;&nbsp;" + obj[0].avoid_metoh.substring(0, 23)).attr("title", obj[0].avoid_metoh);
                    //        break;
                    //}
                    $("#risk").text("风险：" + obj[0].risk_name).attr("title", obj[0].risk_name);
                    $("#avoid").text("防范措施："+obj[0].avoid_metoh).attr("title", obj[0].avoid_metoh);
                }
                else {
                    $("#risk,#avoid").text("暂无");
                }
            });
        });

        /***当前时间***/
        //function NowTime() {
        //    $("#nowTime").html(new Date().toLocaleString());
        //    setTimeout("NowTime()", 1000);
        //}

        /***定时刷新***/
        function refresh() {
            timer != "" ? clearTimeout(timer) : null;//卸载当前定时刷新，避免多个定时刷新同时运行
            /***公告消息***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "ggxx" })
            .done(function (data) {
                if (data != "null" && data != "") {
                    obj = $.parseJSON(data);
                    $.each(obj, function (i) {
                        /***未读***/
                        if (obj[i].read_status == 0) {
                            strTable += "<a id='" + obj[i].message_id + "' name='" + obj[i].type_name + "' onclick='showGgxxDetail(this)' class='list-group-item' title='" + obj[i].message_title + "'><span class='glyphicon glyphicon-envelope text-danger' title='未读'></span><small class='text-primary'>【" + obj[i].type_name + "】</small>" + obj[i].message_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].message_send_time + "</span></a>";
                        }
                        /***已读***/
                        else {
                            strTable += "<a id='" + obj[i].message_id + "' name='" + obj[i].type_name + "' onclick='showGgxxDetail(this)' class='list-group-item' title='" + obj[i].message_title + "'><span class='glyphicon glyphicon-envelope' title='已读'></span><small class='text-primary'>【" + obj[i].type_name + "】</small>" + obj[i].message_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].message_send_time + "</span></a>";
                        }
                    });
                    $("#ggxx").html(strTable);
                    strTable = "";
                }
                else {
                    $("#ggxx").html(strTable);
                }
            });

            /***“三重一大”***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "szyd" })
            .done(function (data) {
                if (data != "null" && data != "") {
                    obj = $.parseJSON(data);
                    $.each(obj, function (i) {
                        strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");' href='#' class='list-group-item'><span class='text-primary'>●&nbsp;</span><small class='text-primary'>【" + obj[i].type_name + "】</small>" + obj[i].archive_title.substring(0, 15) + "<span class='pull-right'>" + obj[i].create_time + "</span></a>";
                    });
                    $("#major").html(strTable).fadeIn();
                    strTable = "";
                }
                else {
                    $("#major").html(strTable);
                }
            });

            /***待办事项***/
            $.get("/Ajax/PublicQuery.ashx", { pageState: "dbsx" })
            .done(function (data) {
                if (data != "null" && data != "") {
                    obj = $.parseJSON(data);
                    $.each(obj, function (i) {
                        /***已过期***/
                        if (obj[i].is_expire < 0) {
                            strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");' href='#' class='list-group-item' style='color:#d9534f;'><span class='glyphicon glyphicon-exclamation-sign text-danger' title='已过期'></span><small class='text-primary'>【" + (obj[i].task_type == "1" ? obj[i].type_name + " — 抄送" : obj[i].type_name) + "】</small>" + obj[i].archive_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].limit_time + "</span></a>";
                        }
                            /***没过期，且需要提醒***/
                        else if (obj[i].remind_time < 0 && obj[i].is_expire > 0) {
                            //剩余时间为正小数
                            if (obj[i].is_expire<86400) {
                                strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");' href='#' class='list-group-item' style='color:#f0ad4e;'><span class='glyphicon glyphicon-flash' style='color:#f0ad4e;' title='还有" + Math.floor((obj[i].is_expire / 3600).toFixed(1)) + "小时'></span><small class='text-primary'>【" + (obj[i].task_type == "1" ? obj[i].type_name + " — 抄送" : obj[i].type_name) + "】</small>" + obj[i].archive_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].limit_time + "</span></a>";
                            }
                                //剩余时间为正整数
                            else if (obj[i].is_expire>86400) {
                                strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");' href='#' class='list-group-item' style='color:#f0ad4e;'><span class='glyphicon glyphicon-flash' style='color:#f0ad4e;' title='还有" + Math.floor(obj[i].is_expire / 84600) + "天'></span><small class='text-primary'>【" + (obj[i].task_type == "1" ? obj[i].type_name + " — 抄送" : obj[i].type_name) + "】</small>" + obj[i].archive_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].limit_time + "</span></a>";
                            }
                        }
                            //其它
                        else {
                            strTable += "<a title='" + obj[i].archive_title + "' onclick='showDetail(" + obj[i].archive_id + "," + obj[i].archive_task_id + "," + obj[i].archive_type + ");' href='#' class='list-group-item'><span class='text-primary'>●&nbsp;</span><small class='text-primary'>【" + (obj[i].task_type == "1" ? obj[i].type_name + " — 抄送" : obj[i].type_name) + "】</small>" + obj[i].archive_title.substring(0, 25) + "<span class='pull-right'>" + obj[i].limit_time + "</span></a>";
                        }
                    });
                    $("#readyWork").html(strTable);
                    strTable = "";
                    $readyWork = $("#readyWork > a");//获取所有待办事项DOM集合
                    /***遍历该集合判断前面是否有图标（即将过期）***/
                    $readyWork.each(function (i) {
                        if ($(this).children("span:first()").attr("title") != undefined && $(this).children("span:first()").attr("title") != "已过期") {
                            var a_span = $(this).children("span").eq(0);//获取图标
                            setInterval(function () { a_span.fadeOut(800).fadeIn(800) }, 800);
                        }
                    });
                }
                else {
                    $("#readyWork").html(strTable);
                }
            });
            timer = window.setTimeout(refresh, 30000);//30秒定时刷新，并设定刷新ID，卸载刷新时使用
        }

        /***弹出iFrame查看详细（需要传递多个ID时，调用此方法）***/
        function showDetail(archive_id, archive_task_id, archive_type) {
            var src;
            /***待办事项***/
            if (archive_task_id != undefined) {
                switch (archive_type) {
                    case 10:
                        src = "/Archive/newPieces.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 11:
                        src = "/Archive/NewWork.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 12:
                        src = "/Archive/NewUnitDoc.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 20: case 21: case 22: case 23:
                        src = "/Archive/newSupInfo.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 24:
                        src = "/Admin/newProposal.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 32:
                        src = "/Admin/newPersonnel.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 33:
                    case 331:
                        src = "/Admin/sel_Finance.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                    case 40: case 41: case 42: case 43: case 44: case 61: case 62:
                        src = "/Approve/newApprove.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "&type=" + archive_type + "";
                        break;
                    case 51:
                        src = "/Risk/newRisk.aspx?arid=" + archive_id + "&tid=" + archive_task_id + "";
                        break;
                }
            }
                /***“三重一大”***/
            else {
                switch (archive_type) {
                    case 10:
                        src = "/Archive/sel_Generalpieces.aspx?arid=" + archive_id + "";
                        break;
                    case 11:
                        src = "/Archive/sel_Ordinarypieces.aspx?arid=" + archive_id + "";
                        break;
                    case 12:
                        src = "/Archive/sel_UnitDoc.aspx?arid=" + archive_id + "";
                        break;
                    case 20: case 21: case 22: case 23:
                        src = "/Archive/sel_supInfo.aspx?arid=" + archive_id + "";
                        break;
                    case 24:
                        src = "/Admin/sel_Proposal.aspx?arid=" + archive_id + "";
                        break;
                    case 32:
                        src = "/Admin/sel_Personnal.aspx?arid=" + archive_id + "";
                        break;
                    case 33:
                        src = "/Admin/selFinance.aspx?arid=" + archive_id + "";
                        break;
                    case 51:
                        src = "/Risk/sel_risk.aspx?arid=" + archive_id + "";
                        break;
                    case 61: case 62:
                        src = "/Approve/sel_Approve.aspx?arid=" + archive_id  +"&type=" + archive_type + "";
                        break;
                    case 71:
                        src = "/Archive/selTiobnoedit.aspx?arid=" + archive_id + "";
                        break;
                }
            }
            $.layer({
                type: 2,
                title: "公文办理",
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '600px'],
                offset: ['10px', ''],
                iframe: { src: src }
            });
        }

        /***公告消息查看详细***/
        function showGgxxDetail(btn) {
            var src, title;
            switch ($(btn).attr("name")) {
                case "公告":
                    title = "公告";
                    src = "/Archive/msgInfo.aspx?mid=" + $(btn).attr("id") + "";
                    break;
                case "会议":
                    title = "会议";
                    src = "/Meeting/ViewMeeting.aspx?mid=" + $(btn).attr("id") + "";
                    break;
            }
            $.layer({
                type: 2,
                title: title,
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '600px'],
                offset: ['10px', ''],
                iframe: { src: src }
            });
        }

        /***下拉链接调整***/
        function showLink(link, selectObj)
        {
            if (link != "") {
                window.open(link);
                selectObj.options[0].selected = true;
            }
        }

        /***首页点击公文任务办理后返回刷新页面***/
        function doRefresh() { refresh(); }
        function mbtnDelete(favorite_id) {
            if (confirm("确定取消收藏此份公文")) {
                $.get("/Ajax/PublicSave.ashx", {
                    pageState: "scjDel",
                    favorite_id: favorite_id
                },
              function (data) {
                  alert("删除成功");
                  $("#favorites").modal("hide");
              });
            }
            
        }
        function showDetail2(archive_id, archive_type) {
            var src;
            /***“三重一大”***/
            switch (archive_type) {
                case 10:
                    src = "/Archive/sel_Generalpieces.aspx?arid=" + archive_id + "";
                    break;
                case 11:
                    src = "/Archive/sel_Ordinarypieces.aspx?arid=" + archive_id + "";
                    break;
                case 12:
                    src = "/Archive/sel_UnitDoc.aspx?arid=" + archive_id + "";
                    break;
                case 20: case 21: case 22: case 23:
                    src = "/Archive/sel_supInfo.aspx?arid=" + archive_id + "";
                    break;
                case 24:
                    src = "/Admin/sel_Proposal.aspx?arid=" + archive_id + "";
                    break;
                case 32:
                    src = "/Admin/sel_Personnal.aspx?arid=" + archive_id + "";
                    break;
                case 33:
                    src = "/Admin/selFinance.aspx?arid=" + archive_id + "";
                    break;
                case 40: case 41: case 42: case 43: case 44:
                    src = "/Approve/sel_Approve.aspx?arid=" + archive_id + "&type=" + archive_type + "";
                    break;
                case 51:
                    src = "/Risk/sel_risk.aspx?arid=" + archive_id + "";
                    break;
            }
            $.layer({
                type: 2,
                title: "收藏夹",
                shadeClose: true, //开启点击遮罩关闭层
                //shade: [0], //不显示遮罩
                area: ['985px', '500px'],
                offset: ['100px', ''],
                iframe: { src: src }
            });
        }
    </script>
</body>
</html>