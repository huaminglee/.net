using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Archive_newSupInfo : System.Web.UI.Page
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
    int contentTask_Id;
    decimal next_step;
    public string t_rand = "";
    public string arId = "";
    string ARCHIVE_TYPE = "";
    PDTech.OA.Model.OA_ARCHIVE Arwhere = null;//当前公文
    PDTech.OA.Model.OA_ARCHIVE_TASK tWhere;//当前任务
    const string Symol = "/images/nextIcon.png";
    /// <summary>
    /// 督办工作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["tId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["tId"].ToString()))
                contentTask_Id = int.Parse(Request.QueryString["tId"].ToString());
        }
        if (Request.QueryString["arId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["arId"].ToString()))
                arId = Request.QueryString["arId"].ToString();
        }
        if (Request.QueryString["type"] != null)
        {
            ARCHIVE_TYPE = Request.QueryString["type"].ToString();
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "处理单";//设置标题
        }
        if (!IsPostBack)
        {
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveSzyd), dplSzyd);
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveUrgency), dplUrgency);
            List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(decimal.Parse(ARCHIVE_TYPE));///本流程所有步骤
            List<PDTech.OA.Model.WORKFLOW_STEP> vNextList = new List<PDTech.OA.Model.WORKFLOW_STEP>();///下一步可操作步骤集合
            PDTech.OA.Model.WORKFLOW_STEP start_step;///起始步骤
            if (!string.IsNullOrEmpty(contentTask_Id.ToString()) && contentTask_Id != 0)//办理公文任务
            {
                tWhere = tbll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = contentTask_Id });
                /***风险防控--开始***/
                DataTable dt = rpi_bll.GetRiskPointInfo("OA_WORKFLOW_STEP", tWhere.CURRENT_STEP_ID.ToString());//查询风险防控
                if (dt != null && dt.Rows.Count > 0)
                {
                    //配置提示信息
                    tipInfo.Attributes.Add("title", "风险等级：" + dt.Rows[0]["level_name"] + "\n风险点：" + dt.Rows[0]["risk_point"] + "\n防范措施：" + dt.Rows[0]["risk_resolve"] + "");
                    //配置提示样式
                    switch (dt.Rows[0]["level_name"].ToString())
                    {
                        case "一级":
                            tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                            break;
                        case "二级":
                            tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                            break;
                        case "三级":
                            tipInfo.InnerHtml = "<b class='text-danger pull-right' style='font-size: 20px; margin-right:3%;'><span class='glyphicon glyphicon-star'></span></b>";
                            break;
                    }
                }
                else
                {
                    tipInfo.Visible = false;//隐藏提示图标
                }
                /***风险防控--结束***/
                Arwhere = ArchiveBll.GetArchiveInfo(tWhere.ARCHIVE_ID.Value);
                start_step = vStepList.Where(s => s.STEP_ID == tWhere.CURRENT_STEP_ID).FirstOrDefault();
                onBindData();
                if (btnSubmit.Visible && !string.IsNullOrEmpty(start_step.IS_ALLOW_REVERT) && start_step.IS_ALLOW_REVERT == "1"
                     && !(tWhere.TASK_TYPE.HasValue && tWhere.TASK_TYPE.Value == 1)) ///显示退回按钮
                {
                    btnRevert.Visible = true;
                }
            }
            else //新增公文
            {
                start_step = vStepList.Where(s => s.START_FLAG != null && s.START_FLAG == "1").FirstOrDefault();
                this.btnCc.Visible = false;
                btnProcess.Visible = false;
                btnSave.Visible = false;
                tipInfo.Visible = false;//隐藏提示图标
            }
            ViewState["CuurStemp_State"] = start_step.IS_RETURN_TO_RESPONSE_USER;
            ViewState["End_Flag"] = start_step.END_FLAG;
            Archive_Base.GetAvailableSteps(Arwhere, vStepList, vNextList, start_step.STEP_ID.Value);//获取下一步列表
            BindDplSkipList(vNextList);//绑定下一步可操作的列表
            if ((ViewState["End_Flag"] == null || ViewState["End_Flag"].ToString() != "1") && contentTask_Id > 0 && ViewState["tType"].ToString() == "0" && (ViewState["CuurStemp_State"] == null || ViewState["CuurStemp_State"].ToString() == "0" || string.IsNullOrEmpty(ViewState["CuurStemp_State"].ToString())))
            {
                btnSubmit.Text = "办理";
            }
        }
    }



    /// <summary>
    /// 绑定界面显示下一步列表
    /// </summary>
    /// <param name="p_steps"></param>
    private void BindDplSkipList(List<PDTech.OA.Model.WORKFLOW_STEP> p_steps)
    {
        foreach (var items in p_steps)
        {
            ListItem item = new ListItem();
            item.Text = items.STEP_NAME;
            item.Value = items.STEP_ID.ToString();
            this.dplSkipList.Items.Add(item);
        }
    }


    /// <summary>
    /// 非新增绑定数据
    /// </summary>
    public void onBindData()
    {
        PDTech.OA.Model.OA_ARCHIVE Arwhere = new PDTech.OA.Model.OA_ARCHIVE();
        PDTech.OA.Model.OA_ARCHIVE_TASK tWhere = tbll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = contentTask_Id });
        #region 获取扩展属性并绑定
        if (tWhere != null)
        {
            Arwhere = ArchiveBll.GetArchiveInfo((decimal)tWhere.ARCHIVE_ID);
            arId = tWhere.ARCHIVE_ID.ToString();

            #region 获取和遍历扩展属性
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
            if (attList.Count > 0)
            {
                foreach (var item in attList)
                {
                    switch (item.KEY)
                    {
                        case "SENDUNIT":
                            txtSendUnit.Value = item.VALUE;
                            break;
                        case "RecNum":
                            txtRecNum.Text = item.VALUE;
                            break;


                        case "Curcandelf":
                            hidAttachmentIds.Value = item.VALUE;
                            break;
                    }
                }
            }
            txtDispath.Text = Arwhere.ARCHIVE_NO;
            txtRemark.Text = Arwhere.ARCHIVE_CONTENT;
            txtTitle.Text = Arwhere.ARCHIVE_TITLE;
            ViewState["const_logId"] = Arwhere.ATTRIBUTE_LOG;
            ViewState["Creator"] = Arwhere.CREATOR;
            if (tWhere.TASK_TYPE == 1)
            {
                dplSkipList.Visible = false;
                btnSave.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>hideAtt();</script>");
            }
            ViewState["tType"] = tWhere.TASK_TYPE;
            pdtInComingDate.Text = (Arwhere.RECEIVE_TIME ?? Arwhere.CREATE_TIME).Value.ToString("yyyy-MM-dd");
            if (Arwhere.IS_SHOW_IN_SZYD == "1")
            { dplSzyd.SelectedValue = "1"; }
            else
            {
                dplSzyd.SelectedValue = "0";
            }
            if (tWhere.TASK_STATE == 1)
            {
                btnSubmit.Visible = false;
                btnSave.Visible = false;
            }
            hidArStatus.Value = Arwhere.CURRENT_STATE.ToString();
            hidTaskStatus.Value = tWhere.TASK_STATE.ToString();
            dplUrgency.SelectedValue = Arwhere.PRI_LEVEL.ToString();
            #endregion

            #region 获取该公文的附件

            PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
            where.REF_TYPE = "OA_ARCHIVE";
            where.REF_ID = (decimal)tWhere.ARCHIVE_ID;
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


            ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(decimal.Parse(arId));
           
        }
        #endregion
    }


    /// <summary>
    /// 提交公文 包括（公文新增、公文办理、公文抄送）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Visible)
            {
                btnSave_Click(null, null);
            }
            if (!string.IsNullOrEmpty(dplSkipList.SelectedValue))
                next_step = decimal.Parse(dplSkipList.SelectedValue);
            #region 新增公文
            if (string.IsNullOrEmpty(contentTask_Id.ToString()) || contentTask_Id == 0)
            {
                string fjIds = "";
                IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
                PDTech.OA.Model.OA_ARCHIVE Archive = new PDTech.OA.Model.OA_ARCHIVE();
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写来文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
                Archive.ARCHIVE_NO = txtDispath.Text.Trim();
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = decimal.Parse(ARCHIVE_TYPE);
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
                Archive.IS_SHOW_IN_SZYD = dplSzyd.SelectedValue;
                if (string.IsNullOrEmpty(pdtInComingDate.Text.Trim()))
                {
                    Archive.RECEIVE_TIME = DateTime.Now;
                }
                else
                {
                    Archive.RECEIVE_TIME = new ConvertHelper(pdtInComingDate.Text.Trim()).ToDateTime;
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }
                if (!string.IsNullOrEmpty(txtSendUnit.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "SENDUNIT", VALUE = txtSendUnit.Value.Trim() });
                }
                if (!string.IsNullOrEmpty(txtRecNum.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "RecNum", VALUE = new ConvertHelper(txtRecNum.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "Curcandelf", VALUE = new ConvertHelper(hidAttachmentIds.Value.Trim()).String });
                }

                bool result = ArchiveBll.Add(Archive, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, fjIds, attList, out Archive_Id, out Task_Id);
                if (result && (ViewState["CuurStemp_State"] == null || ViewState["CuurStemp_State"].ToString() == "0" || string.IsNullOrEmpty(ViewState["CuurStemp_State"].ToString())))
                {
                    contentTask_Id = (int)Task_Id;

                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
                }
                if (result && ViewState["CuurStemp_State"].ToString() == "1")
                {
                    contentTask_Id = (int)Task_Id;
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='Is_ResponseUser.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
                }
                else
                {
                    nPrompt("提交失败!", 0);
                }
            }
            else if (ViewState["End_Flag"] != null && ViewState["End_Flag"].ToString() == "1")
            {
                PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
                where.P_TASK_ID = contentTask_Id;
                int result = taskBll.ArchiveHandle(where);
                if (result == 1)
                {
                    nPrompt("提交成功!", 2);
                }
                else
                {
                    nPrompt("提交失败!", 0);
                }
            }
            else if (contentTask_Id > 0 && ViewState["tType"].ToString() == "0" && (ViewState["CuurStemp_State"] == null || ViewState["CuurStemp_State"].ToString() == "0" || string.IsNullOrEmpty(ViewState["CuurStemp_State"].ToString())))
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
            }
            else if (contentTask_Id > 0 && ViewState["tType"].ToString() == "0" && ViewState["CuurStemp_State"].ToString() == "1")
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='Is_ResponseUser.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
            }
            else if (contentTask_Id > 0 && ViewState["tType"].ToString() == "1")
            {
                PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
                where.P_TASK_ID = contentTask_Id;
                int result = taskBll.ArchiveHandle(where);
                if (result == 1)
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

    /// <summary>
    /// 公文退回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevert_Click(object sender, EventArgs e)
    {
        try
        {
            if (contentTask_Id > 0)
            {
                PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle() { P_TASK_ID = contentTask_Id };
                int result = taskBll.ArchiveRevert(where);
                if (result == 1)
                {
                    nPrompt("退回成功!", 2);
                }
                else
                {
                    nPrompt("退回失败!", 0);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// 抄送公文
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCc_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "&action=copy'</script>");
    }
    /// <summary>
    /// 保存修改公文信息
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
            if (!string.IsNullOrEmpty(arId.ToString()) && int.Parse(arId) != 0)
            {
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写公文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
                Archive.ARCHIVE_NO = txtDispath.Text.Trim();
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = decimal.Parse(ARCHIVE_TYPE);
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
                Archive.IS_SHOW_IN_SZYD = dplSzyd.SelectedValue;
                Archive.ARCHIVE_ID = int.Parse(arId);
                if (ViewState["const_logId"] != null)
                {
                    Archive.ATTRIBUTE_LOG = decimal.Parse(ViewState["const_logId"].ToString());
                }
                if (string.IsNullOrEmpty(pdtInComingDate.Text.Trim()))
                {
                    Archive.RECEIVE_TIME = DateTime.Now;
                }
                else
                {
                    Archive.RECEIVE_TIME = new ConvertHelper(pdtInComingDate.Text.Trim()).ToDateTime;
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }
                if (!string.IsNullOrEmpty(txtSendUnit.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "SENDUNIT", VALUE = txtSendUnit.Value.Trim() });
                }
                if (!string.IsNullOrEmpty(txtRecNum.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "RecNum", VALUE = new ConvertHelper(txtRecNum.Text.Trim()).String });
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
    protected void btnImport_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 刷新重新获取附件列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
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
            if (!string.IsNullOrEmpty(arId.ToString()) && int.Parse(arId) != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_ARCHIVE')", arId);
            if (!string.IsNullOrEmpty(arId.ToString()) && int.Parse(arId) != 0 && string.IsNullOrEmpty(where.Append))
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
        if (!string.IsNullOrEmpty(arId) && !string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            fBll.UpdatePID(HidIds, decimal.Parse(arId), "OA_ARCHIVE", "");
        }
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
                if (ViewState["Creator"] != null && contentTask_Id != 0)
                {
                    if (ViewState["Creator"].ToString() == CurrentAccount.USER_ID.ToString())
                        fBll.Delete(atId);
                    else
                        nPrompt("您没有权限删除此附件!", 0);
                }
                else if (contentTask_Id == 0)
                {
                    fBll.Delete(atId);
                }
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
}