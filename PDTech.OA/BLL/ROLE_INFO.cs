using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// ROLE_INFO
	/// </summary>
	public partial class ROLE_INFO
	{
		private readonly PDTech.OA.DAL.ROLE_INFO dal=new PDTech.OA.DAL.ROLE_INFO();
		public ROLE_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.ROLE_INFO model,string HostName,string Ip,decimal operId)
		{
            return dal.Add(model, HostName, Ip,operId);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(PDTech.OA.Model.ROLE_INFO model, string HostName, string Ip, decimal operId)
		{
            return dal.Update(model, HostName, Ip, operId);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ROLE_ID)
		{
			
			return dal.Delete(ROLE_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ROLE_IDlist )
		{
			return dal.DeleteList(ROLE_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.ROLE_INFO GetModel(decimal ROLE_ID)
		{
			
			return dal.GetModel(ROLE_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.ROLE_INFO GetModelByCache(decimal ROLE_ID)
		{
			
			string CacheKey = "ROLE_INFOModel-" + ROLE_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ROLE_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.ROLE_INFO)objModel;
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
		public List<PDTech.OA.Model.ROLE_INFO> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.ROLE_INFO> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.ROLE_INFO> modelList = new List<PDTech.OA.Model.ROLE_INFO>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.ROLE_INFO model;
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
        /// 获取角色信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.ROLE_INFO> get_Paging_RoleInfoList(Model.ROLE_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_RoleInfoList(where, currentpage, pagesize, out totalrecord);
        }
         /// <summary>
        /// 获取一条角色信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.ROLE_INFO GetRoleInfo(decimal uId)
        {
            return dal.GetRoleInfo(uId);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        /// <summary>
        /// 获取全部角色信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.ROLE_INFO> get_RoleList(Model.ROLE_INFO where)
        {
            return dal.get_RoleList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

