using System;
using System.Collections.Generic;

public partial class IncorruptEdu_EduTestList : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_EDUTEST testBll = new PDTech.OA.BLL.OA_EDUTEST();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    public string isshowexpire = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            if (Request.QueryString["ISshowexpire"] != null && Request.QueryString["ISshowexpire"].ToString() == "1")
            {
                isshowexpire = CurrentAccount.USER_ID.ToString();
                dquery.Visible = false;
            }
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDUTEST> testList = new List<PDTech.OA.Model.OA_EDUTEST>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            testList = testBll.Get_Paging_List(title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record, isshowexpire);
        }
        else
        {
            testList = testBll.Get_Paging_List(null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record, isshowexpire);
        }
        rpt_EduTestList.DataSource = testList;
        rpt_EduTestList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    public int GetIsAnswerCount(string tid)
    { 
        PDTech.OA.BLL.OA_TEST_ANSWER answerBll = new PDTech.OA.BLL.OA_TEST_ANSWER();
        return answerBll.GetIsAnswerCount(CurrentAccount.USER_ID, tid);
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