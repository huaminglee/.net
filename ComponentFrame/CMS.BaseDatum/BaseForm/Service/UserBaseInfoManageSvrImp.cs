#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/30 15:45:29 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
      <!--ϵͳ�û�������Ϣ����-->
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
    /// UserBaseInfoManageSvrʵ�֡�    
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
        #region ��������
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

            // ����跢���Ĺ�����Ϣ
        }

        public override void FormAttribsRec(PengeSoft.WorkZoneData.AppAttribBaseRec attr)
        {
            base.FormAttribsRec(attr);

            attr.Detail = "";
        }

        #endregion

        #region IUserBaseInfoManageSvr ����

        /// <summary>
        /// �����Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="LoginID">��¼��</param>
        /// <param name="Password">����</param>
        /// <param name="FullName">����()</param>
        /// <param name="Remark">��ע()</param>
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
        /// ��ȡ�û�������Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option"></param>
        /// <param name="sid">��¼��</param>
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
        /// ��ȡ�û�������Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option"></param>
        /// <param name="loginid">��¼��</param>
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
        /// ɾ��������Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��¼id</param>
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
        /// ����ɾ����Ա
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginIdList">��¼id</param>
        [PublishMethod]
        public void DelUserList(string uTag, string loginIdList)
        {
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                string[] dels = loginIdList.Split(new char[] { ',' });
                foreach (var loginid in dels)
                {
                    //ѭ��ɾ���û�
                    userMan.Remove(loginid);
                }
            }
        }
        /// <summary>
        /// �����û�����  
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginIdList">��¼id�б�</param>
        /// <param name="newpass">������</param>
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
        /// �޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��¼id</param>
        /// <param name="Userinfo">��Ա��Ϣ</param>
        /// ע�⣺�û������е�UStatus�����ֵֻ����0���٣���1���棩
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
        /// ��ѯ�û�����   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="strcondition">�ۺϲ�ѯ����()</param>
        /// <param name="level">���ѡ��</param>
        /// <param name="tag">��ʶλһ�㴫0</param>
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
        /// ��ѯ��Ա�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="strcondition">�ۺϲ�ѯ����()</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="count">����</param>
        /// <param name="level">���ѡ��</param>
        /// <param name="tag">��ʶλһ�㴫0</param>
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
        /// ��Ӳ���   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ParentID">������ID</param>
        /// <param name="depInfo">������Ϣ</param>
        /// <param name="Option">ѡ��</param>
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
        /// �޸Ĳ�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptsid">����sid</param>
        /// <param name="depInfo">������Ϣ</param>
        /// <param name="Option">�޸�ѡ��</param>
        [PublishMethod]
        public int UpdateDeptInfo(string uTag, BaseDeptInfo depInfo, int Option)
        {
            int result = 1;
            if (CheckRight(uTag, "") == AutherCheckResult.OP_SUCESS)
            {
                int sid = 0;
                //����޸ĵĲ����������д���
                autherdept.GetSID(depInfo.LoginID, out sid);
                if (sid != 0)
                {
                    //�Ѵ��ڣ��򷵻��Ѵ���
                    result = AutherCheckResult.OP_DataExists;
                }
                else
                {
                    //�����ڲż����޸�
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
        /// ɾ������   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="DeptID">����id</param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ȡ������ϸ��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��option ѡ��PengeSoft.Service.DeptManConst�� GDOP_IncludeChilds ȡ��һ������Ϣ GDOP_IncludeAllChilds
        //     �ݹ�ȡ���������� GDOP_IncludeSys ȡ��ϵͳ�飨�����û�����Ч��</param>
        /// <param name="deptid">����id</param>
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
        /// ��ȡ�����б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="parentnode">���ڵ�</param>
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
        /// ��ȡ���ų�Ա�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptId">���ű�ʶ</param>
        /// <param name="Option">ѡ��</param>
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
        /// �����Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptid">����id</param>
        /// <param name="UserIDs">��Աids(��sid��,�ָ�)</param>
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
        /// ������ch1���Ƴ�����ch2�е�����
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
        /// ������ch1�����ch2
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
        /// ������ch1���Ƴ�����ch2�е�����
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
        /// ������ch1�����ch2
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
        /// ���������Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptid">����id</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
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
        /// ��ȡ��ɫ��ϸ��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">ѡ��</param>
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
        /// ɾ����ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">ѡ��</param>
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
        /// �޸Ľ�ɫ����   
        /// </summary>
        /// <param name="uTag">��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="detail">����</param>
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
        /// ��ӽ�ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="Detail">����</param>
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
        /// ��ѯ��ɫ����    
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="condition">��ѯ����</param>
        /// <param name="option">���ѡ��</param>
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
        /// ��ȡ��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="condition">�ۺϲ�ѯ����()</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="count">����</param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ȡ��ɫ��Ա�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolenames">()</param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ѯָ����Ա��ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ɫ�����Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
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
        /// ��ɫ�Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userIDs">�Ƴ���ԱID(��sid��,�ָ�)</param>
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
        /// ��ȡȨ���б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="level"> ȡ�б�ļ��������·���: ACTL_DETAIL : ȡ��ϸ��Ϣ ACTL_LITTLE : ȡ������Ϣ �����������ɻ��ϵ�ѡ��(�ɻ���һ��)ACTL_GETBYNODE : �� Tag ָ���ڵ�ȡ ACTL_INPARNODE : ���� Tag ָ���ڵ㱾��</param>
        /// <param name="Tag"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ȡȨ����Ա��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActID">Ȩ��ID</param>
        /// <param name="Option">ѡ��</param>
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
        /// Ȩ���Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="userids">�û��б�</param>
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
        /// Ȩ���Ƴ���ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="rolenames">��ɫ�б��ԣ��ָ�()</param>
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
        /// Ȩ�������Ա  
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="userids">�û��б��ԣ��ָ�</param>
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
        /// Ȩ����ӽ�ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="roleids">��ɫ�б��ԣ��ָ�()</param>
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
        /// ɾ��Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="Option">ѡ��</param>
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
        /// �½�Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="PosAct">���λ�õ�Ȩ�ޱ�ʶ���Ҳ�����Ϊ���ڵ�</param>
        /// <param name="ActID">����Ȩ�ޱ�ʶ��0���Զ�ѡȡ</param>
        /// <param name="Option">���ѡ�� Optionѡ��: DTAO_AddSub : �������Ŀ(��ָ������ӻ����ͬ����Ŀ����������������Ŀ) DTAO_Insert :��PosAct�������Ŀ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="Detail">����()</param>
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
        /// �鿴Ȩ�޻�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actName">Ȩ����()</param>
        /// <param name="Option">ѡ��</param>
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
        /// �鿴Ȩ�޻�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ����ID</param>
        /// <param name="Option">ѡ��</param>
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
        /// �޸�Ȩ����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ��id</param>
        /// <param name="Actinfo">Ȩ����Ϣ</param>
        /// <param name="Option">ѡ��</param>
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
        /// ��ȡȨ����Ȩ���б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
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
        /// ��ѯָ���û���Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
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
        /// �����û�id��ѯ�û��б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
        /// <param name="UserIds">�û�id�б��ɣ��ָ�</param>
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
        /// ȡ���������б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��Ա��¼id</param>       
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
        /// �����޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptuniqid">����id()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
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
        /// ��ɫ�޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
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
        /// Ȩ���޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ��id</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
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
        /// ��ѯ������Ա��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="strcondition">�ۺϲ�ѯ����</param>
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
