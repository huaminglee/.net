
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
    /// <summary>
    /// 工作表
    /// </summary>
    public partial class OA_ARCHIVE
    {
        private readonly PDTech.OA.DAL.OA_ARCHIVE dal = new PDTech.OA.DAL.OA_ARCHIVE();
        public OA_ARCHIVE()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ARCHIVE_ID)
        {
            return dal.Exists(ARCHIVE_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PDTech.OA.Model.OA_ARCHIVE model, string HostName, string Ip, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList, out int? ARCHIVE_ID, out int? TASK_ID)
        {
            return dal.Add(model, HostName, Ip, Ids, AttList, out ARCHIVE_ID, out TASK_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddRisk(PDTech.OA.Model.OA_ARCHIVE model, string HostName, string Ip, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList, int p_ArchiveID, int p_taskID, int ptype, int rId, out int? ARCHIVE_ID, out int? TASK_ID)
        {
            return dal.AddRisk(model, HostName, Ip, Ids, AttList, p_ArchiveID, p_taskID, ptype, rId, out ARCHIVE_ID, out TASK_ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PDTech.OA.Model.OA_ARCHIVE model, string Ids, IList<PDTech.OA.Model.ATTRIBUTES> AttList)
        {
            return dal.Update(model, Ids, AttList);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal ARCHIVE_ID)
        {

            return dal.Delete(ARCHIVE_ID);
        }

        /// <summary>
        /// 获取一条公文信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_ARCHIVE GetArchiveInfo(decimal aId)
        {
            return dal.GetArchiveInfo(aId);
        }
        /// <summary>
        /// 公文流程转向
        /// </summary>
        /// <param name="Opter">操作人员ID</param>
        /// <param name="arId">公文ID</param>
        /// <param name="nextStempId">下一步骤ID</param>
        /// <param name="reMark">备注</param>
        /// <param name="userList">用户ID</param>
        /// <returns></returns>
        public bool RELOCATE(decimal Opter, decimal arId, decimal nextStempId, string reMark, string userList)
        {
            return dal.RELOCATE(Opter, arId, nextStempId, reMark, userList);
        }
        /// <summary>
        /// 获取公文列表信息-使用分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllList(Model.OA_ARCHIVE where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_ArchiveAllList(where, currentpage, pagesize, out totalrecord);
        }
        /// <summary>
        /// 查询三重一大
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllListszyd(int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_ArchiveAllListszyd(currentpage, pagesize, out totalrecord);
        }
        
        /// <summary>
        /// 获取公文列表信息-未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.OA_ARCHIVE> get_Paging_ArchiveAllList(Model.OA_ARCHIVE where)
        {
            return dal.get_Paging_ArchiveAllList(where);
        }
        /// <summary>
        /// 获取公文列表信息-未分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        public IList<Model.VIEW_ARCHIVE_USER_DEPT> get_Paging_ArchiveAllList(Model.VIEW_ARCHIVE_USER_DEPT where)
        {
            return dal.get_Paging_ArchiveAllList(where);
        }
        /// <summary>
        /// 查询教育任务数量
        /// </summary>
        /// <returns></returns>
        public string get_edutaskandonlinetestcount()
        {
            return dal.get_edutaskandonlinetestcount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW_ARCHIVE_USER_DEPT get_ArchiveAll_UserList(Model.VIEW_ARCHIVE_USER_DEPT where)
        {
            return dal.get_ArchiveAll_UserList(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 测试
        /// </summary>
        public IList<Model.OA_MAJOR> GetTest(string page, string rows, out int totalNum)
        {
            return dal.GetTest(page, rows, out totalNum);
        }

        /// <summary>
        /// 查询三重一大
        /// </summary>
        /// <returns>返回三重一大</returns>
        public IList<Model.OA_MAJOR> GetMajor()
        {
            return dal.GetMajor();
        }

        /// <summary>
        /// 查询所有三重一大
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="currentPage">当前页面</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalNum">总条数</param>
        /// <returns>返回所有三重一大</returns>
        public IList<Model.OA_MAJOR> GetMajor(string strWhere, string currentPage, string pageSize, out int totalNum)
        {
            return dal.GetMajor(strWhere, currentPage, pageSize, out totalNum);
        }
        #endregion  ExtensionMethod
    }
}