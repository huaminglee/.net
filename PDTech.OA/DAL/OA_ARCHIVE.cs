using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
using PDTech.OA.Model;
using System.Data.SqlClient;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_ARCHIVE
    /// </summary>
    public partial class OA_ARCHIVE
    {
        public OA_ARCHIVE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ARCHIVE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_ARCHIVE");
            strSql.Append(" where ARCHIVE_ID=@ARCHIVE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ARCHIVE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_ARCHIVE model, string HostName, string Ip, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList, out int? ARCHIVE_ID, out int? TASK_ID)
        {
            try
            {
                if (Exists(model.ARCHIVE_ID))
                {
                    PDTech.OA.Model.OA_ARCHIVE where = GetArchiveInfo(model.ARCHIVE_ID);
                    ARCHIVE_ID = null;
                    TASK_ID = null;
                    return false;
                }
                if (model.LIMIT_TIME != null)
                {
                    model.LIMIT_TIME = Convert.ToDateTime(model.LIMIT_TIME).AddDays(1);
                }
                IList<sqlTrasExcuteComm> trasList = new List<sqlTrasExcuteComm>();
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter O_ARCHIVE_ID = new SqlParameter("O_ARCHIVE_ID", SqlDbType.Int);
                O_ARCHIVE_ID.Direction = ParameterDirection.Output;
                SqlParameter O_TASK_ID = new SqlParameter("O_TASK_ID", SqlDbType.Int);
                O_TASK_ID.Direction = ParameterDirection.Output;
                SqlParameter O_ATTRIBUTE_LOG_ID = new SqlParameter("O_ATTRIBUTE_LOG_ID", SqlDbType.Int);
                O_ATTRIBUTE_LOG_ID.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_TYPE", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("P_PRI_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("P_IS_SECRET", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_NO", SqlDbType.NVarChar),
					new SqlParameter("P_ARCHIVE_TITLE", SqlDbType.NVarChar),
					new SqlParameter("P_ARCHIVE_CONTENT", SqlDbType.Text),
					new SqlParameter("P_LIMIT_TIME", SqlDbType.DateTime),
                    new SqlParameter("P_RECEIVE_TIME", SqlDbType.DateTime),
					new SqlParameter("P_IS_SHOW_IN_SZYD", SqlDbType.NVarChar),
					new SqlParameter("P_OA_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
					new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
					new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                                               RESULTCODE,O_ARCHIVE_ID,O_TASK_ID,O_ATTRIBUTE_LOG_ID};
                parameters[0].Value = model.CREATOR;
                parameters[1].Value = model.ARCHIVE_TYPE;
                parameters[2].Value = model.ARCHIVE_LEVEL;
                parameters[3].Value = model.PRI_LEVEL;
                parameters[4].Value = model.IS_SECRET;
                parameters[5].Value = model.ARCHIVE_NO;
                parameters[6].Value = model.ARCHIVE_TITLE;
                parameters[7].Value = model.ARCHIVE_CONTENT;
                parameters[8].Value = model.LIMIT_TIME;
                parameters[9].Value = model.RECEIVE_TIME;
                parameters[10].Value = model.IS_SHOW_IN_SZYD??"0";
                parameters[11].Value = Ids;
                parameters[12].Value = Ip;
                parameters[13].Value = HostName;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_ARCHIVE", parameters);
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
                    dparameters[0].Value = O_ATTRIBUTE_LOG_ID.Value;
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
                    Att_parameters[0].Value = O_ATTRIBUTE_LOG_ID.Value;
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
                #endregion

                ARCHIVE_ID = int.Parse(O_ARCHIVE_ID.Value.ToString());
                TASK_ID = int.Parse(O_TASK_ID.Value.ToString());
                return true;

            }
            catch (Exception ex)
            {
                ARCHIVE_ID = null;
                TASK_ID = null;
                return false;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddRisk(PDTech.OA.Model.OA_ARCHIVE model, string HostName, string Ip, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList, int p_ArchiveID, int p_taskID, int ptype, int rId, out int? ARCHIVE_ID, out int? TASK_ID)
        {
            try
            {
                if (Exists(model.ARCHIVE_ID))
                {
                    PDTech.OA.Model.OA_ARCHIVE where = GetArchiveInfo(model.ARCHIVE_ID);
                    ARCHIVE_ID = null;
                    TASK_ID = null;
                    return false;
                }
                if (model.LIMIT_TIME != null)
                {
                    model.LIMIT_TIME = Convert.ToDateTime(model.LIMIT_TIME).AddDays(1);
                }
                IList<sqlTrasExcuteComm> trasList = new List<sqlTrasExcuteComm>();
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", OracleType.Int32);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter O_ARCHIVE_ID = new SqlParameter("O_ARCHIVE_ID", OracleType.Int32);
                O_ARCHIVE_ID.Direction = ParameterDirection.Output;
                SqlParameter O_TASK_ID = new SqlParameter("O_TASK_ID", OracleType.Int32);
                O_TASK_ID.Direction = ParameterDirection.Output;
                SqlParameter O_ATTRIBUTE_LOG_ID = new SqlParameter("O_ATTRIBUTE_LOG_ID", OracleType.Int32);
                O_ATTRIBUTE_LOG_ID.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_TYPE", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("P_PRI_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("P_IS_SECRET", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_NO", SqlDbType.NVarChar),
					new SqlParameter("P_ARCHIVE_TITLE", SqlDbType.NVarChar),
					new SqlParameter("P_ARCHIVE_CONTENT", SqlDbType.Text),
					new SqlParameter("P_LIMIT_TIME", SqlDbType.DateTime),
                    new SqlParameter("P_RECEIVE_TIME", SqlDbType.DateTime),
					new SqlParameter("P_IS_SHOW_IN_SZYD", SqlDbType.NVarChar),
					new SqlParameter("P_OA_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
					new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
					new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                    new SqlParameter("P_FROM_ARCHIVE_ID", SqlDbType.NVarChar),
                    new SqlParameter("P_FROM_TASK_ID", SqlDbType.NVarChar),
                    new SqlParameter("P_FROM_ARCHIVE_TYPE", SqlDbType.NVarChar),
                    new SqlParameter("P_OVER_TIME_RISK_REMIND_ID", SqlDbType.NVarChar),
                                               RESULTCODE,O_ARCHIVE_ID,O_TASK_ID,O_ATTRIBUTE_LOG_ID};
                parameters[0].Value = model.CREATOR;
                parameters[1].Value = model.ARCHIVE_TYPE;
                parameters[2].Value = model.ARCHIVE_LEVEL;
                parameters[3].Value = model.PRI_LEVEL;
                parameters[4].Value = model.IS_SECRET;
                parameters[5].Value = model.ARCHIVE_NO;
                parameters[6].Value = model.ARCHIVE_TITLE;
                parameters[7].Value = model.ARCHIVE_CONTENT;
                parameters[8].Value = model.LIMIT_TIME;
                parameters[9].Value = model.RECEIVE_TIME;
                parameters[10].Value = model.IS_SHOW_IN_SZYD ?? "0";
                parameters[11].Value = Ids;
                parameters[12].Value = Ip;
                parameters[13].Value = HostName;
                parameters[14].Value = p_ArchiveID;
                parameters[15].Value = p_taskID;
                parameters[16].Value = ptype;
                parameters[17].Value = rId;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_RISK_HANDLE_ARCHIVE", parameters);
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
                    dparameters[0].Value = O_ATTRIBUTE_LOG_ID.Value;
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
                    Att_parameters[0].Value = O_ATTRIBUTE_LOG_ID.Value;
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
                #endregion

                ARCHIVE_ID = int.Parse(O_ARCHIVE_ID.Value.ToString());
                TASK_ID = int.Parse(O_TASK_ID.Value.ToString());
                return true;

            }
            catch (Exception ex)
            {
                ARCHIVE_ID = null;
                TASK_ID = null;
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.OA_ARCHIVE model, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList)
        {
            try
            {
                IList<sqlTrasExcuteComm> trasList = new List<sqlTrasExcuteComm>();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update OA_ARCHIVE set ");
                strSql.Append("ARCHIVE_TYPE=@ARCHIVE_TYPE,");
                strSql.Append("ARCHIVE_LEVEL=@ARCHIVE_LEVEL,");
                strSql.Append("ARCHIVE_NO=@ARCHIVE_NO,");
                strSql.Append("ARCHIVE_TITLE=@ARCHIVE_TITLE,");
                strSql.Append("ARCHIVE_CONTENT=@ARCHIVE_CONTENT,");
                strSql.Append("LIMIT_TIME=@LIMIT_TIME,");
                strSql.Append("IS_SHOW_IN_SZYD=@IS_SHOW_IN_SZYD,");
                strSql.Append("RECEIVE_TIME=@RECEIVE_TIME,");
                strSql.Append("IS_SECRET=@IS_SECRET,");
                strSql.Append("PRI_LEVEL=@PRI_LEVEL");
                strSql.Append(" where ARCHIVE_ID=@ARCHIVE_ID ");
                SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_TYPE", SqlDbType.Decimal,4),
					new SqlParameter("@ARCHIVE_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@ARCHIVE_NO", SqlDbType.NVarChar),
					new SqlParameter("@ARCHIVE_TITLE", SqlDbType.NVarChar),
					new SqlParameter("@ARCHIVE_CONTENT", SqlDbType.Text),
					new SqlParameter("@LIMIT_TIME", SqlDbType.DateTime),
					new SqlParameter("@IS_SHOW_IN_SZYD", SqlDbType.Char,1),
                    new SqlParameter("@RECEIVE_TIME", SqlDbType.DateTime),
                    new SqlParameter("@IS_SECRET", SqlDbType.Decimal,4),
                    new SqlParameter("@PRI_LEVEL", SqlDbType.Decimal,4),
					new SqlParameter("@ARCHIVE_ID", SqlDbType.Decimal,4)};
                parameters[0].Value = model.ARCHIVE_TYPE;
                parameters[1].Value = model.ARCHIVE_LEVEL;
                parameters[2].Value = model.ARCHIVE_NO;
                parameters[3].Value = model.ARCHIVE_TITLE;
                parameters[4].Value = model.ARCHIVE_CONTENT;
                parameters[5].Value = model.LIMIT_TIME;
                parameters[6].Value = model.IS_SHOW_IN_SZYD;
                parameters[7].Value = model.RECEIVE_TIME;
                parameters[8].Value = model.IS_SECRET;
                parameters[9].Value = model.PRI_LEVEL;
                parameters[10].Value = model.ARCHIVE_ID;
                DAL_Helper.get_db_para_value(parameters);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
                    dparameters[0].Value = model.ATTRIBUTE_LOG;
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
                    Att_parameters[0].Value = model.ATTRIBUTE_LOG;
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
                #endregion
                if (!string.IsNullOrEmpty(Ids))
                {
                    string ModSQL = string.Format("UPDATE OA_ATTACHMENT_FILE SET REF_ID={0},REF_TYPE='OA_ARCHIVE' WHERE ATTACHMENT_FILE_ID IN({1})", model.ARCHIVE_ID, Ids);
                    DbHelperSQL.ExecuteSql(ModSQL);
                }
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ARCHIVE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_ARCHIVE ");
            strSql.Append(" where ARCHIVE_ID=@ARCHIVE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ARCHIVE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ARCHIVE_ID;

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
        /// 获取公文列表信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_ArchiveInfoList(Model.OA_ARCHIVE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM OA_ARCHIVE WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt);
        }
        /// <summary>
        /// 获取一条公文信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_ARCHIVE GetArchiveInfo(decimal aId)
        {
            string strSQL = string.Format("SELECT * FROM OA_ARCHIVE WHERE ARCHIVE_ID={0}", aId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取公文列表信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveInfoList(Model.OA_ARCHIVE where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT  TOP (100) PERCENT * FROM OA_ARCHIVE WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt);
        }

        /// <summary>
        /// 公文流程转向
        /// </summary>
        /// <param name="Opter">操作人员ID</param>
        /// <param name="arId">公文ID</param>
        /// <param name="nextStempId">下一步骤ID</param>
        /// <param name="reMark">备注</param>
        /// <param name="userList">用户ID</param>
        /// <returns></returns>
        public bool RELOCATE(decimal Opter, decimal arId, decimal nextStempId, string reMark, string userList)
        {
            SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
            RESULTCODE.Direction = ParameterDirection.Output;
            SqlParameter[] parameters = {
					new SqlParameter("P_CHANGE_USER", SqlDbType.Decimal,4),
					new SqlParameter("P_ARCHIVE_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_NEXT_STEP_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_SKIPP_REMARK", SqlDbType.NVarChar),
					new SqlParameter("P_NEXT_USER_LIST", SqlDbType.NVarChar),
                                               RESULTCODE};
            parameters[0].Value = Opter;
            parameters[1].Value = arId;
            parameters[2].Value = nextStempId;
            parameters[3].Value = reMark;
            parameters[4].Value = userList;
            DAL_Helper.get_db_para_value(parameters);
            DbHelperSQL.RunProcedure_Add("PD_ARCHIVE_TASK_RELOCATE", parameters);
            if (int.Parse(RESULTCODE.Value.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取公文列表信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllList(Model.OA_ARCHIVE where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT  TOP (100) PERCENT O.*,
(SELECT TYPE_NAME FROM OA_ARCHIVE_TYPE WHERE ARCHIVE_TYPE=O.ARCHIVE_TYPE ) AS ARCHIVE_TYPE_NAME
FROM OA_ARCHIVE O WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt);
        }
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllListszyd(int currentpage, int pagesize, out int totalrecord)
        {            
            string strSQL = @"SELECT  TOP (100) PERCENT O.*,
(SELECT TYPE_NAME FROM OA_ARCHIVE_TYPE WHERE ARCHIVE_TYPE=O.ARCHIVE_TYPE ) AS ARCHIVE_TYPE_NAME
FROM OA_ARCHIVE O WHERE IS_SHOW_IN_SZYD=1 or ARCHIVE_TYPE=71 order by CREATE_TIME desc ";
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "CREATE_TIME", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt);
        }
        /// <summary>
        /// 获取公文列表信息-未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllList(Model.OA_ARCHIVE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT O.*,
(SELECT TYPE_NAME FROM OA_ARCHIVE_TYPE WHERE ARCHIVE_TYPE=O.ARCHIVE_TYPE ) AS ARCHIVE_TYPE_NAME
FROM OA_ARCHIVE O WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ARCHIVE>(dt);
        }
         /// <summary>
        /// 获取公文列表信息-未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_USER_DEPT> get_Paging_ArchiveAllList(Model.VIEW_ARCHIVE_USER_DEPT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT * FROM VIEW_ARCHIVE_USER_DEPT WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVE_USER_DEPT>(dt);
        }
        /// <summary>
        /// 查询教育任务和在线考试数量
        /// </summary>
        /// <returns></returns>
        public string get_edutaskandonlinetestcount()
        {
            string strSQL = @"select 999 as archive_type, COUNT (1)  as qyy
            from OA_RISKEDUCATION a inner join OA_RISKEDURECEIVER b on a.EDUCATION_ID=b.EDUCATION_ID 
           where   b.READ_STATUS =0 
           union all select 1000 as archive_type,COUNT(1) as qyy 
           from OA_EDUTEST c where  c.EDU_T_GUID  in  
           (select distinct EDU_T_GUID from OA_QUESTION_TEST_MAP d where d.EDU_MAP_GUID not in 
           (select EDU_MAP_GUID from OA_TEST_ANSWER e   ))";
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            string strSQL2 = @"select 999 as archive_type, COUNT (1)  as qyy 
            from OA_RISKEDUCATION a inner join OA_RISKEDURECEIVER b on a.EDUCATION_ID=b.EDUCATION_ID 
           where   b.READ_STATUS =0 and a.HOPEFINISHTIME<GETDATE()
           union all select 1000 as archive_type,COUNT(1) as qyy 
           from OA_EDUTEST c where  c.EDU_T_GUID  in  
           (select distinct EDU_T_GUID from OA_QUESTION_TEST_MAP d where d.EDU_MAP_GUID not in 
           (select EDU_MAP_GUID from OA_TEST_ANSWER e   )) and c.HOPEFINISHTIME<GETDATE()";
            DataTable dt2 = DbHelperSQL.GetTable(strSQL2);
            string result = dt.Rows[0].ItemArray[1].ToString() + ";" + dt.Rows[1].ItemArray[1].ToString() + ";" + dt2.Rows[0].ItemArray[1].ToString() + ";" + dt2.Rows[1].ItemArray[1].ToString();
            return result;
             
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVE_USER_DEPT get_ArchiveAll_UserList(Model.VIEW_ARCHIVE_USER_DEPT where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT * FROM VIEW_ARCHIVE_USER_DEPT WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_ARCHIVE_USER_DEPT>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 测试
        /// </summary>
        public IList<Model.OA_MAJOR> GetTest(string page, string rows, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  TOP (100) PERCENT task.* from (select oa.archive_id,oa.archive_title,oa.archive_type,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("case oa.pri_level when 0 then '普通' when 1 then '急件' when 2 then '特急' else '其它' end as pri_level,");
            strSql.Append("convert(varchar(10),oa.create_time,101) as create_time,");
            strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            strSql.Append("(select step_name from workflow_step where step_id=oa.current_step_id) as current_step_id ");
            strSql.Append("from oa_archive oa,oa_archive_task oat where oa.archive_id=oat.archive_id ");
            strSql.Append(") task order by oat.start_time desc ");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(page);//当前页索引
            pd.PageSize = int.Parse(rows);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString());
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

        /// <summary>
        /// 查询三重一大
        /// </summary>
        /// <returns>返回三重一大</returns>
        public IList<Model.OA_MAJOR> GetMajor()
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select oa_archive.* from(select archive_id,archive_title,to_char(create_time,'yyyy-mm-dd') as create_time,archive_type,");
            //strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name ");
            //strSql.Append("from oa_archive oa where is_show_in_szyd='1' order by create_time desc) oa_archive where rownum < 6 ");
            strSql.Append("select top 5 oa_archive.* from(select archive_id,archive_title,");
            strSql.Append("convert(varchar(10),create_time,101) as create_time,archive_type,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name ");
            strSql.Append("from oa_archive oa where is_show_in_szyd='1') oa_archive ");
            strSql.Append("union select archive_id,archive_title,convert(varchar(10),create_time,101) as create_time,71,ARCHIVE_NO as archive_type  ");
            strSql.Append(" from oa_archive where ARCHIVE_TYPE=71 order by create_time desc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_MAJOR>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询所有三重一大
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回所有三重一大</returns>
        public IList<Model.OA_MAJOR> GetMajor(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT rank() over(order by oa.create_time desc) as rowno,");
            strSql.Append("oa.archive_id,oa.archive_title,oa.archive_type,");
            strSql.Append("(select type_name from oa_archive_type where archive_type=oa.archive_type) as type_name,");
            strSql.Append("case oa.pri_level when 0 then '普通'when 1 then '急件' when 2 then '特急' else '其它' end as pri_level,");
            strSql.Append("convert(varchar(10), create_time,101) as create_time,");
            strSql.Append("(select count(1) from oa_attachment_file where ref_id=oa.archive_id and ref_type='oa_archive') as attachment_count,");
            strSql.Append("(select full_name from user_info where user_id=oa.creator) as creator,");
            strSql.Append("(select step_name from workflow_step where step_id=oa.current_step_id) as current_step_id ");
            strSql.Append("from oa_archive oa where is_show_in_szyd='1' ");
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