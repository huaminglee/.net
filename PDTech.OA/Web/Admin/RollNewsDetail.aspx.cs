using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RollNewsDetail : System.Web.UI.Page
{
    public string t_rand = "";
    string newsId = string.Empty;
    PDTech.OA.BLL.ROLL_NEWS newsBll = new PDTech.OA.BLL.ROLL_NEWS();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        newsId = Request.QueryString["news_id"];
        //newsId = "4";
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(newsId))
            {
                ViewData(decimal.Parse(newsId));
            }
        }
    }

    private void ViewData(decimal newsId)
    {
        PDTech.OA.Model.ROLL_NEWS model = newsBll.GetModel(newsId);
        if (model != null)
        {
            lbTitle.Text = model.NEWS_TITLE;
            lbCreateTime.Text = model.CREATE_TIME.ToString();
            lbCreator.Text = "发布人：" + GetUserName(model.CREATOR.Value);
            lbContent.Text = model.NEWS_CONTENT;
        }
        else
        {
            lbContent.Text = "新闻已被删除！";
        }
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }
}