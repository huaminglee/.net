using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_ARCHIVE_TASK
    /// </summary>
    public partial class OA_ARCHIVE_TASK
    {
        public OA_ARCHIVE_TASK()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ARCHIVE_TASK_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_ARCHIVE_TASK");
            strSql.Append(" where ARCHIVE_TASK_ID=@ARCHIVE_TASK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_TASK_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ARCHIVE_TASK_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_ARCHIVE_TASK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OA_ARCHIVE_TASK(");
            strSql.Append("ARCHIVE_TASK_ID,ARCHIVE_ID,OWNER_ID,CURRENT_STEP_ID,TASK_REMARK,TASK_STATE,TASK_TYPE,PREVIOUS_TASK_ID,START_TIME,END_TIME,LIMIT_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ARCHIVE_TASK_ID,@ARCHIVE_ID,@OWNER_ID,@CURRENT_STEP_ID,@TASK_REMARK,@TASK_STATE,@TASK_TYPE,@PREVIOUS_TASK_ID,@START_TIME,@END_TIME,@LIMIT_TIME)");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_TASK_ID", SqlDbType.Decimal,4),
					new SqlParameter("@ARCHIVE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@OWNER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@CURRENT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TASK_REMARK", SqlDbType.NVarChar),
					new SqlParameter("@TASK_STATE", SqlDbType.Decimal,2),
					new SqlParameter("@TASK_TYPE", SqlDbType.Decimal,2),
					new SqlParameter("@PREVIOUS_TASK_ID", SqlDbType.Decimal,4),
					new SqlParameter("@START_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@LIMIT_TIME", SqlDbType.DateTime)};
            parameters[0].Value = model.ARCHIVE_TASK_ID;
            parameters[1].Value = model.ARCHIVE_ID;
            parameters[2].Value = model.OWNER_ID;
            parameters[3].Value = model.CURRENT_STEP_ID;
            parameters[4].Value = model.TASK_REMARK;
            parameters[5].Value = model.TASK_STATE;
            parameters[6].Value = model.TASK_TYPE;
            parameters[7].Value = model.PREVIOUS_TASK_ID;
            parameters[8].Value = model.START_TIME;
            parameters[9].Value = model.END_TIME;
            parameters[10].Value = model.LIMIT_TIME;

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
        public bool Update(PDTech.OA.Model.OA_ARCHIVE_TASK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_ARCHIVE_TASK set ");
            strSql.Append("ARCHIVE_ID=@ARCHIVE_ID,");
            strSql.Append("OWNER_ID=@OWNER_ID,");
            strSql.Append("CURRENT_STEP_ID=@CURRENT_STEP_ID,");
            strSql.Append("TASK_REMARK=@TASK_REMARK,");
            strSql.Append("TASK_STATE=@TASK_STATE,");
            strSql.Append("TASK_TYPE=@TASK_TYPE,");
            strSql.Append("PREVIOUS_TASK_ID=@PREVIOUS_TASK_ID,");
            strSql.Append("START_TIME=@START_TIME,");
            strSql.Append("END_TIME=@END_TIME,");
            strSql.Append("LIMIT_TIME=@LIMIT_TIME");
            strSql.Append(" where ARCHIVE_TASK_ID=@ARCHIVE_TASK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@OWNER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@CURRENT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TASK_REMARK", SqlDbType.NVarChar),
					new SqlParameter("@TASK_STATE", SqlDbType.Decimal,2),
					new SqlParameter("@TASK_TYPE", SqlDbType.Decimal,2),
					new SqlParameter("@PREVIOUS_TASK_ID", SqlDbType.Decimal,4),
					new SqlParameter("@START_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@LIMIT_TIME", SqlDbType.DateTime),
					new SqlParameter("@ARCHIVE_TASK_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.ARCHIVE_ID;
            parameters[1].Value = model.OWNER_ID;
            parameters[2].Value = model.CURRENT_STEP_ID;
            parameters[3].Value = model.TASK_REMARK;
            parameters[4].Value = model.TASK_STATE;
            parameters[5].Value = model.TASK_TYPE;
            parameters[6].Value = model.PREVIOUS_TASK_ID;
            parameters[7].Value = model.START_TIME;
            parameters[8].Value = model.END_TIME;
            parameters[9].Value = model.LIMIT_TIME;
            parameters[10].Value = model.ARCHIVE_TASK_ID;

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
        /// 写入印章数据
        /// </summary>
        /// <param name="taskID"></param>
        /// <param name="sealData"></param>
        /// <returns></returns>
        public bool UpdateSealData(decimal taskID, string sealData)
        {
            string sql = "update OA_ARCHIVE_TASK set SING_DATA = @SING_DATA where ARCHIVE_TASK_ID = @ARCHIVE_TASK_ID ";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@SING_DATA",SqlDbType.Text),
                new SqlParameter("@ARCHIVE_TASK_ID",SqlDbType.Decimal,4)
            };
            parameters[0].Value = sealData;
            parameters[1].Value = taskID;

            int row = DbHelperSQL.ExecuteSql(sql, parameters);
            if (row > 0)
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
        public bool Delete(decimal ARCHIVE_TASK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_ARCHIVE_TASK ");
            strSql.Append(" where ARCHIVE_TASK_ID=@ARCHIVE_TASK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_TASK_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ARCHIVE_TASK_ID;

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
        /// 获取任务信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE_TASK> get_TaskInfoList(Model.OA_ARCHIVE_TASK where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM OA_ARCHIVE_TASK WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE_TASK>(dt);
        }

        public IList<Model.OA_ARCHIVE_TASK> get_TaskInfoList(decimal aid, decimal tid)
        {
            string strSQL = string.Format("SELECT archive_task_id,task_remark FROM OA_ARCHIVE_TASK WHERE archive_id = {0} and archive_task_id <= {1} order by archive_task_id ", aid, tid);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE_TASK>(dt);
        }

        /// <summary>
        /// 获取一条任务信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_ARCHIVE_TASK GetTaskInfo(Model.OA_ARCHIVE_TASK where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM OA_ARCHIVE_TASK WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_ARCHIVE_TASK>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        public Model.OA_ARCHIVE_TASK GetTaskInfo(decimal taskId)
        {
            string sql = "SELECT * FROM OA_ARCHIVE_TASK where ARCHIVE_TASK_ID = " + taskId;
            DataTable dt = DbHelperSQL.GetTable(sql);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE_TASK>(dt)[0];
        }
        /// <summary>
        /// 办理公文
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveHandle(PDTech.OA.Model.Pro_TASKHandle model)
        {
            int IntFlag = 0;
            try
            {
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_TASK_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_NEXT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_SKIPP_REMARK", SqlDbType.NVarChar),
					new SqlParameter("P_NEXT_USER_LIST", SqlDbType.NVarChar),
					new SqlParameter("P_TASK_REMARK", SqlDbType.NVarChar),
					new SqlParameter("P_LIMIT_TIME", SqlDbType.DateTime),
					new SqlParameter("P_IS_SEND_SMS_NOW", SqlDbType.Decimal),
					new SqlParameter("P_IS_SEND_SMS_LIMIT", SqlDbType.Decimal),
					new SqlParameter("P_SMS_LIMIT_TIME", SqlDbType.DateTime),
                    new SqlParameter("P_SMS_TO_USER_TYPE", SqlDbType.Decimal),
                    //new SqlParameter("P_PROTECT_DATA", SqlDbType.NVarChar),
					RESULTCODE};
                parameters[0].Value = model.P_TASK_ID;
                parameters[1].Value = model.P_NEXT_STEP_ID;
                parameters[2].Value = model.P_SKIPP_REMARK;
                parameters[3].Value = model.P_NEXT_USER_LIST;
                parameters[4].Value = model.P_TASK_REMARK;
                parameters[5].Value = model.P_LIMIT_TIME;
                parameters[6].Value = model.P_IS_SEND_SMS_NOW;
                parameters[7].Value = model.P_IS_SEND_SMS_LIMIT;
                parameters[8].Value = model.P_SMS_LIMIT_TIME;
                parameters[9].Value = model.P_SMS_TO_USER_TYPE;
                //parameters[10].Value = model.P_PROTECT_DATA == null ? "" : model.P_PROTECT_DATA;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_ARCHIVE_TASK_NEXT", parameters);
                if (int.Parse(RESULTCODE.Value.ToString()) > 0)
                {
                    IntFlag = 1;
                }
                else
                {
                    IntFlag = 0;
                }
            }
            catch (Exception ex)
            {
                IntFlag = 0;
            }
            return IntFlag;
        }

        /// <summary>
        /// 公文抄送
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveCopy(PDTech.OA.Model.Pro_TASKHandle model)
        {
            int IntFlag = 0;
            try
            {

                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_TASK_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_NEXT_USER_LIST", SqlDbType.NVarChar),
					new SqlParameter("P_IS_SEND_SMS", SqlDbType.NVarChar),
					RESULTCODE};
                parameters[0].Value = model.P_TASK_ID;
                parameters[1].Value = model.P_NEXT_USER_LIST;
                parameters[2].Value = model.P_IS_SEND_SMS_NOW;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_ARCHIVE_TASK_COPY", parameters);
                if (int.Parse(RESULTCODE.Value.ToString()) > 0)
                {
                    IntFlag = 1;
                }
                else
                {
                    IntFlag = 0;
                }
            }
            catch (Exception ex)
            {
                IntFlag = 0;
            }
            return IntFlag;
        }


        /// <summary>
        /// 公文退回
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveRevert(PDTech.OA.Model.Pro_TASKHandle model)
        {
            int IntFlag = 0;
            try
            {

                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_TASK_ID", SqlDbType.Decimal,4),
					RESULTCODE};
                parameters[0].Value = model.P_TASK_ID;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_ARCHIVE_TASK_REVERT", parameters);
                if (int.Parse(RESULTCODE.Value.ToString()) > 0)
                {
                    IntFlag = 1;
                }
                else
                {
                    IntFlag = 0;
                }
            }
            catch (Exception ex)
            {
                IntFlag = 0;
            }
            return IntFlag;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询待办事项
        /// </summary>
        /// <returns>返回待办事项</returns>
        public IList<Model.OA_READY_WORK> GetReadyWork(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select oa_archive_task.* from(select oa.archive_id,oa.archive_type,");
            //strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            //strSql.Append("oa.archive_title,oat.archive_task_id,oat.task_type,to_char(oat.start_time,'yyyy-mm-dd') as start_time,");
            //strSql.Append("round((select sysdate - nvl(oat.remind_time,sysdate) from dual),3) as remind_time,");
            //strSql.Append("round((select nvl(oat.limit_time,sysdate) - sysdate from dual),3) as is_expire,");
            //strSql.Append("(select nvl(oat.remind_time, nvl(oat.limit_time,oat.start_time)) from dual) as sort_time ");
            //strSql.Append("from oa_archive oa,oa_archive_task oat ");
            //strSql.Append("where oa.archive_id=oat.archive_id and oat.owner_id='" + uId + "' and oat.task_state='0' order by sort_time desc) oa_archive_task where rownum < 6");
            strSql.Append("select top 5 oa_archive_task.* from(select oa.archive_id,oa.archive_type,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("oa.archive_title,oat.archive_task_id,oat.task_type,convert(varchar(10),oat.start_time,101) as start_time,");
            strSql.Append("convert(varchar(10),oat.limit_time,101) as limit_time,");
            strSql.Append("round((datediff(second, GETDATE(), isnull(oat.remind_time,GETDATE()))) ,2) as remind_time,");
            strSql.Append("round((datediff(second , GETDATE(), isnull(oat.limit_time, GETDATE()))),2) as is_expire,");
            strSql.Append("(select isnull(oat.remind_time, isnull(oat.start_time,oat.limit_time))) as sort_time ");
            strSql.Append("from oa_archive oa,oa_archive_task oat ");
            strSql.Append("where oa.ARCHIVE_TYPE <> 71 and oa.archive_id=oat.archive_id and oat.owner_id='" + uId + "' and oat.task_state='0') oa_archive_task ");
            strSql.Append("order by sort_time desc ");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_READY_WORK>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询超期预警（日常办公公文）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回超期预警</returns>
        public IList<Model.OA_EXPIRE_DOCUMENT> GetExpireDocument(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT ROW_NUMBER() OVER(ORDER BY archive_task_id) as rowno,oa_archive_task.* from ");
            strSql.Append("(select oa.archive_id,oa.archive_type,oa.archive_title,oat.archive_task_id,");
            strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            strSql.Append("(select full_name from user_info where user_id=oat.owner_id) as owner,");
            strSql.Append("(select top 1 DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID in ( select DEPARTMENT_ID from user_info where user_id=oat.owner_id)) as owner_dept,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("(select step_name from workflow_step where step_id=oat.current_step_id) as step_name,");
            strSql.Append("convert(varchar(10),oat.limit_time,101) as limit_time,");
            strSql.Append("convert(varchar(20),oat.start_time,120) as start_time,");
            strSql.Append("(select rhm.risk_handle_archive_id from risk_handle_map rhm where rhm.archive_id = oat.archive_id and rhm.archive_task_id=oat.archive_task_id and rhm.archive_type<>33 and rhm.archive_type<>331) as risk_handle_archive_id,");
            strSql.Append("round(datediff(SECOND, GETDATE(), isnull(oat.remind_time,GETDATE())),1) as remind_time,");
            strSql.Append("round(datediff(SECOND, GETDATE(), isnull(oat.limit_time,GETDATE())),1) as is_expire ");
            strSql.Append("from oa_archive oa,oa_archive_task oat where oa.archive_id=oat.archive_id ");
            strSql.Append("and isnull(oat.remind_time,GETDATE())<= GETDATE() ");
            strSql.Append("and oat.task_state='0' and oa.archive_type<>51 and oa.archive_type<>331 and oa.archive_type<>33 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            strSql.Append(") oa_archive_task order by start_time desc");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_EXPIRE_DOCUMENT>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询风险项目（日常办公公文）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险项目</returns>
        public IList<Model.OA_RISK_DOCUMENT> GetRisk(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT ROW_NUMBER() OVER(ORDER BY archive_task_id) as rowno,risk.* from (select oa.archive_id,oa.archive_type,oa.archive_title,oat.archive_task_id,rpi.risk_point,");
            strSql.Append("case rpi.risk_level when 1 then '一级' when 2 then '二级' when 3 then '三级' else '其它' end as level_name,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            strSql.Append("(select full_name from user_info where user_id=oat.owner_id) as owner,");
            strSql.Append("(select top 1 DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_ID in ( select DEPARTMENT_ID from user_info where user_id=oat.owner_id)) as owner_dept,");
            strSql.Append("(select step_name from workflow_step where step_id=oat.current_step_id) as step_name,");
            strSql.Append("convert(varchar(10),oat.limit_time,101) as limit_time,");
            strSql.Append("convert(varchar(20),oat.start_time,120) as start_time ");
            strSql.Append("from risk_point_info rpi,oa_archive_task oat join oa_archive oa on oa.archive_id=oat.archive_id ");
            strSql.Append("where rpi.step_id=oat.current_step_id and oat.task_state=0 and rpi.step_type='OA_WORKFLOW_STEP' and oa.ARCHIVE_TYPE<>33 and oa.ARCHIVE_TYPE<>331 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            strSql.Append(") risk order by start_time desc");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_RISK_DOCUMENT>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询顶部提醒（日常公文、督办工作、建议提案、人事任免、公告）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public DataTable GetRemind(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select archive_type, count(1) as qty ");
            //strSql.Append("  from oa_archive_task oat ");
            //strSql.Append(" join oa_archive using (archive_id) ");
            //strSql.Append(" where oat.owner_id = " + uId + " ");
            //strSql.Append(" and oat.task_state = '0'  group by archive_type");
            strSql.Append("select archive_type, count(1) as qty ");
            strSql.Append("  from oa_archive_task oat ");
            strSql.Append(" left join oa_archive oa on oat.archive_id = oa.archive_id ");
            strSql.Append(" where oat.owner_id = " + uId + " ");
            strSql.Append(" and oat.task_state = '0'  group by archive_type ");
            strSql.Append("union all select 999 as archive_type, COUNT (1)  as qyy ");
            strSql.Append("from OA_RISKEDUCATION a inner join OA_RISKEDURECEIVER b on a.EDUCATION_ID=b.EDUCATION_ID ");
            strSql.Append("where b.RECEIVER_ID=" + uId + " and b.READ_STATUS =0 ");
            strSql.Append("union all select 1000 as archive_type,COUNT(1) as qyy ");
            strSql.Append("from OA_EDUTEST c where  c.EDU_T_GUID  in  ");
            strSql.Append("(select distinct EDU_T_GUID from OA_QUESTION_TEST_MAP d where d.EDU_MAP_GUID not in ");
            strSql.Append("(select EDU_MAP_GUID from OA_TEST_ANSWER e where e.ANSWER_ID=" + uId + " ))");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查询顶部提醒 公告消息
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindMessage(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from oa_message_receiver omr where omr.receiver_id= " + uId + " and omr.read_status='0'");
            return DbHelperSQL.GetScalar(strSql.ToString());
        }

        /// <summary>
        /// 查询顶部提醒 会议
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindMeeting(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_MEETING_RECEIVER omr join OA_MEETING USING(MEETING_ID) where omr.receiver_id= " + uId + " and omr.read_status='0'  AND START_TIME<SYSDATE ");
            return DbHelperSQL.GetScalar(strSql.ToString());
        }

        /// <summary>
        /// 查询顶部提醒 超期风险处置提醒
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindRISK(string uId,bool isall=false)
        {
            StringBuilder strSql = new StringBuilder();
            if (isall)
            {
                strSql.Append("SELECT COUNT(1) FROM OVER_TIME_RISK_REMIND WHERE STATUS='0'");
            }
            else
            {
                strSql.Append(string.Format(@"SELECT COUNT(1) FROM OVER_TIME_RISK_REMIND WHERE STATUS='0' and  ( USER_ID= {0} or
  USER_ID=( select USER_ID from USER_INFO where DEPARTMENT_ID in (select DEPARTMENT_ID from USERS_DEPT_OWNER_MAP where USER_ID={0})) 
            ) or (USER_ID in (select USER_ID from USER_INFO where DEPARTMENT_ID in(select DEPARTMENT_ID from DEPARTMENT_DEFAULT_USER where USER_ID={0})))", uId));
            }
            
            return DbHelperSQL.GetScalar(strSql.ToString());
        }

        /// <summary>
        /// 公文查询
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回公文查询</returns>
        public IList<Model.OA_MAJOR> GetDocument(string uId, string strWhere, string currentPage, string pageSize, out int totalNum,bool isall=false)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select rownum as rowno,task.* from (select oa.archive_id,oa.archive_title,oa.archive_type,");
            //strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            //strSql.Append("decode(oa.pri_level,0,'普通',1,'急件',2,'特急','其它') as pri_level,");
            //strSql.Append("to_char(oa.create_time,'yyyy-mm-dd') as create_time,");
            //strSql.Append("(select count(1) from oa_attachment_file where ref_id=oa.archive_id and ref_type='oa_archive') as attachment_count,");
            //strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            //strSql.Append("(select step_name from workflow_step where step_id=oa.current_step_id) as current_step_id ");
            //strSql.Append("from oa_archive oa,oa_archive_task oat where oa.archive_id=oat.archive_id and oat.owner_id='" + uId + "' ");
            strSql.Append("select TOP (100) PERCENT ROW_NUMBER() OVER(ORDER BY archive_id) as rowno,task.* from (select oa.archive_id,oa.archive_title,oa.archive_type,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("case oa.pri_level when 0 then '普通' when 1 then '急件' when 2 then '特急' else '其它' end as pri_level,");
            strSql.Append("convert(varchar(10),oa.create_time,120) as create_time,");
            strSql.Append("(select count(1) from oa_attachment_file where ref_id=oa.archive_id and ref_type='oa_archive') as attachment_count,");
            strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            strSql.Append("(select step_name from workflow_step where step_id=oa.current_step_id) as current_step_id ");
            strSql.Append("from oa_archive oa where EXISTS (select * from oa_archive_task oat where oa.archive_id=oat.archive_id ");
            strSql.Append("and oat.TASK_TYPE = 0 ");
            if (!isall)
            {
                if (uId.Length > 0)
                {
                    strSql.Append("and oat.owner_id in (" + uId + ")");
                }
            }
           
            strSql.Append(")");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            strSql.Append(") task ");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);      //当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString(), "create_time", "desc");
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_MAJOR>(dt);
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}