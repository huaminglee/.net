using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_EduTaskList : System.Web.UI.Page
{
	public string t_rand = "";
    PDTech.OA.BLL.OA_RISKEDUCATION riskBll = new PDTech.OA.BLL.OA_RISKEDUCATION();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    public bool isshowexpire = false;
    string[] arrayType = new string[] { "全部", "法律法规", "文件通知", "讲话精神", "影像资料", "警示案例" };
    protected void Page_Load(object sender, EventArgs e)
    {
	    t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
	    if (!IsPostBack)
        {
            if (Request.QueryString["ISshowexpire"] != null && Request.QueryString["ISshowexpire"].ToString()=="1")
            {
                isshowexpire = true;
                dquery.Visible = false;
            }

            BindDropDownList();
            BindData();
        }
    }

    private void BindDropDownList()
    {
        this.ddlType.Items.Clear();
        ListItem[] items = new ListItem[arrayType.Length];
        for (int i = 0; i < arrayType.Length; i++)
        {
            items[i] = new ListItem(arrayType[i]);
        }
        this.ddlType.Items.AddRange(items);
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_RISKEDUCATION> riskList = new List<PDTech.OA.Model.OA_RISKEDUCATION>();
        string type = AidHelp.FilterSpecial(ddlType.SelectedValue);
        string title = AidHelp.FilterSpecial(txtmName.Text);
        if (!string.IsNullOrEmpty(title))
        {
            riskList = riskBll.Get_Paging_List(CurrentAccount.USER_ID, title, type, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record, isshowexpire);
        }
        else
        {
            riskList = riskBll.Get_Paging_List(CurrentAccount.USER_ID, null, type, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record, isshowexpire);
        }
        rpt_EducationList.DataSource = riskList;
        rpt_EducationList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

	protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}