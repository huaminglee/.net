using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;

public partial class Admin_newFinance : System.Web.UI.Page
{
    PDTech.OA.BLL.FUNDS_INFO zBll = new PDTech.OA.BLL.FUNDS_INFO();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.SW_PROJECT_INFO sBll = new PDTech.OA.BLL.SW_PROJECT_INFO();
    PDTech.OA.BLL.ARCHIVE_PROJECT_MAP mBll = new PDTech.OA.BLL.ARCHIVE_PROJECT_MAP();
    PDTech.OA.BLL.WORKFLOW_STEP vStepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
    public string t_rand = "";//css 或者JS  时间戳
    decimal archivetype = 33;
    decimal ArId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["ArId"] != null)
        {
            ArId = decimal.Parse(Request.QueryString["ArId"].ToString());
        }
        if (Request.QueryString["stype"] != null)
        {
            archivetype = 331;
        }
        if (!IsPostBack)
        {
            List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(archivetype);///本流程所有步骤
            PDTech.OA.Model.WORKFLOW_STEP start_step;///起始步骤
            List<PDTech.OA.Model.WORKFLOW_STEP> vNextList = new List<PDTech.OA.Model.WORKFLOW_STEP>();///下一步可操作步骤集合
            title.InnerText = "成都市水务局" + S_App.ShowTitle("33") + "备案表";//设置标题
            InitBind();
            if (ArId != 0)
            {
                InitBindData();
                PDTech.OA.BLL.OA_ARCHIVE_TASK tBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                PDTech.OA.Model.OA_ARCHIVE_TASK tInfo = tBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_ID = ArId });

                start_step = vStepList.Where(s => s.STEP_ID == tInfo.CURRENT_STEP_ID).FirstOrDefault();
            }
            else
            {
                start_step = vStepList.Where(s => s.START_FLAG != null && s.START_FLAG == "1").FirstOrDefault();
            }

            Archive_Base.GetAvailableSteps(null, vStepList, vNextList, start_step.STEP_ID.Value);//获取下一步列表
            BindDplSkipList(vNextList);//绑定下一步可操作的列表
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

    public void InitBindData()
    {
        #region 获取并绑定项目信息
        PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() {ARCHIVE_ID=ArId });
        PDTech.OA.Model.SW_PROJECT_INFO sequel = sBll.get_proInfo((decimal)map.PROJECT_ID);
            txtHostUnit.Value = sequel.OWNER_DEPT;//项目主办单位
            txtMoneyTotal.Value = sequel.PROJECT_FUNDS.ToString();//项目总金额
            txtPlaneTime.Value = sequel.PLAN_END_TIME == null ? "" : sequel.PLAN_END_TIME.Value.ToString("yyyy-MM-dd");//计划结束时间
            txtProjectBasis.Value = sequel.PROJECT_BY;//立项依据
            txtRemark.Text = sequel.REMARK;//备注
            dplRESPONSE_DEPT.SelectedValue = sequel.TOP_RESPONSE_DEPT;//主办处室
            txtsTime.Value = sequel.START_TIME == null ? "" : sequel.START_TIME.Value.ToString("yyyy-MM-dd");//开始时间
            txtTitle.Text = sequel.PROJECT_NAME;//项目名称
            txtMoneySource.Value= sequel.FUNDS_TYPE.ToString();//项目资金来源
            dplFILE_DEPT.SelectedValue = sequel.FILE_DEPT.ToString();//归档处室
            dplIs_End.SelectedValue = sequel.PROJECT_STATUS.ToString();//项目完结状态
            dplOrgUnit.SelectedValue = sequel.LAUNCH_TYPE.ToString();//项目组织方式
        #endregion

        #region 获取该公文的附件
            PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
            where.REF_TYPE = "OA_ARCHIVE";//
            where.REF_ID = ArId;//步骤Id
            IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = fBll.get_InfoList(where);//获取当前步骤附件的列表
            if (aList.Count > 0)//如列表数据大于零 绑定并显示附件
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

        ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(ArId); 
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void InitBind()
    {
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        /**绑定组织单位**/
        CurrentAccount.BindEnumDropDownList(typeof(EArchiveOrgUnit), dplOrgUnit);
        /**绑定项目归档处室**/
        CurrentAccount.BindEnumDropDownList(typeof(EArchiveFILE_DEPT), dplFILE_DEPT);
        dplFILE_DEPT.Enabled = false;
        if (archivetype == 331)
        {
            dplFILE_DEPT.SelectedValue = "2";
        }
        else
        {
            dplFILE_DEPT.SelectedValue = "1";
        }
        /**获取绑定三重一大**/
        IList<PDTech.OA.Model.DEPARTMENT> dList = dBll.get_DeptList(new PDTech.OA.Model.DEPARTMENT() { });
        foreach (var item in dList)
        {
            ListItem ditem = new ListItem();
            ditem.Value = item.DEPARTMENT_ID.ToString();
            ditem.Text = item.DEPARTMENT_NAME;
            dplRESPONSE_DEPT.Items.Add(ditem);
        }
        ListItem item_d = new ListItem();
        item_d.Value = "";
        item_d.Text = "---请选择---";
        dplRESPONSE_DEPT.Items.Insert(0, item_d);
        if (ArId == 0)//新增时隐藏选择结束项目
        {
            tr_Opinion.Visible = false;
            btnSave.Visible = false;
            btnCc.Visible = false;
        }

    }

    /// <summary>
    /// 提交当前项目
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Ids = "";
        int Is_szyd=0;
        decimal ArchiveId=0;
        decimal Project_Id=0;
        decimal task_Id=0;
        try
        {
            if (ArId == 0)
            {
                PDTech.OA.Model.SW_PROJECT_INFO query = new PDTech.OA.Model.SW_PROJECT_INFO();
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    nPrompt("项目名称不能为空!", 0);
                    txtTitle.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(dplRESPONSE_DEPT.SelectedValue))
                {
                    nPrompt("请选择牵头处室!", 0);
                    dplRESPONSE_DEPT.Focus();
                    return;
                }
                query.START_TIME = new ConvertHelper(txtsTime.Value).ToDateTime;//项目开始时间,未选择为null
                query.CREATOR = new ConvertHelper(CurrentAccount.USER_ID).ToInt32;//项目创建人ID
                query.FILE_DEPT = new ConvertHelper(dplFILE_DEPT.SelectedValue).ToDecimal;//归档处室,未选择为null
                query.FUNDS_TYPE = new ConvertHelper(txtMoneySource.Value).String;//资金来源,未选择为null
                query.LAUNCH_TYPE = new ConvertHelper(dplOrgUnit.SelectedValue).ToDecimal;//组织方式,为选择为null
                query.OWNER_DEPT = txtHostUnit.Value;//主办单位，可不填
                query.PLAN_END_TIME = new ConvertHelper(txtPlaneTime.Value).ToDateTime;//计划完成时间,为选择为null
                query.PROJECT_BY = txtProjectBasis.Value;//项目立项依据
                query.PROJECT_FUNDS = new ConvertHelper(txtMoneyTotal.Value).String;//项目总金额
                query.PROJECT_NAME = txtTitle.Text;//项目名称
                query.PROJECT_STATUS = new ConvertHelper(dplIs_End.SelectedValue).ToDecimal;//项目状态
                query.REMARK = txtRemark.Text;//项目备注,可为空
                query.TOP_RESPONSE_DEPT = dplRESPONSE_DEPT.SelectedValue;//主办处室
                Is_szyd = 0;//int.Parse(dplSzyd.SelectedValue);
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    Ids = hidAttachmentIds.Value.TrimEnd(',');
                }
                bool result = sBll.Add(query, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, Ids, Is_szyd, out ArchiveId, out Project_Id, out task_Id);
                if (result)
                {
                    PDTech.OA.BLL.OA_ARCHIVE_TASK tBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                    PDTech.OA.Model.OA_ARCHIVE_TASK tInfo = tBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_ID = ArchiveId });
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?projectid="+query.PROJECT_ID+"&tId=" + task_Id + "&nId=" + dplSkipList.SelectedValue + "&action=Handle'</script>");
                }
                else
                {
                    nPrompt("提交失败", 0);
                }
            }
            else if(ArId>0)
            {
                PDTech.OA.BLL.OA_ARCHIVE_TASK tBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
                PDTech.OA.Model.OA_ARCHIVE_TASK tInfo = tBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_ID = ArId });
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + tInfo.ARCHIVE_TASK_ID  +"&nId=" + dplSkipList.SelectedValue + "&action=Handle'</script>");
            }
        }
        catch
        {

        }
    }
    /// <summary>
    /// 爆粗当前修改的项目
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() { ARCHIVE_ID = ArId });
            PDTech.OA.Model.SW_PROJECT_INFO query = new PDTech.OA.Model.SW_PROJECT_INFO();
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                nPrompt("标题不能为空!", 0);
                return;
            }
            if (string.IsNullOrEmpty(dplRESPONSE_DEPT.SelectedValue))
            {
                nPrompt("请选择局机关牵头处室!", 0);
                return;
            }
            query.START_TIME = new ConvertHelper(txtsTime.Value).ToDateTime;//项目开始时间,未选择为null
            query.CREATOR = new ConvertHelper(CurrentAccount.USER_ID).ToInt32;//项目创建人ID
            query.FILE_DEPT = new ConvertHelper(dplFILE_DEPT.SelectedValue).ToDecimal;//归档处室,未选择为null
            query.FUNDS_TYPE = new ConvertHelper(txtMoneySource.Value).String;//资金来源,未选择为null
            query.LAUNCH_TYPE = new ConvertHelper(dplOrgUnit.SelectedValue).ToDecimal;//组织方式,为选择为null
            query.OWNER_DEPT = txtHostUnit.Value;//主办单位，可不填
            query.PLAN_END_TIME = new ConvertHelper(txtPlaneTime.Value).ToDateTime;//计划完成时间,为选择为null
            query.PROJECT_BY = txtProjectBasis.Value;//项目立项依据
            query.PROJECT_FUNDS = new ConvertHelper(txtMoneyTotal.Value).String;//项目总金额
            query.PROJECT_NAME = txtTitle.Text;//项目名称
            query.PROJECT_STATUS = new ConvertHelper(dplIs_End.SelectedValue).ToDecimal;//项目状态
            query.REMARK = txtRemark.Text;//项目备注,可为空
            query.TOP_RESPONSE_DEPT = dplRESPONSE_DEPT.SelectedValue;//主办处室
            query.PROJECT_ID = map.PROJECT_ID;
            bool result = sBll.Update(query,ArId);
            if (result)
            {
                nPrompt("保存成功!", 1);
            }
            else
            {
                nPrompt("保存失败!", 1);
            }
        }
        catch
        {

        }
    }
    /// <summary>
    /// 项目抄送
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCc_Click(object sender, EventArgs e)
    {
        PDTech.OA.BLL.OA_ARCHIVE_TASK tBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
        PDTech.OA.Model.OA_ARCHIVE_TASK tInfo = tBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() {ARCHIVE_ID=ArId });
        this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + tInfo.ARCHIVE_TASK_ID + "&action=copy'</script>");
    }
    /// <summary>
    /// 查询当前项目步骤的附件
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
        /**判断是否有新增附件**/
        if (!string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            if (!string.IsNullOrEmpty(HidIds))
                where.Append = string.Format(" ATTACHMENT_FILE_ID IN({0}) ", HidIds);
            if (ArId != 0 && !string.IsNullOrEmpty(where.Append))//获取是此项目的附件
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_ARCHIVE')", ArId);
            if (ArId != 0 && string.IsNullOrEmpty(where.Append))//获取是此项目的附件
                where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_ARCHIVE' ", ArId);
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
        /**项目不是新增且有新增附件**/
        if (ArId != 0 && !string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            fBll.UpdatePID(HidIds, ArId, "OA_ARCHIVE", "");
        }
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
            }
            else
            {
                if (ViewState["Creator"] != null )
                {
                    if (ViewState["Creator"].ToString() == CurrentAccount.USER_ID.ToString())
                        fBll.Delete(atId);
                    else
                        nPrompt("您没有权限删除此附件!", 0);
                }

            }
        }
        BindData();
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.Close();</script>");
        }
    }
}