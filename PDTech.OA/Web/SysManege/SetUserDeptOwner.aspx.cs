using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_SetUserDeptOwner : System.Web.UI.Page
{
    PDTech.OA.BLL.DEPARTMENT deptBll = new PDTech.OA.BLL.DEPARTMENT();
    PDTech.OA.BLL.USERS_DEPT_OWNER_MAP usersDeptOwnerBll = new PDTech.OA.BLL.USERS_DEPT_OWNER_MAP();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
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
                DataTable dt = deptBll.get_DeptTab(new PDTech.OA.Model.DEPARTMENT() { });
                if (dt.Rows.Count > 0)
                {
                    Bind_Tv(dt, this.RightTree.Nodes, "0", "DEPARTMENT_ID", "PARENT_ID", "DEPARTMENT_NAME");
                    lblMark.Visible = true;
                }
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
        txtrName.Text = where.FULL_NAME;
    }

    /// <summary>
    /// 判断历史勾选
    /// </summary>
    public void ChkSelected()
    {
        IList<PDTech.OA.Model.USERS_DEPT_OWNER_MAP> pList = usersDeptOwnerBll.GetModelList("USER_ID=" + uId);
        foreach (var pitem in pList)
        {
            foreach (TreeNode nd in RightTree.Nodes)
            {
                if (nd.Value == pitem.DEPARTMENT_ID.ToString())
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
    private void GetChildTree(IList<PDTech.OA.Model.USERS_DEPT_OWNER_MAP> pList, TreeNode node)
    {
        foreach (var item in pList)
        {
            foreach (TreeNode nd in node.ChildNodes)
            {
                if (nd.Value == item.DEPARTMENT_ID.ToString())
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


    ArrayList CheckDepts = new ArrayList();
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
        IList<PDTech.OA.Model.USERS_DEPT_OWNER_MAP> rList = new List<PDTech.OA.Model.USERS_DEPT_OWNER_MAP>();
        foreach (var item in CheckDepts)
        {
            PDTech.OA.Model.USERS_DEPT_OWNER_MAP where = new PDTech.OA.Model.USERS_DEPT_OWNER_MAP();
            where.USER_ID = int.Parse(uId);
            where.DEPARTMENT_ID = int.Parse(item.ToString());
            rList.Add(where);
        }
        int result = 0;
        result = usersDeptOwnerBll.ExecuteSqlTran(rList, uId, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
        if (result == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('保存成功!');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
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
            CheckDepts.Add(node.Value.ToString().Trim());
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
                CheckDepts.Add(nd.Value.ToString().Trim());
            }
            if (nd.ChildNodes.Count > 0)
                GetChildTree(nd);
        }
    }
}