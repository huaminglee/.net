using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Archive_selSupInfo : System.Web.UI.Page
{
    public string t_rand = "";
    public string arId = "";
    int contentTask_Id;
    string ARCHIVE_TYPE = "";
    const string Symol = "/images/nextIcon.png";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            ARCHIVE_TYPE = Request.QueryString["type"].ToString();
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "处理单";//设置标题
        }
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["arId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["arId"].ToString()))
                arId = Request.QueryString["arId"].ToString();
        }
        if (Request.QueryString["tId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["tId"].ToString()))
                contentTask_Id = int.Parse(Request.QueryString["tId"].ToString());
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(contentTask_Id.ToString()) && contentTask_Id != 0)
            {
                onBindData();
            }
        }
    }
    /// <summary>
    /// 非新增绑定数据
    /// </summary>
    public void onBindData()
    {
        PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
        PDTech.OA.BLL.OA_ARCHIVE ArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
        PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
        PDTech.OA.BLL.OA_ARCHIVE_TASK tbll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
        PDTech.OA.BLL.VIEW_ARCHIVE_TYPE_STEP vStepBll = new PDTech.OA.BLL.VIEW_ARCHIVE_TYPE_STEP();
        PDTech.OA.Model.OA_ARCHIVE Arwhere = new PDTech.OA.Model.OA_ARCHIVE();
        PDTech.OA.Model.OA_ARCHIVE_TASK tWhere = tbll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = contentTask_Id });
        PDTech.OA.BLL.RISK_POINT_INFO rpi_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
        #region 获取扩展属性并绑定
        if (tWhere != null)
        {
            /***风险防控--开始***/
            DataTable dt = rpi_bll.GetRiskPointInfo("OA_WORKFLOW_STEP", tWhere.CURRENT_STEP_ID.ToString());//查询风险防控
            if (dt != null && dt.Rows.Count > 0)
            {
                //配置提示信息
                tipInfo.Attributes.Add("title", "风险等级：" + dt.Rows[0]["level_name"] + "\n风险点：" + dt.Rows[0]["risk_point"] + "\n防范措施：" + dt.Rows[0]["risk_resolve"] + "");
                //配置提示样式
                switch (dt.Rows[0]["level_name"].ToString())
                {
                    case "一级":
                        tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "二级":
                        tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "三级":
                        tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                }
            }
            else
            {
                tipInfo.Visible = false;//隐藏提示图标
            }
            /***风险防控--结束***/
            Arwhere = ArchiveBll.GetArchiveInfo((decimal)tWhere.ARCHIVE_ID);
            #region 获取和遍历扩展属性
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
            if (attList.Count > 0)
            {
                foreach (var item in attList)
                {
                    switch (item.KEY)
                    {
                        case "SENDUNIT":
                            txtSendUnit.Text = item.VALUE;
                            break;
                        case "RecNum":
                            txtRecNum.Text = item.VALUE;
                            break;
                    }
                }
            }
            pdtInComingDate.Text = Arwhere.RECEIVE_TIME.Value.ToString("yyyy-MM-dd");
            txtDispath.Text = Arwhere.ARCHIVE_NO;
            txtRemark.Text = Arwhere.ARCHIVE_CONTENT;
            txtTitle.Text = Arwhere.ARCHIVE_TITLE;
            dplSzyd.Text = new ConvertHelper(Enum.Parse(typeof(EArchiveSzyd), Arwhere.IS_SHOW_IN_SZYD.ToString())).String;
            dplUrgency.Text = new ConvertHelper(Enum.Parse(typeof(EArchiveUrgency), Arwhere.PRI_LEVEL.ToString())).String;
            #endregion

            #region 获取该公文的附件

            PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
            where.REF_TYPE = "OA_ARCHIVE";
            where.REF_ID = (decimal)tWhere.ARCHIVE_ID;
            IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = fBll.get_InfoList(where);
            if (aList.Count > 0)
            {
                rpt_AttachmentList.DataSource = aList;
                rpt_AttachmentList.DataBind();
                tr_showList.Visible = true;
            }
            else
            {
                tr_showList.Visible = false;
            }
            #endregion

            ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(decimal.Parse(arId)); 
        }
        #endregion
    }
    protected void btnCc_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=99&action=copy'</script>");
    }
    /// <summary>
    /// 绑定下载地址
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_AttachmentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            PDTech.OA.Model.OA_ATTACHMENT_FILE item = e.Item.DataItem as PDTech.OA.Model.OA_ATTACHMENT_FILE;
            HyperLink hlDown = e.Item.FindControl("hlDown") as HyperLink;
            if (hlDown != null)
            {
                hlDown.NavigateUrl = "/DownLoad.aspx?file=" + item.FILE_PATH + "&fullName=" + item.FILE_NAME;
            }
        }
    }
}