using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManeg_ShowRead : System.Web.UI.Page
{
    public string t_rand = "";
    string mId = "";
    PDTech.OA.BLL.VIEW_USER_MSGINFO vBll = new PDTech.OA.BLL.VIEW_USER_MSGINFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["Mid"] != null)
        {
            mId = Request.QueryString["Mid"].ToString();
        }
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(mId))
            {
                BindData();
            }
        }
    }
    public void BindData()
    {
        //定义获取所有公告信息实例
        IList<PDTech.OA.Model.VIEW_USER_MSGINFO> ListAll = new List<PDTech.OA.Model.VIEW_USER_MSGINFO>();
        /********按MessageID获取信息人员列表*******/
        ListAll = vBll.get_MsgList(new PDTech.OA.Model.VIEW_USER_MSGINFO() { MESSAGE_ID = decimal.Parse(mId) });
        /********筛选出未读公告信息列表********/
        List<PDTech.OA.Model.VIEW_USER_MSGINFO> nList = ListAll.Where(t => !t.READ_STATUS.HasValue || t.READ_STATUS.Value == 0).ToList();
        /*********筛选出已读公告信息列表*********/
        List<PDTech.OA.Model.VIEW_USER_MSGINFO> rList = ListAll.Where(t => t.READ_STATUS.HasValue && t.READ_STATUS.Value == 1).ToList();
        /*定义变量接收未读人员Full_Name*/
        string nReadNames = "";
        foreach (var item in nList)
        {
            nReadNames += item.FULL_NAME + ",";
        }
        /*****绑定未读人员******/
        txtUserNames.Text = nReadNames.TrimEnd(',');
        /**绑定已读人员列表数据**/
        rpt_UserList.DataSource = rList;
        rpt_UserList.DataBind();
    }
}