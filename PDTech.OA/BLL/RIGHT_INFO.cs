using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// RIGHT_INFO
	/// </summary>
	public partial class RIGHT_INFO
	{
		private readonly PDTech.OA.DAL.RIGHT_INFO dal=new PDTech.OA.DAL.RIGHT_INFO();
		public RIGHT_INFO()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal RIGHT_ID)
		{
			return dal.Exists(RIGHT_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(PDTech.OA.Model.RIGHT_INFO model, string HostName, string Ip, decimal operId)
		{
            return dal.Add(model, HostName,Ip,operId);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(PDTech.OA.Model.RIGHT_INFO model, string HostName, string Ip, decimal operId)
		{
            return dal.Update(model,HostName, Ip, operId);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal RIGHT_ID)
		{
			
			return dal.Delete(RIGHT_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RIGHT_IDlist )
		{
			return dal.DeleteList(RIGHT_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.RIGHT_INFO GetModel(decimal RIGHT_ID)
		{
			
			return dal.GetModel(RIGHT_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.RIGHT_INFO GetModelByCache(decimal RIGHT_ID)
		{
			
			string CacheKey = "RIGHT_INFOModel-" + RIGHT_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RIGHT_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.RIGHT_INFO)objModel;
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
		public List<PDTech.OA.Model.RIGHT_INFO> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.RIGHT_INFO> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.RIGHT_INFO> modelList = new List<PDTech.OA.Model.RIGHT_INFO>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.RIGHT_INFO model;
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
        /// 获取权限信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.RIGHT_INFO> get_RiInfoList(Model.RIGHT_INFO where)
        {
            return dal.get_RiInfoList(where);
        }
        /// <summary>
        /// 获取权限信息--返回dataTable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable get_RightInfoTab(Model.RIGHT_INFO where)
        {
            return dal.get_RightInfoTab(where);
        }
        /// <summary>
        /// 获取一条权限信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.RIGHT_INFO GetRightInfo(decimal uId)
        {
            return dal.GetRightInfo(uId);
        }
        /// <summary>
        /// 获取权限信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.RIGHT_INFO> get_Paging_RightInfoList(Model.RIGHT_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_RightInfoList(where, currentpage, pagesize, out totalrecord);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

