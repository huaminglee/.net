using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewPurview : System.Web.UI.Page
{
    const string randomFolder = "UserControls/";
    protected void Page_Load(object sender, EventArgs e)
    {
        Control featuredProduct = Page.LoadControl(randomFolder+ "ucPurview.ascx");
        rPanel.Controls.Add(featuredProduct);
    }

}