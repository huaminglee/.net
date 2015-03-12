using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:RISK_POINT_INFO
    /// </summary>
    public partial class RISK_POINT_INFO
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.RISK_POINT_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RISK_POINT_INFO(");
            strSql.Append("STEP_TYPE,STEP_ID,RISK_LEVEL,RISK_POINT,RISK_RESOLVE,REMARK)");
            strSql.Append(" values (");
            strSql.Append("@STEP_TYPE,@STEP_ID,@RISK_LEVEL,@RISK_POINT,@RISK_RESOLVE,@REMARK) ");
            SqlParameter[] parameters = {
					new SqlParameter("@STEP_TYPE", SqlDbType.NVarChar),
                    new SqlParameter("@STEP_ID",SqlDbType.Decimal,4),
					new SqlParameter("@RISK_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@RISK_POINT", SqlDbType.NVarChar),
					new SqlParameter("@RISK_RESOLVE", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar)};
            parameters[0].Value = model.STEP_TYPE;
            parameters[1].Value = model.STEP_ID;
            parameters[2].Value = model.RISK_LEVEL;
            parameters[3].Value = model.RISK_POINT;
            parameters[4].Value = model.RISK_RESOLVE;
            parameters[5].Value = model.REMARK;
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
        public bool Update(PDTech.OA.Model.RISK_POINT_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RISK_POINT_INFO set ");
            strSql.Append("STEP_TYPE=@STEP_TYPE,");
            strSql.Append("STEP_ID=@STEP_ID,");
            strSql.Append("RISK_LEVEL=@RISK_LEVEL,");
            strSql.Append("RISK_POINT=@RISK_POINT,");
            strSql.Append("RISK_RESOLVE=@RISK_RESOLVE,");
            strSql.Append("REMARK=@REMARK");
            strSql.Append(" where RISK_POINT_ID=@RISK_POINT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@STEP_TYPE", SqlDbType.NVarChar),
                    new SqlParameter("@STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RISK_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@RISK_POINT", SqlDbType.NVarChar),
					new SqlParameter("@RISK_RESOLVE", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@RISK_POINT_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.STEP_TYPE;
            parameters[1].Value = model.STEP_ID;
            parameters[2].Value = model.RISK_LEVEL;
            parameters[3].Value = model.RISK_POINT;
            parameters[4].Value = model.RISK_RESOLVE;
            parameters[5].Value = model.REMARK;
            parameters[6].Value = model.RISK_POINT_ID;
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
        public bool Delete(decimal RISK_POINT_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RISK_POINT_INFO ");
            strSql.Append(" where RISK_POINT_ID=@RISK_POINT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RISK_POINT_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = RISK_POINT_ID;

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
        /// 查询风险防控（当前类型，当前步骤）
        /// </summary>
        /// <param name="step_type">步骤类型</param>
        /// <param name="step_id">步骤ID</param>
        /// <returns>返回风险防控</returns>
        public DataTable GetRiskPointInfo(string step_type, string step_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CASE risk_level WHEN 1 THEN '一级' WHEN 2 THEN '二级' WHEN 3 THEN '三级' ELSE '其它' END as level_name,risk_point,risk_resolve,remark ");
            strSql.Append("from risk_point_info where step_type='" + step_type + "' and step_id='" + step_id + "' ");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询风险防控
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险防控列表</returns>
        public IList<Model.RISK_POINT> GetRiskPointInfo(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select risk.* from(select TOP (100) PERCENT ROW_NUMBER() OVER(ORDER BY risk_point_id) as rowno,");
            strSql.Append("CASE step_type WHEN 'OA_WORKFLOW_STEP' THEN '日常办公公文' WHEN 'SW_PROJECT_STEP' THEN '水务项目' ELSE '其它' END as type_name,");
            strSql.Append("CASE risk_level WHEN 1 THEN '一级' WHEN 2 THEN '二级' WHEN 3 THEN '三级' ELSE '其它' END as level_name,");
            strSql.Append("risk_point_id,step_id,step_type,risk_level,risk_point,risk_resolve,remark ");
            strSql.Append("from risk_point_info where 1=1 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            strSql.Append("order by risk_level desc) risk");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.RISK_POINT>(dt);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取所有风险防控点定义
        /// </summary>
        /// <returns></returns>
        public IList<Model.RISK_POINT_INFO> GetAllRiskPointInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from risk_point_info where 1=1 ");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.RISK_POINT_INFO>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}