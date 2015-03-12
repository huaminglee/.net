﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// ROLE_RIGHT_MAP
	/// </summary>
	public partial class ROLE_RIGHT_MAP
	{
		private readonly PDTech.OA.DAL.ROLE_RIGHT_MAP dal=new PDTech.OA.DAL.ROLE_RIGHT_MAP();
		public ROLE_RIGHT_MAP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.ROLE_RIGHT_MAP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.ROLE_RIGHT_MAP model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

        /// <summary>
        /// 删除角色-权限关系数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteBy_RoleId(decimal rId)
        {
            return dal.DeleteBy_RoleId(rId);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.ROLE_RIGHT_MAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.ROLE_RIGHT_MAP GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "ROLE_RIGHT_MAPModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.ROLE_RIGHT_MAP)objModel;
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
		public List<PDTech.OA.Model.ROLE_RIGHT_MAP> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.ROLE_RIGHT_MAP> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.ROLE_RIGHT_MAP> modelList = new List<PDTech.OA.Model.ROLE_RIGHT_MAP>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.ROLE_RIGHT_MAP model;
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
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
         /// <summary>
        /// 事务添加角色权限
        /// </summary>
        /// <param name="kList"></param>
        /// <param name="user_Id"></param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.ROLE_RIGHT_MAP> List, string HostName, string Ip, decimal operId)
        {
            return dal.ExecuteSqlTran(List, HostName,Ip,operId);
        }
        /// <summary>
        /// 获取全部角色权限绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ROLE_RIGHT_MAP> get_rPurviewList(decimal rId)
        {
            return dal.get_rPurviewList(rId);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

