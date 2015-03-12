using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class SysManege_UserControls_ucEduTaskList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.OA_RISKEDUCATION riskBll = new PDTech.OA.BLL.OA_RISKEDUCATION();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    string[] arrayType = new string[] { "全部", "法律法规", "文件通知", "讲话精神", "影像资料", "警示案例" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        string type = ddlType.SelectedValue;
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            riskList = riskBll.Get_Paging_List(0, title, type, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            riskList = riskBll.Get_Paging_List(0, null, type, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
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

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}