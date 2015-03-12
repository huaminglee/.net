using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 资金来源基础信息表
	/// </summary>
	public partial class FUNDS_INFO
	{
		private readonly PDTech.OA.DAL.FUNDS_INFO dal=new PDTech.OA.DAL.FUNDS_INFO();
		public FUNDS_INFO()
		{}
		#region  BasicMethod
		 /// <summary>
        /// 获取资金来源数据列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public IList<Model.FUNDS_INFO> get_fundsList(Model.FUNDS_INFO where)
        {
            return dal.get_fundsList(where);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

