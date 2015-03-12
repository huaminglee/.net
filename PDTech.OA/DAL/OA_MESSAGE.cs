using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:OA_MESSAGE
    /// </summary>
    public partial class OA_MESSAGE
    {
        public OA_MESSAGE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal MESSAGE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_MESSAGE");

            strSql.Append(" where MESSAGE_ID=@MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MESSAGE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = MESSAGE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_MESSAGE model, string fileIds, string setreceiverIds, int issendSms, string clientIp, string clientHost)
        {
            try
            {
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("P_MESSAGE_TITLE", SqlDbType.NVarChar),
					new SqlParameter("P_MESSAGE_CONTENT", SqlDbType.Text),
					new SqlParameter("P_OA_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
					new SqlParameter("P_RECEIVE_USER_LIST", SqlDbType.NVarChar),
					new SqlParameter("P_IS_SEND_SMS_NOW", SqlDbType.Decimal,2),
                    new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                    RESULTCODE};
                parameters[0].Value = model.MESSAGE_SENDER;
                parameters[1].Value = model.MESSAGE_TITLE;
                parameters[2].Value = model.MESSAGE_CONTENT;
                parameters[3].Value = fileIds;
                parameters[4].Value = setreceiverIds;
                parameters[5].Value = issendSms;
                parameters[6].Value = clientIp;
                parameters[7].Value = clientHost;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_MESSAGE", parameters);
                string result = RESULTCODE.Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal MESSAGE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OA_MESSAGE ");
            strSql.Append(" where MESSAGE_ID=@MESSAGE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MESSAGE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = MESSAGE_ID;

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
        /// 获取所有信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.OA_MESSAGE> get_messageList(Model.OA_MESSAGE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM OA_MESSAGE WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.OA_MESSAGE>(dt);
        }
        /// <summary>
        /// 获取单条公告信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_MESSAGE get_messageInfo(Model.OA_MESSAGE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM OA_MESSAGE WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_MESSAGE>(dt)[0];
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