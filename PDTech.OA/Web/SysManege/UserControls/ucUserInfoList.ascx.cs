using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Linq;

public partial class UserControls_ucUserInfoList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.USER_INFO bll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBind();
            BindData();
        }
    }

    public void InitBind()
    {
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { });
        foreach (var item in dList)
        {
            ListItem items = new ListItem();
            items.Value = item.DEPARTMENT_ID.ToString();
            items.Text = item.DEPARTMENT_NAME;
            dplDempList.Items.Add(items);
        }
        ListItem iteml = new ListItem();
        iteml.Value = "(全部)";
        iteml.Text = "(全部)";
        dplDempList.Items.Insert(0, iteml);
    }

    public void BindData()
    {

        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { });
        PDTech.OA.BLL.USERS_DEPT_OWNER_MAP udoBll = new PDTech.OA.BLL.USERS_DEPT_OWNER_MAP();
        IList<PDTech.OA.Model.USERS_DEPT_OWNER_MAP>  udoList = udoBll.GetModelList("");

        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
        {
            where.FULL_NAME = AidHelp.FilterSpecial(txtUserName.Text.Trim());
        }
        if (dplDempList.SelectedValue != "(全部)")
        {
            where.DEPARTMENT_ID = decimal.Parse(dplDempList.SelectedValue);
        }
        where.SortFields = " SORT_NUM,SORT_NUMBER ASC ";
        int Record = 0;
        IList<PDTech.OA.Model.USER_INFO> List = bll.get_Paging_UserInfoList(where, AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out Record);
        foreach (var uObj in List)
        {
            string[] deptArr = (from udo in udoList
                                where udo.USER_ID == uObj.USER_ID.Value
                                select
                                    (from dept in dList where dept.DEPARTMENT_ID.Value == udo.DEPARTMENT_ID select dept.DEPARTMENT_NAME).FirstOrDefault()).ToArray();
            if (deptArr != null)
            {
                uObj.OwnerDeptNames = string.Join("、", deptArr);
            }
        }
        rpt_UserList.DataSource = List;
        rpt_UserList.DataBind();
        AspNetPager.RecordCount = Record;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager.CurrentPageIndex = 1;
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void rpt_UserList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "nRemove")
        {
            decimal uId = Convert.ToDecimal(e.CommandArgument.ToString());
            bll.ModDisable(uId, "1");
            AspNetPager.CurrentPageIndex = 1;
        }
        if (e.CommandName == "nEnable")
        {
            decimal uId = Convert.ToDecimal(e.CommandArgument.ToString());
            bll.ModDisable(uId, "0");
            AspNetPager.CurrentPageIndex = 1;
        }
        if (e.CommandName == "resetPwd")
        {
            decimal uId = Convert.ToDecimal(e.CommandArgument.ToString());
            bll.UpdatePwd(new PDTech.OA.Model.USER_INFO() { LOGIN_PWD = FormsAuthentication.HashPasswordForStoringInConfigFile("999999", "MD5").ToString(), USER_ID = uId });
            AspNetPager.CurrentPageIndex = 1;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.layer.alert('已将此用户密码重置为:999999',1);</script>");
        }
    }
}