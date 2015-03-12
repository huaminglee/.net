using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_ucStencilList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.TEMPLATE_INFO tBll = new PDTech.OA.BLL.TEMPLATE_INFO();
    string stype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            stype = Server.UrlDecode(Request.QueryString["type"].ToString());
            hidType.Value = stype;
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.TEMPLATE_INFO> tList = new List<PDTech.OA.Model.TEMPLATE_INFO>();
        tList = tBll.get_Paging_tempList(new PDTech.OA.Model.TEMPLATE_INFO() { TEMPLATE_JC = AidHelp.FilterSpecial(txtmName.Text.Trim()), TEMPLATE_TYPE = stype }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_tempList.DataSource = tList;
        rpt_tempList.DataBind();
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
    protected void rpt_mRoomDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (e.CommandName == "nDel")
            {
                decimal tID = decimal.Parse(e.CommandArgument.ToString());
                bool result = tBll.Delete(tID);
                if (result)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('删除成功',1);</script>");
                }
                AspNetPager.CurrentPageIndex = 1;
            }
        }
    }
}