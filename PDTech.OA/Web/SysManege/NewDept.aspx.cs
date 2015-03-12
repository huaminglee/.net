using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class NewDept : System.Web.UI.Page
{
    PDTech.OA.BLL.DEPARTMENT bll = new PDTech.OA.BLL.DEPARTMENT();
    private string parentId = "1";
    string dId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["dId"] != null)
        {
            dId = Request.QueryString["dId"].ToString();
        }
        if (Request.QueryString["dId"] != null&&!AidHelp.IsDecimal(Request.QueryString["dId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        if (!IsPostBack)
        {
            LoadDeptDropDownList(this.ddlDept_List, parentId, true);
            if (!string.IsNullOrEmpty(dId))
                BindData();
        }
    }

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strHostName = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]; //得到本机的主机名
        string ipEntry = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; //取得本机IP
        PDTech.OA.Model.DEPARTMENT where = new PDTech.OA.Model.DEPARTMENT();
        if (string.IsNullOrEmpty(txtDeptName.Text.Trim()))
        {
            nPrompt("部门名称不能为空!", 0);
            return;
        }
        if (string.IsNullOrEmpty(txtSort.Text.Trim()))
        {
            nPrompt("部门排序不能为空!", 0);
            return;
        }
        where.DEPARTMENT_NAME = txtDeptName.Text.Trim();
        if (string.IsNullOrEmpty(txtDeptName_Jc.Text.Trim()))
        {
            where.DEPARTMENT_JC = txtDeptName.Text.Trim();
        }
        else
        {
            where.DEPARTMENT_JC = txtDeptName_Jc.Text.Trim();
        }
        where.PARENT_ID =Convert.ToDecimal(ddlDept_List.SelectedValue);
        where.REMARK = txtReMark.Text.Trim();
        if (string.IsNullOrEmpty(txtSort.Text.Trim()))
        {
            where.SORT_NUM = 0;
        }
        else
        {
            where.SORT_NUM = int.Parse(txtSort.Text.Trim());
        }
        where.IS_DISABLE = "0";

        bool result =false;
        if (string.IsNullOrEmpty(dId))
        {
            result = bll.Add(where, strHostName,ipEntry,CurrentAccount.USER_ID);
        }
        else
        {
            where.DEPARTMENT_ID = decimal.Parse(dId);
            result = bll.Update(where, strHostName, ipEntry, CurrentAccount.USER_ID);
        }
        if (result)
        {
            nPrompt("保存成功!", 1);
        }
        else
        {
            nPrompt("保存失败!", 1);
        }
    }
    public void nPrompt(string msg,int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.DEPARTMENT where = new PDTech.OA.Model.DEPARTMENT();
        where = bll.GetDeptInfo(Decimal.Parse(dId));
        txtDeptName.Text = where.DEPARTMENT_NAME;
        txtDeptName_Jc.Text = where.DEPARTMENT_JC;
        txtReMark.Text = where.REMARK;
        txtSort.Text = where.SORT_NUM.ToString();
        if(where.PARENT_ID!=null)
        ddlDept_List.SelectedValue = where.PARENT_ID.ToString();
    }
}