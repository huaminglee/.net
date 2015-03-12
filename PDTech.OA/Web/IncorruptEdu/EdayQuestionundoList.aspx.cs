using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_EdayQuestionundoList : System.Web.UI.Page
{
    string strwhere;
    public string t_rand = "";
    PDTech.OA.BLL.OA_EDUQUESTION edubll = new PDTech.OA.BLL.OA_EDUQUESTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txteTime.Text = DateTime.Now.ToShortDateString();
            if (DateTime.Now.Day > 26)
            {
                BindData();
            }
            
        }
    }
    private void BindData()
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        int record = 0;
        IList<PDTech.OA.Model.OA_EDUQUESTION> edayList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        //strwhere = new StringBuilder();
        //strwhere.Append(string.Format(" ANSWER_PERSON={0}", CurrentAccount.USER_ID));
        //if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        //{
        //    strwhere.Append(string.Format(@" AND DATEDIFF(DAY,ANSWER_TIME,'{0}')<=0", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd"))));
        //}
        //if (!string.IsNullOrEmpty(txteTime.Text.Trim()))
        //{
        //    strwhere.Append(string.Format(@" AND DATEDIFF(DAY,ANSWER_TIME,'{0}')>=0 ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd"))));
        //}
        strwhere = string.Format("ANSWER_PERSON={0} and ANSWER_TIME>=(CONVERT(varchar(7), getdate() , 120) + '-1')",CurrentAccount.USER_ID.ToString());
        edayList = edubll.Get_Paging_List_ByCondition(strwhere, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        
        rpt_EdayQuestionList.DataSource = edayList;
        rpt_EdayQuestionList.DataBind();
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
}