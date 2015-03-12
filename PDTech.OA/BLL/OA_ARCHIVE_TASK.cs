using System.Collections.Generic;
using System.Data;

namespace PDTech.OA.BLL
{
    /// <summary>
    /// 公文任务表
    /// </summary>
    public partial class OA_ARCHIVE_TASK
    {
        private readonly PDTech.OA.DAL.OA_ARCHIVE_TASK dal = new PDTech.OA.DAL.OA_ARCHIVE_TASK();
        public OA_ARCHIVE_TASK()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ARCHIVE_TASK_ID)
        {
            return dal.Exists(ARCHIVE_TASK_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_ARCHIVE_TASK model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.OA_ARCHIVE_TASK model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 写入印章数据
        /// </summary>
        /// <param name="taskID"></param>
        /// <param name="sealData"></param>
        /// <returns></returns>
        public bool UpdateSealData(decimal taskID, string sealData)
        {
            return dal.UpdateSealData(taskID, sealData);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ARCHIVE_TASK_ID)
        {

            return dal.Delete(ARCHIVE_TASK_ID);
        }

        /// <summary>
        /// 获取任务信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE_TASK> get_TaskInfoList(Model.OA_ARCHIVE_TASK where)
        {
            return dal.get_TaskInfoList(where);
        }

        public IList<Model.OA_ARCHIVE_TASK> get_TaskInfoList(decimal aid, decimal tid)
        {
            return dal.get_TaskInfoList(aid, tid);
        }

        /// <summary>
        /// 获取一条任务信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_ARCHIVE_TASK GetTaskInfo(Model.OA_ARCHIVE_TASK where)
        {
            return dal.GetTaskInfo(where);
        }

        public Model.OA_ARCHIVE_TASK GetTaskInfo(decimal taskId)
        {
            return dal.GetTaskInfo(taskId);
        }
        /// <summary>
        /// 办理公文
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveHandle(PDTech.OA.Model.Pro_TASKHandle where)
        {
            return dal.ArchiveHandle(where);
        }
        /// <summary>
        /// 公文抄送
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveCopy(PDTech.OA.Model.Pro_TASKHandle model)
        {
            return dal.ArchiveCopy(model);
        }
        /// <summary>
        /// 公文退回
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int ArchiveRevert(PDTech.OA.Model.Pro_TASKHandle model)
        {
            return dal.ArchiveRevert(model);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询待办事项
        /// </summary>
        /// <returns>返回待办事项</returns>
        public IList<Model.OA_READY_WORK> GetReadyWork(string uId)
        {
            return dal.GetReadyWork(uId);
        }

        /// <summary>
        /// 查询超期预警（日常办公公文）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回超期预警</returns>
        public IList<Model.OA_EXPIRE_DOCUMENT> GetExpireDocument(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetExpireDocument(strWhere, currentPage, pageSize, out totalNum);
        }

        /// <summary>
        /// 查询风险项目（日常办公公文）
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回风险项目</returns>
        public IList<Model.OA_RISK_DOCUMENT> GetRisk(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetRisk(strWhere, currentPage, pageSize, out totalNum);
        }

        /// <summary>
        /// 查询顶部提醒（日常公文、督办工作、建议提案、人事任免）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public DataTable GetRemind(string uId)
        {
            return dal.GetRemind(uId);
        }

        /// <summary>
        /// 查询顶部提醒（公告）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindMessage(string uId)
        {
            return dal.GetRemindMessage(uId);
        }

        /// <summary>
        /// 查询顶部提醒（会议）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindMeeting(string uId)
        {
            return dal.GetRemindMeeting(uId);
        }

        /// <summary>
        /// 查询顶部提醒（超期风险处置提醒）
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <returns>返回每个需要提醒条目的数量</returns>
        public int GetRemindRISK(string uId,bool isall=false)
        {
            return dal.GetRemindRISK(uId,isall);
        }
        /// <summary>
        /// 公文查询
        /// </summary>
        /// <param name="uId">用户ID</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回公文查询</returns>
        public IList<Model.OA_MAJOR> GetDocument(string uId, string strWhere, string currentPage, string pageSize, out int totalNum,bool isall=false)
        {
            return dal.GetDocument(uId, strWhere, currentPage, pageSize, out totalNum,isall);
        }
        #endregion  ExtensionMethod
    }
}