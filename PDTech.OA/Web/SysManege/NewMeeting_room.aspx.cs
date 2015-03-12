using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_NewMeeting_room : System.Web.UI.Page
{
    PDTech.OA.BLL.MEETING_ROOM_INFO mBll = new PDTech.OA.BLL.MEETING_ROOM_INFO();
    string mID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mId"] != null)
        {
            mID = Request.QueryString["mId"].ToString();
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(mID))
                BindData();
        }
    }
    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.MEETING_ROOM_INFO mInfo = new PDTech.OA.Model.MEETING_ROOM_INFO();
        mInfo = mBll.GetmRoomInfo(decimal.Parse(mID));
        txtName.Text = mInfo.MEETING_ROOM_NAME;
        txtSummary.Text = mInfo.ROOM_DESC;
    }

    /// <summary>
    /// 保存会议室信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.MEETING_ROOM_INFO mwhere = new PDTech.OA.Model.MEETING_ROOM_INFO();
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('会议室名称不能为空!');</script>");
            return;
        }
        mwhere.MEETING_ROOM_NAME = txtName.Text.Trim();
        mwhere.ROOM_DESC = txtSummary.Text.Trim();
        int result = 0;
        if (string.IsNullOrEmpty(mID))
        {
            result = mBll.Add(mwhere);
        }
        else
        {
            mwhere.MEETING_ROOM_ID = decimal.Parse(mID);
            result = mBll.Update(mwhere);
        }
        if (result==1)
        {

            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存成功');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
        else if (result == -1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('已存在此名称,不能重复添加');</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存失败');</script>");
        }
    }
}