using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_selTempList : System.Web.UI.Page
{
    PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
    PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
    string Code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["code"] != null)
        {
            Code = Request.QueryString["code"].ToString();
        }
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
        tList = tBll.get_Paging_tempList(new PDTech.OA.Model.TEMPLATE_INFO() { TEMPLATE_TYPE = "接收人员模板" });
        rpt_tempList.DataSource = tList;
        rpt_tempList.DataBind();
    }
    /// <summary>
    /// 获取人员列表
    /// </summary>
    public void GetUser(string Ids)
    {
        IList<PDTech.OA.Model.USER_INFO> uList = new List<PDTech.OA.Model.USER_INFO>();
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        if (!string.IsNullOrEmpty(Code))
        {
            where.Append = string.Format(@"USER_ID IN({0}) AND USER_ID IN
(SELECT USER_ID FROM VIEW_USER_RIGHT WHERE RIGHT_CODE='{1}')", Ids, Code);
        }
        else
        {
            where.Append = string.Format(@"USER_ID IN({0}) ", Ids);
        }
        uList = uBll.get_UserList(where);
        rpt_uList.DataSource = uList;
        rpt_uList.DataBind();
    }
    /// <summary>
    /// 删除或获取模板人员
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_tempList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "tDel")
        {
            if (CurrentAccount.ISHavePurview("delpersontemp"))
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
                nPrompt("你不具备删除人员模板列表的权限!", 0);
            }
        }
        if (e.CommandName == "GetUser")
        {
            string uIds = e.CommandArgument.ToString();
            GetUser(uIds);
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
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string guids = "";
        string Names = "";
        foreach (RepeaterItem item in rpt_uList.Items)
        {
            HiddenField hidId = (HiddenField)item.FindControl("hidUserID");
            Label lblName = (Label)item.FindControl("lblName");
            guids += hidId.Value + ",";
            Names += lblName.Text.Trim() + ",";
        }
        guids = guids.TrimEnd(',');
        Names = Names.TrimEnd(',');
        if (!string.IsNullOrEmpty(guids))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.ShowTemp('" + guids + "','" + Names + "');</script>");
        }
        else
        {
            nPrompt("导入模板失败", 0);
        }
    }
}