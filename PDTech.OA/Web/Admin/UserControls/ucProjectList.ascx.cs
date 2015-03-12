using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Admin_UserControls_ucProjectList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.VIEW_PROJECT_STEP_USER vBll = new PDTech.OA.BLL.VIEW_PROJECT_STEP_USER();
    protected void Page_Load(object sender, EventArgs e)
    {
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
        /**定义接收数据列表**/
        IList<PDTech.OA.Model.VIEW_PROJECT_STEP_USER> vList = new List<PDTech.OA.Model.VIEW_PROJECT_STEP_USER>();
        /**条件实例**/
        PDTech.OA.Model.VIEW_PROJECT_STEP_USER view = new PDTech.OA.Model.VIEW_PROJECT_STEP_USER();
        view.PROJECT_NAME = AidHelp.FilterSpecial(txtmName.Text.Trim());//搜索的项目名称
        if (dplStatus.SelectedValue != "(全部)" && !string.IsNullOrEmpty(dplStatus.SelectedValue))//是否选择状态
        {
            view.TASK_STATE = decimal.Parse(dplStatus.SelectedValue);
        }
        view.OWNER_ID = CurrentAccount.USER_ID;
        view.SortFields = " START_TIME DESC ";
        int record = 0;//数据总条数
        vList = vBll.get_paging_project_stepList(view, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_ProStepList.DataSource = vList;
        rpt_ProStepList.DataBind();
        AspNetPager.RecordCount = record;
    }
    /// <summary>
    /// 查询
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
    protected void rpt_ProStepList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HiddenField hidTaskState = (HiddenField)e.Item.FindControl("hidTaskState");
            HiddenField hidArchiveState = (HiddenField)e.Item.FindControl("hidArchiveState");
            HiddenField hidownerid = (HiddenField)e.Item.FindControl("hidownerid");
            Label sHandle = (Label)e.Item.FindControl("sHandle");
            LinkButton lbdel = (LinkButton)e.Item.FindControl("lbdel");
            if (hidTaskState.Value == "1" || hidArchiveState.Value == "2" || hidArchiveState.Value == "9" || hidownerid.Value != CurrentAccount.USER_ID.ToString())
            {
                sHandle.Visible = false;
            }
            
            if (hidArchiveState.Value == "0")
            {
                lbdel.Visible = true;
            }
        }
        
    }
    protected void rpt_ProStepList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            PDTech.OA.BLL.OA_ARCHIVE blla = new PDTech.OA.BLL.OA_ARCHIVE();
            blla.Delete(decimal.Parse(e.CommandArgument.ToString()));
            BindData();
        }
    }
}