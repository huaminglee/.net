using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
using System.Collections.Generic;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// VIEW_ARCHIVE_FILE_TASK
	/// </summary>
	public partial class VIEW_ARCHIVE_FILE_TASK
	{
		private readonly PDTech.OA.DAL.VIEW_ARCHIVE_FILE_TASK dal=new PDTech.OA.DAL.VIEW_ARCHIVE_FILE_TASK();
		public VIEW_ARCHIVE_FILE_TASK()
		{}
		#region  BasicMethod
          /// <summary>
        /// 获取任务信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_FILE_TASK> get_Paging_taskInfoList(Model.VIEW_ARCHIVE_FILE_TASK where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_taskInfoList(where, currentpage, pagesize, out totalrecord);
        }
        public DataTable getArchiveTongji(string strwhere,string ftype)
        {
            return dal.getArchiveTongji(strwhere,ftype);
        }
        public DataTable getArchiveunfinished(string strwhere)
        {
            return dal.getArchiveunfinished(strwhere);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

