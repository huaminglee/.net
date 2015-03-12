using System;
using System.Collections.Generic;

public partial class Monitor_DailyQuestion : System.Web.UI.Page
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
        IList<PDTech.OA.Model.OA_EDAYQUESTION> edayList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
        decimal departmentId = 0;
        if (!string.IsNullOrEmpty(hidDeptId.Value) && hidDeptId.Value != "---请选择---" && int.Parse(hidDeptId.Value) > 0)
        {
            departmentId = decimal.Parse(hidDeptId.Value);
        }
        decimal userId = 0;
        if (departmentId == 0)
        {
            userId = 0;
        }
        else if (!string.IsNullOrEmpty(hidUserId.Value) && hidUserId.Value != "---请选择---" && int.Parse(hidUserId.Value) > 0)
        {
            userId = decimal.Parse(hidUserId.Value);
        }
        string sDate = txtSDate.Value;
        string eDate = txtEDate.Value;
        decimal state = decimal.Parse(ddlState.SelectedValue);
        edayList = edayBll.Get_Paging_List(null, departmentId, userId, sDate, eDate, state, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        rpt_EdayQuestionList.DataSource = edayList;
        rpt_EdayQuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    /// <summary>
    /// ID转换标题
    /// </summary>
    /// <param name="quid">题目ID</param>
    /// <returns>题目标题</returns>
    public string GetTitle(string quid)
    {
        return quesBll.GetModel(quid).TITLE;
    }

    public string GetAnswer(string quid)
    {
        model = quesBll.GetModel(quid);
        if (model != null)
            return model.ANSWER;
        return "";
    }

    public string GetUserName(decimal userId)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetModel(userId);
        if (user != null)
            return user.FULL_NAME;
        return "";
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