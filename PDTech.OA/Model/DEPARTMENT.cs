using System;
using System.Runtime.Serialization;

namespace PDTech.OA.Model
{
    /// <summary>
    /// DEPARTMENT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DEPARTMENT
    {
        public DEPARTMENT()
        { }
        #region Model
        private decimal? _department_id;
        private string _department_name;
        private string _department_jc;
        private string _remark;
        private decimal? _department_level;
        private decimal? _parent_id;
        private string _parent_name;
        private decimal? _attribute_log;
        private decimal? _sort_num;
        private string _out_related_id;
        private string _is_disable;
        /// <summary>
        /// 默认DEPARTMENT_ID_SEQ.NEXTVAL
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            set { _department_id = value; }
            get { return _department_id; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPARTMENT_NAME
        {
            set { _department_name = value; }
            get { return _department_name; }
        }
        /// <summary>
        /// 部门简称
        /// </summary>
        public string DEPARTMENT_JC
        {
            set { _department_jc = value; }
            get { return _department_jc; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 部门层级
        /// </summary>
        public decimal? DEPARTMENT_LEVEL
        {
            set { _department_level = value; }
            get { return _department_level; }
        }
        /// <summary>
        /// 上级部门ID
        /// </summary>
        public decimal? PARENT_ID
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// 上级部门名称
        /// </summary>
        public string PARENT_NAME
        {
            set { _parent_name = value; }
            get { return _parent_name; }
        }
        /// <summary>
        /// 扩展属性logID
        /// </summary>
        public decimal? ATTRIBUTE_LOG
        {
            set { _attribute_log = value; }
            get { return _attribute_log; }
        }
        /// <summary>
        /// 排序id
        /// </summary>
        public decimal? SORT_NUM
        {
            set { _sort_num = value; }
            get { return _sort_num; }
        }
        /// <summary>
        /// 外来数据部门ID
        /// </summary>
        public string OUT_RELATED_ID
        {
            set { _out_related_id = value; }
            get { return _out_related_id; }
        }
        /// <summary>
        /// 是否停用 1表示未停用
        /// </summary>
        public string IS_DISABLE
        {
            set { _is_disable = value; }
            get { return _is_disable; }
        }
        #endregion Model
        /// <summary>
        /// 排序字段[格式如：User_ID ASC,User_Name DESC]
        /// </summary>
        public string SortFields
        {
            get;
            set;
        }
        /// <summary>
        /// 自定义查询字段[格式: UserID = '10001' AND UserName= 'Mr.Zore' AND ID NOT (SELECT ID FROM XX)]
        /// </summary>
        public string Append
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 部门列表，用于下拉框选择所在部门（Json对象）
    /// </summary>
    [DataContract]
    public partial class DEPARTMENT_NAME
    {
        /***部门ID***/
        [DataMember(Order = 0)]
        public string department_id { get; set; }

        /***部门名称***/
        [DataMember(Order = 1)]
        public string department_name { get; set; }
    }
}