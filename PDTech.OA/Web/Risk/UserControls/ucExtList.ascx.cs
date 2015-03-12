using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Risk_UserControls_ucExtList : System.Web.UI.UserControl
{
    string RISK_TYPE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            RISK_TYPE = Server.UrlDecode(Request.QueryString["type"].ToString());
        }
        if (!IsPostBack)
        {
            PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
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
            lblTab_Name.InnerText = RISK_TYPE + "列表";
            dplBusinessType.Items.Insert(0, item_default);
            InitBindData();
        }
    }
    public void InitBindData()
    {
        PDTech.OA.BLL.VIEW_RISK_ATT vBll = new PDTech.OA.BLL.VIEW_RISK_ATT();
        PDTech.OA.Model.VIEW_RISK_ATT where = new PDTech.OA.Model.VIEW_RISK_ATT();
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && string.IsNullOrEmpty(where.Append))
        {
            where.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(AidHelp.FilterSpecial(txteTime.Text)).ToString()));
        }
        else if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && !string.IsNullOrEmpty(where.Append))
        {
            where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(AidHelp.FilterSpecial(txteTime.Text)).ToString()));
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()) && !string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            var sTime = DateTime.Parse(AidHelp.FilterSpecial(txtsTime.Text.Trim()));
            var eTime = DateTime.Parse(AidHelp.FilterSpecial(txteTime.Text.Trim()));
            if (sTime > eTime)
            {
                where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(AidHelp.FilterSpecial(txteTime.Text)).ToString()));
                where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(AidHelp.FilterSpecial(txtsTime.Text)).ToString()));
            }
            else if (sTime == eTime)
            {
                where.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(AidHelp.FilterSpecial(txteTime.Text)).ToString()));
            }
        }
        if (!string.IsNullOrEmpty(hidDeptName.Value))
            where.DEPT_NAME =AidHelp.FilterSpecial(hidDeptName.Value);
        if (!string.IsNullOrEmpty(hidUserName.Value) && hidUserName.Value != "---请选择---")
            where.HANDLE_USER =AidHelp.FilterSpecial(hidUserName.Value);
        if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
            where.BUSINESS = dplBusinessType.SelectedItem.Text;
        where.RISKTYPE = RISK_TYPE;
        where.ARCHIVE_TITLE =AidHelp.FilterSpecial(txtTitle.Value);
        where.ARCHIVE_NO =AidHelp.FilterSpecial(txtArchiveNo.Text);
        if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
            where.BUSINESS = dplBusinessType.SelectedItem.Text;
        int record = 0;
        IList<PDTech.OA.Model.VIEW_RISK_ATT> vLIst = vBll.get_viewList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_taskList.DataSource = vLIst;
        rpt_taskList.DataBind();
        AspNetPager.RecordCount = record;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        InitBindData();
    }
}