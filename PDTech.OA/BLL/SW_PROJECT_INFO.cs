using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 水务项目基础信息表
	/// </summary>
	public partial class SW_PROJECT_INFO
	{
		private readonly PDTech.OA.DAL.SW_PROJECT_INFO dal=new PDTech.OA.DAL.SW_PROJECT_INFO();
		public SW_PROJECT_INFO()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal PROJECT_ID)
		{
			return dal.Exists(PROJECT_ID);
		}

		/// <summary>
		/// 新增信息
		/// </summary>
		/// <param name="model">实例信息</param>
		/// <param name="HostName">计算机名</param>
		/// <param name="Ip">IP</param>
		/// <param name="Ids">附件Ids</param>
		/// <param name="Is_szyd">是否三重一大</param>
		/// <param name="Archive_ID">公文ID</param>
		/// <param name="Project_Id">项目ID</param>
		/// <param name="Task_id">任务ID</param>
		/// <returns></returns>
		public bool Add(PDTech.OA.Model.SW_PROJECT_INFO model,string HostName, string Ip, string Ids, int Is_szyd, out decimal Archive_ID, out decimal Project_Id,out decimal Task_id)
		{
			return dal.Add(model,HostName,Ip,Ids,Is_szyd,out Archive_ID,out Project_Id,out Task_id);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(PDTech.OA.Model.SW_PROJECT_INFO model, decimal ArID)
		{
			return dal.Update(model,ArID);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal PROJECT_ID)
		{
			
			return dal.Delete(PROJECT_ID);
		}
		
         /// <summary>
        /// 获取项目列表---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.SW_PROJECT_INFO> get_proList(Model.SW_PROJECT_INFO where)
        {
            return dal.get_proList(where);
        }

         /// <summary>
        /// 获取项目-使用分页
        /// </summary>
        /// <param name="where">条件[实体]</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">显示数目</param>
        /// <param name="totalrecord">总条数</param>
        /// <returns></returns>
        public IList<Model.SW_PROJECT_INFO> get_Paging_proList(Model.SW_PROJECT_INFO where, int currentpage, int pagesize, out int totalrecord)
        {
            return dal.get_Paging_proList(where, currentpage, pagesize, out totalrecord);
        }
        /// <summary>
        /// 获取一条项目信息
        /// </summary>
        /// <param name="pId">项目ID</param>
        /// <returns></returns>
        public Model.SW_PROJECT_INFO get_proInfo(decimal pId)
        {
            return dal.get_proInfo(pId);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

