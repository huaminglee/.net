using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_PurviewInfo : System.Web.UI.Page
{
    PDTech.OA.BLL.RIGHT_INFO rbll = new PDTech.OA.BLL.RIGHT_INFO();
    string rId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["rId"] == null || string.IsNullOrEmpty(Request.QueryString["rId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            rId = Request.QueryString["rId"].ToString();
            if(!IsPostBack)
            BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.RIGHT_INFO where = new PDTech.OA.Model.RIGHT_INFO();
        where = rbll.GetRightInfo(Decimal.Parse(rId));
        lblParent_Name.Text = where.PARENT_NAME;
        txtRIGHT_CODE.Text = where.RIGHT_CODE;
        txtRIGHT_DESC.Text = where.RIGHT_DESC;
        txtRIGHT_NAME.Text = where.RIGHT_NAME;
        txtSORT_NUM.Text = where.SORT_NUM.ToString();
    }
}