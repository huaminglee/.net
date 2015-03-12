using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:FUNDS_INFO
	/// </summary>
	public partial class FUNDS_INFO
	{
		public FUNDS_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal FUNDS_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FUNDS_INFO");
			strSql.Append(" where FUNDS_ID=@FUNDS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FUNDS_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = FUNDS_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 获取资金来源数据列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public IList<Model.FUNDS_INFO> get_fundsList(Model.FUNDS_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format("SELECT * FROM FUNDS_INFO WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.FUNDS_INFO>(dt);
        }

		
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

