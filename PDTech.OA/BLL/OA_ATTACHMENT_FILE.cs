using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 附件文件表
	/// </summary>
	public partial class OA_ATTACHMENT_FILE
	{
		private readonly PDTech.OA.DAL.OA_ATTACHMENT_FILE dal=new PDTech.OA.DAL.OA_ATTACHMENT_FILE();
		public OA_ATTACHMENT_FILE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(PDTech.OA.Model.OA_ATTACHMENT_FILE model, string HostName, string Ip, decimal operId, out string ar_ID)
		{
            return dal.Add(model, HostName, Ip, operId,out ar_ID);
		}

		

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ATTACHMENT_FILE_ID)
		{
			
			return dal.Delete(ATTACHMENT_FILE_ID);
		}
		

        /// <summary>
        /// 获取附件信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ATTACHMENT_FILE> get_InfoList(Model.OA_ATTACHMENT_FILE where)
        {
            return dal.get_InfoList(where);
        }
         /// <summary>
        /// 修改办理中新增的附件所属公文或者类型
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="arId"></param>
        /// <returns></returns>
        public bool UpdatePID(string Ids, decimal pId, string type, string steptype)
        {
            return dal.UpdatePID(Ids, pId, type, steptype);
        }
        /// <summary>
        /// 获取附件信息---未分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.OA_ATTACHMENT_FILE> get_InfoList(int limit,string where)
        {
            return dal.get_InfoList(limit,where);
        }

        /// <summary>
        /// 更新OCR状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public bool UpdateOCRInfo(Model.OA_ATTACHMENT_FILE update)
        {
            return dal.UpdateOCRInfo(update);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

