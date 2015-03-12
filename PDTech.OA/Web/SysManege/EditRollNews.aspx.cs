using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_EditRollNews : System.Web.UI.Page
{
    public string t_rand = "";
    string newsId = string.Empty;
    PDTech.OA.BLL.ROLL_NEWS newsBll = new PDTech.OA.BLL.ROLL_NEWS();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        newsId = Request.QueryString["news_id"];
        if(!IsPostBack)
        {
            if (!string.IsNullOrEmpty(newsId))
            { 
                EditBind(decimal.Parse(newsId));
            }
        }
    }

    private void EditBind(decimal newsId)
    {
        PDTech.OA.Model.ROLL_NEWS model = newsBll.GetModel(newsId);
        txtTitle.Text = model.NEWS_TITLE;
        txtContent.Text = model.NEWS_CONTENT;
        ddlIsRolling.SelectedValue = model.IS_ROLLING.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        PDTech.OA.Model.ROLL_NEWS model = new PDTech.OA.Model.ROLL_NEWS();
        model.NEWS_TITLE = txtTitle.Text;
        model.NEWS_CONTENT = txtContent.Text;
        model.CREATOR = CurrentAccount.USER_ID;
        model.CREATE_TIME = DateTime.Now;
        model.IS_ROLLING = decimal.Parse(ddlIsRolling.SelectedValue);
        if (string.IsNullOrEmpty(newsId))
        {
            //新增
            int r = newsBll.Add(model);
            if (r==1)
            {
                nPrompt("新增新闻成功", 2);
            }
            else if (r == -1)
            {
                nPrompt("已存在此标题,不能重复添加!", 0);
            }
            else
            {
                nPrompt("新增新闻失败!", 0);
            }
        }
        else
        { 
            //编辑
            model.NEWS_ID = decimal.Parse(newsId);
            int r = newsBll.Update(model);
            if (r==1)
            {
                nPrompt("编辑新闻成功!", 2);
            }
            else if (r == -1)
            {
                nPrompt("已存在此标题,不能重复添加!", 0);
            }
            else
            {
                nPrompt("编辑新闻失败!", 0);
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