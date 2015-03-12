using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Archive_VideoList : System.Web.UI.Page
{
    public string t_rand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (!Page.IsPostBack)
        {
            BindRDO();
        }
    }
    private void BindRDO()
    {
        string path = Server.MapPath(Request.ApplicationPath+"/database/Videos/Custom");

        string[] files = System.IO.Directory.GetFiles(path);
        Dictionary<string, string> nfiles = new Dictionary<string, string>();
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo finfo = new FileInfo(files[i]);
            if (finfo.Extension == ".flv")
            {
                nfiles.Add(finfo.Name, finfo.Name);
            }
        }
        this.ckbvideolist.DataSource = nfiles;
        ckbvideolist.DataTextField = "Value";
        ckbvideolist.DataValueField = "Key";
        ckbvideolist.DataBind();
            

    }
}