using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_NewRoleInfo : System.Web.UI.Page
{
    PDTech.OA.BLL.ROLE_INFO rBll = new PDTech.OA.BLL.ROLE_INFO();
    string rId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["rId"] != null)
        { rId = Request.QueryString["rId"].ToString(); }
        if (Request.QueryString["rId"] != null && !AidHelp.IsDecimal(Request.QueryString["rId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
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
        where=rBll.GetRoleInfo(decimal.Parse(rId));
        txtReMark.Text=where.ROLE_DESC;
        txtrName.Text = where.ROLE_NAME;
    }
    /// <summary>
    /// 点击保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.ROLE_INFO Qwhere = new PDTech.OA.Model.ROLE_INFO();
        Qwhere.ROLE_NAME = txtrName.Text.Trim();
        Qwhere.ROLE_DESC = txtReMark.Text.Trim();
        int result = 0;
        if (string.IsNullOrEmpty(rId))
        {
            result = rBll.Add(Qwhere,CurrentAccount.ClientHostName,CurrentAccount.ClientIP,CurrentAccount.USER_ID);
        }
        else
        {
            Qwhere.ROLE_ID=decimal.Parse(rId);
            result = rBll.Update(Qwhere, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        }
        if (result==1)
        {
            nPrompt("保存成功!", 1);
        }
        else if (result == -1)
        {
            nPrompt("已存在此名称,不能重复添加!",0);
        }
        else
        {
            nPrompt("保存失败!", 0);
        }
    }

    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
    }
}