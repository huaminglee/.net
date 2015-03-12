using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_NewTiob : System.Web.UI.Page
{
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.OA_ARCHIVE ArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
    PDTech.OA.BLL.OA_ARCHIVE_TASK tbll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.WORKFLOW_STEP vStepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
    PDTech.OA.BLL.OA_ARCHIVE_TASK taskBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.RISK_POINT_INFO rpi_bll = new PDTech.OA.BLL.RISK_POINT_INFO();

    int? Archive_Id = 0;///
    int? Task_Id = 0;//作用区分接收和办理人员
    const decimal ARCHIVE_TYPE = 71;
    public string t_rand = "";
    public int arId = 0;
    PDTech.OA.Model.OA_ARCHIVE Arwhere = null;//当前公文
   
    const string Symol = "/images/nextIcon.png";
    /// <summary>
    /// 单位发文
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
       
        if (Request.QueryString["arId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["arId"].ToString()))
                arId = int.Parse( Request.QueryString["arId"].ToString());
        }
        if (!IsPostBack)
        {
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "处理单";//设置标题
            PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
            
            List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(ARCHIVE_TYPE);///本流程所有步骤
            List<PDTech.OA.Model.WORKFLOW_STEP> vNextList = new List<PDTech.OA.Model.WORKFLOW_STEP>();///下一步可操作步骤集合
            if (arId==0)
            {
                btnSave.Visible = false;
                ShowOpList.Visible = false;
                tipInfo.Visible = false;//隐藏提示图标
            }
            else
            {
                btnSubmit.Visible = false;
                onBindData();
            }
             
        }
    }
    /// <summary>
    /// 非新增绑定数据
    /// </summary>
    public void onBindData()
    {
        PDTech.OA.Model.OA_ARCHIVE Arwhere = new PDTech.OA.Model.OA_ARCHIVE();
      
        #region 获取扩展属性并绑定
            Arwhere = ArchiveBll.GetArchiveInfo((decimal)arId);
        
            #region 获取和遍历扩展属性
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
            if (attList.Count > 0)
            {
                foreach (var item in attList)
                {
                    switch (item.KEY)
                    {                       
                        case "Curcandelf":
                            hidAttachmentIds.Value = item.VALUE;
                            break;                        
                    }
                }
            }
        
            txtTitle.Text = Arwhere.ARCHIVE_TITLE;
            txtcontent.Text = Arwhere.ARCHIVE_CONTENT;
            ViewState["const_logId"] = Arwhere.ATTRIBUTE_LOG;
            ViewState["Creator"] = Arwhere.CREATOR;
            hidarchtivetype.Value=Arwhere.ARCHIVE_NO;
            hidArStatus.Value = Arwhere.CURRENT_STATE.ToString();
            
            #endregion

            #region 获取该公文的附件

            PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
            where.REF_TYPE = "OA_ARCHIVE";
            where.REF_ID = (decimal)arId;
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
            #endregion
            ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html((decimal)arId);
        
        #endregion
    }

    /// <summary>
    /// 附件文本Doc扫描读入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {

    }
   
    /// <summary>
    /// 保存修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string fjIds = "";
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            PDTech.OA.Model.OA_ARCHIVE Archive = new PDTech.OA.Model.OA_ARCHIVE();
            if ( arId != 0)
            {
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写公文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtcontent.Text.Trim();
                
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                if (!String.IsNullOrEmpty(hidarchtivetype.Value))
                {                   
                    Archive.ARCHIVE_NO = hidarchtivetype.Value;
                }
              
                Archive.ARCHIVE_ID = arId;
                if (ViewState["const_logId"] != null)
                {
                    Archive.ATTRIBUTE_LOG = decimal.Parse(ViewState["const_logId"].ToString());
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }             
              
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "Curcandelf", VALUE = new ConvertHelper(hidAttachmentIds.Value.Trim()).String });
                }
                
                bool result = ArchiveBll.Update(Archive, fjIds, attList);
                if (result)
                {
                    if (sender == null)//提交调用保存时，成功不提示，直接跳转页面
                    {
                        return;
                    }
                    nPrompt("保存成功!", 1);
                }
                else
                {
                    nPrompt("保存失败!", 0);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void rpt_AttachmentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DelItem")
        {
            decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());
           
          
                if (ViewState["Creator"] != null)
                {
                    if (ViewState["Creator"].ToString() == CurrentAccount.USER_ID.ToString())
                        fBll.Delete(atId);
                    else
                        nPrompt("您没有权限删除此附件!", 0);
                }
                else if (arId == 0)
                {
                    fBll.Delete(atId);
                }
            
        }
        BindData();
    }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {           
            if (btnSave.Visible)
            {
                btnSave_Click(null, null);
            }
            #region 新增公文
            if (arId==0)
            {
                string fjIds = "";
                IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
                PDTech.OA.Model.OA_ARCHIVE Archive = new PDTech.OA.Model.OA_ARCHIVE();
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写单位发文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtcontent.Text.Trim();
                 
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.ARCHIVE_TYPE_NAME = "三重一大";
                if (!String.IsNullOrEmpty(hidarchtivetype.Value))
                {
                    Archive.ARCHIVE_NO = hidarchtivetype.Value;
                }
              
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }             
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "Curcandelf", VALUE = new ConvertHelper(hidAttachmentIds.Value.Trim()).String });
                }
               
                bool result = ArchiveBll.Add(Archive, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, fjIds, attList, out Archive_Id, out Task_Id);
                if (result)
                {
                    nPrompt("提交成功!", 2);
                }                
                else
                {
                    nPrompt("提交失败!", 0);
                }
            }                   
            #endregion
        }
        catch (Exception ex)
        {
        }
    }


    public void nPrompt(string msg, int flag)
    {
        if (flag == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',8)</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "',1);</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
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
            if (!string.IsNullOrEmpty(arId.ToString()) && arId != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_ARCHIVE')", arId);
            if (!string.IsNullOrEmpty(arId.ToString()) && arId != 0 && string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_ARCHIVE' ", arId);
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
        if (arId!=0 && !string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            fBll.UpdatePID(HidIds, (decimal)(arId), "OA_ARCHIVE", "");
        }
    }
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
        BindData();
    }
}