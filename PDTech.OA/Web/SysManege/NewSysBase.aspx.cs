using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_NewSysBase : System.Web.UI.Page
{
    PDTech.OA.BLL.SYS_BASE_INFO sysBll = new PDTech.OA.BLL.SYS_BASE_INFO();
    string sysType = "";
    string sysID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sAc"] == null || string.IsNullOrEmpty(Request.QueryString["sAc"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数');history.go(-1);return false;</script>");
        }
        else
        {
            sysType = Request.QueryString["sAc"].ToString();
            lblSysType.Text = sysType;
        }
        if (Request.QueryString["sId"] != null)
        {
            sysID = Request.QueryString["sId"].ToString();
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(sysID))
            {
                BindData();
            }
        }
    }

    public void BindData()
    {
        PDTech.OA.Model.SYS_BASE_INFO where=sysBll.GetSysInfo(decimal.Parse(sysID));
        lblSysType.Text = where.SYS_TYPE;
        txtName.Text = where.BASE_NAME;
        txtName_Jc.Text = where.BASE_JC;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.SYS_BASE_INFO sysWhere = new PDTech.OA.Model.SYS_BASE_INFO();
        
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.layer.alert('单位名称不能为空',8)</script>");
            return;
        }
        if (string.IsNullOrEmpty(txtName_Jc.Text.Trim()))
        {
            sysWhere.BASE_JC = txtName.Text.Trim();
        }
        else{
            sysWhere.BASE_JC = txtName_Jc.Text.Trim();
        }
        sysWhere.BASE_NAME = txtName.Text.Trim();
        sysWhere.SYS_TYPE = lblSysType.Text.Trim();
        int result =0;
        if (string.IsNullOrEmpty(sysID))
        { result = sysBll.Add(sysWhere); }
        else
        {
            sysWhere.SYS_BASE_ID = decimal.Parse(sysID);
            result = sysBll.Update(sysWhere);
        }
        if (result==1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存成功');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
        else if (result == -1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('已存在此名称,不能重复添加');</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存失败');</script>");
        }
    }
}