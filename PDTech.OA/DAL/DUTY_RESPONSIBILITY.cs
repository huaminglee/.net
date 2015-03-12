using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:DUTY_RESPONSIBILITY
    /// </summary>
    public partial class DUTY_RESPONSIBILITY
    {
        public DUTY_RESPONSIBILITY()
        { }
        #region  ********操作方法********

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal DUTY_RESPONSIBILITY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DUTY_RESPONSIBILITY");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = DUTY_RESPONSIBILITY_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.DUTY_RESPONSIBILITY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DUTY_RESPONSIBILITY(");
            strSql.Append("DUTY_NAME,RESPONSIBILITY,DEPARTMENT_ID) ");
            strSql.Append("values (");
            strSql.Append("@DUTY_NAME,@RESPONSIBILITY,@DEPARTMENT_ID) ");
            strSql.Append("select @OUT_DUTY_ID = SCOPE_IDENTITY() ");
            SqlParameter did_out = new SqlParameter("@OUT_DUTY_ID", SqlDbType.Int);
            did_out.Direction = ParameterDirection.Output;
            SqlParameter[] parameters = {
					//new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,4),
					new SqlParameter("@DUTY_NAME", SqlDbType.VarChar,150),
					new SqlParameter("@RESPONSIBILITY", SqlDbType.VarChar,2000),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
                                        did_out};
            //parameters[0].Value = model.DUTY_RESPONSIBILITY_ID;
            parameters[0].Value = model.DUTY_NAME;
            parameters[1].Value = model.RESPONSIBILITY;
            parameters[2].Value = model.DEPARTMENT_ID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            model.DUTY_RESPONSIBILITY_ID = Decimal.Parse(did_out.Value.ToString());
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
        public bool Update(PDTech.OA.Model.DUTY_RESPONSIBILITY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DUTY_RESPONSIBILITY set ");
            strSql.Append("DUTY_NAME=@DUTY_NAME,");
            strSql.Append("RESPONSIBILITY=@RESPONSIBILITY,");
            strSql.Append("DEPARTMENT_ID=@DEPARTMENT_ID");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_NAME", SqlDbType.VarChar,150),
					new SqlParameter("@RESPONSIBILITY", SqlDbType.VarChar,2000),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.DUTY_NAME;
            parameters[1].Value = model.RESPONSIBILITY;
            parameters[2].Value = model.DEPARTMENT_ID;
            parameters[3].Value = model.DUTY_RESPONSIBILITY_ID;

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
        public bool Delete(decimal DUTY_RESPONSIBILITY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DUTY_RESPONSIBILITY ");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,22)			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string DUTY_RESPONSIBILITY_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DUTY_RESPONSIBILITY ");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID in (" + DUTY_RESPONSIBILITY_IDlist + ")  ");
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
        public PDTech.OA.Model.DUTY_RESPONSIBILITY GetModel(decimal DUTY_RESPONSIBILITY_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DUTY_RESPONSIBILITY_ID,DUTY_NAME,RESPONSIBILITY,DEPARTMENT_ID from DUTY_RESPONSIBILITY ");
            strSql.Append(" where DUTY_RESPONSIBILITY_ID=@DUTY_RESPONSIBILITY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DUTY_RESPONSIBILITY_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = DUTY_RESPONSIBILITY_ID;

            PDTech.OA.Model.DUTY_RESPONSIBILITY model = new PDTech.OA.Model.DUTY_RESPONSIBILITY();
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
        public PDTech.OA.Model.DUTY_RESPONSIBILITY DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.DUTY_RESPONSIBILITY model = new PDTech.OA.Model.DUTY_RESPONSIBILITY();
            if (row != null)
            {
                if (row["DUTY_RESPONSIBILITY_ID"] != null && row["DUTY_RESPONSIBILITY_ID"].ToString() != "")
                {
                    model.DUTY_RESPONSIBILITY_ID = decimal.Parse(row["DUTY_RESPONSIBILITY_ID"].ToString());
                }
                if (row["DUTY_NAME"] != null)
                {
                    model.DUTY_NAME = row["DUTY_NAME"].ToString();
                }
                if (row["RESPONSIBILITY"] != null)
                {
                    model.RESPONSIBILITY = row["RESPONSIBILITY"].ToString();
                }
                if (row["DEPARTMENT_ID"] != null && row["DEPARTMENT_ID"].ToString() != "")
                {
                    model.DEPARTMENT_ID = decimal.Parse(row["DEPARTMENT_ID"].ToString());
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
            strSql.Append("select DUTY_RESPONSIBILITY_ID,DUTY_NAME,RESPONSIBILITY,DEPARTMENT_ID ");
            strSql.Append(" FROM DUTY_RESPONSIBILITY ");
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
            strSql.Append("select count(1) FROM DUTY_RESPONSIBILITY ");
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
        #region  ********业务方法********
        /// <summary>
        /// 查询岗位职责（当前用户）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回岗位职责</returns>
        public string GetResponsibility(string uId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select dr.responsibility ");
            strSql.Append("from duty_responsibility dr,user_duty_responsibility_map udr,user_info u ");
            strSql.Append("where dr.duty_responsibility_id=udr.duty_responsibility_id and udr.user_id=u.user_id and u.user_id='" + uId + "'");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["responsibility"].ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询岗位职责（所有）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回所有岗位职责</returns>
        public IList<Model.RESPONSIBILITY> GetAllResponsibility(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select rownum as rowno,department.* from (select dr.duty_responsibility_id,d.department_name,dr.duty_name,dr.responsibility ");
            //strSql.Append("from duty_responsibility dr join department d on d.department_id=dr.department_id where 1=1 ");
            strSql.Append("select ROW_NUMBER() OVER(ORDER BY duty_responsibility_id DESC) as rowno, department.* from ");
            strSql.Append("(select dr.duty_responsibility_id,d.department_name,dr.duty_name,dr.responsibility ");
            strSql.Append("from duty_responsibility dr join department d on d.department_id=dr.department_id where 1=1 ");
            if (strWhere != "" && strWhere != null)
            {
                strSql.Append(strWhere);
            }
            //strSql.Append("order by d.sort_num asc) department");
            strSql.Append(") department ");
            /***组织分页***/
            PageDescribe pd = new PageDescribe();
            pd.CurrentPage = int.Parse(currentPage);//当前页索引
            pd.PageSize = int.Parse(pageSize);//当前页显示条数
            DataTable dt = pd.PageDescribes(strSql.ToString(), "rowno", "ASC");
            totalNum = pd.RecordCount;
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.RESPONSIBILITY>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询部门单位
        /// </summary>
        /// <returns>部门单位</returns>
        public DataTable GetDepartment()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from department order by sort_num asc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查询部门列表
        /// </summary>
        /// <returns>返回部门列表</returns>
        public IList<Model.DEPARTMENT_NAME> GetDepartmentName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select department_id,department_name from department order by sort_num asc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.DEPARTMENT_NAME>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询岗位人员（正常使用状态）
        /// </summary>
        /// <returns>岗位人员</returns>
        public DataTable GetPerson()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user_info where is_disable='0' order by sort_number asc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查询岗位人员（正常使用状态）
        /// </summary>
        /// <param name="strName">姓名</param>
        /// <returns>岗位人员</returns>
        public DataTable GetPerson(string strName)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * from user_info where is_disable='0' and upper(full_name) like '%' + upper('" + strName + "') + '%' order by sort_number asc");
            strSql.Append("select * from user_info where is_disable='0' and full_name like '%" + strName + "%' order by sort_number asc");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion  ExtensionMethod
    }
}