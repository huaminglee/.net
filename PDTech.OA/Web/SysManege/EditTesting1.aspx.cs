using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_EditTesting1 : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            BindQuestion();
        }
    }

    private void BindQuestion()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        quesList = quesBll.Get_Paging_List(null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        rpt_QuestionList.DataSource = quesList;
        rpt_QuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetTitle(string title)
    {
        if (title.Length > 70)
        {
            return title.Substring(0, 71) + "...";
        }
        else
        {
            return title;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindQuestion();
    }
}