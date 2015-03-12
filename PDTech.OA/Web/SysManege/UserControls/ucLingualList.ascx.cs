using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_ucLingualList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.SYS_BASE_INFO sysBll = new PDTech.OA.BLL.SYS_BASE_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.SYS_BASE_INFO> sList = new List<PDTech.OA.Model.SYS_BASE_INFO>();
        sList = sysBll.get_sysBase_DeptList(new PDTech.OA.Model.SYS_BASE_INFO() { SYS_TYPE = "文种", BASE_NAME = AidHelp.FilterSpecial(txtmName.Text.Trim()) }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_tempList.DataSource = sList;
        rpt_tempList.DataBind();
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
    /// <summary>
    /// 删除文种
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_mRoomDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (e.CommandName == "nDel")
            {
                decimal tID = decimal.Parse(e.CommandArgument.ToString());
                bool result = sysBll.Delete(tID);
                if (result)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('删除成功',1);</script>");
                }
                AspNetPager.CurrentPageIndex = 1;
            }
        }
    }
}