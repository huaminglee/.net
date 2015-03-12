/**  版本信息模板在安装目录下，可自行修改。
* OPERATION_LOG.cs
*
* 功 能： N/A
* 类 名： OPERATION_LOG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-27 14:30:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
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
    /// 数据访问类:OPERATION_LOG
    /// </summary>
    public partial class OPERATION_LOG
    {
        public OPERATION_LOG()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal LOG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OPERATION_LOG");
            strSql.Append(" where LOG_ID=@LOG_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = LOG_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OPERATION_LOG model)
        {
            try
            {
                SqlParameter return_val = new SqlParameter("RESULTCODE", SqlDbType.Int);
                return_val.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("OPERATOR_USER", SqlDbType.Decimal,4),
					new SqlParameter("OPERATION_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("ENTITY_TYPE", SqlDbType.Decimal,20),
                    new SqlParameter("ENTITY_ID", SqlDbType.Decimal,20),
					new SqlParameter("HOST_IP", SqlDbType.VarChar,50),
					new SqlParameter("HOST_NAME", SqlDbType.VarChar,50),
					new SqlParameter("OPERATION_DESC", SqlDbType.VarChar,1000),
					new SqlParameter("OPERATION_DATA", SqlDbType.VarChar,500),
                    return_val
                                           };
                parameters[0].Value = model.OPERATOR_USER;
                parameters[1].Value = model.OPERATION_TYPE;
                parameters[2].Value = model.ENTITY_TYPE;
                parameters[3].Value = model.ENTITY_ID;
                parameters[4].Value = model.HOST_IP;
                parameters[5].Value = model.HOST_NAME;
                parameters[6].Value = model.OPERATION_DESC;
                parameters[7].Value = model.OPERATION_DATA;
               
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_UPDATELOG", parameters);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OPERATION_LOG GetLogInfo(decimal lId)
        {
            string strSQL = string.Format("SELECT * FROM OPERATION_LOG WHERE LOG_ID={0}", lId);
            DataTable dt = DbHelperSQL.Query(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OPERATION_LOG>(dt)[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取用户信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OPERATION_LOG> get_Paging_LogInfoList(Model.OPERATION_LOG where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM OPERATION_LOG WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "OPERATION_TIME", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OPERATION_LOG>(dt);
        }

        /// <summary>
        /// 获取用户信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OPERATION_LOG> get_Paging_LogInfoList(string strSQL, int currentpage, int pagesize, out int totalrecord)
        {
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "OPERATION_TIME", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OPERATION_LOG>(dt);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

