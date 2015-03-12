using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_EdayQuestionDetail : System.Web.UI.Page
{
    public string t_rand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        string edayId = Request.QueryString["eday_id"];
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(edayId))
            {
                ShowDetail(decimal.Parse(edayId));
            }
        }
    }

    private void ShowDetail(decimal edayId)
    {
        PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
        PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
        PDTech.OA.Model.OA_EDAYQUESTION edayModel = edayBll.GetModel(edayId);
        PDTech.OA.Model.OA_EDUQUESTION quesModel = quesBll.GetModel(edayModel.EDU_Q_GUID);
        lbTitle.Text = quesModel.TITLE;
        lbOptionA.Text = "A、" + quesModel.OPTIONA;
        lbOptionB.Text = "B、" + quesModel.OPTIONB;
        lbOptionC.Text = "C、" + quesModel.OPTIONC;
        if (!string.IsNullOrEmpty(quesModel.OPTIOND))
        {
            lbOptionD.Text = "D、" + quesModel.OPTIOND;
        }
        lbSelected.Text = edayModel.ANSWER;
        lbAnswer.Text = quesModel.ANSWER;
        lbScore.Text = edayModel.SCORE.ToString();
        lbSelectedTime.Text = edayModel.ANSWER_TIME.ToString();
    }
}