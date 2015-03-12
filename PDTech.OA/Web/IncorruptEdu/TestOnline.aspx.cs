using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncorruptEdu_TestOnline : System.Web.UI.Page
{
    public string t_rand = "";
    string testId = string.Empty;
    string key = string.Empty;
    string answerGuid = string.Empty;
    string xmlPath = string.Empty;
    int CountIndex = 0;
    public PageNumbers np;
    //PDTech.OA.Model.OA_EDUTEST testModel = new PDTech.OA.Model.OA_EDUTEST();
    IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
    PDTech.OA.BLL.OA_EDUTEST testBll = new PDTech.OA.BLL.OA_EDUTEST();
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.BLL.OA_QUESTION_TEST_MAP mapBll = new PDTech.OA.BLL.OA_QUESTION_TEST_MAP();
    public PDTech.OA.Model.TestOnline toModel = new PDTech.OA.Model.TestOnline();
    PDTech.OA.BLL.OA_TEST_ANSWER answerBll = new PDTech.OA.BLL.OA_TEST_ANSWER();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        testId = Request.QueryString["test_id"];
        //判断是否已经做过该试卷
        if (answerBll.GetIsAnswerCount(CurrentAccount.USER_ID, testId) > 0)
        {
            string answerId = answerBll.GetAnswerIdByTestId(CurrentAccount.USER_ID, testId);
            Response.Write("<script language=javascript>alert('您已经做过该试卷，系统将自动跳转到查看结果页面！');window.location.href='/IncorruptEdu/ViewTestOnlineResult.aspx?t_id=" + testId + "&a_id=" + answerId + "';</script>");
            Response.End();
        }       

        key = Request.QueryString["key"];
        answerGuid = BasePage.getGUID(CurrentAccount.USER_ID.ToString() + key);
        np = new PageNumbers(3); 

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(testId))
            {
                BindData(testId);
                CountIndex = (quesList.Count - 1) / np.PageCount + 1; //总页数
                np.StartPosition = 1;
                hidPageIndex.Value = (np.StartPosition / np.PageCount + 1).ToString();
                np.PageIndex = int.Parse(hidPageIndex.Value);
                isShowButton(CountIndex);

                PDTech.OA.Model.OA_EDUTEST testModel = testBll.GetModel(testId);
                lbTestName.Text = testModel.TESTNAME;
                toModel.TestName = testModel.TESTNAME;
                toModel.TestCount = testModel.TESTCOUNT.Value;
                toModel.TestScore = testModel.SCORE.Value;
                List<PDTech.OA.Model.Question> list = new List<PDTech.OA.Model.Question>();
                PDTech.OA.Model.Question quesModel = null;
                foreach (PDTech.OA.Model.OA_EDUQUESTION item in quesList)
                {
                    quesModel = new PDTech.OA.Model.Question();
                    quesModel.QuestionID = item.EDU_Q_GUID;
                    quesModel.Title = item.TITLE;
                    quesModel.OptionA = item.OPTIONA;
                    quesModel.OptionB = item.OPTIONB;
                    quesModel.OptionC = item.OPTIONC;
                    if (!string.IsNullOrEmpty(item.OPTIOND))
                    {
                        quesModel.OptionD = item.OPTIOND;
                    }
                    quesModel.CorrectResult = item.ANSWER;
                    quesModel.QuestionValue = item.SCORE.Value;
                    list.Add(quesModel);
                }
                toModel.QuestionCollection = list;
                xmlPath = Server.MapPath("~/App_Resources/XML/" + answerGuid + ".xml");
                if (File.Exists(xmlPath))
                {
                    toModel = XmlHelper.Xml2Obj(xmlPath, typeof(PDTech.OA.Model.TestOnline)) as PDTech.OA.Model.TestOnline;
                }
                else
                {
                    //直接保存成文件，下次将使用
                    XmlHelper.Obj2Xml(toModel, xmlPath);
                }
            }
        }
    }

    private void BindData(string testId)
    {
        ////通过试卷ID在map表里找到所有的试题ID
        //IList<PDTech.OA.Model.OA_QUESTION_TEST_MAP> mapList = new List<PDTech.OA.Model.OA_QUESTION_TEST_MAP>();
        //mapList = mapBll.GetModelList(" EDU_T_GUID = '" + testId + "'");
        ////拼接所有的试题ID
        //string allQuesIds = string.Empty;
        //foreach (PDTech.OA.Model.OA_QUESTION_TEST_MAP model in mapList)
        //{
        //    if (allQuesIds.Length > 0)
        //    {
        //        allQuesIds += ",'" + model.EDU_Q_GUID + "'";
        //    }
        //    else
        //    {
        //        allQuesIds += "'" + model.EDU_Q_GUID + "'";
        //    }
        //}

        quesList = quesBll.GetTestList(" b.EDU_T_GUID = '" + testId + "'");
    }

    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrevPage_Click(object sender, EventArgs e)
    {
        SaveSelectValue();
        np.PageIndex = int.Parse(hidPageIndex.Value); //读取当前页
        np.PageIndex--;
        CountIndex = (toModel.QuestionCollection.Count - 1) / np.PageCount + 1; //总页数
        isShowButton(CountIndex);
        hidPageIndex.Value = np.PageIndex.ToString();
    }

    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        SaveSelectValue();
        np.PageIndex = int.Parse(hidPageIndex.Value); //读取当前页
        np.PageIndex++;
        CountIndex = (toModel.QuestionCollection.Count - 1) / np.PageCount + 1; //总页数
        isShowButton(CountIndex);
        hidPageIndex.Value = np.PageIndex.ToString();
    }

    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //先保存最后一页做题的结果
        SaveSelectValue();
        xmlPath = Server.MapPath("~/App_Resources/XML/" + answerGuid + ".xml");
        toModel = XmlHelper.Xml2Obj(xmlPath, typeof(PDTech.OA.Model.TestOnline)) as PDTech.OA.Model.TestOnline;
        PDTech.OA.Model.OA_EDUTEST testModel = testBll.GetModel(testId);
        IList<PDTech.OA.Model.OA_QUESTION_TEST_MAP> mapList = new List<PDTech.OA.Model.OA_QUESTION_TEST_MAP>();
        mapList = mapBll.GetModelList(" EDU_T_GUID = '" + testId + "'");
        decimal score = 0;
        decimal totalvalue = 0;
        foreach (PDTech.OA.Model.OA_QUESTION_TEST_MAP mapModel in mapList)
        {
            PDTech.OA.Model.OA_TEST_ANSWER answerModel = new PDTech.OA.Model.OA_TEST_ANSWER();
            answerModel.EDU_A_GUID = answerGuid;
            answerModel.EDU_MAP_GUID = mapModel.EDU_MAP_GUID;
            answerModel.ANSWER_ID = CurrentAccount.USER_ID;
            PDTech.OA.Model.Question item = toModel.QuestionCollection.Find(delegate(PDTech.OA.Model.Question t) { return t.QuestionID == mapModel.EDU_Q_GUID; });
            answerModel.SELECTEDOPTION = item.SelectValue;
            answerModel.ANSWERTIME = toModel.ReplyTime;
            answerModel.SCORE = item.Score;
            answerBll.Add(answerModel);
            score += item.Score;
            totalvalue += item.QuestionValue;
        }
        if (File.Exists(xmlPath))
        {
            File.Delete(xmlPath);
        }
        //判断考试结果是否合格,不合格则删除刚才添加的记录
        bool ispass = false;
        if (score*100/totalvalue < 60)
        {
            ispass = false;
        }
        else
        {
            ispass = true;
        }
        if (ispass)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('提交成功！');location.href = '/IncorruptEdu/ViewTestOnlineResult.aspx?t_id=" + testId + "&a_id=" + answerGuid + "';</script>");
        }
        else
        {
            answerBll.Delete(answerGuid);
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('考试成绩不合格，请重新考试！');location.href = '/IncorruptEdu/TestOnline.aspx?test_id=" + testId + "&key="+DateTime.Now.ToString()+"';</script>");
        }
        //跳转到查看结果页面
        //this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>location.href = \"/IncorruptEdu/ViewTestOnlineResult.aspx?test_id=\"'" + testId + "';</script>");
        
    }

    private void isShowButton(int countIndex)
    {
        if (countIndex == np.PageIndex)
        {
            if (countIndex == 1)
            {
                //只有一页(隐藏上一页和下一页按钮)
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
                btnSubmit.Enabled = true;
            }
            else
            {
                //当前页是最后一页(隐藏下一页按钮)
                btnPrevPage.Enabled = true;
                btnNextPage.Enabled = false;
                btnSubmit.Enabled = true;
            }
        }
        else
        {
            if (np.PageIndex == 1)
            {
                //当前是第一页(隐藏上一页和提交按钮)
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = true;
                btnSubmit.Enabled = false;
            }
            else
            {
                //当前页不是第一页和最后一页(隐藏提交按钮)
                btnPrevPage.Enabled = true;
                btnNextPage.Enabled = true;
                btnSubmit.Enabled = false;
            }
        }
    }

    private Hashtable GetSelectValue()
    {
        Hashtable ht = new Hashtable();
        string[] arry = hidResult.Value.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in arry)
        {
            try
            {
                ht.Add(str.Split('=')[0], str.Split('=')[1]);
            }
            catch { }
        }
        return ht;
    }

    private void SaveSelectValue()
    {
        xmlPath = Server.MapPath("~/App_Resources/XML/" + answerGuid + ".xml");
        toModel = XmlHelper.Xml2Obj(xmlPath, typeof(PDTech.OA.Model.TestOnline)) as PDTech.OA.Model.TestOnline;
        string[] arry = hidResult.Value.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string str in arry)
        {
            foreach (PDTech.OA.Model.Question item in toModel.QuestionCollection)
            {
                if (str.Split('=')[0].Equals(item.QuestionID))
                {
                    item.SelectValue = str.Split('=')[1];
                    if (item.SelectValue == item.CorrectResult)
                    {
                        item.Score = item.QuestionValue;
                    }
                    else
                    {
                        item.Score = 0;
                    }
                    break;
                }
            }
        }
        toModel.ReplyTime = DateTime.Parse(DateTime.Now.ToString("G"));
        XmlHelper.Obj2Xml(toModel, xmlPath);//保存做题结果 
    }

    /// <summary>
    /// 提示信息
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>layer.alert('" + msg + "');</script>");
        }
    }
}