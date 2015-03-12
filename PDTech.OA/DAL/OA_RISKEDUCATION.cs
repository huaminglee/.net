/**  版本信息模板在安装目录下，可自行修改。
* OA_RISKEDUCATION.cs
*
* 功 能： N/A
* 类 名： OA_RISKEDUCATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:19   N/A    初版
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
	/// 数据访问类:OA_RISKEDUCATION
	/// </summary>
	public partial class OA_RISKEDUCATION
	{
		public OA_RISKEDUCATION()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal? EDUCATION_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OA_RISKEDUCATION");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_RISKEDUCATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OA_RISKEDUCATION(");
            strSql.Append("EDUCATION_ID,TITLE,FILETYPE,REMARK,CREATOR,CREATETIME,COMPANY,HOPEFINISHTIME,FINISHTIME)");
			strSql.Append(" values (");
            strSql.Append("@EDUCATION_ID,@TITLE,@FILETYPE,@REMARK,@CREATOR,@CREATETIME,@COMPANY,@HOPEFINISHTIME,@FINISHTIME)");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4),
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@FILETYPE", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATETIME", SqlDbType.DateTime),
					new SqlParameter("@COMPANY", SqlDbType.NVarChar),
                    new SqlParameter("@HOPEFINISHTIME", SqlDbType.DateTime),
                    new SqlParameter("@FINISHTIME", SqlDbType.DateTime)};
            parameters[0].Value = model.EDUCATION_ID;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.FILETYPE;
			parameters[3].Value = model.REMARK;
			parameters[4].Value = model.CREATOR;
			parameters[5].Value = model.CREATETIME;
			parameters[6].Value = model.COMPANY;
            parameters[7].Value = model.HOPEFINISHTIME;
            parameters[8].Value = model.FINISHTIME;

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
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_RISKEDUCATION model, string fileIds, string receiveUserId, string hostIP, string hostName)
        {
            try
            {
                SqlParameter RESULTCODE = new SqlParameter("RESULTCODE", SqlDbType.Int);
                RESULTCODE.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("P_CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("P_EDUCATION_TITLE", SqlDbType.NVarChar),
					new SqlParameter("P_TYPE", SqlDbType.NVarChar),
					new SqlParameter("P_COMPANY", SqlDbType.NVarChar),
					new SqlParameter("P_REMARK", SqlDbType.NVarChar),
                    new SqlParameter("P_OA_ATTACHMENT_FILE_IDS", SqlDbType.NVarChar),
                    new SqlParameter("P_RECEIVE_USER_LIST", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_IP", SqlDbType.NVarChar),
                    new SqlParameter("P_HOST_NAME", SqlDbType.NVarChar),
                    new SqlParameter("P_HOPEFINISHTIME", SqlDbType.DateTime),
                    new SqlParameter("P_FINISHTIME", SqlDbType.DateTime),
                    RESULTCODE};
                parameters[0].Value = model.CREATOR;
                parameters[1].Value = model.TITLE;
                parameters[2].Value = model.FILETYPE;
                parameters[3].Value = model.COMPANY;
                parameters[4].Value = model.REMARK;
                parameters[5].Value = fileIds;
                parameters[6].Value = receiveUserId;
                parameters[7].Value = hostIP;
                parameters[8].Value = hostName;
                parameters[9].Value = model.HOPEFINISHTIME;
                parameters[10].Value = model.FINISHTIME;
                DAL_Helper.get_db_para_value(parameters);
                DbHelperSQL.RunProcedure_Add("PD_CREATE_EDUCATION", parameters);
                string result = RESULTCODE.Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_RISKEDUCATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OA_RISKEDUCATION set ");
			strSql.Append("TITLE=@TITLE,");
			strSql.Append("FILETYPE=@FILETYPE,");
			strSql.Append("REMARK=@REMARK,");
			strSql.Append("CREATOR=@CREATOR,");
			strSql.Append("CREATETIME=@CREATETIME,");
			strSql.Append("COMPANY=@COMPANY, ");
            strSql.Append("HOPEFINISHTIME=@HOPEFINISHTIME, ");
            strSql.Append("FINISHTIME=@FINISHTIME ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TITLE", SqlDbType.NVarChar),
					new SqlParameter("@FILETYPE", SqlDbType.NVarChar),
					new SqlParameter("@REMARK", SqlDbType.NVarChar),
					new SqlParameter("@CREATOR", SqlDbType.Decimal,4),
					new SqlParameter("@CREATETIME", SqlDbType.DateTime),
					new SqlParameter("@COMPANY", SqlDbType.NVarChar),
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4),
                    new SqlParameter("@HOPEFINISHTIME", SqlDbType.DateTime),
                    new SqlParameter("@FINISHTIME", SqlDbType.DateTime)};
			parameters[0].Value = model.TITLE;
			parameters[1].Value = model.FILETYPE;
			parameters[2].Value = model.REMARK;
			parameters[3].Value = model.CREATOR;
			parameters[4].Value = model.CREATETIME;
			parameters[5].Value = model.COMPANY;
            parameters[6].Value = model.EDUCATION_ID;
            parameters[7].Value = model.HOPEFINISHTIME;
            parameters[8].Value = model.FINISHTIME;

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
		/// 删除一条数据
		/// </summary>
        public bool Delete(decimal? EDUCATION_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_RISKEDUCATION ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

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
		/// 批量删除数据
		/// </summary>
        public bool DeleteList(string EDUCATION_IDlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OA_RISKEDUCATION ");
            strSql.Append(" where EDUCATION_ID in (" + EDUCATION_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public PDTech.OA.Model.OA_RISKEDUCATION GetModel(decimal? EDUCATION_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select EDUCATION_ID,TITLE,FILETYPE,REMARK,CREATOR,CREATETIME,COMPANY,HOPEFINISHTIME,FINISHTIME from OA_RISKEDUCATION ");
            strSql.Append(" where EDUCATION_ID=@EDUCATION_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EDUCATION_ID", SqlDbType.Decimal,4)			};
            parameters[0].Value = EDUCATION_ID;

			PDTech.OA.Model.OA_RISKEDUCATION model=new PDTech.OA.Model.OA_RISKEDUCATION();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public PDTech.OA.Model.OA_RISKEDUCATION DataRowToModel(DataRow row)
		{
			PDTech.OA.Model.OA_RISKEDUCATION model=new PDTech.OA.Model.OA_RISKEDUCATION();
			if (row != null)
			{
                if (row["EDUCATION_ID"] != null)
				{
                    model.EDUCATION_ID = decimal.Parse(row["EDUCATION_ID"].ToString());
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["FILETYPE"]!=null)
				{
					model.FILETYPE=row["FILETYPE"].ToString();
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
				}
				if(row["CREATOR"]!=null && row["CREATOR"].ToString()!="")
				{
					model.CREATOR=decimal.Parse(row["CREATOR"].ToString());
				}
				if(row["CREATETIME"]!=null && row["CREATETIME"].ToString()!="")
				{
					model.CREATETIME=DateTime.Parse(row["CREATETIME"].ToString());
				}
				if(row["COMPANY"]!=null)
				{
					model.COMPANY=row["COMPANY"].ToString();
				}
                if (row["HOPEFINISHTIME"] != null)
                {
                    model.HOPEFINISHTIME = DateTime.Parse(row["HOPEFINISHTIME"].ToString());
                }
                if (row["FINISHTIME"] != null)
                {
                    model.FINISHTIME = DateTime.Parse(row["FINISHTIME"].ToString());
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
            strSql.Append("select EDUCATION_ID,TITLE,FILETYPE,REMARK,CREATOR,CREATETIME,COMPANY,HOPEFINISHTIME,FINISHTIME ");
			strSql.Append(" FROM OA_RISKEDUCATION ");
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
			strSql.Append("select count(1) FROM OA_RISKEDUCATION ");
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
        public IList<Model.OA_EXPIRE_EDUTASK> Get_exprePaging_List(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            string strSQL = string.Format(@"select TOP (100) PERCENT ROW_NUMBER() OVER (ORDER BY a.EDUCATION_ID desc) AS rowno, TITLE,FILETYPE,CREATOR,CREATETIME,COMPANY 
from OA_RISKEDUCATION a inner join OA_RISKEDURECEIVER b on a.EDUCATION_ID=b.EDUCATION_ID 
           where   b.READ_STATUS =0 and a.HOPEFINISHTIME<GETDATE() and ", strWhere);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = int.Parse(currentPage);
            pdes.PageSize = int.Parse(pageSize);
            DataTable dt = pdes.PageDescribes(strSQL, "rowno", "DESC");
            totalNum = pdes.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.OA_EXPIRE_EDUTASK>(dt);
            }
            else
            {
                return null;
            }
            

        }
        /// <summary>
		/// 分页获取数据列表
		/// </summary>
        public IList<Model.OA_RISKEDUCATION> Get_Paging_List(decimal userId, string title, string type, int PageSize, int PageIndex, out int totalrecord,bool iswhowexpire=false)
        {
            //string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Empty;
            if (iswhowexpire)
            {
                strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE EDUCATION_ID in (select EDUCATION_ID from OA_RISKEDURECEIVER where RECEIVER_ID ={0} and READ_STATUS=0 ) and HOPEFINISHTIME<GETDATE()", userId);
            }
            else
            {
                if ((int)userId > 0)
                {
                    if (!string.IsNullOrEmpty(title))
                    {
                        if (type == "全部")
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE EDUCATION_ID in (select EDUCATION_ID from OA_RISKEDURECEIVER where RECEIVER_ID = {0}) AND TITLE like '%{1}%' ", userId, title);
                        }
                        else
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE EDUCATION_ID in (select EDUCATION_ID from OA_RISKEDURECEIVER where RECEIVER_ID = {0}) AND TITLE like '%{1}%' AND FILETYPE = '{2}' ", userId, title, type);
                        }

                    }
                    else
                    {
                        if (type == "全部")
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE EDUCATION_ID in (select EDUCATION_ID from OA_RISKEDURECEIVER where RECEIVER_ID = {0})", userId);
                        }
                        else
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE EDUCATION_ID in (select EDUCATION_ID from OA_RISKEDURECEIVER where RECEIVER_ID = {0}) AND FILETYPE = '{1}'  ", userId, type);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(title))
                    {
                        if (type == "全部")
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE TITLE like '%{0}%' ", title);
                        }
                        else
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE TITLE like '%{0}%' AND FILETYPE = '{1}' ", title, type);
                        }
                    }
                    else
                    {
                        if (type == "全部")
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION order by EDUCATION_ID ");
                        }
                        else
                        {
                            strSQL = string.Format("SELECT TOP (100) PERCENT * from OA_RISKEDUCATION WHERE FILETYPE = '{0}' ", type);
                        }
                    }
                }
            }
            
            
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = PageIndex;
            pdes.PageSize = PageSize;
            DataTable dt = pdes.PageDescribes(strSQL, "EDUCATION_ID", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.OA_RISKEDUCATION>(dt);
        }


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

