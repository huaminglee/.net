
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:RISK_TYPE_INFO
	/// </summary>
	public partial class RISK_TYPE_INFO
	{
		public RISK_TYPE_INFO()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.RISK_TYPE_INFO> get_risktypeList(Model.RISK_TYPE_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM RISK_TYPE_INFO WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.RISK_TYPE_INFO>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

