using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Risk_RecipientList : System.Web.UI.Page
{

    public string t_rand = "";
    /****--下一步ID--***/
    string content_nextstepId = "";
    /****--当前任务ID--***/
    string content_taskId = "";
    public string protectDatas = string.Empty;
    string content_operType = "";
    public string IS_ALLOW_MULTI_RECEIVE = "";
    public string isNeedSign = string.Empty; //是否参与签名
    PDTech.OA.BLL.OA_ARCHIVE_TASK taskBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    PDTech.OA.BLL.OA_ARCHIVE archiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.WORKFLOW_STEP stepBll = new PDTech.OA.BLL.WORKFLOW_STEP();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["tId"] != null)
        {
            content_taskId = Request.QueryString["tId"].ToString();
        }
        if (Request.QueryString["nId"] != null)
        {
            content_nextstepId = Request.QueryString["nId"].ToString();
            hidCuurentStepId.Value = Request.QueryString["nId"].ToString();
        }
        if (Request.QueryString["action"] != null)
        {
            content_operType = Request.QueryString["action"].ToString();
            hidAction.Value = Request.QueryString["action"].ToString();
        }
        else
        {
            content_operType = "Handle";
            hidAction.Value = "Handle";
        }
        if (!IsPostBack)
        {
            #region 绑定页面下来框数据
            CurrentAccount.BindEnumDropDownList(typeof(EArchiveNextUser), ddlRemindUser);
            /******获取Xml中配置的提醒时间并绑定到控件******/
            ddlRemindDate.DataSource = AidHelp.GetDataTableFromConfig("TimelyRemindTime");
            ddlRemindDate.DataValueField = "Value";
            ddlRemindDate.DataTextField = "Name";
            ddlRemindDate.DataBind();
            #endregion

            BindData();

            PDTech.OA.Model.OA_ARCHIVE_TASK task = taskBll.GetTaskInfo(decimal.Parse(content_taskId));
            if (task != null)
            {
                //判断是否需要签名
                PDTech.OA.Model.WORKFLOW_STEP step = stepBll.GetStepInfo(task.CURRENT_STEP_ID.Value);
                isNeedSign = step.IS_NEED_SIGN;
                if (isNeedSign == "1")
                {
                    //获取盖章时需要保护的数据
                    PDTech.OA.Model.OA_ARCHIVE archive = archiveBll.GetArchiveInfo(task.ARCHIVE_ID.Value);
                    protectDatas = archive.ARCHIVE_TITLE + "=&" + archive.ARCHIVE_CONTENT + "=&";
                    PDTech.OA.Model.OA_ARCHIVE_TASK oaTask = new PDTech.OA.Model.OA_ARCHIVE_TASK();
                    oaTask.ARCHIVE_ID = task.ARCHIVE_ID;
                    IList<PDTech.OA.Model.OA_ARCHIVE_TASK> list = taskBll.get_TaskInfoList(oaTask);
                    if (list != null && list.Count > 0)
                    {
                        int count = 0;
                        foreach (PDTech.OA.Model.OA_ARCHIVE_TASK item in list)
                        {
                            count += 1;
                            if (list.Count == count)
                            {
                                protectDatas += item.ARCHIVE_TASK_ID + "=";
                            }
                            else
                            {
                                protectDatas += item.ARCHIVE_TASK_ID + "=" + item.TASK_REMARK + "&";
                            }
                        }
                    }
                }
            }
        }
    }
    public void BindData()
    {
        PDTech.OA.Model.OA_ARCHIVE_TASK currentTask = taskBll.GetTaskInfo(new PDTech.OA.Model.OA_ARCHIVE_TASK() { ARCHIVE_TASK_ID = decimal.Parse(content_taskId) });
        PDTech.OA.Model.OA_ARCHIVE archiveInfo = archiveBll.GetArchiveInfo((decimal)currentTask.ARCHIVE_ID);
        PDTech.OA.Model.WORKFLOW_STEP stepInfo = stepBll.GetStepInfo((decimal)archiveInfo.CURRENT_STEP_ID);
        PDTech.OA.Model.WORKFLOW_STEP nstepInfo = stepBll.GetStepInfo(decimal.Parse(content_nextstepId));
        IS_ALLOW_MULTI_RECEIVE = nstepInfo.IS_ALLOW_MULTI_RECEIVE;
        hidArchiveId.Value = currentTask.ARCHIVE_ID.ToString();
        hidArchiveType.Value = archiveInfo.ARCHIVE_TYPE.Value.ToString();
        hidTaskID.Value = content_taskId;
        hidCode.Value = stepInfo.RIGHT_CODE;
        if (!string.IsNullOrEmpty(content_operType) && content_operType == "copy")
        {
            deadline.Visible = false;
            workdeadline.Visible = false;
            TipsDate.Visible = false;
        }
        if (stepInfo.IS_RETURN_TO_RESPONSE_USER == "1" && content_operType != "copy")
        {
            ViewState["Is_return"] = stepInfo.IS_RETURN_TO_RESPONSE_USER;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>hidTree();</script>");
        }
        if (stepInfo.END_FLAG == "1")
        {
            ViewState["endFlag"] = stepInfo.END_FLAG;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>hidTree();</script>");
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            #region 公文抄送
            if (!string.IsNullOrEmpty(content_operType) && content_operType == "copy")
            {
                PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
                where.P_TASK_ID = decimal.Parse(content_taskId);
                if (!string.IsNullOrEmpty(hidUserList.Value.TrimEnd(',')))
                {
                    where.P_NEXT_USER_LIST = hidUserList.Value.TrimEnd(',');
                }
                else
                {
                    nPrompt("请选择接收人员!", 0);
                    return;
                }
                if (IS_SEND_SMS_NOW.Checked == true)
                {
                    where.P_IS_SEND_SMS_NOW = 1;
                }
                else { where.P_IS_SEND_SMS_NOW = 0; }
                int result = 0;
                result = taskBll.ArchiveCopy(where);
                if (result == 1)
                {
                    nPrompt("提交成功!", 1);
                }
                else
                {
                    nPrompt("提交失败!", 0);
                }
            }
            #endregion

            #region 公文办理提交
            else if (string.IsNullOrEmpty(content_operType) || content_operType == "Handle")
            {
                PDTech.OA.Model.Pro_TASKHandle where = new PDTech.OA.Model.Pro_TASKHandle();
                where.P_TASK_ID = decimal.Parse(content_taskId);
                if (!string.IsNullOrEmpty(txtInComingDate.Text.Trim()))
                {
                    where.P_LIMIT_TIME = new ConvertHelper(txtInComingDate.Text).ToDateTime.Value.Date.AddMilliseconds(86399); ;
                    if (where.P_LIMIT_TIME < DateTime.Now.AddDays(-1))
                    {
                        nPrompt("办理时限不能小于当前日期!", 0);
                        return;
                    }
                    where.P_SMS_LIMIT_TIME = Convert.ToDateTime(txtInComingDate.Text).AddHours(Convert.ToDouble(ddlRemindDate.SelectedValue));
                }
                else
                {
                    nPrompt("办理时限不能为空!", 0);
                    return;
                }
                if (!string.IsNullOrEmpty(txtIdea.Value.Trim()))
                {
                    where.P_TASK_REMARK = AidHelp.FilterSpecial(txtIdea.Value);
                }
                if (IS_SEND_SMS_LIMIT.Checked == true)
                {
                    where.P_IS_SEND_SMS_LIMIT = 1;
                }
                else { where.P_IS_SEND_SMS_LIMIT = 0; }

                if (IS_SEND_SMS_NOW.Checked == true)
                {
                    where.P_IS_SEND_SMS_NOW = 1;
                }
                else { where.P_IS_SEND_SMS_NOW = 0; }
                if (ViewState["endFlag"] == null)
                {
                    where.P_NEXT_STEP_ID = decimal.Parse(content_nextstepId);
                }
                if (!string.IsNullOrEmpty(hidUserList.Value.TrimEnd(',')))
                {
                    where.P_NEXT_USER_LIST = hidUserList.Value.TrimEnd(',');
                    where.P_NEXT_USER_LIST = where.P_NEXT_USER_LIST.TrimStart(',');
                }
                else if (ViewState["Is_return"] != null && ViewState["Is_return"].ToString() == "1")
                {
                    where.P_NEXT_USER_LIST = "";
                }
                else if (ViewState["endFlag"] != null && ViewState["endFlag"].ToString() == "1")//最后一步
                {
                    where.P_NEXT_USER_LIST = "";
                }
                else
                {
                    nPrompt("请选择接收人员!", 0);
                    return;
                }
                where.P_SMS_TO_USER_TYPE = decimal.Parse(ddlRemindUser.SelectedValue);
                //where.P_PROTECT_DATA = Request["hidProtectedData"].ToString();
                int result = 0;
                result = taskBll.ArchiveHandle(where);
                if (result == 1)
                {
                    //nPrompt("提交成功!", 1);

                    //如果用户盖了章，还要保存印章信息
                    string sealdata = Request["sealdata"].ToString();
                    if (!string.IsNullOrEmpty(sealdata))
                    {
                        bool r = taskBll.UpdateSealData(decimal.Parse(content_taskId), sealdata);

                        if (r)
                        {
                            nPrompt("提交成功!", 1);
                        }
                        else
                        {
                            nPrompt("签章失败!", 0);
                        }
                    }
                    else
                    {
                        nPrompt("提交成功!", 1);
                    }
                }
                else
                {
                    nPrompt("提交失败!", 0);
                }
            }
            #endregion

            #region 处理抄送公文任务


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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh();window.parent.layer.closeAll();</script>");
        }
    }
}