/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING_RECEIVER.cs
*
* 功 能： N/A
* 类 名： OA_MEETING_RECEIVER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:12   N/A    初版
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
	/// 公告消息接收情况
	/// </summary>
	public partial class OA_MEETING_RECEIVER
	{
		private readonly PDTech.OA.DAL.OA_MEETING_RECEIVER dal=new PDTech.OA.DAL.OA_MEETING_RECEIVER();
		public OA_MEETING_RECEIVER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_MEETING_RECEIVER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_MEETING_RECEIVER model)
		{
			return dal.Update(model);
		}

        public bool UpdateState(PDTech.OA.Model.OA_MEETING_RECEIVER model)
        {
            return dal.UpdateState(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public PDTech.OA.Model.OA_MEETING_RECEIVER GetModel(decimal mID, decimal receiverID)
		{
			//该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(mID, receiverID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public PDTech.OA.Model.OA_MEETING_RECEIVER GetModelByCache(decimal mID, decimal receiverID)
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "OA_MEETING_RECEIVERModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(mID, receiverID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_MEETING_RECEIVER)objModel;
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
		public List<PDTech.OA.Model.OA_MEETING_RECEIVER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_MEETING_RECEIVER> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_MEETING_RECEIVER> modelList = new List<PDTech.OA.Model.OA_MEETING_RECEIVER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_MEETING_RECEIVER model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 查询会议通知（未读和已读）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回会议通知</returns>
        public IList<Model.OA_ALL_BULLETIN> GetAllBulletin(string uId, string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetAllBulletin(uId, strWhere, currentPage, pageSize, out totalNum);
        }
		#endregion  ExtensionMethod
	}
}

