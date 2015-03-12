using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_ucMeet_RoomList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.MEETING_ROOM_INFO mBll = new PDTech.OA.BLL.MEETING_ROOM_INFO();
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
        IList<PDTech.OA.Model.MEETING_ROOM_INFO> mList = new List<PDTech.OA.Model.MEETING_ROOM_INFO>();
        mList = mBll.get_Paging_mRoomList(new PDTech.OA.Model.MEETING_ROOM_INFO() { MEETING_ROOM_NAME = AidHelp.FilterSpecial(txtmName.Text.Trim()) }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_mRoomDataList.DataSource = mList;
        rpt_mRoomDataList.DataBind();
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
    /// 删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_mRoomDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (e.CommandName == "nDel")
            {
                decimal mID = decimal.Parse(e.CommandArgument.ToString());
                bool result = mBll.Delete(mID);
                if (result)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('删除成功',1);</script>");
                }
                AspNetPager.CurrentPageIndex = 1;
            }
        }
    }
}