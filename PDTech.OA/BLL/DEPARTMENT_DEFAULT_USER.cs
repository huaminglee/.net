/**  版本信息模板在安装目录下，可自行修改。
* DEPARTMENT_DEFAULT_USER.cs
*
* 功 能： N/A
* 类 名： DEPARTMENT_DEFAULT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 部门默认公文接收人
	/// </summary>
	public partial class DEPARTMENT_DEFAULT_USER
	{
		private readonly PDTech.OA.DAL.DEPARTMENT_DEFAULT_USER dal=new PDTech.OA.DAL.DEPARTMENT_DEFAULT_USER();
		public DEPARTMENT_DEFAULT_USER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model)
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
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.DEPARTMENT_DEFAULT_USER GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.DEPARTMENT_DEFAULT_USER GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "DEPARTMENT_DEFAULT_USERModel-" ;
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
			return (PDTech.OA.Model.DEPARTMENT_DEFAULT_USER)objModel;
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
		public List<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> modelList = new List<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.DEPARTMENT_DEFAULT_USER model;
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
        /// 事务添加部门默认指定人员
        /// </summary>
        /// <param name="kList"></param>
        /// <param name="user_Id"></param>
        /// <returns></returns>
        public int ExecuteSqlTran(IList<PDTech.OA.Model.DEPARTMENT_DEFAULT_USER> List)
        {
            return dal.ExecuteSqlTran(List);
        }
         /// <summary>
        /// 获取全部部门指定人员绑定数据---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.DEPARTMENT_DEFAULT_USER get_uDeptList(decimal deptId)
        {
            return dal.get_uDeptList(deptId);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

