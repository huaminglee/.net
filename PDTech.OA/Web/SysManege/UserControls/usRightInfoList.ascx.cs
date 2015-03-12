using System;
using System.Collections.Generic;

public partial class SysManege_UserControls_usRightInfoList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.RIGHT_INFO bll = new PDTech.OA.BLL.RIGHT_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.RIGHT_INFO where = new PDTech.OA.Model.RIGHT_INFO();
        if (!string.IsNullOrEmpty(txtRiName.Text.Trim()))
        {
            where.RIGHT_NAME = AidHelp.FilterSpecial(txtRiName.Text.Trim());
        }
        where.SortFields = " SORT_NUM ASC ";
        int Record = 0;
        IList<PDTech.OA.Model.RIGHT_INFO> List = bll.get_Paging_RightInfoList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out Record);
        rpt_PurviewList.DataSource = List;
        rpt_PurviewList.DataBind();
        AspNetPager.RecordCount = Record;
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
}