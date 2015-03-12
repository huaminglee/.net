<%@ WebHandler Language="C#" Class="GetRollNews" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;

public class GetRollNews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string returnStr = string.Empty;
        if (context.Session["user_id"] != null)
        {
            PDTech.OA.BLL.ROLL_NEWS newsBll = new PDTech.OA.BLL.ROLL_NEWS();
            List<PDTech.OA.Model.ROLL_NEWS> list = newsBll.GetModelList(" IS_ROLLING = 1 ");
            if (list != null && list.Count > 0)
            {
                foreach (PDTech.OA.Model.ROLL_NEWS model in list)
                {
                    returnStr += "<li class='text-left'><a title='" + model.NEWS_TITLE + "' onclick='doViewNews(" + model.NEWS_ID + ")'>" + S_App.Substr(model.NEWS_TITLE, 16) + "  <span>" + model.CREATE_TIME.Value.ToString("yyyy-MM-dd") + "</span></a></li>";
                }
            }
        }
        context.Response.Write(returnStr);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}