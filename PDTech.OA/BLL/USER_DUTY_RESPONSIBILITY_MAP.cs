using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 岗位职责映射表
	/// </summary>
	public partial class USER_DUTY_RESPONSIBILITY_MAP
	{
		private readonly PDTech.OA.DAL.USER_DUTY_RESPONSIBILITY_MAP dal=new PDTech.OA.DAL.USER_DUTY_RESPONSIBILITY_MAP();
		public USER_DUTY_RESPONSIBILITY_MAP()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="DUTY_RESPONSIBILITY_ID">职责ID</param>
        /// <returns>是否删除成功</returns>
        public bool Delete(decimal DUTY_RESPONSIBILITY_ID)
		{
            return dal.Delete(DUTY_RESPONSIBILITY_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "USER_DUTY_RESPONSIBILITY_MAPModel-" ;
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
			return (PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP)objModel;
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
		public List<PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP> modelList = new List<PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

