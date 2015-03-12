using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace PDTech.OA.DAL
{
    /// <summary>
    /// 数据访问类:USER_INFO
    /// </summary>
    public partial class USER_INFO
    {
        PDTech.OA.DAL.VIEW_USER_RIGHT vidal = new VIEW_USER_RIGHT();
        OPERATION_LOG log = new OPERATION_LOG();
        const string USER_CREATE = "USER_CREATE";
        const string USER_UP = "USER_UP";
        public USER_INFO()
        { }
        #region  BasicMethod
        public object get_db_para_value(object in_p)
        {
            if (in_p == null)
                return DBNull.Value;
            else
                return in_p;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal USER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from USER_INFO");
            strSql.Append(" where USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.BigInt)			};
            parameters[0].Value = USER_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LOGIN_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from USER_INFO");
            strSql.Append(" where LOGIN_NAME=@LOGIN_NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@LOGIN_NAME", SqlDbType.NVarChar,20)			};
            parameters[0].Value = LOGIN_NAME;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PDTech.OA.Model.USER_INFO model, string HostName, string Ip, decimal operId)
        {
            int Flag = 0;
            try
            {
                string reruneVal = "";
                if (Exists(model.LOGIN_NAME))
                {
                    return -2;
                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into USER_INFO(");
                strSql.Append("LOGIN_NAME,FULL_NAME,LOGIN_PWD,PHONE,MOBILE,DEPARTMENT_ID,ATTRIBUTE_LOG,SORT_NUMBER,IS_DISABLE,DUTY_INFO,PUBLIC_NAME,E_MAILE,REMARK)");
                strSql.Append(" values (");
                strSql.Append("@LOGIN_NAME,@FULL_NAME,@LOGIN_PWD,@PHONE,@MOBILE,@DEPARTMENT_ID,@ATTRIBUTE_LOG,@SORT_NUMBER,@IS_DISABLE,@DUTY_INFO,@PUBLIC_NAME,@E_MAILE,@REMARK) select @OUT_LOG_ID = SCOPE_IDENTITY() ");
                SqlParameter uid_out = new SqlParameter("@OUT_LOG_ID", SqlDbType.Int);
                uid_out.Direction = ParameterDirection.Output;
                SqlParameter[] parameters = {
					new SqlParameter("@LOGIN_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@FULL_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@LOGIN_PWD", SqlDbType.VarChar,32),
					new SqlParameter("@PHONE", SqlDbType.VarChar,30),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@ATTRIBUTE_LOG", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUMBER", SqlDbType.Decimal,4),
					new SqlParameter("@IS_DISABLE", SqlDbType.Char,1),
                    new SqlParameter("@DUTY_INFO", SqlDbType.NVarChar,50),
                    new SqlParameter("@PUBLIC_NAME", SqlDbType.NVarChar,20),
                    new SqlParameter("@E_MAILE", SqlDbType.NVarChar,100),
                    new SqlParameter("@REMARK", SqlDbType.NVarChar,2000),
                                               uid_out};
                parameters[0].Value = get_db_para_value(model.LOGIN_NAME);
                parameters[1].Value = get_db_para_value(model.FULL_NAME);
                parameters[2].Value = get_db_para_value(model.LOGIN_PWD);
                parameters[3].Value = get_db_para_value(model.PHONE);
                parameters[4].Value = get_db_para_value(model.MOBILE);
                parameters[5].Value = get_db_para_value(model.DEPARTMENT_ID);
                parameters[6].Value = get_db_para_value(model.ATTRIBUTE_LOG);
                parameters[7].Value = get_db_para_value(model.SORT_NUMBER);
                parameters[8].Value = get_db_para_value(model.IS_DISABLE);
                parameters[9].Value = get_db_para_value(model.DUTY_INFO);
                parameters[10].Value = get_db_para_value(model.PUBLIC_NAME);
                parameters[11].Value = get_db_para_value(model.E_MAILE);
                parameters[12].Value = get_db_para_value(model.REMARK);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                reruneVal = uid_out.Value.ToString();
                if (rows > 0)
                {
                    PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                    Qwhere.OPERATOR_USER = operId;
                    Qwhere.OPERATION_TYPE = USER_CREATE;
                    Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.用户;
                    Qwhere.ENTITY_ID = decimal.Parse(reruneVal);
                    Qwhere.HOST_IP = Ip;
                    Qwhere.HOST_NAME = HostName;
                    Qwhere.OPERATION_DESC = "新增用户信息:LOGIN_NAME=" + model.LOGIN_NAME + ",FULL_NAME=" + model.FULL_NAME + ",PHONE=" + model.PHONE + ",MOBILE=" + model.MOBILE + "...";
                    Qwhere.OPERATION_DATA = "";
                    log.Add(Qwhere);
                    Flag = 1;
                }
                else
                {
                    Flag = 0;
                }
            }
            catch (Exception ex)
            {
                Flag = -1;
            }
            return Flag;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(PDTech.OA.Model.USER_INFO model, string HostName, string Ip, decimal operId)
        {
            int IntFlag = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update USER_INFO set ");
                strSql.Append("FULL_NAME=@FULL_NAME,");
                strSql.Append("PHONE=@PHONE,");
                strSql.Append("MOBILE=@MOBILE,");
                strSql.Append("DEPARTMENT_ID=@DEPARTMENT_ID,");
                strSql.Append("ATTRIBUTE_LOG=@ATTRIBUTE_LOG,");
                strSql.Append("SORT_NUMBER=@SORT_NUMBER,");
                strSql.Append("IS_DISABLE=@IS_DISABLE,");
                strSql.Append("DUTY_INFO=@DUTY_INFO,");
                strSql.Append("PUBLIC_NAME=@PUBLIC_NAME,");
                strSql.Append("E_MAILE=@E_MAILE,");
                strSql.Append("REMARK=@REMARK");
                strSql.Append(" where USER_ID=@USER_ID ");
                SqlParameter[] parameters = {
					new SqlParameter("@FULL_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@PHONE", SqlDbType.VarChar,30),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal,4),
					new SqlParameter("@ATTRIBUTE_LOG", SqlDbType.Decimal,4),
					new SqlParameter("@SORT_NUMBER", SqlDbType.Decimal,4),
					new SqlParameter("@IS_DISABLE", SqlDbType.Char,1),
                    new SqlParameter("@DUTY_INFO", SqlDbType.NVarChar,50),
                    new SqlParameter("@PUBLIC_NAME", SqlDbType.NVarChar,20),
                    new SqlParameter("@E_MAILE", SqlDbType.NVarChar,100),
                    new SqlParameter("@REMARK", SqlDbType.NVarChar,2000),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4)};
                parameters[0].Value = model.FULL_NAME;
                parameters[1].Value = model.PHONE;
                parameters[2].Value = model.MOBILE;
                parameters[3].Value = model.DEPARTMENT_ID;
                parameters[4].Value = model.ATTRIBUTE_LOG;
                parameters[5].Value = model.SORT_NUMBER;
                parameters[6].Value = model.IS_DISABLE;
                parameters[7].Value = model.DUTY_INFO;
                parameters[8].Value = model.PUBLIC_NAME;
                parameters[9].Value = model.E_MAILE;
                parameters[10].Value = model.REMARK;
                parameters[11].Value = model.USER_ID;
                DAL_Helper.get_db_para_value(parameters);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    PDTech.OA.Model.OPERATION_LOG Qwhere = new Model.OPERATION_LOG();
                    Qwhere.OPERATOR_USER = operId;
                    Qwhere.OPERATION_TYPE = USER_UP;
                    Qwhere.ENTITY_TYPE = (decimal)ENTITY_TYPE.用户;
                    Qwhere.ENTITY_ID = model.USER_ID;
                    Qwhere.HOST_IP = Ip;
                    Qwhere.HOST_NAME = HostName;
                    Qwhere.OPERATION_DESC = "修改用户信息:LOGIN_NAME=" + model.LOGIN_NAME + ",FULL_NAME=" + model.FULL_NAME + ",PHONE=" + model.PHONE + ",MOBILE=" + model.MOBILE + "...";
                    Qwhere.OPERATION_DATA = "";
                    log.Add(Qwhere);
                    IntFlag = 1;
                }
                else
                {
                    IntFlag = 0;
                }
            }
            catch
            {
                IntFlag = -1;
            }
            return IntFlag;
        }

        /// <summary>
        /// 更新一条数据（用户基本信息）
        /// </summary>
        public bool Update(PDTech.OA.Model.USER_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USER_INFO set ");
            strSql.Append("PHONE=@PHONE,");
            strSql.Append("MOBILE=@MOBILE");
            strSql.Append(" where USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PHONE", SqlDbType.VarChar,30),
					new SqlParameter("@MOBILE", SqlDbType.VarChar,20),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,4)};
            parameters[0].Value = model.PHONE;
            parameters[1].Value = model.MOBILE;
            parameters[2].Value = model.USER_ID;
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
        /// 修改密码
        /// </summary>
        public bool UpdatePwd(PDTech.OA.Model.USER_INFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USER_INFO set ");
            strSql.Append("login_pwd=@login_pwd");
            strSql.Append(" where USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@login_pwd", SqlDbType.VarChar,32),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,22)};
            parameters[0].Value = model.LOGIN_PWD;
            parameters[1].Value = model.USER_ID;
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
        public bool Delete(decimal USER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from USER_INFO ");
            strSql.Append(" where USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = USER_ID;

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
        public bool DeleteList(string USER_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from USER_INFO ");
            strSql.Append(" where USER_ID in (" + USER_IDlist + ")  ");
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
        public PDTech.OA.Model.USER_INFO GetModel(decimal USER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USER_ID,LOGIN_NAME,FULL_NAME,LOGIN_PWD,PHONE,MOBILE,DEPARTMENT_ID,ATTRIBUTE_LOG,SORT_NUMBER,IS_DISABLE from USER_INFO ");
            strSql.Append(" where USER_ID=@USER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_ID", SqlDbType.Decimal,22)			};
            parameters[0].Value = USER_ID;

            PDTech.OA.Model.USER_INFO model = new PDTech.OA.Model.USER_INFO();
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

        public PDTech.OA.Model.USER_INFO GetModel(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USER_ID,LOGIN_NAME,FULL_NAME,LOGIN_PWD,PHONE,MOBILE,DEPARTMENT_ID,ATTRIBUTE_LOG,SORT_NUMBER,IS_DISABLE from USER_INFO ");
            strSql.Append(" where FULL_NAME=@FULL_NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@FULL_NAME", SqlDbType.VarChar,20)			};
            parameters[0].Value = userName;

            PDTech.OA.Model.USER_INFO model = new PDTech.OA.Model.USER_INFO();
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
        public PDTech.OA.Model.USER_INFO DataRowToModel(DataRow row)
        {
            PDTech.OA.Model.USER_INFO model = new PDTech.OA.Model.USER_INFO();
            if (row != null)
            {
                if (row["USER_ID"] != null && row["USER_ID"].ToString() != "")
                {
                    model.USER_ID = decimal.Parse(row["USER_ID"].ToString());
                }
                if (row["LOGIN_NAME"] != null)
                {
                    model.LOGIN_NAME = row["LOGIN_NAME"].ToString();
                }
                if (row["FULL_NAME"] != null)
                {
                    model.FULL_NAME = row["FULL_NAME"].ToString();
                }
                if (row["LOGIN_PWD"] != null)
                {
                    model.LOGIN_PWD = row["LOGIN_PWD"].ToString();
                }
                if (row["PHONE"] != null)
                {
                    model.PHONE = row["PHONE"].ToString();
                }
                if (row["MOBILE"] != null)
                {
                    model.MOBILE = row["MOBILE"].ToString();
                }
                if (row["DEPARTMENT_ID"] != null && row["DEPARTMENT_ID"].ToString() != "")
                {
                    model.DEPARTMENT_ID = decimal.Parse(row["DEPARTMENT_ID"].ToString());
                }
                if (row["ATTRIBUTE_LOG"] != null && row["ATTRIBUTE_LOG"].ToString() != "")
                {
                    model.ATTRIBUTE_LOG = decimal.Parse(row["ATTRIBUTE_LOG"].ToString());
                }
                if (row["SORT_NUMBER"] != null && row["SORT_NUMBER"].ToString() != "")
                {
                    model.SORT_NUMBER = decimal.Parse(row["SORT_NUMBER"].ToString());
                }
                if (row["IS_DISABLE"] != null)
                {
                    model.IS_DISABLE = row["IS_DISABLE"].ToString();
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
            strSql.Append("select USER_ID,LOGIN_NAME,FULL_NAME,LOGIN_PWD,PHONE,MOBILE,DEPARTMENT_ID,ATTRIBUTE_LOG,SORT_NUMBER,IS_DISABLE ");
            strSql.Append(" FROM USER_INFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取分管部门下属所有人员
        /// </summary>
        /// <param name="uid">当前用户id</param>
        /// <returns></returns>
        public IList<Model.USER_INFO> GetOwnerDeptUsersModelList(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USER_ID,LOGIN_NAME,FULL_NAME,LOGIN_PWD,PHONE,MOBILE,DEPARTMENT_ID,ATTRIBUTE_LOG,SORT_NUMBER,IS_DISABLE ");
            strSql.Append(" FROM USER_INFO WHERE DEPARTMENT_ID IN (SELECT DEPARTMENT_ID FROM USERS_DEPT_OWNER_MAP WHERE USER_ID = {0})");
            DataTable dt = DbHelperSQL.GetTable(string.Format(strSql.ToString(),uid));
            return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM USER_INFO ");
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
        public IList<Model.USER_INFO> get_UserInfoList(Model.USER_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT U.*,(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) DEPARTMENT_NAME FROM USER_INFO U WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
        }

        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_UserInfoList(decimal uId)
        {
            string strSQL = string.Format("SELECT U.*,(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) DEPARTMENT_NAME FROM USER_INFO U WHERE DEPARTMENT_ID={0} ORDER BY SORT_NUMBER ASC ", uId);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
        }

        /// <summary>
        /// 获取用户信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_UserTab(Model.USER_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT U.*,(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) DEPARTMENT_NAME FROM USER_INFO U WHERE 1=1 {0} ", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return dt;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回一条用户信息</returns>
        public Model.USER_INFO GetUserInfo(decimal uId)
        {
            string strSQL = string.Format("SELECT U.*,(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) DEPARTMENT_NAME FROM USER_INFO U WHERE USER_ID={0}", uId);
            DataTable dt = DbHelperSQL.Query(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.USER_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>某一部门的所有用户</returns>
        public IList<Model.USER_INFO> GetUserInfoBydeptId(string deptId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select full_name,phone,mobile,e_maile,");
            strSql.Append("(select department_name from department d where d.department_id=u.department_id) as department_name ");
            strSql.Append("from user_info u ");
            strSql.Append("where u.department_id='" + deptId + "'  AND IS_DISABLE='0' order by sort_number asc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取一条用户信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.USER_INFO GetUserInfo(string LOGIN_NAME, string LOGIN_PWD)
        {
            string strLogin = string.Format(@"SELECT USER_ID,LOGIN_NAME,FULL_NAME,DEPARTMENT_ID,PHONE,MOBILE,(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=USER_INFO.DEPARTMENT_ID) DEPARTMENT_NAME FROM USER_INFO
WHERE LOGIN_NAME='{0}' AND LOGIN_PWD='{1}' AND IS_DISABLE='0'", LOGIN_NAME, LOGIN_PWD);
            //DataTable dt = DbHelperSQL.GetTable(strLogin);
            DataTable dt = DbHelperSQL.Query(strLogin).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.USER_INFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_tUserList(Model.USER_INFO where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT * FROM USER_INFO WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(strSQL);
            return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
        }

        /// <summary>
        /// 获取用户信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_Paging_UserInfoList(Model.USER_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format(@"SELECT TOP (100) PERCENT U.*,
(SELECT DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) DEPARTMENT_NAME,
(SELECT SORT_NUM FROM DEPARTMENT WHERE DEPARTMENT_ID=U.DEPARTMENT_ID) SORT_NUM
FROM USER_INFO U WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL);
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.USER_INFO>(dt);
        }
        /// <summary>
        /// 用户是否启用
        /// </summary>
        /// <param name="deptId">用户ID</param>
        /// <param name="disType">修改值</param>
        /// <returns></returns>
        public int ModDisable(decimal userId, string disType)
        {
            int result = 0;
            string ModSQL = string.Format(@"UPDATE USER_INFO SET IS_DISABLE='{0}' WHERE USER_ID={1}", disType, userId);
            result = DbHelperSQL.ExecuteSql(ModSQL);
            return result;
        }
        /// <summary>
        /// 获取用户信息返回为datatable 
        /// </summary>
        /// <param name="uName">full_name</param>
        /// <param name="Right_Code">权限编码</param>
        /// <returns></returns>
        public DataTable GetUserList(string uName, string Right_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user_info where is_disable='0' and upper(full_name) like '%' + upper('" + uName + "') + '%' ");
            if (!string.IsNullOrEmpty(Right_Code))
            {
                strSql.Append(" AND USER_ID IN(SELECT USER_ID FROM VIEW_USER_RIGHT WHERE 1=1 AND RIGHT_CODE='" + Right_Code + "' )");
            }
            strSql.Append(" ORDER BY SORT_NUMBER ASC");
            return DbHelperSQL.GetTable(strSql.ToString());
        }
        public DataTable GetCurDeptUserList(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user_info where is_disable='0' and DEPARTMENT_ID=(select DEPARTMENT_ID from USER_INFO where USER_ID="+uid.ToString()+")");
             
            strSql.Append(" ORDER BY SORT_NUMBER ASC");
            return DbHelperSQL.GetTable(strSql.ToString());
        }


        /// <summary>
        /// 修改登录状态
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdateLogin_State(decimal userId, int state, string clientIp)
        {
            string ModSQL = "";
            switch (state)
            {
                case 1:
                    ModSQL = string.Format(@"UPDATE USER_INFO SET IS_ONLINE=1,LAST_DATE=GETDATE(),LAST_IP='{0}' WHERE 1=1 AND USER_ID={1}", clientIp, userId);
                    break;
                case 0:
                    ModSQL = string.Format(@"UPDATE USER_INFO SET IS_ONLINE=0 WHERE 1=1 AND USER_ID={0}", userId);
                    break;
            }
            int rows = DbHelperSQL.ExecuteSql(ModSQL);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int UserLogin(PDTech.OA.Model.USER_INFO where, out PDTech.OA.Model.USER_INFO Ac, out IList<PDTech.OA.Model.VIEW_USER_RIGHT> vList, string clientIp)
        {
            int intFlag = 0;
            Ac = null;
            vList = null;
            try
            {

                string ChkUser = string.Format(@"SELECT COUNT(1)
FROM USER_INFO WHERE 1=1 AND LOGIN_NAME=@LOGIN_NAME");
                SqlParameter[] parameters = { 
                                            new SqlParameter("@LOGIN_NAME",SqlDbType.VarChar,20)};
                //SqlParameter[] parameters = {
                //    new SqlParameter("@LOGIN_NAME", SqlDbType.VarChar,20)};
                parameters[0].Value = where.LOGIN_NAME;
                int chkValue = DbHelperSQL.ExecuteScalar(ChkUser, parameters);
                if (chkValue == 0)
                {
                    return -1;
                }
                Ac = GetUserInfo(where.LOGIN_NAME, where.LOGIN_PWD);
                if (Ac != null)
                {
                    vList = vidal.get_ViewList(new Model.VIEW_USER_RIGHT() { USER_ID = Ac.USER_ID });
                    UpdateLogin_State((decimal)Ac.USER_ID, 1, clientIp);
                    intFlag = 1;
                }
                else
                {
                    intFlag = 0;
                }
            }
            catch (Exception ex)
            {

                intFlag = -2;
            }
            finally
            {
            }
            return intFlag;
        }

        /// <summary>
        /// 查询用户基本信息
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>返回基本信息</returns>
        public DataTable GetUserInfo(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select department_name from department d where d.department_id=u.department_id) as department_name,full_name,phone,mobile ");
            strSql.Append("from user_info u ");
            strSql.Append("where u.user_id='" + uid + "' ");
            return DbHelperSQL.GetTable(strSql.ToString());
        }

        /// <summary>
        /// 查询用户密码
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>返回密码</returns>
        public string GetUserPassword(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select login_pwd from user_info where user_id='" + uid + "'");
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            return dt.Rows[0]["login_pwd"].ToString();
        }
        #endregion  ExtensionMethod
    }
}