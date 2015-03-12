using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Meeting_ViewMeeting : System.Web.UI.Page
{
    public string t_rand = "";
    string mid = string.Empty;
    PDTech.OA.BLL.OA_MEETING meetBLL = new PDTech.OA.BLL.OA_MEETING();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.OA_MEETING_RECEIVER meetRBll = new PDTech.OA.BLL.OA_MEETING_RECEIVER();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            mid = Request.QueryString["mid"];
            if (!string.IsNullOrEmpty(mid))
            {
                ShowMeeting(decimal.Parse(mid));
            }
            //this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.doRefresh();</script>");
        }
    }

    private void ShowMeeting(decimal meetingId)
    {
        PDTech.OA.Model.OA_MEETING model = meetBLL.GetModel(meetingId);
        lbTitle.Text = model.TITLE;
        txtContent.Text = model.CONTENT;
        lbLocation.Text = model.LOCATION;
        lbStartTime.Text = model.START_TIME.Value.ToString("yyyy-MM-dd HH:mm");
        lbEndTime.Text = model.END_TIME.Value.ToString("yyyy-MM-dd HH:mm");
        lbDepartment.Text = model.DEPT;
        lbOtherUser.Text = model.OTHER_PERS;
        txtRemark.Text = model.REMARK;
        lbHostUser.Text = GetUserName(model.HOST_USER.Value);
        lbReceiver.Text = GetReceiveUser(model.MEETING_ID);
        //是否发送短信

        //绑定附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> attList = new List<PDTech.OA.Model.OA_ATTACHMENT_FILE>();
        attList = fBll.get_InfoList(new PDTech.OA.Model.OA_ATTACHMENT_FILE() { Append = string.Format(@" REF_ID={0} AND REF_TYPE='OA_MEETING' ", mid) });
        rpt_AttachmentList.DataSource = attList;
        rpt_AttachmentList.DataBind(); //tr_showList
        if (attList != null && attList.Count > 0)
        {
            tr_showList.Visible = true;
        }

        //修改会议状态为已读
        PDTech.OA.Model.OA_MEETING_RECEIVER cache = meetRBll.GetModel(decimal.Parse(mid), CurrentAccount.USER_ID);
        if (cache != null)
        {
            if (cache.READ_STATUS == 0)
            {
                PDTech.OA.Model.OA_MEETING_RECEIVER reModel = new PDTech.OA.Model.OA_MEETING_RECEIVER();
                reModel.MEETING_ID = decimal.Parse(mid);
                reModel.RECEIVER_ID = CurrentAccount.USER_ID;
                reModel.READ_STATUS = 1;
                reModel.READ_TIME = DateTime.Now;
                bool result = meetRBll.UpdateState(reModel);
            }
        }
    }

    private string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    private string GetReceiveUser(decimal meetingId)
    {
        string userNames = string.Empty;
        string strWhere = " MEETING_ID = " + meetingId.ToString();
        List<PDTech.OA.Model.OA_MEETING_RECEIVER> list = meetRBll.GetModelList(strWhere);
        if (list != null && list.Count > 0)
        {
            foreach (PDTech.OA.Model.OA_MEETING_RECEIVER item in list)
            {
                if (userNames.Length > 0)
                {
                    userNames += "," + GetUserName(item.RECEIVER_ID.Value);
                }
                else
                {
                    userNames += GetUserName(item.RECEIVER_ID.Value);
                }
            }
        }
        return userNames;
    }

    /// <summary>
    /// 附件下载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_AttachmentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            PDTech.OA.Model.OA_ATTACHMENT_FILE item = e.Item.DataItem as PDTech.OA.Model.OA_ATTACHMENT_FILE;
            HyperLink hlDown = e.Item.FindControl("hlDown") as HyperLink;
            if (hlDown != null)
            {
                hlDown.NavigateUrl = "/DownLoad.aspx?file=" + item.FILE_PATH + "&fullName=" + item.FILE_NAME;
            }
        }
    }
}