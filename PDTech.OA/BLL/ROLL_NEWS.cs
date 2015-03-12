/**  版本信息模板在安装目录下，可自行修改。
* ROLL_NEWS.cs
*
* 功 能： N/A
* 类 名： ROLL_NEWS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/6 15:00:47   N/A    初版
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
	/// 滚动新闻表
	/// </summary>
	public partial class ROLL_NEWS
	{
		private readonly PDTech.OA.DAL.ROLL_NEWS dal=new PDTech.OA.DAL.ROLL_NEWS();
		public ROLL_NEWS()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.ROLL_NEWS model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(PDTech.OA.Model.ROLL_NEWS model)
		{
			return dal.Update(model);
		}

        public bool Update(string NEWS_IDlist, decimal isRolling)
        {
            return dal.Update(NEWS_IDlist, isRolling);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal NEWS_ID)
		{
			
			return dal.Delete(NEWS_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NEWS_IDlist )
		{
			return dal.DeleteList(NEWS_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.ROLL_NEWS GetModel(decimal NEWS_ID)
		{
			
			return dal.GetModel(NEWS_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.ROLL_NEWS GetModelByCache(decimal NEWS_ID)
		{
			
			string CacheKey = "ROLL_NEWSModel-" + NEWS_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NEWS_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.ROLL_NEWS)objModel;
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
		public List<PDTech.OA.Model.ROLL_NEWS> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.ROLL_NEWS> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.ROLL_NEWS> modelList = new List<PDTech.OA.Model.ROLL_NEWS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.ROLL_NEWS model;
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

        public IList<Model.ROLL_NEWS> Get_Paging_List(string title, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.Get_Paging_List(title, currentpage, pagesize, out totalrecord);
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

