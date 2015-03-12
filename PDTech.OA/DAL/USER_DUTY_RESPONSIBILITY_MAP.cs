using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:USER_DUTY_RESPONSIBILITY_MAP
    /// </summary>
    public partial class USER_DUTY_RESPONSIBILITY_MAP
    {
        public USER_DUTY_RESPONSIBILITY_MAP()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USER_DUTY_RESPONSIBILITY_MAP(");
            strSql.Append("USER_ID,DUTY_RESPONSIBILITY_ID)");
            strSql.Append(" values (");
            strSql.Append("@USER_ID,@DUTY_RESPONSIBILITY_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.DUTY_RESPONSIBILITY_ID;

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
        public bool Update(PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USER_DUTY_RESPONSIBILITY_MAP set ");
            strSql.Append("USER_ID=@USER_ID,");
            strSql.Append("DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4),
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.USER_ID;
            parameters[1].Value = model.DUTY_RESPONSIBILITY_ID;

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
        /// <param name="DUTY_RESPONSIBILITY_ID">职责ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(decimal DUTY_RESPONSIBILITY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from USER_DUTY_RESPONSIBILITY_MAP ");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,22)};
            parameters[0].Value = DUTY_RESPONSIBILITY_ID;

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
        public PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USER_ID,DUTY_RESPONSIBILITY_ID from USER_DUTY_RESPONSIBILITY_MAP ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model = new PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP();
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
        public PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model = new PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP();
            if (row != null)
            {
                if (row["USER_ID"] != null && row["USER_ID"].ToString() != "")
                {
                    model.USER_ID = decimal.Parse(row["USER_ID"].ToString());
                }
                if (row["DUTY_RESPONSIBILITY_ID"] != null && row["DUTY_RESPONSIBILITY_ID"].ToString() != "")
                {
                    model.DUTY_RESPONSIBILITY_ID = decimal.Parse(row["DUTY_RESPONSIBILITY_ID"].ToString());
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
            strSql.Append("select USER_ID,DUTY_RESPONSIBILITY_ID ");
            strSql.Append(" FROM USER_DUTY_RESPONSIBILITY_MAP ");
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
            strSql.Append("select count(1) FROM USER_DUTY_RESPONSIBILITY_MAP ");
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


        #endregion  BasicMethod
    }
}