<%@ WebHandler Language="C#" Class="PublicQuery" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PDTech.OA.Model;

/// <summary>
/// Creator：ZSX
/// Date：2014-6-26
/// Use：Public Query
/// Note：Allow Overload
/// </summary>
public class PublicQuery : IHttpHandler, IRequiresSessionState
{
    string pageState, strWhere = "", currentPage = "1", strUserId = "";
    int totalNum = 0;//分页总条数
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Request.QueryString["xxx"];//Get获取
        //context.Request["xxx"];//Post获取
        pageState = context.Request["pageState"];//获取功能模块
        if (context.Session["user_id"] != null)
        {
            switch (pageState)
            {
                case null:
                    pageState = context.Request.QueryString["pageState"];//因调用此文件可能为Get/Post，可能需要分别获取
                    break;
                case"easyUI":
                    /***EasyUI测试数据***/
                    PDTech.OA.BLL.OA_ARCHIVE easyUI_bll = new PDTech.OA.BLL.OA_ARCHIVE();//查询所有公文
                    context.Response.Write(S_App.DataContractJsonSerialize(easyUI_bll.GetTest(context.Request["page"], context.Request["rows"], out totalNum)).Replace("[", "{\"total\":" + totalNum + ",\"rows\":[").Replace("]", "]}"));
                    break;
                case "message":
                    /***公告查询***/
                    PDTech.OA.BLL.OA_MESSAGE_RECEIVER message_bll = new PDTech.OA.BLL.OA_MESSAGE_RECEIVER();
                    PaginationHelper message_page = new PaginationHelper();
                    //公告标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(om.message_title) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and om.message_send_time between CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    message_page.DataSources = S_App.DataContractJsonSerialize(message_bll.GetAllBulletin(context.Session["user_id"].ToString(), strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    message_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(message_page));
                    break;
                case "document":
                    /***公文查询***/
                    if (!CurrentAccount.ISHavePurview("systemManage"))
                    {
                        throw new Exception("权限错误！");
                    }
                    PDTech.OA.BLL.OA_ARCHIVE_TASK document_bll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    PDTech.OA.Model.OA_MAJOR document_model = new PDTech.OA.Model.OA_MAJOR();
                    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
                    PaginationHelper document_page = new PaginationHelper();
                    //首页查询条件
                    if (context.Request["txt_query"] != "" && context.Request["txt_query"] != null)
                    {
                        strWhere += "and (oa.archive_no like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%' or oa.archive_title like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%' or oa.archive_content like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%') ";
                    }
                    //公文标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and oa.archive_title like '%" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "%' ";
                    }
                    //文件编号
                    if (context.Request["txt_fileNum"] != "" && context.Request["txt_fileNum"] != null)
                    {
                        strWhere += "and oa.archive_no like '%" + AidHelp.FilterSpecial(context.Request["txt_fileNum"]) + "%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and oa.create_time between convert(varchar(10),'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and convert(varchar(10),'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //公文类型
                    if (context.Request["archiveType"] != "0" && context.Request["archiveType"] != null)
                    {
                        strWhere += "and oa.archive_type=" + context.Request["archiveType"] + " ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //人员
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    //部门
                    else if (context.Request["deptname"] != null && context.Request["deptname"] != "0")
                    {
                        IList<PDTech.OA.Model.USER_INFO> userList = userBll.GetModelList(" DEPARTMENT_ID = " + context.Request["deptname"]);
                        foreach (PDTech.OA.Model.USER_INFO item in userList)
                        {
                            strUserId += item.USER_ID.ToString() + ",";
                        }
                        strUserId = strUserId.TrimEnd(",".ToCharArray());
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    document_page.DataSources = S_App.DataContractJsonSerialize(document_bll.GetDocument(strUserId, strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    document_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(document_page));
                    break;
                case "documentQuery":
                    /***公文查询***/
                    PDTech.OA.BLL.OA_ARCHIVE_TASK document_bll_q = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    PDTech.OA.Model.OA_MAJOR document_model_q = new PDTech.OA.Model.OA_MAJOR();
                    PDTech.OA.BLL.USER_INFO userBll_q = new PDTech.OA.BLL.USER_INFO();
                    PaginationHelper document_page_q = new PaginationHelper();
                    //首页查询条件
                    if (context.Request["txt_query"] != "" && context.Request["txt_query"] != null)
                    {
                        strWhere += "and (oa.archive_no like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%' or oa.archive_title like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%' or oa.archive_content like '%" + AidHelp.FilterSpecial(context.Server.UrlDecode(context.Request["txt_query"])) + "%') ";
                    }
                    //公文标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and oa.archive_title like '%" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "%' ";
                    }
                    //文件编号
                    if (context.Request["txt_fileNum"] != "" && context.Request["txt_fileNum"] != null)
                    {
                        strWhere += "and oa.archive_no like '%" + AidHelp.FilterSpecial(context.Request["txt_fileNum"]) + "%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and oa.create_time between convert(varchar(10),'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and convert(varchar(10),'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //公文类型
                    if (context.Request["archiveType"] != "0" && context.Request["archiveType"] != null)
                    {
                        strWhere += "and oa.archive_type=" + context.Request["archiveType"] + " ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //人员
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    //部门
                    else if (context.Request["deptname"] != null && context.Request["deptname"] != "0")
                    {
                        IList<PDTech.OA.Model.USER_INFO> userList = userBll_q.GetModelList(" DEPARTMENT_ID = " + context.Request["deptname"]);
                        foreach (PDTech.OA.Model.USER_INFO item in userList)
                        {
                            strUserId += item.USER_ID.ToString() + ",";
                        }
                        strUserId = strUserId.TrimEnd(",".ToCharArray());
                    }
                    //未指定人员或部门时，默认人员未本人，及本人下属处室
                    if (string.IsNullOrEmpty(strUserId))
                    {
                        IList<PDTech.OA.Model.USER_INFO> userList = userBll_q.GetOwnerDeptUsersModelList(context.Session["user_id"].ToString());
                        List<string> usersIds = (from u in userList select u.USER_ID.Value.ToString()).ToList();
                        usersIds.Add(context.Session["user_id"].ToString());
                        strUserId = string.Join(",", usersIds);
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    bool isall = false;
                    if (CurrentAccount.ISHavePurview("leader"))
                    {
                        isall = true;
                    }
                    document_page_q.DataSources = S_App.DataContractJsonSerialize(document_bll_q.GetDocument(strUserId, strWhere, currentPage, context.Request["pageSize"], out totalNum, isall));
                    document_page_q.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(document_page_q));
                    break;
                case "dbsx":
                    /***待办事项***/
                    PDTech.OA.BLL.OA_ARCHIVE_TASK dbsx_bll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    context.Response.Write(S_App.DataContractJsonSerialize(dbsx_bll.GetReadyWork(context.Session["user_id"].ToString())));//查询待办事项
                    break;
                case "szyd":
                    /***三重一大***/
                    PDTech.OA.BLL.OA_ARCHIVE szyd_bll = new PDTech.OA.BLL.OA_ARCHIVE();
                    context.Response.Write(S_App.DataContractJsonSerialize(szyd_bll.GetMajor()));//查询三重一大
                    break;
                case "szydMore":
                    /***所有三重一大***/
                    PDTech.OA.BLL.OA_ARCHIVE szydMore_bll = new PDTech.OA.BLL.OA_ARCHIVE();
                    PaginationHelper szydMore_page = new PaginationHelper();
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere = "and upper(oa.archive_title) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%'";//带查询条件
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    szydMore_page.DataSources = S_App.DataContractJsonSerialize(szydMore_bll.GetMajor(strWhere, currentPage, context.Request["pageSize"], out totalNum));//查询三重一大
                    szydMore_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(szydMore_page));
                    break;
                case "ggxx":
                    /***公告消息***/
                    PDTech.OA.BLL.OA_MESSAGE_RECEIVER ggxx_bll = new PDTech.OA.BLL.OA_MESSAGE_RECEIVER();
                    context.Response.Write(S_App.DataContractJsonSerialize(ggxx_bll.GetBulletin(context.Session["user_id"].ToString())));//查询公告消息
                    break;
                case "gwzz":
                    /***岗位职责***/
                    PDTech.OA.BLL.DUTY_RESPONSIBILITY gwzz_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();
                    context.Response.Write(gwzz_bll.GetResponsibility(context.Session["user_id"].ToString()));//查询当前用户岗位职责
                    break;
                case "gwzzMore":
                    /***所有岗位职责***/
                    PDTech.OA.BLL.DUTY_RESPONSIBILITY gwzzMore_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();
                    PaginationHelper gwzzMore_page = new PaginationHelper();
                    //所在单位
                    if (context.Request["company"] != "0" && context.Request["company"] != null)
                    {
                        strWhere += "and d.department_id='" + AidHelp.FilterSpecial(context.Request["company"]) + "' ";
                    }
                    //岗位名称
                    if (context.Request["txt_dutyName"] != "" && context.Request["txt_dutyName"] != null)
                    {
                        strWhere += "and upper(dr.duty_name) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_dutyName"]) + "') + '%' ";
                    }
                    //岗位职责
                    if (context.Request["txt_responsibility"] != "" && context.Request["txt_responsibility"] != null)
                    {
                        strWhere += "and upper(dr.responsibility) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_responsibility"]) + "') + '%' ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    gwzzMore_page.DataSources = S_App.DataContractJsonSerialize(gwzzMore_bll.GetAllResponsibility(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    gwzzMore_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(gwzzMore_page));
                    break;
                case "gwfx":
                    /***岗位风险***/
                    PDTech.OA.BLL.DUTY_RISK_INFO gwfx_bll = new PDTech.OA.BLL.DUTY_RISK_INFO();
                    context.Response.Write(S_App.DataContractJsonSerialize(gwfx_bll.GetRiskInfo(context.Session["user_id"].ToString())));//查询当前用户最新的一条岗位风险
                    break;
                case "gwfxIndexMore":
                    /***首页岗位风险更多***/
                    PDTech.OA.BLL.DUTY_RISK_INFO gwfxIndexMore_bll = new PDTech.OA.BLL.DUTY_RISK_INFO();
                    context.Response.Write(S_App.DataContractJsonSerialize(gwfxIndexMore_bll.GetRiskInfoMore(context.Session["user_id"].ToString())));//查询当前用户所有的岗位风险
                    break;
                case "gwfxMore":
                    /***岗位风险***/
                    PDTech.OA.BLL.DUTY_RISK_INFO gwfxMore_bll = new PDTech.OA.BLL.DUTY_RISK_INFO();
                    PaginationHelper gwfxMore_page = new PaginationHelper();
                    //所在单位
                    if (context.Request["company"] != "0" && context.Request["company"] != null)
                    {
                        strWhere += "and d.department_id='" + AidHelp.FilterSpecial(context.Request["company"]) + "' ";
                    }
                    //岗位名称
                    if (context.Request["txt_dutyName"] != "" && context.Request["txt_dutyName"] != null)
                    {
                        strWhere += "and upper(dri.duty_name) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_dutyName"]) + "') + '%' ";
                    }
                    //岗位风险
                    if (context.Request["txt_dutyRisk"] != "" && context.Request["txt_dutyRisk"] != null)
                    {
                        strWhere += "and upper(dri.risk_name) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_dutyRisk"]) + "') + '%' ";
                    }
                    //风险等级
                    if (context.Request["riskLevel"] != "0" && context.Request["riskLevel"] != null)
                    {
                        strWhere += "and dri.risk_level='" + AidHelp.FilterSpecial(context.Request["riskLevel"]) + "' ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    gwfxMore_page.DataSources = S_App.DataContractJsonSerialize(gwfxMore_bll.GetAllRiskInfo(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    gwfxMore_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(gwfxMore_page));
                    break;
                case "riskModule":
                    /***风险模块--日常办公公文***/
                    PDTech.OA.BLL.WORKFLOW_TEMPLATE riskModule_bll = new PDTech.OA.BLL.WORKFLOW_TEMPLATE();
                    IList<PDTech.OA.Model.OA_RISK_MODULE> riskList = riskModule_bll.GetRiskModule();
                    PDTech.OA.Model.OA_RISK_MODULE riskModel = new OA_RISK_MODULE();
                    riskModel.flow_template_id = "0";
                    riskModel.flow_template_name = "---请选择---";
                    riskList.Insert(0, riskModel);
                    context.Response.Write(S_App.DataContractJsonSerialize(riskList));//查询日常办公公文
                    break;
                case "riskModule2":
                    /***风险模块--日常办公公文***/
                    IList<PDTech.OA.Model.OA_RISK_MODULE> risk2List = new List<PDTech.OA.Model.OA_RISK_MODULE>();
                    PDTech.OA.Model.OA_RISK_MODULE riskModel1 = new OA_RISK_MODULE();
                    riskModel1.flow_template_id = "0";
                    riskModel1.flow_template_name = "---请选择---";
                    risk2List.Add(riskModel1);
                    PDTech.OA.Model.OA_RISK_MODULE riskModel2 = new OA_RISK_MODULE();
                    riskModel2.flow_template_id = "1";
                    riskModel2.flow_template_name = "基建项目";
                    risk2List.Add(riskModel2);
                    PDTech.OA.Model.OA_RISK_MODULE riskModel3 = new OA_RISK_MODULE();
                    riskModel3.flow_template_id = "2";
                    riskModel3.flow_template_name = "市财政项目";
                    risk2List.Add(riskModel3);
                    context.Response.Write(S_App.DataContractJsonSerialize(risk2List));//查询日常办公公文
                    break;
                case "riskStep":
                    /***风险步骤--日常办公公文***/
                    PDTech.OA.BLL.WORKFLOW_STEP riskStep_bll = new PDTech.OA.BLL.WORKFLOW_STEP();
                    IList<PDTech.OA.Model.OA_RISK_STEP> riskStepList = riskStep_bll.GetRiskStep(context.Request["flow_template_id"]);
                    PDTech.OA.Model.OA_RISK_STEP riskStepModel = new OA_RISK_STEP();
                    riskStepModel.step_id = 0;
                    riskStepModel.step_name = "---请选择---";
                    riskStepList.Insert(0, riskStepModel);
                    context.Response.Write(S_App.DataContractJsonSerialize(riskStepList));//查询风险步骤
                    break;
                case "projectStep":
                    /***风险步骤--水务项目***/
                    PDTech.OA.BLL.WORKFLOW_STEP projectStep_bll = new PDTech.OA.BLL.WORKFLOW_STEP();
                    IList<PDTech.OA.Model.OA_RISK_STEP> projectStepList = projectStep_bll.GetProjectStep(context.Request["project_type"]);
                    PDTech.OA.Model.OA_RISK_STEP projectStepModel = new OA_RISK_STEP();
                    projectStepModel.step_id = 0;
                    projectStepModel.step_name = "---请选择---";
                    projectStepList.Insert(0, projectStepModel);
                    context.Response.Write(S_App.DataContractJsonSerialize(projectStepList));//查询风险步骤
                    break;
                case "riskControl":
                    /***风险防控***/
                    PDTech.OA.BLL.RISK_POINT_INFO riskControl_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
                    PaginationHelper riskControl_page = new PaginationHelper();
                    /***日常办公公文***/
                    if (context.Request["riskType"] != "0" && context.Request["riskType"] != null)
                    {
                        if (context.Request["riskType"] == "OA_WORKFLOW_STEP")
                        {
                            strWhere += "and step_type='" + AidHelp.FilterSpecial(context.Request["riskType"]) + "' ";
                            //风险模块
                            if (context.Request["riskModule"] != "0")
                            {
                                strWhere += "and step_id in (select step_id from workflow_step where flow_template_id='" + AidHelp.FilterSpecial(context.Request["riskModule"]) + "') ";
                            }
                            //风险步骤
                            if (context.Request["riskStep"] != "0" && context.Request["riskStep"] != null && context.Request["riskStep"] != "")
                            {
                                strWhere += "and step_id='" + AidHelp.FilterSpecial(context.Request["riskStep"]) + "' ";
                            }
                        }
                        /***水务项目***/
                        else if (context.Request["riskType"] == "SW_PROJECT_STEP")
                        {
                            strWhere += "and step_type='" + AidHelp.FilterSpecial(context.Request["riskType"]) + "' ";
                            //风险模块
                            if (context.Request["riskModule"] != "0")
                            {
                                strWhere += "and step_id in (select step_id from sw_project_step_type where project_type='" + AidHelp.FilterSpecial(context.Request["riskModule"]) + "') ";
                            }
                            //风险步骤
                            if (context.Request["riskStep"] != "0" && context.Request["riskStep"] != null && context.Request["riskStep"] != "")
                            {
                                strWhere += "and step_id='" + AidHelp.FilterSpecial(context.Request["riskStep"]) + "' ";
                            }
                        }
                        //当前页码
                        if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                        {
                            currentPage = context.Request["currentPage"];
                        }
                        //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                        riskControl_page.DataSources = S_App.DataContractJsonSerialize(riskControl_bll.GetRiskPointInfo(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                        riskControl_page.TotalNum = totalNum;//数据源总条数
                        //第二次序列化（包含总条数）
                        context.Response.Write(S_App.DataContractJsonSerialize(riskControl_page));
                    }
                    else
                    {
                        //当前页码
                        if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                        {
                            currentPage = context.Request["currentPage"];
                        }
                        //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                        riskControl_page.DataSources = S_App.DataContractJsonSerialize(riskControl_bll.GetRiskPointInfo(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                        riskControl_page.TotalNum = totalNum;//数据源总条数
                        //第二次序列化（包含总条数）
                        context.Response.Write(S_App.DataContractJsonSerialize(riskControl_page));

                    }
                    break;
                case "expireDocument":
                    /***超期预警--日常办公公文***/
                    PDTech.OA.BLL.OA_ARCHIVE_TASK expireDocument_bll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    PDTech.OA.Model.OA_EXPIRE_DOCUMENT expireDocument_model = new PDTech.OA.Model.OA_EXPIRE_DOCUMENT();
                    PaginationHelper expireDocument_page = new PaginationHelper();
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    
                    //公文标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(oa.archive_title) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //文件编号
                    if (context.Request["txt_fileNum"] != "" && context.Request["txt_fileNum"] != null)
                    {
                        strWhere += "and upper(oa.archive_no) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_fileNum"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and oat.start_time between CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //所在部门
                    if (context.Request["company"] != "0" && context.Request["company"] != null)
                    {
                        strWhere += "and (oat.owner_id in (select user_id from user_info where department_id=" + context.Request["company"] + ")) ";
                    }
                    //公文类型
                    if (context.Request["archiveType"] != "0" && context.Request["archiveType"] != null)
                    {
                        strWhere += "and oa.archive_type=" + context.Request["archiveType"] + " ";
                    }
                    //风险处置
                    if (context.Request["riskHandle"] != "0" && context.Request["riskHandle"] != null)
                    {
                        switch (context.Request["riskHandle"])
                        {
                            //未处理
                            case"1":
                                strWhere += "and not exists(select risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id=oat.archive_id and rhm.archive_task_id = oat.archive_task_id) ";
                                break;
                            //已处理
                            case"2":
                                strWhere += "and exists(select risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id=oat.archive_id and rhm.archive_task_id = oat.archive_task_id) ";
                                break;
                        }
                    }
                    if (!CurrentAccount.ISHavePurview("leader"))
                    {
                        strWhere += string.Format(@"and (oat.owner_id={0} or (oat.owner_id in( select USER_ID from USER_INFO where DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID={0})) 
            ) or (oat.owner_id in (select USER_ID from USER_INFO where DEPARTMENT_ID in(select DEPARTMENT_ID from DEPARTMENT_DEFAULT_USER where USER_ID={0}))))", strUserId);

                    }
                                       //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    expireDocument_page.DataSources = S_App.DataContractJsonSerialize(expireDocument_bll.GetExpireDocument(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    expireDocument_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(expireDocument_page));
                    break;
                case "expireWater":
                    /***超期预警--水务项目***/
                    PDTech.OA.BLL.SW_PROJECT_STEP expireWater_bll = new PDTech.OA.BLL.SW_PROJECT_STEP();
                    PDTech.OA.Model.SW_EXPIRE_WATER expireWater_model = new PDTech.OA.Model.SW_EXPIRE_WATER();
                    PaginationHelper expireWater_page = new PaginationHelper();
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    //项目标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(project_name) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and start_time between '" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "' and '" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "' ";
                    }
                    //风险处置
                    if (context.Request["riskHandle"] != "0" && context.Request["riskHandle"] != null)
                    {
                        switch (context.Request["riskHandle"])
                        {
                            //未处理
                            case "1":
                                strWhere += "and not exists(select risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id=sw_project_step.project_id and rhm.archive_task_id = sw_project_step.project_step_id) ";
                                break;
                            //已处理
                            case "2":
                                strWhere += "and exists(select risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id=sw_project_step.project_id and rhm.archive_task_id = sw_project_step.project_step_id) ";
                                break;
                        }
                    }
                    if (!CurrentAccount.ISHavePurview("leader"))
                    {
                        strWhere += string.Format(@"and (sw_project_step.owner=(select FULL_NAME from USER_INFO where USER_ID= {0}) or (sw_project_step.owner in( select FULL_NAME from USER_INFO where DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID={0})) 
            ) or (sw_project_step.owner in (select FULL_NAME from USER_INFO where DEPARTMENT_ID in(select DEPARTMENT_ID from DEPARTMENT_DEFAULT_USER where USER_ID={0}))))", strUserId);

                    }
                   
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    expireWater_page.DataSources = S_App.DataContractJsonSerialize(expireWater_bll.GetExpireWater(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    expireWater_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(expireWater_page));
                    break;
                case "riskDocument":
                    /***风险项目--日常办公公文***/
                    PDTech.OA.BLL.OA_ARCHIVE_TASK riskDocument_bll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    PDTech.OA.Model.OA_RISK_DOCUMENT riskDocument_model = new PDTech.OA.Model.OA_RISK_DOCUMENT();
                    PaginationHelper riskDocument_page = new PaginationHelper();
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    //公文标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(oa.archive_title) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //文件编号
                    if (context.Request["txt_fileNum"] != "" && context.Request["txt_fileNum"] != null)
                    {
                        strWhere += "and upper(oa.archive_no) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_fileNum"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and oat.start_time between CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //所在部门
                    if (context.Request["company"] != "0" && context.Request["company"] != null)
                    {
                        strWhere += "and (oat.owner_id in (select user_id from user_info where department_id=" + context.Request["company"] + ")) ";
                    }
                    //公文类型
                    if (context.Request["archiveType"] != "0" && context.Request["archiveType"] != null)
                    {
                        strWhere += "and oa.archive_type=" + context.Request["archiveType"] + " ";
                    }
                    strWhere += string.Format(@"and (oat.owner_id={0} or (oat.owner_id in( select USER_ID from USER_INFO where DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID={0})) 
            ) or (oat.owner_id in (select USER_ID from USER_INFO where DEPARTMENT_ID in(select DEPARTMENT_ID from DEPARTMENT_DEFAULT_USER where USER_ID={0}))))", strUserId);

                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    riskDocument_page.DataSources = S_App.DataContractJsonSerialize(riskDocument_bll.GetRisk(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    riskDocument_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(riskDocument_page));
                    break;
                case "riskWater":
                    /***风险项目--日常办公公文***/
                    PDTech.OA.BLL.SW_PROJECT_STEP riskWater_bll = new PDTech.OA.BLL.SW_PROJECT_STEP();
                    PDTech.OA.Model.SW_RISK_WATER riskWater_model = new PDTech.OA.Model.SW_RISK_WATER();
                    PaginationHelper riskWater_page = new PaginationHelper();
                    if (context.Request["username"] != null && context.Request["username"] != "0")
                    {
                        strUserId = context.Request["username"].ToString();
                    }
                    //公文标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(project_name) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and start_time between '" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "' and '" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "' ";
                    }
                    strWhere += string.Format(@"and (riskWater.owner=(select FULL_NAME from USER_INFO where USER_ID= {0}) or (riskWater.owner in( select FULL_NAME from USER_INFO where DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID={0})) 
            ) or (riskWater.owner in (select FULL_NAME from USER_INFO where DEPARTMENT_ID in(select DEPARTMENT_ID from DEPARTMENT_DEFAULT_USER where USER_ID={0}))))", strUserId);

                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    riskWater_page.DataSources = S_App.DataContractJsonSerialize(riskWater_bll.GetRiskWater(strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    riskWater_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(riskWater_page));
                    break;
                case "archiveType":
                    /***公文类型的Tree***/
                    PDTech.OA.BLL.OA_ARCHIVE_TYPE archiveType_bll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
                    DataTable dtArchiveType;//初始化公文类型
                    dtArchiveType = archiveType_bll.GetArchiveType();
                    ARCHIVE_TYPE archiveType_rootNode = new ARCHIVE_TYPE()
                    {
                        /***组织根节点的json格式***/
                        id = "1",
                        text = "收藏夹",
                        iconCls = "glyphicon glyphicon-folder-open"
                    };
                    S_App.GetDataString(dtArchiveType, "1", archiveType_rootNode);//生成jsonTree结构
                    List<ARCHIVE_TYPE> ArchiveTypeList = new List<ARCHIVE_TYPE>();
                    ArchiveTypeList.Add(archiveType_rootNode);//如果是List，序列化时会添加[ ]符号
                    context.Response.Write(S_App.DataContractJsonSerialize(ArchiveTypeList));//序列化为json并返回
                    break;
                case"archiveTypeOption":
                    /***公文类型的下拉框***/
                    PDTech.OA.BLL.OA_ARCHIVE_TYPE archiveTypeOption_bll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();//公文类型
                    PDTech.OA.Model.ARCHIVE_TYPE_OPTION atoModel = new ARCHIVE_TYPE_OPTION();
                    atoModel.archive_type = "0";
                    atoModel.type_name = "全部";
                    IList<PDTech.OA.Model.ARCHIVE_TYPE_OPTION> atoList = archiveTypeOption_bll.GetArchiveTypeOption();
                    atoList.Insert(0, atoModel);
                    context.Response.Write(S_App.DataContractJsonSerialize(atoList));//查询公文类型
                    break;
                case "company":
                    /***部门单位***/
                    PDTech.OA.BLL.DUTY_RESPONSIBILITY company_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();//岗位职责
                    PDTech.OA.Model.DEPARTMENT_NAME depModel0 = new DEPARTMENT_NAME();
                    depModel0.department_id = "0";
                    depModel0.department_name = "全部";
                    IList<PDTech.OA.Model.DEPARTMENT_NAME> depList = company_bll.GetDepartmentName();
                    depList.Insert(0, depModel0);
                    context.Response.Write(S_App.DataContractJsonSerialize(depList));//查询部门列表
                    break;
                case "gwry":
                    /***岗位人员的Tree***/
                    PDTech.OA.BLL.DUTY_RESPONSIBILITY gwry_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();//岗位职责
                    DataTable dtUser, dtDept;//初始化岗位人员，部门单位
                    /***是否带查询条件***/
                    if (context.Request["txt_name"] != "" && context.Request["txt_name"] != null)
                    {
                        dtUser = gwry_bll.GetPerson(AidHelp.FilterSpecial(context.Request["txt_name"].ToString()));//查询岗位人员（带姓名查询条件）
                    }
                    else
                    {
                        dtUser = gwry_bll.GetPerson();//查询岗位人员（查询所有人）
                    }
                    dtDept = gwry_bll.GetDepartment();//查询部门单位
                    if (dtDept.Rows.Count > 0)
                    {
                        DataRow[] CRow = dtDept.Select("department_id='1'");//内存中查询根节点（即成都市水务局）
                        PersonTree rootNode = new PersonTree()
                        {
                            /***组织根节点的json格式***/
                            id = CRow[0]["department_id"].ToString(),
                            text = CRow[0]["department_name"].ToString(),
                            status = "department",
                            iconCls = "glyphicon glyphicon-folder-close"
                        };
                        S_App.GetDataString(dtDept, dtUser, "1", rootNode);//生成jsonTree结构
                        List<PersonTree> PersonTreeList = new List<PersonTree>();
                        PersonTreeList.Add(rootNode);//如果是List，序列化时会添加[ ]符号
                        context.Response.Write(S_App.DataContractJsonSerialize(PersonTreeList));//序列化为json并返回
                    }
                    break;
                case "folder":
                    /***获取指定目录下的文件夹***/
                    DirectoryInfo rootDi = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "database");//获取项目相对路径并指定"资料库"文件夹
                    FolderTree rootFolder = new FolderTree()
                    {
                        /***组织根节点的json格式***/
                        text = "资料库",
                        iconCls = "glyphicon glyphicon-folder-open",
                        fullPath = rootDi.FullName
                    };
                    S_App.GetDirectorInfo(rootDi, rootFolder);
                    List<FolderTree> FolderTreeList = new List<FolderTree>();
                    FolderTreeList.Add(rootFolder);//如果是List，序列化时会添加[ ]符号
                    context.Response.Write(S_App.DataContractJsonSerialize(FolderTreeList));//序列化为json并返回
                    break;
                case "file":
                    /***获得点击时的路径，并查询其目录下的子文件***/
                    DirectoryInfo di;
                    FileInfo[] files;
                    if (context.Request["txt_fileName"] != "" && context.Request["txt_fileName"] != null)
                    {
                        di = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "database");//指定目录
                        files = di.GetFiles("*" + context.Request["txt_fileName"] + "*", SearchOption.AllDirectories);//以根目录为查询起点，向下查询
                    }
                    else
                    {
                        di = new DirectoryInfo(context.Request["fullPath"]);//指定目录
                        files = di.GetFiles();//获取文件
                    }
                    List<FileTree> filesList =
                        (from f in files
                         select new FileTree()
                             {
                                 text = f.Name,
                                 relativePath = f.FullName.Replace(System.AppDomain.CurrentDomain.BaseDirectory, "\\").Replace("\\", "/"),//相对路径
                                 modifyTime = f.LastWriteTime.ToString("yyyy年MM月dd日")
                             }).ToList();//转换list
                    context.Response.Write(S_App.DataContractJsonSerialize(filesList));//转换json并回调至前端
                    break;
                case "uInfo":
                    /***个人信息***/
                    PDTech.OA.BLL.USER_INFO uInfo_bll = new PDTech.OA.BLL.USER_INFO();
                    context.Response.Write(S_App.DataContractJsonSerialize(uInfo_bll.GetUserInfo(Convert.ToDecimal(context.Session["user_id"]))));//查询当前登录用户信息
                    break;
                case "favorites":
                    /***收藏夹***/
                    PDTech.OA.BLL.OA_FAVORITE favorites_bll = new PDTech.OA.BLL.OA_FAVORITE();
                    context.Response.Write(S_App.DataContractJsonSerialize(favorites_bll.GetFavorite(context.Session["user_id"].ToString(), context.Request["archiveType"])));
                    break;
                case "contact":
                    /***通讯录***/
                    PDTech.OA.BLL.USER_INFO contact_bll = new PDTech.OA.BLL.USER_INFO();
                    if (context.Request["status"] == "department")
                    {
                        context.Response.Write(S_App.DataContractJsonSerialize(contact_bll.GetUserInfoBydeptId(context.Request["id"])));//查询某一部门所有用户信息
                    }
                    else
                    {
                        context.Response.Write(S_App.DataContractJsonSerialize(contact_bll.GetUserInfo(Convert.ToDecimal(context.Request["id"]))));//查询某一用户信息
                    }
                    break;
                case "cPwd":
                    /***修改密码***/
                    PDTech.OA.BLL.USER_INFO cPwd_bll = new PDTech.OA.BLL.USER_INFO();
                    if (FormsAuthentication.HashPasswordForStoringInConfigFile(context.Request["txt_oldPwd"], "MD5") == cPwd_bll.GetUserPassword(context.Session["user_id"].ToString()))
                    {
                        context.Response.Write("yes");
                    }
                    else
                    {
                        context.Response.Write("error");
                    }
                    break;
                case "exit":
                    PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
                    uBll.UpdateLogin_State(CurrentAccount.USER_ID, 0, CurrentAccount.ClientIP);
                    /***安全退出***/
                    context.Session.Clear();
                    context.Response.Write("ok");
                    break;
                case "remind":
                    /***顶部提醒（日常公文、督办工作、公告）***/
                    PDTech.OA.BLL.OA_ARCHIVE_TASK remind_bll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    ///顶部提醒模型
                    PDTech.OA.Model.OA_READY_WORK_COUNT orwc = new OA_READY_WORK_COUNT();
                    string uid = context.Session["user_id"].ToString();
                    DataTable dtTop = remind_bll.GetRemind(uid);
                    if (dtTop != null && dtTop.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtTop.Rows)
                        {
                            switch (item["archive_type"].ToString())
                            {
                                case "10":
                                case "11":
                                case "12":
                                    orwc.RCBG += int.Parse(item["qty"].ToString());
                                    break;
                                case "20":
                                case "21":
                                case "22":
                                case "23":
                                case "24":
                                    orwc.DBGZ += int.Parse(item["qty"].ToString());
                                    break;
                                case "32":
                                    orwc.RSRM += int.Parse(item["qty"].ToString());
                                    break;
                                case "33":
                                case "331":
                                    orwc.SWGCXM += int.Parse(item["qty"].ToString());
                                    break;
                                case "40":
                                case "41":
                                case "42":
                                case "43":
                                case "44":
                                    orwc.XZSP += int.Parse(item["qty"].ToString());
                                    break;
                                case "51":
                                    orwc.FXCZD += int.Parse(item["qty"].ToString());
                                    break;
                                case "999":
                                    orwc.JYRW += int.Parse(item["qty"].ToString());
                                    break;
                                case "1000":
                                    orwc.ZXKS += int.Parse(item["qty"].ToString());
                                    break;
                            }
                        }
                    }
                    orwc.GGXX = remind_bll.GetRemindMessage(uid);
                    orwc.HYTZ = remind_bll.GetRemindMeeting(uid);
                    orwc.CQFXCZD = remind_bll.GetRemindRISK(uid,CurrentAccount.ISHavePurview("leader"));
                    System.Collections.Generic.List<string> resList = new List<string>();
                    if (orwc.RCBG > 0)
                    {
                        resList.Add("<li id='rcgw'>日常公文：<a href='/Archive/AllArchive_Task.aspx?Archive_types=10,11,12' target='mainWorkArea' class='text-danger'>" + orwc.RCBG + "件</a></li>");
                    }
                    if (orwc.DBGZ > 0)
                    {
                        resList.Add("<li id='dbgz'>督办工作：<a href='/Archive/AllArchive_Task.aspx?Archive_types=20,21,22,23,24' target='mainWorkArea' class='text-danger'>" + orwc.DBGZ + "件</a></li>");
                    }
                    if (orwc.GGXX > 0)
                    {
                        resList.Add("<li id='ggxx'>公告消息：<a href='/Archive/MessageQuery.aspx' target='mainWorkArea' class='text-danger'>" + orwc.GGXX + "条</a></li>");
                    }
                    if (orwc.HYTZ > 0)
                    {
                        resList.Add("<li id='hytz'>会议通知：<a href='/Meeting/MeetingList.aspx' target='mainWorkArea' class='text-danger'>" + orwc.HYTZ + "个</a></li>");
                    }
                    if (orwc.RSRM > 0)
                    {
                        resList.Add("<li id='rsrm'>人事任免：<a href='/Archive/AllArchive_Task.aspx?Archive_types=32' target='mainWorkArea' class='text-danger'>" + orwc.RSRM + "件</a></li>");
                    }
                    if (orwc.SWGCXM > 0)
                    {
                        resList.Add("<li id='swgcxm'>水务工程项目：<a href='/Archive/AllArchive_Task.aspx?Archive_types=33' target='mainWorkArea' class='text-danger'>" + orwc.SWGCXM + "件</a></li>");
                    }
                    if (orwc.XZSP > 0)
                    {
                        resList.Add("<li id='xzsp'>行政审批：<a href='/Archive/AllArchive_Task.aspx?Archive_types=40,41,42,43,44' target='mainWorkArea' class='text-danger'>" + orwc.XZSP + "个</a></li>");
                    }
                    if (orwc.FXCZD > 0)
                    {
                        resList.Add("<li id='fxczd'>风险处置单：<a href='/Archive/AllArchive_Task.aspx?Archive_types=51' target='mainWorkArea' class='text-danger'>" + orwc.FXCZD + "个</a></li>");
                    }
                    if (orwc.CQFXCZD > 0)
                    {
                        resList.Add("<li id='cqfxczd'>超期风险：<a href='/Risk/ArRiskList.aspx' target='mainWorkArea' class='text-danger'>" + orwc.CQFXCZD + "个</a></li>");
                    }
                    if (orwc.JYRW > 0)
                    {
                        resList.Add("<li id='jyrw'>教育任务：<a href='/IncorruptEdu/EduTaskList.aspx' target='mainWorkArea' class='text-danger'>" + orwc.JYRW + "个</a></li>");
                    }
                    if (orwc.ZXKS > 0)
                    {
                        resList.Add("<li id='zxks'>在线考试：<a href='/IncorruptEdu/EduTestList.aspx' target='mainWorkArea' class='text-danger'>" + orwc.ZXKS + "个</a></li>");
                    }
                    /*** 页面顶部小菜单移植至此 ***/
                    string resString = string.Format("<ul class='list-inline'>{0}" +
                        "</ul>", string.Join("", resList));
                    context.Response.Write(resString);
                    break;
                case "meeting":
                    /***通知查询***/
                    PDTech.OA.BLL.OA_MEETING_RECEIVER meeting_bll = new PDTech.OA.BLL.OA_MEETING_RECEIVER();
                    PaginationHelper meeting_page = new PaginationHelper();
                    //公告标题
                    if (context.Request["txt_title"] != "" && context.Request["txt_title"] != null)
                    {
                        strWhere += "and upper(om.message_title) like '%' + upper('" + AidHelp.FilterSpecial(context.Request["txt_title"]) + "') + '%' ";
                    }
                    //日期选择
                    if ((context.Request["txt_startTime"] != "" && context.Request["txt_startTime"] != null)
                        && (context.Request["txt_endTime"] != "" && context.Request["txt_endTime"] != null))
                    {
                        strWhere += "and om.message_send_time between CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_startTime"]) + "',120) and CONVERT(DATETIME,'" + AidHelp.FilterSpecial(context.Request["txt_endTime"]) + "',120) ";
                    }
                    //当前页码
                    if (context.Request["currentPage"] != "" && context.Request["currentPage"] != null)
                    {
                        currentPage = context.Request["currentPage"];
                    }
                    //将第一次序列化的json字符串，赋值给另一个数据源以便组织新的数据源（包含totalNum）
                    meeting_page.DataSources = S_App.DataContractJsonSerialize(meeting_bll.GetAllBulletin(context.Session["user_id"].ToString(), strWhere, currentPage, context.Request["pageSize"], out totalNum));
                    meeting_page.TotalNum = totalNum;//数据源总条数
                    //第二次序列化（包含总条数）
                    context.Response.Write(S_App.DataContractJsonSerialize(meeting_page));
                    break;
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}