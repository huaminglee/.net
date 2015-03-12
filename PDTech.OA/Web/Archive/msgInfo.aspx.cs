using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Archive_msgInfo : System.Web.UI.Page
{
    public string t_rand = "";
    string mId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["Mid"] != null)
        {
            mId = Request.QueryString["Mid"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
            //this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.doRefresh();</script>");
        }
    }
    /// <summary>
    /// 获取并绑定信息
    /// </summary>
    public void BindData()
    {
        PDTech.OA.BLL.VIEW_USER_MSGINFO oBll = new PDTech.OA.BLL.VIEW_USER_MSGINFO();//实例化用户公告试图Bll
        PDTech.OA.Model.VIEW_USER_MSGINFO oView = oBll.get_MsgInfo(decimal.Parse(mId));//获取用户公告信息
        lbl_sendName.Text = oView.SENDER_FULLNAME;
        lbl_sendTime.Text = oView.MESSAGE_SEND_TIME.HasValue ? oView.MESSAGE_SEND_TIME.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
        title.Text = oView.MESSAGE_TITLE;//绑定用户公告标题
        txtContent.Text = oView.MESSAGE_CONTENT;//绑定用户公告内容
        PDTech.OA.BLL.OA_ATTACHMENT_FILE fbll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();//实例化公告附件Bll
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> mlist = fbll.get_InfoList(new PDTech.OA.Model.OA_ATTACHMENT_FILE() { REF_TYPE = "OA_MESSAGE", REF_ID = oView.MESSAGE_ID });//根据附件类型和所属公告获取数据并绑定
        if (mlist.Count > 0)
        {
            tr_showList.Visible = true;
            rpt_AttachmentList.DataSource = mlist;
            rpt_AttachmentList.DataBind();
        }
        /***********修改公告信息的已读状态***********/
        PDTech.OA.BLL.OA_MESSAGE_RECEIVER mrBll = new PDTech.OA.BLL.OA_MESSAGE_RECEIVER();
        IList<PDTech.OA.Model.OA_MESSAGE_RECEIVER> list = new List<PDTech.OA.Model.OA_MESSAGE_RECEIVER>();
        PDTech.OA.Model.OA_MESSAGE_RECEIVER where = new PDTech.OA.Model.OA_MESSAGE_RECEIVER();
        where.MESSAGE_ID = oView.MESSAGE_ID;
        where.RECEIVER_ID = CurrentAccount.USER_ID;
        list.Add(where);
        bool result = mrBll.Update(list);
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