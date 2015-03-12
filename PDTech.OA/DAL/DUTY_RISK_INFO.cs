using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;//Please add references

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:DUTY_RISK_INFO
    /// </summary>
    public partial class DUTY_RISK_INFO
    {
        DataTable dt;
        public DUTY_RISK_INFO()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.DUTY_RISK_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DUTY_RISK_INFO(");
            strSql.Append("DUTY_NAME,RISK_NAME,RISK_LEVEL,AVOID_METOH,DEPARTMENT_ID)");
            strSql.Append(" values (");
            strSql.Append("@DUTY_NAME,@RISK_NAME,@RISK_LEVEL,@AVOID_METOH,@DEPARTMENT_ID) ");
            strSql.Append("select @OUT_DUTY_ID = SCOPE_IDENTITY() ");
            SqlParameter did_out = new SqlParameter("@OUT_DUTY_ID", OracleType.Int32);
            did_out.Direction = ParameterDirection.Output;
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_NAME", SqlDbType.NVarChar),
					new SqlParameter("@RISK_NAME", SqlDbType.NVarChar),
					new SqlParameter("@RISK_LEVEL", SqlDbType.Char,1),
					new SqlParameter("@AVOID_METOH", SqlDbType.NVarChar),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
                                           did_out};
            parameters[0].Value = model.DUTY_NAME;
            parameters[1].Value = model.RISK_NAME;
            parameters[2].Value = model.RISK_LEVEL;
            parameters[3].Value = model.AVOID_METOH;
            parameters[4].Value = model.DEPARTMENT_ID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            model.DUTY_RISK_ID = Decimal.Parse(did_out.Value.ToString());
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
        public bool Update(PDTech.OA.Model.DUTY_RISK_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DUTY_RISK_INFO set ");
            strSql.Append("DUTY_NAME=@DUTY_NAME,");
            strSql.Append("RISK_NAME=@RISK_NAME,");
            strSql.Append("RISK_LEVEL=@RISK_LEVEL,");
            strSql.Append("AVOID_METOH=@AVOID_METOH,");
            strSql.Append("DEPARTMENT_ID=@DEPARTMENT_ID");
            strSql.Append(" where DUTY_RISK_ID=@DUTY_RISK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_NAME", SqlDbType.NVarChar),
					new SqlParameter("@RISK_NAME", SqlDbType.NVarChar),
					new SqlParameter("@RISK_LEVEL", SqlDbType.Char,1),
					new SqlParameter("@AVOID_METOH", SqlDbType.NVarChar),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@DUTY_RISK_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.DUTY_NAME;
            parameters[1].Value = model.RISK_NAME;
            parameters[2].Value = model.RISK_LEVEL;
            parameters[3].Value = model.AVOID_METOH;
            parameters[4].Value = model.DEPARTMENT_ID;
            parameters[5].Value = model.DUTY_RISK_ID;

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
        public bool Delete(decimal DUTY_RISK_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DUTY_RISK_INFO ");
            strSql.Append(" where DUTY_RISK_ID=@DUTY_RISK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_RISK_ID", SqlDbType.Decimal,22)};
            parameters[0].Value = DUTY_RISK_ID;
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
        /// 查询岗位风险（当前用户最新的一条）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回当前用户最新的一条岗位风险</returns>
        public IList<Model.DUTY_RISK> GetRiskInfo(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select risk.* from (select dri.risk_name,dri.avoid_metoh,dri.risk_level ");
            //strSql.Append("from duty_risk_info dri,user_risk_map udri,user_info u ");
            //strSql.Append("where dri.duty_risk_id=udri.duty_risk_id and udri.user_id=u.user_id and u.user_id='" + uId + "' ");
            //strSql.Append("order by dri.duty_risk_id desc) risk where rownum < 2");
            strSql.Append("select top 1 risk.* from (select dri.duty_risk_id,dri.risk_name,dri.avoid_metoh,dri.risk_level ");
            strSql.Append("from duty_risk_info dri,user_risk_map udri,user_info u ");
            strSql.Append("where dri.duty_risk_id=udri.duty_risk_id and udri.user_id=u.user_id and u.user_id='" + uId + "') risk ");
            strSql.Append("order by risk.duty_risk_id desc");
            dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.DUTY_RISK>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询岗位风险（当前用户的所有）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回当前用户的所有岗位风险</returns>
        public IList<Model.DUTY_RISK> GetRiskInfoMore(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select rownum as rowno,risk.* from (select dri.duty_name,dri.risk_name,dri.avoid_metoh,dri.risk_level ");
            //strSql.Append("from duty_risk_info dri,user_risk_map udri,user_info u ");
            //strSql.Append("where dri.duty_risk_id=udri.duty_risk_id and udri.user_id=u.user_id and u.user_id='" + uId + "' ");
            //strSql.Append("order by dri.duty_risk_id desc) risk");
            strSql.Append("select ROW_NUMBER() OVER(ORDER BY duty_risk_id) as rowno,risk.* ");
            strSql.Append("from (select top 100 percent dri.duty_risk_id,dri.duty_name,dri.risk_name,dri.avoid_metoh,dri.risk_level ");
            strSql.Append("from duty_risk_info dri,user_risk_map udri,user_info u ");
            strSql.Append("where dri.duty_risk_id=udri.duty_risk_id and udri.user_id=u.user_id and u.user_id='" + uId + "' ");
            strSql.Append("order by dri.duty_risk_id desc) risk");
            dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.DUTY_RISK>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询岗位风险（所有）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回岗位风险</returns>
        public IList<Model.DUTY_RISK> GetAllRiskInfo(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select rownum as rowno,duty_risk_info.* from ");
            //strSql.Append("(select dri.duty_risk_id,d.department_name,dri.duty_name,dri.risk_name,dri.avoid_metoh,");
            //strSql.Append("decode(dri.risk_level,1,'一级',2,'二级',3,'三级','其它') as risk_level ");
            //strSql.Append("from duty_risk_info dri join department d on d.department_id=dri.department_id where 1=1 ");
            strSql.Append("select ROW_NUMBER() OVER(ORDER BY DUTY_RISK_ID DESC) as rowno,duty_risk_info.* from ");
            strSql.Append("(select top 100 percent dri.duty_risk_id,d.department_name,dri.duty_name,dri.risk_name,dri.avoid_metoh,d.sort_num,");
            strSql.Append("case dri.risk_level when 1 then '一级' when 2 then '二级' when 3 then '三级' else '其它' end as risk_level ");
            strSql.Append("from duty_risk_info dri join department d on d.department_id=dri.department_id where 1=1 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            strSql.Append("order by d.sort_num asc) duty_risk_info");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString(), "rowno", "ASC");
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.DUTY_RISK>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}