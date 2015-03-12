using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

public partial class Admin_sel_Finance : System.Web.UI.Page
{
    PDTech.OA.BLL.FUNDS_INFO zBll = new PDTech.OA.BLL.FUNDS_INFO();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.OA_ARCHIVE ArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.SW_PROJECT_INFO sBll = new PDTech.OA.BLL.SW_PROJECT_INFO();
    PDTech.OA.BLL.ARCHIVE_PROJECT_MAP mBll = new PDTech.OA.BLL.ARCHIVE_PROJECT_MAP();
    PDTech.OA.BLL.WORKFLOW_STEP vStepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
    PDTech.OA.BLL.OA_ARCHIVE_TASK tbll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.OA_ARCHIVE_TASK taskBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.Model.OA_ARCHIVE Arwhere = null;//当前公文
    PDTech.OA.Model.OA_ARCHIVE_TASK tWhere;//当前任务
    PDTech.OA.BLL.RISK_POINT_INFO rpi_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
    public string t_rand = "";//css 或者JS  时间戳
    public decimal ArId = 0;
    public decimal pId = 0;
    decimal psId = 0;
    decimal ARCHIVE_TYPE = 33;
    public decimal contentTask_Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["ArId"] != null && !string.IsNullOrEmpty(Request.QueryString["ArId"]))
        {
            ArId = decimal.Parse(Request.QueryString["ArId"].ToString());
            hidarchid.Value = ArId.ToString();
            PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() { ARCHIVE_ID = ArId });
            pId = (decimal)map.PROJECT_ID;
        }
        if (Request.QueryString["tId"] != null)
        {
            if (AidHelp.IsDecimal(Request.QueryString["tId"].ToString()))
            {
                contentTask_Id = int.Parse(Request.QueryString["tId"].ToString());
                hidtaskid.Value = contentTask_Id.ToString();
            }
        }
        if (!IsPostBack)
        {
            
            InitBind();
            if (ArId != 0)
            {
                InitBindData();
            }
        }
    }
    public void InitBindData()
    {
        #region 获取并绑定项目信息
        PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() { ARCHIVE_ID = ArId });
        PDTech.OA.Model.SW_PROJECT_INFO sequel = sBll.get_proInfo((decimal)map.PROJECT_ID);
        txtHostUnit.Value = sequel.OWNER_DEPT;//项目主办单位
        txtMoneyTotal.Value = (sequel.PROJECT_FUNDS).ToString();//项目总金额
        txtPlaneTime.Value = sequel.PLAN_END_TIME == null ? "" : sequel.PLAN_END_TIME.Value.ToString("yyyy-MM-dd");//计划结束时间
        txtProjectBasis.Value = sequel.PROJECT_BY;//立项依据
        txtRemark.Text = sequel.REMARK;//备注
        dplRESPONSE_DEPT.SelectedValue = sequel.TOP_RESPONSE_DEPT;//主办处室
        txtsTime.Value = sequel.START_TIME == null ? "" : sequel.START_TIME.Value.ToString("yyyy-MM-dd");//开始时间
        txtTitle.Text = sequel.PROJECT_NAME;//项目名称
        lbtitle.Text = "水务项目--" + sequel.PROJECT_NAME;
        txtMoneySource.Value = sequel.FUNDS_TYPE.ToString();//项目资金来源
        dplFILE_DEPT.SelectedValue = sequel.FILE_DEPT.ToString();//归档处室
        dplIs_End.SelectedValue = sequel.PROJECT_STATUS.ToString();//项目完结状态
        dplOrgUnit.SelectedValue = sequel.LAUNCH_TYPE.ToString();//项目组织方式
        hidprojectid.Value = sequel.PROJECT_ID.ToString();

        #endregion

        #region 获取该公文的附件
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        where.REF_TYPE = "OA_ARCHIVE";//
        where.REF_ID = map.ARCHIVE_ID;//步骤Id
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
            tipInfo.Visible = false;//隐藏提示图标
        }
        else
        {
            PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() { ARCHIVE_ID = ArId });
            PDTech.OA.Model.SW_PROJECT_INFO sequel = sBll.get_proInfo((decimal)map.PROJECT_ID);
            if (sequel.FILE_DEPT == 2)
            {
                ARCHIVE_TYPE = 331;
            }
        }
        List<PDTech.OA.Model.WORKFLOW_STEP> vStepList = (List<PDTech.OA.Model.WORKFLOW_STEP>)vStepBll.GetStepByArchiveType(ARCHIVE_TYPE);///本流程所有步骤
        List<PDTech.OA.Model.WORKFLOW_STEP> vNextList = new List<PDTech.OA.Model.WORKFLOW_STEP>();///下一步可操作步骤集合
        PDTech.OA.Model.WORKFLOW_STEP start_step = new PDTech.OA.Model.WORKFLOW_STEP();///起始步骤
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
        if (ArId == 0)
        {
            ArId = tWhere.ARCHIVE_ID.Value;
            hidarchid.Value = ArId.ToString();
            PDTech.OA.Model.ARCHIVE_PROJECT_MAP map = mBll.get_mapInfo(new PDTech.OA.Model.ARCHIVE_PROJECT_MAP() { ARCHIVE_ID = ArId });
            pId = (decimal)map.PROJECT_ID;
        }


        Arwhere = ArchiveBll.GetArchiveInfo(tWhere.ARCHIVE_ID.Value);
        hidcurstepid.Value = Arwhere.CURRENT_STEP_ID.ToString();
        start_step = vStepList.Where(s => s.STEP_ID == tWhere.CURRENT_STEP_ID).FirstOrDefault();
        ViewState["End_Flag"] = start_step.END_FLAG;
        ViewState["tType"] = tWhere.TASK_TYPE;
        if (tWhere.TASK_TYPE == 1)
        {
            btnSave.Visible = false;
            dplSkipList.Visible = false;
        }
        Archive_Base.GetAvailableSteps(Arwhere, vStepList, vNextList, start_step.STEP_ID.Value);//获取下一步列表
        BindDplSkipList(vNextList);//绑定下一步可操作的列表
        #region 绑定各步骤附件
        BindStepFile();
        #endregion
    }
    protected void BindStepFile()
    {
        PDTech.OA.BLL.VIEW_PRO_STEP_TYPE vBll = new PDTech.OA.BLL.VIEW_PRO_STEP_TYPE();
        PDTech.OA.Model.VIEW_PRO_STEP_TYPE twhere = new PDTech.OA.Model.VIEW_PRO_STEP_TYPE();
        PDTech.OA.Model.VIEW_PRO_STEP_TYPE step;
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();

        switch (hidcurstepid.Value.ToString())
        {
            case "330012":        //规划
                gh.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 102;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_gh = fBll.get_InfoList(where);
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_gh = allList_gh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "审查意见").ToList();

                    if (exList_gh.Count > 0)
                    {
                        rpt_ExfileList_gh.DataSource = exList_gh;
                        rpt_ExfileList_gh.DataBind();
                        tr_showExList_gh.Visible = true;
                    }
                    else
                    {
                        tr_showExList_gh.Visible = false;
                    }
                }


                break;
            case "330013":        //项目建议书
                xmjys.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 103;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    ///获取此步骤的所有附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_xmjys = fBll.get_InfoList(where);
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_xmjys = allList_xmjys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "审查意见").ToList();
                    ///获取步骤编制报告附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> plList_xmjys = allList_xmjys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "编制报告").ToList();
                    ///获取步骤专家评审结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccList_xmjys = allList_xmjys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "专家评审结果").ToList();

                    if (exList_xmjys.Count > 0)
                    {
                        rpt_ExfileList_xmjys.DataSource = exList_xmjys;
                        rpt_ExfileList_xmjys.DataBind();
                        tr_showExList_xmjys.Visible = true;
                        hidUpload_xmjys.Value = "1";
                    }
                    else
                    {
                        tr_showExList_xmjys.Visible = false;
                        hidUpload_xmjys.Value = "0";
                    }
                    if (plList_xmjys.Count > 0)
                    {
                        rpt_plaitList_xmjys.DataSource = plList_xmjys;
                        rpt_plaitList_xmjys.DataBind();
                        tr_showplList_xmjys.Visible = true;
                        hidPlait_xmjys.Value = "1";
                    }
                    else
                    {
                        tr_showplList_xmjys.Visible = false;
                        hidPlait_xmjys.Value = "0";
                    }
                    if (AccList_xmjys.Count > 0)
                    {
                        rpt_AccList_xmjys.DataSource = AccList_xmjys;
                        rpt_AccList_xmjys.DataBind();
                        tr_AccList_xmjys.Visible = true;
                        hidAcc_xmjys.Value = "1";
                    }
                    else
                    {
                        tr_AccList_xmjys.Visible = false;
                        hidAcc_xmjys.Value = "0";
                    }
                }
                break;
            case "330014"://可行性研究
                kxx.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 104;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    ///获取此步骤的所有附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList = fBll.get_InfoList(where);

                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ArgList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "涉水专项论证").ToList();
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "审查意见").ToList();
                    ///获取步骤编制报告附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> plList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "编制报告").ToList();
                    ///获取步骤专家评审结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "专家评审结果").ToList();

                    if (exList.Count > 0)
                    {
                        rpt_ExfileList_kxx.DataSource = exList;
                        rpt_ExfileList_kxx.DataBind();
                        tr_showExList_kxx.Visible = true;
                        hidEx_kxx.Value = "1";
                    }
                    else
                    {
                        tr_showExList_kxx.Visible = false;
                        hidEx_kxx.Value = "0";
                    }
                    if (plList.Count > 0)
                    {
                        rpt_plaitList_kxx.DataSource = exList;
                        rpt_plaitList_kxx.DataBind();
                        tr_showplList_kxx.Visible = true;
                        hidPlait_kxx.Value = "1";
                    }
                    else
                    {
                        tr_showplList_kxx.Visible = false;
                        hidPlait_kxx.Value = "0";
                    }
                    if (AccList.Count > 0)
                    {
                        rpt_AccList_kxx.DataSource = AccList;
                        rpt_AccList_kxx.DataBind();
                        tr_AccList_kxx.Visible = true;
                        hidAcc_kxx.Value = "1";
                    }
                    else
                    {
                        tr_AccList_kxx.Visible = false;
                        hidAcc_kxx.Value = "0";
                    }
                    if (ArgList.Count > 0)
                    {
                        rpt_ArgList_kxx.DataSource = ArgList;
                        rpt_ArgList_kxx.DataBind();
                        tr_ArgList_kxx.Visible = true;
                        hidArg_kxx.Value = "1";
                    }
                    else
                    {
                        tr_ArgList_kxx.Visible = false;
                        hidArg_kxx.Value = "0";
                    }
                }
                break;
            case "330015"://初步设计
                cbsj.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 105;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    ///获取此步骤的所有附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_cbsj = fBll.get_InfoList(where);
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_cbsj = allList_cbsj.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "定审结果").ToList();
                    ///获取步骤编制报告附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> plList_cbsj = allList_cbsj.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "会签结果").ToList();
                    ///获取步骤专家评审结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccList_cbsj = allList_cbsj.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "领导签发").ToList();

                    if (exList_cbsj.Count > 0)
                    {
                        rpt_ExfileList_cbsj.DataSource = exList_cbsj;
                        rpt_ExfileList_cbsj.DataBind();
                        tr_showExList_cbsj.Visible = true;
                        hidEx_cbsj.Value = "1";
                    }
                    else
                    {
                        tr_showExList_cbsj.Visible = false;
                        hidEx_cbsj.Value = "0";
                    }
                    if (plList_cbsj.Count > 0)
                    {
                        rpt_plaitList_cbsj.DataSource = plList_cbsj;
                        rpt_plaitList_cbsj.DataBind();
                        tr_showplList_cbsj.Visible = true;
                        hidPlait_cbsj.Value = "1";
                    }
                    else
                    {
                        tr_showplList_cbsj.Visible = false;
                        hidPlait_cbsj.Value = "0";
                    }
                    if (AccList_cbsj.Count > 0)
                    {
                        rpt_AccList_cbsj.DataSource = AccList_cbsj;
                        rpt_AccList_cbsj.DataBind();
                        tr_AccList_cbsj.Visible = true;
                        hidAcc_cbsj.Value = "1";
                    }
                    else
                    {
                        tr_AccList_cbsj.Visible = false;
                        hidAcc_cbsj.Value = "0";
                    }
                }
                break;
            case "330016"://施工准备
                sgzb.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 106;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    ///获取此步骤的所有附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_sgzb = fBll.get_InfoList(where);

                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ArgList_sgzb = allList_sgzb.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "招标文件").ToList();
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_sgzb = allList_sgzb.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "开标监督文件").ToList();
                    ///获取步骤编制报告附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> plList_sgzb = allList_sgzb.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "中标通知书").ToList();
                    ///获取步骤专家评审结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccList_sgzb = allList_sgzb.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "合同").ToList();


                    if (exList_sgzb.Count > 0)
                    {
                        rpt_ExfileList_sgzb.DataSource = exList_sgzb;
                        rpt_ExfileList_sgzb.DataBind();
                        tr_showExList_sgzb.Visible = true;
                        hidEx_sgzb.Value = "1";
                    }
                    else
                    {
                        tr_showExList_sgzb.Visible = false;
                        hidEx_sgzb.Value = "0";
                    }
                    if (plList_sgzb.Count > 0)
                    {
                        rpt_plaitList_sgzb.DataSource = plList_sgzb;
                        rpt_plaitList_sgzb.DataBind();
                        tr_showplList_sgzb.Visible = true;
                        hidPlait_sgzb.Value = "1";
                    }
                    else
                    {
                        tr_showplList_sgzb.Visible = false;
                        hidPlait_sgzb.Value = "0";
                    }
                    if (AccList_sgzb.Count > 0)
                    {
                        rpt_AccList_sgzb.DataSource = AccList_sgzb;
                        rpt_AccList_sgzb.DataBind();
                        tr_AccList_sgzb.Visible = true;
                        hidAcc_sgzb.Value = "1";
                    }
                    else
                    {
                        tr_AccList_sgzb.Visible = false;
                        hidAcc_sgzb.Value = "0";
                    }
                    if (ArgList_sgzb.Count > 0)
                    {
                        rpt_ArgList_sgzb.DataSource = ArgList_sgzb;
                        rpt_ArgList_sgzb.DataBind();
                        tr_ArgList_sgzb.Visible = true;
                        hidArg_sgzb.Value = "1";
                    }
                    else
                    {
                        tr_ArgList_sgzb.Visible = false;
                        hidArg_sgzb.Value = "0";
                    }
                }
                break;
            case "330017"://建设实施
                jsss.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 107;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    ///获取此步骤的所有附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_jsss = fBll.get_InfoList(where);
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_jsss = allList_jsss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "开工备案").ToList();
                    ///获取步骤编制报告附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> plList_jsss = allList_jsss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "进度管理").ToList();
                    ///获取步骤专家评审结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccList_jsss = allList_jsss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "重大设计变更审批").ToList();


                    if (exList_jsss.Count > 0)
                    {
                        rpt_ExfileList_jsss.DataSource = exList_jsss;
                        rpt_ExfileList_jsss.DataBind();
                        tr_showExList_jsss.Visible = true;
                        hidEx_jsss.Value = "1";
                    }
                    else
                    {
                        tr_showExList_jsss.Visible = false;
                        hidEx_jsss.Value = "0";
                    }
                    if (plList_jsss.Count > 0)
                    {
                        rpt_plaitList_jsss.DataSource = plList_jsss;
                        rpt_plaitList_jsss.DataBind();
                        tr_showplList_jsss.Visible = true;
                        hidPlait_jsss.Value = "1";
                    }
                    else
                    {
                        tr_showplList_jsss.Visible = false;
                        hidPlait_jsss.Value = "0";
                    }
                    if (AccList_jsss.Count > 0)
                    {
                        rpt_AccList_jsss.DataSource = AccList_jsss;
                        rpt_AccList_jsss.DataBind();
                        tr_AccList_jsss.Visible = true;
                        hidAcc_jsss.Value = "1";
                    }
                    else
                    {
                        tr_AccList_jsss.Visible = false;
                        hidAcc_jsss.Value = "0";
                    }
                }
                break;
            case "330018"://生产准备
                sczb.Visible = true;
                break;
            case "330019"://竣工验收
                jgys.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 109;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_jgys = fBll.get_InfoList(where);
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ApplyList_jgys = allList_jgys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "竣工验收申请").ToList();
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccepList_jgys = allList_jgys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "竣工验收鉴定书").ToList();

                    if (ApplyList_jgys.Count > 0)
                    {
                        rpt_CompList_jgys.DataSource = ApplyList_jgys;
                        rpt_CompList_jgys.DataBind();
                        tr_showApplyList_jgys.Visible = true;
                        hidApply_jgys.Value = "1";
                    }
                    else
                    {
                        tr_showApplyList_jgys.Visible = false;
                        hidApply_jgys.Value = "0";
                    }
                    if (AccepList_jgys.Count > 0)
                    {
                        rpt_AccepList_jgys.DataSource = AccepList_jgys;
                        rpt_AccepList_jgys.DataBind();
                        tr_AccepList_jgys.Visible = true;
                        hidAccep_jgys.Value = "1";
                    }
                    else
                    {
                        tr_AccepList_jgys.Visible = false;
                        hidAccep_jgys.Value = "0";
                    }
                }
                break;
            case "330010"://后评价
                hpj.Visible = true;
                break;
            case "330112"://审定计划
                sdjh.Visible = true;
                 twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 202;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_sdjh = fBll.get_InfoList(where);

                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> EvaList_sdjh = allList_sdjh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "申报项目评审").ToList();
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> exList_sdjh = allList_sdjh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "申报项目签审").ToList();

                    if (exList_sdjh.Count > 0)
                    {
                        rpt_ProExetList_sdjh.DataSource = exList_sdjh;
                        rpt_ProExetList_sdjh.DataBind();
                        trProExetList_sdjh.Visible = true;
                        hidProExet_sdjh.Value = "1";
                    }
                    else
                    {
                        trProExetList_sdjh.Visible = false;
                        hidProExet_sdjh.Value = "0";
                    }
                    if (EvaList_sdjh.Count > 0)
                    {
                        rpt_ProEvaList_sdjh.DataSource = EvaList_sdjh;
                        rpt_ProEvaList_sdjh.DataBind();
                        tr_showProEvaList_sdjh.Visible = true;
                        hidProEva_sdjh.Value = "1";
                    }
                    else
                    {
                        tr_showProEvaList_sdjh.Visible = false;
                        hidProEva_sdjh.Value = "0";
                    }
                }
                break;
            case "330113"://上报计划
                sbjh.Visible = true;
                 twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 203;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_sbjh = fBll.get_InfoList(where);

                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ProBasisList_sbjh = allList_sbjh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "立项依据").ToList();
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> fPlanList_sbjh = allList_sbjh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "项目资金计划").ToList();

                    if (ProBasisList_sbjh.Count > 0)
                    {
                        rpt_ProBasisList_sbjh.DataSource = ProBasisList_sbjh;
                        rpt_ProBasisList_sbjh.DataBind();
                        tr_showProBasisList_sbjh.Visible = true;
                        hidProBasis_sbjh.Value = "1";
                    }
                    else
                    {
                        tr_showProBasisList_sbjh.Visible = false;
                        hidProBasis_sbjh.Value = "0";
                    }
                    if (fPlanList_sbjh.Count > 0)
                    {
                        rpt_fPlanList_sbjh.DataSource = fPlanList_sbjh;
                        rpt_fPlanList_sbjh.DataBind();
                        tr_fPlanList_sbjh.Visible = true;
                    }
                    else
                    {
                        tr_fPlanList_sbjh.Visible = false;
                    }
                }
                break;
            case "330114"://下达计划
                xdjh.Visible = true;
                 twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 204;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_xdjh = fBll.get_InfoList(where);
                    ///获取步骤审查意见附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> fPlanList_xdjh = allList_xdjh.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "项目资金计划").ToList();

                    if (fPlanList_xdjh.Count > 0)
                    {
                        rpt_fPlanList_xdjh.DataSource = fPlanList_xdjh;
                        rpt_fPlanList_xdjh.DataBind();
                        tr_fPlanList_xdjh.Visible = true;
                    }
                    else
                    {
                        tr_fPlanList_xdjh.Visible = false;
                    }
                }
                break;
            case "330115"://项目实施
                xmss.Visible = true;
                zjbf.Visible = true;
                 twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 205;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_xmss = fBll.get_InfoList(where);

                    ///获取步骤招标文件附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> BidDocList_xmss = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "招标文件").ToList();
                    ///获取步骤开标监督文件附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> supDocList_xmss = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "开标监督文件").ToList();
                    ///获取步骤中标通知书附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> bidNoticeList_xmss = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "中标通知书").ToList();
                    ///获取步骤合同附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ContractList_xmss = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "合同").ToList();
                    ///获取步骤开工备案附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> sRecordList_xmss = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "开工备案").ToList();

                    ///获取步骤付款申请附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> PayList_zjbf = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "付款申请").ToList();
                    ///获取步骤付款申请审核结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> payrList_zjbf = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "付款申请审核结果").ToList();
                    ///获取步骤资金拨付签审附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> MoneyList_zjbf = allList_xmss.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "资金拨付签审").ToList();

                    if (PayList_zjbf.Count > 0)
                    {
                        rpt_PayList_zjbf.DataSource = PayList_zjbf;
                        rpt_PayList_zjbf.DataBind();
                        hidbidPay_zjbf.Value = "1";
                        tr_ShowPayList_zjbf.Visible = true;
                    }
                    else
                    {
                        hidbidPay_zjbf.Value = "0";
                        tr_ShowPayList_zjbf.Visible = false;
                    }
                    if (payrList_zjbf.Count > 0)
                    {
                        rpt_PayrList_zjbf.DataSource = payrList_zjbf;
                        rpt_PayrList_zjbf.DataBind();
                        hidPayr_zjbf.Value = "1";
                        tr_ShowPayrList_zjbf.Visible = true;
                    }
                    else
                    {
                        hidPayr_zjbf.Value = "0";
                        tr_ShowPayrList_zjbf.Visible = false;
                    }
                    if (MoneyList_zjbf.Count > 0)
                    {
                        rpt_MoneyList_zjbf.DataSource = MoneyList_zjbf;
                        rpt_MoneyList_zjbf.DataBind();
                        tr_ShowMoney_zjbf.Visible = true;
                    }
                    else
                    {
                        tr_ShowMoney_zjbf.Visible = false;
                    }

                    if (BidDocList_xmss.Count > 0)
                    {
                        rpt_BidDocList_xmss.DataSource = BidDocList_xmss;
                        rpt_BidDocList_xmss.DataBind();
                        hidBidDoc_xmss.Value = "1";
                        this.tr_showBidDocList_xmss.Visible = true;
                    }
                    if (supDocList_xmss.Count > 0)
                    {
                        rpt_supDocList_xmss.DataSource = supDocList_xmss;
                        rpt_supDocList_xmss.DataBind();
                        hidsupDoc_xmss.Value = "1";
                        this.tr_supDocList_xmss.Visible = true;
                    }
                    if (bidNoticeList_xmss.Count > 0)
                    {
                        rpt_bidNoticeList_xmss.DataSource = bidNoticeList_xmss;
                        rpt_bidNoticeList_xmss.DataBind();
                        hidbidNotice_xmss.Value = "1";
                        this.tr_ShowbidNoticeList_xmss.Visible = true;
                    }
                    if (ContractList_xmss.Count > 0)
                    {
                        rpt_ContractList_xmss.DataSource = ContractList_xmss;
                        rpt_ContractList_xmss.DataBind();
                        hidContract_xmss.Value = "1";
                        this.tr_ShowContractList_xmss.Visible = true;
                    }
                    if (sRecordList_xmss.Count > 0)
                    {
                        rpt_sRecordList_xmss.DataSource = sRecordList_xmss;
                        rpt_sRecordList_xmss.DataBind();
                        this.tr_ShowsRecord_xmss.Visible = true;
                    }
                }
                break;
            case "330116"://资金拨付
                zjbf.Visible = true;
                 twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 206;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_zjbf = fBll.get_InfoList(where);

                    ///获取步骤付款申请附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> PayList_zjbf = allList_zjbf.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "付款申请").ToList();
                    ///获取步骤付款申请审核结果附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> payrList_zjbf = allList_zjbf.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "付款申请审核结果").ToList();
                    ///获取步骤资金拨付签审附件
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> MoneyList_zjbf = allList_zjbf.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "资金拨付签审").ToList();

                    if (PayList_zjbf.Count > 0)
                    {
                        rpt_PayList_zjbf.DataSource = PayList_zjbf;
                        rpt_PayList_zjbf.DataBind();
                        hidbidPay_zjbf.Value = "1";
                        tr_ShowPayList_zjbf.Visible = true;
                    }
                    else
                    {
                        hidbidPay_zjbf.Value = "0";
                        tr_ShowPayList_zjbf.Visible = false;
                    }
                    if (payrList_zjbf.Count > 0)
                    {
                        rpt_PayrList_zjbf.DataSource = payrList_zjbf;
                        rpt_PayrList_zjbf.DataBind();
                        hidPayr_zjbf.Value = "1";
                        tr_ShowPayrList_zjbf.Visible = true;
                    }
                    else
                    {
                        hidPayr_zjbf.Value = "0";
                        tr_ShowPayrList_zjbf.Visible = false;
                    }
                    if (MoneyList_zjbf.Count > 0)
                    {
                        rpt_MoneyList_zjbf.DataSource = MoneyList_zjbf;
                        rpt_MoneyList_zjbf.DataBind();
                        tr_ShowMoney_zjbf.Visible = true;
                    }
                    else
                    {
                        tr_ShowMoney_zjbf.Visible = false;
                    }
                }
                break;
            case "330117"://竣工验收
                jgys.Visible = true;
                twhere.PROJECT_ID = pId;
                twhere.STEP_ID = 207;
                step = vBll.getviewstepAndtype(twhere);
                if (step != null)
                {
                    psId = step.PROJECT_STEP_ID.Value;
                    hidpisID.Value = psId.ToString();
                    where.REF_TYPE = "OA_PROJECT_ARCHIVE";
                    where.REF_ID = psId;
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList_jgys = fBll.get_InfoList(where);
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ApplyList_jgys = allList_jgys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "竣工验收申请").ToList();
                    IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> AccepList_jgys = allList_jgys.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "竣工验收鉴定书").ToList();

                    if (ApplyList_jgys.Count > 0)
                    {
                        rpt_CompList_jgys.DataSource = ApplyList_jgys;
                        rpt_CompList_jgys.DataBind();
                        tr_showApplyList_jgys.Visible = true;
                        hidApply_jgys.Value = "1";
                    }
                    else
                    {
                        tr_showApplyList_jgys.Visible = false;
                        hidApply_jgys.Value = "0";
                    }
                    if (AccepList_jgys.Count > 0)
                    {
                        rpt_AccepList_jgys.DataSource = AccepList_jgys;
                        rpt_AccepList_jgys.DataBind();
                        tr_AccepList_jgys.Visible = true;
                        hidAccep_jgys.Value = "1";
                    }
                    else
                    {
                        tr_AccepList_jgys.Visible = false;
                        hidAccep_jgys.Value = "0";
                    }
                }
                break;
            

        }
    }


    /// <summary>
    /// 绑定界面显示下一步列表
    /// </summary>
    /// <param name="p_steps"></param>
    private void BindDplSkipList(List<PDTech.OA.Model.WORKFLOW_STEP> p_steps)
    {
        this.dplSkipList.Items.Clear();
        foreach (var items in p_steps)
        {
            ListItem item = new ListItem();
            item.Text = items.STEP_NAME;
            item.Value = items.STEP_ID.ToString();
            this.dplSkipList.Items.Add(item);
        }
        if (CurrentAccount.ISHavePurview("chuzhang"))
        {
            this.dplSkipList.Enabled = true;
        }
        else
        {
            this.dplSkipList.Enabled = false;
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
        int Is_szyd = 0;
        decimal ArchiveId = 0;
        decimal Project_Id = 0;
        decimal task_Id = 0;
        try
        {
            if (btnSave.Visible)
            {
                btnSave_Click(null, null);
            }
            if (ArId == 0)
            {
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
                Is_szyd = 0; //int.Parse(dplSzyd.SelectedValue);
                if (!string.IsNullOrEmpty(hidAttachmentIds.Value))
                {
                    Ids = hidAttachmentIds.Value.TrimEnd(',');
                }
                bool result = sBll.Add(query, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, Ids, Is_szyd, out ArchiveId, out Project_Id, out task_Id);
                if (result)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + task_Id + "&action=Handle&projectid=" + Project_Id.ToString() + "'</script>");
                }
                else
                {
                    nPrompt("提交失败", 0);
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
            else if (ViewState["tType"] != null && ViewState["tType"].ToString() == "1")
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
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>window.location.href='RecipientList.aspx?tId=" + contentTask_Id + "&nId=" + dplSkipList.SelectedValue + "&projectid=" + hidprojectid.Value + "'</script>");
            }
        }
        catch
        {

        }
    }
    /// <summary>
    /// 保存当前修改的项目
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
            if (ViewState["End_Flag"] != null && ViewState["End_Flag"].ToString() == "1" && sender == null)
            {
                query.PROJECT_STATUS = 1;
            }
            query.REMARK = txtRemark.Text;//项目备注,可为空
            query.TOP_RESPONSE_DEPT = dplRESPONSE_DEPT.SelectedValue;//主办处室
            query.PROJECT_ID = map.PROJECT_ID;
            bool result = sBll.Update(query, (decimal)ArId);
            //保存当前步骤附件
            Savecurfile();
            if (result)
            {
                if (sender == null)//提交调用保存时，成功不提示，直接跳转页面
                {
                    return;
                }
                nPrompt("保存成功!", 1);
                if (string.IsNullOrEmpty(hidtaskid.Value))
                {
                    contentTask_Id = decimal.Parse(hidtaskid.Value);
                }

                if (hidarchid.Value != "0")
                {
                    ArId = decimal.Parse(hidarchid.Value);
                    InitBind();
                    InitBindData();
                }
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
        PDTech.OA.Model.OA_ARCHIVE_TASK tInfo = tBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_ID = ArId });
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
            fBll.UpdatePID(HidIds, (decimal)ArId, "OA_ARCHIVE", "");
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
                if (ViewState["Creator"] != null)
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();CloseAllFrame();</script>");
        }
    }
    protected void rpt_ExfileList_gh_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            PDTech.OA.Model.OA_ATTACHMENT_FILE item = e.Item.DataItem as PDTech.OA.Model.OA_ATTACHMENT_FILE;
            HyperLink hlDown = e.Item.FindControl("hlDown") as HyperLink;
            HiddenField hidcreateruser = e.Item.FindControl("hidcreateruser") as HiddenField;
            LinkButton lbDel = e.Item.FindControl("lbDel") as LinkButton;
            if (hidcreateruser.Value == CurrentAccount.USER_ID.ToString())
            {
                lbDel.Visible = true;
            }
            else
            {
                lbDel.Visible = false;
            }
            if (hlDown != null)
            {
                hlDown.NavigateUrl = "/DownLoad.aspx?file=" + item.FILE_PATH + "&fullName=" + item.FILE_NAME;
            }
        }
    }
    /// <summary>
    /// 保存当前步骤文件
    /// </summary>
    protected void Savecurfile()
    {
        switch (hidcurstepid.Value.ToString())
        {
            case "330012":
                UpLoadFile(this.fileLoad_gh, "审查意见");
                break;
            case "330013":
                UpLoadFile(this.fileLoad_xmjys, "审查意见");
                UpLoadFile(this.load_plait_xmjys, "编制报告");
                UpLoadFile(this.loadacc_xmjys, "专家评审结果");
                break;
            case "330014":
                UpLoadFile(this.fileArg_kxx, "涉水专项论证");
                UpLoadFile(this.fileLoad_kxx, "审查意见");
                UpLoadFile(this.load_plait_kxx, "编制报告");
                UpLoadFile(this.loadacc_kxx, "专家评审结果");
                break;
            case "330015":
                UpLoadFile(this.fileLoad_cbsj, "定审结果");
                UpLoadFile(this.load_plait_cbsj, "会签结果");
                UpLoadFile(this.loadacc_cbsj, "领导签发");
                break;
            case "330016":
                UpLoadFile(this.fileArg_sgzb, "招标文件");
                UpLoadFile(this.fileLoad_sgzb, "开标监督文件");
                UpLoadFile(this.load_plait_sgzb, "中标通知书");
                UpLoadFile(this.loadacc_sgzb, "合同");
                break;
            case "330017":
                UpLoadFile(this.fileLoad_jsss, "开工备案");
                UpLoadFile(this.load_plait_jsss, "进度管理");
                UpLoadFile(this.loadacc_jsss, "重大设计变更审批");
                break;
            case "330018":
                break;
            case "330019":
                UpLoadFile(this.fileApply_jgys, "竣工验收申请");
                UpLoadFile(this.fileAccep_jgys, "竣工验收鉴定书");
                break;
            case "330010":
                
                break;
            case "330112":
                UpLoadFile(this.fileProEva_sdjh, "申报项目评审");
            UpLoadFile(this.fileProExet_sdjh, "申报项目签审");
                break;
            case "330113":
                UpLoadFile(this.fileProBasis_sbjh, "立项依据");
            UpLoadFile(this.filefPlan_sbjh, "项目资金计划");
                break;
            case "330114":
                UpLoadFile(this.filefPlan_xdjh, "项目资金计划");
                break;
            case "330115":
                UpLoadFile(this.fileBidDoc_xmss, "招标文件");
                UpLoadFile(this.filesupDoc_xmss, "开标监督文件");
                UpLoadFile(this.filebidNotice_xmss, "中标通知书");
                UpLoadFile(this.fileContract_xmss, "合同");
                UpLoadFile(this.filesRecord_xmss, "开工备案");
                UpLoadFile(this.filePay_zjbf, "付款申请");
                UpLoadFile(this.filePayr_zjbf, "付款申请审核结果");
                UpLoadFile(this.fileMoney_zjbf, "资金拨付签审");
                break;
            case "330116":
                UpLoadFile(this.filePay_zjbf, "付款申请");
                UpLoadFile(this.filePayr_zjbf, "付款申请审核结果");
                UpLoadFile(this.fileMoney_zjbf, "资金拨付签审");
                break;
            case "330117":
                UpLoadFile(this.fileApply_jgys, "竣工验收申请");
                UpLoadFile(this.fileAccep_jgys, "竣工验收鉴定书");
                break;

        }
    }
    public void UpLoadFile(System.Web.UI.HtmlControls.HtmlInputFile file, string name)
    {
        PDTech.OA.Model.OA_ATTACHMENT_FILE data = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        try
        {
            string nfileName = "";
            //保存图片到服务器
            string relativeDir = @"/Upload\" + DateTime.Now.ToString("yyyyMM") + @"\";
            string newFileName = System.IO.Path.GetExtension(file.PostedFile.FileName);
            Stream stream = file.PostedFile.InputStream;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            nfileName = BitConverter.ToString((new MD5CryptoServiceProvider()).ComputeHash(bytes)).Replace("-", "");
            //服务器文件路径
            string targetFilePath = Server.MapPath(relativeDir);
            if (!Directory.Exists(targetFilePath))
            {
                Directory.CreateDirectory(targetFilePath);
            }
            file.PostedFile.SaveAs(targetFilePath + @"\" + nfileName + newFileName);

            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            data.FILE_PATH = relativeDir + nfileName + newFileName;
            data.FILE_HASH = nfileName;
            string fileName = file.PostedFile.FileName;
            string fileType = "";
            try
            {
                int fileTypeIndex = fileName.LastIndexOf('.');
                fileType = fileName.Substring(fileTypeIndex + 1).ToLower();
            }
            catch { }
            data.FILE_TYPE = fileType;
            data.FILE_NAME = file.PostedFile.FileName;
            data.FILE_SIZE = bytes.Length;
            data.CREATE_USER = CurrentAccount.USER_ID;
            data.DATA1 = name;
            data.REF_ID = decimal.Parse(hidpisID.Value);
            data.REF_TYPE = "OA_PROJECT_ARCHIVE";
            string att_file_id = "";
            if (!string.IsNullOrEmpty(file.PostedFile.FileName))
                fBll.Add(data, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID, out att_file_id);//
        }
        catch
        {
        }
    }
    protected void rpt_ExfileList_gh_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DelItem")
        {
            decimal atId = Convert.ToDecimal(e.CommandArgument.ToString());

            fBll.Delete(atId);
        }
        BindStepFile();
    }
}