using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_ViewTestOnlineResult : System.Web.UI.Page
{
    public string t_rand = "";
    string tId = string.Empty;
    string aId = string.Empty;
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.BLL.OA_EDUTEST testBll = new PDTech.OA.BLL.OA_EDUTEST();
    PDTech.OA.BLL.OA_TEST_ANSWER answerBll = new PDTech.OA.BLL.OA_TEST_ANSWER();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        tId = Request.QueryString["t_id"];
        aId = Request.QueryString["a_id"];
        if (!IsPostBack)
        {
            PDTech.OA.Model.OA_EDUTEST testModel = testBll.GetModel(tId);
            lbTitle.Text = testModel.TESTNAME;
            lbTotal.Text = testModel.SCORE.ToString();
            lbScore.Text = answerBll.GetTotalScore(CurrentAccount.USER_ID, tId, aId).ToString();
            BindData(tId);
        }
    }

    private void BindData(string testId)
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        quesList = quesBll.Get_Paging_List(CurrentAccount.USER_ID, testId, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        rpt_TestResultList.DataSource = quesList;
        rpt_TestResultList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string returnStr(string optionD)
    {
        if (!string.IsNullOrEmpty(optionD))
        {
            return "<tr><td>D、" + optionD + "</td></tr>";
        }
        return "";
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData(tId);
    }

    public string GetSelectOption(string questionId)
    {
        return answerBll.GetSelectOption(CurrentAccount.USER_ID, tId, aId, questionId);
    }
}