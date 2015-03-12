/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUTEST.cs
*
* 功 能： N/A
* 类 名： OA_EDUTEST
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:27   N/A    初版
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
	/// 试卷表
	/// </summary>
	public partial class OA_EDUTEST
	{
		private readonly PDTech.OA.DAL.OA_EDUTEST dal=new PDTech.OA.DAL.OA_EDUTEST();
		public OA_EDUTEST()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EDU_T_GUID)
		{
			return dal.Exists(EDU_T_GUID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_EDUTEST model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_EDUTEST model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EDU_T_GUID)
		{
			
			return dal.Delete(EDU_T_GUID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EDU_T_GUIDlist )
		{
			return dal.DeleteList(EDU_T_GUIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_EDUTEST GetModel(string EDU_T_GUID)
		{
			
			return dal.GetModel(EDU_T_GUID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.OA_EDUTEST GetModelByCache(string EDU_T_GUID)
		{
			
			string CacheKey = "OA_EDUTESTModel-" + EDU_T_GUID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EDU_T_GUID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_EDUTEST)objModel;
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
		public List<PDTech.OA.Model.OA_EDUTEST> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_EDUTEST> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_EDUTEST> modelList = new List<PDTech.OA.Model.OA_EDUTEST>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_EDUTEST model;
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
        public IList<Model.OA_EXPIRE_ONLINETEST> Get_expirePaging_List(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.Get_exprePaging_List(strWhere, currentPage, pageSize, out totalNum);
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
        public IList<Model.OA_EDUTEST> Get_Paging_List(string title, int PageSize, int PageIndex, out int totalrecord, string isshowexpire="")
        {
            return dal.Get_Paging_List(title, PageSize, PageIndex, out totalrecord, isshowexpire);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUTEST> Get_Paging_TestList(decimal userId, string title, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_TestList(userId, title, PageSize, PageIndex, out totalrecord);
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

