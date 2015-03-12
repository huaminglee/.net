using System;

public partial class MainBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /***权限配置***/
            //if (!CurrentAccount.ISHavePurview("workManage"))
            //{
            //    btn_work.Visible = false;//办公管理
            //}
            if (!CurrentAccount.ISHavePurview("executive"))
            {
                btn_admin.Disabled = true;//行政权力运行
                btn_admin.Attributes.Add("title", "无此权限");
            }
            //if (!CurrentAccount.ISHavePurview("businessMonitor"))
            //{
            //    btn_monitor.Disabled = true;//风险预警
            //    btn_monitor.Attributes.Add("title", "无此权限");
            //}
            //if (!CurrentAccount.ISHavePurview("riskDisposal"))
            //{
            //    btn_risk.Visible = false;//风险处置
            //}
            if (!CurrentAccount.ISHavePurview("riskAssessment"))
            {
                btn_Ass.Disabled = true;//风险评估
                btn_Ass.Attributes.Add("title", "无此权限");
            }
            if (!CurrentAccount.ISHavePurview("systemManage"))
            {
                btn_system.Visible = false;//系统管理
                btn_system.Attributes.Add("title", "无此权限");
            }
        }
    }
}