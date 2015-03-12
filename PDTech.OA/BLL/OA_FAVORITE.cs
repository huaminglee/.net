using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;

namespace PDTech.OA.BLL
{
    /// <summary>
    /// OA_FAVORITE
    /// </summary>
    public partial class OA_FAVORITE
    {
        private readonly PDTech.OA.DAL.OA_FAVORITE dal = new PDTech.OA.DAL.OA_FAVORITE();
        public OA_FAVORITE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PDTech.OA.Model.OA_FAVORITE model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal favorite_id)
        {
            return dal.Delete(favorite_id);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 查询收藏夹（当前用户的某种公文类型）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="archiveType">公文类型</param>
        /// <returns>返回收藏夹</returns>
        public IList<Model.FAVORITE> GetFavorite(string uId, string archiveType)
        {
            return dal.GetFavorite(uId, archiveType);
        }
    }
}