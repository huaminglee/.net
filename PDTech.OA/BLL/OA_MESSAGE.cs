using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// OA_MESSAGE
	/// </summary>
	public partial class OA_MESSAGE
	{
		private readonly PDTech.OA.DAL.OA_MESSAGE dal=new PDTech.OA.DAL.OA_MESSAGE();
		public OA_MESSAGE()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MESSAGE_ID)
		{
			return dal.Exists(MESSAGE_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(PDTech.OA.Model.OA_MESSAGE model, string fileIds, string setreceiverIds,int issendSms,string clientIp,string clientHost)
		{
			return dal.Add(model,fileIds,setreceiverIds,issendSms,clientIp,clientHost);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal MESSAGE_ID)
		{
			
			return dal.Delete(MESSAGE_ID);
		}
		
        /// <summary>
        /// 获取所有信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<PDTech.OA.Model.OA_MESSAGE> get_messageList(Model.OA_MESSAGE where)
        {
            return dal.get_messageList(where);
        }
        /// <summary>
        /// 获取单条公告信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.OA_MESSAGE get_messageInfo(Model.OA_MESSAGE where)
        {
            return dal.get_messageInfo(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

