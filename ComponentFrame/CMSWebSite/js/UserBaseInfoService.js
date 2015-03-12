/*

 @Name: pengesoft 用户信息管理服务类 1.0.0
 @Author：罗坤
 @Date: 2015-03-04
 
 */
function UserBaseInfoService() {
    //继承基础类、并初始化
    BaseService.call(this, "/Service/UserBaseInfo.assx");
}
//继承基类的方法
UserBaseInfoService.prototype = new BaseService();

//定义自己的方法体
UserBaseInfoService.prototype = {
    //登录
    Login:function(loginId, password, userDefTag, callback) {
        this.Post(
            this.baseUrl + "/Login",
            { loginId: loginId, password: password, userDefTag: userDefTag },
            callback);
    },
    //注销
    Logout:function(callback) {
        this.Post(
            this.baseUrl + "/Logout",
            { utag: utag },
            callback);
    },
    //修改密码
    ChangePass:function(oldPwd, newPwd, callback){
        this.Post(
            this.baseUrl + "/ChangePass",
            { utag: this.uTag,oldPwd: oldPwd, newPwd: newPwd },
            callback);
    },
    //添加人员 
    AddUser:function(LoginID, Password, FullName, Remark, callback) {
        this.Post(
            this.baseUrl + "/AddUser",
            { uTag: this.uTag,LoginID: LoginID, Password: Password, FullName: FullName, Remark: Remark },
            callback);
    },

    //获取用户基本信息
    GetUserInfoBySid:function(Option, sid, callback) {
        this.Post(
           this.baseUrl + "/GetUserInfoBySid",
           { uTag: this.uTag,Option: Option, sid: sid },
           callback);
    },

    //获取用户基本信息
    GetUserInfo:function(Option, loginid, callback) {
        this.Post(
           this.baseUrl + "/GetUserInfo",
           { uTag: this.uTag,Option: Option, loginid: loginid },
           callback);
    },

    //删除单个人员
    DelUser:function(loginid, callback) {
        this.Post(
           this.baseUrl + "/DelUser",
           { uTag: this.uTag,loginid: loginid},
           callback);
    },

    //批量删除人员
    DelUserList:function(loginIdList, callback) {
        this.Post(
           this.baseUrl + "/DelUserList",
           { uTag: this.uTag,loginIdList: loginIdList },
           callback);
    },

    //设置用户密码
    SetUserPass:function(loginIdList, newpass, callback) {
        this.Post(
           this.baseUrl + "/SetUserPass",
           { uTag: this.uTag,loginIdList: loginIdList, newpass: newpass },
           callback);
    },

    //修改人员信息
    UpdateUserInfo:function(loginid, Userinfo, callback) {
        this.Post(
           this.baseUrl + "/UpdateUserInfo",
           { uTag: this.uTag,loginid: loginid, Userinfo: Userinfo },
           callback);
    },
    //查询用户数量
    QueryUserCount:function(strcondition, level, tag, callback) {
        this.Post(
           this.baseUrl + "/QueryUserCount",
           { uTag: this.uTag,strcondition: strcondition, level: level, tag: tag },
           callback);
    },
    //查询人员列表
    GetUserList:function(strcondition, start, count, level, tag, callback) {
        this.Post(
           this.baseUrl + "/GetUserList",
           { uTag: this.uTag,strcondition: strcondition, start: start,count:count, level:level, tag:tag },
           callback);
    },

    //添加部门
    AddDept:function(ParentID, depInfo, Option, callback) {
        this.Post(
           this.baseUrl + "/AddDept",
           { uTag: this.uTag,ParentID: ParentID, depInfo: depInfo, Option: Option },
           callback);
    },

    //修改部门信息
    UpdateDeptInfo:function(depInfo, Option, callback) {
        this.Post(
           this.baseUrl + "/UpdateDeptInfo",
           { uTag: this.uTag,depInfo: depInfo, Option: Option },
           callback);
    },

    //删除部门
    DelDept:function(deptuniqid, Option, callback) {
        this.Post(
           this.baseUrl + "/DelDept",
           { uTag: this.uTag,deptuniqid: deptuniqid, Option: Option },
           callback);
    },

    //获取部门详细信息
    GetDeptInfo:function(Option, deptuniqid, callback) {
        this.Post(
           this.baseUrl + "/GetDeptInfo",
           { uTag: this.uTag,deptuniqid: deptuniqid, Option: Option },
           callback);
    },

    //获取部门列表
    GetDeptList:function(parentnode, callback) {
        this.Post(
           this.baseUrl + "/GetDeptList",
           { uTag: this.uTag,parentnode: parentnode },
           callback);
    },

    //获取部门成员列表
    GetDeptUsers:function(deptId, Option, callback) {
        this.Post(
           this.baseUrl + "/GetDeptUsers",
           { uTag: this.uTag,deptId: deptId, Option: Option },
           callback);
    },

    //部门移除人员
    DeptRemoveUser:function(deptuniqid, UserIDs, callback) {
        this.Post(
           this.baseUrl + "/DeptRemoveUser",
           { uTag: this.uTag,deptuniqid: deptuniqid, UserIDs: UserIDs },
           callback);
    },

    //部门添加人员
    DeptAddUser:function(deptuniqid, userids, callback) {
        this.Post(
           this.baseUrl + "/DeptAddUser",
           { uTag: this.uTag,deptuniqid: deptuniqid, userids: userids },
           callback);
    },

    //获取角色详细信息
    GetRoleDetail:function(rolename, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRoleDetail",
           { uTag: this.uTag,rolename: rolename, Option: Option },
           callback);
    },

    // 删除角色
    DelRole:function(rolenames, Option, callback) {
        this.Post(
           this.baseUrl + "/DelRole",
           { uTag: this.uTag,rolenames: rolenames, Option: Option },
           callback);
    },

    //修改角色描述
    UpdateRoleInfo:function(rolename, detail, callback) {
        this.Post(
           this.baseUrl + "/UpdateRoleInfo",
           { uTag: this.uTag,rolename: rolename, detail: detail },
           callback);
    },

    //添加角色
    AddRole:function(rolename, Detail, Option, callback) {
        this.Post(
           this.baseUrl + "/AddRole",
           { uTag: this.uTag,rolename: rolename, Detail: Detail, Option: Option },
           callback);
    },

    //查询角色数量
    QueryRoleCount:function(condition, option, callback) {
        this.Post(
           this.baseUrl + "/QueryRoleCount",
           { uTag: this.uTag,condition: condition, option: option },
           callback);
    },

    //获取角色列表
    GetRoleList:function(condition, start, count, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRoleList",
           { uTag: this.uTag,condition: condition, start: start, count: count, Option: Option },
           callback);
    },

    // 获取角色人员列表
    GetRoleUsers:function(rolenames, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRoleUsers",
           { uTag: this.uTag,rolenames: rolenames, Option: Option },
           callback);
    },

    //查询指定人员角色
    GetUserRoleByUserid:function(Option, loginid, callback) {
        this.Post(
           this.baseUrl + "/GetUserRoleByUserid",
           { uTag: this.uTag,loginid: loginid, Option: Option },
           callback);
    },

    //角色添加人员
    RoleAddUsers:function(rolename, userids, callback) {
        this.Post(
           this.baseUrl + "/RoleAddUsers",
           { uTag: this.uTag,rolename: rolename, userids: userids },
           callback);
    },

    //角色移除人员
    RoleRemoveUser:function(rolename, userIDs, callback) {
        this.Post(
           this.baseUrl + "/RoleRemoveUser",
           { uTag: this.uTag,rolename: rolename, userIDs: userIDs },
           callback);
    },

    //获取权限列表
    GetRighstList:function(level, Tag, start, len, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRighstList",
           { uTag: this.uTag,level: level, Tag: Tag, start: start,len: len, Option: Option },
           callback);
    },

    //获取权限人员角色列
    GetRightsUsers:function(ActID, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRightsUsers",
           { uTag: this.uTag,ActID: ActID, Option: Option },
           callback);
    },

    //权限移除人员
    RightsRemoveUsers:function(ActName, userids, callback) {
        this.Post(
           this.baseUrl + "/RightsRemoveUsers",
           { uTag: this.uTag,ActName: ActName, userids: userids },
           callback);
    },

    //权限移除角色
    RightRemoveRoles:function(ActName, rolenames, callback) {
        this.Post(
           this.baseUrl + "/RightRemoveRoles",
           { uTag: this.uTag,ActName: ActName, rolenames: rolenames },
           callback);
    },

    //权限添加人员
    RightsAddUsers:function(ActName, userids, callback) {
        this.Post(
           this.baseUrl + "/RightsAddUsers",
           { uTag: this.uTag,ActName: ActName, userids: userids },
           callback);
    },

    //权限添加角色
    RightsAddRoles:function(ActName, roleids, callback) {
        this.Post(
           this.baseUrl + "/RightsAddRoles",
           { uTag: this.uTag,ActName: ActName, roleids: roleids },
           callback);
    },

    //删除权限
    DelRights:function (ActName, Option, callback) {
        this.Post(
           this.baseUrl + "/DelRights",
           { uTag: this.uTag,ActName: ActName, Option: Option },
           callback);
    },

    //新建权限
    AddRights:function(PosAct, ActID, Option, ActName, Detail, callback) {
        this.Post(
           this.baseUrl + "/AddRights",
           { uTag: this.uTag,PosAct: PosAct, ActID: ActID, Option: Option, ActName: ActName, Detail: Detail },
           callback);
    },

    //查看权限基本信息
    GetRightDetail:function(actName, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRightDetail",
           { uTag: this.uTag,actName: actName, Option: Option },
           callback);
    },

    //查看权限基本信息
    GetRightDetail:function(actId, Option, callback) {
        this.Post(
           this.baseUrl + "/GetRightDetail",
           { uTag: this.uTag,actId: actId, Option: Option },
           callback);
    },

    //修改权限信息
    UpdateRightsInfo:function(actid, Actinfo, Option, callback) {
        this.Post(
           this.baseUrl + "/UpdateRightsInfo",
           { uTag: this.uTag,actid: actid, Actinfo: Actinfo, Option: Option },
           callback);
    },

    //获取权限子权限列表
    GetRightListNode:function(Node, start, len, callback) {
        this.Post(
           this.baseUrl + "/GetRightListNode",
           { uTag: this.uTag,Node: Node, start: start, len: len },
           callback);
    },

    //查询指定用户的权限
    GetUserRightsListByUser:function(Option, loginid, callback) {
        this.Post(
           this.baseUrl + "/GetUserRightsListByUser",
           { uTag: this.uTag,loginid: loginid, Option: Option},
           callback);
    },

    //根据用户id查询用户列表
    GetUsersByIds:function(Option, UserIds, callback) {
        this.Post(
           this.baseUrl + "/GetUsersByIds",
           { uTag: this.uTag,UserIds: UserIds, Option: Option},
           callback);
    },

    //取待办事项列表
    GetWorkWaitfor:function(callback) {
        this.Post(
           this.baseUrl + "/GetWorkWaitfor",
           { uTag: this.uTag, loginid: this.loginId },
           callback);
    },

    //部门修改人员信息
    UpdateDeptUsers:function(deptuniqid, userids, callback) {
        this.Post(
           this.baseUrl + "/UpdateDeptUsers",
           { uTag: this.uTag,deptuniqid: deptuniqid, userids: userids },
           callback);
    },

    // 角色修改人员信息
    UpdateRolesUsers:function(rolename, userids, callback) {
        this.Post(
           this.baseUrl + "/UpdateRolesUsers",
           { uTag: this.uTag,rolename: rolename, userids: userids},
           callback);
    },

    //权限修改人员信息
    UpdateRightUsers:function(actid, userids, callback) {
        this.Post(
           this.baseUrl + "/UpdateRightUsers",
           { uTag: this.uTag,actid: actid, userids: userids},
           callback);
     },

    //查询所有人员角色列表
    GetAllUserandRoleList:function(strcondition, callback) {
        this.Post(
           this.baseUrl + "/GetAllUserandRoleList",
           { uTag: this.uTag,strcondition: strcondition },
           callback);
    }
}