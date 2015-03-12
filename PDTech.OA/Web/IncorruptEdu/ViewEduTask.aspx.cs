using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_ViewEduTask : System.Web.UI.Page
{
    public string t_rand = "";
    string eduId = string.Empty;
    string flag = string.Empty;
    PDTech.OA.BLL.OA_RISKEDUCATION riskBll = new PDTech.OA.BLL.OA_RISKEDUCATION();
    PDTech.OA.BLL.OA_ATTACHMENT_FILE fBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.OA_RISKEDURECEIVER riskReBll = new PDTech.OA.BLL.OA_RISKEDURECEIVER();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            eduId = Request.QueryString["edu_id"];
            flag = Request.QueryString["flag"];
            if (!string.IsNullOrEmpty(eduId))
            {
                ShowDetail(decimal.Parse(eduId));
            }
        }
    }

    private void ShowDetail(decimal eduId)
    {
        PDTech.OA.Model.OA_RISKEDUCATION model = riskBll.GetModel(eduId);
        hideuid.Value = eduId.ToString();
        lbTitle.Text = model.TITLE;
        lbType.Text = model.FILETYPE;
        lbCreator.Text = GetUserName(model.CREATOR.Value);
        lbCreatTime.Text = model.CREATETIME.Value.ToString("yyyy-MM-dd HH:mm:ss");
        lbCompany.Text = model.COMPANY;
        lbReceiver.Text = GetReceiveUser(eduId);
        lbhopefinishtime.Text = model.HOPEFINISHTIME.Value.ToString("yyyy-MM-d");
        if (model.REMARK.IndexOf("#regionvidoe") > -1)
        {
            string videos = model.REMARK.Substring(model.REMARK.IndexOf("#regionvidoe")+12);
            txtRemark.Text = model.REMARK.Substring(0, model.REMARK.IndexOf("#regionvidoe"));
            hidvideos.Value = videos;
        }
        else
        {
            txtRemark.Text = model.REMARK;
            hidvideos.Value = "0";
        }
        

        //绑定附件
        IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> attList = new List<PDTech.OA.Model.OA_ATTACHMENT_FILE>();
        attList = fBll.get_InfoList(new PDTech.OA.Model.OA_ATTACHMENT_FILE() { Append = string.Format(@" REF_ID={0} AND REF_TYPE='OA_EDUCATION' ", eduId) });
        rpt_AttachmentList.DataSource = attList;
        rpt_AttachmentList.DataBind(); 
        if (attList != null && attList.Count > 0)
        {
            tr_showList.Visible = true;
        }

        //修改状态为已读;如果有视频资料则需看完视频后再修改为已读
        if (string.IsNullOrEmpty(flag) && model.REMARK.IndexOf("#regionvidoe")<0)
        {
            PDTech.OA.Model.OA_RISKEDURECEIVER cache = riskReBll.GetModel(eduId, CurrentAccount.USER_ID);
            if (cache != null)
            {
                if (cache.READ_STATUS == 0)
                {
                    PDTech.OA.Model.OA_RISKEDURECEIVER newModel = new PDTech.OA.Model.OA_RISKEDURECEIVER();
                    newModel.EDUCATION_ID = eduId;
                    newModel.RECEIVER_ID = CurrentAccount.USER_ID;
                    newModel.READ_STATUS = 1;
                    newModel.READ_TIME = DateTime.Now;
                    newModel.READ_COUNT = 1;
                    bool result = riskReBll.UpdateState(newModel);
                }
                else
                { 
                    //更新阅读次数
                    bool result = riskReBll.UpdateReadCount(eduId, CurrentAccount.USER_ID);
                }
            }
        }  
    }

    private string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    private string GetReceiveUser(decimal eduId)
    {
        string userNames = string.Empty;
        string strWhere = " EDUCATION_ID = " + eduId;
        List<PDTech.OA.Model.OA_RISKEDURECEIVER> list = riskReBll.GetModelList(strWhere);
        if (list != null && list.Count > 0)
        {
            foreach (PDTech.OA.Model.OA_RISKEDURECEIVER item in list)
            {
                if (userNames.Length > 0)
                {
                    userNames += "," + GetUserName(item.RECEIVER_ID.Value);
                }
                else
                {
                    userNames += GetUserName(item.RECEIVER_ID.Value);
                }
            }
        }
        return userNames;
    }

    /// <summary>
    /// 附件下载
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
    protected void btnfinishvideo_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_RISKEDURECEIVER cache = riskReBll.GetModel(decimal.Parse(hideuid.Value), CurrentAccount.USER_ID);
        if (cache != null)
        {
            if (cache.READ_STATUS == 0)
            {
                PDTech.OA.Model.OA_RISKEDURECEIVER newModel = new PDTech.OA.Model.OA_RISKEDURECEIVER();
                newModel.EDUCATION_ID = decimal.Parse(hideuid.Value);
                newModel.RECEIVER_ID = CurrentAccount.USER_ID;
                newModel.READ_STATUS = 1;
                newModel.READ_TIME = DateTime.Now;
                newModel.READ_COUNT = 1;
                bool result = riskReBll.UpdateState(newModel);
                Response.Write("<script language=javascript>alert('你已完成本次教育任务')</script>");
            }
            else
            {
                //更新阅读次数
                bool result = riskReBll.UpdateReadCount(decimal.Parse(hideuid.Value), CurrentAccount.USER_ID);
            }
        }
    }
}