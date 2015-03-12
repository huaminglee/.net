using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitor_RiskWater : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiduserid.Value = CurrentAccount.USER_ID.ToString();
    }
}