using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Archive_AllArchive_Task : System.Web.UI.Page
{
    public string t_rand = "";
    string Archive_Type = "";
    PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK viewtBll = new PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            if (Request.QueryString["Archive_types"] != null)
            {
                Archive_Type = Request.QueryString["Archive_types"].ToString();
            }
            PDTech.OA.BLL.OA_ARCHIVE_TYPE dBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
            IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> dLIst = dBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
            foreach (var item in dLIst)
            {
                ListItem dplItem = new ListItem();
                dplItem.Value = item.ARCHIVE_TYPE.ToString();
                dplItem.Text = item.TYPE_NAME;
                dplTypeList.Items.Add(dplItem);
            }
            ListItem dplItem0 = new ListItem();
            dplItem0.Value = "";
            dplItem0.Text ="---全部---";
            dplTypeList.Items.Insert(0, dplItem0);
            BindData();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        IList<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK> vList = new List<PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK>();
        PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK view = new PDTech.OA.Model.VIEW_ARCHIVE_FILE_TASK();
        view.OWNER_ID = CurrentAccount.USER_ID;
        view.ARCHIVE_TITLE =AidHelp.FilterSpecial(txtmName.Text.Trim());
        if (dplStatus.SelectedValue != "---全部---" && !string.IsNullOrEmpty(dplStatus.SelectedValue))
        {
            view.TASK_STATE = decimal.Parse(dplStatus.SelectedValue);
        }
        if (!string.IsNullOrEmpty(dplTypeList.SelectedValue))
        {
            view.ARCHIVE_TYPE = decimal.Parse(dplTypeList.SelectedValue);
        }
        else if (!string.IsNullOrEmpty(Archive_Type))
        {
            view.Append = string.Format(" ARCHIVE_TYPE IN({0}) ", Archive_Type);
        }
        view.SortFields = " START_TIME DESC";
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

    /// <summary>
    /// 
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
        if (e.CommandName == "del")
        {
            PDTech.OA.BLL.OA_ARCHIVE blla = new PDTech.OA.BLL.OA_ARCHIVE();
            blla.Delete(decimal.Parse(e.CommandArgument.ToString()));
            BindData();
        }
    }
}