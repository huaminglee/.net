using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Approve_Main_Frame : System.Web.UI.Page
{
    const string randomFolder = "UserControls/";
    string Action = "";
    public string t_rand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["action"] != null && !string.IsNullOrEmpty(Request.QueryString["action"].ToString()))
        {
            Action = Request.QueryString["action"].ToString();
        }
        else
        {
            Action = "Approve";
            return;
        }
        Control featuredProduct = Page.LoadControl(randomFolder + Action + ".ascx");
        nPanel.Controls.Add(featuredProduct);
    }
}