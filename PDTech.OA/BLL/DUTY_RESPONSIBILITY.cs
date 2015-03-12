using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// 岗位职责
    /// </summary>
    public partial class DUTY_RESPONSIBILITY
    {
        private readonly PDTech.OA.DAL.DUTY_RESPONSIBILITY dal = new PDTech.OA.DAL.DUTY_RESPONSIBILITY();
        public DUTY_RESPONSIBILITY()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal DUTY_RESPONSIBILITY_ID)
        {
            return dal.Exists(DUTY_RESPONSIBILITY_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.DUTY_RESPONSIBILITY model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.DUTY_RESPONSIBILITY model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal DUTY_RESPONSIBILITY_ID)
        {
            return dal.Delete(DUTY_RESPONSIBILITY_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string DUTY_RESPONSIBILITY_IDlist)
        {
            return dal.DeleteList(DUTY_RESPONSIBILITY_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PDTech.OA.Model.DUTY_RESPONSIBILITY GetModel(decimal DUTY_RESPONSIBILITY_ID)
        {

            return dal.GetModel(DUTY_RESPONSIBILITY_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PDTech.OA.Model.DUTY_RESPONSIBILITY GetModelByCache(decimal DUTY_RESPONSIBILITY_ID)
        {

            string CacheKey = "DUTY_RESPONSIBILITYModel-" + DUTY_RESPONSIBILITY_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(DUTY_RESPONSIBILITY_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PDTech.OA.Model.DUTY_RESPONSIBILITY)objModel;
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
        public List<PDTech.OA.Model.DUTY_RESPONSIBILITY> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PDTech.OA.Model.DUTY_RESPONSIBILITY> DataTableToList(DataTable dt)
        {
            List<PDTech.OA.Model.DUTY_RESPONSIBILITY> modelList = new List<PDTech.OA.Model.DUTY_RESPONSIBILITY>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PDTech.OA.Model.DUTY_RESPONSIBILITY model;
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
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询岗位职责（当前用户）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回岗位职责</returns>
        public string GetResponsibility(string uId)
        {
            return dal.GetResponsibility(uId);
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
            return dal.GetAllResponsibility(strWhere, currentPage, pageSize, out totalNum);
        }

        /// <summary>
        /// 查询部门单位
        /// </summary>
        /// <returns>部门单位</returns>
        public DataTable GetDepartment()
        {
            return dal.GetDepartment();
        }

        /// <summary>
        /// 查询部门列表
        /// </summary>
        /// <returns>返回部门列表</returns>
        public IList<Model.DEPARTMENT_NAME> GetDepartmentName()
        {
            return dal.GetDepartmentName();
        }

        /// <summary>
        /// 查询岗位人员（正常使用状态）
        /// </summary>
        /// <returns>岗位人员</returns>
        public DataTable GetPerson()
        {
            return dal.GetPerson();
        }

        /// <summary>
        /// 查询岗位人员（正常使用状态）
        /// </summary>
        /// <param name="strName">姓名</param>
        /// <returns>岗位人员</returns>
        public DataTable GetPerson(string strName)
        {
            return dal.GetPerson(strName);
        }
        #endregion  ExtensionMethod
    }
}