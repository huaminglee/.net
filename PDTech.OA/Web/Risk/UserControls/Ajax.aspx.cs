using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Risk_UserControls_Ajax : System.Web.UI.Page
{
    string queryState = "";
    decimal dept_Id;
    string deptname;
    decimal user_Id;
    string username;
    string title;
    string business;
    string sdate;
    string edate;
    string archiveno;
    string tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        queryState = Request.QueryString["queryState"].ToString();
        switch (queryState)
        {
            case "dept":
                getDeptList();
                break;
            case "mapDept":
                getMapDeptList();
                break;
            case "user":
                dept_Id = decimal.Parse(Request.QueryString["queryId"].ToString());
                getUserList(dept_Id);
                break;
            case "Ext":
                deptname = Server.UrlDecode(Request.QueryString["deptname"].ToString());
                username = Server.UrlDecode(Request.QueryString["username"].ToString());
                title = Server.UrlDecode(Request.QueryString["title"].ToString());
                business = Server.UrlDecode(Request.QueryString["business"].ToString());
                sdate =Server.UrlDecode( Request.QueryString["sdate"].ToString());
                edate = Server.UrlDecode(Request.QueryString["edate"].ToString());
                archiveno = Server.UrlDecode(Request.QueryString["archiveno"].ToString());
                getExtJson();
                break;
            case "Vio":
                deptname = Server.UrlDecode(Request.QueryString["deptname"].ToString());
                username = Server.UrlDecode(Request.QueryString["username"].ToString());
                title = Server.UrlDecode(Request.QueryString["title"].ToString());
                business = Server.UrlDecode(Request.QueryString["business"].ToString());
                sdate =Server.UrlDecode( Request.QueryString["sdate"].ToString());
                edate =Server.UrlDecode( Request.QueryString["edate"].ToString());
                archiveno = Server.UrlDecode(Request.QueryString["archiveno"].ToString());
                getDeptJson();
                break;
            case "Err":
                if (string.IsNullOrEmpty(Request.QueryString["deptid"]))
                {
                    dept_Id = 0;
                }
                else
                {
                    dept_Id = decimal.Parse(Request.QueryString["deptid"].ToString());
                }
                if (string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    user_Id = 0;
                }
                else if (Request.QueryString["userid"] == "0")
                {
                    user_Id = 0;
                }
                else
                {
                    user_Id = decimal.Parse(Request.QueryString["userid"].ToString());
                }
                sdate =Server.UrlDecode( Request.QueryString["sdate"].ToString());
                edate =Server.UrlDecode( Request.QueryString["edate"].ToString());
                getErrRateJson();
                break;
            case "score":
                tid = Request.QueryString["tid"].ToString();
                getScoreList();
                break;
        }
        Response.End();
    }
    public void getDeptList()
    {
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { Append = " DEPARTMENT_ID<>1 " });
        PDTech.OA.Model.DEPARTMENT deptModel = new PDTech.OA.Model.DEPARTMENT();
        deptModel.DEPARTMENT_ID = 0;
        deptModel.DEPARTMENT_NAME = "---请选择---";
        dList.Insert(0, deptModel);
        if (dList != null && dList.Count > 0)
        {
            string strJson = AidHelp.DataContractJsonSerialize(dList);
            Response.Write(strJson);
        }
    }

    public void getMapDeptList()
    {
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { Append = " DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID = " + CurrentAccount.USER_ID.ToString() + ") " });
        PDTech.OA.Model.DEPARTMENT deptModel = new PDTech.OA.Model.DEPARTMENT();
        deptModel.DEPARTMENT_ID = 0;
        deptModel.DEPARTMENT_NAME = "---请选择---";
        dList.Insert(0, deptModel);
        if (dList != null && dList.Count > 0)
        {
            string strJson = AidHelp.DataContractJsonSerialize(dList);
            Response.Write(strJson);
        }
    }

    public void getUserList(decimal dept_Id)
    {
        PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
        IList<PDTech.OA.Model.USER_INFO> uList = uBll.get_UserList(new PDTech.OA.Model.USER_INFO() { DEPARTMENT_ID = dept_Id });
        PDTech.OA.Model.USER_INFO userModel = new PDTech.OA.Model.USER_INFO();
        userModel.USER_ID = 0;
        userModel.FULL_NAME = "---请选择---";
        uList.Insert(0, userModel);
        if (uList != null && uList.Count > 0)
        {
            string strJson = AidHelp.DataContractJsonSerialize(uList);
            Response.Write(strJson);
        }
    }

    public void getExtJson()
    {
        #region  风险统计
        PDTech.OA.BLL.VIEW_RISK_ATT vBll = new PDTech.OA.BLL.VIEW_RISK_ATT();
        PDTech.OA.Model.VIEW_RISK_ATT where = new PDTech.OA.Model.VIEW_RISK_ATT();
        PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT view = new PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT();
        if (!string.IsNullOrEmpty(sdate))
        {
            where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(sdate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(edate) && string.IsNullOrEmpty(where.Append))
        {
            where.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(edate) && !string.IsNullOrEmpty(where.Append))
        {
            where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(sdate) && !string.IsNullOrEmpty(edate))
        {
            var sTime = DateTime.Parse(sdate);
            var eTime = DateTime.Parse(edate);
            if (sTime > eTime)
            {
                where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
                where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(sdate).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                where.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
        if (!string.IsNullOrEmpty(deptname) && deptname != "---请选择---")
            where.DEPT_NAME = deptname;
        if (!string.IsNullOrEmpty(username) && username != "0" && username != "---请选择---")
            where.FULL_NAME = username;
        where.ARCHIVE_TITLE = title;
        if (!string.IsNullOrEmpty(business) && business != "---请选择---")
            where.BUSINESS = business;
        where.ARCHIVE_NO = archiveno;
        IList<PDTech.OA.Model.VIEW_RISK_ATT> vLIst = vBll.get_viewList(where);
        List<jsonchart> showslist = new List<jsonchart>();
        if (vLIst != null && queryState == "Ext")
        {
            #region 超期风险统计
            /**日常办公**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> dLIst = vLIst.Where(s => s.RISK_P_ARCHIVETYPE == 10 || s.RISK_P_ARCHIVETYPE == 11 || s.RISK_P_ARCHIVETYPE == 12).ToList();
            if (vLIst.Count > 0)
            {
                jsonchart vchart = new jsonchart();
                vchart.name = "日常办公";
                vchart.value = dLIst.Count;
                showslist.Add(vchart);
            }
            /**督办工作**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> sLIst = vLIst.Where(s => s.RISK_P_ARCHIVETYPE == 20 || s.RISK_P_ARCHIVETYPE == 21 || s.RISK_P_ARCHIVETYPE == 22 || s.RISK_P_ARCHIVETYPE == 23 || s.RISK_P_ARCHIVETYPE == 24).ToList();
            if (sLIst.Count > 0)
            {
                jsonchart schart = new jsonchart();
                schart.name = "督办工作";
                schart.value = sLIst.Count;
                showslist.Add(schart);
            }
            /**行政审批**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> aLIst = vLIst.Where(s => s.RISK_P_ARCHIVETYPE == 40 || s.RISK_P_ARCHIVETYPE == 41 || s.RISK_P_ARCHIVETYPE == 42 || s.RISK_P_ARCHIVETYPE == 43 || s.RISK_P_ARCHIVETYPE == 44).ToList();
            if (aLIst.Count > 0)
            {
                jsonchart achart = new jsonchart();
                achart.name = "行政审批";
                achart.value = aLIst.Count;
                showslist.Add(achart);
            }
            /**人事任免**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> pLIst = vLIst.Where(s =>  s.RISK_P_ARCHIVETYPE == 32).ToList();
            if (pLIst.Count > 0)
            {
                jsonchart pchart = new jsonchart();
                pchart.name = "人事任免";
                pchart.value = pLIst.Count;
                showslist.Add(pchart);
            }
            /**水务项目**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> prLIst = vLIst.Where(s => s.RISK_P_ARCHIVETYPE == 33).ToList();
            if (prLIst.Count > 0)
            {
                jsonchart prchart = new jsonchart();
                prchart.name = "水务工程项目";
                prchart.value = prLIst.Count;
                showslist.Add(prchart);
            }
            #endregion
        }
        System.Web.Script.Serialization.JavaScriptSerializer js =
               new System.Web.Script.Serialization.JavaScriptSerializer();
        string strJ = js.Serialize(showslist);
        string rejso = strJ.ToString().Trim();
        Response.Write(rejso);
        #endregion
    }

    public void getDeptJson()
    {
        #region  部门饼状图
        PDTech.OA.BLL.VIEW_RISK_ATT vBll = new PDTech.OA.BLL.VIEW_RISK_ATT();
        PDTech.OA.Model.VIEW_RISK_ATT where = new PDTech.OA.Model.VIEW_RISK_ATT();
        if (!string.IsNullOrEmpty(sdate))
        {
            where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(sdate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(edate) && string.IsNullOrEmpty(where.Append))
        {
            where.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(edate) && !string.IsNullOrEmpty(where.Append))
        {
            where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(sdate) && !string.IsNullOrEmpty(edate))
        {
            var sTime = DateTime.Parse(sdate);
            var eTime = DateTime.Parse(edate);
            if (sTime > eTime)
            {
                where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
                where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(sdate).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                where.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(edate).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
        if (!string.IsNullOrEmpty(deptname) && deptname != "---请选择---")
            where.DEPT_NAME = deptname;
        if (!string.IsNullOrEmpty(username) && username != "0" && username != "---请选择---")
            where.FULL_NAME = username;
        where.ARCHIVE_TITLE = title;
        if (!string.IsNullOrEmpty(business) && business != "---请选择---")
            where.BUSINESS = business;
        where.ARCHIVE_NO = archiveno;
        IList<PDTech.OA.Model.VIEW_RISK_ATT> vLIst = vBll.getDeptNum(where);
        List<jsonchart> showslist = new List<jsonchart>();
        #endregion
        if (vLIst != null && queryState == "Vio")
        {
            foreach (var item in vLIst)
            {
                if (item.CNUM > 0)
                {
                    jsonchart prchart = new jsonchart();
                    prchart.name = item.DEPT_NAME;
                    prchart.value = item.CNUM;
                    showslist.Add(prchart);
                }
            }
        }
        System.Web.Script.Serialization.JavaScriptSerializer js =
               new System.Web.Script.Serialization.JavaScriptSerializer();
        string strJ = js.Serialize(showslist);
        string rejso = strJ.ToString().Trim();
        Response.Write(rejso);
    }

    public void getErrRateJson()
    {
        List<PDTech.OA.Model.OA_EDAYQUESTION> edayList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
        PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
        string strWhere = string.Empty;
        if (dept_Id > 0)
        {
            strWhere = " and ANSWER_PERSON in (select USER_ID from USER_INFO where DEPARTMENT_ID = " + dept_Id.ToString() + ") ";
        }
        if (user_Id > 0)
        {
            strWhere = " and ANSWER_PERSON = " + user_Id.ToString();
        }
        if (!string.IsNullOrEmpty(sdate))
        {
            strWhere += " and ANSWER_TIME >= CONVERT(DATETIME,'" + sdate + " 00:00:01',120) ";
        }
        if (!string.IsNullOrEmpty(edate))
        {
            strWhere += " and ANSWER_TIME <= CONVERT(DATETIME,'" + edate + " 23:59:59',120) ";
        }
        edayList = edayBll.GetUidList(strWhere);
        List<PDTech.OA.Model.DailyQuestion_Count> list = new List<PDTech.OA.Model.DailyQuestion_Count>();
        List<jsonchart> showslist = new List<jsonchart>();
        foreach (PDTech.OA.Model.OA_EDAYQUESTION item in edayList)
        {
            PDTech.OA.Model.DailyQuestion_Count cModel = new PDTech.OA.Model.DailyQuestion_Count();
            cModel.UserId = item.ANSWER_PERSON.Value;
            cModel.UserName = new PDTech.OA.BLL.USER_INFO().GetModel(item.ANSWER_PERSON.Value).FULL_NAME;
            DataTable dt = edayBll.Tongji(" ANSWER_PERSON = " + item.ANSWER_PERSON);
            //List<PDTech.OA.Model.OA_EDAYQUESTION> newList = edayBll.GetModelList(" ANSWER_PERSON = " + item.ANSWER_PERSON);
            if (dt.Rows.Count > 0)
            {
                cModel.TotalCount = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                cModel.CorrectCount = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                cModel.ErrorCount = int.Parse(dt.Rows[0].ItemArray[1].ToString()) - int.Parse(dt.Rows[0].ItemArray[0].ToString());

                if (cModel.ErrorCount > 0)
                {
                    jsonchart errchart = new jsonchart();
                    errchart.name = cModel.UserName;
                    errchart.value = Math.Round(((decimal)cModel.ErrorCount / ((decimal)cModel.CorrectCount + (decimal)cModel.ErrorCount) * 100), 2);
                    showslist.Add(errchart);
                }
            }
           //cModel.TotalCount = newList.Count;
            //cModel.CorrectCount = edayList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 1; }).Count;
           // cModel.ErrorCount = newList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 2; }).Count;
            //cModel.SkipCount = edayList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 3; }).Count;
           
        }
        System.Web.Script.Serialization.JavaScriptSerializer js =
               new System.Web.Script.Serialization.JavaScriptSerializer();
        string strJ = js.Serialize(showslist);
        string rejso = strJ.ToString().Trim();
        Response.Write(rejso);
    }

    public void getScoreList()
    {
        List<jsonchart> showslist = new List<jsonchart>();
        PDTech.OA.BLL.OA_TEST_ANSWER answerBll = new PDTech.OA.BLL.OA_TEST_ANSWER();
        List<PDTech.OA.Model.OA_TEST_ANSWER> list = answerBll.GetTotalList(tid);
        if (list != null && list.Count > 0)
        {
            foreach (PDTech.OA.Model.OA_TEST_ANSWER item in list)
            {
                jsonchart totalChart = new jsonchart();
                totalChart.name = new PDTech.OA.BLL.USER_INFO().GetModel(item.ANSWER_ID.Value).FULL_NAME;
                totalChart.value = item.SCORE;
                totalChart.total = answerBll.GetRecordCount(" EDU_A_GUID = '" + item.EDU_A_GUID + "'");
                showslist.Add(totalChart);
            }
        }
        System.Web.Script.Serialization.JavaScriptSerializer js =
               new System.Web.Script.Serialization.JavaScriptSerializer();
        string strJ = js.Serialize(showslist);
        string rejso = strJ.ToString().Trim();
        Response.Write(rejso);
    }

    [Serializable]
    public class jsonchart
    {
        public string name { get; set; }
        public decimal? value { get; set; }
        public int total { get; set; }
    }
}