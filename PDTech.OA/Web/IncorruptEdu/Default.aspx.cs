using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!CurrentAccount.ISHavePurview("edu_sys_manager"))
            {
                div_edu_manager.Visible = false;//廉政教育管理
            }
        }
    }
}