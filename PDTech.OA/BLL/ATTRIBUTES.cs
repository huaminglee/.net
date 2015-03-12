using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// ATTRIBUTES
	/// </summary>
	public partial class ATTRIBUTES
	{
		private readonly PDTech.OA.DAL.ATTRIBUTES dal=new PDTech.OA.DAL.ATTRIBUTES();
		public ATTRIBUTES()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ATTRIBUTE_ID)
		{
			return dal.Exists(ATTRIBUTE_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.ATTRIBUTES model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.ATTRIBUTES model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ATTRIBUTE_IDlist )
		{
			return dal.DeleteList(ATTRIBUTE_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.ATTRIBUTES GetModel(decimal ATTRIBUTE_ID)
		{
			
			return dal.GetModel(ATTRIBUTE_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.ATTRIBUTES GetModelByCache(decimal ATTRIBUTE_ID)
		{
			
			string CacheKey = "ATTRIBUTESModel-" + ATTRIBUTE_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ATTRIBUTE_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.ATTRIBUTES)objModel;
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
		public List<PDTech.OA.Model.ATTRIBUTES> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.ATTRIBUTES> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.ATTRIBUTES> modelList = new List<PDTech.OA.Model.ATTRIBUTES>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.ATTRIBUTES model;
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
        /// 获取用户信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ATTRIBUTES> get_AttInfoList(Model.ATTRIBUTES where)
        {
            return dal.get_AttInfoList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

