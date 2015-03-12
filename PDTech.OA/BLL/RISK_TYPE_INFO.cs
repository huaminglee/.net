
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 风险类型定义表
	/// </summary>
	public partial class RISK_TYPE_INFO
	{
		private readonly PDTech.OA.DAL.RISK_TYPE_INFO dal=new PDTech.OA.DAL.RISK_TYPE_INFO();
		public RISK_TYPE_INFO()
		{}
		#region  BasicMethod

		/// <summary>
        /// 获取
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.RISK_TYPE_INFO> get_risktypeList(Model.RISK_TYPE_INFO where)
        {
            return dal.get_risktypeList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

