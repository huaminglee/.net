/**  版本信息模板在安装目录下，可自行修改。
* OA_EDUQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDUQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:35   N/A    初版
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
	/// 试题表
	/// </summary>
	public partial class OA_EDUQUESTION
	{
		private readonly PDTech.OA.DAL.OA_EDUQUESTION dal=new PDTech.OA.DAL.OA_EDUQUESTION();
		public OA_EDUQUESTION()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EDU_Q_GUID)
		{
			return dal.Exists(EDU_Q_GUID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_EDUQUESTION model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        public void BatchAdd(List<PDTech.OA.Model.OA_EDUQUESTION> list)
        {
            dal.BatchAdd(list);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_EDUQUESTION model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EDU_Q_GUID)
		{
			
			return dal.Delete(EDU_Q_GUID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EDU_Q_GUIDlist )
		{
			return dal.DeleteList(EDU_Q_GUIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_EDUQUESTION GetModel(string EDU_Q_GUID)
		{
			
			return dal.GetModel(EDU_Q_GUID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.OA_EDUQUESTION GetModelByCache(string EDU_Q_GUID)
		{
			
			string CacheKey = "OA_EDUQUESTIONModel-" + EDU_Q_GUID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EDU_Q_GUID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_EDUQUESTION)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 随机获取一道试题
		/// </summary>
		public List<PDTech.OA.Model.OA_EDUQUESTION> GetModelRound()
		{
			return DataTableToList(dal.GetRoundObj());
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_EDUQUESTION> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<PDTech.OA.Model.OA_EDUQUESTION> GetTestList(string strWhere)
        {
            DataSet ds = dal.GetTestList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_EDUQUESTION> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_EDUQUESTION> modelList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_EDUQUESTION model;
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
        public IList<Model.OA_EDUQUESTION> Get_Paging_List(string title, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_List(title, PageSize, PageIndex, out totalrecord);
        }        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_List_ByCondition(string strwhere, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_List_ByCondition(strwhere, PageSize, PageIndex, out totalrecord);
        }
 
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_List(decimal userId, string testId, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_List(userId, testId, PageSize, PageIndex, out totalrecord);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDUQUESTION> Get_Paging_TestList(string quesIds, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_TestList(quesIds, PageSize, PageIndex, out totalrecord);
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

