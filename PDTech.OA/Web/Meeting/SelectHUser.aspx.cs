﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_SelectHUser : System.Web.UI.Page
{
    public string t_rand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
    }
}