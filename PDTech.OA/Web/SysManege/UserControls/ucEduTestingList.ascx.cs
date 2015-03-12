using System;
using System.Collections.Generic;

public partial class SysManege_UserControls_ucEduTestingList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.OA_EDUTEST testBll = new PDTech.OA.BLL.OA_EDUTEST();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            testList = testBll.Get_Paging_List(title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            testList = testBll.Get_Paging_List(null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        rpt_TestingList.DataSource = testList;
        rpt_TestingList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}