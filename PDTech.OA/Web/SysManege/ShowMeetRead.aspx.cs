using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_ShowMeetRead : System.Web.UI.Page
{
    public string t_rand = "";
    string mId = "";
    PDTech.OA.BLL.OA_MEETING_RECEIVER meetRBll = new PDTech.OA.BLL.OA_MEETING_RECEIVER();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");

        if (Request.QueryString["Mid"] != null)
        {
            mId = Request.QueryString["Mid"].ToString();
        }

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(mId))
            {
                BindMeetingData();
            }
        }
    }

    private void BindMeetingData()
    {
        string strWhere = " MEETING_ID = " + mId;
        List<PDTech.OA.Model.OA_MEETING_RECEIVER> allList = meetRBll.GetModelList(strWhere);
        List<PDTech.OA.Model.OA_MEETING_RECEIVER> noreadList = allList.FindAll(delegate(PDTech.OA.Model.OA_MEETING_RECEIVER t) { return t.READ_STATUS == 0; });
        int count = allList.RemoveAll(delegate(PDTech.OA.Model.OA_MEETING_RECEIVER t) { return noreadList.Contains(t); });
        List<PDTech.OA.Model.OA_MEETING_RECEIVER> readList = allList;
        string nReadNames = "";
        foreach (var item in noreadList)
        {
            nReadNames += GetUserName(item.RECEIVER_ID.Value) + ",";
        }
        txtUserNames.Text = nReadNames.TrimEnd(',');
        rpt_UserList.DataSource = readList;
        rpt_UserList.DataBind();
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }
}