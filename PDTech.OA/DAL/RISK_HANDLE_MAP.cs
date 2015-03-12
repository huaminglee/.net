using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:RISK_HANDLE_MAP
	/// </summary>
	public partial class RISK_HANDLE_MAP
	{
		public RISK_HANDLE_MAP()
		{}
		#region  BasicMethod

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.RISK_HANDLE_MAP get_mapInfo(Model.RISK_HANDLE_MAP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQl = string.Format(@"SELECT * FROM RISK_HANDLE_MAP WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQl);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.RISK_HANDLE_MAP>(dt)[0];
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

