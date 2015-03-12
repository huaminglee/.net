using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_ArchiveSteering : System.Web.UI.Page
{
    public string t_rand = "";
    string arId = "";
    PDTech.OA.BLL.VIEW_ARCHIVE_STEMP vsBll = new PDTech.OA.BLL.VIEW_ARCHIVE_STEMP();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["arId"] != null)
        {
            arId = Request.QueryString["arId"].ToString();
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(arId))
                BindData();
        }
    }

    public void BindData()
    {
        PDTech.OA.BLL.WORKFLOW_STEP sBll = new PDTech.OA.BLL.WORKFLOW_STEP();
        PDTech.OA.Model.VIEW.VIEW_ARCHIVE_STEMP where = vsBll.get_viewarchivestepInfo(new PDTech.OA.Model.VIEW.VIEW_ARCHIVE_STEMP() { ARCHIVE_ID = decimal.Parse(arId) });
        lbType.Text = where.STEP_NAME;
        lbUser.Text = where.FULL_NAME;
        hidStemp.Value = where.CURRENT_STEP_ID.ToString();
        IList<PDTech.OA.Model.WORKFLOW_STEP> sList = sBll.get_worlflow_step(new PDTech.OA.Model.WORKFLOW_STEP() { FLOW_TEMPLATE_ID = (decimal)where.FLOW_TEMPLATE_ID });
        CreateItems(sList,1,1);
    }

    private void CreateItems(IList<PDTech.OA.Model.WORKFLOW_STEP> nList,decimal nId,int level)
    {
        ListItem item = new ListItem();
        if (level == 1)
        {
            PDTech.OA.Model.WORKFLOW_STEP nStep = nList.Where(s => s.START_FLAG != null && s.START_FLAG == "1").FirstOrDefault();
            item.Text = nStep.STEP_NAME;
            item.Value = nStep.STEP_ID.ToString();
            dplStemp.Items.Add(item);
            if (nStep.END_FLAG != "1")
            CreateItems(nList, (decimal)nStep.NEXT_STEP_ID, level + 1);
        }
        else
        {
            PDTech.OA.Model.WORKFLOW_STEP nStep = nList.Where(s => s.STEP_ID == nId).FirstOrDefault();
            item.Text = nStep.STEP_NAME;
            item.Value = nStep.STEP_ID.ToString();
            dplStemp.Items.Add(item);
            if (nStep.END_FLAG!="1")
            CreateItems(nList,(decimal) nStep.NEXT_STEP_ID, level + 1);
        }
    }
    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        PDTech.OA.BLL.OA_ARCHIVE arBll = new PDTech.OA.BLL.OA_ARCHIVE();
        try
        {
            if (string.IsNullOrEmpty(hidUserList.Value))
            {
                nPrompt("请选择接收人员!",0);
                return;
            }

           bool result=arBll.RELOCATE(CurrentAccount.USER_ID, decimal.Parse(arId), decimal.Parse(dplStemp.SelectedValue), txtRemark.Text, hidUserList.Value);
           if (result)
           {
               nPrompt("操作成功!", 2);
           }
           else
           {
               nPrompt("操作失败!", 0);
           }
        }
        catch (Exception ex)
        {
        }
    }

    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
    }

    /// <summary>
    /// 流程步骤变更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dplStemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        hidStemp.Value = dplStemp.SelectedValue;
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>onRefresh();</script>");
    }
}