using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class UserControls_ucDepartment : System.Web.UI.UserControl
{
    PDTech.OA.BLL.DEPARTMENT bll = new PDTech.OA.BLL.DEPARTMENT();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.DEPARTMENT where = new PDTech.OA.Model.DEPARTMENT();
        if (!string.IsNullOrEmpty(txtDeptName.Text.Trim()))
        {
            where.DEPARTMENT_NAME = AidHelp.FilterSpecial(txtDeptName.Text.Trim());
        }
        where.SortFields = " SORT_NUM ASC";
        int Record = 0;
        IList<PDTech.OA.Model.DEPARTMENT> List = bll.get_Paging_DeptList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out Record);
        rpt_DeptList.DataSource = List;
        rpt_DeptList.DataBind();
        AspNetPager.RecordCount = Record;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void rpt_DeptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "nRemove")
        {
            decimal DeptId = Convert.ToDecimal(e.CommandArgument.ToString());
            bll.ModDisable(DeptId, "1");
            AspNetPager.CurrentPageIndex = 1;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
}