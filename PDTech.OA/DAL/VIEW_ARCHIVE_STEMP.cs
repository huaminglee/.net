using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references

namespace PDTech.OA.DAL
{
    public class VIEW_ARCHIVE_STEMP
    {
        public VIEW_ARCHIVE_STEMP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 获取公文相关信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW.VIEW_ARCHIVE_STEMP> get_ViewArchiveStep(Model.VIEW.VIEW_ARCHIVE_STEMP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_ARCHIVE_STEMP WHERE 1=1 {0}",condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            return DAL_Helper.CommonFillList<Model.VIEW.VIEW_ARCHIVE_STEMP>(dt);
        }
        /// <summary>
        /// 获取公文相关信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW.VIEW_ARCHIVE_STEMP get_viewarchivestepInfo(Model.VIEW.VIEW_ARCHIVE_STEMP where)
        {
            string condition = DAL_Helper.GetWhereCondition(where);
            string selSQL = string.Format(@"SELECT * FROM VIEW_ARCHIVE_STEMP WHERE 1=1 {0}", condition);
            DataTable dt = DbHelperSQL.GetTable(selSQL);
            if (dt.Rows.Count > 0)
            {
                return DAL_Helper.CommonFillList<Model.VIEW.VIEW_ARCHIVE_STEMP>(dt)[0];
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
