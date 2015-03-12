using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeptShowInfo : System.Web.UI.Page
{
    string dId = "";
    PDTech.OA.BLL.DEPARTMENT bll = new PDTech.OA.BLL.DEPARTMENT();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["dId"] == null || string.IsNullOrEmpty(Request.QueryString["dId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else if (!AidHelp.IsDecimal(Request.QueryString["dId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            dId = Request.QueryString["dId"].ToString();
            BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.DEPARTMENT where = new PDTech.OA.Model.DEPARTMENT();
        where = bll.GetDeptInfo(Decimal.Parse(dId));
        lblDeptName.Text = where.DEPARTMENT_NAME;
        txtDeptName_Jc.Text = where.DEPARTMENT_JC;
        txtReMark.Text = where.REMARK;
        txtSort.Text = where.SORT_NUM.ToString();
        if (where.PARENT_NAME == null || string.IsNullOrEmpty(where.PARENT_NAME))
            txtParentName.Text = "无";
        else
        txtParentName.Text = where.PARENT_NAME;
    }
}