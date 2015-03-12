using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_FortheProcess : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.VIEW_ARCHIVETASK_STEP ArBll = new PDTech.OA.BLL.VIEW_ARCHIVETASK_STEP();
    PDTech.OA.BLL.OA_ARCHIVE_TASK taskBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.OA_ARCHIVE archiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    public string Archive_id;
    public string allSealData = string.Empty;
    public List<string> protectList = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["ArId"] != null)
        {
            Archive_id = Request.QueryString["ArId"].ToString();        
        }
        if (!IsPostBack)
        {
            BindData();

            string protectDatas = string.Empty;
            PDTech.OA.Model.OA_ARCHIVE oaArchive = archiveBll.GetArchiveInfo(decimal.Parse(Archive_id));
            protectDatas = oaArchive.ARCHIVE_TITLE + "=&" + oaArchive.ARCHIVE_CONTENT + "=&";
            PDTech.OA.Model.OA_ARCHIVE_TASK oaTask = new PDTech.OA.Model.OA_ARCHIVE_TASK();
            oaTask.ARCHIVE_ID = decimal.Parse(Archive_id);
            IList<PDTech.OA.Model.OA_ARCHIVE_TASK> list = taskBll.get_TaskInfoList(oaTask);
            if (list != null && list.Count > 0)
            {
                foreach (PDTech.OA.Model.OA_ARCHIVE_TASK task in list)
                {
                    //拼接受保护的数据
                    protectDatas += task.ARCHIVE_TASK_ID + "=" + task.TASK_REMARK + "&";
                    if (!string.IsNullOrEmpty(task.Sing_data))
                    {
                        allSealData += task.Sing_data + ",";
                        protectList.Add(protectDatas);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void BindData()
    {
        int record=0;
        IList<PDTech.OA.Model.VIEW_ARCHIVETASK_STEP> ArList = new List<PDTech.OA.Model.VIEW_ARCHIVETASK_STEP>();
        ArList = ArBll.get_Paging_ArchiveTask_StepList(new PDTech.OA.Model.VIEW_ARCHIVETASK_STEP() { ARCHIVE_ID = decimal.Parse(Archive_id), SortFields = " START_TIME ASC " }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_taskList.DataSource = ArList;
        rpt_taskList.DataBind();
        AspNetPager.RecordCount = record;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    /// <summary>
    /// 判定是否有风险处置单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_taskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton lbntGnt = e.Item.FindControl("lbntGnt") as LinkButton;
            LinkButton lbntSel = e.Item.FindControl("lbntSel") as LinkButton;
            HiddenField hidRiskId = e.Item.FindControl("hidRiskId") as HiddenField;
            HiddenField hidOt_Type = e.Item.FindControl("hidOt_Type") as HiddenField;
            HiddenField hidOt_State = e.Item.FindControl("hidOt_State") as HiddenField;
            Label stateStr= e.Item.FindControl("stateStr") as Label;
            if (!string.IsNullOrEmpty(hidRiskId.Value))
            {
                lbntGnt.Visible = false;
            }
            else
            {
                lbntSel.Visible = false;
            }
            if (hidOt_Type.Value == "1")
            {
                stateStr.Text = "抄 送";
            }
            else if (hidOt_State.Value == "1")
            {
                stateStr.Text = "已完成";
            }
            else
            {
                stateStr.Text = "待办中";
            }
        }
    }
    /// <summary>
    /// 新增或查看风险处置单
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_taskList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Gnt")
        {
            HiddenField hidArchiveId = e.Item.FindControl("hidArchiveId") as HiddenField;
            HiddenField hidArchiveType = e.Item.FindControl("hidArchiveType") as HiddenField;
            HiddenField hidArchive_Task_Id = e.Item.FindControl("hidArchive_Task_Id") as HiddenField;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>editRisk('" + hidArchiveType.Value + "','" + hidArchive_Task_Id.Value + "','" + hidArchiveId.Value + "');</script>");
        }
        if (e.CommandName == "Sel")
        {
            HiddenField hidRiskId = e.Item.FindControl("hidRiskId") as HiddenField;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>selrisk('" + hidRiskId.Value + "');</script>");
        }
    }
}