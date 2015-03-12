using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_NewStencil : System.Web.UI.Page
{
    PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
    string stype = "";
    string tId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["tId"] != null)
        {
            tId = Request.QueryString["tId"].ToString();
        }
        if (Request.QueryString["type"] != null)
        {
            stype = Request.QueryString["type"].ToString();
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数');window.parent.location.href='../MainBoard.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(tId) && AidHelp.IsDecimal(tId))
            { BindData(); }
        }
    }
    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.TEMPLATE_INFO twhere = tBll.GetmTempInfo(decimal.Parse(tId));
        txtComtent.Text = twhere.TEMPLATE_VALUE;
        txtName.Text = twhere.TEMPLATE_JC;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.TEMPLATE_INFO where = new PDTech.OA.Model.TEMPLATE_INFO();
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('模板简称不能为空!');</script>");
            return;
        }
        if (string.IsNullOrEmpty(txtComtent.Text.Trim()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('模板内容不能为空!');</script>");
            return;
        }
        where.TEMPLATE_JC = txtName.Text.Trim();
        where.TEMPLATE_VALUE = txtComtent.Text.Trim();
        int result =0;
        if (string.IsNullOrEmpty(tId))
        {
            where.TEMPLATE_TYPE = stype;
            result = tBll.Add(where);
        }
        else
        {
            where.TEMPLATE_ID = decimal.Parse(tId);
            result = tBll.Update(where);
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