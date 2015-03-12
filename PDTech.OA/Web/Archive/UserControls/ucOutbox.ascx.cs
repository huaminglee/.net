using System;
using System.Collections.Generic;

public partial class Archive_UserControls_ucOutbox : System.Web.UI.UserControl
{
    PDTech.OA.BLL.VIEW_OUTMESSAGE oBll = new PDTech.OA.BLL.VIEW_OUTMESSAGE();

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
        IList<PDTech.OA.Model.VIEW_OUTMESSAGE> mList = new List<PDTech.OA.Model.VIEW_OUTMESSAGE>();
        PDTech.OA.Model.VIEW_OUTMESSAGE where = new PDTech.OA.Model.VIEW_OUTMESSAGE();
        where.MESSAGE_SENDER = CurrentAccount.USER_ID;
        where.MESSAGE_TITLE =AidHelp.FilterSpecial(txtmName.Text.Trim());
        mList = oBll.get_Paging_outMsgList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_MsgList.DataSource = mList;
        rpt_MsgList.DataBind();
        AspNetPager.RecordCount = record;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}