using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

public partial class Admin_upload : System.Web.UI.Page
{
    PDTech.OA.BLL.OA_ATTACHMENT_FILE file = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
    string ref_type = "";
    string ref_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PDTech.OA.Model.OA_ATTACHMENT_FILE data = new PDTech.OA.Model.OA_ATTACHMENT_FILE();
        MemoryStream ms = null;
        try
        {
            string nfileName = "";
            // Get the data
            HttpPostedFile upload = Request.Files["Filedata"];
            if (Request.QueryString["type"] != null)
            {
                ref_type = Request.QueryString["type"].ToString();
            }
            if (Request.QueryString["Id"] != null)
            {
                ref_Id = Request.QueryString["Id"].ToString();
            }

            //保存图片到服务器
            string relativeDir = @"/Upload\" + DateTime.Now.ToString("yyyyMM") + @"\";
            string newFileName = System.IO.Path.GetExtension(upload.FileName);
            Stream stream = upload.InputStream;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            nfileName = BitConverter.ToString((new MD5CryptoServiceProvider()).ComputeHash(bytes)).Replace("-", "");
            //服务器文件路径
            string targetFilePath = Server.MapPath(relativeDir);
            if (!Directory.Exists(targetFilePath))
            {
                Directory.CreateDirectory(targetFilePath);
            }
            upload.SaveAs(targetFilePath + @"\" + nfileName + newFileName);


            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            data.FILE_PATH = relativeDir + nfileName + newFileName;
            data.FILE_HASH = nfileName;
            string fileName = upload.FileName;
            string fileType = "";
            try
            {
                int fileTypeIndex = fileName.LastIndexOf('.');
                fileType = fileName.Substring(fileTypeIndex + 1).ToLower();
            }
            catch { }
            data.FILE_TYPE = fileType;
            data.FILE_NAME = upload.FileName;
            data.FILE_SIZE = bytes.Length;
            data.CREATE_USER = CurrentAccount.USER_ID;
            string att_file_id = "";
            file.Add(data, CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID, out att_file_id);//CurrentAccount.ClientHostName, CurrentAccount.ClientIP, CurrentAccount.USER_ID, out att_file_id);
            Response.StatusCode = 200;
            if (!string.IsNullOrEmpty(att_file_id))
                Response.Write(att_file_id);
            else
                Response.Write(null);
        }
        catch (Exception ex)
        {
            // If any kind of error occurs return a 500 Internal Server error
            Response.StatusCode = 500;
            Response.Write(ex.Message);
            Response.End();
        }
        finally
        {
            if (ms != null) ms.Close();
            Response.End();
        }



    }
}