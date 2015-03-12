using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Approve_sel_Approve : System.Web.UI.Page
{
    public string t_rand = "";
    public string arId = "";
    string ARCHIVE_TYPE = "";
    const string Symol = "/images/nextIcon.png";
    protected void Page_Load(object sender, EventArgs e)
    {
        PDTech.OA.BLL.RISK_POINT_INFO rpi_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
        if (Request.QueryString["type"] != null)
        {
            ARCHIVE_TYPE = Request.QueryString["type"].ToString();
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "处理单";//设置标题
            if (ARCHIVE_TYPE == "61" || ARCHIVE_TYPE == "62")
                tr_Mark.Visible = true;
        }
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["arId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["arId"].ToString()))
                arId = Request.QueryString["arId"].ToString();

        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(arId) && arId != "0")
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
        #region 获取扩展属性并绑定
        Arwhere = ArchiveBll.GetArchiveInfo(decimal.Parse(arId));
        #region 获取和遍历扩展属性
        txtTitle.Text = Arwhere.ARCHIVE_TITLE;
        txtContent.Text = Arwhere.ARCHIVE_CONTENT;
        #endregion
        #region 获取该公文的附件

        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        where.REF_TYPE = "OA_ARCHIVE";
        where.REF_ID = decimal.Parse(arId);
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
        #endregion
        ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(decimal.Parse(arId)); 
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