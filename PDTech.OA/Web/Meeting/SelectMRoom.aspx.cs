using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_SelectMRoom : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.MEETING_ROOM_INFO mriBll = new PDTech.OA.BLL.MEETING_ROOM_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.MEETING_ROOM_INFO> tList = new List<PDTech.OA.Model.MEETING_ROOM_INFO>();
        tList = mriBll.get_Paging_mRoomList(new PDTech.OA.Model.MEETING_ROOM_INFO() { MEETING_ROOM_NAME = txtName.Text.Trim() }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
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