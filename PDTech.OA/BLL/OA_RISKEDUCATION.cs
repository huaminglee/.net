/**  版本信息模板在安装目录下，可自行修改。
* OA_RISKEDUCATION.cs
*
* 功 能： N/A
* 类 名： OA_RISKEDUCATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:19   N/A    初版
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
	/// 教育任务表
	/// </summary>
	public partial class OA_RISKEDUCATION
	{
		private readonly PDTech.OA.DAL.OA_RISKEDUCATION dal=new PDTech.OA.DAL.OA_RISKEDUCATION();
		public OA_RISKEDUCATION()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal? EDUCATION_ID)
		{
            return dal.Exists(EDUCATION_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_RISKEDUCATION model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_RISKEDUCATION model, string fileIds, string receiveUserId, string hostIP, string hostName)
        {
            return dal.Add(model, fileIds, receiveUserId, hostIP, hostName);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_RISKEDUCATION model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(decimal? EDUCATION_ID)
		{

            return dal.Delete(EDUCATION_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool DeleteList(string EDUCATION_IDlist)
		{
            return dal.DeleteList(EDUCATION_IDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public PDTech.OA.Model.OA_RISKEDUCATION GetModel(decimal? EDUCATION_ID)
		{

            return dal.GetModel(EDUCATION_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public PDTech.OA.Model.OA_RISKEDUCATION GetModelByCache(decimal? EDUCATION_ID)
		{

            string CacheKey = "OA_RISKEDUCATIONModel-" + EDUCATION_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(EDUCATION_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_RISKEDUCATION)objModel;
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
		public List<PDTech.OA.Model.OA_RISKEDUCATION> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_RISKEDUCATION> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_RISKEDUCATION> modelList = new List<PDTech.OA.Model.OA_RISKEDUCATION>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_RISKEDUCATION model;
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
        public IList<Model.OA_RISKEDUCATION> Get_Paging_List(decimal userId, string title, string type, int PageSize, int PageIndex, out int totalrecord,bool isshwoexpire=false)
        {
            return dal.Get_Paging_List(userId, title, type, PageSize, PageIndex, out totalrecord, isshwoexpire);
        }
        public IList<Model.OA_EXPIRE_EDUTASK> Get_expirePaging_List(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.Get_exprePaging_List(strWhere, currentPage, pageSize, out totalNum);
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

