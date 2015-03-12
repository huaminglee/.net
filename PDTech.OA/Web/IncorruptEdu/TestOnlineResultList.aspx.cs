using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_TestOnlineResultList : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.TestOnline toBll = new PDTech.OA.BLL.TestOnline();
    PDTech.OA.BLL.OA_TEST_ANSWER answerBll = new PDTech.OA.BLL.OA_TEST_ANSWER();
    PDTech.OA.BLL.TestAnswer taBll = new PDTech.OA.BLL.TestAnswer();
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
        IList<PDTech.OA.Model.TestAnswer> taList = new List<PDTech.OA.Model.TestAnswer>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            taList = taBll.Get_Paging_List(CurrentAccount.USER_ID, title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            taList = taBll.Get_Paging_List(CurrentAccount.USER_ID, null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        rpt_TestList.DataSource = taList;
        rpt_TestList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public decimal GetTotalScore(string answerId)
    {
        decimal totalScore = 0;
        IList<PDTech.OA.Model.OA_TEST_ANSWER> answerList = answerBll.GetModelList(" EDU_A_GUID = '" + answerId + "'");
        foreach (PDTech.OA.Model.OA_TEST_ANSWER item in answerList)
        {
            totalScore += item.SCORE.Value;
        }
        return totalScore;
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