using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_usBaseList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.SYS_BASE_INFO sysBll = new PDTech.OA.BLL.SYS_BASE_INFO();
    public string sysType = "";
    public string tTitle = "";
    public string tTitle_jc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sAc"] == null || string.IsNullOrEmpty(Request.QueryString["sAc"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数');history.go(-1);return false;</script>");
        }
        else
        {
            sysType = Server.UrlDecode(Request.QueryString["sAc"].ToString());
        }
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
        IList<PDTech.OA.Model.SYS_BASE_INFO> sList = new List<PDTech.OA.Model.SYS_BASE_INFO>();
        sList = sysBll.get_sysBase_DeptList(new PDTech.OA.Model.SYS_BASE_INFO() { SYS_TYPE = sysType, BASE_NAME = AidHelp.FilterSpecial(txtDeptName.Text.Trim()) }, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        lblTitle.InnerText = sysType + "列表";
        hidName.Value = sysType;
        switch (sysType)
        {
            case "交办单位":
                tTitle = "单位名称";
                tTitle_jc = "单位简称";
                break;
            case "承办单位":
                tTitle = "单位名称";
                tTitle_jc = "单位简称";
                break;
            case "来文单位":
                tTitle = "单位名称";
                tTitle_jc = "单位简称";
                break;
            case "发文单位":
                tTitle = "单位名称";
                tTitle_jc = "单位简称";
                break;
            case "信访问题分类":
                tTitle = "信访问题名称";
                tTitle_jc = "信访问题简称";
                break;
            case "文种维护":
                tTitle = "文种名称";
                tTitle_jc = "文种简称";
                break;
            case "办理意见模板":
                tTitle = "模板内容";
                tTitle_jc = "简略内容";
                break;
        }
        rpt_BaseDataList.DataSource = sList;
        rpt_BaseDataList.DataBind();
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
    protected void rpt_BaseDataList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (e.CommandName == "nDel")
            {
                decimal sysID = decimal.Parse(e.CommandArgument.ToString());
                bool result = sysBll.Delete(sysID);
                if (result)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('删除成功');</script>");
                }
                AspNetPager.CurrentPageIndex = 1;
            }
        }
    }
}