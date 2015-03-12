using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_ARCHIVE_TYPE_STEP
	/// </summary>
	public partial class VIEW_ARCHIVE_TYPE_STEP
	{
		public VIEW_ARCHIVE_TYPE_STEP()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVE_TYPE_STEP Get_ViewInfo(Model.VIEW_ARCHIVE_TYPE_STEP Model)
        {
            string condition = DAL_Helper.GetWhereCondition(Model);
            string strSQL = string.Format("SELECT * FROM VIEW_ARCHIVE_TYPE_STEP  WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVE_TYPE_STEP>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取步骤信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_vStepTab(Model.VIEW_ARCHIVE_TYPE_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM VIEW_ARCHIVE_TYPE_STEP  WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }
        /// <summary>
        /// 获取步骤绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_TYPE_STEP> get_vStepList(Model.VIEW_ARCHIVE_TYPE_STEP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM VIEW_ARCHIVE_TYPE_STEP  WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVE_TYPE_STEP>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

