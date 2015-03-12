using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:USER_RISK_MAP
    /// </summary>
    public partial class USER_RISK_MAP
    {
        public USER_RISK_MAP()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.USER_RISK_MAP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USER_RISK_MAP(");
            strSql.Append("USER_ID,DUTY_RISK_ID)");
            strSql.Append(" values (");
            strSql.Append("@USER_ID,@DUTY_RISK_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal),
					new SqlParameter("@DUTY_RISK_ID", SqlDbType.Decimal)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.DUTY_RISK_ID;

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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.USER_RISK_MAP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USER_RISK_MAP set ");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("DUTY_RISK_ID=@DUTY_RISK_ID");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal),
					new SqlParameter("@DUTY_RISK_ID", SqlDbType.Decimal)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.DUTY_RISK_ID;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="duty_risk_id">风险ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(decimal duty_risk_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_risk_map ");
            strSql.Append("where duty_risk_id=@duty_risk_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@duty_risk_id", SqlDbType.Decimal)};
            parameters[0].Value = duty_risk_id;
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
    }
}