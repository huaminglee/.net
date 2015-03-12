using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Archive_NewUnitDoc : System.Web.UI.Page
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
    const decimal ARCHIVE_TYPE = 12;
    int contentTask_Id;
    decimal next_step;
    public string t_rand = "";
    public string arId = "";
    PDTech.OA.Model.OA_ARCHIVE Arwhere = null;//当前公文
    PDTech.OA.Model.OA_ARCHIVE_TASK tWhere;//当前任务
    const string Symol = "/images/nextIcon.png";
    /// <summary>
    /// 单位发文
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
        if (!IsPostBack)
        {
            title.InnerText = "成都市水务局" + S_App.ShowTitle(ARCHIVE_TYPE.ToString()) + "处理单";//设置标题
            PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
            IList<PDTech.OA.Model.DEPARTMENT> dLIst = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { Append = "DEPARTMENT_ID<>1" });
            foreach (var item in dLIst)
            {
                ListItem ditem = new ListItem();
                ditem.Value = item.DEPARTMENT_ID.ToString();
                ditem.Text = item.DEPARTMENT_NAME;
                dplDeptList.Items.Add(ditem);
            }
            dplDeptList.SelectedValue = CurrentAccount.DEPARTMENT_ID.ToString();
            txtUserName.Value = CurrentAccount.FULL_NAME;
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveUrgency), dplUrgency);
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveIsSecret), dplIsSecret);
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveSzyd), dplSzyd);
            List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(ARCHIVE_TYPE);///本流程所有步骤
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
                ShowOpList.Visible = false;
                txtDispath.Text = "成水务";
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
                        case "ArCreateUser":
                            txtUserName.Value = item.VALUE;
                            break;
                        case "ArIsNet":
                            txtIs_net.Text = item.VALUE;
                            break;
                        case "ArIsSpe":
                            txtIs_Spe.Value = item.VALUE;
                            break;
                        case "ArPrintNum":
                            txtPrintNum.Text = item.VALUE;
                            break;
                        case "ArProo":
                            txtProo.Value = item.VALUE;
                            break;
                        case "ArReview":
                            txtReview.Text = item.VALUE;
                            break;
                        case "ArCopies":
                            txtCopies.Value = item.VALUE;
                            break;
                        case "ArLordsent":
                            txtLordsent.Text = item.VALUE;
                            break;
                        case "ArCc":
                            txtCc.Text = item.VALUE;
                            break;
                        case "uDeptValue":
                            dplDeptList.SelectedValue = item.VALUE;
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
            dplIsSecret.SelectedValue = Arwhere.IS_SECRET.ToString();

            ViewState["const_logId"] = Arwhere.ATTRIBUTE_LOG;
            ViewState["Creator"] = Arwhere.CREATOR;
            if (tWhere.TASK_TYPE == 1)
            {
                dplSkipList.Visible = false;
                btnSave.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>hideAtt();</script>");
            }
            ViewState["tType"] = tWhere.TASK_TYPE;
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
    /// 附件文本Doc扫描读入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 单位发文抄送
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCc_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "&action=copy'</script>");
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
            if (!string.IsNullOrEmpty(arId.ToString()) && int.Parse(arId) != 0)
            {
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写公文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
                Archive.ARCHIVE_NO = txtDispath.Text;
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.IS_SECRET = decimal.Parse(dplIsSecret.SelectedValue);
                Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
                Archive.IS_SHOW_IN_SZYD = dplSzyd.SelectedValue;
                Archive.ARCHIVE_ID = int.Parse(arId);
                if (ViewState["const_logId"] != null)
                {
                    Archive.ATTRIBUTE_LOG = decimal.Parse(ViewState["const_logId"].ToString());
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }
                if (!string.IsNullOrEmpty(txtUserName.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCreateUser", VALUE = new ConvertHelper(txtUserName.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtIs_net.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArIsNet", VALUE = new ConvertHelper(txtIs_net.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtIs_Spe.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArIsSpe", VALUE = new ConvertHelper(txtIs_Spe.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtPrintNum.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArPrintNum", VALUE = new ConvertHelper(txtPrintNum.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtProo.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArProo", VALUE = new ConvertHelper(txtProo.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtReview.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArReview", VALUE = new ConvertHelper(txtReview.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtCopies.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCopies", VALUE = new ConvertHelper(txtCopies.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtLordsent.Text))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArLordsent", VALUE = new ConvertHelper(txtLordsent.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtCc.Text))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCc", VALUE = new ConvertHelper(txtCc.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "Curcandelf", VALUE = new ConvertHelper(hidAttachmentIds.Value.Trim()).String });
                }
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "uDeptValue", VALUE = new ConvertHelper(dplDeptList.SelectedValue).String });
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "uDeptName", VALUE = new ConvertHelper(dplDeptList.SelectedItem.Text).String });
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(dplSkipList.SelectedValue))
                next_step = decimal.Parse(dplSkipList.SelectedValue);
            if (btnSave.Visible)
            {
                btnSave_Click(null, null);
            }
            #region 新增公文
            if (string.IsNullOrEmpty(contentTask_Id.ToString()) || contentTask_Id == 0)
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
                Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
                Archive.ARCHIVE_NO = txtDispath.Text.Trim();
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.IS_SECRET = decimal.Parse(dplIsSecret.SelectedValue);
                Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
                Archive.IS_SHOW_IN_SZYD = dplSzyd.SelectedValue;
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }
                if (!string.IsNullOrEmpty(txtUserName.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCreateUser", VALUE = new ConvertHelper(txtUserName.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtIs_net.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArIsNet", VALUE = new ConvertHelper(txtIs_net.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtIs_Spe.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArIsSpe", VALUE = new ConvertHelper(txtIs_Spe.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtPrintNum.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArPrintNum", VALUE = new ConvertHelper(txtPrintNum.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtProo.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArProo", VALUE = new ConvertHelper(txtProo.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtReview.Text.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArReview", VALUE = new ConvertHelper(txtReview.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtCopies.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCopies", VALUE = new ConvertHelper(txtCopies.Value.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtLordsent.Text))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArLordsent", VALUE = new ConvertHelper(txtLordsent.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(txtCc.Text))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "ArCc", VALUE = new ConvertHelper(txtCc.Text.Trim()).String });
                }
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "Curcandelf", VALUE = new ConvertHelper(hidAttachmentIds.Value.Trim()).String });
                }
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "uDeptValue", VALUE = new ConvertHelper(dplDeptList.SelectedValue).String });
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "uDeptName", VALUE = new ConvertHelper(dplDeptList.SelectedItem.Text).String });
                bool result = ArchiveBll.Add(Archive, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, fjIds, attList, out Archive_Id, out Task_Id);
                if (result && (ViewState["CuurStemp_State"] == null || ViewState["CuurStemp_State"].ToString() == "0" || string.IsNullOrEmpty(ViewState["CuurStemp_State"].ToString())))
                {
                    contentTask_Id = (int)Task_Id;
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
                }
                else if (result && ViewState["CuurStemp_State"].ToString() == "1")
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
                //修改为直接提交

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
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
        BindData();
    }
}