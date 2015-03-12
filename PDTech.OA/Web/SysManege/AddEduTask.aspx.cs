using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_AddEduTask : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_RISKEDUCATION eduBLL = new PDTech.OA.BLL.OA_RISKEDUCATION();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    string[] arrayType = new string[] { "法律法规", "文件通知", "讲话精神", "影像资料", "警示案例" };

    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            BindDropDownList();
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_RISKEDUCATION model = new PDTech.OA.Model.OA_RISKEDUCATION();
        model.TITLE = txtTitle.Value;
        model.FILETYPE = ddlType.SelectedValue;
        model.COMPANY = txtSendUnit.Text;
        model.REMARK = txtRemark.Text;
        if (!String.IsNullOrEmpty(pdthopefinishtime.Text))
        {
            model.HOPEFINISHTIME = DateTime.Parse(pdthopefinishtime.Text.Trim());
        }
        else
        {
            model.HOPEFINISHTIME = DateTime.MaxValue;
        }
        model.FINISHTIME = DateTime.MaxValue;
        if (!String.IsNullOrEmpty(hidselvideo.Value))
        {
            model.REMARK += "#regionvidoe" + hidselvideo.Value;
        }
       
        model.CREATOR = CurrentAccount.USER_ID;
        string receiveUserId = hidRUserID.Value;
        string fileIds = hidAttachmentIds.Value;
        string hostIP = CurrentAccount.ClientIP;
        string hostName = CurrentAccount.ClientHostName;
        //调用添加方法的存储过程
        bool result = eduBLL.Add(model, fileIds, receiveUserId, hostIP, hostName);
        if (result)
        {
            nPrompt("新增教育任务成功!", 2);
        }
        else
        {
            nPrompt("新增教育任务失败!", 2);
        }
    }

    protected void rpt_AttachmentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DelItem")
        {
            decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());
            if (!hidAttachmentIds.Value.Contains(atId.ToString()))
            {
                nPrompt("当前状态不能删除附件!", 0);
                return;
            }
            else
            {
                fBll.Delete(atId);
            }
        }
        BindData();
    }

    /// <summary>
    /// 绑定附件
    /// </summary>
    public void BindData()
    {
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        if (!string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            if (!string.IsNullOrEmpty(HidIds))
                where.Append = string.Format(" ATTACHMENT_FILE_ID IN({0}) ", HidIds);
            //if (!string.IsNullOrEmpty(m_id.ToString()) && int.Parse(m_id) != 0 && !string.IsNullOrEmpty(where.Append))
            //    where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_MEETING')", m_id);
            //if (!string.IsNullOrEmpty(m_id.ToString()) && int.Parse(m_id) != 0 && string.IsNullOrEmpty(where.Append))
            //    where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_MEETING' ", m_id);
            IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = fBll.get_InfoList(where);
            if (aList.Count > 0)
            {
                rpt_AttachmentList.DataSource = aList;
                rpt_AttachmentList.DataBind();
                tr_showList.Visible = true;
            }
            else
            {
                tr_showList.Visible = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_AttachmentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            PDTech.OA.Model.OA_ATTACHMENT_FILE item = e.Item.DataItem as PDTech.OA.Model.OA_ATTACHMENT_FILE;
            HyperLink hlDown = e.Item.FindControl("hlDown") as HyperLink;
            if (hlDown != null)
            {
                hlDown.NavigateUrl = "/DownLoad.aspx?file=" + item.FILE_PATH + "&fullName=" + item.FILE_NAME;
            }
        }
    }

    /// <summary>
    ///  查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
        BindData();
    }

    /// <summary>
    /// 提示信息
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh(); window.parent.layer.closeAll();</script>");
        }
    }
}