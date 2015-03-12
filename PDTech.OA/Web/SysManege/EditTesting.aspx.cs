using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_EditTesting : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    PDTech.OA.BLL.OA_EDUTEST testBll = new PDTech.OA.BLL.OA_EDUTEST();
    PDTech.OA.BLL.OA_QUESTION_TEST_MAP mapBll = new PDTech.OA.BLL.OA_QUESTION_TEST_MAP();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!IsPostBack)
        {
            
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string title = txtTestName.Text;
        string selectType = rblTestCount.SelectedValue;     
        IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = quesBll.GetModelList("");
        List<PDTech.OA.Model.OA_EDUQUESTION> createList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        PDTech.OA.Model.OA_EDUTEST testModel = new PDTech.OA.Model.OA_EDUTEST();
        PDTech.OA.Model.OA_QUESTION_TEST_MAP mapModel = null;
        Random rand = null;
        int i = 0;
        decimal total = 0;
        if (selectType == "自定义")
        {
            int customCount = int.Parse(txtDefineCount.Text);
            if (quesList != null && quesList.Count > 0)
            {
                if (customCount > quesList.Count)
                {
                    //生成的试题数大于已有试题总数
                    nPrompt("生成试卷失败，生成的试题数大于已有试题总数！", 2);
                }
                else
                {
                    //随机生成用户输入的试题数
                    while (createList.Count != customCount)
                    {
                        rand = new Random();
                        i = rand.Next(0, quesList.Count);
                        if (!createList.Contains(quesList[i]))
                        {
                            total += quesList[i].SCORE.Value;
                            createList.Add(quesList[i]);
                            quesList.RemoveAt(i);
                        }
                    }
                    //添加试卷 
                    testModel.EDU_T_GUID = System.Guid.NewGuid().ToString();
                    testModel.TESTNAME = title;
                    testModel.CREATOR = CurrentAccount.USER_ID;
                    testModel.CREATETIME = DateTime.Now;
                    testModel.TESTCOUNT = customCount;
                    testModel.SCORE = total;
                    if (!String.IsNullOrEmpty(pdthopefinishtime.Text))
                    {
                        testModel.HOPEFINISHTIME = DateTime.Parse(pdthopefinishtime.Text.Trim());
                    }
                    else
                    {
                        testModel.HOPEFINISHTIME = DateTime.MaxValue;
                    }
                    testModel.FINISHTIME = DateTime.MaxValue;
                    bool r = testBll.Add(testModel);
                    if (r)
                    {
                        //添加试卷与试题对应关系表
                        //string mapGuid = System.Guid.NewGuid().ToString();
                        int index = 0;
                        foreach (PDTech.OA.Model.OA_EDUQUESTION item in createList)
                        {
                            mapModel = new PDTech.OA.Model.OA_QUESTION_TEST_MAP();
                            mapModel.EDU_MAP_GUID = System.Guid.NewGuid().ToString();
                            mapModel.EDU_Q_GUID = item.EDU_Q_GUID;
                            mapModel.EDU_T_GUID = testModel.EDU_T_GUID;
                            mapModel.MAP_INDEX = (index += 1);
                            mapBll.Add(mapModel);
                        }
                        nPrompt("生成试卷成功！", 1);
                    }
                }
            }
        }
        else
        {
            if (quesList != null && quesList.Count > 0)
            {
                if (int.Parse(selectType) > quesList.Count)
                {
                    //生成的试题数大于已有试题总数
                    nPrompt("生成试卷失败，生成的试题数大于已有试题总数！", 2);
                }
                else
                {
                    //随机生成用户选择的试题数
                    while (createList.Count != int.Parse(selectType))
                    {
                        rand = new Random();
                        i = rand.Next(0, quesList.Count);
                        if (!createList.Contains(quesList[i]))
                        {
                            total += quesList[i].SCORE.Value;
                            createList.Add(quesList[i]);
                            quesList.RemoveAt(i);
                        }
                    }
                    //添加试卷 
                    testModel.EDU_T_GUID = System.Guid.NewGuid().ToString();
                    testModel.TESTNAME = title;
                    testModel.CREATOR = CurrentAccount.USER_ID;
                    testModel.CREATETIME = DateTime.Now;
                    testModel.TESTCOUNT = int.Parse(selectType);
                    testModel.SCORE = total;
                    if (!String.IsNullOrEmpty(pdthopefinishtime.Text))
                    {
                        testModel.HOPEFINISHTIME = DateTime.Parse(pdthopefinishtime.Text.Trim());
                    }
                    else
                    {
                        testModel.HOPEFINISHTIME = DateTime.MaxValue;
                    }
                    testModel.FINISHTIME = DateTime.MaxValue;
                    bool r = testBll.Add(testModel);
                    if (r)
                    {
                        //添加试卷与试题对应关系表
                        //string mapGuid = System.Guid.NewGuid().ToString();
                        int index = 0;
                        foreach (PDTech.OA.Model.OA_EDUQUESTION item in createList)
                        {
                            mapModel = new PDTech.OA.Model.OA_QUESTION_TEST_MAP();
                            mapModel.EDU_MAP_GUID = System.Guid.NewGuid().ToString();
                            mapModel.EDU_Q_GUID = item.EDU_Q_GUID;
                            mapModel.EDU_T_GUID = testModel.EDU_T_GUID;
                            mapModel.MAP_INDEX = (index += 1);
                            mapBll.Add(mapModel);
                        }
                        nPrompt("生成试卷成功！", 1);
                    }
                }
            }
        }
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "')</script>");
        }
        else if (flag == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh(); window.parent.layer.closeAll();</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
    }
}