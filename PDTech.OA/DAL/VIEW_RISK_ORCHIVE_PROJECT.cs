using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_RISK_ORCHIVE_PROJECT
	/// </summary>
	public partial class VIEW_RISK_ORCHIVE_PROJECT
	{
		public VIEW_RISK_ORCHIVE_PROJECT()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取信息---分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_RISK_ORCHIVE_PROJECT> get_paging_viewList(Model.VIEW_RISK_ORCHIVE_PROJECT where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM VIEW_RISK_ORCHIVE_PROJECT WHERE 1=1 {0}", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_ORCHIVE_PROJECT>(dt);
        }

        /// <summary>
        /// 获取信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_RISK_ORCHIVE_PROJECT> get_paging_viewList(Model.VIEW_RISK_ORCHIVE_PROJECT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM VIEW_RISK_ORCHIVE_PROJECT WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_RISK_ORCHIVE_PROJECT>(dt);
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public Model.VIEW_RISK_ORCHIVE_PROJECT get_paging_viewInfo(Model.VIEW_RISK_ORCHIVE_PROJECT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM VIEW_RISK_ORCHIVE_PROJECT WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_RISK_ORCHIVE_PROJECT>(dt)[0];
            }
            else
            {
                return null;
            }
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

