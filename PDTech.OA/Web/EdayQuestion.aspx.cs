using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EdayQuestion : System.Web.UI.Page
{
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.BLL.OA_EDAYQUESTION edayBll = new PDTech.OA.BLL.OA_EDAYQUESTION();
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["user_id"] == null)
            {
                Response.Write("<script language=javascript>window.location.href='Login.aspx';</script>");
            }
            else
            {
                if (Request.QueryString["eqid"] != null && Request.QueryString["eqid"] != string.Empty)
                {
                    hidbuzuoquestionid.Value = Request.QueryString["eqid"];
                }
                BindData();
            }
        }
    }

    private void BindData()
    {
        if (string.IsNullOrEmpty(hidbuzuoquestionid.Value))
        {
            //随机显示一道试题
            IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = quesBll.GetModelList("");
            Random rand = new Random();
            int i = rand.Next(0, quesList.Count);
            if (quesList[i] != null)
            {
                lbTitle.Text = quesList[i].TITLE;
                rblOption.Items.Add(new ListItem("A、" + quesList[i].OPTIONA, "A"));
                rblOption.Items.Add(new ListItem("B、" + quesList[i].OPTIONB, "B"));
                rblOption.Items.Add(new ListItem("C、" + quesList[i].OPTIONC, "C"));
                if (!string.IsNullOrEmpty(quesList[i].OPTIOND))
                {
                    rblOption.Items.Add(new ListItem("D、" + quesList[i].OPTIOND, "D"));
                }
                hidQuestionId.Value = quesList[i].EDU_Q_GUID;
                hidScore.Value = quesList[i].SCORE.ToString();
                hidAnswer.Value = quesList[i].ANSWER;
                switch (quesList[i].ANSWER)
                {
                    case "A":
                        hidAnswerTitle.Value = quesList[i].OPTIONA;
                        break;
                    case "B":
                        hidAnswerTitle.Value = quesList[i].OPTIONB;
                        break;
                    case "C":
                        hidAnswerTitle.Value = quesList[i].OPTIONC;
                        break;
                    case "D":
                        hidAnswerTitle.Value = quesList[i].OPTIOND;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else
        {
            PDTech.OA.Model.OA_EDUQUESTION ques = quesBll.GetModel(hidbuzuoquestionid.Value);
            
            if (ques != null)
            {
                lbTitle.Text = ques.TITLE;
                rblOption.Items.Add(new ListItem("A、" + ques.OPTIONA, "A"));
                rblOption.Items.Add(new ListItem("B、" + ques.OPTIONB, "B"));
                rblOption.Items.Add(new ListItem("C、" + ques.OPTIONC, "C"));
                if (!string.IsNullOrEmpty(ques.OPTIOND))
                {
                    rblOption.Items.Add(new ListItem("D、" + ques.OPTIOND, "D"));
                }
                hidQuestionId.Value = ques.EDU_Q_GUID;
                hidScore.Value = ques.SCORE.ToString();
                hidAnswer.Value = ques.ANSWER;
                switch (ques.ANSWER)
                {
                    case "A":
                        hidAnswerTitle.Value = ques.OPTIONA;
                        break;
                    case "B":
                        hidAnswerTitle.Value = ques.OPTIONB;
                        break;
                    case "C":
                        hidAnswerTitle.Value = ques.OPTIONC;
                        break;
                    case "D":
                        hidAnswerTitle.Value = ques.OPTIOND;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_EDAYQUESTION model = new PDTech.OA.Model.OA_EDAYQUESTION();
        model.EDU_Q_GUID = hidQuestionId.Value;
        model.ANSWER_PERSON = CurrentAccount.USER_ID;
        model.ANSWER = rblOption.SelectedValue;
        model.ANSWER_TIME = DateTime.Now;

        if (hidAnswer.Value != rblOption.SelectedValue)
        {
            if (rblOption.SelectedValue != "")
            {
                int curtimes=int.Parse(hidanswertimes.Value);
                curtimes++;
                hidanswertimes.Value = curtimes.ToString();
                //插入记录，状态为2=回答错误
                model.SCORE = 0;
                model.STATE = 2;
               // edayBll.Add(model);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回答错误')</script>");
               
            }
            //else
            //{
            //    Page.Session.Abandon();
            //    Response.Write("<script language=javascript>alert('您还未答题！')</script>");
            //    Response.Write("<script language=javascript>window.location.href='Login.aspx';</script>");
            //    Response.End();
            //}
        }
        else
        {
            int curtimes = int.Parse(hidanswertimes.Value);
            curtimes++;
            hidanswertimes.Value = curtimes.ToString();
            //插入记录，状态为1=回答正确，当天再次登录不用弹出该页面
            //10月11 修改 state 用来存答题次数
            model.SCORE = decimal.Parse(hidScore.Value);
            model.STATE = int.Parse(hidanswertimes.Value);
            edayBll.Add(model);
            Response.Write("<script language=javascript>alert('恭喜您回答正确，预祝您工作愉快！');</script>");
            if (string.IsNullOrEmpty(hidbuzuoquestionid.Value))
            {
                Response.Write("<script language=javascript>window.location.href='MainBoard.aspx';</script>");
            }
            else
            {
                Response.Write("<script language=javascript>window.parent.doRefresh();window.parent.layer.closeAll();</script>");
            }
            
        }
        
    }

    protected void btnSkip_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_EDAYQUESTION model = new PDTech.OA.Model.OA_EDAYQUESTION();
        model.EDU_Q_GUID = hidQuestionId.Value;
        model.ANSWER_PERSON = CurrentAccount.USER_ID;
        model.ANSWER = rblOption.SelectedValue;
        model.ANSWER_TIME = DateTime.Now;
        model.SCORE = 0;
        model.STATE = 3;    //3=跳过
        edayBll.Add(model);
        Response.Write("<script language=javascript>window.location.href='MainBoard.aspx';</script>");
    }
}