using System;

public partial class Monitor_ExpireDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hiduserid.Value = CurrentAccount.USER_ID.ToString();
    }
}