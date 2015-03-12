#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/2/6 13:38:54 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Service;
using PengeSoft.WorkFlow;
using PengeSoft.Service.Auther;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// IUserBaseInfoManageSvr �ӿڶ��塣    
    /// </summary>
    [PublishName("UserBaseInfoManage")]
    public interface IUserBaseInfoManageSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// �����Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="LoginID">��¼��</param>
        /// <param name="Password">����</param>
        /// <param name="FullName">����()</param>
        /// <param name="Remark">��ע()</param>
        [PublishMethod]
        int AddUser(string uTag, string LoginID, string Password, string FullName, string Remark);

        /// <summary>
        /// ��ȡ�û�������Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option"></param>
        /// <param name="sid">��¼��</param>
        [PublishMethod]
        UserRec GetUserInfoBySid(string uTag, int Option, int sid);

        /// <summary>
        /// ��ȡ�û�������Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option"></param>
        /// <param name="loginid">��¼��</param>
        [PublishMethod]
        UserRec GetUserInfo(string uTag, int Option, string loginid);

        /// <summary>
        /// ɾ��������Ա
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��¼id</param>
        [PublishMethod]
        int DelUser(string uTag, string loginid);

        /// <summary>
        /// ����ɾ����Ա
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginIdList">��¼id</param>
        [PublishMethod]
        void DelUserList(string uTag, string loginIdList);

        /// <summary>
        /// �����û�����  
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginIdList">��¼id�б�</param>
        /// <param name="newpass">������</param>
        [PublishMethod]
        int SetUserPass(string uTag, string loginIdList, string newpass);

        /// <summary>
        /// �޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��¼id</param>
        /// <param name="Userinfo">��Ա��Ϣ</param>
        [PublishMethod]
        int UpdateUserInfo(string uTag, string loginid, BaseUserInfo Userinfo);

        /// <summary>
        /// ��ѯ�û�����   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="strcondition">�ۺϲ�ѯ����()</param>
        /// <param name="level">���ѡ��</param>
        /// <param name="tag">��ʶλһ�㴫0</param>
        [PublishMethod]
        int QueryUserCount(string uTag, string strcondition, int level, int tag);

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
        Users GetUserList(string uTag, string strcondition, int start, int count, int level, int tag);

        /// <summary>
        /// ��Ӳ���   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ParentID">������ID</param>
        /// <param name="depInfo">������Ϣ</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        int AddDept(string uTag, string ParentID, BaseDeptInfo depInfo, int Option);

        /// <summary>
        /// �޸Ĳ�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptsid">����sid</param>
        /// <param name="depInfo">������Ϣ</param>
        /// <param name="Option">�޸�ѡ��</param>
        [PublishMethod]
        int UpdateDeptInfo(string uTag, BaseDeptInfo depInfo, int Option);

        /// <summary>
        /// ɾ������   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptuniqid">����id()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        int DelDept(string uTag, string deptuniqid, int Option);

        /// <summary>
        /// ��ȡ������ϸ��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
        /// <param name="deptuniqid">��ʼλ��</param>
        [PublishMethod]
        UserGroupRec GetDeptInfo(string uTag, int Option, string deptuniqid);

        /// <summary>
        /// ��ȡ�����б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="parentnode">���ڵ�</param>
        [PublishMethod]
        BaseDeptInfoList GetDeptList(string uTag, string parentnode);

        /// <summary>
        /// ��ȡ���ų�Ա�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptId">���ű�ʶ</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        Users GetDeptUsers(string uTag, string deptId, int Option);

        /// <summary>
        /// �����Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptuniqid">����id()</param>
        /// <param name="UserIDs">��Աids(��sid��,�ָ�)</param>
        [PublishMethod]
        int DeptRemoveUser(string uTag, string deptuniqid, string UserIDs);

        /// <summary>
        /// ���������Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptuniqid">����id()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
        [PublishMethod]
        int DeptAddUser(string uTag, string deptuniqid, string userids);

        /// <summary>
        /// ��ȡ��ɫ��ϸ��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        UserGroupRec GetRoleDetail(string uTag, string rolename, int Option);

        /// <summary>
        /// ɾ����ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        void DelRole(string uTag, string rolenames, int Option);

        /// <summary>
        /// �޸Ľ�ɫ����   
        /// </summary>
        /// <param name="uTag">��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="detail">����()</param>
        [PublishMethod]
        int UpdateRoleInfo(string uTag, string rolename, string detail);

        /// <summary>
        /// ��ӽ�ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="Detail">����()</param>
        /// <param name="Option"></param>
        [PublishMethod]
        int AddRole(string uTag, string rolename, string Detail, int Option);

        /// <summary>
        /// ��ѯ��ɫ����    
        /// </summary>
        /// <param name="uTag">�û���¼��</param>
        /// <param name="condition">��ѯ����</param>
        /// <param name="option">���ѡ��</param>
        [PublishMethod]
        int QueryRoleCount(string uTag, string condition, int option);

        /// <summary>
        /// ��ȡ��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="condition">�ۺϲ�ѯ����</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="count">����</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        UserGroups GetRoleList(string uTag, string condition, int start, int count, int Option);

        /// <summary>
        /// ��ȡ��ɫ��Ա�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolenames">()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        Users GetRoleUsers(string uTag, string rolenames, int Option);

        /// <summary>
        /// ��ѯָ����Ա��ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
        /// <param name="loginid"></param>
        [PublishMethod]
        UserGroupDefs GetUserRoleByUserid(string uTag, int Option, string loginid);

        /// <summary>
        /// ��ɫ�����Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
        [PublishMethod]
        void RoleAddUsers(string uTag, string rolename, string userids);

        /// <summary>
        /// ��ɫ�Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userIDs">�Ƴ���ԱID</param>
        [PublishMethod]
        void RoleRemoveUser(string uTag, string rolename, string userIDs);

        /// <summary>
        /// ��ȡȨ���б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="level"></param>
        /// <param name="Tag"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        BaseRightsInfoList GetRighstList(string uTag, int level, int Tag, int start, int len, int Option);

        /// <summary>
        /// ��ȡȨ����Ա��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        BaseUserAndRoleInfoList GetRightsUsers(string uTag, int ActID, int Option);

        /// <summary>
        /// Ȩ���Ƴ���Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="userids">�û��б�</param>
        [PublishMethod]
        void RightsRemoveUsers(string uTag, string ActName, string userids);

        /// <summary>
        /// Ȩ���Ƴ���ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="rolenames">��ɫ�б�()</param>
        void RightRemoveRoles(string uTag, string ActName, string rolenames);

        /// <summary>
        /// Ȩ�������Ա   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="userids">�û��б�</param>
        [PublishMethod]
        void RightsAddUsers(string uTag, string ActName, string userids);

        /// <summary>
        /// Ȩ����ӽ�ɫ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="roleids">��ɫ�б�()</param>
        void RightsAddRoles(string uTag, string ActName, string roleids);

        /// <summary>
        /// ɾ��Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        int DelRights(string uTag, string ActName, int Option);

        /// <summary>
        /// �½�Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="PosAct"></param>
        /// <param name="ActID">Ȩ����</param>
        /// <param name="Option"></param>
        /// <param name="ActName">Ȩ����()</param>
        /// <param name="Detail">����()</param>
        [PublishMethod]
        int AddRights(string uTag, int PosAct, int ActID, int Option, string ActName, string Detail);

        /// <summary>
        /// �鿴Ȩ�޻�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actName">Ȩ����</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        UserActionRec GetRightDetail(string uTag, string actName, int Option);
         /// <summary>
        /// �鿴Ȩ�޻�����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ����ID</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
         UserActionRec GetRightDetail(string uTag, int actId, int Option);
        /// <summary>
        /// �޸�Ȩ����Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ��id</param>
        /// <param name="Actinfo">Ȩ����Ϣ</param>
        /// <param name="Option">ѡ��</param>
        [PublishMethod]
        int UpdateRightsInfo(string uTag, int actid, BaseRightsInfo Actinfo, int Option);

        /// <summary>
        /// ��ȡȨ����Ȩ���б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Node">()</param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        [PublishMethod]
        UserRightRecs GetRightListNode(string uTag, string Node, int start, int len);

        /// <summary>
        /// ��ѯָ���û���Ȩ��   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
        /// <param name="loginid"></param>
        [PublishMethod]
        UserActs GetUserRightsListByUser(string uTag, int Option, string loginid);
        /// <summary>
        /// �����û�id��ѯ�û��б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="Option">ѡ��</param>
        /// <param name="UserIds">�û�id�б��ɣ��ָ�</param>
        [PublishMethod]
        Users GetUsersByIds(string uTag, int Option, string UserIds);
        /// <summary>
        /// ȡ���������б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="loginid">��Ա��¼id</param>       
        [PublishMethod]
        DataList GetWorkWaitfor(string uTag, string loginid);
        /// <summary>
        /// �����޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="deptuniqid">����id()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
        [PublishMethod]
        int UpdateDeptUsers(string uTag, string deptuniqid, string userids);

        /// <summary>
        /// ��ɫ�޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="rolename">��ɫ��()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
        [PublishMethod]
        int UpdateRolesUsers(string uTag, string rolename, string userids);

        /// <summary>
        /// Ȩ���޸���Ա��Ϣ   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="actid">Ȩ��id()</param>
        /// <param name="userids">��Ա�б�(��sid��,�ָ�)</param>
        [PublishMethod]
        int UpdateRightUsers(string uTag, int actid, string userids);
        /// <summary>
        /// ��ѯ������Ա��ɫ�б�   
        /// </summary>
        /// <param name="uTag">��֤��ʶ</param>
        /// <param name="strcondition">�ۺϲ�ѯ����</param>
        [PublishMethod]
        BaseUserAndRoleInfoList GetAllUserandRoleList(string uTag, string strcondition);              

    }
}