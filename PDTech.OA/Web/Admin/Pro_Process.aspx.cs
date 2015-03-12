using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_Pro_Process : System.Web.UI.Page
{
    public decimal pId = 0; decimal flag = -1;
    PDTech.OA.BLL.VIEW_PRO_STEP_TYPE vBll = new PDTech.OA.BLL.VIEW_PRO_STEP_TYPE();
    public string t_rand = "";
    const string Symol = "/images/nextIcon.png";
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["pId"] != null)
        {
            pId = decimal.Parse(Request.QueryString["pId"].ToString());
            hidPid.Value = Request.QueryString["pId"].ToString();
            
            
            //flag = decimal.Parse(Request.QueryString["flag"].ToString());
            //hidFlag.Value = Request.QueryString["flag"].ToString();
            //if (flag == 0)
            //{
            //    hidTid.Value = Request.QueryString["tId"].ToString();
            //    hidArId.Value = Request.QueryString["ArId"].ToString();
            //}
        }
        if (Request.QueryString["Isedit"] != null)
        {
            hidisedit.Value = Request.QueryString["Isedit"].ToString();
        }
        if (Request.QueryString["ArId"] != null)
        {
            hidarchid.Value = Request.QueryString["ArId"].ToString();
        }
        if (Request.QueryString["tId"] != null)
        {
            hidtaskid.Value = Request.QueryString["tId"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 绑定项目步骤
    /// </summary>
    public void BindData()
    {
        if (string.IsNullOrEmpty(hidarchid.Value))
        {
            PDTech.OA.BLL.VIEW_PROJECT_STEP_USER vapbll = new PDTech.OA.BLL.VIEW_PROJECT_STEP_USER();
            PDTech.OA.Model.VIEW_PROJECT_STEP_USER vpsu = new PDTech.OA.Model.VIEW_PROJECT_STEP_USER();
            vpsu.PROJECT_ID = pId;
            vpsu = vapbll.get_paging_project_info(vpsu);
            hidarchid.Value = vpsu.ARCHIVE_ID.ToString();
            if (string.IsNullOrEmpty(hidtaskid.Value) || hidtaskid.Value=="0")
            {
                hidtaskid.Value = vpsu.ARCHIVE_TASK_ID.ToString();
            }
            
        }
        


        PDTech.OA.BLL.RISK_POINT_INFO rpiBll = new PDTech.OA.BLL.RISK_POINT_INFO();
        IList<PDTech.OA.Model.RISK_POINT_INFO> allRiskPoint = rpiBll.GetAllRiskPointInfo();
        IList<PDTech.OA.Model.VIEW_PRO_STEP_TYPE> vList = vBll.get_viewStepAndType(new PDTech.OA.Model.VIEW_PRO_STEP_TYPE() { PROJECT_ID = pId });
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < vList.Count; i++)
        {
            string p_state = "";
            if (vList[i].P_STEP_STATUS == 9)
            {
                p_state = "1";
            }
            else
            {
                p_state = "0";
            }
            string state = "";
            switch (vList[i].STEP_STATUS.ToString())
            {
                case "0":
                        state = "未开始";
                        sb.Append("<tr class='HandCss' >");
                        sb.Append("<td onclick=\"showStepDetail('" + vList[i].URL + "','" + vList[i].PROJECT_STEP_ID + "','" + p_state + "','" + vList[i].P_STEP_NAME + "')\">" + vList[i].STEP_NAME + "</td>");
                    break;
                case "1":
                    state = "进行中";
                    sb.Append("<tr class='green HandCss' title='负责人:" + vList[i].FULL_NAME + ",开始时间:" + vList[i].START_TIME + ",结束时间:" + vList[i].END_TIME + "' >");
                    sb.Append("<td onclick=\"showStepDetail('" + vList[i].URL + "','" + vList[i].PROJECT_STEP_ID + "','" + p_state + "','" + vList[i].P_STEP_NAME + "')\">" + vList[i].STEP_NAME + "</td>");
                    break;
                case "9":
                    if (vList[i].START_FLAG != "1")
                    {
                        state = "已完成";
                        sb.Append("<tr class='Orange HandCss' title='负责人:" + vList[i].FULL_NAME + ",开始时间:" + vList[i].START_TIME + ",结束时间:" + vList[i].END_TIME + "' >");
                        sb.Append("<td onclick=\"showStepDetail('" + vList[i].URL + "','" + vList[i].PROJECT_STEP_ID + "','" + p_state + "','" + vList[i].P_STEP_NAME + "')\">" + vList[i].STEP_NAME + "</td>");
                    }
                    else
                    {
                        state = "已完成";
                        sb.Append("<tr class='Orange HandCss' title='负责人:" + vList[i].FULL_NAME + ",开始时间:" + vList[i].START_TIME + ",结束时间:" + vList[i].END_TIME + "'>");
                        sb.Append("<td>" + vList[i].STEP_NAME + "</td>");
                    }
                    break;
            }
            #region 获取步骤对应的风险点
            sb.Append(" <td > ");
            PDTech.OA.Model.RISK_POINT_INFO step_risk_point = null;
            if (allRiskPoint != null)
            {
                step_risk_point = allRiskPoint.Where(r => r.STEP_TYPE == "SW_PROJECT_STEP" && r.STEP_ID == vList[i].STEP_ID.Value).FirstOrDefault();
            }
            if (step_risk_point != null)
            {
                string risk_title = "风险点：" + step_risk_point.RISK_POINT + "\n\n防范措施：" + step_risk_point.RISK_RESOLVE + "";
                string risk_icon = "";
                //配置提示样式
                switch (step_risk_point.RISK_LEVEL.Value.ToString())
                {
                    case "1":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px; '><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "2":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px;'><span class='glyphicon glyphicon-star'></span><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                    case "3":
                        risk_icon = "<b class='text-danger pull-right' style='font-size: 18px; '><span class='glyphicon glyphicon-star'></span></b>";
                        break;
                }
                sb.Append(" <span class=\"AttitudeBtn\"; title=\"" + risk_title + "\">" + risk_icon + "</span>");
            }
            sb.Append(" </td>");
            #endregion
            sb.Append("<td>" + vList[i].DEPARTMENT_NAME + "</td>");
            sb.Append("<td>" +AidHelp.ShortTime(vList[i].START_TIME) + "</td>");
            sb.Append("<td>" + AidHelp.ShortTime(vList[i].END_TIME) + "</td>");
            string date;
            if (vList[i].LIMIT_TIME == null || string.IsNullOrEmpty(vList[i].LIMIT_TIME.ToString()))
            {
                date = "";
            }
            else
            {
                date = vList[i].LIMIT_TIME.Value.ToString("yyyy-MM-dd");
            }
            sb.Append("<td>" + date + "</td>");
            sb.Append("<td>" + state + "</td>");
            if (vList[i].RISK_HANDLE_ARCHIVE_ID == null)
            {
                sb.Append("<td style=\"color:#0000ed;\" onclick=\"editRisk('33','" + vList[i].PROJECT_ID + "','" + vList[i].PROJECT_STEP_ID + "')\"><a href='javascript:void(0);'>生成风险处置单</a></td>");
            }
            else
            {
                sb.Append("<td style=\"color:#0000ed;\" onclick=\"selrisk('" + vList[i].RISK_HANDLE_ARCHIVE_ID + "')\"><a href='javascript:void(0);'>查看风险处置单</a></td>");
            }
            sb.Append("</tr>");
            if (i != vList.Count -1)
            {
                sb.Append("<tr>");
                sb.Append("<td colspan='8'><img src='" + Symol + "' alt='下一步' style='height:20px;'/></td>");
                sb.Append("</tr>");
            }
        }
        ShowScript.Text = sb.ToString();
    }
}