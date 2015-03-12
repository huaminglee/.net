using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControls_ucPurview : System.Web.UI.UserControl
{
    PDTech.OA.BLL.RIGHT_INFO bll = new PDTech.OA.BLL.RIGHT_INFO();
    string rId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["rId"] != null)
        {
            rId = Request.QueryString["rId"].ToString();
        }
        if (Request.QueryString["rId"] != null && !AidHelp.IsDecimal(Request.QueryString["rId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        if (!IsPostBack)
        {
            DataTable dt = bll.get_RightInfoTab(new PDTech.OA.Model.RIGHT_INFO() { });
            if (dt.Rows.Count > 0)
                Bind_Tv(dt, this.Tree_Purview.Nodes, "0", "RIGHT_ID", "PARENT_ID", "RIGHT_NAME");
            else
                lblMark.Text = "暂无权限列表信息";
            if (!string.IsNullOrEmpty(rId))
                BindData();
        }
    }
    /// <summary>
    /// 绑定树节点
    /// </summary>
    /// <param name="tnc">节点集合</param>
    /// <param name="pid_val">初始ParentID</param>
    /// <param name="id">当前ID</param>
    /// <param name="pid">ParentID</param>
    /// <param name="text">显示text</param>
    private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
    {
        DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
        TreeNode tn;
        string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
        dv.RowFilter = filter;
        foreach (DataRowView drv in dv)
        {
            tn = new TreeNode();
            tn.Value = drv[id].ToString();
            tn.Text = drv[text].ToString();
            tnc.Add(tn);
            Bind_Tv(dt, tn.ChildNodes, tn.Value, id, pid, text);//递归
        }
    }
    /// <summary>
    /// 选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Tree_Purview_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.Tree_Purview.SelectedNodeStyle.ForeColor = System.Drawing.Color.Orange;
        lblParent_Name.Text = Tree_Purview.SelectedNode.Text;
    }
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.RIGHT_INFO where = new PDTech.OA.Model.RIGHT_INFO();
        if (!ChkNull())
        {
            return;
        }
        if (!string.IsNullOrEmpty(Tree_Purview.SelectedValue))
        {
            where.PARENT_ID = decimal.Parse(Tree_Purview.SelectedValue);
        }
        else
        {
            where.PARENT_ID = 0;
        }
        where.RIGHT_CODE = txtRIGHT_CODE.Text.Trim();
        where.RIGHT_DESC = txtRIGHT_DESC.Text.Trim();
        where.RIGHT_NAME = txtRIGHT_NAME.Text.Trim();
        where.SORT_NUM = decimal.Parse(txtSORT_NUM.Text.Trim());
        int result = 0;
        if (string.IsNullOrEmpty(rId))
        { result = bll.Add(where,CurrentAccount.ClientHostName,CurrentAccount.ClientIP,CurrentAccount.USER_ID); }
        else
        {
            where.RIGHT_ID = decimal.Parse(rId);
            result = bll.Update(where, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        }
        if (result==1)
        {
            nPrompt("保存成功!", 1);
        }
        else if(result==-2)
        {
            nPrompt("已存在此编码值!", 0);
        }
        else
        {
            nPrompt("保存失败!", 0);
        }
    }
    /// <summary>
    /// 检测是否为空
    /// </summary>
    public bool ChkNull()
    {
        bool boolResult = true;
        if (string.IsNullOrEmpty(txtRIGHT_NAME.Text.Trim()))
        {
            nPrompt("权限名称不能为空", 0);
            boolResult = false;
        }
        if (string.IsNullOrEmpty(txtRIGHT_CODE.Text.Trim()))
        {
            nPrompt("权限编码不能为空", 0);
            boolResult = false;
        }
        if (string.IsNullOrEmpty(txtSORT_NUM.Text.Trim()))
        {
            nPrompt("权限排序不能为空", 0);
            boolResult = false;
        }
        return boolResult;
    }
    /// <summary>
    /// 提示
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="flag"></param>
    public void nPrompt(string msg, int flag)
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
        PDTech.OA.Model.RIGHT_INFO where = new PDTech.OA.Model.RIGHT_INFO();
        where = bll.GetRightInfo(Decimal.Parse(rId));
        lblParent_Name.Text = where.PARENT_NAME;
        txtRIGHT_CODE.Text = where.RIGHT_CODE;
        txtRIGHT_CODE.Enabled = false;
        txtRIGHT_DESC.Text = where.RIGHT_DESC;
        txtRIGHT_NAME.Text = where.RIGHT_NAME;
        txtSORT_NUM.Text = where.SORT_NUM.ToString();
    }
}