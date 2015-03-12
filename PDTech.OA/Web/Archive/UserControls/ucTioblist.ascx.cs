using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_UserControls_ucTioblist : System.Web.UI.UserControl
{
    const decimal ARCHIVE_TYPE = 71;
    PDTech.OA.BLL.OA_ARCHIVE archbll = new PDTech.OA.BLL.OA_ARCHIVE();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void BindData()
    {
        
        IList<PDTech.OA.Model.OA_ARCHIVE> vList = new List<PDTech.OA.Model.OA_ARCHIVE>();
       
        int record = 0;
        vList = archbll.get_Paging_ArchiveAllListszyd(AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_taskList.DataSource = vList;
        rpt_taskList.DataBind();
        AspNetPager.RecordCount = record;
    }

    protected void rpt_taskList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
           
            HiddenField hidArchiveState = (HiddenField)e.Item.FindControl("hidArchiveState");
            Label sHandle = (Label)e.Item.FindControl("sHandle");
            LinkButton lbdel = (LinkButton)e.Item.FindControl("lbdel");
            Label lbcreator = (Label)e.Item.FindControl("lbcreator");
            LinkButton lbedit = (LinkButton)e.Item.FindControl("lbedit");
            Label lbarchtypename = (Label)e.Item.FindControl("lbarchtypename");
            Label lbarchivetype = (Label)e.Item.FindControl("lbarchivetype");
            Label lbarchtypename2 = (Label)e.Item.FindControl("lbarchtypename2");
            if (lbarchivetype.Text != "71")
            {
                lbarchtypename2.Visible = true;
                lbarchtypename.Visible = false;
            }

            if (hidArchiveState.Value == "0" && CurrentAccount.USER_ID == decimal.Parse(lbcreator.Text)&&lbarchivetype.Text=="71")
            {
                lbdel.Visible = true;
                lbedit.Visible = true;
            }
            if (!String.IsNullOrEmpty(lbcreator.Text))
            {
                PDTech.OA.BLL.USER_INFO userbll=new PDTech.OA.BLL.USER_INFO();
                lbcreator.Text = userbll.GetUserInfo(decimal.Parse(lbcreator.Text)).FULL_NAME;
            }
           
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void rpt_taskList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PDTech.OA.BLL.OA_FAVORITE bll = new PDTech.OA.BLL.OA_FAVORITE();
        if (e.CommandName == "Collect")
        {
            PDTech.OA.Model.OA_FAVORITE model = new PDTech.OA.Model.OA_FAVORITE();
            model.REF_ID = decimal.Parse(e.CommandArgument.ToString());
            model.CREATE_TIME = DateTime.Now;
            model.REF_TYPE = "OA_ARCHIVE";
            model.USER_ID = CurrentAccount.USER_ID;
            int result = bll.Add(model);
            if (result == 1)
            {
                nPrompt("收藏成功", 1);
            }
            else if (result == 2)
            {
                nPrompt("已收藏此公文,无需重复收藏", 1);
            }
        }
        else if (e.CommandName == "del")
        {
            PDTech.OA.BLL.OA_ARCHIVE blla = new PDTech.OA.BLL.OA_ARCHIVE();
            blla.Delete(decimal.Parse(e.CommandArgument.ToString()));
            BindData();
        }
        else if (e.CommandName == "edit")
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "doWork", "<script>doWork('" + e.CommandArgument + "');</script>");

        }
    }
    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "<script>layer.alert('" + msg + "',8);</script>", false);
        }
        else if (flag == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "<script>layer.alert('" + msg + "',1);</script>", false);
        }
    }
}