using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_selHandleOpList : System.Web.UI.Page
{
    PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
    PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 获取人员模板列表
    /// </summary>
    public void BindData()
    {
        IList<PDTech.OA.Model.TEMPLATE_INFO> tList = new List<PDTech.OA.Model.TEMPLATE_INFO>();
        PDTech.OA.Model.TEMPLATE_INFO where = new PDTech.OA.Model.TEMPLATE_INFO();
        where.TEMPLATE_TYPE = "办理意见";
        where.Append = string.Format(@" TEMPLATE_OWNER={0} OR TEMPLATE_OWNER IS NULL ",CurrentAccount.USER_ID);
        tList = tBll.get_Paging_tempList(where);
        rpt_tempList.DataSource = tList;
        rpt_tempList.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(lblValue.Text))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.ShowOpinion('" + lblValue.Text + "');</script>");
        }
        else
        {
            nPrompt("导入模板失败", 0);
        }
    }
    protected void rpt_tempList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "tDel")
        {
            if (CurrentAccount.ISHavePurview("delatttemp"))
            {
                decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());
                bool result = tBll.Delete(atId);
                if (result)
                {
                    nPrompt("操作成功!", 1);
                }
                BindData();
            }
            else
            {
                nPrompt("你不具备删除此模板列表的权限!", 0);
            }
        }
        if (e.CommandName == "GetValue")
        {
            string uValue = e.CommandArgument.ToString();
            lblValue.Text = uValue;
        }
    }

    /// <summary>
    /// 提示
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="flag"></param>
    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',8)</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',1);</script>");
        }
    }
}