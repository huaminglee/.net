using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
using System.Data.SqlClient;//Please add references

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_ATTACHMENT_FILE
    /// </summary>
    public partial class OA_ATTACHMENT_FILE
    {
        public OA_ATTACHMENT_FILE()
        { }
        OPERATION_LOG log = new OPERATION_LOG();
        const string ATTACHMENT_CREATE = "ATTACHMENT_CREATE";
        const string ATTACHMENT_UP = "ATTACHMENT_UP";
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string FILE_HASH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_ATTACHMENT_FILE");
            strSql.Append(" where FILE_HASH=@FILE_HASH ");
            SqlParameter[] parameters = {
					new SqlParameter("@FILE_HASH",SqlDbType.NVarChar),	};
            parameters[0].Value = FILE_HASH;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_ATTACHMENT_FILE model, string HostName, string Ip, decimal operId, out string ar_ID)
        {
            try
            {

                string reruneVal = "";
                SqlParameter aid_out = new SqlParameter("@OUT_LOG_ID", SqlDbType.Int);
                aid_out.Direction = ParameterDirection.Output;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into OA_ATTACHMENT_FILE(");
                strSql.Append("FILE_NAME,FILE_TYPE,FILE_SIZE,FILE_PATH,FILE_HASH,REF_ID,REF_TYPE,CREATE_USER,DATA1,DATA2)");
                strSql.Append(" values (");
                strSql.Append("@FILE_NAME,@FILE_TYPE,@FILE_SIZE,@FILE_PATH,@FILE_HASH,@REF_ID,@REF_TYPE,@CREATE_USER,@DATA1,@DATA2) select @OUT_LOG_ID = @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@FILE_NAME", SqlDbType.NVarChar),
					new SqlParameter("@FILE_TYPE", SqlDbType.NVarChar),
					new SqlParameter("@FILE_SIZE", SqlDbType.Decimal,4),
					new SqlParameter("@FILE_PATH", SqlDbType.NVarChar),
					new SqlParameter("@FILE_HASH", SqlDbType.NVarChar),
                    new SqlParameter("@REF_ID", SqlDbType.Decimal,4),
                    new SqlParameter("@REF_TYPE", SqlDbType.NVarChar),
                    new SqlParameter("@CREATE_USER", SqlDbType.Decimal,4),
                    new SqlParameter("@DATA1", SqlDbType.NVarChar),
					new SqlParameter("@DATA2", SqlDbType.NVarChar),
                                               aid_out};
                parameters[0].Value = model.FILE_NAME;
                parameters[1].Value = model.FILE_TYPE;
                parameters[2].Value = model.FILE_SIZE;
                parameters[3].Value = model.FILE_PATH;
                parameters[4].Value = model.FILE_HASH;
                parameters[5].Value = model.REF_ID;
                parameters[6].Value = model.REF_TYPE;
                parameters[7].Value = model.CREATE_USER;
                parameters[8].Value = model.DATA1;
                parameters[9].Value = model.DATA2;
                DAL_Helper.get_db_para_value(parameters);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                reruneVal = aid_out.Value.ToString();
                if (rows > 0)
                {
                    PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                    Qwhere.OPERATOR_USER = operId;
                    Qwhere.OPERATION_TYPE = ATTACHMENT_CREATE;
                    Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.附件;
                    Qwhere.ENTITY_ID = decimal.Parse(reruneVal);
                    Qwhere.HOST_IP = Ip;
                    Qwhere.HOST_NAME = HostName;
                    Qwhere.OPERATION_DESC = "新增附件:FILE_NAME=" + model.FILE_NAME + ",FILE_PATH=" + model.FILE_PATH + "...";
                    Qwhere.OPERATION_DATA = "";
                    log.Add(Qwhere);
                    ar_ID = reruneVal;
                    return true;
                }
                else
                {
                    ar_ID = reruneVal;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ar_ID = "";
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ATTACHMENT_FILE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_ATTACHMENT_FILE ");
            strSql.Append(" where ATTACHMENT_FILE_ID=@ATTACHMENT_FILE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ATTACHMENT_FILE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ATTACHMENT_FILE_ID;

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
        /// 获取附件信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ATTACHMENT_FILE> get_InfoList(Model.OA_ATTACHMENT_FILE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            return get_InfoList(condition);
        }

        /// <summary>
        /// 获取附件信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ATTACHMENT_FILE> get_InfoList(string where)
        {
            string strSQL = string.Format(@"SELECT F.*,
(SELECT FULL_NAME FROM USER_INFO WHERE USER_ID=F.CREATE_USER) FULL_NAME
 FROM OA_ATTACHMENT_FILE F WHERE 1=1 {0} ", where);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ATTACHMENT_FILE>(dt);
        }


        /// <summary>
        /// 获取附件信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ATTACHMENT_FILE> get_InfoList(int limit,string where)
        {
            string strSQL = string.Format(@"SELECT TOP {0} F.*,
(SELECT FULL_NAME FROM USER_INFO WHERE USER_ID=F.CREATE_USER) FULL_NAME
 FROM OA_ATTACHMENT_FILE F WHERE 1=1 {1} ",limit, where);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.OA_ATTACHMENT_FILE>(dt);
        }
        /// <summary>
        /// 修改办理中新增的附件所属公文或者类型
        /// </summary>
        /// <param name="Ids">附件ID子串</param>
        /// <param name="pId">所属公文或公告ID</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public bool UpdatePID(string Ids, decimal pId, string type,string steptype)
        {
            try
            {
                string ModSQL = string.Format("UPDATE OA_ATTACHMENT_FILE SET REF_ID={0},REF_TYPE='{1}',DATA1='{2}' WHERE ATTACHMENT_FILE_ID IN({3})", pId, type, steptype, Ids);
                DbHelperSQL.ExecuteSql(ModSQL);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新OCR状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOCRInfo(Model.OA_ATTACHMENT_FILE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_ATTACHMENT_FILE set ");
            strSql.Append("OCR_STATUS=@OCR_STATUS,");
            strSql.Append("OCR_CONTENT=@OCR_CONTENT");
            strSql.Append(" WHERE FILE_HASH=@FILE_HASH AND FILE_PATH=@FILE_PATH AND OCR_STATUS <>1");
            SqlParameter[] parameters = {
					new SqlParameter("@OCR_STATUS", SqlDbType.Decimal,4),
					new SqlParameter("@OCR_CONTENT", SqlDbType.Text),
					new SqlParameter("@FILE_HASH", SqlDbType.NVarChar),
					new SqlParameter("@FILE_PATH", SqlDbType.NVarChar)};
            parameters[0].Value = model.OCR_STATUS;
            parameters[1].Value = model.OCR_CONTENT;
            parameters[2].Value = model.FILE_HASH;
            parameters[3].Value = model.FILE_PATH;

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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

