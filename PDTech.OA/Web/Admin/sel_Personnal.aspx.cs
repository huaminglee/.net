using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Admin_sel_Personnal : System.Web.UI.Page
{
    public string t_rand = "";
    public string arId = "";
    const decimal ARCHIVE_TYPE = 32;
    const string Symol = "/images/nextIcon.png";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["arId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["arId"].ToString()))
                arId = Request.QueryString["arId"].ToString();
        }
        if (!IsPostBack)
        {
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "议题";//设置标题
            if (!string.IsNullOrEmpty(arId))
            {
                onBindData();
            }
        }
    }
    /// <summary>
    /// 绑定数据
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

        Arwhere = ArchiveBll.GetArchiveInfo(decimal.Parse(arId));//获取当前ID的公文信息

        #region 获取和遍历扩展属性
        IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
        attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
        if (attList.Count > 0)
        {
            foreach (var item in attList)
            {
                switch (item.KEY)
                {
                    case "Lordsent":
                        txtLordsent.Text = item.VALUE;
                        break;
                }
            }
        }
        txtRemark.Text = Arwhere.ARCHIVE_CONTENT;//人事任免公文备注
        txtTitle.Text = Arwhere.ARCHIVE_TITLE;//标题
        #endregion

        #region 获取该公文的附件

        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        where.REF_TYPE = "OA_ARCHIVE";
        where.REF_ID = (decimal)Arwhere.ARCHIVE_ID;
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = fBll.get_InfoList(where);//获取此公文的附件
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
    /// 重新处理附件的下载路径和方式
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