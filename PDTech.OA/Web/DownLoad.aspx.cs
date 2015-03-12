using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DownLoad : System.Web.UI.Page
{
    string filePath;
    string fullName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["file"]!=null)
        {
            filePath = Request.QueryString["file"].ToString();
            fullName = Request.QueryString["fullName"].ToString();
            if (!IsPostBack)
            {
                DownFile(filePath, fullName);
            }
        }
    }
    private void downLoad(string filename)
    {
        string path = Server.MapPath("") + filename;
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(filename));
            Response.AddHeader("Content-Length", fi.Length.ToString());
            Response.ContentType = "application/octet-stream;charset=gb2321";
            Response.WriteFile(fi.FullName);
            Response.Flush();
            Response.Close();
        }
    }
    /// <summary>
    /// Response.AddHeader实现下载
    /// </summary>
    /// <param name="filePath">完整的文件路径</param>
    /// <param name="fileName">文件名</param>
    private void DownFile(string filePath, string fileName)
    {
        //string path = Server.MapPath("") + filePath;
        string path = Server.MapPath(filePath);
        FileInfo fileInfo = new FileInfo(path);
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(fileName));
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.AddHeader("Content-Transfer-Encoding", "binary");
        Response.ContentType = "application/octet-stream";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        Response.WriteFile(fileInfo.FullName);
        Response.Flush();
        Response.End();
    }
}