using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace PDTech.OA.DAL
{
	/// <summary>
	/// 数据访问类:VIEW_USER_MSGINFO
	/// </summary>
	public partial class VIEW_USER_MSGINFO
	{
		public VIEW_USER_MSGINFO()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取公告信息列表---未分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_MSGINFO> get_MsgList(Model.VIEW_USER_MSGINFO model)
        {
            string condition = DAL_Helper.GetWhereCondition(model);
            string selSQL = string.Format(@"SELECT * FROM VIEW_USER_MSGINFO WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW_USER_MSGINFO>(dt);
        }

        /// <summary>
        /// 获取符合条件的公告信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Model.VIEW_USER_MSGINFO get_MsgInfo(Model.VIEW_USER_MSGINFO model)
        {
            string condition = DAL_Helper.GetWhereCondition(model);
            string selSQL = string.Format(@"SELECT * FROM VIEW_USER_MSGINFO WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_USER_MSGINFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取符合条件的公告信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Model.VIEW_USER_MSGINFO get_MsgInfo(decimal msgID)
        {
            string selSQL = string.Format(@"SELECT * FROM VIEW_USER_MSGINFO WHERE 1=1 AND MESSAGE_ID={0}", msgID);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW_USER_MSGINFO>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取公告信息列表-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_USER_MSGINFO> get_Paging_MsgInfoList(Model.VIEW_USER_MSGINFO where, int currentpage, int pagesize, out int totalrecord)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string strSQL = string.Format("SELECT TOP (100) PERCENT * FROM VIEW_USER_MSGINFO WHERE 1=1 {0} ", condition);
            PageDescribe pdes = new PageDescribe();
            pdes.CurrentPage = currentpage;
            pdes.PageSize = pagesize;
            DataTable dt = pdes.PageDescribes(strSQL, "MESSAGE_ID", "desc");
            totalrecord = pdes.RecordCount;
            return DAL_Helper.CommonFillList<Model.VIEW_USER_MSGINFO>(dt);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

