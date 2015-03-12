/**  版本信息模板在安装目录下，可自行修改。
* MEETING_ROOM_INFO.cs
*
* 功 能： N/A
* 类 名： MEETING_ROOM_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:36   N/A    初版
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
using System.Data.OracleClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using System.Data.SqlClient;
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:MEETING_ROOM_INFO
	/// </summary>
	public partial class MEETING_ROOM_INFO
	{
		public MEETING_ROOM_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string MEETING_ROOM_NAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MEETING_ROOM_INFO");
            strSql.Append(" where MEETING_ROOM_NAME=@MEETING_ROOM_NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ROOM_NAME", SqlDbType.VarChar)			};
            parameters[0].Value = MEETING_ROOM_NAME;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MEETING_ROOM_NAME, decimal MEETING_ROOM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MEETING_ROOM_INFO");
            strSql.Append(" where MEETING_ROOM_NAME=@MEETING_ROOM_NAME AND MEETING_ROOM_ID<>@MEETING_ROOM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ROOM_NAME", SqlDbType.NVarChar),
                    new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,22)};
            parameters[0].Value = MEETING_ROOM_NAME;
            parameters[1].Value = MEETING_ROOM_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.MEETING_ROOM_INFO model)
		{
            if (Exists(model.MEETING_ROOM_NAME))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MEETING_ROOM_INFO(");
			strSql.Append("MEETING_ROOM_NAME,ROOM_DESC)");
			strSql.Append(" values (");
			strSql.Append("@MEETING_ROOM_NAME,@ROOM_DESC)");
            SqlParameter[] parameters = {
					//new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,4),
					new SqlParameter("@MEETING_ROOM_NAME", SqlDbType.VarChar,150),
					new SqlParameter("@ROOM_DESC", SqlDbType.VarChar,300)};
			//parameters[0].Value = model.MEETING_ROOM_ID;
			parameters[0].Value = model.MEETING_ROOM_NAME;
			parameters[1].Value = model.ROOM_DESC;
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
		public int Update(PDTech.OA.Model.MEETING_ROOM_INFO model)
		{
            if (Exists(model.MEETING_ROOM_NAME, model.MEETING_ROOM_ID))
            {
                return -1;
            }
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MEETING_ROOM_INFO set ");
			strSql.Append("MEETING_ROOM_NAME=@MEETING_ROOM_NAME,");
			strSql.Append("ROOM_DESC=@ROOM_DESC");
			strSql.Append(" where MEETING_ROOM_ID=@MEETING_ROOM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ROOM_NAME", SqlDbType.VarChar,150),
					new SqlParameter("@ROOM_DESC", SqlDbType.VarChar,300),
					new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.MEETING_ROOM_NAME;
			parameters[1].Value = model.ROOM_DESC;
			parameters[2].Value = model.MEETING_ROOM_ID;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal MEETING_ROOM_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MEETING_ROOM_INFO ");
			strSql.Append(" where MEETING_ROOM_ID=@MEETING_ROOM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = MEETING_ROOM_ID;

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
        public Model.MEETING_ROOM_INFO GetmRoomInfo(decimal mId)
        {
            string strSQL = string.Format("SELECT MEETING_ROOM_ID,MEETING_ROOM_NAME,ROOM_DESC FROM MEETING_ROOM_INFO WHERE MEETING_ROOM_ID={0}", mId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.MEETING_ROOM_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MEETING_ROOM_ID,MEETING_ROOM_NAME,ROOM_DESC ");
            strSql.Append(" FROM MEETING_ROOM_INFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.MEETING_ROOM_INFO DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.MEETING_ROOM_INFO model = new PDTech.OA.Model.MEETING_ROOM_INFO();
            if (row != null)
            {
                if (row["MEETING_ROOM_ID"] != null && row["MEETING_ROOM_ID"].ToString() != "")
                {
                    model.MEETING_ROOM_ID = decimal.Parse(row["MEETING_ROOM_ID"].ToString());
                }
                if (row["MEETING_ROOM_NAME"] != null)
                {
                    model.MEETING_ROOM_NAME = row["MEETING_ROOM_NAME"].ToString();
                }
                if (row["ROOM_DESC"] != null)
                {
                    model.ROOM_DESC = row["ROOM_DESC"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获取基础数据信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.MEETING_ROOM_INFO> get_Paging_mRoomList(Model.MEETING_ROOM_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT  TOP (100) PERCENT MEETING_ROOM_ID,MEETING_ROOM_NAME,ROOM_DESC FROM MEETING_ROOM_INFO WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "MEETING_ROOM_ID", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.MEETING_ROOM_INFO>(dt);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

