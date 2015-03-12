using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_UserControls_ucSupList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK viewtBll = new PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK();
    string ARCHIVE_TYPE = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            ARCHIVE_TYPE = Request.QueryString["type"].ToString();
            hidType.Value = ARCHIVE_TYPE;
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        switch (ARCHIVE_TYPE)
        {
            case "20":
                lblTitle.InnerText = "领导批示件";
                break;
            case "21":
                lblTitle.InnerText = "党组会督办件";
                break;
            case "22":
                lblTitle.InnerText = "局长办公会督办件";
                break;
            case "23":
                lblTitle.InnerText = "信访督办件";
                break;
        }
        IList<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK> vList = new List<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK>();
        PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK view = new PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK();
        view.OWNER_ID = CurrentAccount.USER_ID;
        view.ARCHIVE_TYPE = decimal.Parse(ARCHIVE_TYPE);
        view.ARCHIVE_TITLE =AidHelp.FilterSpecial(txtmName.Text.Trim());
        if (dplStatus.SelectedValue != "(全部)" && !string.IsNullOrEmpty(dplStatus.SelectedValue))
        {
            view.TASK_STATE = decimal.Parse(dplStatus.SelectedValue);
        }
        view.SortFields = " START_TIME DESC ";
        int record = 0;
        vList = viewtBll.get_Paging_taskInfoList(view, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_taskList.DataSource = vList;
        rpt_taskList.DataBind();
        AspNetPager.RecordCount = record;
    }

    /// <summary>
    /// 查询督办件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    /// <summary>
    /// 下载件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_taskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HiddenField hidTaskState = (HiddenField)e.Item.FindControl("hidTaskState");
            HiddenField hidArchiveState = (HiddenField)e.Item.FindControl("hidArchiveState");
            Label sHandle = (Label)e.Item.FindControl("sHandle");
            LinkButton lbdel = (LinkButton)e.Item.FindControl("lbdel");
            if (hidTaskState.Value == "1" || hidArchiveState.Value == "2" || hidArchiveState.Value == "9")
            {
                sHandle.Visible = false;
            }
            if (hidArchiveState.Value == "0")
            {
                lbdel.Visible = true;
            }
        }
    }
    protected void rpt_taskList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PDTech.OA.BLL.OA_FAVORITE bll = new PDTech.OA.BLL.OA_FAVORITE();
        if (e.CommandName == "Collect")
        {
            PDTech.OA.Model.OA_FAVORITE model = new PDTech.OA.Model.OA_FAVORITE();
            model.REF_ID = decimal.Parse(e.CommandArgument.ToString());
            model.CREATE_TIME = DateTime.Now;
            model.REF_TYPE = "OA_ARCHIVE";
            model.USER_ID = CurrentAccount.USER_ID;
            int result = bll.Add(model);
            if (result == 1)
            {
                nPrompt("收藏成功", 1);
            }
            else if (result == 2)
            {
                nPrompt("已收藏此公文,无需重复收藏", 1);
            }
        }
        else if (e.CommandName == "del")
        {
            PDTech.OA.BLL.OA_ARCHIVE blla = new PDTech.OA.BLL.OA_ARCHIVE();
            blla.Delete(decimal.Parse(e.CommandArgument.ToString()));
            BindData();
        }
    }
    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "<script>layer.alert('" + msg + "',8);</script>", false);
        }
        else if (flag == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "<script>layer.alert('" + msg + "',1);</script>", false);
        }
    }
}