using System;
namespace PDTech.OA.Model
{
    /// <summary>
    /// USER_INFO:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class USER_INFO
    {
        public USER_INFO()
        { }
        #region Model
        private decimal? _user_id;
        private string _login_name;
        private string _full_name;
        private string _login_pwd;
        private string _phone;
        private string _mobile;
        private decimal? _department_id;
        private decimal? _attribute_log;
        private decimal? _sort_number;
        private string _is_disable;
        private string _department_name;
        private string _duty_info;
        private string _public_name;
        private string _e_maile;
        private string _remark;
        /// <summary>
        /// USER_ID_SEQ.NEXTVAL
        /// </summary>
        public decimal? USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LOGIN_NAME
        {
            set { _login_name = value; }
            get { return _login_name; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FULL_NAME
        {
            set { _full_name = value; }
            get { return _full_name; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string LOGIN_PWD
        {
            set { _login_pwd = value; }
            get { return _login_pwd; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string PHONE
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string MOBILE
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 部门id
        /// </summary>
        public decimal? DEPARTMENT_ID
        {
            set { _department_id = value; }
            get { return _department_id; }
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
        /// 部门中排序顺序
        /// </summary>
        public decimal? SORT_NUMBER
        {
            set { _sort_number = value; }
            get { return _sort_number; }
        }
        /// <summary>
        /// 是否停用 1表示未停用
        /// </summary>
        public string IS_DISABLE
        {
            set { _is_disable = value; }
            get { return _is_disable; }
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
        /// 职务
        /// </summary>
        public string DUTY_INFO
        {
            set { _duty_info = value; }
            get { return _duty_info; }
        }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string PUBLIC_NAME
        {
            set { _public_name = value; }
            get { return _public_name; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string E_MAILE
        {
            set { _e_maile = value; }
            get { return _e_maile; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 是否在线  1 在线 0未在线
        /// </summary>
        public decimal? IS_ONLINE
        {
            get;
            set;
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LAST_DATE
        {
            get;
            set;
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LAST_IP
        {
            get;
            set;
        }

        /// <summary>
        /// 部门排序ID
        /// </summary>
        public decimal? SORT_NUM
        {
            get;
            set;
        }

        #endregion Model

        #region 自定义 成员

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

        /// <summary>
        /// 分管部门列表
        /// </summary>
        public string OwnerDeptNames
        {
            get;
            set;
        }
        #endregion
    }
}