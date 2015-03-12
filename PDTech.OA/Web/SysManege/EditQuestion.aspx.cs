using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_EditQuestion : System.Web.UI.Page
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
        txtTitle.Text = model.TITLE;
        txtOptionA.Text = model.OPTIONA;
        txtOptionB.Text = model.OPTIONB;
        txtOptionC.Text = model.OPTIONC;
        txtOptionD.Text = model.OPTIOND;
        ddlScore.SelectedValue = model.SCORE.ToString();
        rblOption.SelectedValue = model.ANSWER;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_EDUQUESTION model = new PDTech.OA.Model.OA_EDUQUESTION();
        model.TITLE = txtTitle.Text;
        model.OPTIONA = txtOptionA.Text;
        model.OPTIONB = txtOptionB.Text;
        model.OPTIONC = txtOptionC.Text;
        model.OPTIOND = txtOptionD.Text;
        model.SCORE = decimal.Parse(ddlScore.SelectedValue);
        model.ANSWER = rblOption.SelectedValue;
        model.WEIGHT = 0;

        if (string.IsNullOrEmpty(quId))
        {
            //新增            
            model.EDU_Q_GUID = System.Guid.NewGuid().ToString();
            model.CREATETIME = DateTime.Now;
            bool result = quesBll.Add(model);
            if (result)
            {
                nPrompt("",3);
            }
            else
            {
                nPrompt("新增试题失败!", 2);
            }
        }
        else
        { 
            //编辑
            model.EDU_Q_GUID = quId;
            bool result = quesBll.Update(model);
            if (result)
            {
                nPrompt("编辑试题成功!", 2);
            }
            else
            {
                nPrompt("编辑试题失败!", 2);
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