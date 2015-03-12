using System;
using System.Collections.Generic;

public partial class SysManege_UserControls_ucRoleList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.ROLE_INFO rBll = new PDTech.OA.BLL.ROLE_INFO();
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
        PDTech.OA.Model.ROLE_INFO where = new PDTech.OA.Model.ROLE_INFO();
        where.ROLE_NAME = AidHelp.FilterSpecial(txtRoleName.Text.Trim());
        int record = 0;
        IList<PDTech.OA.Model.ROLE_INFO> rList = rBll.get_Paging_RoleInfoList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_RoleList.DataSource = rList;
        rpt_RoleList.DataBind();
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
}