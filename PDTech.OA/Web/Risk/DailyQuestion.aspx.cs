using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_DailyQuestion : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.Model.OA_EDUQUESTION model = new PDTech.OA.Model.OA_EDUQUESTION();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        PDTech.OA.Model.USER_INFO uModel = new PDTech.OA.Model.USER_INFO();
        decimal departmentId = 0;
        if (!string.IsNullOrEmpty(hidDeptId.Value) && hidDeptId.Value != "---请选择---" && int.Parse(hidDeptId.Value) > 0)
        {
            departmentId = decimal.Parse(hidDeptId.Value);
        }
        decimal userId = 0;
        if (!string.IsNullOrEmpty(hidUserId.Value) && hidUserId.Value != "---请选择---" && int.Parse(hidUserId.Value) > 0)
        {
            userId = decimal.Parse(hidUserId.Value);
        }
        if (departmentId > 0)
        {
            uModel.DEPARTMENT_ID = departmentId;
        }
        if (userId > 0)
        {
            uModel.USER_ID = userId;
        }
        IList<PDTech.OA.Model.USER_INFO> userList = userBll.get_Paging_UserInfoList(uModel, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        //List<PDTech.OA.Model.OA_EDAYQUESTION> edayList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
        DataTable dt;
        List<PDTech.OA.Model.DailyQuestion_Count> list = new List<PDTech.OA.Model.DailyQuestion_Count>();
        foreach (PDTech.OA.Model.USER_INFO item in userList)
        {
            string strWhere = " ANSWER_PERSON = " + item.USER_ID.ToString();
            string sDate = txtSDate.Value;
            string eDate = txtEDate.Value;
            if (!string.IsNullOrEmpty(sDate))
            {
                strWhere += " and ANSWER_TIME >= CONVERT(DATETIME,'" + sDate + " 00:00:01',120) ";
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                strWhere += " and ANSWER_TIME <= CONVERT(DATETIME,'" + eDate + " 23:59:59',120) ";
            }
            dt = edayBll.Tongji(strWhere);
            if (dt.Rows.Count > 0)
            {

            
            //edayList = edayBll.GetModelList(strWhere);
            PDTech.OA.Model.DailyQuestion_Count cModel = new PDTech.OA.Model.DailyQuestion_Count();
            cModel.UserId = item.USER_ID.Value;
            cModel.UserName = item.FULL_NAME;
            cModel.TotalCount =int.Parse(dt.Rows[0].ItemArray[0].ToString());
            cModel.CorrectCount = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            cModel.ErrorCount = int.Parse(dt.Rows[0].ItemArray[1].ToString()) - int.Parse(dt.Rows[0].ItemArray[0].ToString());
           // cModel.CorrectCount = edayList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 1; }).Count;
           // cModel.ErrorCount = edayList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 2; }).Count;
           // cModel.SkipCount = edayList.FindAll(delegate(PDTech.OA.Model.OA_EDAYQUESTION t) { return t.STATE == 3; }).Count;
            list.Add(cModel);
            }
        }
        rpt_EdayQuestionList.DataSource = list;
        rpt_EdayQuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal userId)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetModel(userId);
        if (user != null)
            return user.FULL_NAME;
        return "";
    }

    public string GetDetailUrl(int count, decimal userId, int state)
    {
        string strReturn = "<a href='javascript:void(0);' onclick='location.href = /IncorruptEdu/EdayQuestionList.aspx?uid=" + userId + "&sid=" + state + ";'>" + count + "</a>";
        return strReturn;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}