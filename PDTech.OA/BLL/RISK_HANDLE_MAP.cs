using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;
namespace PDTech.OA.BLL
{
	/// <summary>
	/// 风险处置单映射表
	/// </summary>
	public partial class RISK_HANDLE_MAP
	{
		private readonly PDTech.OA.DAL.RISK_HANDLE_MAP dal=new PDTech.OA.DAL.RISK_HANDLE_MAP();
		public RISK_HANDLE_MAP()
		{}
		#region  BasicMethod
        /// <summary>
        /// 获取Map相关信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.RISK_HANDLE_MAP get_mapInfo(Model.RISK_HANDLE_MAP where)
        {
            return dal.get_mapInfo(where);
        }
		
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

