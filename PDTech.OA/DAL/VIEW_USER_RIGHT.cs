
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references

namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_USER_RIGHT
	/// </summary>
	public partial class VIEW_USER_RIGHT
	{
		public VIEW_USER_RIGHT()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取用户权限Code---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_RIGHT> get_ViewList(Model.VIEW_USER_RIGHT where)
        {
            SqlCondition condition = DAL_Helper.GetWhereConditionForSql(where);
            //OracleSqlCondition condition = DAL_Helper.GetWhereConditionPOracle(where);
            string strSQL = string.Format("SELECT RIGHT_CODE FROM VIEW_USER_RIGHT WHERE 1=1 {0} ", condition.ConditionSqlStr);

            DataTable dt = DbHelperSQL.Query(strSQL, condition.sqlParaList.ToArray()).Tables[0];
            return DAL_Helper.CommonFillList<Model.VIEW_USER_RIGHT>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

