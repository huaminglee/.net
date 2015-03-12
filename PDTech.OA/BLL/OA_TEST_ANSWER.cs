/**  版本信息模板在安装目录下，可自行修改。
* OA_TEST_ANSWER.cs
*
* 功 能： N/A
* 类 名： OA_TEST_ANSWER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/22 15:35:44   N/A    初版
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
	/// 答题表
	/// </summary>
	public partial class OA_TEST_ANSWER
	{
		private readonly PDTech.OA.DAL.OA_TEST_ANSWER dal=new PDTech.OA.DAL.OA_TEST_ANSWER();
		public OA_TEST_ANSWER()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EDU_A_GUID)
		{
			return dal.Exists(EDU_A_GUID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_TEST_ANSWER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_TEST_ANSWER model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EDU_A_GUID)
		{
			
			return dal.Delete(EDU_A_GUID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EDU_A_GUIDlist )
		{
			return dal.DeleteList(EDU_A_GUIDlist );
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_TEST_ANSWER GetModel(string EDU_A_GUID)
		{
			
			return dal.GetModel(EDU_A_GUID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.OA_TEST_ANSWER GetModelByCache(string EDU_A_GUID)
		{
			
			string CacheKey = "OA_TEST_ANSWERModel-" + EDU_A_GUID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EDU_A_GUID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_TEST_ANSWER)objModel;
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
		public List<PDTech.OA.Model.OA_TEST_ANSWER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<PDTech.OA.Model.OA_TEST_ANSWER> GetTotalList(string testId)
        {
            DataSet ds = dal.GetTotalList(testId);
            return DataTableToTotalList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_TEST_ANSWER> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_TEST_ANSWER> modelList = new List<PDTech.OA.Model.OA_TEST_ANSWER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_TEST_ANSWER model;
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

        public List<PDTech.OA.Model.OA_TEST_ANSWER> DataTableToTotalList(DataTable dt)
        {
            List<PDTech.OA.Model.OA_TEST_ANSWER> modelList = new List<PDTech.OA.Model.OA_TEST_ANSWER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PDTech.OA.Model.OA_TEST_ANSWER model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToTotal(dt.Rows[n]);
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

        public int GetIsAnswerCount(decimal? uid, string tid)
        {
            return dal.GetIsAnswerCount(uid, tid);
        }

        public string GetAnswerIdByTestId(decimal? uid, string tid)
        {
            return dal.GetAnswerIdByTestId(uid, tid);
        }

        public decimal GetTotalScore(decimal userId, string testId, string answerId)
        {
            return dal.GetTotalScore(userId, testId, answerId);
        }

        public string GetSelectOption(decimal userId, string testId, string answerId, string questionId)
        {
            return dal.GetSelectOption(userId, testId, answerId, questionId);
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

