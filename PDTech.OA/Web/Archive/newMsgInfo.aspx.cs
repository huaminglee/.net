using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_newMsgInfo : System.Web.UI.Page
{
    public string t_rand = "";
    string msgId = "";
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.OA_MESSAGE mBll = new PDTech.OA.BLL.OA_MESSAGE();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["mID"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["mID"].ToString()))
                msgId = Request.QueryString["mID"].ToString();
            btnSubmit.Enabled = false;
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(msgId))
            {
                mBindData();
            }
        }
    }

    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void mBindData()
    {
        string names = "";
        PDTech.OA.BLL.VIEW_USER_MSGINFO msBll = new PDTech.OA.BLL.VIEW_USER_MSGINFO();
        IList<PDTech.OA.Model.VIEW_USER_MSGINFO> list = new List<PDTech.OA.Model.VIEW_USER_MSGINFO>();
        list = msBll.get_MsgList(new PDTech.OA.Model.VIEW_USER_MSGINFO() { MESSAGE_ID = decimal.Parse(msgId) });
        if (list.Count > 0)
        {
            foreach (var item in list)
            {
                names += item.FULL_NAME + ",";
            }
            txtRname.Value = names.TrimEnd(',');
            txtTitle.Text = list[0].MESSAGE_TITLE;
            txtContent.Value = list[0].MESSAGE_CONTENT;
        }
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> attList = new List<PDTech.OA.Model.OA_ATTACHMENT_FILE>();
        attList = fBll.get_InfoList(new PDTech.OA.Model.OA_ATTACHMENT_FILE() { Append = string.Format(@" REF_ID={0} AND REF_TYPE='OA_MESSAGE' ", msgId) });
        rpt_AttachmentList.DataSource = attList;
        rpt_AttachmentList.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_MESSAGE msg = new PDTech.OA.Model.OA_MESSAGE();
        if (string.IsNullOrEmpty(hidUserIds.Value))
        {
            nPrompt("请先选择接收人员", 0);
            return;
        }
        if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
        {
            nPrompt("公告标题不能为空", 0);
            txtTitle.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtContent.Value.Trim()))
        {
            nPrompt("公告内容不能为空", 0);
            txtContent.Focus();
            return;
        }
        msg.MESSAGE_SENDER = CurrentAccount.USER_ID;
        msg.MESSAGE_TITLE = txtTitle.Text.Trim();
        msg.MESSAGE_CONTENT = txtContent.Value.Trim();
        int issendSms = 0;
        if (chkIs_sendsms.Checked)
        {
            issendSms = 1;
        }
        bool result = mBll.Add(msg, hidAttachmentIds.Value, hidUserIds.Value.TrimEnd(',').TrimStart(','), issendSms, CurrentAccount.ClientIP, CurrentAccount.ClientHostName);
        if (result)
        {
            nPrompt("发送公告成功!", 2);
        }
        else
        {
            nPrompt("发送公告失败!", 0);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rpt_AttachmentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DelItem")
        {
            decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());
            if (!hidAttachmentIds.Value.Contains(atId.ToString()))
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
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
            if (!string.IsNullOrEmpty(msgId.ToString()) && int.Parse(msgId) != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_MESSAGE')", msgId);
            if (!string.IsNullOrEmpty(msgId.ToString()) && int.Parse(msgId) != 0 && string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_MESSAGE' ", msgId);
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
}