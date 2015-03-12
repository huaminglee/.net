
using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:ARCHIVE_PROJECT_MAP
	/// </summary>
	public partial class ARCHIVE_PROJECT_MAP
	{
		public ARCHIVE_PROJECT_MAP()
		{}
		#region  BasicMethod

        /// <summary>
        /// 获取Anchive和Project关联
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.ARCHIVE_PROJECT_MAP get_mapInfo(Model.ARCHIVE_PROJECT_MAP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM ARCHIVE_PROJECT_MAP WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.Query(selSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.ARCHIVE_PROJECT_MAP>(dt)[0];
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

