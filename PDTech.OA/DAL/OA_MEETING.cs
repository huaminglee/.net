/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING.cs
*
* 功 能： N/A
* 类 名： OA_MEETING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:23   N/A    初版
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
	/// 数据访问类:OA_MEETING
	/// </summary>
	public partial class OA_MEETING
	{
		public OA_MEETING()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MEETING_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_MEETING");
			strSql.Append(" where MEETING_ID=@MEETING_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = MEETING_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在记录
        /// </summary>
        public bool Exists(decimal roomId, string location, DateTime startTime, DateTime endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OA_MEETING where 1=1 ");
            if (roomId > 0)
            {
                strSql.Append(" and MEETING_ROOM_ID = " + roomId.ToString() );
            }
            else
            {
                strSql.Append(" and location = " + location);
            }
            strSql.Append(" and ((START_TIME <= convert(varchar(20),'" + startTime + "',120) and END_TIME >= convert(varchar(20),'" + startTime + "',120))");
            strSql.Append(" or (START_TIME <= convert(varchar(20),'" + endTime + "',120) and END_TIME >= convert(varchar(20),'" + endTime + "',120)))");
            return DbHelperSQL.Exists(strSql.ToString());
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_MEETING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_MEETING(");
			strSql.Append("MEETING_ID,TITLE,CONTENT,SENDER,CREATE_TIME,STATE,MEETING_ROOM_ID,LOCATION,START_TIME,END_TIME,DEPT,HOST_USER,OTHER_PERS,REMARK)");
			strSql.Append(" values (");
			strSql.Append("@MEETING_ID,@TITLE,@CONTENT,@SENDER,@CREATE_TIME,@STATE,@MEETING_ROOM_ID,@LOCATION,@START_TIME,@END_TIME,@DEPT,@HOST_USER,@OTHER_PERS,@REMARK)");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@CONTENT", SqlDbType.NVarChar),
					new SqlParameter("@SENDER", SqlDbType.Decimal,4),
					new SqlParameter("@CREATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@STATE", SqlDbType.Decimal,2),
					new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,4),
					new SqlParameter("@LOCATION", SqlDbType.NVarChar),
					new SqlParameter("@START_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@DEPT", SqlDbType.NVarChar),
					new SqlParameter("@HOST_USER", SqlDbType.Decimal,4),
					new SqlParameter("@OTHER_PERS", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar)};
			parameters[0].Value = model.MEETING_ID;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.CONTENT;
			parameters[3].Value = model.SENDER;
			parameters[4].Value = model.CREATE_TIME;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.MEETING_ROOM_ID;
			parameters[7].Value = model.LOCATION;
			parameters[8].Value = model.START_TIME;
			parameters[9].Value = model.END_TIME;
			parameters[10].Value = model.DEPT;
			parameters[11].Value = model.HOST_USER;
			parameters[12].Value = model.OTHER_PERS;
			parameters[13].Value = model.REMARK;

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
		public bool Update(PDTech.OA.Model.OA_MEETING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_MEETING set ");
			strSql.Append("TITLE=@TITLE,");
			strSql.Append("CONTENT=@CONTENT,");
			strSql.Append("SENDER=@SENDER,");
			strSql.Append("CREATE_TIME=@CREATE_TIME,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("MEETING_ROOM_ID=@MEETING_ROOM_ID,");
			strSql.Append("LOCATION=@LOCATION,");
			strSql.Append("START_TIME=@START_TIME,");
			strSql.Append("END_TIME=@END_TIME,");
			strSql.Append("DEPT=@DEPT,");
			strSql.Append("HOST_USER=@HOST_USER,");
			strSql.Append("OTHER_PERS=@OTHER_PERS,");
			strSql.Append("REMARK=@REMARK");
			strSql.Append(" where MEETING_ID=@MEETING_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@CONTENT", SqlDbType.NVarChar),
					new SqlParameter("@SENDER", SqlDbType.Decimal,4),
					new SqlParameter("@CREATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@STATE", SqlDbType.Decimal,2),
					new SqlParameter("@MEETING_ROOM_ID", SqlDbType.Decimal,4),
					new SqlParameter("@LOCATION", SqlDbType.NVarChar),
					new SqlParameter("@START_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_TIME", SqlDbType.DateTime),
					new SqlParameter("@DEPT", SqlDbType.NVarChar),
					new SqlParameter("@HOST_USER", SqlDbType.Decimal,4),
					new SqlParameter("@OTHER_PERS", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,4)};
			parameters[0].Value = model.TITLE;
			parameters[1].Value = model.CONTENT;
			parameters[2].Value = model.SENDER;
			parameters[3].Value = model.CREATE_TIME;
			parameters[4].Value = model.STATE;
			parameters[5].Value = model.MEETING_ROOM_ID;
			parameters[6].Value = model.LOCATION;
			parameters[7].Value = model.START_TIME;
			parameters[8].Value = model.END_TIME;
			parameters[9].Value = model.DEPT;
			parameters[10].Value = model.HOST_USER;
			parameters[11].Value = model.OTHER_PERS;
			parameters[12].Value = model.REMARK;
			parameters[13].Value = model.MEETING_ID;

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
		public bool Delete(decimal MEETING_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_MEETING ");
            strSql.Append(" where MEETING_ID=@MEETING_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = MEETING_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string MEETING_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_MEETING ");
			strSql.Append(" where MEETING_ID in ("+MEETING_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public PDTech.OA.Model.OA_MEETING GetModel(decimal MEETING_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MEETING_ID,TITLE,CONTENT,SENDER,CREATE_TIME,STATE,MEETING_ROOM_ID,LOCATION,START_TIME,END_TIME,DEPT,HOST_USER,OTHER_PERS,REMARK from OA_MEETING ");
			strSql.Append(" where MEETING_ID=@MEETING_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MEETING_ID", SqlDbType.Decimal,22)			};
			parameters[0].Value = MEETING_ID;

			PDTech.OA.Model.OA_MEETING model=new PDTech.OA.Model.OA_MEETING();
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
		public PDTech.OA.Model.OA_MEETING DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_MEETING model=new PDTech.OA.Model.OA_MEETING();
			if (row != null)
			{
				if(row["MEETING_ID"]!=null && row["MEETING_ID"].ToString()!="")
				{
					model.MEETING_ID=decimal.Parse(row["MEETING_ID"].ToString());
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["CONTENT"]!=null)
				{
					model.CONTENT=row["CONTENT"].ToString();
				}
				if(row["SENDER"]!=null && row["SENDER"].ToString()!="")
				{
					model.SENDER=decimal.Parse(row["SENDER"].ToString());
				}
				if(row["CREATE_TIME"]!=null && row["CREATE_TIME"].ToString()!="")
				{
					model.CREATE_TIME=DateTime.Parse(row["CREATE_TIME"].ToString());
				}
				if(row["STATE"]!=null && row["STATE"].ToString()!="")
				{
					model.STATE=decimal.Parse(row["STATE"].ToString());
				}
				if(row["MEETING_ROOM_ID"]!=null && row["MEETING_ROOM_ID"].ToString()!="")
				{
					model.MEETING_ROOM_ID=decimal.Parse(row["MEETING_ROOM_ID"].ToString());
				}
				if(row["LOCATION"]!=null)
				{
					model.LOCATION=row["LOCATION"].ToString();
				}
				if(row["START_TIME"]!=null && row["START_TIME"].ToString()!="")
				{
					model.START_TIME=DateTime.Parse(row["START_TIME"].ToString());
				}
				if(row["END_TIME"]!=null && row["END_TIME"].ToString()!="")
				{
					model.END_TIME=DateTime.Parse(row["END_TIME"].ToString());
				}
				if(row["DEPT"]!=null)
				{
					model.DEPT=row["DEPT"].ToString();
				}
				if(row["HOST_USER"]!=null && row["HOST_USER"].ToString()!="")
				{
					model.HOST_USER=decimal.Parse(row["HOST_USER"].ToString());
				}
				if(row["OTHER_PERS"]!=null)
				{
					model.OTHER_PERS=row["OTHER_PERS"].ToString();
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
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
			strSql.Append("select MEETING_ID,TITLE,CONTENT,SENDER,CREATE_TIME,STATE,MEETING_ROOM_ID,LOCATION,START_TIME,END_TIME,DEPT,HOST_USER,OTHER_PERS,REMARK ");
			strSql.Append(" FROM OA_MEETING ");
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
			strSql.Append("select count(1) FROM OA_MEETING ");
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

        public IList<Model.OA_MEETING> Get_Paging_MeetingList(decimal creatorId, string title, int currentpage, int pagesize, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_MEETING WHERE (SENDER = {0} or HOST_USER = {1} or MEETING_ID IN (select MEETING_ID from OA_MEETING_RECEIVER where RECEIVER_ID = {2})) and TITLE like '%{3}%' order by CREATE_TIME desc ", creatorId, creatorId, creatorId, title);
            }
            else
            {
                strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_MEETING WHERE (SENDER = {0} or HOST_USER = {1} or MEETING_ID IN (select MEETING_ID from OA_MEETING_RECEIVER where RECEIVER_ID = {2})) order by CREATE_TIME desc ", creatorId, creatorId, creatorId);
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "CREATE_TIME", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_MEETING>(dt);
        }

        public IList<Model.OA_MEETING> Get_Paging_MeetingList(string title, int currentpage, int pagesize, out int totalrecord)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(title))
            {
                strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_MEETING WHERE TITLE like '%{0}%' order by CREATE_TIME desc ", title);
            }
            else
            {
                strSQL = string.Format("SELECT  TOP (100) PERCENT * from OA_MEETING order by CREATE_TIME desc ");
            }
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "CREATE_TIME", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_MEETING>(dt);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_MEETING model, string fileIds, string receiveUserIds, int isSend, string clientIp, string clientHost)
        {
            try
            {
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", OracleType.Int32);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("P_MEETING_TITLE", SqlDbType.NVarChar),
					new SqlParameter("P_MEETING_CONTENT", SqlDbType.Text),
					new SqlParameter("P_MEETING_ROOM_ID", SqlDbType.Decimal,4),
					new SqlParameter("P_LOCATION", SqlDbType.NVarChar),
					new SqlParameter("P_START_TIME", SqlDbType.DateTime),
                    new SqlParameter("P_END_TIME", SqlDbType.DateTime),
                    new SqlParameter("P_DEPT", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_USER", SqlDbType.Decimal,4),
                    new SqlParameter("P_OTHER_PERS", SqlDbType.NVarChar),
                    new SqlParameter("P_REMARK", SqlDbType.NVarChar),
                    new SqlParameter("P_OA_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
                    new SqlParameter("P_RECEIVE_USER_LIST", SqlDbType.NVarChar),
                    new SqlParameter("P_IS_SEND_SMS_NOW", SqlDbType.Decimal,2),
                    new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                    RESULTCODE};
                parameters[0].Value = model.SENDER;
                parameters[1].Value = model.TITLE;
                parameters[2].Value = model.CONTENT;
                parameters[3].Value = model.MEETING_ROOM_ID;
                parameters[4].Value = model.LOCATION;
                parameters[5].Value = model.START_TIME;
                parameters[6].Value = model.END_TIME;
                parameters[7].Value = model.DEPT;
                parameters[8].Value = model.HOST_USER;
                parameters[9].Value = model.OTHER_PERS;
                parameters[10].Value = model.REMARK;
                parameters[11].Value = fileIds;
                parameters[12].Value = receiveUserIds;
                parameters[13].Value = isSend;
                parameters[14].Value = clientIp;
                parameters[15].Value = clientHost;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_MEETING", parameters);
                string result = RESULTCODE.Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

