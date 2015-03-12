using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_selQuestion : System.Web.UI.Page
{
    public string t_rand = "";
    string quId = string.Empty;
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        quId = Request.QueryString["qu_id"];
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(quId))
            {
                EditBind(quId);
            }
        }
    }

    private void EditBind(string quId)
    {
        PDTech.OA.Model.OA_EDUQUESTION model = quesBll.GetModel(quId);
        lbTitle.Text = model.TITLE;
        lbOptionA.Text ="A:"+ model.OPTIONA;
        lbOptionB.Text = "B:"+model.OPTIONB;
        lbOptionC.Text ="C:"+ model.OPTIONC;
        lbOptionD.Text ="D:"+ model.OPTIOND;
        lbScore.Text = model.SCORE.ToString();
        lbAnswer.Text = model.ANSWER;
        
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
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');</script>");
        }
        else if (flag == 2)
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>alert('" + msg + "');window.parent.doRefresh(); window.parent.layer.closeAll();</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(GetType(), "showDiv", "<script>doContinue()</script>");
        }
    }
}