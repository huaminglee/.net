using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class NewUserInfo : System.Web.UI.Page
{
    PDTech.OA.BLL.USER_INFO ubll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.DEPARTMENT bll = new PDTech.OA.BLL.DEPARTMENT();
    private string parentId = "1";
    string uId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uId"] != null)
        {
            uId = Request.QueryString["uId"].ToString();
        }
        if (Request.QueryString["uId"] != null && !AidHelp.IsDecimal(Request.QueryString["uId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        if (!IsPostBack)
        {
            LoadDeptDropDownList(this.ddlDept_List, parentId, true);
            if (!string.IsNullOrEmpty(uId))
                BindData();
        }
    }
    #region 获取部门列表
    public void LoadDeptDropDownList(DropDownList dplist, string selectedValue, bool allFlag)
    {
        //如果列表中还有项目则先清空
        if (dplist.Items.Count > 0)
        {
            dplist.Items.Clear();
        }
        //获取所有类别
        DataTable orgTable = bll.get_DeptTab(new PDTech.OA.Model.DEPARTMENT() { });

        //填充dplist
        CreateList(dplist, orgTable, "0", 0, "");

        //选中默认项
        if (selectedValue != String.Empty)
        {
            ListItem item = dplist.Items.FindByValue(selectedValue);
            if (item != null)
            {
                dplist.SelectedIndex = -1;
                item.Selected = true;
            }
        }
    }
    private void CreateList(DropDownList dplist, DataTable dataTable, string iPID, int level, string leftside)
    {
        DataView dv = new DataView(dataTable);
        dv.RowFilter = "PARENT_ID ='" + iPID + "'";
        for (int i = 0; i < dv.Count; i++)
        {
            DataRowView row = dv[i];
            //菜单前缀
            string prefix = "";
            //当前项目的菜单路径
            string currentleftside = "";
            //子项目的菜单路径
            string childleftside = "";
            if (i < dv.Count - 1)
            {
                prefix = "├";
                childleftside = leftside + "│";
            }
            else
            {
                if (iPID != "0")
                {
                    prefix = "└";
                    childleftside = leftside + "　";
                }
            }
            currentleftside = leftside + prefix;
            ListItem item = new ListItem();
            item.Text = HttpUtility.HtmlDecode(currentleftside + Convert.ToString(row["DEPARTMENT_NAME"]));
            item.Value = Convert.ToString(row["DEPARTMENT_ID"]);
            dplist.Items.Add(item);
            //递归创建子项目
            CreateList(dplist, dataTable, Convert.ToString(row["DEPARTMENT_ID"]), level + 1, childleftside);
        }
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Hostname = HttpContext.Current.Request.UserHostName;
        string Ip = HttpContext.Current.Request.UserHostAddress;
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        if (!CheckNull())
        {
            return;
        }
        if (txtPwd.Text.Trim() != txtRePwd.Text.Trim())
        {
            nPrompt("两次输入的密码不一致,请重新输入!", 0);
            txtPwd.Text = "";
            txtRePwd.Text = "";
            return;
        }
        where.FULL_NAME = txtFullName.Text.Trim();
        where.IS_DISABLE = "0";
        where.LOGIN_NAME = txtLoginName.Text.Trim();
        where.MOBILE = txtMobile.Text.Trim();
        where.PHONE = txtPhone.Text.Trim();
        where.DUTY_INFO = txtDutyInfo.Text.Trim();
        where.PUBLIC_NAME = txtPublicName.Text.Trim();
        where.E_MAILE = txtEMaile.Text.Trim();
        where.REMARK = txtRemark.Text.Trim();
        where.SORT_NUMBER = decimal.Parse(txtSort.Text.Trim());
        where.DEPARTMENT_ID = decimal.Parse(ddlDept_List.SelectedValue);
        int result = 0;
        if (string.IsNullOrEmpty(uId))
        {
            where.LOGIN_PWD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwd.Text.Trim(), "MD5").ToUpper();
            result = ubll.Add(where, Hostname, Ip, CurrentAccount.USER_ID);
        }
        else
        {
            where.USER_ID = decimal.Parse(uId);
            result = ubll.Update(where, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        }
        if (result==1)
        {
            nPrompt("保存成功!", 1);
        }
            else if(result==-1)
        {
            nPrompt("已存在此用户登录名!", 1);
        }
        else
        {
            nPrompt("保存失败!", 1);
        }
    }

    public bool CheckNull()
    {
        bool chkResult = true;
        if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
        {
            nPrompt("姓名不能为空!", 0);
            chkResult= false;
        }
        if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
        {
            nPrompt("登录帐号不能为空!", 0);
            chkResult = false; ;
        }
        if (string.IsNullOrEmpty(txtMobile.Text.Trim()))
        {
            nPrompt("手机号码不能为空!", 0);
            chkResult = false;
        }
        else
        {
            if (!AidHelp.IsMobile(txtMobile.Text.Trim()))
            {
                nPrompt("手机号码格式有误!", 0);
                chkResult = false;
            }
        }
        if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
        {
            nPrompt("电话号码不能为空!", 0);
            chkResult = false;
        }
        if (string.IsNullOrEmpty(uId))
        {
            if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                nPrompt("密码不能为空!", 0);
                chkResult = false;
            }
            if (string.IsNullOrEmpty(txtRePwd.Text.Trim()))
            {
                nPrompt("确认密码不能为空!", 0);
                chkResult = false;
            }
        }
        if (string.IsNullOrEmpty(txtSort.Text.Trim()))
        {
            nPrompt("用户排序不能为空!", 0);
            chkResult = false;
        }
        else
        {
            if (!AidHelp.IsDecimal(txtSort.Text.Trim()))
            {
                nPrompt("输入的序号有误!", 0);
                chkResult = false;
            }
        }
        return chkResult;
    }
    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
            return;
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
            return;
        }
    }

    public void BindData()
    {
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        where = ubll.GetUserInfo(Decimal.Parse(uId));
        txtFullName.Text = where.FULL_NAME;
        txtLoginName.Text = where.LOGIN_NAME;
        txtMobile.Text = where.MOBILE;
        txtPhone.Text = where.PHONE;
        txtDutyInfo.Text = where.DUTY_INFO;
        txtPublicName.Text = where.PUBLIC_NAME;
        txtEMaile.Text = where.E_MAILE;
        txtRemark.Text = where.REMARK;
        txtSort.Text = where.SORT_NUMBER.ToString();
        tr_Pwd.Visible = false;
        tr_rePwd.Visible = false;
        if (where.DEPARTMENT_ID != null)
            ddlDept_List.SelectedValue = where.DEPARTMENT_ID.ToString();
    }
}