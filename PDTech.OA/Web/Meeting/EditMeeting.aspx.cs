using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_EditMeeting : System.Web.UI.Page
{
    public string t_rand = "";
    public string m_id = string.Empty;
    PDTech.OA.BLL.OA_MEETING meetBLL = new PDTech.OA.BLL.OA_MEETING();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.OA_MEETING_RECEIVER meetRBll = new PDTech.OA.BLL.OA_MEETING_RECEIVER();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            m_id = Request.QueryString["mid"];
            if (!string.IsNullOrEmpty(m_id))
            {
                ShowMeeting(decimal.Parse(m_id));
            }
        }
    }

    private void ShowMeeting(decimal meetingId)
    {
        PDTech.OA.Model.OA_MEETING model = meetBLL.GetModel(meetingId);
        txtTitle.Value = model.TITLE;
        txtContent.Text = model.CONTENT;
        txtLocation.Text = model.LOCATION;
        txtStartTime.Text = model.START_TIME.Value.ToString("yyyy-MM-dd HH:mm");
        txtEndTime.Text = model.END_TIME.Value.ToString("yyyy-MM-dd HH:mm");
        txtDepartment.Text = model.DEPT;
        txtOtherPerson.Text = model.OTHER_PERS;
        txtRemark.Text = model.REMARK;
        txtHostUser.Text = GetUserName(model.HOST_USER.Value);
        txtReceiveUser.Text = GetReceiveUser(model.MEETING_ID);
        //是否发送短信

        //绑定附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> attList = new List<PDTech.OA.Model.OA_ATTACHMENT_FILE>();
        attList = fBll.get_InfoList(new PDTech.OA.Model.OA_ATTACHMENT_FILE() { Append = string.Format(@" REF_ID={0} AND REF_TYPE='OA_MEETING' ", m_id) });
        rpt_AttachmentList.DataSource = attList;
        rpt_AttachmentList.DataBind();
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_MEETING model = new PDTech.OA.Model.OA_MEETING();
        model.TITLE = txtTitle.Value;
        model.CONTENT = txtContent.Text;
        model.MEETING_ROOM_ID = 0;
        if (!string.IsNullOrEmpty(hidRoomID.Value))
        {
            model.MEETING_ROOM_ID = decimal.Parse(hidRoomID.Value);
        }
        model.LOCATION = txtLocation.Text;
        model.START_TIME = DateTime.Parse(txtStartTime.Text);
        model.END_TIME = DateTime.Parse(txtEndTime.Text);
        model.DEPT = txtDepartment.Text;
        model.HOST_USER = decimal.Parse(hidHUserID.Value);
        model.OTHER_PERS = txtOtherPerson.Text;
        model.REMARK = txtRemark.Text;
        int isSend = chkIs_sendsms.Checked ? 1 : 0;
        model.SENDER = (int)CurrentAccount.USER_ID;
        string receiveUserId = hidRUserID.Value;
        string fileIds = hidAttachmentIds.Value;
        string hostIP = CurrentAccount.ClientIP;
        string hostName = CurrentAccount.ClientHostName;
        //先判断会议室在申请时刻是否被占用
        if (!meetBLL.Exists(model.MEETING_ROOM_ID.Value, model.LOCATION, model.START_TIME.Value, model.END_TIME.Value))
        {
            //没有被占用再添加会议
            bool result = meetBLL.Add(model, fileIds, receiveUserId, isSend, hostIP, hostName);
            if (result)
            {
                nPrompt("创建会议成功!", 2);
            }
            else
            {
                nPrompt("创建会议失败!", 2);
            }
        }
        else
        {
            nPrompt("会议室在当前时刻已被占用，请重新设置时间!", 3);
        }
    }

    protected void rpt_AttachmentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DelItem")
        {
            decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());
            if (!string.IsNullOrEmpty(m_id))
            {
                nPrompt("当前状态不能删除附件!", 0);
                return;
            }
            else
            {
                fBll.Delete(atId);
            }
        }
        BindData();
    }
    
    /// <summary>
    /// 绑定附件
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        if (!string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            if (!string.IsNullOrEmpty(HidIds))
                where.Append = string.Format(" ATTACHMENT_FILE_ID IN({0}) ", HidIds);
            if (!string.IsNullOrEmpty(m_id.ToString()) && int.Parse(m_id) != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_MEETING')", m_id);
            if (!string.IsNullOrEmpty(m_id.ToString()) && int.Parse(m_id) != 0 && string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_MEETING' ", m_id);
            IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = fBll.get_InfoList(where);
            if (aList.Count > 0)
            {
                rpt_AttachmentList.DataSource = aList;
                rpt_AttachmentList.DataBind();
                tr_showList.Visible = true;
            }
            else
            {
                tr_showList.Visible = false;
            }
        }
    }
    /// <summary>
    /// 
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

    /// <summary>
    ///  查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
        BindData();
    }

    /// <summary>
    /// 提示信息
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="flag"></param>
    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',8)</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',1);</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh(); window.parent.layer.closeAll();</script>");
        }
        else if (flag == 3)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
    }
}