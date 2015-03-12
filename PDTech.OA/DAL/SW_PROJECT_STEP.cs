using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:SW_PROJECT_STEP
    /// </summary>
    public partial class SW_PROJECT_STEP
    {
        public SW_PROJECT_STEP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal PROJECT_STEP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SW_PROJECT_STEP");
            strSql.Append(" where PROJECT_STEP_ID=@PROJECT_STEP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PROJECT_STEP_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = PROJECT_STEP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool FirstUpdate(PDTech.OA.Model.SW_PROJECT_STEP model)
        {
            SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
            RESULTCODE.Direction = ParameterDirection.Output;
            SqlParameter[] parameters_p = {
					new SqlParameter("P_PROJECT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_PLAN_END_TIME", SqlDbType.DateTime),
                    RESULTCODE
                                             };
            parameters_p[0].Value = model.PROJECT_STEP_ID;
            parameters_p[1].Value = model.PLAN_ENDTIME;
            DAL_Helper.get_db_para_value(parameters_p);
            DbHelperSQL.RunProcedure_Add("PD_SET_SW_PROJECT_LIMT_TIME", parameters_p);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SW_PROJECT_STEP set ");
            strSql.Append("START_TIME=@START_TIME,END_TIME=@END_TIME,");
            strSql.Append("OWNER=@OWNER,");
            strSql.Append("STEP_STATUS=@STEP_STATUS,");
            strSql.Append("PLAN_ENDTIME=@PLAN_ENDTIME,");
            strSql.Append("REMARK=@REMARK");
            strSql.Append(" where PROJECT_STEP_ID=@PROJECT_STEP_ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@START_TIME",SqlDbType.DateTime),
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@OWNER", SqlDbType.Decimal,4),
					new SqlParameter("@STEP_STATUS", SqlDbType.Decimal,4),
                    new SqlParameter("@PLAN_ENDTIME", SqlDbType.DateTime),
                    new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@PROJECT_STEP_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.START_TIME;
            parameters[1].Value = model.END_TIME;
            parameters[2].Value = model.OWNER;
            parameters[3].Value = model.STEP_STATUS;
            parameters[4].Value = model.PLAN_ENDTIME;
            parameters[5].Value = model.REMARK;
            parameters[6].Value = model.PROJECT_STEP_ID;
            DAL_Helper.get_db_para_value(parameters);
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
        /// 审核
        /// </summary>
        public bool FirstAudit(decimal attID, IList<PDTech.OA.Model.ATTRIBUTES> AttList)
        {
            IList<sqlTrasExcuteComm> trasList = new List<sqlTrasExcuteComm>();
            #region 选择添加扩展属性
            foreach (var item in AttList)
            {
                sqlTrasExcuteComm Add_tras = new sqlTrasExcuteComm();
                sqlTrasExcuteComm del_tras = new sqlTrasExcuteComm();
                //删除语句拼接
                StringBuilder delSql = new StringBuilder();
                delSql.Append("delete from ATTRIBUTES ");
                delSql.Append(" where LOG_ID=@LOG_ID AND [KEY]=@KEY ");
                SqlParameter[] dparameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,22),
                    new SqlParameter("@KEY", SqlDbType.NVarChar)};
                dparameters[0].Value = attID;
                dparameters[1].Value = item.KEY;
                //新增语句
                StringBuilder Att_Add_Sql = new StringBuilder();
                Att_Add_Sql.Append("insert into ATTRIBUTES(");
                Att_Add_Sql.Append("LOG_ID,[KEY],VALUE)");
                Att_Add_Sql.Append(" values (");
                Att_Add_Sql.Append("@LOG_ID,@KEY,@VALUE)");
                SqlParameter[] Att_parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,4),
					new SqlParameter("@KEY", SqlDbType.VarChar,50),
					new SqlParameter("@VALUE", SqlDbType.VarChar,1000)};
                Att_parameters[0].Value = attID;
                Att_parameters[1].Value = item.KEY;
                Att_parameters[2].Value = item.VALUE;

                DAL_Helper.get_db_para_value(dparameters);
                DAL_Helper.get_db_para_value(Att_parameters);
                del_tras.commandText = delSql.ToString();
                del_tras.parameters = dparameters;
                del_tras.type = CommandType.Text;

                Add_tras.commandText = Att_Add_Sql.ToString();
                Add_tras.parameters = Att_parameters;
                Add_tras.type = CommandType.Text;
                trasList.Add(del_tras);
                trasList.Add(Add_tras);
            }
            DbHelperSQL.ExecuteSqlTran(trasList);
            return true;
            #endregion

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.SW_PROJECT_STEP model)
        {
            SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
            RESULTCODE.Direction = ParameterDirection.Output;
            SqlParameter[] parameters_p = {
					new SqlParameter("P_PROJECT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_PLAN_END_TIME", SqlDbType.DateTime),
                    RESULTCODE
                                             };
            parameters_p[0].Value = model.PROJECT_STEP_ID;
            parameters_p[1].Value = model.PLAN_ENDTIME;
            DAL_Helper.get_db_para_value(parameters_p);
            DbHelperSQL.RunProcedure_Add("PD_SET_SW_PROJECT_LIMT_TIME", parameters_p);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SW_PROJECT_STEP set ");
            strSql.Append("END_TIME=@END_TIME,");
            strSql.Append("STEP_STATUS=@STEP_STATUS,");
            strSql.Append("PLAN_ENDTIME=@PLAN_ENDTIME,");
            strSql.Append("REMARK=@REMARK");
            strSql.Append(" where PROJECT_STEP_ID=@PROJECT_STEP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@STEP_STATUS", SqlDbType.Decimal,4),
                    new SqlParameter("@PLAN_ENDTIME", SqlDbType.DateTime),
                    new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@PROJECT_STEP_ID", SqlDbType.Decimal,4)};

            parameters[0].Value = model.END_TIME;
            parameters[1].Value = model.STEP_STATUS;
            parameters[2].Value = model.PLAN_ENDTIME;
            parameters[3].Value = model.REMARK;
            parameters[4].Value = model.PROJECT_STEP_ID;
            DAL_Helper.get_db_para_value(parameters);
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
        public bool Delete(decimal PROJECT_STEP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SW_PROJECT_STEP ");
            strSql.Append(" where PROJECT_STEP_ID=@PROJECT_STEP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PROJECT_STEP_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = PROJECT_STEP_ID;

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
        /// 查询超期预警（水务项目）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回超期预警</returns>
        public IList<Model.SW_EXPIRE_WATER> GetExpireWater(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT ROW_NUMBER() OVER (ORDER BY start_time desc) AS rowno,sw_project_step.* from(select TOP (100) PERCENT sps.project_id,sps.project_step_id,");
            strSql.Append("(select project_name from sw_project_info where project_id=sps.project_id) as project_name,");
            strSql.Append("CASE(select file_dept from sw_project_info where project_id=sps.project_id) WHEN 1 THEN '规计处' WHEN 2 THEN '财务处' ELSE '其它' END as file_dept_name,");
            strSql.Append("(select full_name from user_info where user_id=(select creator from sw_project_info where project_id=sps.project_id)) as creator,");
            strSql.Append("(select full_name from user_info where user_id=sps.owner) as owner,");
            strSql.Append("(select top 1 DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID in ( select DEPARTMENT_ID from user_info where user_id=sps.owner)) as owner_dept,");
            strSql.Append("CONVERT(VARCHAR,sps.start_time,20) as start_time,");
            strSql.Append("(select step_name from sw_project_step_type where step_id=sps.step_id) as step_name,");
            strSql.Append("CONVERT(VARCHAR(10),sps.limit_time,20) as limit_time,");
            strSql.Append("(select rhm.risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id = sps.project_id and rhm.archive_task_id=sps.project_step_id and (rhm.archive_type=33 or rhm.archive_type=331)) as risk_handle_archive_id ");
            strSql.Append("from sw_project_step sps where (isnull(sps.limit_time, getdate()) < GETDATE() OR isnull(sps.Remind_Time, GETDATE()) < GETDATE()) and sps.step_status=1 ");
            strSql.Append("order by sps.start_time desc) sw_project_step where 1=1 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.SW_EXPIRE_WATER>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询风险项目（水务项目）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险项目</returns>
        public IList<Model.SW_RISK_WATER> GetRiskWater(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ROW_NUMBER() OVER (ORDER BY start_time desc)  as rowno,riskWater.* from(select TOP (100) PERCENT sps.project_id,rpi.risk_point,");
            strSql.Append("(select project_name from sw_project_info where project_id=sps.project_id) as project_name,");
            strSql.Append("CASE(select file_dept from sw_project_info where project_id=sps.project_id) WHEN 1 THEN '规计处' WHEN 2 THEN '财务处' ELSE '其它' END as file_dept_name,");
            strSql.Append("(select full_name from user_info where user_id=(select creator from sw_project_info where project_id=sps.project_id)) as creator,");
            strSql.Append("(select full_name from user_info where user_id=sps.owner) as owner,");
            strSql.Append("(select top 1 DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID in ( select DEPARTMENT_ID from user_info where user_id=sps.owner)) as owner_dept,");
            strSql.Append("CONVERT(VARCHAR,sps.start_time,20) as start_time,");
            strSql.Append("(select step_name from sw_project_step_type where step_id=sps.step_id) as step_name,");
            strSql.Append("CONVERT(VARCHAR(10),sps.limit_time,20) as limit_time,");
            strSql.Append("CASE rpi.risk_level WHEN 1 THEN '一级' WHEN 2 THEN '二级' WHEN 3 THEN '三级' ELSE '其它' END as level_name ");
            strSql.Append("from sw_project_step sps,risk_point_info rpi where rpi.step_id=sps.step_id ");
            strSql.Append("and sps.step_status=1 and rpi.step_type='SW_PROJECT_STEP' order by sps.start_time desc) riskWater where 1=1");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.SW_RISK_WATER>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}