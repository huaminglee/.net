/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING_RECEIVER.cs
*
* 功 能： N/A
* 类 名： OA_MEETING_RECEIVER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:12   N/A    初版
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
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:OA_MEETING_RECEIVER
	/// </summary>
	public partial class OA_MEETING_RECEIVER
	{
		public OA_MEETING_RECEIVER()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_MEETING_RECEIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_MEETING_RECEIVER(");
			strSql.Append("MEETING_ID,RECEIVER_ID,READ_STATUS,READ_TIME)");
			strSql.Append(" values (");
			strSql.Append("@MEETING_ID,@RECEIVER_ID,@READ_STATUS,@READ_TIME)");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,2),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime)};
			parameters[0].Value = model.MEETING_ID;
			parameters[1].Value = model.RECEIVER_ID;
			parameters[2].Value = model.READ_STATUS;
			parameters[3].Value = model.READ_TIME;

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
		public bool Update(PDTech.OA.Model.OA_MEETING_RECEIVER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_MEETING_RECEIVER set ");
			strSql.Append("MEETING_ID=@MEETING_ID,");
			strSql.Append("RECEIVER_ID=@RECEIVER_ID,");
			strSql.Append("READ_STATUS=@READ_STATUS,");
			strSql.Append("READ_TIME=@READ_TIME");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,2),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime)};
			parameters[0].Value = model.MEETING_ID;
			parameters[1].Value = model.RECEIVER_ID;
			parameters[2].Value = model.READ_STATUS;
			parameters[3].Value = model.READ_TIME;

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

        public bool UpdateState(PDTech.OA.Model.OA_MEETING_RECEIVER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_MEETING_RECEIVER set ");
            strSql.Append("READ_STATUS=@READ_STATUS,");
            strSql.Append("READ_TIME=@READ_TIME");
            strSql.Append(" where ");
            strSql.Append("MEETING_ID=@MEETING_ID");
            strSql.Append(" and ");
            strSql.Append("RECEIVER_ID=@RECEIVER_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,4),
					new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@READ_STATUS", SqlDbType.Decimal,2),
					new SqlParameter("@READ_TIME", SqlDbType.DateTime)};
            parameters[0].Value = model.MEETING_ID;
            parameters[1].Value = model.RECEIVER_ID;
            parameters[2].Value = model.READ_STATUS;
            parameters[3].Value = model.READ_TIME;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_MEETING_RECEIVER ");
			strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_MEETING_RECEIVER GetModel(decimal mID,decimal receiverID)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MEETING_ID,RECEIVER_ID,READ_STATUS,READ_TIME from OA_MEETING_RECEIVER ");
            strSql.Append(" where MEETING_ID=@MEETING_ID ");
            strSql.Append(" and RECEIVER_ID=@RECEIVER_ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MEETING_ID", SqlDbType.Decimal),
                    new SqlParameter("@RECEIVER_ID", SqlDbType.Decimal)
			};
            parameters[0].Value = mID;
            parameters[1].Value = receiverID;
			PDTech.OA.Model.OA_MEETING_RECEIVER model=new PDTech.OA.Model.OA_MEETING_RECEIVER();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_MEETING_RECEIVER DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_MEETING_RECEIVER model=new PDTech.OA.Model.OA_MEETING_RECEIVER();
			if (row != null)
			{
				if(row["MEETING_ID"]!=null && row["MEETING_ID"].ToString()!="")
				{
					model.MEETING_ID=decimal.Parse(row["MEETING_ID"].ToString());
				}
				if(row["RECEIVER_ID"]!=null && row["RECEIVER_ID"].ToString()!="")
				{
					model.RECEIVER_ID=decimal.Parse(row["RECEIVER_ID"].ToString());
				}
				if(row["READ_STATUS"]!=null && row["READ_STATUS"].ToString()!="")
				{
					model.READ_STATUS=decimal.Parse(row["READ_STATUS"].ToString());
				}
				if(row["READ_TIME"]!=null && row["READ_TIME"].ToString()!="")
				{
					model.READ_TIME=DateTime.Parse(row["READ_TIME"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MEETING_ID,RECEIVER_ID,READ_STATUS,READ_TIME ");
			strSql.Append(" FROM OA_MEETING_RECEIVER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OA_MEETING_RECEIVER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 查询公告消息（未读和已读）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回公告消息</returns>
        public IList<Model.OA_ALL_BULLETIN> GetAllBulletin(string uId, string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP (100) PERCENT rank() over(order by omr.READ_STATUS asc,om.CREATE_TIME desc) as rowno,");
            strSql.Append("om.MEETING_ID as message_id,om.TITLE as message_title,");
            strSql.Append("decode(omr.READ_STATUS,0,'未读',1,'已读','其它') as read_status,");
            strSql.Append("to_char(om.CREATE_TIME,'yyyy-mm-dd') as message_send_time ");
            strSql.Append("from OA_MEETING om join OA_MEETING_RECEIVER omr on omr.MEETING_ID=om.MEETING_ID ");
            strSql.Append("where omr.RECEIVER_ID='" + uId + "' ");
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
                return DAL_Helper.CommonFillList<Model.OA_ALL_BULLETIN>(dt);
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

