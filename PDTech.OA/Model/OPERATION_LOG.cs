/**  版本信息模板在安装目录下，可自行修改。
* OPERATION_LOG.cs
*
* 功 能： N/A
* 类 名： OPERATION_LOG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-27 14:30:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace PDTech.OA.Model
{
	/// <summary>
	/// OPERATION_LOG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OPERATION_LOG
	{
		public OPERATION_LOG()
		{}
		#region Model
		private decimal _log_id;
		private decimal? _operator_user;
		private string _operation_type;
		private DateTime _operation_time;
		private string _host_ip;
		private string _host_name;
		private string _operation_desc;
		private string _operation_data;
		private decimal _entity_type;
		private decimal? _entity_id;
		/// <summary>
		/// 默认值OPERATION_LOG_ID_SEQ.NEXTVAL
		/// </summary>
		public decimal LOG_ID
		{
			set{ _log_id=value;}
			get{return _log_id;}
		}
		/// <summary>
		/// 操作人ID
		/// </summary>
		public decimal? OPERATOR_USER
		{
			set{ _operator_user=value;}
			get{return _operator_user;}
		}
		/// <summary>
		/// 操作类型编码
		/// </summary>
		public string OPERATION_TYPE
		{
			set{ _operation_type=value;}
			get{return _operation_type;}
		}
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OPERATION_TIME
		{
			set{ _operation_time=value;}
			get{return _operation_time;}
		}
		/// <summary>
		/// 操作客户端IP
		/// </summary>
		public string HOST_IP
		{
			set{ _host_ip=value;}
			get{return _host_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HOST_NAME
		{
			set{ _host_name=value;}
			get{return _host_name;}
		}
		/// <summary>
		/// 操作描述
		/// </summary>
		public string OPERATION_DESC
		{
			set{ _operation_desc=value;}
			get{return _operation_desc;}
		}
		/// <summary>
		/// 操作数据详情
		/// </summary>
		public string OPERATION_DATA
		{
			set{ _operation_data=value;}
			get{return _operation_data;}
		}
		/// <summary>
		/// 记录日志类型1:用户 2:部门 3:角色 4:公文......
		/// </summary>
		public decimal ENTITY_TYPE
		{
			set{ _entity_type=value;}
			get{return _entity_type;}
		}
		/// <summary>
		/// 被操作对象的ID(如user_id,department_id,archive_id......)
		/// </summary>
		public decimal? ENTITY_ID
		{
			set{ _entity_id=value;}
			get{return _entity_id;}
		}
		#endregion Model

	}
}

