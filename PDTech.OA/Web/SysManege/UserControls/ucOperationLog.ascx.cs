using System;
using System.Collections.Generic;
using System.Text;

public partial class SysManege_UserControls_ucOperationLog : System.Web.UI.UserControl
{
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    PDTech.OA.BLL.OPERATION_LOG logBll = new PDTech.OA.BLL.OPERATION_LOG();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OPERATION_LOG> logList = new List<PDTech.OA.Model.OPERATION_LOG>();
        string startTime = AidHelp.FilterSpecial(txtStartTime.Text);
        string endTime = txtEndTime.Text;
        string content = txtContent.Text;
        string loginName = AidHelp.FilterSpecial(txtLoginName.Text);
        StringBuilder sb = new StringBuilder();
        sb.Append("select * from OPERATION_LOG where 1=1 ");
        if (!string.IsNullOrEmpty(startTime))
        {
            sb.Append("and OPERATION_TIME >= CONVERT(DATETIME,'" + startTime + "',120) ");
        }
        if (!string.IsNullOrEmpty(endTime))
        {
            sb.Append("and OPERATION_TIME <= CONVERT(DATETIME,'" + endTime + "',120) ");
        }
        if (!string.IsNullOrEmpty(content))
        {
            sb.Append("and OPERATION_DESC like '%" + content + "%' ");
        }
        if (!string.IsNullOrEmpty(loginName))
        {
            sb.Append("and OPERATOR_USER = (select USER_ID from USER_INFO where FULL_NAME = '" + loginName + "') ");
        }
        logList = logBll.get_Paging_LogInfoList(sb.ToString(), AspNetPager.CurrentPageIndex, AspNetPager.PageSize, out record);
        rpt_OperationLogList.DataSource = logList;
        rpt_OperationLogList.DataBind();
        AspNetPager.RecordCount = record;
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }

    public string CutLength(string content)
    {
        if (content.Length > 70)
        {
            return content.Substring(0, 71);
        }
        return content;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}