/**  版本信息模板在安装目录下，可自行修改。
* SYS_BASE_INFO.cs
*
* 功 能： N/A
* 类 名： SYS_BASE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:28   N/A    初版
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
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:SYS_BASE_INFO
    /// </summary>
    public partial class SYS_BASE_INFO
    {
        public SYS_BASE_INFO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BASE_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_BASE_INFO");
            strSql.Append(" where BASE_NAME=@BASE_NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@BASE_NAME", SqlDbType.NVarChar)			};
            parameters[0].Value = BASE_NAME;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BASE_NAME, decimal SYS_BASE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_BASE_INFO");
            strSql.Append(" where BASE_NAME=@BASE_NAME AND SYS_BASE_ID<>@SYS_BASE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BASE_NAME", SqlDbType.NVarChar),
                    new SqlParameter("@SYS_BASE_ID", SqlDbType.Decimal,4)	};
            parameters[0].Value = BASE_NAME;
            parameters[1].Value = SYS_BASE_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PDTech.OA.Model.SYS_BASE_INFO model)
        {
            if (Exists(model.BASE_NAME))
            {
                return -1;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_BASE_INFO(");
            strSql.Append("SYS_TYPE,BASE_JC,BASE_NAME)");
            strSql.Append(" values (");
            strSql.Append("@SYS_TYPE,@BASE_JC,@BASE_NAME)");
            SqlParameter[] parameters = {
					new SqlParameter("@SYS_TYPE", SqlDbType.VarChar,150),
					new SqlParameter("@BASE_JC", SqlDbType.VarChar,300),
					new SqlParameter("@BASE_NAME", SqlDbType.VarChar,300)};
            parameters[0].Value = model.SYS_TYPE;
            parameters[1].Value = model.BASE_JC;
            parameters[2].Value = model.BASE_NAME;
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
        /// 更新一条数据
        /// </summary>
        public int Update(PDTech.OA.Model.SYS_BASE_INFO model)
        {
            if (Exists(model.BASE_NAME, model.SYS_BASE_ID))
            {
                return -1;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_BASE_INFO set ");
            strSql.Append("SYS_TYPE=@SYS_TYPE,");
            strSql.Append("BASE_JC=@BASE_JC,");
            strSql.Append("BASE_NAME=@BASE_NAME");
            strSql.Append(" where SYS_BASE_ID=@SYS_BASE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SYS_TYPE", SqlDbType.VarChar,150),
					new SqlParameter("@BASE_JC", SqlDbType.VarChar,300),
					new SqlParameter("@BASE_NAME", SqlDbType.VarChar,300),
					new SqlParameter("@SYS_BASE_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.SYS_TYPE;
            parameters[1].Value = model.BASE_JC;
            parameters[2].Value = model.BASE_NAME;
            parameters[3].Value = model.SYS_BASE_ID;

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
        public bool Delete(decimal SYS_BASE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_BASE_INFO ");
            strSql.Append(" where SYS_BASE_ID=@SYS_BASE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SYS_BASE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = SYS_BASE_ID;

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
        /// 获取信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.SYS_BASE_INFO GetSysInfo(decimal sysId)
        {
            string strSQL = string.Format("SELECT SYS_BASE_ID,BASE_NAME,BASE_JC,SYS_TYPE FROM SYS_BASE_INFO WHERE SYS_BASE_ID={0}", sysId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.SYS_BASE_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取基础数据信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.SYS_BASE_INFO> get_sysBase_DeptList(Model.SYS_BASE_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT SYS_BASE_ID,BASE_NAME,BASE_JC,SYS_TYPE FROM SYS_BASE_INFO WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "SYS_BASE_ID","DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.SYS_BASE_INFO>(dt);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

