using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:VIEW_RISK_ATT
    /// </summary>
    public partial class VIEW_RISK_ATT
    {
        public VIEW_RISK_ATT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> get_viewList(Model.VIEW_RISK_ATT where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT TOP (100) PERCENT * FROM VIEW_RISK_ATT WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(selSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_ATT>(dt);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> get_viewList(Model.VIEW_RISK_ATT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_RISK_ATT WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_ATT>(dt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.VIEW_RISK_ATT> getDeptNum(Model.VIEW_RISK_ATT where)
        {
            string condition = DAL_Helper.GetWhereConditions(where);
            string selSQL = string.Format(@"SELECT COUNT(1) AS CNUM,DEPT_NAME FROM VIEW_RISK_ATT WHERE 1=1 {0} 
GROUP BY DEPT_NAME ORDER BY DEPT_NAME DESC ", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_ATT>(dt);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

