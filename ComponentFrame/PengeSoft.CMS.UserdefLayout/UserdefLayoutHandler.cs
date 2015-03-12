using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections.Specialized;
namespace PengeSoft.CMS.UserdefLayout
{
    public class UserdefLayoutHandler : IHttpHandler
    {
        #region IHttpHandler 成员

        
       
        #region 接口实现

        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string cURI = context.Request.Path;
            cURI = cURI.Substring(1, cURI.Length - 1);
            int index = cURI.ToLower().IndexOf("userdeflayout");
            if (index > -1)
            {
                string pagename = cURI.Substring(index + 14, cURI.Length - (index+14));
                context.Server.Transfer("/index.html?pagename=" + pagename, true);
            }            
        }

        #endregion

      

        #endregion
    }
}
