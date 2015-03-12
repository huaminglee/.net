/**  版本信息模板在安装目录下，可自行修改。
* TEMPLATE_INFO.cs
*
* 功 能： N/A
* 类 名： TEMPLATE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:18   N/A    初版
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
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:TEMPLATE_INFO
	/// </summary>
	public partial class TEMPLATE_INFO
	{
		public TEMPLATE_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string TEMPLATE_JC)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TEMPLATE_INFO");
            strSql.Append(" where TEMPLATE_JC=@TEMPLATE_JC ");
			SqlParameter[] parameters = {
					new SqlParameter("@TEMPLATE_JC", SqlDbType.NVarChar)			};
            parameters[0].Value = TEMPLATE_JC;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TEMPLATE_JC, decimal TEMPLATE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TEMPLATE_INFO");
            strSql.Append(" where TEMPLATE_JC=@TEMPLATE_JC AND TEMPLATE_ID<>@TEMPLATE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TEMPLATE_JC", SqlDbType.NVarChar),
                    new SqlParameter("@TEMPLATE_ID",SqlDbType.Decimal,4)                       };
            parameters[0].Value = TEMPLATE_JC;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.TEMPLATE_INFO model)
		{
            if (Exists(model.TEMPLATE_JC))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TEMPLATE_INFO(");
			strSql.Append("TEMPLATE_TYPE,TEMPLATE_JC,TEMPLATE_VALUE)");
			strSql.Append(" values (");
			strSql.Append("@TEMPLATE_TYPE,@TEMPLATE_JC,@TEMPLATE_VALUE)");
			SqlParameter[] parameters = {
					new SqlParameter("@TEMPLATE_TYPE", SqlDbType.NVarChar,150),
					new SqlParameter("@TEMPLATE_JC", SqlDbType.NVarChar,60),
					new SqlParameter("@TEMPLATE_VALUE", SqlDbType.NVarChar,3000)};
			parameters[0].Value = model.TEMPLATE_TYPE;
			parameters[1].Value = model.TEMPLATE_JC;
			parameters[2].Value = model.TEMPLATE_VALUE;
            DAL_Helper.get_db_para_value(parameters);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public int Update(PDTech.OA.Model.TEMPLATE_INFO model)
		{
            if (Exists(model.TEMPLATE_JC,(decimal)model.TEMPLATE_ID))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TEMPLATE_INFO set ");
			strSql.Append("TEMPLATE_JC=@TEMPLATE_JC,");
			strSql.Append("TEMPLATE_VALUE=@TEMPLATE_VALUE");
			strSql.Append(" where TEMPLATE_ID=@TEMPLATE_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TEMPLATE_JC", SqlDbType.NVarChar,60),
					new SqlParameter("@TEMPLATE_VALUE", SqlDbType.NVarChar,3000),
					new SqlParameter("@TEMPLATE_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.TEMPLATE_JC;
			parameters[1].Value = model.TEMPLATE_VALUE;
			parameters[2].Value = model.TEMPLATE_ID;
            DAL_Helper.get_db_para_value(parameters);
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal TEMPLATE_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TEMPLATE_INFO ");
			strSql.Append(" where TEMPLATE_ID=@TEMPLATE_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TEMPLATE_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = TEMPLATE_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public Model.TEMPLATE_INFO GetmTempInfo(decimal tId)
        {
            string strSQL = string.Format(@"SELECT T.*,
(SELECT FULL_NAME FROM USER_INFO WHERE USER_ID=T.TEMPLATE_OWNER) FULL_NAME
 FROM TEMPLATE_INFO T WHERE TEMPLATE_ID={0}", tId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.TEMPLATE_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取模板信息-分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.TEMPLATE_INFO> get_Paging_tempList(Model.TEMPLATE_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT TOP (100) PERCENT T.*,
(SELECT FULL_NAME FROM USER_INFO WHERE USER_ID=T.TEMPLATE_OWNER) FULL_NAME
 FROM TEMPLATE_INFO T WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "TEMPLATE_ID","DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.TEMPLATE_INFO>(dt);
        }

        /// <summary>
        /// 获取模板信息-未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.TEMPLATE_INFO> get_Paging_tempList(Model.TEMPLATE_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT T.*,
(SELECT FULL_NAME FROM USER_INFO WHERE USER_ID=T.TEMPLATE_OWNER) FULL_NAME
 FROM TEMPLATE_INFO T WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.TEMPLATE_INFO>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

