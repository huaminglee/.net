<%@ WebHandler Language="C#" Class="GetUserByDepId" %>

using System;
using System.Web;
using System.Collections.Generic;

public class GetUserByDepId : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string queryState = context.Request.QueryString["queryState"].ToString();
        string retJson = string.Empty;
        switch (queryState)
        {
            case "dept":
                retJson = getDeptList();
                break;
            case "user":
                decimal dept_Id = decimal.Parse(context.Request.QueryString["deptId"].ToString());
                retJson = getUserList(dept_Id);
                break;
        }
        context.Response.Write(retJson);
    }

    public string getDeptList()
    {
        string strJson = string.Empty;
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { Append = " DEPARTMENT_ID<>1 " });
        if (dList != null && dList.Count > 0)
        {
            strJson = AidHelp.DataContractJsonSerialize(dList);
        }
        return strJson;
    }

    public string getUserList(decimal dept_Id)
    {
        string strJson = string.Empty;
        PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
        IList<PDTech.OA.Model.USER_INFO> uList = uBll.get_UserList(new PDTech.OA.Model.USER_INFO() { DEPARTMENT_ID = dept_Id });
        if (uList != null && uList.Count > 0)
        {
            strJson = AidHelp.DataContractJsonSerialize(uList);
        }
        return strJson;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}