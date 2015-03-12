using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Archive_UserControls_ucMsgList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.VIEW_USER_MSGINFO mBll = new PDTech.OA.BLL.VIEW_USER_MSGINFO();
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
        IList<PDTech.OA.Model.VIEW_USER_MSGINFO> mList = new List<PDTech.OA.Model.VIEW_USER_MSGINFO>();
        PDTech.OA.Model.VIEW_USER_MSGINFO where = new PDTech.OA.Model.VIEW_USER_MSGINFO();
        where.USER_ID = CurrentAccount.USER_ID;
        where.MESSAGE_TITLE =AidHelp.FilterSpecial(txtmName.Text.Trim());
        if (dplStatus.SelectedValue != "(全部)")
        {
            where.READ_STATUS = decimal.Parse(dplStatus.SelectedValue);
        }
        mList = mBll.get_Paging_MsgInfoList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rptMsgList.DataSource = mList;
        rptMsgList.DataBind();
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
    /// 把未读公告信息标记为已读
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRead_Click(object sender, EventArgs e)
    {
        PDTech.OA.BLL.OA_MESSAGE_RECEIVER mrBll = new PDTech.OA.BLL.OA_MESSAGE_RECEIVER();
        IList<PDTech.OA.Model.OA_MESSAGE_RECEIVER> list = new List<PDTech.OA.Model.OA_MESSAGE_RECEIVER>();
        foreach (RepeaterItem item in rptMsgList.Items)
        {
            PDTech.OA.Model.OA_MESSAGE_RECEIVER where = new PDTech.OA.Model.OA_MESSAGE_RECEIVER();
            System.Web.UI.HtmlControls.HtmlInputCheckBox chk = (System.Web.UI.HtmlControls.HtmlInputCheckBox)item.FindControl("checkbox");
            if (chk.Checked)
            {
                where.MESSAGE_ID = decimal.Parse(chk.Value);
                where.RECEIVER_ID = CurrentAccount.USER_ID;
                list.Add(where);
            }
        }
        bool result = mrBll.Update(list);
        if (result)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('已标记成功!',1);</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('标记失败!',8);</script>");
        }
        BindData();
    }
}