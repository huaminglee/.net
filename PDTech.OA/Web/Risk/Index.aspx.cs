using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentAccount.ISHavePurview("riskAssessment"))
        {
            throw new Exception("权限错误！");
        }
        if (CurrentAccount.ISHavePurview("ckajtj"))
        {
            dajtj.Visible = true;

        }
        else
        {
            dajtj.Visible = false;
        }
    }
}