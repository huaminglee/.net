using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_SetUser_Purview : System.Web.UI.Page
{
    PDTech.OA.BLL.RIGHT_INFO purviewBll = new PDTech.OA.BLL.RIGHT_INFO();
    PDTech.OA.BLL.ROLE_INFO roleBll = new PDTech.OA.BLL.ROLE_INFO();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.USER_RIGHT_MAP user_p_Bll = new PDTech.OA.BLL.USER_RIGHT_MAP();
    PDTech.OA.BLL.USER_ROLE_MAP user_r_Bll = new PDTech.OA.BLL.USER_ROLE_MAP();
    string uId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否存在参数
        if (Request.QueryString["uId"] == null || string.IsNullOrEmpty(Request.QueryString["uId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            uId = Request.QueryString["uId"].ToString();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(uId))
                { BindData(); }
                DataTable dt = purviewBll.get_RightInfoTab(new PDTech.OA.Model.RIGHT_INFO() { });
                if (dt.Rows.Count > 0)
                {
                    Bind_Tv(dt, this.RightTree.Nodes, "0", "RIGHT_ID", "PARENT_ID", "RIGHT_NAME");
                    lblMark.Visible = true;
                }

                else
                { lblMark.Text = "暂无权限列表信息"; }
                ChkSelected();
            }
        }
    }

    /// <summary>
    /// 获取并绑定用户信息
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.USER_INFO where = new PDTech.OA.Model.USER_INFO();
        where = userBll.GetUserInfo(decimal.Parse(uId));
        txtrName.Text = where.LOGIN_NAME;
        IList<PDTech.OA.Model.ROLE_INFO> rList = roleBll.get_RoleList(new PDTech.OA.Model.ROLE_INFO() { });
        rpt_RolrList.DataSource = rList;
        rpt_RolrList.DataBind();
    }

    /// <summary>
    /// 判断历史勾选
    /// </summary>
    public void ChkSelected()
    {
        IList<PDTech.OA.Model.USER_RIGHT_MAP> pList = user_p_Bll.get_uPurviewList(new PDTech.OA.Model.USER_RIGHT_MAP() { USER_ID = decimal.Parse(uId) });
        IList<PDTech.OA.Model.USER_ROLE_MAP> rList = user_r_Bll.get_uRoleList(decimal.Parse(uId));
        foreach (var ritem in rList)
        {
            foreach (RepeaterItem item in rpt_RolrList.Items)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chk = (System.Web.UI.HtmlControls.HtmlInputCheckBox)item.FindControl("chk_Id");
                if (chk.Value == ritem.ROLE_ID.ToString())
                    chk.Checked = true;
            }
        }
        foreach (var pitem in pList)
        {
            foreach (TreeNode nd in RightTree.Nodes)
            {
                if (nd.Value == pitem.RIGHT_ID.ToString())
                    nd.Checked = true;
                if (nd.ChildNodes.Count > 0)
                    GetChildTree(pList, nd);
            }
        }


    }

    /// <summary>
    /// 遍历子节点
    /// </summary>
    /// <param name="node"></param>
    private void GetChildTree(IList<PDTech.OA.Model.USER_RIGHT_MAP> pList, TreeNode node)
    {
        foreach (var item in pList)
        {
            foreach (TreeNode nd in node.ChildNodes)
            {
                if (nd.Value == item.RIGHT_ID.ToString())
                    nd.Checked = true;
                if (nd.ChildNodes.Count > 0)
                    GetChildTree(pList, nd);
            }
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


    ArrayList CheckRights = new ArrayList();
    ArrayList CheckRoles = new ArrayList();
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (TreeNode no in this.RightTree.Nodes)
        {
            GetTree(no);
        }
        if (CheckRights.Count <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('请勾选权限!',8);</script>");
            return;
        }
        foreach (RepeaterItem item in rpt_RolrList.Items)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox chk = (System.Web.UI.HtmlControls.HtmlInputCheckBox)item.FindControl("chk_Id");
            if (chk.Checked)
                CheckRoles.Add(chk.Value);
        }
        if (CheckRoles.Count <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('请勾选角色!',8);</script>");
            return;
        }
        IList<PDTech.OA.Model.USER_RIGHT_MAP> pList = new List<PDTech.OA.Model.USER_RIGHT_MAP>();
        IList<PDTech.OA.Model.USER_ROLE_MAP> rList = new List<PDTech.OA.Model.USER_ROLE_MAP>();
        foreach (var item in CheckRights)
        {
            PDTech.OA.Model.USER_RIGHT_MAP where = new PDTech.OA.Model.USER_RIGHT_MAP();
            where.USER_ID = decimal.Parse(uId);
            where.RIGHT_ID = decimal.Parse(item.ToString());
            pList.Add(where);
        }
        foreach (var item in CheckRoles)
        {
            PDTech.OA.Model.USER_ROLE_MAP where = new PDTech.OA.Model.USER_ROLE_MAP();
            where.USER_ID = decimal.Parse(uId);
            where.ROLE_ID = decimal.Parse(item.ToString());
            rList.Add(where);
        }
        int result = 0;
        result = user_p_Bll.ExecuteSqlTran(pList, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        result = user_r_Bll.ExecuteSqlTran(rList, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        if (result == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存成功!');window.parent.layer.closeAll();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存失败!');window.parent.layer.closeAll();</script>");
        }
    }


    /// <summary>
    /// 遍历第一层节点
    /// </summary>
    /// <param name="node"></param>
    private void GetTree(TreeNode node)
    {
        if (node.Checked == true)
        {
            CheckRights.Add(node.Value.ToString().Trim());
        }
        if (node.ChildNodes.Count > 0)
            GetChildTree(node);

    }
    /// <summary>
    /// 遍历子节点
    /// </summary>
    /// <param name="node"></param>
    private void GetChildTree(TreeNode node)
    {
        foreach (TreeNode nd in node.ChildNodes)
        {
            if (nd.Checked)
            {
                CheckRights.Add(nd.Value.ToString().Trim());
            }
            if (nd.ChildNodes.Count > 0)
                GetChildTree(nd);
        }
    }
}