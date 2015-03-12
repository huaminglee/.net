using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_ucRoll_NewsList : System.Web.UI.UserControl
{
    public string t_rand = "";
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.ROLL_NEWS newsBll = new PDTech.OA.BLL.ROLL_NEWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            BindData();
        }
        this.btnRoll.Click += btnRoll_Click;
        this.btnNotRoll.Click += btnNotRoll_Click;
        this.btnDel.Click += btnDel_Click;
    }

    void btnDel_Click(object sender, EventArgs e)
    {
        string sb = string.Empty;
        for (int i = 0; i < this.rpt_NewsDataList.Items.Count; i++)
        {
            CheckBox cb = (this.rpt_NewsDataList.Items[i].FindControl("chbSelect")) as CheckBox;
            if (cb.Checked == true)
            {
                sb += (this.rpt_NewsDataList.Items[i].FindControl("lbNewsID") as Label).Text + ",";
            }
        }
        if (sb.Length > 0)
        {
            sb = sb.Substring(0, sb.Length - 1);
        }
        bool r = newsBll.DeleteList(sb);
        if (r)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');doRefresh();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('没有可删除的记录！');</script>");
        }
    }

    void btnNotRoll_Click(object sender, EventArgs e)
    {
        string sb = string.Empty;
        for (int i = 0; i < this.rpt_NewsDataList.Items.Count; i++)
        {
            CheckBox cb = (this.rpt_NewsDataList.Items[i].FindControl("chbSelect")) as CheckBox;
            if (cb.Checked == true)
            {
                sb += (this.rpt_NewsDataList.Items[i].FindControl("lbNewsID") as Label).Text + ",";
            }
        }
        if (sb.Length > 0)
        {
            sb = sb.Substring(0, sb.Length - 1);
        }
        bool r = newsBll.Update(sb, 0);
        if (r)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消滚动成功！');doRefresh();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消滚动失败！');</script>");
        }
    }

    void btnRoll_Click(object sender, EventArgs e)
    {
        string sb = string.Empty;
        for (int i = 0; i < this.rpt_NewsDataList.Items.Count; i++)
        {
            CheckBox cb = (this.rpt_NewsDataList.Items[i].FindControl("chbSelect")) as CheckBox;
            if (cb.Checked == true)
            {
                sb += (this.rpt_NewsDataList.Items[i].FindControl("lbNewsID") as Label).Text + ",";
            }
        }
        if (sb.Length > 0)
        {
            sb = sb.Substring(0, sb.Length - 1);
        }
        bool r = newsBll.Update(sb, 1);
        if (r)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设为滚动成功！');doRefresh();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设为滚动失败！');</script>");
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.ROLL_NEWS> newsList = new List<PDTech.OA.Model.ROLL_NEWS>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            newsList = newsBll.Get_Paging_List(title, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        }
        else
        {
            newsList = newsBll.Get_Paging_List(null, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        }
        rpt_NewsDataList.DataSource = newsList;
        rpt_NewsDataList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}