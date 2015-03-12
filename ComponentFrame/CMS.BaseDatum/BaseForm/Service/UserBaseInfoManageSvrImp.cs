#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/1/30 15:45:29 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
      <!--系统用户基础信息服务-->
      <component id="UserBaseInfoManageSvr" type="PengeSoft.CMS.BaseDatum.UserBaseInfoManageSvr, PengeSoft.CMS.BaseDatum" service="PengeSoft.CMS.BaseDatum.IUserBaseInfoManageSvr, PengeSoft.CMS.BaseDatum" lifestyle="Singleton">
        <parameters>
        </parameters>
      </component>
*/
using System;
using System.Collections;
using System.Text;
using Castle.Windsor;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Common.Exceptions;
using PengeSoft.Auther.RightCheck;
using PengeSoft.Service;
using PengeSoft.Auther;
using PengeSoft.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PengeSoft.WorkFlow;
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// UserBaseInfoManageSvr实现。    
    /// </summary>
    [PublishName("UserBaseInfoManage")]
    public class UserBaseInfoManageSvr : PengeSoft.Service.Auther.UserAutherImp, IUserBaseInfoManageSvr
    {
        private AutherUserManager userMan;
        private AutherActionManager autheraction;
        private AutherGroupManager authergroup;
        private AutherDeptManager autherdept;
        private IWindsorContainer _container;
        private IRightCheck _rightcheck;
        private PengeSoft.Auther.IRightCheck auther;
        #region 服务描述
        public UserBaseInfoManageSvr()
        {
            _container = ComponentManager.GetInstance();
            auther = _container["PsAuther.DefaultRightCheck"] as PengeSoft.Auther.IRightCheck;
            _rightcheck = auther;
            userMan = new AutherUserManager(auther);
            autheraction = new AutherActionManager(auther);
            authergroup = new AutherGroupManager(auther);
            autherdept = new AutherDeptManager(auther);
        }

        public override void FormActionList(AppActionList Acts)
        {
            base.FormActionList(Acts);

            // 添加需发布的功能信息
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "";
        }

        #endregion

        #region IUserBaseInfoManageSvr 函数

        /// <summary>
        /// 添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="LoginID">登录名</param>
        /// <param name="Password">密码</param>
        /// <param name="FullName">姓名()</param>
        /// <param name="Remark">备注()</param>
        [PublishMethod]
        public int AddUser(string uTag, string LoginID, string Password, string FullName, string Remark)
        {
            int SID = 0;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                //AutherCheckResult.CheckResult(userMan.Add(LoginID, Password, FullName, Remark, out SID));
                SID = userMan.Add(LoginID, Password, FullName, Remark, out SID);
            }
            return SID;
        }
        /// <summary>
        /// 获取用户基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option"></param>
        /// <param name="sid">登录名</param>
        [PublishMethod]
        public UserRec GetUserInfoBySid(string uTag, int Option, int sid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string loginid;
                AutherCheckResult.CheckResult(userMan.GetLoginID(sid, out loginid));

                UserRec result;
                AutherCheckResult.CheckResult(userMan.GetDetail(loginid, out result));
                return result;
            }
            return null;
        }

        /// <summary>
        /// 获取用户基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option"></param>
        /// <param name="loginid">登录名</param>
        [PublishMethod]
        public UserRec GetUserInfo(string uTag, int Option, string loginid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserRec result;
                AutherCheckResult.CheckResult(userMan.GetDetail(loginid, out result));
                return result;
            }
            return null;
        }


        /// <summary>
        /// 删除单个人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">登录id</param>
        [PublishMethod]
        public int DelUser(string uTag, string loginid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                AutherCheckResult.CheckResult(userMan.Remove(loginid));
                return 1;
            }
            else return 0;
        }
        /// <summary>
        /// 批量删除人员
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginIdList">登录id</param>
        [PublishMethod]
        public void DelUserList(string uTag, string loginIdList)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string[] dels = loginIdList.Split(new char[] { ',' });
                foreach (var loginid in dels)
                {
                    //循环删除用户
                    userMan.Remove(loginid);
                }
            }
        }
        /// <summary>
        /// 设置用户密码  
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginIdList">登录id列表</param>
        /// <param name="newpass">新密码</param>
        [PublishMethod]
        public int SetUserPass(string uTag, string loginIdList, string newpass)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserRec rec;
                string xml;
                object KeyID;
                string[] dels = loginIdList.Split(new char[] { ',' });
                foreach (var loginid in dels)
                {
                    rec = new UserRec();
                    AutherCheckResult.CheckResult(userMan.GetDetail(loginid, out xml));
                    rec.XMLText = xml;
                    rec.Password = newpass;
                    AutherCheckResult.CheckResult(userMan.Update(rec, out KeyID));
                }
                return 1;
            }
            else return 0;
        }

        /// <summary>
        /// 修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">登录id</param>
        /// <param name="Userinfo">人员信息</param>
        /// 注意：用户对象中的UStatus传入的值只能是0（假）和1（真）
        [PublishMethod]
        public int UpdateUserInfo(string uTag, string loginid, BaseUserInfo Userinfo)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserRec rec = new UserRec();
                string xml;
                AutherCheckResult.CheckResult(userMan.GetDetail(loginid, out xml));
                rec.XMLText = xml;
                rec.Set_UStatusSet(UserRec.UST_DISACCOUNT, Userinfo.IsLocked);
                rec.FullName = Userinfo.FullName;
                rec.Detail = Userinfo.Detail;
                rec.Unit = Userinfo.Unit;
                rec.Addr = Userinfo.Addr;
                rec.Dept = Userinfo.Dept;
                rec.Job = Userinfo.Job;
                rec.Chief = Userinfo.Chief;
                rec.Contact = Userinfo.Contact;
                rec.Tel1 = Userinfo.Tel;
                rec.Mob1 = Userinfo.Mob;
                rec.IDCard = Userinfo.IDCard;
                rec.IMCode = Userinfo.IMCode;
                rec.Fax = Userinfo.Fax;
                rec.Zip = Userinfo.Zip;
                rec.EMail = Userinfo.EMail;
                rec.WebURL = Userinfo.WebUrl;
                rec.Memo = Userinfo.Memo;

                object KeyID;
                AutherCheckResult.CheckResult(userMan.Update(rec, out KeyID));
                return 1;
            }
            else return 0;
        }
        /// <summary>
        /// 查询用户数量   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="strcondition">综合查询条件()</param>
        /// <param name="level">结果选项</param>
        /// <param name="tag">标识位一般传0</param>
        [PublishMethod]
        public int QueryUserCount(string uTag, string strcondition, int level, int tag)
        {

            Users userList = GetUserList(uTag, strcondition, 0, -1, level, tag);

            if (userList != null)
            {
                return userList.Count;
            }
            return 0;
        }

        /// <summary>
        /// 查询人员列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="strcondition">综合查询条件()</param>
        /// <param name="start">起始位置</param>
        /// <param name="count">数量</param>
        /// <param name="level">结果选项</param>
        /// <param name="tag">标识位一般传0</param>
        [PublishMethod]
        public Users GetUserList(string uTag, string strcondition, int start, int count, int level, int tag)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                Users result = new Users();
                string strresult;
                if (!string.IsNullOrEmpty(strcondition))
                {
                    AutherCheckResult.CheckResult(userMan.GetUserList(level, tag, 0, -1, out strresult));
                    result.XMLText = strresult;
                    IEnumerable<UserRec> query = from UserRec ci in result
                                                 where (ci.FullName != null && ci.FullName.Contains(strcondition)) || (ci.Unit != null && ci.Unit.Contains(strcondition)) || (ci.NickName != null && ci.NickName.Contains(strcondition))
                                                 select ci;
                    if (query.Any())
                    {
                        Users newresult = new Users();
                        int i = 0;
                        foreach (UserRec user in query)
                        {
                            if ((i >= start && i < start + count) || count == -1)
                            {
                                newresult.Add(user);
                            }
                            i++;
                        }
                        return newresult;
                    }
                }
                else
                {
                    AutherCheckResult.CheckResult(userMan.GetUserList(level, tag, start, count, out strresult));
                    result.XMLText = strresult;
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加部门   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ParentID">父部门ID</param>
        /// <param name="depInfo">部门信息</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public int AddDept(string uTag, string ParentID, BaseDeptInfo depInfo, int Option)
        {
            int SID = 0;
            int result = 0;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                result = autherdept.Add(ParentID, depInfo.LoginID, depInfo.Detail, Option, out SID);
            }
            return result == 0 ? SID : result;
        }

        /// <summary>
        /// 修改部门信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptsid">部门sid</param>
        /// <param name="depInfo">部门信息</param>
        /// <param name="Option">修改选项</param>
        [PublishMethod]
        public int UpdateDeptInfo(string uTag, BaseDeptInfo depInfo, int Option)
        {
            int result = 1;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                int sid = 0;
                //检查修改的部门名称是有存在
                autherdept.GetSID(depInfo.LoginID, out sid);
                if (sid != 0)
                {
                    //已存在，则返回已存在
                    result = AutherCheckResult.OP_DataExists;
                }
                else
                {
                    //不存在才继续修改
                    UserGroupRec rec;
                    string loginid;
                    AutherCheckResult.CheckResult(autherdept.GetLoginID(depInfo.SID, out loginid));
                    if (!string.IsNullOrEmpty(loginid))
                    {
                        AutherCheckResult.CheckResult(autherdept.GetDetail(loginid, out rec));
                        rec.LoginID = depInfo.LoginID;
                        rec.FullName = depInfo.FullName;
                        rec.Detail = depInfo.Detail;
                        object keyid;
                        result = autherdept.Update(rec, out keyid);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 删除部门   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="DeptID">部门id</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public int DelDept(string uTag, string deptuniqid, int Option)
        {
            int result = 1;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                result = autherdept.Remove(deptuniqid);
            }
            return result;
        }
        /// <summary>
        /// 获取部门详细信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项option 选项PengeSoft.Service.DeptManConst： GDOP_IncludeChilds 取下一级组信息 GDOP_IncludeAllChilds
        //     递归取出所有子组 GDOP_IncludeSys 取出系统组（仅对用户组有效）</param>
        /// <param name="deptid">部门id</param>
        [PublishMethod]
        public UserGroupRec GetDeptInfo(string uTag, int Option, string deptuniqid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec rec;
                AutherCheckResult.CheckResult(autherdept.GetDetail(deptuniqid, out rec));
                return rec;
            }
            return null;
        }
        /// <summary>
        /// 获取部门列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="parentnode">父节点</param>
        [PublishMethod]
        public BaseDeptInfoList GetDeptList(string uTag, string parentnode)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                BaseDeptInfoList result = new BaseDeptInfoList();
                UserGroups yresult;
                AutherCheckResult.CheckResult(autherdept.GetListNode(parentnode, 0, -1, out yresult));

                if (yresult.Count > 0)
                {
                    int befornode = 0;
                    int befordeep = 0;
                    int parentid = 0;
                    Dictionary<int, int> objdeepid = new Dictionary<int, int>();
                    objdeepid.Add(1, 0);
                    foreach (UserGroupRec act in yresult)
                    {
                        BaseDeptInfo addrec = new BaseDeptInfo();
                        addrec.Detail = act.Detail;
                        addrec.Deep = act.deep;
                        addrec.LoginID = act.LoginID;
                        addrec.SID = act.SID;
                        if (act.deep == 1)
                        {
                            befordeep = 1;
                            befornode = act.SID;
                            parentid = 0;
                        }
                        else
                        {

                            if (befordeep < act.deep)
                            {
                                parentid = befornode;
                                befornode = act.SID;
                                befordeep = act.deep;
                                if (objdeepid.ContainsKey(act.deep))
                                {
                                    objdeepid[act.deep] = parentid;
                                }
                                else
                                {
                                    objdeepid.Add(act.deep, parentid);
                                }

                            }
                            else if (befordeep == act.deep)
                            {
                                befornode = act.SID;
                            }

                            else if (befordeep > act.deep)
                            {
                                parentid = objdeepid[act.deep];
                                befordeep = act.deep;
                                befornode = act.SID;
                            }
                        }
                        addrec.ParentID = parentid;
                        result.Add(addrec);
                    }
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// 获取部门成员列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptId">部门标识</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public Users GetDeptUsers(string uTag, string deptId, int Option)
        {
            UserGroupRec usergroups = GetDeptInfo(uTag, Option, deptId);
            int[] userArray = usergroups.UserList;
            Users users = new Users();
            UserRec userRec;
            foreach (var uId in userArray)
            {
                userRec = GetUserInfoBySid(uTag, Option, uId);
                users.Add(userRec);
            }
            return users;
        }
        /// <summary>
        /// 部门移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptid">部门id</param>
        /// <param name="UserIDs">人员ids(传sid以,分隔)</param>
        [PublishMethod]
        public int DeptRemoveUser(string uTag, string deptuniqid, string UserIDs)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec dept;
                AutherCheckResult.CheckResult(autherdept.GetDetail(deptuniqid, out dept));
                if (dept.UserList != null)
                {
                    int[] intArray = Array.ConvertAll<string, int>(UserIDs.Split(','), delegate(string s) { return int.Parse(s); });
                    int[] newusers = RemoveIntFromStrs(dept.UserList, intArray);
                    dept.UserList = newusers;
                    object objid;
                    AutherCheckResult.CheckResult(autherdept.Update(dept, out objid));
                    return 1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 从数组ch1中移除数组ch2中的内容
        /// </summary>
        /// <param name="FatherStr"></param>
        /// <param name="ChildStr"></param>
        /// <returns></returns>
        private string RemoveStrFromStrs(string[] ch1, string[] ch2)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, int> d1 = new Dictionary<string, int>();
            foreach (string item in ch1)
                d1[item] = 0;
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            foreach (string item in ch2)
                d2[item] = 0;
            List<string> list1 = new List<string>();
            foreach (string item in d1.Keys)
                if (!d2.ContainsKey(item))
                    list1.Add(item);
            foreach (string str in list1)
            {
                sb.Append(str + ',');
            }
            string reslut = sb.ToString();
            if (reslut.Length > 0)
            {
                reslut = reslut.Substring(0, reslut.Length - 1);
            }
            return reslut;

        }
        /// <summary>
        /// 像数组ch1中添加ch2
        /// </summary>
        /// <param name="FatherStr"></param>
        /// <param name="ChildStr"></param>
        /// <returns></returns>
        private string AddStrToStrs(string[] ch1, string[] ch2)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, int> d1 = new Dictionary<string, int>();
            foreach (string item in ch1)
                d1[item] = 0;
            Dictionary<string, int> d2 = new Dictionary<string, int>();
            foreach (string item in ch2)
                d2[item] = 0;
            List<string> list1 = new List<string>();
            foreach (string item in d1.Keys)
                list1.Add(item);
            foreach (string item in d2.Keys)
                if (!d1.ContainsKey(item))
                    list1.Add(item);
            foreach (string str in list1)
            {
                sb.Append(str + ',');
            }
            string reslut = sb.ToString();
            if (reslut.Length > 0)
            {
                reslut = reslut.Substring(0, reslut.Length - 1);
            }
            return reslut;

        }
        /// <summary>
        /// 从数组ch1中移除数组ch2中的内容
        /// </summary>
        /// <param name="FatherStr"></param>
        /// <param name="ChildStr"></param>
        /// <returns></returns>
        private int[] RemoveIntFromStrs(int[] ch1, int[] ch2)
        {
            Dictionary<int, int> d1 = new Dictionary<int, int>();
            foreach (int item in ch1)
                d1[item] = 0;
            Dictionary<int, int> d2 = new Dictionary<int, int>();
            foreach (int item in ch2)
                d2[item] = 0;
            List<int> list1 = new List<int>();
            foreach (int item in d1.Keys)
                if (!d2.ContainsKey(item))
                    list1.Add(item);
            int[] result = list1.ToArray();
            return result;

        }
        /// <summary>
        /// 像数组ch1中添加ch2
        /// </summary>
        /// <param name="FatherStr"></param>
        /// <param name="ChildStr"></param>
        /// <returns></returns>
        private int[] AddIntToStrs(int[] ch1, int[] ch2)
        {

            Dictionary<int, int> d1 = new Dictionary<int, int>();
            foreach (int item in ch1)
                d1[item] = 0;
            Dictionary<int, int> d2 = new Dictionary<int, int>();
            foreach (int item in ch2)
                d2[item] = 0;
            List<int> list1 = new List<int>();
            foreach (int item in d1.Keys)
                list1.Add(item);
            foreach (int item in d2.Keys)
                if (!d1.ContainsKey(item))
                    list1.Add(item);

            int[] result = list1.ToArray();
            return result;

        }

        /// <summary>
        /// 部门添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptid">部门id</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        public int DeptAddUser(string uTag, string deptuniqid, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec dept;
                AutherCheckResult.CheckResult(autherdept.GetDetail(deptuniqid, out dept));
                int[] intArray = Array.ConvertAll<string, int>(userids.Split(','), delegate(string s) { return int.Parse(s); });
                if (dept.UserList == null)
                {
                    dept.UserList = intArray;
                }
                else
                {
                    dept.UserList = AddIntToStrs(dept.UserList, intArray);

                }
                object objid;
                AutherCheckResult.CheckResult(autherdept.Update(dept, out objid));
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 获取角色详细信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public UserGroupRec GetRoleDetail(string uTag, string rolename, int Option)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec result = new UserGroupRec();
                AutherCheckResult.CheckResult(authergroup.GetDetail(rolename, out result));
                return result;
            }
            return null;
        }

        /// <summary>
        /// 删除角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public void DelRole(string uTag, string rolenames, int Option)
        {

            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string[] dels = rolenames.Split(new char[] { ',' });
                foreach (var rId in dels)
                {
                    authergroup.Remove(rId);
                }
            }
        }

        /// <summary>
        /// 修改角色描述   
        /// </summary>
        /// <param name="uTag">标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="detail">描述</param>
        [PublishMethod]
        public int UpdateRoleInfo(string uTag, string rolename, string detail)
        {

            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserGroupRec rec = new UserGroupRec();
                authergroup.GetDetail(rolename, out rec);

                if (rec.SID != 0)
                {
                    rec.Detail = detail;
                    object kid = 0;
                    return authergroup.Update(rec, out kid);
                }
            }
            return -1;
        }

        /// <summary>
        /// 添加角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="Detail">描述</param>
        [PublishMethod]
        public int AddRole(string uTag, string rolename, string Detail, int Option)
        {
            int sid = -1;

            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                sid = authergroup.Add("", rolename, Detail, Option, out sid);
            }
            return sid;
        }
        /// <summary>
        /// 查询角色数量    
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="condition">查询参数</param>
        /// <param name="option">结果选项</param>
        [PublishMethod]
        public int QueryRoleCount(string uTag, string condition, int option)
        {
            UserGroups roleList = GetRoleList(uTag, condition, 0, -1, option);
            if (roleList != null)
            {
                return roleList.Count;
            }
            return 0;
        }

        /// <summary>
        /// 获取角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="condition">综合查询条件()</param>
        /// <param name="start">起始位置</param>
        /// <param name="count">数量</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public UserGroups GetRoleList(string uTag, string condition, int start, int count, int Option)
        {

            UserGroups result = new UserGroups();
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    AutherCheckResult.CheckResult(authergroup.GetList("", 0, -1, out result));

                    IEnumerable<UserGroupRec> query = from UserGroupRec ci in result
                                                      where (ci.LoginID != null && ci.LoginID.Contains(condition)) || (ci.Detail != null && ci.Detail.Contains(condition))
                                                      select ci;
                    if (query.Any())
                    {
                        UserGroups newresult = new UserGroups();
                        int i = 0;
                        foreach (UserGroupRec user in query)
                        {
                            if ((i >= start && i < start + count) || count == -1)
                            {
                                user.SID = user.SID | 0x40000000;
                                newresult.Add(user);
                            }
                            i++;
                        }
                        return newresult;
                    }
                }
                else
                {

                    AutherCheckResult.CheckResult(authergroup.GetList("", start, count, out result));
                    foreach (UserGroupRec user in result)
                    {
                        user.SID = user.SID | 0x40000000;
                    }
                    return result;
                }

            }
            return null;
        }

        /// <summary>
        /// 获取角色人员列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolenames">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public Users GetRoleUsers(string uTag, string rolenames, int Option)
        {

            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string strusers;
                AutherCheckResult.CheckResult(_rightcheck.GetGroupUsers(rolenames, AutherConst.GGUL_DETAIL, out strusers));

                Users result = new Users();
                result.XMLText = strusers;
                return result;
            }
            return null;
        }

        /// <summary>
        /// 查询指定人员角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="loginid"></param>
        public UserGroupDefs GetUserRoleByUserid(string uTag, int Option, string loginid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserGroupDefs result = new UserGroupDefs();
                int sid = 0;
                AutherCheckResult.CheckResult(userMan.GetSID(loginid, out sid));
                AutherCheckResult.CheckResult(authergroup.GetUserGroupDefs(sid, "", Option, out result));
                return result;
            }
            return null;
        }

        /// <summary>
        /// 角色添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        public void RoleAddUsers(string uTag, string rolename, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec rec = new UserGroupRec();
                AutherCheckResult.CheckResult(authergroup.GetDetail(rolename, out rec));
                int[] intArray = Array.ConvertAll<string, int>(userids.Split(','), delegate(string s) { return int.Parse(s); });
                if (rec.UserList != null)
                {
                    rec.UserList = AddIntToStrs(rec.UserList, intArray);
                }
                else
                {
                    rec.UserList = intArray;
                }
                object objid;
                AutherCheckResult.CheckResult(authergroup.Update(rec, out objid));
            }

        }

        /// <summary>
        /// 角色移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userIDs">移除人员ID(传sid以,分隔)</param>
        [PublishMethod]
        public void RoleRemoveUser(string uTag, string rolename, string userIDs)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec rec = new UserGroupRec();
                AutherCheckResult.CheckResult(authergroup.GetDetail(rolename, out rec));

                if (rec.UserList != null)
                {
                    int[] intArray = Array.ConvertAll<string, int>(userIDs.Split(','), delegate(string s) { return int.Parse(s); });
                    rec.UserList = RemoveIntFromStrs(rec.UserList, intArray);
                    object objid;
                    AutherCheckResult.CheckResult(authergroup.Update(rec, out objid));
                }
            }
        }

        /// <summary>
        /// 获取权限列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="level"> 取列表的级别，有以下方面: ACTL_DETAIL : 取详细信息 ACTL_LITTLE : 取少量信息 和下面两个可或上的选项(可或在一起)ACTL_GETBYNODE : 按 Tag 指定节点取 ACTL_INPARNODE : 包括 Tag 指定节点本身</param>
        /// <param name="Tag"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public BaseRightsInfoList GetRighstList(string uTag, int level, int Tag, int start, int len, int Option)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                BaseRightsInfoList result = new BaseRightsInfoList();
                string strresult = "";
                UserRightRecs yresult = new UserRightRecs();
                autheraction.GetActList(AutherConst.ACTL_LITTLE | AutherConst.ACTL_INPARNODE, Tag, start, len, out strresult);
                yresult.XMLText = strresult;
                if (yresult.Count > 0)
                {
                    int befornode = 0;
                    int befordeep = 0;
                    int parentid = 0;
                    Dictionary<int, int> objdeepid = new Dictionary<int, int>();
                    objdeepid.Add(1, 0);
                    foreach (UserRightRec act in yresult)
                    {
                        BaseRightsInfo addrec = new BaseRightsInfo();
                        addrec.Detail = act.ActName;
                        addrec.Deep = act.Deep;
                        addrec.ActID = act.ActID;
                        if (act.Deep == 1)
                        {
                            befordeep = 1;
                            befornode = act.ActID;
                            parentid = 0;
                        }
                        else
                        {

                            if (befordeep < act.Deep)
                            {
                                parentid = befornode;
                                befornode = act.ActID;
                                befordeep = act.Deep;
                                if (objdeepid.ContainsKey(act.Deep))
                                {
                                    objdeepid[act.Deep] = parentid;
                                }
                                else
                                {
                                    objdeepid.Add(act.Deep, parentid);
                                }

                            }
                            else if (befordeep == act.Deep)
                            {
                                befornode = act.ActID;
                            }

                            else if (befordeep > act.Deep)
                            {
                                parentid = objdeepid[act.Deep];
                                befordeep = act.Deep;
                                befornode = act.ActID;
                            }
                        }
                        addrec.ParentID = parentid;

                        result.Add(addrec);
                    }
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 获取权限人员角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActID">权限ID</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public BaseUserAndRoleInfoList GetRightsUsers(string uTag, int ActID, int Option)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(ActID, out ans));
                BaseUserAndRoleInfoList result = new BaseUserAndRoleInfoList();
                if (!string.IsNullOrEmpty(ans))
                {
                    UserActionRec actresult = new UserActionRec();
                    actresult.XMLText = ans;
                    if (actresult.UserRights.Count > 0)
                    {
                        foreach (RightDefRec rec in actresult.UserRights)
                        {
                            BaseUserAndRoleInfo outrec = new BaseUserAndRoleInfo();

                            if ((rec.SID & 0x40000000) != 0)
                            {
                                int groupid = rec.SID & ~0x40000000;
                                UserGroupRec usergroup;
                                string loginid;
                                authergroup.GetLoginID(groupid, out loginid);
                                authergroup.GetDetail(loginid, out usergroup);

                                outrec.LoginID = loginid;
                                outrec.SID = rec.SID;
                                outrec.FullName = usergroup.Detail;
                            }
                            else
                            {
                                outrec.SID = rec.SID;
                                string fullname;
                                UserRec userrec;
                                userMan.GetLoginID(rec.SID, out fullname);
                                userMan.GetDetail(fullname, out userrec);
                                outrec.LoginID = fullname;
                                outrec.FullName = userrec.FullName;


                            }
                            result.Add(outrec);
                        }
                        return result;
                    }
                }

            }
            return null;

        }

        /// <summary>
        /// 权限移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="userids">用户列表</param>
        [PublishMethod]
        public void RightsRemoveUsers(string uTag, string ActName, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                int actId;
                UserActionRec rec = new UserActionRec();
                AutherCheckResult.CheckResult(autheraction.GetActIdByName(ActName, out actId));
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(actId, out ans));
                if (!string.IsNullOrEmpty(ans))
                {
                    rec.XMLText = ans;
                }
                int sid = 0;
                string[] users = userids.Split(',');
                foreach (string user in users)
                {
                    AutherCheckResult.CheckResult(userMan.GetSID(user, out sid));

                    foreach (RightDefRec def in rec.UserRights)
                    {
                        if (def.Mask == AutherConst.RIGHT_READWRITE && def.SID == sid)
                        {
                            rec.UserRights.Remove(def);
                        }
                    }


                }
                object keyId;
                AutherCheckResult.CheckResult(autheraction.Update(rec, out keyId));

            }
        }
        /// <summary>
        /// 权限移除角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="rolenames">角色列表以，分隔()</param>
        public void RightRemoveRoles(string uTag, string ActName, string rolenames)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                int actId;
                UserActionRec rec = new UserActionRec();
                AutherCheckResult.CheckResult(autheraction.GetActIdByName(ActName, out actId));
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(actId, out ans));
                if (!string.IsNullOrEmpty(ans))
                {
                    rec.XMLText = ans;
                }
                int sid = 0;
                string[] roles = rolenames.Split(',');
                foreach (string role in roles)
                {
                    AutherCheckResult.CheckResult(authergroup.GetSID(role, out sid));
                    foreach (RightDefRec def in rec.UserRights)
                    {
                        if (def.Mask == AutherConst.RIGHT_READWRITE && def.SID == sid)
                        {
                            rec.UserRights.Remove(def);
                        }
                    }

                }
                object keyId;
                AutherCheckResult.CheckResult(autheraction.Update(rec, out keyId));

            }
        }


        /// <summary>
        /// 权限添加人员  
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="userids">用户列表以，分隔</param>
        [PublishMethod]
        public void RightsAddUsers(string uTag, string ActName, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserActionRec act = GetRightDetail(uTag, ActName, 0);
                string[] users = userids.Split(',');
                foreach (string user in users)
                {
                    int sid;
                    AutherCheckResult.CheckResult(userMan.GetSID(user, out sid));
                    RightDefRec def = new RightDefRec();
                    def.Mask = AutherConst.RIGHT_READWRITE;
                    def.SID = sid;
                    act.UserRights.Add(def);

                }
                object keyId;
                AutherCheckResult.CheckResult(autheraction.Update(act, out keyId));

            }

        }
        /// <summary>
        /// 权限添加角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="roleids">角色列表以，分隔()</param>
        public void RightsAddRoles(string uTag, string ActName, string roleids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserActionRec act = GetRightDetail(uTag, ActName, 0);
                string[] roles = roleids.Split(',');
                foreach (string role in roles)
                {
                    int sid;
                    AutherCheckResult.CheckResult(authergroup.GetSID(role, out sid));
                    RightDefRec def = new RightDefRec();
                    def.Mask = AutherConst.RIGHT_READWRITE;
                    def.SID = sid;
                    act.UserRights.Add(def);
                }
                object keyId;
                AutherCheckResult.CheckResult(autheraction.Update(act, out keyId));

            }
        }

        /// <summary>
        /// 删除权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public int DelRights(string uTag, string ActName, int Option)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                DeleteRight(ActName);
                return 1;
            }
            return 0;
        }
        private void DeleteRight(string NodeName)
        {
            string strlistnode;
            autheraction.GetListNode(NodeName, 0, -1, out strlistnode);
            UserRightRecs listnode = new UserRightRecs();
            listnode.XMLText = strlistnode;
            if (listnode.Count > 0)
            {
                Stack<string> nodes = new Stack<string>();
                foreach (UserRightRec childnode in listnode)
                {
                    nodes.Push(childnode.ActName);

                }
                for (int i = 0; i < nodes.Count; i++)
                {
                    int actid = 0;
                    AutherCheckResult.CheckResult(autheraction.GetActIdByName(nodes.Pop(), out actid));
                    AutherCheckResult.CheckResult(autheraction.RemoveAct(actid));
                }
            }
            int actid2 = 0;
            AutherCheckResult.CheckResult(autheraction.GetActIdByName(NodeName, out actid2));
            AutherCheckResult.CheckResult(autheraction.RemoveAct(actid2));
        }

        /// <summary>
        /// 新建权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="PosAct">添加位置的权限标识，找不到则为根节点</param>
        /// <param name="ActID">给定权限标识，0则自动选取</param>
        /// <param name="Option">添加选项 Option选项: DTAO_AddSub : 添加子项目(不指定则添加或插入同级项目，会跳过已有子项目) DTAO_Insert :在PosAct后插入项目</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="Detail">描述()</param>
        [PublishMethod]
        public int AddRights(string uTag, int PosAct, int ActID, int Option, string ActName, string Detail)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                int aid;
                int addresult = autheraction.Add(PosAct, ActID, Option, ActName, Detail, out aid);
                if (addresult!=0)
                {
                    return addresult;
                }                
                autheraction.GetActIdByName(ActName, out aid);
                return aid;
            }
            return 0;
        }

        /// <summary>
        /// 查看权限基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actName">权限名()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public UserActionRec GetRightDetail(string uTag, string actName, int Option)
        {
            UserActionRec result = null;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                int actId;
                AutherCheckResult.CheckResult(autheraction.GetActIdByName(actName, out actId));
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(actId, out ans));

                if (!string.IsNullOrEmpty(ans))
                {
                    result = new UserActionRec();
                    result.XMLText = ans;
                }
            }
            return result;
        }
        /// <summary>
        /// 查看权限基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限名ID</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public UserActionRec GetRightDetail(string uTag, int actId, int Option)
        {
            UserActionRec result = null;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(actId, out ans));

                if (!string.IsNullOrEmpty(ans))
                {
                    result = new UserActionRec();
                    result.XMLText = ans;
                }
            }
            return result;
        }

        /// <summary>
        /// 修改权限信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限id</param>
        /// <param name="Actinfo">权限信息</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        public int UpdateRightsInfo(string uTag, int actid, BaseRightsInfo Actinfo, int Option)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserActionRec result = null;
                string ans;
                AutherCheckResult.CheckResult(autheraction.GetDetail(actid, out ans));
                if (!string.IsNullOrEmpty(ans))
                {
                    result = new UserActionRec();
                    result.XMLText = ans;
                }
                object objid;
                result.AddAttrib = Actinfo.AddAttrib;
                result.ActName = Actinfo.Detail;

                int actId;
                autheraction.GetActIdByName(Actinfo.Detail, out actId);
                if (actId !=0 && actId != actid)
                {
                    return -47;
                }
                AutherCheckResult.CheckResult(autheraction.Update(result, out objid));
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 获取权限子权限列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Node">()</param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        [PublishMethod]
        public UserRightRecs GetRightListNode(string uTag, string Node, int start, int len)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                string strresult = "";
                autheraction.GetListNode(Node, start, len, out strresult);
                UserRightRecs result = new UserRightRecs();
                result.XMLText = strresult;
                return result;
            }
            return null;
        }

        /// <summary>
        /// 查询指定用户的权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="loginid"></param>
        [PublishMethod]
        public UserActs GetUserRightsListByUser(string uTag, int Option, string loginid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string strright = "";
                _rightcheck.GetUserRights(loginid, AutherConst.GURT_DETAIL, AutherConst.RIGHT_READWRITE, 1, out strright);
                UserActs result = new UserActs();
                result.XMLText = strright;
                return result;
            }
            return null;
        }
        /// <summary>
        /// 根据用户id查询用户列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="UserIds">用户id列表由，分隔</param>
        [PublishMethod]
        public Users GetUsersByIds(string uTag, int Option, string UserIds)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string[] userid = UserIds.Split(',');
                Users result = new Users();
                foreach (string id in userid)
                {
                    UserRec rec = new UserRec();
                    string loginid;
                    userMan.GetLoginID(Int32.Parse(id), out loginid);
                    int n = userMan.GetDetail(loginid, out rec);
                    result.Add(rec);
                }
                return result;
            }
            return null;
        }
        /// <summary>
        /// 取待办事项列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">人员登录id</param>       
        [PublishMethod]
        public DataList GetWorkWaitfor(string uTag, string loginid)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                IWorkTaskQuerySvr _workflow = _container[typeof(IWorkTaskQuerySvr)] as IWorkTaskQuerySvr;
                return _workflow.GetTaskList(loginid, 0, 0);
            }
            return null;
        }
        /// <summary>
        /// 部门修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptuniqid">部门id()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        public int UpdateDeptUsers(string uTag, string deptuniqid, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec dept;
                AutherCheckResult.CheckResult(autherdept.GetDetail(deptuniqid, out dept));
                if (!string.IsNullOrEmpty(userids))
                {
                    int[] intArray = Array.ConvertAll<string, int>(userids.Split(','), delegate(string s) { return int.Parse(s); });
                    dept.UserList = intArray;
                }
                else
                {
                    dept.UserList = null;
                }
                object objid;
                AutherCheckResult.CheckResult(autherdept.Update(dept, out objid));
                return 1;

            }
            return 0;
        }

        /// <summary>
        /// 角色修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        public int UpdateRolesUsers(string uTag, string rolename, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {

                UserGroupRec rec = new UserGroupRec();
                AutherCheckResult.CheckResult(authergroup.GetDetail(rolename, out rec));
                if (!string.IsNullOrEmpty(userids))
                {
                    int[] intArray = Array.ConvertAll<string, int>(userids.Split(','), delegate(string s) { return int.Parse(s); });
                    rec.UserList = intArray;
                }
                else
                {
                    rec.UserList = null;
                }
                object objid;
                AutherCheckResult.CheckResult(authergroup.Update(rec, out objid));
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 权限修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限id</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        public int UpdateRightUsers(string uTag, int actid, string userids)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                UserActionRec act = GetRightDetail(uTag, actid, 0);
                if (!string.IsNullOrEmpty(userids))
                {
                    int[] intArray = Array.ConvertAll<string, int>(userids.Split(','), delegate(string s) { return int.Parse(s); });
                    act.UserRights.Clear();
                    foreach (int sid in intArray)
                    {
                        RightDefRec def = new RightDefRec();
                        def.Mask = AutherConst.RIGHT_READWRITE;
                        def.SID = sid;
                        act.UserRights.Add(def);
                    }
                }
                else
                {
                    act.UserRights.Clear();
                }
                object keyId;
                AutherCheckResult.CheckResult(autheraction.Update(act, out keyId));
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 查询所有人员角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="strcondition">综合查询条件</param>
        [PublishMethod]
        public BaseUserAndRoleInfoList GetAllUserandRoleList(string uTag, string strcondition)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                BaseUserAndRoleInfoList result = new BaseUserAndRoleInfoList();
                Users userresult = new Users();
                UserGroups groupresult = new UserGroups();
                string strresult;
                AutherCheckResult.CheckResult(userMan.GetUserList(1, 0, 0, -1, out strresult));
                userresult.XMLText = strresult;
                AutherCheckResult.CheckResult(authergroup.GetList("", 0, -1, out groupresult));
                if (!string.IsNullOrEmpty(strcondition))
                {
                    IEnumerable<UserRec> query = from UserRec ci in userresult
                                                 where (ci.FullName != null && ci.FullName.Contains(strcondition)) || (ci.Unit != null && ci.Unit.Contains(strcondition)) || (ci.NickName != null && ci.NickName.Contains(strcondition))
                                                 select ci;
                    if (query.Any())
                    {
                        foreach (UserRec user in query)
                        {
                            BaseUserAndRoleInfo newresult = new BaseUserAndRoleInfo();
                            newresult.SID = user.SID;
                            newresult.FullName = user.FullName;
                            newresult.LoginID = user.NickName;
                            result.Add(newresult);
                        }
                    }
                    IEnumerable<UserGroupRec> gquery = from UserGroupRec ci in groupresult
                                                       where (ci.LoginID != null && ci.LoginID.Contains(strcondition)) || (ci.Detail != null && ci.Detail.Contains(strcondition
                                                       ))
                                                       select ci;
                    if (gquery.Any())
                    {
                        foreach (UserGroupRec user in gquery)
                        {
                            BaseUserAndRoleInfo newgresult = new BaseUserAndRoleInfo();
                            newgresult.SID = user.SID | 0x40000000;
                            newgresult.LoginID = user.LoginID;
                            newgresult.FullName = user.Detail;
                            result.Add(newgresult);
                        }
                    }
                }
                else
                {
                    foreach (UserRec user in userresult)
                    {
                        BaseUserAndRoleInfo newresult = new BaseUserAndRoleInfo();
                        newresult.SID = user.SID;
                        newresult.FullName = user.FullName;
                        newresult.LoginID = user.NickName;
                        result.Add(newresult);
                    }
                    foreach (UserGroupRec group in groupresult)
                    {
                        BaseUserAndRoleInfo newgresult = new BaseUserAndRoleInfo();
                        newgresult.SID = group.SID | 0x40000000; ;
                        newgresult.FullName = group.Detail;
                        newgresult.LoginID = group.LoginID;
                        result.Add(newgresult);
                    }
                }
                return result;
            }
            return null;
        }        
        #endregion
    }
}
