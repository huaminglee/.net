using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_SetRole_Purview : System.Web.UI.Page
{
    PDTech.OA.BLL.RIGHT_INFO bll = new PDTech.OA.BLL.RIGHT_INFO();
    PDTech.OA.BLL.ROLE_INFO rBll = new PDTech.OA.BLL.ROLE_INFO();
    PDTech.OA.BLL.ROLE_RIGHT_MAP wbll = new PDTech.OA.BLL.ROLE_RIGHT_MAP();
    string rId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否存在参数
        if (Request.QueryString["rId"] == null || string.IsNullOrEmpty(Request.QueryString["rId"].ToString()))
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('非法参数!');window.parent.layer.closeAll();</script>");
            return;
        }
        else
        {
            rId = Request.QueryString["rId"].ToString();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(rId))
                { BindData(); }
                DataTable dt = bll.get_RightInfoTab(new PDTech.OA.Model.RIGHT_INFO() { });
                if (dt.Rows.Count > 0)
                {
                    Bind_Tv(dt, this.RightTree.Nodes, "0", "RIGHT_ID", "PARENT_ID", "RIGHT_NAME");
                    lblMark.Visible = true;
                    ChkSelected();
                }

                else
                    lblMark.Text = "暂无权限列表信息";
            }
        }
    }


    public void BindData()
    {
        PDTech.OA.Model.ROLE_INFO where = new PDTech.OA.Model.ROLE_INFO();
        where = rBll.GetRoleInfo(decimal.Parse(rId));
        txtReMark.Text = where.ROLE_DESC;
        txtrName.Text = where.ROLE_NAME;

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
    /// 判断历史勾选
    /// </summary>
    public void ChkSelected()
    {
        IList<PDTech.OA.Model.ROLE_RIGHT_MAP> pList = wbll.get_rPurviewList(decimal.Parse(rId));
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
    private void GetChildTree(IList<PDTech.OA.Model.ROLE_RIGHT_MAP> pList, TreeNode node)
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

    ArrayList CheckRights = new ArrayList();
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (TreeNode no in this.RightTree.Nodes)
        {
            GetTree(no);
        }
        IList<PDTech.OA.Model.ROLE_RIGHT_MAP> rList = new List<PDTech.OA.Model.ROLE_RIGHT_MAP>();
        if (CheckRights.Count <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.parent.layer.closeAll();layer.alert('请勾选权限!',1);</script>");
            return;
        }
        foreach (var item in CheckRights)
        {
            PDTech.OA.Model.ROLE_RIGHT_MAP where = new PDTech.OA.Model.ROLE_RIGHT_MAP();
            where.ROLE_ID = decimal.Parse(rId);
            where.RIGHT_ID = decimal.Parse(item.ToString());
            rList.Add(where);
        }
        int result = 0;
        result = wbll.ExecuteSqlTran(rList, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID);
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