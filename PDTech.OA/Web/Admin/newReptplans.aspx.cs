using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

public partial class Admin_newReptplans : System.Web.UI.Page
{
    public string t_rand = "";//css 或者JS  时间戳
    decimal psId = 0;
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.VIEW_PRO_STEP_TYPE vBll = new PDTech.OA.BLL.VIEW_PRO_STEP_TYPE();
    PDTech.OA.BLL.SW_PROJECT_STEP sBll = new PDTech.OA.BLL.SW_PROJECT_STEP();
    PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["psId"] != null)
        {
            psId = decimal.Parse(Request.QueryString["psId"].ToString());
        }
        if (Request.QueryString["Isedit"] != null)
        {
            hidisedit.Value = Request.QueryString["Isedit"].ToString();
        }
        if (Request.QueryString["tId"] != null)
        {
            hidtaskid.Value = Request.QueryString["tId"].ToString();
        }
        if (!IsPostBack && psId != 0)
        {
            InitBindData();
        }
    }


    /// <summary>
    /// 获取并绑定数据
    /// </summary>
    public void InitBindData()
    {
        PDTech.OA.Model.VIEW_PRO_STEP_TYPE vInfo = vBll.getviewstepAndtype(new PDTech.OA.Model.VIEW_PRO_STEP_TYPE() { PROJECT_STEP_ID = psId });
        PDTech.OA.BLL.RISK_POINT_INFO rpi_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
        if (vInfo != null)
        {
            /***风险防控--开始***/
            DataTable dt = rpi_bll.GetRiskPointInfo("SW_PROJECT_STEP", vInfo.STEP_ID.ToString());//查询风险防控
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
            txtRemark.Text = vInfo.REMARK;
            tr_Opinion.Visible = true;
            hidstate.Value = vInfo.STEP_STATUS.ToString();
            txtPlan_EndTIME.Value = vInfo.PLAN_ENDTIME == null ? "" : vInfo.PLAN_ENDTIME.Value.ToString("yyyy-MM-dd");
            dplIs_End.SelectedValue = vInfo.STEP_STATUS == 9 ? "1" : "0";
            if (vInfo.STEP_STATUS != 9)
                btnSubmit.Visible = false;
            else
                btnSubmit.Visible = true;
            hidPId.Value = vInfo.PROJECT_ID.ToString();
            hidLogID.Value = vInfo.ATTRIBUTE_LOG.ToString();


            #region 获取扩展属性

            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)vInfo.ATTRIBUTE_LOG });
            if (attList.Count > 0)
            {
                btnSubmit.Visible = false;
                foreach (var item in attList)
                {
                    switch (item.KEY)
                    {
                        case "REVIEWER":
                            lblUserName.Text = item.VALUE;
                            break;
                        case "AUDITDATE":
                            lblAuditDate.Text = AidHelp.ShortTime(item.VALUE);
                            break;
                    }
                }
            }
            #endregion
        }
        #region 获取审查意见附件
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        where.REF_TYPE = "OA_PROJECT_ARCHIVE";
        where.REF_ID = psId;
        ///获取此步骤的所有附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> allList = fBll.get_InfoList(where);

        ///获取步骤审查意见附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> ProBasisList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "立项依据").ToList();
        ///获取步骤审查意见附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> fPlanList = allList.Where(o => !string.IsNullOrEmpty(o.DATA1) && o.DATA1 == "项目资金计划").ToList();
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> aList = allList.Where(o => string.IsNullOrEmpty(o.DATA1)).ToList();
        #region 判定并绑定附件数据
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
        if (ProBasisList.Count > 0)
        {
            rpt_ProBasisList.DataSource = ProBasisList;
            rpt_ProBasisList.DataBind();
            tr_showProBasisList.Visible = true;
            hidProBasis.Value = "1";
        }
        else
        {
            tr_showProBasisList.Visible = false;
            hidProBasis.Value = "0";
        }
        if (fPlanList.Count > 0)
        {
            rpt_fPlanList.DataSource = fPlanList;
            rpt_fPlanList.DataBind();
            tr_fPlanList.Visible = true;
        }
        else
        {
            tr_fPlanList.Visible = false;
        }
        #endregion
        #endregion
    }


    protected void rpt_ProBasisList_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rpt_fPlanList_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
    /// 附件删除处理
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
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
                fBll.Delete(atId);
            }
        }
        uBindData();
        InitBindData();
    }
    /// <summary>
    /// 绑定附件
    /// </summary>
    public void uBindData()
    {
        PDTech.OA.Model.OA_ATTACHMENT_FILE where = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        if (!string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            if (!string.IsNullOrEmpty(HidIds))
                where.Append = string.Format(" ATTACHMENT_FILE_ID IN({0}) ", HidIds);
            if (!string.IsNullOrEmpty(psId.ToString()) && psId != 0 && !string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" OR ( REF_ID={0} AND REF_TYPE='OA_PROJECT_ARCHIVE' AND DATA1 IS NULL)", psId);
            if (!string.IsNullOrEmpty(psId.ToString()) && psId != 0 && string.IsNullOrEmpty(where.Append))
                where.Append += string.Format(@" REF_ID={0} AND REF_TYPE='OA_PROJECT_ARCHIVE' AND DATA1 IS NULL ", psId);
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
        if (psId != 0 && !string.IsNullOrEmpty(hidAttachmentIds.Value.Trim()))
        {
            string HidIds = hidAttachmentIds.Value.TrimEnd(',');
            fBll.UpdatePID(HidIds, psId, "OA_PROJECT_ARCHIVE", "");
        }
    }
    /// <summary>
    /// 友好提示
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.layer.closeAll();</script>");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            PDTech.OA.Model.SW_PROJECT_STEP where = new PDTech.OA.Model.SW_PROJECT_STEP();
            where.PROJECT_STEP_ID = psId;
            if (dplIs_End.SelectedValue == "1")
            {
                where.STEP_STATUS = 9;
                where.END_TIME = DateTime.Now;
            }
            else
            {
                where.STEP_STATUS = 1;
            }
            where.OWNER = CurrentAccount.USER_ID;
            where.REMARK = txtRemark.Text;
            where.PLAN_ENDTIME = new ConvertHelper(txtPlan_EndTIME.Value).ToDateTime;
            UpLoadFile(this.fileProBasis, "立项依据");
            UpLoadFile(this.filefPlan, "项目资金计划");
            bool result = false;
            if (hidstate.Value == "0")
            {
                where.START_TIME = DateTime.Now;
                result = sBll.FirstUpdate(where);
            }
            else
            { result = sBll.Update(where); }
            if (result)
            {
                nPrompt("保存成功!", 1);
                InitBindData();
            }
            else
            {
                nPrompt("保存失败!", 0);
            }
        }
        catch (Exception ex)
        {
        }
    }


    /// <summary>
    /// 审核意见附件上传
    /// </summary>
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
            data.REF_ID = psId;
            data.REF_TYPE = "OA_PROJECT_ARCHIVE";
            string att_file_id = "";
            if (!string.IsNullOrEmpty(file.PostedFile.FileName))
                fBll.Add(data, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID, out att_file_id);//
        }
        catch
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchList_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.fileProBasis.PostedFile.FileName))
            UpLoadFile(this.fileProBasis, "立项依据");
        if (!string.IsNullOrEmpty(this.filefPlan.PostedFile.FileName))
            UpLoadFile(this.filefPlan, "项目资金计划");
        uBindData();
        InitBindData();
    }
    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        try
        {
            IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
            attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "REVIEWER", VALUE = CurrentAccount.FULL_NAME });
            attList.Add(new PDTech.OA.Model.ATTRIBUTES() { KEY = "AUDITDATE", VALUE = DateTime.Now.ToString() });
            bool result = false;
            result = sBll.FirstAudit(decimal.Parse(hidLogID.Value), attList);
            if (result)
            {
                nPrompt("审核成功!", 1);
                InitBindData();
            }
            else
            {
                nPrompt("审核失败!", 0);
            }
        }
        catch (Exception ex)
        {
        }
    }
}