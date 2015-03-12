/**  版本信息模板在安装目录下，可自行修改。
* OA_MEETING.cs
*
* 功 能： N/A
* 类 名： OA_MEETING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-7-16 9:31:23   N/A    初版
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
	/// 公告消息表
	/// </summary>
	public partial class OA_MEETING
	{
		private readonly PDTech.OA.DAL.OA_MEETING dal=new PDTech.OA.DAL.OA_MEETING();
		public OA_MEETING()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MEETING_ID)
		{
			return dal.Exists(MEETING_ID);
		}

        /// <summary>
        /// 是否存在记录
        /// </summary>
        public bool Exists(decimal roomId, string location, DateTime startTime, DateTime endTime)
        {
            return dal.Exists(roomId, location, startTime, endTime);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PDTech.OA.Model.OA_MEETING model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_MEETING model, string fileIds, string receiveUserIds, int isSend, string clientIp, string clientHost)
        {
            return dal.Add(model, fileIds, receiveUserIds, isSend, clientIp, clientHost);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PDTech.OA.Model.OA_MEETING model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal MEETING_ID)
		{
			
			return dal.Delete(MEETING_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PDTech.OA.Model.OA_MEETING GetModel(decimal MEETING_ID)
		{
			
			return dal.GetModel(MEETING_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PDTech.OA.Model.OA_MEETING GetModelByCache(decimal MEETING_ID)
		{
			
			string CacheKey = "OA_MEETINGModel-" + MEETING_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MEETING_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PDTech.OA.Model.OA_MEETING)objModel;
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
		public List<PDTech.OA.Model.OA_MEETING> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PDTech.OA.Model.OA_MEETING> DataTableToList(DataTable dt)
		{
			List<PDTech.OA.Model.OA_MEETING> modelList = new List<PDTech.OA.Model.OA_MEETING>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PDTech.OA.Model.OA_MEETING model;
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
        public IList<Model.OA_MEETING> Get_Paging_MeetingList(decimal creatorId, string title, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_MeetingList(creatorId,title, PageSize, PageIndex, out totalrecord);
        }

        public IList<Model.OA_MEETING> Get_Paging_MeetingList(string title, int PageSize, int PageIndex, out int totalrecord)
        {
            return dal.Get_Paging_MeetingList(title, PageSize, PageIndex, out totalrecord);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

