using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Risk_UserControls_ucRiskStatistics : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
            IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> tList = tBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
            foreach (var item in tList)
            {
                ListItem items = new ListItem();
                if (item.ARCHIVE_TYPE != 51)
                {
                    items.Value = item.ARCHIVE_TYPE.ToString();
                    items.Text = item.TYPE_NAME;
                    dplBusinessType.Items.Add(items);
                }

            }
            ListItem item_default = new ListItem();
            item_default.Value = "";
            item_default.Text = "---请选择---";
            dplBusinessType.Items.Insert(0, item_default);
            txtsTime.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            txteTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

            InitBindData();
        }
    }

    public void InitBindData()
    {


        #region 所有统计
        PDTech.OA.BLL.OA_ARCHIVE viewtBll = new PDTech.OA.BLL.OA_ARCHIVE();
        PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT Query = new PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT();
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            Query.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && string.IsNullOrEmpty(Query.Append))
        {
            Query.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && !string.IsNullOrEmpty(Query.Append))
        {
            Query.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()) && !string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            var sTime = DateTime.Parse(txtsTime.Text.Trim());
            var eTime = DateTime.Parse(txteTime.Text.Trim());
            if (sTime > eTime)
            {
                Query.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
                Query.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                Query.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
        if (!string.IsNullOrEmpty(hidDeptName.Value) && hidDeptName.Value != "---请选择---")
            Query.DEPARTMENT_NAME = AidHelp.FilterSpecial(hidDeptName.Value);
        if (!string.IsNullOrEmpty(hidUserName.Value) && hidUserName.Value != "---请选择---" && hidDeptName.Value != "---请选择---")
            Query.FULL_NAME = AidHelp.FilterSpecial(hidUserName.Value);
        Query.ARCHIVE_TITLE =AidHelp.FilterSpecial(txtTitle.Value);
        if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue))
            Query.ARCHIVE_TYPE = decimal.Parse(dplBusinessType.SelectedValue);
        Query.ARCHIVE_NO =AidHelp.FilterSpecial(txtArchiveNo.Text);
        string [] edulist= viewtBll.get_edutaskandonlinetestcount().Split(';');
        txtEdutaskNum.Text = "["+edulist[0]+"]";
        txtOnlinetestNum.Text = "[" + edulist[1] + "]";
        txtEduTask.Text = edulist[2];
        txtOnlineTest.Text = edulist[3];
        IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> arList = viewtBll.get_Paging_ArchiveAllList(Query);
        if (arList != null)
        {
            /**日常办公**/
            IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> ardLIst = arList.Where(s => s.ARCHIVE_TYPE == 10 || s.ARCHIVE_TYPE == 11 || s.ARCHIVE_TYPE == 12).ToList();
            /**督办工作**/
            IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> arsLIst = arList.Where(s => s.ARCHIVE_TYPE == 20 || s.ARCHIVE_TYPE == 21 || s.ARCHIVE_TYPE == 22 || s.ARCHIVE_TYPE == 23 || s.ARCHIVE_TYPE == 24).ToList();
            /**行政审批**/
            IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> araLIst = arList.Where(s => s.ARCHIVE_TYPE == 40 || s.ARCHIVE_TYPE == 41 || s.ARCHIVE_TYPE == 42 || s.ARCHIVE_TYPE == 43 || s.ARCHIVE_TYPE == 44).ToList();
            /**人事任免**/
            IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> arpLIst = arList.Where(s => s.ARCHIVE_TYPE == 32).ToList();
            /**水务项目**/
            IList<PDTech.OA.Model.VIEW_ARCHIVE_USER_DEPT> arprLIst = arList.Where(s => s.ARCHIVE_TYPE == 33).ToList();
            txtArchiveNum.Text = "[" + ardLIst.Count.ToString() + "]";
            txtAdminNum.Text = "[" + araLIst.Count.ToString() + "]";
            txtPersonnelNum.Text = "[" + arpLIst.Count.ToString() + "]";
            txtProjectNum.Text = "[" + arprLIst.Count.ToString() + "]";
            txtSupNum.Text = "[" + arsLIst.Count.ToString() + "]";
        }
        #endregion

        #region  风险统计
        PDTech.OA.BLL.VIEW_RISK_ATT vBll = new PDTech.OA.BLL.VIEW_RISK_ATT();
        PDTech.OA.Model.VIEW_RISK_ATT where = new PDTech.OA.Model.VIEW_RISK_ATT();
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && string.IsNullOrEmpty(where.Append))
        {
            where.Append = string.Format(@" CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        else if (!string.IsNullOrEmpty(txteTime.Text.Trim()) && !string.IsNullOrEmpty(where.Append))
        {
            where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
        }
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()) && !string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            var sTime = DateTime.Parse(txtsTime.Text.Trim());
            var eTime = DateTime.Parse(txteTime.Text.Trim());
            if (sTime > eTime)
            {
                where.Append = string.Format(@" CREATE_TIME>CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
                where.Append += string.Format(@" AND CREATE_TIME<CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else if (sTime == eTime)
            {
                where.Append = string.Format(@" CREATE_TIME=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss")));
            }
        }
        if (!string.IsNullOrEmpty(hidDeptName.Value) && hidDeptName.Value != "---请选择---")
            where.DEPT_NAME = AidHelp.FilterSpecial(hidDeptName.Value);
        if (!string.IsNullOrEmpty(hidUserName.Value) && hidUserName.Value != "---请选择---" && hidDeptName.Value != "---请选择---")
            where.FULL_NAME = AidHelp.FilterSpecial(hidUserName.Value);
        where.ARCHIVE_TITLE =AidHelp.FilterSpecial(txtTitle.Value);
        if (!string.IsNullOrEmpty(dplBusinessType.SelectedValue) && dplBusinessType.SelectedItem.Text != "---请选择---")
            where.BUSINESS = dplBusinessType.SelectedItem.Text;
        where.ARCHIVE_NO =AidHelp.FilterSpecial(txtArchiveNo.Text);
        IList<PDTech.OA.Model.VIEW_RISK_ATT> vLIst = vBll.get_viewList(where);
        if (vLIst != null)
        {
            #region 超期风险统计
            /**日常办公**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> dLIst = vLIst.Where(s => s.RISKTYPE == "超期风险" && (s.RISK_P_ARCHIVETYPE == 10 || s.RISK_P_ARCHIVETYPE == 11 || s.RISK_P_ARCHIVETYPE == 12)).ToList();
            /**督办工作**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> sLIst = vLIst.Where(s => s.RISKTYPE == "超期风险" && (s.RISK_P_ARCHIVETYPE == 20 || s.RISK_P_ARCHIVETYPE == 21 || s.RISK_P_ARCHIVETYPE == 22 || s.RISK_P_ARCHIVETYPE == 23 || s.RISK_P_ARCHIVETYPE == 24)).ToList();
            /**行政审批**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> aLIst = vLIst.Where(s => s.RISKTYPE == "超期风险" && (s.RISK_P_ARCHIVETYPE == 40 || s.RISK_P_ARCHIVETYPE == 41 || s.RISK_P_ARCHIVETYPE == 42 || s.RISK_P_ARCHIVETYPE == 43 || s.RISK_P_ARCHIVETYPE == 44)).ToList();
            /**人事任免**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> pLIst = vLIst.Where(s => s.RISKTYPE == "超期风险" && s.RISK_P_ARCHIVETYPE == 32).ToList();
            /**水务项目**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> prLIst = vLIst.Where(s => s.RISKTYPE == "超期风险" && (s.RISK_P_ARCHIVETYPE == 33 || s.RISK_P_ARCHIVETYPE == 331)).ToList();
            txtAichive.Text = dLIst.Count.ToString();
            txtAdmin.Text = aLIst.Count.ToString();
            txtPersonel.Text = pLIst.Count.ToString();
            txtProject.Text = prLIst.Count.ToString();
            txtSup.Text = sLIst.Count.ToString();

            #endregion

            #region  违规风险统计
            /**日常办公**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> dLIst0 = vLIst.Where(s => s.RISKTYPE == "违规风险" && (s.RISK_P_ARCHIVETYPE == 10 || s.RISK_P_ARCHIVETYPE == 11 || s.RISK_P_ARCHIVETYPE == 12)).ToList();
            /**督办工作**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> sLIst0 = vLIst.Where(s => s.RISKTYPE == "违规风险" && (s.RISK_P_ARCHIVETYPE == 20 || s.RISK_P_ARCHIVETYPE == 21 || s.RISK_P_ARCHIVETYPE == 22 || s.RISK_P_ARCHIVETYPE == 23 || s.RISK_P_ARCHIVETYPE == 24)).ToList();
            /**行政审批**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> aLIst0 = vLIst.Where(s => s.RISKTYPE == "违规风险" && (s.RISK_P_ARCHIVETYPE == 40 || s.RISK_P_ARCHIVETYPE == 41 || s.RISK_P_ARCHIVETYPE == 42 || s.RISK_P_ARCHIVETYPE == 43 || s.RISK_P_ARCHIVETYPE == 44)).ToList();
            /**人事任免**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> pLIst0 = vLIst.Where(s => s.RISKTYPE == "违规风险" && s.RISK_P_ARCHIVETYPE == 32).ToList();
            /**水务项目**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> prLIst0 = vLIst.Where(s => s.RISKTYPE == "违规风险" && (s.RISK_P_ARCHIVETYPE == 33 || s.RISK_P_ARCHIVETYPE == 331)).ToList();
            txtAichive0.Text = dLIst0.Count.ToString();
            txtAdmin0.Text = aLIst0.Count.ToString();
            txtPersonel0.Text = pLIst0.Count.ToString();
            txtProject0.Text = prLIst0.Count.ToString();
            txtSup0.Text = sLIst0.Count.ToString();
            #endregion
            
            #region  监督督查统计
            /**日常办公**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> dLIst1 = vLIst.Where(s => s.RISKTYPE == "监督督查" && (s.RISK_P_ARCHIVETYPE == 10 || s.RISK_P_ARCHIVETYPE == 11 || s.RISK_P_ARCHIVETYPE == 12)).ToList();
            /**督办工作**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> sLIst1 = vLIst.Where(s => s.RISKTYPE == "监督督查" && (s.RISK_P_ARCHIVETYPE == 20 || s.RISK_P_ARCHIVETYPE == 21 || s.RISK_P_ARCHIVETYPE == 22 || s.RISK_P_ARCHIVETYPE == 23 || s.RISK_P_ARCHIVETYPE == 24)).ToList();
            /**行政审批**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> aLIst1 = vLIst.Where(s => s.RISKTYPE == "监督督查" && (s.RISK_P_ARCHIVETYPE == 40 || s.RISK_P_ARCHIVETYPE == 41 || s.RISK_P_ARCHIVETYPE == 42 || s.RISK_P_ARCHIVETYPE == 43 || s.RISK_P_ARCHIVETYPE == 44)).ToList();
            /**人事任免**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> pLIst1 = vLIst.Where(s => s.RISKTYPE == "监督督查" && s.RISK_P_ARCHIVETYPE == 32).ToList();
            /**水务项目**/
            IList<PDTech.OA.Model.VIEW_RISK_ATT> prLIst1 = vLIst.Where(s => s.RISKTYPE == "监督督查" && (s.RISK_P_ARCHIVETYPE == 33 || s.RISK_P_ARCHIVETYPE == 331)).ToList();
            txtAichive_O.Text = dLIst1.Count.ToString();
            txtAdmin_O.Text = aLIst1.Count.ToString();
            txtPersonel_O.Text = pLIst1.Count.ToString();
            txtProject_O.Text = prLIst1.Count.ToString();
            txtSup_O.Text = sLIst1.Count.ToString();
            #endregion
        }
        #endregion
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        InitBindData();
    }
}