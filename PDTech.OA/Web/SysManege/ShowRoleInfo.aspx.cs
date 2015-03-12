using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_ShowRoleInfo : System.Web.UI.Page
{
    PDTech.OA.BLL.ROLE_INFO rBll = new PDTech.OA.BLL.ROLE_INFO();
    string rId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["rId"] != null)
        { rId = Request.QueryString["rId"].ToString(); }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.opener.location.href='SysDepartment.aspx';layer.alert('非法参数',1);</script>");
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(rId))
                BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.ROLE_INFO where = new PDTech.OA.Model.ROLE_INFO();
        where = rBll.GetRoleInfo(decimal.Parse(rId));
        txtReMark.Text = where.ROLE_DESC;
        txtrName.Text = where.ROLE_NAME;
    }
}