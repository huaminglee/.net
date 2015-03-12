/**  版本信息模板在安装目录下，可自行修改。
* MEETING_ROOM_INFO.cs
*
* 功 能： N/A
* 类 名： MEETING_ROOM_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-26 9:19:36   N/A    初版
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
	/// 会议室信息表
	/// </summary>
	public partial class MEETING_ROOM_INFO
	{
		private readonly PDTech.OA.DAL.MEETING_ROOM_INFO dal=new PDTech.OA.DAL.MEETING_ROOM_INFO();
		public MEETING_ROOM_INFO()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PDTech.OA.Model.MEETING_ROOM_INFO model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(PDTech.OA.Model.MEETING_ROOM_INFO model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal MEETING_ROOM_ID)
		{
			
			return dal.Delete(MEETING_ROOM_ID);
		}
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.MEETING_ROOM_INFO GetmRoomInfo(decimal mId)
        {
            return dal.GetmRoomInfo(mId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PDTech.OA.Model.MEETING_ROOM_INFO> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PDTech.OA.Model.MEETING_ROOM_INFO> DataTableToList(DataTable dt)
        {
            List<PDTech.OA.Model.MEETING_ROOM_INFO> modelList = new List<PDTech.OA.Model.MEETING_ROOM_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PDTech.OA.Model.MEETING_ROOM_INFO model;
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
        /// 获取基础数据信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.MEETING_ROOM_INFO> get_Paging_mRoomList(Model.MEETING_ROOM_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_mRoomList(where, currentpage, pagesize, out totalrecord);
        }
		

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

