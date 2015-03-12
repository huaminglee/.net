using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SysManege_Dept_DefaultPerson : System.Web.UI.Page
{
    PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
    PDTech.OA.BLL.USER_INFO uBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.DEPARTMENT_DEFAULT_USER duBll = new PDTech.OA.BLL.DEPARTMENT_DEFAULT_USER();
    string dId = "";
    public string ridio_Name = "ridio_Name";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["dId"] == null || string.IsNullOrEmpty(Request.QueryString["dId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            dId = Request.QueryString["dId"].ToString();
            if (!IsPostBack)
                BindData();
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.DEPARTMENT dwhere = dBll.GetDeptInfo(decimal.Parse(dId));
        txtDeptName.Text = dwhere.DEPARTMENT_NAME;
        IList<PDTech.OA.Model.USER_INFO> uList = uBll.get_UserInfoList(decimal.Parse(dId));
        if (uList == null || uList.Count==0)
        {
            lblMark.Text = "此部门暂无人员!";
            lblMark.ForeColor = System.Drawing.Color.OrangeRed;
            return;
        }
        rpt_PersonList.DataSource = uList;
        rpt_PersonList.DataBind();
        chkSelected();
    }

    public void chkSelected()
    {
        PDTech.OA.Model.DEPARTMENT_DEFAULT_USER duList = duBll.get_uDeptList(decimal.Parse(dId));
        if (duList!= null)
        hidUserId.Value = duList.USER_ID.ToString();
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hidUserId.Value))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('请选择部门指定接收人员!');</script>");
            return;
        }
        IList<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> dList = new List<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER>();
        PDTech.OA.Model.DEPARTMENT_DEFAULT_USER where = new PDTech.OA.Model.DEPARTMENT_DEFAULT_USER();
        where.DEPARTMENT_ID = decimal.Parse(dId);
        where.USER_ID = decimal.Parse(hidUserId.Value.ToString());
        dList.Add(where);
        int result=duBll.ExecuteSqlTran(dList);
        if (result == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存成功!');window.parent.layer.closeAll();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存失败!');</script>");
        }
    }
}