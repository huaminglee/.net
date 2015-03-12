using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserShowInfo : System.Web.UI.Page
{
    string uId = "";
    PDTech.OA.BLL.USER_INFO ubll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uId"] == null || string.IsNullOrEmpty(Request.QueryString["uId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            uId = Request.QueryString["uId"].ToString();
            if(!IsPostBack)
            BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        where = ubll.GetUserInfo(Decimal.Parse(uId));
        txtFullName.Text = where.FULL_NAME;
        txtLoginName.Text = where.LOGIN_NAME;
        txtMobile.Text = where.MOBILE;
        txtPhone.Text = where.PHONE;
        txtDutyInfo.Text = where.DUTY_INFO;
        txtPublicName.Text = where.PUBLIC_NAME;
        txtEMaile.Text = where.E_MAILE;
        txtRemark.Text = where.REMARK;
        txtSort.Text = where.SORT_NUMBER.ToString();
        lblDeptName.Text = where.DEPARTMENT_NAME;
    }
}