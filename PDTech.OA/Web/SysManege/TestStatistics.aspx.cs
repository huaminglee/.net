using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_TestStatistics : System.Web.UI.Page
{
    public string t_rand = "";
    public string testId = string.Empty;
    public string testName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        testId = Request.QueryString["t_id"];
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(testId))
            {
                testName = new PDTech.OA.BLL.OA_EDUTEST().GetModel(testId).TESTNAME;
            }
        }
    }
}