using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProjectItem_Print : System.Web.UI.Page
{
    public string t_rand = "";
    decimal projectid = 0;
    PDTech.OA.BLL.SW_PROJECT_INFO sBll = new PDTech.OA.BLL.SW_PROJECT_INFO();
    PDTech.OA.BLL.ARCHIVE_PROJECT_MAP mBll = new PDTech.OA.BLL.ARCHIVE_PROJECT_MAP();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["projectid"] != null)
        {
            projectid = decimal.Parse(Request.QueryString["projectid"]);
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        
        PDTech.OA.Model.SW_PROJECT_INFO sequel = sBll.get_proInfo(projectid);
        txtHostUnit.Text = sequel.OWNER_DEPT;//项目主办单位
        txtMoneyTotal.Text = (sequel.PROJECT_FUNDS).ToString();//项目总金额
        txtProjectBasis.Text = sequel.PROJECT_BY;//立项依据
        txtRemark.Text = sequel.REMARK;//备注
        lbTopTitle.Text += sequel.PROJECT_NAME;
        txtsTime.Text = sequel.START_TIME == null ? "" : sequel.START_TIME.Value.ToString("yyyy-MM-dd");//开始时间
        txtTitle.Text = sequel.PROJECT_NAME;//项目名称
        txtMoneySource.Text = sequel.FUNDS_TYPE.ToString();//项目资金来源
        txtFILE_DEPT.Text = sequel.FILE_DEPT.ToString()=="1"?"规计处":"财务处";//归档处室
        switch (sequel.LAUNCH_TYPE.ToString())
        {
            case "1":
                txtOrgUnit.Text = "市级";
                break;
            case "2":
                  txtOrgUnit.Text = "县级";
                break;
            case "3":
                txtOrgUnit.Text = "省级";
                break;
            case "7":
                 txtOrgUnit.Text = "其它";
                break;
        }
        PDTech.OA.BLL.DEPARTMENT dBll = new PDTech.OA.BLL.DEPARTMENT();
        PDTech.OA.Model.DEPARTMENT deptinfo = dBll.GetDeptInfo(decimal.Parse(sequel.TOP_RESPONSE_DEPT));
        if (deptinfo != null)
        {
            txtRESPONSE_DEPT.Text = deptinfo.DEPARTMENT_NAME;
        }
        PDTech.OA.Model.ARCHIVE_PROJECT_MAP where =new PDTech.OA.Model.ARCHIVE_PROJECT_MAP();
        where.PROJECT_ID=projectid;
        where=mBll.get_mapInfo(where);
        ShowOpList.Text = AidHelp.get_PrintInfoListAll_Html(where.ARCHIVE_ID.Value,false);
        
    }
}