using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_AddHandleOp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            nPrompt("模板名称不能为空", 0);
            txtName.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtValue.Text.Trim()))
        {
            nPrompt("模板内容不能为空", 0);
            txtValue.Focus();
            return;
        }
        PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
        PDTech.OA.Model.TEMPLATE_INFO temp = new PDTech.OA.Model.TEMPLATE_INFO();
        temp.TEMPLATE_JC = txtName.Text.Trim();
        temp.TEMPLATE_TYPE = "办理意见";
        temp.TEMPLATE_VALUE = txtValue.Text;
        int result = tBll.Add(temp);
        if (result==1)
        {
            nPrompt("保存成功", 1);
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