using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// USER_INFO
    /// </summary>
    public partial class USER_INFO
    {
        private readonly PDTech.OA.DAL.USER_INFO dal = new PDTech.OA.DAL.USER_INFO();
        public USER_INFO()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal USER_ID)
        {
            return dal.Exists(USER_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PDTech.OA.Model.USER_INFO model, string HostName, string Ip, decimal operId)
        {
            return dal.Add(model, HostName, Ip, operId);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(PDTech.OA.Model.USER_INFO model,string HostName, string Ip, decimal operId)
        {
            return dal.Update(model,HostName, Ip, operId);
        }

        /// <summary>
        /// 更新一条数据（用户基本信息）
        /// </summary>
        public bool Update(PDTech.OA.Model.USER_INFO model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public bool UpdatePwd(PDTech.OA.Model.USER_INFO model)
        {
            return dal.UpdatePwd(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal USER_ID)
        {
            return dal.Delete(USER_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string USER_IDlist)
        {
            return dal.DeleteList(USER_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.USER_INFO GetModel(decimal USER_ID)
        {

            return dal.GetModel(USER_ID);
        }

        public PDTech.OA.Model.USER_INFO GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PDTech.OA.Model.USER_INFO GetModelByCache(decimal USER_ID)
        {

            string CacheKey = "USER_INFOModel-" + USER_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(USER_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PDTech.OA.Model.USER_INFO)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PDTech.OA.Model.USER_INFO> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取分管部门下属所有人员
        /// </summary>
        /// <param name="uid">当前用户id</param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.USER_INFO> GetOwnerDeptUsersModelList(string uid)
        {
            return dal.GetOwnerDeptUsersModelList(uid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PDTech.OA.Model.USER_INFO> DataTableToList(DataTable dt)
        {
            List<PDTech.OA.Model.USER_INFO> modelList = new List<PDTech.OA.Model.USER_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PDTech.OA.Model.USER_INFO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_UserInfoList(Model.USER_INFO where)
        {
            return dal.get_UserInfoList(where);
        }
         /// <summary>
        /// 获取用户信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_UserTab(Model.USER_INFO where)
        {
            return dal.get_UserTab(where);
        }
        /// <summary>
        /// 获取一条用户信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.USER_INFO GetUserInfo(decimal uId)
        {
            return dal.GetUserInfo(uId);
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>某一部门的所有用户</returns>
        public IList<Model.USER_INFO> GetUserInfoBydeptId(string deptId)
        {
            return dal.GetUserInfoBydeptId(deptId);
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
            return dal.get_Paging_UserInfoList(where,currentpage,pagesize,out totalrecord);
        }
         /// <summary>
        /// 用户是否启用
        /// </summary>
        /// <param name="deptId">用户ID</param>
        /// <param name="disType">修改值</param>
        /// <returns></returns>
        public int ModDisable(decimal userId, string disType)
        {
            return dal.ModDisable(userId, disType);
        }
         /// <summary>
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_UserInfoList(decimal uId)
        {
            return dal.get_UserInfoList(uId);
        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.USER_INFO> get_UserList(Model.USER_INFO where)
        {
            return dal.get_tUserList(where);
        }
        /// <summary>
        /// 修改登录状态
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdateLogin_State(decimal userId, int state, string clientIp)
        {
            return dal.UpdateLogin_State(userId, state,clientIp);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int UserLogin(PDTech.OA.Model.USER_INFO where, out PDTech.OA.Model.USER_INFO Ac, out IList<PDTech.OA.Model.VIEW_USER_RIGHT> vList,string clientIp)
        {
            return dal.UserLogin(where, out Ac, out vList, clientIp);
        }

        /// <summary>
        /// 获取用户信息返回为datatable 
        /// </summary>
        /// <param name="uName">full_name</param>
        /// <param name="Right_Code">权限编码</param>
        /// <returns></returns>
        public DataTable GetUserList(string uName, string Right_Code)
        {
            return dal.GetUserList(uName, Right_Code);
        }
        public DataTable GetCurDeptUserList(string uid)
        {
            return dal.GetCurDeptUserList(uid);
        }

        /// <summary>
        /// 查询用户基本信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetUserInfo(string uid)
        {
            return dal.GetUserInfo(uid);
        }

        /// <summary>
        /// 查询用户密码
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>返回密码</returns>
        public string GetUserPassword(string uid)
        {
            return dal.GetUserPassword(uid);
        }

        #endregion  ExtensionMethod
    }
}