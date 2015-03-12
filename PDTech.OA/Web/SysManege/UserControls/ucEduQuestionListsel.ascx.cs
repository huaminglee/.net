using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


public partial class SysManege_UserControls_ucEduQuestionListsel : System.Web.UI.UserControl
{
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
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
        IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            quesList = quesBll.Get_Paging_List(title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            quesList = quesBll.Get_Paging_List(null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        rpt_QuestionList.DataSource = quesList;
        rpt_QuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>window.location.href='/DownLoad.aspx?file=/Upload/Template/在线考试试题模版.xls&fullName=在线考试试题模板.xls';</script>");
    }

    
}