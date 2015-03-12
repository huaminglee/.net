using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManege_ShowEduReadState : System.Web.UI.Page
{
    public string t_rand = "";
    PDTech.OA.BLL.OA_RISKEDURECEIVER eduReBll = new PDTech.OA.BLL.OA_RISKEDURECEIVER();
    PDTech.OA.BLL.USER_INFO userBll = new PDTech.OA.BLL.USER_INFO();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        string eduId = Request.QueryString["edu_id"];
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(eduId))
            {
                BindEduData(decimal.Parse(eduId));
            }
        }
    }

    private void BindEduData(decimal eduId)
    {
        List<PDTech.OA.Model.OA_RISKEDURECEIVER> allList = eduReBll.GetModelList(" EDUCATION_ID = " + eduId.ToString());
        List<PDTech.OA.Model.OA_RISKEDURECEIVER> noreadList = allList.FindAll(delegate(PDTech.OA.Model.OA_RISKEDURECEIVER t) { return t.READ_STATUS == 0; });
        int count = allList.RemoveAll(delegate(PDTech.OA.Model.OA_RISKEDURECEIVER t) { return noreadList.Contains(t); });
        List<PDTech.OA.Model.OA_RISKEDURECEIVER> readList = allList;
        string nReadNames = "";
        foreach (var item in noreadList)
        {
            nReadNames += GetUserName(item.RECEIVER_ID.Value) + ",";
        }
        txtUserNames.Text = nReadNames.TrimEnd(',');
        rpt_UserList.DataSource = readList;
        rpt_UserList.DataBind();
    }

    public string GetUserName(decimal uid)
    {
        PDTech.OA.Model.USER_INFO user = userBll.GetUserInfo(uid);
        return user.FULL_NAME;
    }
}