using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_AddTemp : System.Web.UI.Page
{
    string userList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uIds"] != null)
        {
            userList = Request.QueryString["uIds"].ToString();
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非凡参数');window.parent.layer.closeAll();</script>");
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            nPrompt("模板名称不能为空",0);
            txtName.Focus();
            return;
        }
        PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
        PDTech.OA.Model.TEMPLATE_INFO temp = new PDTech.OA.Model.TEMPLATE_INFO();
        temp.TEMPLATE_JC = txtName.Text.Trim();
        temp.TEMPLATE_TYPE = "接收人员模板";
        temp.TEMPLATE_VALUE = userList.TrimEnd(',');
        int result = tBll.Add(temp);
        if (result==1)
        {
            nPrompt("保存成功",1);
        }
        else if (result == -1)
        {
            nPrompt("已存在此名称,不能重复添加", 0);
        }
        else
        {
            nPrompt("保存失败", 0);
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.layer.closeAll();</script>");
        }
    }
}