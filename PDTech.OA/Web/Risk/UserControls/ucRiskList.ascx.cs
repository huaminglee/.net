using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_UserControls_ucRiskList : System.Web.UI.UserControl
{
    const decimal ARCHIVE_TYPE = 51;
    PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK viewtBll = new PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// 获取绑定风险处置单数据
    /// </summary>
    public void BindData()
    {
        IList<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK> vList = new List<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK>();
        PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK view = new PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK();
        view.OWNER_ID = CurrentAccount.USER_ID;
        view.ARCHIVE_TYPE = ARCHIVE_TYPE;
        view.ARCHIVE_NO = txtArNum.Text;
        view.ARCHIVE_TITLE = AidHelp.FilterSpecial(txtmName.Text.Trim());
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

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