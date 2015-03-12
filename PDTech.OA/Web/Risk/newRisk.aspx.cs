using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Risk_newRisk : System.Web.UI.Page
{
    PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
    PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
    PDTech.OA.BLL.OA_ARCHIVE ArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.OA_ARCHIVE_TASK currentTaskbll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.RISK_TYPE_INFO rBll = new PDTech.OA.BLL.RISK_TYPE_INFO();
    public string t_rand = "";
    public int ptId = 0;
    public decimal ARCHIVE_TYPE = 51;
    public decimal ptype = 0;
    public decimal arId = 0;
    public decimal contentTask_Id = 0;
    public decimal next_step = 0;
    public int p_arId = 0;

    int? Archive_Id = 0;///
    int? Task_Id = 0;//作用区分接收和办理人员
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["ptype"] != null)//获取类型参数
        {
            ptype = decimal.Parse(Request.QueryString["ptype"].ToString());
        }
        if (Request.QueryString["arId"] != null)//获取当前公文ID参数
        {
            arId = decimal.Parse(Request.QueryString["arId"].ToString());
        }
        if (Request.QueryString["tId"] != null)//获取当前任务ID参数
        {
            contentTask_Id = decimal.Parse(Request.QueryString["tId"].ToString());
        }
        if (Request.QueryString["ptId"] != null)//获取任务ID
        {
            ptId = int.Parse(Request.QueryString["ptId"].ToString());
        }
        if (Request.QueryString["p_arId"] != null)//公文ID
        {
            p_arId = int.Parse(Request.QueryString["p_arId"].ToString());
        }
        if (!IsPostBack)
        {
            InitLoad();
        }
    }


    /// <summary>
    /// 初始化页面必要信息
    /// </summary>
    public void InitLoad()
    {
        PDTech.OA.Model.OA_ARCHIVE Arwhere = null;//当前公文
        PDTech.OA.Model.OA_ARCHIVE_TASK tWhere;//当前任务
        #region 下拉框数据绑定
        CurrentAccount.BindEnumDropDownList(typeof(EArchiveRiskLevel), dplUrgency);
        IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> tList = tBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
        foreach (var item in tList)
        {
            ListItem items = new ListItem();
            if (item.ARCHIVE_TYPE != 51)
            {
                items.Value = item.ARCHIVE_TYPE.ToString();
                items.Text = item.TYPE_NAME;
                dplBusinessType.Items.Add(items);
            }

        }
        ListItem item_default = new ListItem();
        item_default.Value = "";
        item_default.Text = "---请选择---";
        dplBusinessType.Items.Insert(0, item_default);
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { });
        foreach (var item in dList)
        {
            ListItem ditem = new ListItem();
            ditem.Value = item.DEPARTMENT_ID.ToString();
            ditem.Text = item.DEPARTMENT_NAME;
            dplDeptList.Items.Add(ditem);
        }
        ListItem item_d = new ListItem();
        item_d.Value = "";
        item_d.Text = "---请选择---";
        dplDeptList.Items.Insert(0, item_d);

        IList<PDTech.OA.Model.RISK_TYPE_INFO> rList = rBll.get_risktypeList(new PDTech.OA.Model.RISK_TYPE_INFO() { });
        foreach (var itemr in rList)
        {
            if (itemr.RISK_TYPE_NAME == "监督督查")
            {
                if (CurrentAccount.ISHavePurview("leader"))
                {
                    ListItem ditem = new ListItem();
                    ditem.Value = itemr.RISK_TYPE_NAME;
                    ditem.Text = itemr.RISK_TYPE_NAME;
                    dplRiskList.Items.Add(ditem);
                }
            }
            else
            {
                ListItem ditem = new ListItem();
                ditem.Value = itemr.RISK_TYPE_NAME;
                ditem.Text = itemr.RISK_TYPE_NAME;
                dplRiskList.Items.Add(ditem);

            }
        }
        ListItem item_r = new ListItem();
        item_r.Value = "";
        item_r.Text = "---请选择---";
        dplRiskList.Items.Insert(0, item_r);
        dplRiskList.SelectedValue = "超期风险";
        PDTech.OA.BLL.WORKFLOW_STEP vStepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
        List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(ARCHIVE_TYPE);///本流程所有步骤
        List<PDTech.OA.Model.WORKFLOW_STEP> vNextList = new List<PDTech.OA.Model.WORKFLOW_STEP>();///下一步可操作步骤集合
        PDTech.OA.Model.WORKFLOW_STEP start_step;///起始步骤
        if (contentTask_Id != 0)//办理公文任务
        {
            tWhere = currentTaskbll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = contentTask_Id });
            Arwhere = ArchiveBll.GetArchiveInfo(tWhere.ARCHIVE_ID.Value);
            start_step = vStepList.Where(s => s.STEP_ID == tWhere.CURRENT_STEP_ID).FirstOrDefault();
            //onBindData();
            firstRisk.Visible = false;
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
            editrisk.Visible = false;
        }
        ViewState["End_Flag"] = start_step.END_FLAG;
        Archive_Base.GetAvailableSteps(Arwhere, vStepList, vNextList, start_step.STEP_ID.Value);//获取下一步列表
        BindDplSkipList(vNextList);//绑定下一步可操作的列表

        int Seq = dBll.getSEQ();
        switch (Seq.ToString().Length.ToString())
        {
            case "1":
                txtSeqNum.Value = "000" + Seq.ToString();
                break;
            case "2":
                txtSeqNum.Value = "00" + Seq.ToString();
                break;
            case "3":
                txtSeqNum.Value = "0" + Seq.ToString();
                break;
            case "4":
                txtSeqNum.Value = Seq.ToString();
                break;
        }

        for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 1; i--)
        {
            ListItem yItem = new ListItem();
            yItem.Value = i.ToString();
            yItem.Text = i.ToString();
            yearList.Items.Add(yItem);
        }

        #endregion

        #region 公文或者项目任务风险处置
        if (ptype != 0 && ptId != 0)
        {
            firstRisk.Visible = false;
            editrisk.Visible = true;
            if (ptype == 33)//项目任务风险处置
            {
                PDTech.OA.BLL.VIEW_PRO_STEP_TYPE sBll = new PDTech.OA.BLL.VIEW_PRO_STEP_TYPE();
                PDTech.OA.Model.VIEW_PRO_STEP_TYPE sInfo = sBll.getviewstepAndtype(new PDTech.OA.Model.VIEW_PRO_STEP_TYPE() { PROJECT_STEP_ID = ptId });
                if (sInfo != null)
                {
                    txtBusinessNum.Text = sInfo.STEP_ID.ToString();
                    txtBusinessNum.Enabled = false;
                    txtHandleDate.Value = sInfo.START_TIME.ToString();
                    txtHandleDate.Disabled = true;
                    txtUserName.Value = sInfo.FULL_NAME;
                    txtUserName.Disabled = true;
                    dplDeptList.SelectedValue = sInfo.DEPARTMENT_ID.ToString();
                    dplDeptList.Enabled = false;
                    dplBusinessType.SelectedValue = "33";
                    dplBusinessType.Enabled = false;
                }
            }
            else//公文任务风险处置
            {
                PDTech.OA.BLL.VIEW_ARCHIVETASK_STEP currBll = new PDTech.OA.BLL.VIEW_ARCHIVETASK_STEP();
                PDTech.OA.Model.VIEW_ARCHIVETASK_STEP tInfo = currBll.get_StempInfo(new PDTech.OA.Model.VIEW_ARCHIVETASK_STEP() { ARCHIVE_TASK_ID = ptId });
                if (tInfo != null)
                {
                    txtBusinessNum.Text = tInfo.ARCHIVE_TASK_ID.ToString();
                    txtBusinessNum.Enabled = false;
                    txtHandleDate.Value = tInfo.START_TIME.ToString();
                    txtHandleDate.Disabled = true;
                    txtUserName.Value = tInfo.FULL_NAME;
                    txtUserName.Disabled = true;
                    dplDeptList.SelectedValue = tInfo.DEPARTMENT_ID.ToString();
                    dplDeptList.Enabled = false;
                    dplBusinessType.SelectedValue = ptype.ToString();
                    dplBusinessType.Enabled = false;
                }
            }
        }
        else if (contentTask_Id > 0)
        {
            onBindData();
        }
        #endregion
    }


    public void onBindData()
    {
        PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
        #region 获取扩展属性并绑定
        PDTech.OA.Model.OA_ARCHIVE_TASK tWhere = currentTaskbll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = contentTask_Id });
        if (tWhere != null)
        {
            PDTech.OA.Model.OA_ARCHIVE Arwhere = ArchiveBll.GetArchiveInfo(tWhere.ARCHIVE_ID.Value);
            #region 获取和遍历扩展属性
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)Arwhere.ATTRIBUTE_LOG });
            if (attList.Count > 0)
            {
                foreach (var item in attList)
                {
                    switch (item.KEY)
                    {
                        case "BusinessType":
                            dplBusinessType.SelectedItem.Text = item.VALUE;
                            dplBusinessType.Enabled = false;
                            break;
                        case "HandleDate":
                            txtHandleDate.Value = item.VALUE;
                            txtHandleDate.Disabled = true;
                            break;
                        case "HandleUser":
                            txtUserName.Value = item.VALUE;
                            txtUserName.Disabled = true;
                            break;
                        case "DeptId":
                            dplDeptList.SelectedItem.Text = item.VALUE;
                            dplDeptList.Enabled = false;
                            break;
                        case "RiskType":
                            dplRiskList.SelectedItem.Text = item.VALUE;
                            dplRiskList.Enabled = false;
                            break;
                        case "HandleYear":
                            yearList.SelectedValue = item.VALUE;
                            break;
                        case "HandleSEQ":
                            txtSeqNum.Value = item.VALUE;
                            txtSeqNum.Disabled = true;
                            break;
                        case "BusinessNum":
                            txtBusinessNum.Text = item.VALUE;
                            txtBusinessNum.Enabled = false;
                            break;
                    }

                }
            }
            txtRemark.Text = Arwhere.ARCHIVE_CONTENT;
            txtTitle.Text = Arwhere.ARCHIVE_TITLE;
            ViewState["const_logId"] = Arwhere.ATTRIBUTE_LOG;
            if (tWhere.TASK_TYPE == 1)
            {
                dplSkipList.Visible = false;
                btnSave.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>hideAtt();</script>");
            }
            ViewState["tType"] = tWhere.TASK_TYPE;
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

            ///显示公文办理流程
            ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(arId); 
            if (Arwhere != null)
            {
                PDTech.OA.BLL.RISK_HANDLE_MAP rBll = new PDTech.OA.BLL.RISK_HANDLE_MAP();
                PDTech.OA.Model.RISK_HANDLE_MAP ArInfo = rBll.get_mapInfo(new PDTech.OA.Model.RISK_HANDLE_MAP() { RISK_HANDLE_ARCHIVE_ID = arId });
                if (ArInfo != null && ArInfo.ARCHIVE_ID != 0)
                {
                    lbtnUrl.Visible = true;
                    lbtnUrl.Text = "查看此公文";
                    switch ((int)ArInfo.ARCHIVE_TYPE)
                    {
                        case 10:
                            lbtnUrl.NavigateUrl = "/Archive/sel_Generalpieces.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 11:
                            lbtnUrl.NavigateUrl = "/Archive/sel_Ordinarypieces.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 12:
                            lbtnUrl.NavigateUrl = "/Archive/sel_UnitDoc.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                            lbtnUrl.NavigateUrl = "/Archive/sel_supInfo.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 24:
                            lbtnUrl.NavigateUrl = "/Admin/sel_Proposal.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 32:
                            lbtnUrl.NavigateUrl = "/Admin/sel_Personnal.aspx?arid=" + ArInfo.ARCHIVE_ID + "";
                            break;
                        case 33:
                            lbtnUrl.Text = "查看此项目";
                            lbtnUrl.NavigateUrl = "/Admin/selFinance.aspx?pId=" + ArInfo.ARCHIVE_ID + "";
                            break;
                    }
                }
                else
                {
                    lbtnUrl.Visible = false;
                }
            }
        }
        #endregion
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
    /// 公文提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSave.Visible)
        {
            btnSave_Click(null, null);
        }
        if (!string.IsNullOrEmpty(dplSkipList.SelectedValue))
            next_step = decimal.Parse(dplSkipList.SelectedValue);///是否存在下一步
        ///
        #region 新增公文
        if (string.IsNullOrEmpty(contentTask_Id.ToString()) || contentTask_Id == 0)
        {
            string fjIds = "";
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            PDTech.OA.Model.OA_ARCHIVE Archive = new PDTech.OA.Model.OA_ARCHIVE();
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                nPrompt("请填写公文标题!", 0);
                txtTitle.Focus();
                return;
            }
            Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
            Archive.ARCHIVE_NO = yearList.SelectedValue + txtSeqNum.Value;
            Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
            Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
            Archive.CREATOR = CurrentAccount.USER_ID;
            Archive.CURRENT_STATE = 0;
            Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
            if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
            {
                fjIds = hidAttachmentIds.Value.TrimEnd(',');
            }
            if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "BusinessType", VALUE = new ConvertHelper(dplBusinessType.SelectedItem.Text).String });
            }
            if (!string.IsNullOrEmpty(txtHandleDate.Value.Trim()))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleDate", VALUE = txtHandleDate.Value.Trim() });
            }
            if (!string.IsNullOrEmpty(txtUserName.Value.Trim()))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleUser", VALUE = txtUserName.Value.Trim() });
            }
            if (!string.IsNullOrEmpty(dplDeptList.SelectedValue))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "DeptId", VALUE = dplDeptList.SelectedItem.Text });
            }
            if (!string.IsNullOrEmpty(dplRiskList.SelectedValue))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "RiskType", VALUE = dplRiskList.SelectedItem.Text });
            }
            if (!string.IsNullOrEmpty(yearList.SelectedValue))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleYear", VALUE = yearList.SelectedValue });
            }
            if (!string.IsNullOrEmpty(txtSeqNum.Value))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleSEQ", VALUE = txtSeqNum.Value });
            }
            if(!string.IsNullOrEmpty(txtBusinessNum.Text))
            {
                attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "BusinessNum", VALUE = txtBusinessNum.Text });
            }
            if (ptype == 0)
            {
                ptype = decimal.Parse(dplBusinessType.SelectedValue);
            }
            bool result = ArchiveBll.AddRisk(Archive, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, fjIds, attList, p_arId, ptId, (int)ptype, 0, out Archive_Id, out Task_Id);
            if (result)
            {
                contentTask_Id = (int)Task_Id;
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='/Risk/RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
            }
            else
            {
                nPrompt("提交失败!", 0);
            }
        }
        #endregion

        #region 最后步骤
        else if (ViewState["End_Flag"] != null && ViewState["End_Flag"].ToString() == "1")
        {
            PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
            where.P_TASK_ID = contentTask_Id;
            int result = currentTaskbll.ArchiveHandle(where);
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

        #region  抄送办理提交
        else if (ViewState["tType"] != null && ViewState["tType"].ToString() == "1")
        {
            PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
            where.P_TASK_ID = contentTask_Id;
            int result = currentTaskbll.ArchiveHandle(where);
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

        #region 常规公文办理
        else if (ViewState["tType"] != null && ViewState["tType"].ToString() == "0")
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='/Risk/RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "'</script>");
        }
        #endregion
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
                int result = currentTaskbll.ArchiveRevert(where);
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
    /// 公文抄送
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCc_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='/Risk/RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "&action=copy'</script>");
    }
    /// <summary>
    /// 修改保存风险处置
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
            if (arId != 0)
            {
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    nPrompt("请填写公文标题!", 0);
                    txtTitle.Focus();
                    return;
                }
                Archive.ARCHIVE_CONTENT = txtRemark.Text.Trim();
                Archive.ARCHIVE_NO = yearList.SelectedValue+txtSeqNum.Value;
                Archive.ARCHIVE_TITLE = txtTitle.Text.Trim();
                Archive.ARCHIVE_TYPE = ARCHIVE_TYPE;
                Archive.CREATOR = CurrentAccount.USER_ID;
                Archive.CURRENT_STATE = 0;
                Archive.ARCHIVE_ID = arId;
                if (ViewState["const_logId"] != null)
                {
                    Archive.ATTRIBUTE_LOG = decimal.Parse(ViewState["const_logId"].ToString());
                }
                Archive.PRI_LEVEL = decimal.Parse(dplUrgency.SelectedValue);
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    fjIds = hidAttachmentIds.Value.TrimEnd(',');
                }
                if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "BusinessType", VALUE = new ConvertHelper(dplBusinessType.SelectedValue).String });
                }
                if (!string.IsNullOrEmpty(txtHandleDate.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleDate", VALUE = txtHandleDate.Value.Trim() });
                }
                if (!string.IsNullOrEmpty(txtUserName.Value.Trim()))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleUser", VALUE = txtUserName.Value.Trim() });
                }
                if (!string.IsNullOrEmpty(dplDeptList.SelectedValue))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "DeptId", VALUE = dplDeptList.SelectedValue });
                }
                if (!string.IsNullOrEmpty(dplRiskList.SelectedValue))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "RiskType", VALUE = dplRiskList.SelectedItem.Text });
                }
                if (!string.IsNullOrEmpty(yearList.SelectedValue))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleYear", VALUE = yearList.SelectedValue });
                }
                if (!string.IsNullOrEmpty(txtSeqNum.Value))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "HandleSEQ", VALUE = txtSeqNum.Value });
                }
                if (!string.IsNullOrEmpty(txtBusinessNum.Text))
                {
                    attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "BusinessNum", VALUE = txtBusinessNum.Text });
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

    /// <summary>
    /// 查询附件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
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
            if (arId != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_ARCHIVE')", arId);
            if (arId != 0 && string.IsNullOrEmpty(where.Append))
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
        if (arId != 0 && !string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            fBll.UpdatePID(HidIds, arId, "OA_ARCHIVE", "");
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();CloseAllFrame();</script>");
        }
    }
}