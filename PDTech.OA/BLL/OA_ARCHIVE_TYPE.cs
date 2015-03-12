using System.Collections.Generic;
using System.Data;

namespace PDTech.OA.BLL
{
    /// <summary>
    /// 公文类型定义字典表
    /// </summary>
    public partial class OA_ARCHIVE_TYPE
    {
        private readonly PDTech.OA.DAL.OA_ARCHIVE_TYPE dal = new PDTech.OA.DAL.OA_ARCHIVE_TYPE();
        public OA_ARCHIVE_TYPE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 获取类型信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE_TYPE> get_ArchiveTypeList(Model.OA_ARCHIVE_TYPE where)
        {
            return dal.get_ArchiveTypeList(where);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 查询公文类型
        /// </summary>
        /// <returns>返回公文类型</returns>
        public DataTable GetArchiveType()
        {
            return dal.GetArchiveType();
        }

        /// <summary>
        /// 查询公文类型
        /// </summary>
        /// <returns>返回公文类型</returns>
        public IList<Model.ARCHIVE_TYPE_OPTION> GetArchiveTypeOption()
        {
            return dal.GetArchiveTypeOption();
        }
    }
}