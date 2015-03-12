using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 公文项目关联表
	/// </summary>
	public partial class ARCHIVE_PROJECT_MAP
	{
		private readonly PDTech.OA.DAL.ARCHIVE_PROJECT_MAP dal=new PDTech.OA.DAL.ARCHIVE_PROJECT_MAP();
		public ARCHIVE_PROJECT_MAP()
		{}
		#region  BasicMethod

		 /// <summary>
        /// 获取Anchive和Project关联
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.ARCHIVE_PROJECT_MAP get_mapInfo(Model.ARCHIVE_PROJECT_MAP where)
        {
            return dal.get_mapInfo(where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

