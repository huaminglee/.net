using System;
using System.Collections.Generic;

public partial class SysManege_UserControls_ucMeetingList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.OA_MEETING meetingBll = new PDTech.OA.BLL.OA_MEETING();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_MEETING> meetingList = new List<PDTech.OA.Model.OA_MEETING>();
        string title = AidHelp.FilterSpecial(txtmName.Text);
        if (!string.IsNullOrEmpty(title))
        {
            meetingList = meetingBll.Get_Paging_MeetingList(title, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        }
        else
        {
            meetingList = meetingBll.Get_Paging_MeetingList(null, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        }
        rpt_MeetingList.DataSource = meetingList;
        rpt_MeetingList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}