using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentAccount.ISHavePurview("businessMonitor"))
        {
            throw new Exception("权限错误！");
        }
    }
}