using System;
using System.Collections.Generic;

public partial class SysManege_UserControls_ucOnlineList : System.Web.UI.UserControl
{
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
        PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        where.IS_ONLINE = 1;
        int record = 0;
        IList<PDTech.OA.Model.USER_INFO> uList = uBll.get_Paging_UserInfoList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_UserList.DataSource = uList;
        rpt_UserList.DataBind();
        AspNetPager.RecordCount = record;
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
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
}