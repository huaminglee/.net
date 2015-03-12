using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_ARCHIVE_TYPE
    /// </summary>
    public partial class OA_ARCHIVE_TYPE
    {
        public OA_ARCHIVE_TYPE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获取类型信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE_TYPE> get_ArchiveTypeList(Model.OA_ARCHIVE_TYPE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM OA_ARCHIVE_TYPE WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE_TYPE>(dt);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 查询公文类型
        /// </summary>
        /// <returns>返回公文类型</returns>
        public DataTable GetArchiveType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select oat.archive_type,oat.type_name,oat.group_name,'1' as parent_id from oa_archive_type oat");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查询公文类型
        /// </summary>
        /// <returns>返回公文类型</returns>
        public IList<Model.ARCHIVE_TYPE_OPTION> GetArchiveTypeOption()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select archive_type,type_name from oa_archive_type order by archive_type asc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.ARCHIVE_TYPE_OPTION>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}