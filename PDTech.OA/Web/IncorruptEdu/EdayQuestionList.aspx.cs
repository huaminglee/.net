using System;
using System.Collections.Generic;

public partial class IncorruptEdu_EdayQuestionList : System.Web.UI.Page
{
    public string t_rand = "";
    public int flag = 0;
    string userId = string.Empty;
    string state = string.Empty;
    PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.Model.OA_EDUQUESTION model = new PDTech.OA.Model.OA_EDUQUESTION();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        //从统计页面过来
        userId = Request.QueryString["user_id"];
        state = Request.QueryString["state"];
        if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(state))
        {
            flag = 1;
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["u_name"]))
        {
            //把name转换成id
            userId = userBll.GetModel(Request.QueryString["u_name"]).USER_ID.Value.ToString();
            flag = 1;
        }
        else
        {
            userId = CurrentAccount.USER_ID.ToString();
            state = "0";
        }
        if (!IsPostBack)
        {
            BindData(decimal.Parse(userId), int.Parse(state));
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDAYQUESTION> edayList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
        string title = txtTitle.Text;
        if (!string.IsNullOrEmpty(title))
        {
            edayList = edayBll.Get_Paging_List(CurrentAccount.USER_ID, title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            edayList = edayBll.Get_Paging_List(CurrentAccount.USER_ID, null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        rpt_EdayQuestionList.DataSource = edayList;
        rpt_EdayQuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    private void BindData(decimal userId, int state)
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDAYQUESTION> edayList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            edayList = edayBll.Get_Paging_List(title, 0, userId, null, null, state, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            edayList = edayBll.Get_Paging_List(null, 0, userId, null, null, state, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData(decimal.Parse(userId), int.Parse(state));
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData(decimal.Parse(userId), int.Parse(state));
    }
}