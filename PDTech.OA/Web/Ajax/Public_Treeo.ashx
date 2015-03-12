<%@ WebHandler Language="C#" Class="Public_Treeo" %>


using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Data;
using System.Collections.Generic;
using PDTech.OA.Model;

public class Public_Treeo : IHttpHandler, IRequiresSessionState
{
    string pageState;
    string action;
    string stempID = "";
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Request.QueryString["xxx"];//Get获取
        //context.Request["xxx"];//Post获取
        PDTech.OA.BLL.USER_INFO dr_bll = new PDTech.OA.BLL.USER_INFO();//岗位职责
        PDTech.OA.BLL.DEPARTMENT dept_bll = new PDTech.OA.BLL.DEPARTMENT();
        PDTech.OA.BLL.OA_ARCHIVE archiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
        PDTech.OA.BLL.WORKFLOW_STEP stepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
        pageState = context.Request.QueryString["pageState"].ToString();//获取功能模块
        stempID = context.Request.QueryString["stemp"].ToString();
        switch (pageState)
        {
            case "gwry":
                DataTable dtDept;//初始化岗位人员，部门单位
                DataTable dtUser = new DataTable();
                /***是否带查询条件***/
                if (string.IsNullOrEmpty(stempID))
                {

                    dtUser = dr_bll.GetUserList(AidHelp.FilterSpecial(context.Request.QueryString["txt_name"].ToString()), "");
                }
                else
                {
                    PDTech.OA.Model.WORKFLOW_STEP stepInfo = stepBll.GetStepInfo(decimal.Parse(stempID));
                    dtUser = dr_bll.GetUserList(AidHelp.FilterSpecial(context.Request.QueryString["txt_name"].ToString()), stepInfo.RIGHT_CODE);//查询岗位人员（带姓名查询条件)

                } 
                dtDept = dept_bll.GetDepartment_DefaultUser();//查询部门单位
                if (dtDept.Rows.Count > 0)
                {
                    DataRow[] CRow = dtDept.Select("department_id='1'");//内存中查询根节点（即成都市水务局）
                    PersonTree rootNode = new PersonTree()
                    {
                        /***组织根节点的json格式***/
                        id = CRow[0]["department_id"].ToString(),
                        text = CRow[0]["department_name"].ToString(),
                        status = "department",
                        iconCls = "glyphicon glyphicon-folder-close",
                        duid = CRow[0]["DEFAULT_USER"].ToString()
                    };
                    AidHelp.GetDataString(dtDept, dtUser, "1", rootNode);//生成jsonTree结构
                    List<PersonTree> PersonTreefList = new List<PersonTree>();
                    PersonTreefList.Add(rootNode);//如果是List，序列化时会添加[ ]符号
                    context.Response.Write(AidHelp.DataContractJsonSerialize(PersonTreefList));//序列化为json并返回
                }
                break;
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