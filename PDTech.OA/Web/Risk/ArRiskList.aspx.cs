using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_ArRiskList : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.VIEW_RISK_ORCHIVE_PROJECT viewtBll = new PDTech.OA.BLL.VIEW_RISK_ORCHIVE_PROJECT();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
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
            item_default.Text = "---请选择---";
            dplBusinessType.Items.Insert(0, item_default);
            BindData();
        }
    }

    /// <summary>
    /// 获取绑定风险处置单数据
    /// </summary>
    public void BindData()
    {
        IList<PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT> vList = new List<PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT>();
        PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT view = new PDTech.OA.Model.VIEW_RISK_ORCHIVE_PROJECT();


        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            view.Append = string.Format(@" START_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && string.IsNullOrEmpty(view.Append))
        {
            view.Append = string.Format(@" START_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && !string.IsNullOrEmpty(view.Append))
        {
            view.Append += string.Format(@" AND START_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()) && !string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            var sTime = DateTime.Parse(txtsTime.Text.Trim());
            var eTime = DateTime.Parse(txteTime.Text.Trim());
            if (sTime > eTime)
            {
                view.Append = string.Format(@" START_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
                view.Append += string.Format(@" AND START_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                view.Append = string.Format(@" START_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }

        if (!string.IsNullOrEmpty(hidDeptName.Value) && hidDeptName.Value != "---请选择---")
            view.DEPARTMENT_NAME = hidDeptName.Value;
        if (!string.IsNullOrEmpty(hidUserName.Value) && hidUserName.Value != "---请选择---" && hidDeptName.Value != "---请选择---")
            view.FULL_NAME = hidUserName.Value;
        if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
            view.ARCHIVE_TYPE = decimal.Parse(dplBusinessType.SelectedValue);
        if (!CurrentAccount.ISHavePurview("leader"))
        {
            view.USER_ID = CurrentAccount.USER_ID;
        }
        
        view.ARCHIVE_TITLE = AidHelp.FilterSpecial(txtmName.Value.Trim());
        view.SortFields = " START_TIME DESC ";
        int record = 0;
        vList = viewtBll.get_paging_viewList(view, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_taskList.DataSource = vList;
        rpt_taskList.DataBind();
        AspNetPager.RecordCount = record;
    }

    protected void rpt_taskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

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
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    public void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
}