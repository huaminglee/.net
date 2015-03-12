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
    public partial class OA_MESSAGE_RECEIVER
    {
        private readonly PDTech.OA.DAL.OA_MESSAGE_RECEIVER dal = new PDTech.OA.DAL.OA_MESSAGE_RECEIVER();
        public OA_MESSAGE_RECEIVER()
        { }
        #region  BasicMethod
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IList<PDTech.OA.Model.OA_MESSAGE_RECEIVER> List)
        {
            return dal.Update(List);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询公告消息
        /// </summary>
        /// <returns>返回公告消息</returns>
        public IList<Model.OA_BULLETIN> GetBulletin(string uId)
        {
            return dal.GetBulletin(uId);
        }

        /// <summary>
        /// 查询公告消息（未读和已读）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回公告消息</returns>
        public IList<Model.OA_ALL_BULLETIN> GetAllBulletin(string uId, string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetAllBulletin(uId, strWhere, currentPage, pageSize, out totalNum);
        }
        #endregion  ExtensionMethod
    }
}