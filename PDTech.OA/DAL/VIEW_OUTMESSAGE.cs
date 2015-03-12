
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_OUTMESSAGE
	/// </summary>
	public partial class VIEW_OUTMESSAGE
	{
		public VIEW_OUTMESSAGE()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取并返回符合条件的公告列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW_OUTMESSAGE> get_outmessageList(Model.VIEW_OUTMESSAGE where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_OUTMESSAGE WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_OUTMESSAGE>(dt);
        }
        /// <summary>
        /// 获取公告信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_OUTMESSAGE> get_Paging_outMsgList(Model.VIEW_OUTMESSAGE where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM VIEW_OUTMESSAGE WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "MESSAGE_ID", "DESC");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_OUTMESSAGE>(dt);
        }
        
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

