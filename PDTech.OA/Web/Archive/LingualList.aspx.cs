using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Archive_LingualList : System.Web.UI.Page
{
    PDTech.OA.BLL.SYS_BASE_INFO sysBll = new PDTech.OA.BLL.SYS_BASE_INFO();
    public string t_rand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
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
        IList<PDTech.OA.Model.SYS_BASE_INFO> tList = new List<PDTech.OA.Model.SYS_BASE_INFO>();
        tList = sysBll.get_sysBase_DeptList(new PDTech.OA.Model.SYS_BASE_INFO() { BASE_NAME = txtName.Text.Trim(), SYS_TYPE = "文种" }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_tempList.DataSource = tList;
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
}