/**  版本信息模板在安装目录下，可自行修改。
* OA_EDAYQUESTION.cs
*
* 功 能： N/A
* 类 名： OA_EDAYQUESTION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/24 15:01:39   N/A    初版
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
	/// 每日一题表
	/// </summary>
	public partial class OA_EDAYQUESTION
	{
		private readonly PDTech.OA.DAL.OA_EDAYQUESTION dal=new PDTech.OA.DAL.OA_EDAYQUESTION();
		public OA_EDAYQUESTION()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal EDAY_Q_ID)
		{
			return dal.Exists(EDAY_Q_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_EDAYQUESTION model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_EDAYQUESTION model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal EDAY_Q_ID)
		{
			
			return dal.Delete(EDAY_Q_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EDAY_Q_IDlist )
		{
			return dal.DeleteList(EDAY_Q_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_EDAYQUESTION GetModel(decimal EDAY_Q_ID)
		{
			
			return dal.GetModel(EDAY_Q_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.OA_EDAYQUESTION GetModelByCache(decimal EDAY_Q_ID)
		{
			
			string CacheKey = "OA_EDAYQUESTIONModel-" + EDAY_Q_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EDAY_Q_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_EDAYQUESTION)objModel;
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
		public List<PDTech.OA.Model.OA_EDAYQUESTION> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}       
        public DataTable Tongji(string strWhere)
        {
            return dal.GetTongji(strWhere);
        }

        public List<PDTech.OA.Model.OA_EDAYQUESTION> GetUidList(string strWhere)
        {
            DataSet ds = dal.GetUidList(strWhere);
            return DataTableToSingle(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_EDAYQUESTION> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_EDAYQUESTION> modelList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_EDAYQUESTION model;
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

        public List<PDTech.OA.Model.OA_EDAYQUESTION> DataTableToSingle(DataTable dt)
        {
            List<PDTech.OA.Model.OA_EDAYQUESTION> modelList = new List<PDTech.OA.Model.OA_EDAYQUESTION>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PDTech.OA.Model.OA_EDAYQUESTION model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToSingle(dt.Rows[n]);
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
        /// 当天是否已经存在答题记录
        /// </summary>
        /// <returns></returns>
        public int IsHasRecord(decimal userId)
        {
            return dal.IsHasRecord(userId);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<Model.OA_EDAYQUESTION> Get_Paging_List(decimal userId, string title, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_List(userId, title, PageSize, PageIndex, out totalrecord);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="departmentId"></param>
        /// <param name="date"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_EDAYQUESTION> Get_Paging_List(string title, decimal departmentId, decimal userId, string sDate, string eDate, decimal state, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_List(title, departmentId, userId, sDate, eDate, state, PageSize, PageIndex, out totalrecord);
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

