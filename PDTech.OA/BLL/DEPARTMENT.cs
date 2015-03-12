using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// DEPARTMENT
	/// </summary>
	public partial class DEPARTMENT
	{
		private readonly PDTech.OA.DAL.DEPARTMENT dal=new PDTech.OA.DAL.DEPARTMENT();
		public DEPARTMENT()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal DEPARTMENT_ID)
		{
			return dal.Exists(DEPARTMENT_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.DEPARTMENT model,string HostName, string Ip, decimal operId)
		{
			return dal.Add(model,HostName, Ip, operId);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.DEPARTMENT model,string HostName, string Ip, decimal operId)
		{
			return dal.Update(model,HostName, Ip, operId);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal DEPARTMENT_ID)
		{
			
			return dal.Delete(DEPARTMENT_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DEPARTMENT_IDlist )
		{
			return dal.DeleteList(DEPARTMENT_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.DEPARTMENT GetModel(decimal DEPARTMENT_ID)
		{
			
			return dal.GetModel(DEPARTMENT_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.DEPARTMENT GetModelByCache(decimal DEPARTMENT_ID)
		{
			
			string CacheKey = "DEPARTMENTModel-" + DEPARTMENT_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DEPARTMENT_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.DEPARTMENT)objModel;
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
		public List<PDTech.OA.Model.DEPARTMENT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.DEPARTMENT> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.DEPARTMENT> modelList = new List<PDTech.OA.Model.DEPARTMENT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.DEPARTMENT model;
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
        /// 获取全部部门信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.DEPARTMENT> get_DeptList(Model.DEPARTMENT where)
        {
            return dal.get_DeptList(where);
        }
        /// <summary>
        /// 获取全部部门信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_DeptTab(Model.DEPARTMENT where)
        {
            return dal.get_DeptTab(where);
        }
        /// <summary>
        /// 获取全部部门信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.DEPARTMENT> get_Paging_DeptList(Model.DEPARTMENT where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_DeptList(where, currentpage, pagesize, out totalrecord);
        }

        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.DEPARTMENT GetDeptInfo(decimal deptId)
        {
            return dal.GetDeptInfo(deptId);
        }
        /// <summary>
        /// 修改部门是否显示
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="disType">修改值</param>
        /// <returns></returns>
        public int ModDisable(decimal deptId, string disType)
        {
            return dal.ModDisable(deptId, disType);
        }
          /// <summary>
        /// 查询部门单位_默认人员
        /// </summary>
        /// <returns>部门单位</returns>
        public DataTable GetDepartment_DefaultUser()
        {
            return dal.GetDepartment_DefaultUser();
        }
         /// <summary>
        /// 获取SEQ
        /// </summary>
        /// <returns></returns>
        public int getSEQ()
        {
            return dal.getSEQ();
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

        
		#endregion  ExtensionMethod
	}
}

