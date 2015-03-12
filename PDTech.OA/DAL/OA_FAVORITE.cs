using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_FAVORITE
    /// </summary>
    public partial class OA_FAVORITE
    {
        public OA_FAVORITE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal REF_ID, decimal UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_FAVORITE");
            strSql.Append(" where REF_ID=@REF_ID AND USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@REF_ID", SqlDbType.Decimal,22),
                    new SqlParameter("@USER_ID", SqlDbType.Decimal,22)};
            parameters[0].Value = REF_ID;
            parameters[1].Value = UserID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PDTech.OA.Model.OA_FAVORITE model)
        {
            if (Exists(model.REF_ID, model.USER_ID))
            {
                return 2;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OA_FAVORITE(");
            strSql.Append("USER_ID,REF_TYPE,REF_ID,CREATE_TIME)");
            strSql.Append(" values (");
            strSql.Append("@USER_ID,@REF_TYPE,@REF_ID,@CREATE_TIME)");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@REF_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@REF_ID", SqlDbType.Decimal,4),
					new SqlParameter("@CREATE_TIME", SqlDbType.DateTime)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.REF_TYPE;
            parameters[2].Value = model.REF_ID;
            parameters[3].Value = model.CREATE_TIME;
            DAL_Helper.get_db_para_value(parameters);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal favorite_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from oa_favorite ");
            strSql.Append(" where favorite_id=@favorite_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@favorite_id", SqlDbType.Decimal,22)};
            parameters[0].Value = favorite_id;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod

        /// <summary>
        /// 查询收藏夹（当前用户的某种公文类型）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="archiveType">公文类型</param>
        /// <returns>返回收藏夹</returns>
        public IList<Model.FAVORITE> GetFavorite(string uId, string archiveType)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select rownum as rowno,oa_favorite.* from (select f.favorite_id,oa.archive_title,oa.archive_id,oa.archive_type,");
            //strSql.Append("to_char(oa.create_time,'yyyy-mm-dd hh24:mi:ss') as create_time,");
            //strSql.Append("decode(oa.current_state,0,'新建',1,'流转中',2,'已完成',9,'取消','其它') as current_state,");
            //strSql.Append("(select full_name from user_info where oa.creator=user_id) as creator ");
            //strSql.Append("from oa_favorite f,oa_archive oa ");
            //strSql.Append("where f.ref_id=oa.archive_id and f.ref_type='OA_ARCHIVE' and f.user_id='" + uId + "' ");
            //strSql.Append("and oa.archive_type='" + archiveType + "' order by f.create_time desc) oa_favorite");
            strSql.Append("select ROW_NUMBER() OVER(ORDER BY favorite_id) as rowno,oa_favorite.* from (select f.favorite_id,oa.archive_title,oa.archive_id,oa.archive_type,");
            strSql.Append("convert(varchar(10),oa.create_time,101) as create_time,");
            strSql.Append("case oa.current_state when 0 then '新建' when 1 then '流转中' when 2 then '已完成' when 9 then '取消' else '其它' end as current_state,");
            strSql.Append("(select full_name from user_info where oa.creator=user_id) as creator ");
            strSql.Append("from oa_favorite f,oa_archive oa ");
            strSql.Append("where f.ref_id=oa.archive_id and f.ref_type='OA_ARCHIVE' and f.user_id='" + uId + "' ");
            strSql.Append("and oa.archive_type='" + archiveType + "') oa_favorite order by oa_favorite.create_time desc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.FAVORITE>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}