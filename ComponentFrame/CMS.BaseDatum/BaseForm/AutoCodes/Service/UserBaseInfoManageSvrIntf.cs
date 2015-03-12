#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/6 13:38:54 
 *
 * Copyright (C) 2008 - 鹏业软件公司
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
    /// IUserBaseInfoManageSvr 接口定义。    
    /// </summary>
    [PublishName("UserBaseInfoManage")]
    public interface IUserBaseInfoManageSvr : PengeSoft.Service.Auther.IUserAuther
    {
        /// <summary>
        /// 添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="LoginID">登录名</param>
        /// <param name="Password">密码</param>
        /// <param name="FullName">姓名()</param>
        /// <param name="Remark">备注()</param>
        [PublishMethod]
        int AddUser(string uTag, string LoginID, string Password, string FullName, string Remark);

        /// <summary>
        /// 获取用户基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option"></param>
        /// <param name="sid">登录名</param>
        [PublishMethod]
        UserRec GetUserInfoBySid(string uTag, int Option, int sid);

        /// <summary>
        /// 获取用户基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option"></param>
        /// <param name="loginid">登录名</param>
        [PublishMethod]
        UserRec GetUserInfo(string uTag, int Option, string loginid);

        /// <summary>
        /// 删除单个人员
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">登录id</param>
        [PublishMethod]
        int DelUser(string uTag, string loginid);

        /// <summary>
        /// 批量删除人员
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginIdList">登录id</param>
        [PublishMethod]
        void DelUserList(string uTag, string loginIdList);

        /// <summary>
        /// 设置用户密码  
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginIdList">登录id列表</param>
        /// <param name="newpass">新密码</param>
        [PublishMethod]
        int SetUserPass(string uTag, string loginIdList, string newpass);

        /// <summary>
        /// 修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">登录id</param>
        /// <param name="Userinfo">人员信息</param>
        [PublishMethod]
        int UpdateUserInfo(string uTag, string loginid, BaseUserInfo Userinfo);

        /// <summary>
        /// 查询用户数量   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="strcondition">综合查询条件()</param>
        /// <param name="level">结果选项</param>
        /// <param name="tag">标识位一般传0</param>
        [PublishMethod]
        int QueryUserCount(string uTag, string strcondition, int level, int tag);

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
        Users GetUserList(string uTag, string strcondition, int start, int count, int level, int tag);

        /// <summary>
        /// 添加部门   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ParentID">父部门ID</param>
        /// <param name="depInfo">部门信息</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        int AddDept(string uTag, string ParentID, BaseDeptInfo depInfo, int Option);

        /// <summary>
        /// 修改部门信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptsid">部门sid</param>
        /// <param name="depInfo">部门信息</param>
        /// <param name="Option">修改选项</param>
        [PublishMethod]
        int UpdateDeptInfo(string uTag, BaseDeptInfo depInfo, int Option);

        /// <summary>
        /// 删除部门   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptuniqid">部门id()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        int DelDept(string uTag, string deptuniqid, int Option);

        /// <summary>
        /// 获取部门详细信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="deptuniqid">起始位置</param>
        [PublishMethod]
        UserGroupRec GetDeptInfo(string uTag, int Option, string deptuniqid);

        /// <summary>
        /// 获取部门列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="parentnode">父节点</param>
        [PublishMethod]
        BaseDeptInfoList GetDeptList(string uTag, string parentnode);

        /// <summary>
        /// 获取部门成员列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptId">部门标识</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        Users GetDeptUsers(string uTag, string deptId, int Option);

        /// <summary>
        /// 部门移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptuniqid">部门id()</param>
        /// <param name="UserIDs">人员ids(传sid以,分隔)</param>
        [PublishMethod]
        int DeptRemoveUser(string uTag, string deptuniqid, string UserIDs);

        /// <summary>
        /// 部门添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptuniqid">部门id()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        int DeptAddUser(string uTag, string deptuniqid, string userids);

        /// <summary>
        /// 获取角色详细信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        UserGroupRec GetRoleDetail(string uTag, string rolename, int Option);

        /// <summary>
        /// 删除角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        void DelRole(string uTag, string rolenames, int Option);

        /// <summary>
        /// 修改角色描述   
        /// </summary>
        /// <param name="uTag">标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="detail">描述()</param>
        [PublishMethod]
        int UpdateRoleInfo(string uTag, string rolename, string detail);

        /// <summary>
        /// 添加角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="Detail">描述()</param>
        /// <param name="Option"></param>
        [PublishMethod]
        int AddRole(string uTag, string rolename, string Detail, int Option);

        /// <summary>
        /// 查询角色数量    
        /// </summary>
        /// <param name="uTag">用户登录码</param>
        /// <param name="condition">查询参数</param>
        /// <param name="option">结果选项</param>
        [PublishMethod]
        int QueryRoleCount(string uTag, string condition, int option);

        /// <summary>
        /// 获取角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="condition">综合查询条件</param>
        /// <param name="start">起始位置</param>
        /// <param name="count">数量</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        UserGroups GetRoleList(string uTag, string condition, int start, int count, int Option);

        /// <summary>
        /// 获取角色人员列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolenames">()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        Users GetRoleUsers(string uTag, string rolenames, int Option);

        /// <summary>
        /// 查询指定人员角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="loginid"></param>
        [PublishMethod]
        UserGroupDefs GetUserRoleByUserid(string uTag, int Option, string loginid);

        /// <summary>
        /// 角色添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        void RoleAddUsers(string uTag, string rolename, string userids);

        /// <summary>
        /// 角色移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userIDs">移除人员ID</param>
        [PublishMethod]
        void RoleRemoveUser(string uTag, string rolename, string userIDs);

        /// <summary>
        /// 获取权限列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="level"></param>
        /// <param name="Tag"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        BaseRightsInfoList GetRighstList(string uTag, int level, int Tag, int start, int len, int Option);

        /// <summary>
        /// 获取权限人员角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        BaseUserAndRoleInfoList GetRightsUsers(string uTag, int ActID, int Option);

        /// <summary>
        /// 权限移除人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="userids">用户列表</param>
        [PublishMethod]
        void RightsRemoveUsers(string uTag, string ActName, string userids);

        /// <summary>
        /// 权限移除角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="rolenames">角色列表()</param>
        void RightRemoveRoles(string uTag, string ActName, string rolenames);

        /// <summary>
        /// 权限添加人员   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="userids">用户列表</param>
        [PublishMethod]
        void RightsAddUsers(string uTag, string ActName, string userids);

        /// <summary>
        /// 权限添加角色   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="roleids">角色列表()</param>
        void RightsAddRoles(string uTag, string ActName, string roleids);

        /// <summary>
        /// 删除权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="ActName">权限名()</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        int DelRights(string uTag, string ActName, int Option);

        /// <summary>
        /// 新建权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="PosAct"></param>
        /// <param name="ActID">权限码</param>
        /// <param name="Option"></param>
        /// <param name="ActName">权限名()</param>
        /// <param name="Detail">描述()</param>
        [PublishMethod]
        int AddRights(string uTag, int PosAct, int ActID, int Option, string ActName, string Detail);

        /// <summary>
        /// 查看权限基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actName">权限名</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        UserActionRec GetRightDetail(string uTag, string actName, int Option);
         /// <summary>
        /// 查看权限基本信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限名ID</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
         UserActionRec GetRightDetail(string uTag, int actId, int Option);
        /// <summary>
        /// 修改权限信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限id</param>
        /// <param name="Actinfo">权限信息</param>
        /// <param name="Option">选项</param>
        [PublishMethod]
        int UpdateRightsInfo(string uTag, int actid, BaseRightsInfo Actinfo, int Option);

        /// <summary>
        /// 获取权限子权限列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Node">()</param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        [PublishMethod]
        UserRightRecs GetRightListNode(string uTag, string Node, int start, int len);

        /// <summary>
        /// 查询指定用户的权限   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="loginid"></param>
        [PublishMethod]
        UserActs GetUserRightsListByUser(string uTag, int Option, string loginid);
        /// <summary>
        /// 根据用户id查询用户列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="Option">选项</param>
        /// <param name="UserIds">用户id列表由，分隔</param>
        [PublishMethod]
        Users GetUsersByIds(string uTag, int Option, string UserIds);
        /// <summary>
        /// 取待办事项列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="loginid">人员登录id</param>       
        [PublishMethod]
        DataList GetWorkWaitfor(string uTag, string loginid);
        /// <summary>
        /// 部门修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="deptuniqid">部门id()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        int UpdateDeptUsers(string uTag, string deptuniqid, string userids);

        /// <summary>
        /// 角色修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="rolename">角色名()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        int UpdateRolesUsers(string uTag, string rolename, string userids);

        /// <summary>
        /// 权限修改人员信息   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="actid">权限id()</param>
        /// <param name="userids">人员列表(传sid以,分隔)</param>
        [PublishMethod]
        int UpdateRightUsers(string uTag, int actid, string userids);
        /// <summary>
        /// 查询所有人员角色列表   
        /// </summary>
        /// <param name="uTag">验证标识</param>
        /// <param name="strcondition">综合查询条件</param>
        [PublishMethod]
        BaseUserAndRoleInfoList GetAllUserandRoleList(string uTag, string strcondition);              

    }
}