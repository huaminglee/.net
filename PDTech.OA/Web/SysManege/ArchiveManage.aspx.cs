using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_ArchiveManage : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_ARCHIVE viewtBll = new PDTech.OA.BLL.OA_ARCHIVE();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {

            BindType();
            BindData();
        }
    }
    /// <summary>
    /// 绑定下拉
    /// </summary>
    public void BindType()
    {
        PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
        IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> tList = tBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
        foreach (var item in tList)
        {
            ListItem ditem = new ListItem();
            ditem.Value = item.ARCHIVE_TYPE.ToString();
            ditem.Text = item.TYPE_NAME;
            dplArchiveType.Items.Add(ditem);
        }
        CurrentAccount.BindEnumDropDownList(typeof(EArchiveIsState), dplArchiveState);
        ListItem nitem = new ListItem();
        nitem.Value = "";
        nitem.Text = "请选择";
        dplArchiveType.Items.Insert(0, nitem);
        dplArchiveState.Items.Insert(0, nitem);
    }


    public void BindData()
    {
        PDTech.OA.Model.OA_ARCHIVE where = new PDTech.OA.Model.OA_ARCHIVE();
        if (!string.IsNullOrEmpty(dplArchiveState.SelectedValue))
        {
            where.CURRENT_STATE = decimal.Parse(dplArchiveState.SelectedValue);
        }
        if (!string.IsNullOrEmpty(dplArchiveType.SelectedValue))
        {
            where.ARCHIVE_TYPE = decimal.Parse(dplArchiveType.SelectedValue);
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && string.IsNullOrEmpty(where.Append))
        {
            where.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && !string.IsNullOrEmpty(where.Append))
        {
            where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()) && !string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            var sTime = DateTime.Parse(txtsTime.Text.Trim());
            var eTime = DateTime.Parse(txteTime.Text.Trim());
            if (sTime > eTime)
            {
                where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
                where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                where.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
        where.ARCHIVE_NO = txtArchiveNo.Text;
        where.ARCHIVE_TITLE = txtTitle.Text;
        int record = 0;
        IList<PDTech.OA.Model.OA_ARCHIVE> arList = viewtBll.get_Paging_ArchiveAllList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_ArchiveList.DataSource = arList;
        rpt_ArchiveList.DataBind();
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

    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
    }
}