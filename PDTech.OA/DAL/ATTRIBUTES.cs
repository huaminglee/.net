using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:ATTRIBUTES
    /// </summary>
    public partial class ATTRIBUTES
    {
        public ATTRIBUTES()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ATTRIBUTE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ATTRIBUTES");
            strSql.Append(" where ATTRIBUTE_ID=@ATTRIBUTE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ATTRIBUTE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ATTRIBUTE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.ATTRIBUTES model)
        {
            try
            {
                Hashtable SQLStringList = new Hashtable();

                StringBuilder delSql = new StringBuilder();
                delSql.Append("delete from ATTRIBUTES ");
                delSql.Append(" where LOG_ID=@LOG_ID AND [KEY]=@KEY ");
                SqlParameter[] dparameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,22),
                    new SqlParameter("@KEY", SqlDbType.NVarChar)};
                dparameters[0].Value = model.LOG_ID;
                dparameters[1].Value = model.KEY;
                SQLStringList.Add(delSql, dparameters);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into ATTRIBUTES(");
                strSql.Append("LOG_ID,[KEY],VALUE)");
                strSql.Append(" values (");
                strSql.Append("@LOG_ID,@KEY,@VALUE)");
                SqlParameter[] parameters = {
					//new SqlParameter("@ATTRIBUTE_ID", SqlDbType.Decimal,4),
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,4),
					new SqlParameter("@KEY", SqlDbType.VarChar,50),
					new SqlParameter("@VALUE", SqlDbType.VarChar,1000)};
                parameters[0].Value = model.LOG_ID;
                parameters[1].Value = model.KEY;
                parameters[2].Value = model.VALUE;
                DAL_Helper.get_db_para_value(parameters);
                SQLStringList.Add(strSql, parameters);
                DbHelperSQL.ExecuteSqlTran(SQLStringList);
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
        public bool Update(PDTech.OA.Model.ATTRIBUTES model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ATTRIBUTES set ");
            strSql.Append("LOG_ID=@LOG_ID,");
            strSql.Append("[KEY]=@KEY,");
            strSql.Append("VALUE=@VALUE");
            strSql.Append(" where ATTRIBUTE_ID=@ATTRIBUTE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,4),
					new SqlParameter("@KEY", SqlDbType.VarChar,50),
					new SqlParameter("@VALUE", SqlDbType.VarChar,1000),
					new SqlParameter("@ATTRIBUTE_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.LOG_ID;
            parameters[1].Value = model.KEY;
            parameters[2].Value = model.VALUE;
            parameters[3].Value = model.ATTRIBUTE_ID;

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
        public bool Delete(Model.ATTRIBUTES model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ATTRIBUTES ");
            strSql.Append(" where LOG_ID=@LOG_ID AND [KEY]=@KEY ");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Decimal,22),
                                           new SqlParameter("@KEY", SqlDbType.NVarChar)};
            parameters[0].Value = model.LOG_ID;
            parameters[1].Value = model.KEY;

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
        public bool DeleteList(string ATTRIBUTE_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ATTRIBUTES ");
            strSql.Append(" where ATTRIBUTE_ID in (" + ATTRIBUTE_IDlist + ")  ");
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
        public PDTech.OA.Model.ATTRIBUTES GetModel(decimal ATTRIBUTE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ATTRIBUTE_ID,LOG_ID,[KEY],VALUE from ATTRIBUTES ");
            strSql.Append(" where ATTRIBUTE_ID=@ATTRIBUTE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ATTRIBUTE_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = ATTRIBUTE_ID;

            PDTech.OA.Model.ATTRIBUTES model = new PDTech.OA.Model.ATTRIBUTES();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public PDTech.OA.Model.ATTRIBUTES DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.ATTRIBUTES model = new PDTech.OA.Model.ATTRIBUTES();
            if (row != null)
            {
                if (row["ATTRIBUTE_ID"] != null && row["ATTRIBUTE_ID"].ToString() != "")
                {
                    model.ATTRIBUTE_ID = decimal.Parse(row["ATTRIBUTE_ID"].ToString());
                }
                if (row["LOG_ID"] != null && row["LOG_ID"].ToString() != "")
                {
                    model.LOG_ID = decimal.Parse(row["LOG_ID"].ToString());
                }
                if (row["KEY"] != null)
                {
                    model.KEY = row["KEY"].ToString();
                }
                if (row["VALUE"] != null)
                {
                    model.VALUE = row["VALUE"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ATTRIBUTE_ID,LOG_ID,[KEY],VALUE ");
            strSql.Append(" FROM ATTRIBUTES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ATTRIBUTES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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


        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ATTRIBUTES> get_AttInfoList(Model.ATTRIBUTES where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM \"ATTRIBUTES\" WHERE 1=1 AND LOG_ID={0} ", where.LOG_ID);
            DataTable dt = DbHelperSQL.Query(strSQL).Tables[0];
            return DAL_Helper.CommonFillList<Model.ATTRIBUTES>(dt);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

