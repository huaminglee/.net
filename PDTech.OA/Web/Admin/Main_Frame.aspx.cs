﻿using System;
using System.Web.UI;

public partial class Admin_Main_Frame : System.Web.UI.Page
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
            return;
        }
        Control featuredProduct = Page.LoadControl(randomFolder + Action + ".ascx");
        nPanel.Controls.Add(featuredProduct);
    }
}