using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_sel_risk : System.Web.UI.Page
{
    public string t_rand = "";
    public decimal arId = 0;
    PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
    PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
    PDTech.OA.BLL.OA_ARCHIVE ArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.RISK_TYPE_INFO rBll = new PDTech.OA.BLL.RISK_TYPE_INFO();

    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["arId"] != null)//获取当前公文ID参数
        {
            arId = decimal.Parse(Request.QueryString["arId"].ToString());
        }
        if (!IsPostBack)
        {
            InitLoad();
            onBindData();
        }
    }
    /// <summary>
    /// 初始化页面必要信息
    /// </summary>
    public void InitLoad()
    {
        #region 下拉框数据绑定
        CurrentAccount.BindEnumDropDownList(typeof(EArchiveRiskLevel), dplUrgency);
        IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> tList = tBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
        foreach (var item in tList)
        {
            ListItem items = new ListItem();
            if (item.ARCHIVE_TYPE != 51)
            {
                items.Value = item.ARCHIVE_TYPE.ToString();
                items.Text = item.TYPE_NAME;
                dplBusinessType.Items.Add(items);
            }

        }
        ListItem item_default = new ListItem();
        item_default.Value = "";
        item_default.Text = "请选择...";
        dplBusinessType.Items.Insert(0, item_default);
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { });
        foreach (var item in dList)
        {
            ListItem ditem = new ListItem();
            ditem.Value = item.DEPARTMENT_ID.ToString();
            ditem.Text = item.DEPARTMENT_NAME;
            dplDeptList.Items.Add(ditem);
        }
        ListItem item_d = new ListItem();
        item_d.Value = "";
        item_d.Text = "请选择...";
        dplDeptList.Items.Insert(0, item_d);
        IList<PDTech.OA.Model.RISK_TYPE_INFO> rList = rBll.get_risktypeList(new PDTech.OA.Model.RISK_TYPE_INFO() { });
        foreach (var itemr in rList)
        {
            ListItem ditem = new ListItem();
            ditem.Value = itemr.RISK_TYPE_NAME;
            ditem.Text = itemr.RISK_TYPE_NAME;
            dplRiskList.Items.Add(ditem);
        }
        ListItem item_r = new ListItem();
        item_r.Value = "";
        item_r.Text = "请选择...";
        dplRiskList.Items.Insert(0, item_r);
        #endregion
    }
    public void onBindData()
    {
        PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
        #region 获取扩展属性并绑定
        PDTech.OA.Model.OA_ARCHIVE Arwhere = ArchiveBll.GetArchiveInfo(arId);
        #region 获取和遍历扩展属性
        IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
        attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
        if (attList.Count > 0)
        {
            foreach (var item in attList)
            {
                switch (item.KEY)
                {
                    case "BusinessType":
                        dplBusinessType.SelectedItem.Text = item.VALUE;
                        dplBusinessType.Enabled = false;
                        break;
                    case "HandleDate":
                        txtHandleDate.Value = item.VALUE;
                        txtHandleDate.Disabled = true;
                        break;
                    case "HandleUser":
                        txtUserName.Value = item.VALUE;
                        txtUserName.Disabled = true;
                        break;
                    case "DeptId":
                        dplDeptList.SelectedItem.Text = item.VALUE;
                        dplDeptList.Enabled = false;
                        break;
                    case "RiskType":
                        dplRiskList.SelectedItem.Text = item.VALUE;
                        dplRiskList.Enabled = false;
                        break;
                    case "BusinessNum":
                        txtBusinessNum.Text = item.VALUE;
                        txtBusinessNum.Enabled = false;
                        break;
                }
            }
        }
        txtSeqNum.Value = Arwhere.ARCHIVE_NO;
        txtRemark.Text = Arwhere.ARCHIVE_CONTENT;
        txtTitle.Text = Arwhere.ARCHIVE_TITLE;
        dplUrgency.SelectedValue = Arwhere.PRI_LEVEL.ToString();
        #endregion

        #region 获取该公文的附件

        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        where.REF_TYPE = "OA_ARCHIVE";
        where.REF_ID = arId;
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


        if (Arwhere != null)
        {
            PDTech.OA.BLL.RISK_HANDLE_MAP rBll = new PDTech.OA.BLL.RISK_HANDLE_MAP();
            PDTech.OA.Model.RISK_HANDLE_MAP ArInfo = rBll.get_mapInfo(new PDTech.OA.Model.RISK_HANDLE_MAP() { RISK_HANDLE_ARCHIVE_ID = arId });
            if (ArInfo != null && ArInfo.ARCHIVE_ID != 0)
            {
                lbtnUrl.Visible = true;
                lbtnUrl.Text = "查看此公文";
                switch ((int)ArInfo.ARCHIVE_TYPE)
                {
                    case 10:
                        lbtnUrl.NavigateUrl = "/Archive/sel_Generalpieces.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 11:
                        lbtnUrl.NavigateUrl = "/Archive/sel_Ordinarypieces.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 12:
                        lbtnUrl.NavigateUrl = "/Archive/sel_UnitDoc.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                        lbtnUrl.NavigateUrl = "/Archive/sel_supInfo.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 24:
                        lbtnUrl.NavigateUrl = "/Admin/sel_Proposal.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 32:
                        lbtnUrl.NavigateUrl = "/Admin/sel_Personnal.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                    case 33:
                        lbtnUrl.Text = "查看此项目";
                        lbtnUrl.NavigateUrl = "/Admin/selFinance.aspx?pid=" + ArInfo.ARCHIVE_ID + "";
                        break;
                }
            }
            else
            {
                lbtnUrl.Visible = false;
            }
        }
        #endregion
    }

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