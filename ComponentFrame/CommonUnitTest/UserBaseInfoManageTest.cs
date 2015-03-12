#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2015/2/3 9:33:34 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using Castle.Windsor;
using NUnit.Framework;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Common;
using PengeSoft.Common.Exceptions;
using PengeSoft.Auther;
using PengeSoft.Auther.RightCheck;
using PengeSoft.CMS.BaseDatum;

namespace PengeSoft.CMS.BaseDatumTest
{
    [TestFixture]
    public class UserBaseInfoManageSvrTest
    {
        private IWindsorContainer _container;
        private IUserBaseInfoManageSvr _svr;
        private IRightCheck _auther;
        private string uTag = "ojMR/MfhUj5673aKdk+hRw==";

        [SetUp]
        public void SetUp()
        {
            if (_container == null)
            {
                _container = ComponentManager.GetInstance();

                //_container.AddComponent("UserBaseInfoManage", typeof(IUserBaseInfoManage), typeof(UserBaseInfoManage));
            }

            _auther = (IRightCheck)_container[typeof(IRightCheck)];
            _auther.Active = true;

            _svr = (IUserBaseInfoManageSvr)_container[typeof(IUserBaseInfoManageSvr)];

            //_auther = new AutherUseRightCheck();
            //_auther.Login("127.0.0.1", "zprk", "");
        }

        [TearDown]
        public void Finished()
        {
            _svr = null;
        }
        /// <summary>
        /// 人员基本操作
        /// </summary>
        [Test]
        public void UserTest()
        {
            string strcondition = "";
            int start = 0;
            int count = -1;
            int option = 0;
            Users res = _svr.GetUserList(uTag, strcondition, start, count, option);
            Assert.IsNotNull(res, "执行失败");
            int usercount = res.Count;

            string LoginID = Guid.NewGuid().ToString();
            string Password = "password";
            string FullName = "测试账号";
            string Remark = "";
            int ret = _svr.AddUser(uTag, LoginID, Password, FullName, Remark);
            Assert.AreNotEqual(ret, 0, "添加失败");


            UserRec addresult = _svr.GetUserInfo(uTag, 0, LoginID);
            Assert.IsNotNull(addresult, "执行失败");


            _svr.DelUser(uTag, LoginID);
            UserRec delresult = _svr.GetUserInfo(uTag, 0, LoginID);
            Assert.IsNull(delresult, "删除失败");


            Users res2 = _svr.GetUserList(uTag, strcondition, start, count, option);
            Assert.AreEqual(usercount, res2.Count, "出错！");
        }
        /// <summary>
        /// 部门测试
        /// </summary>
        [Test]
        public void DeptTest()
        {
            string parentnode = "";
            int start = 0;
            int count = -1;
            int Option = 0;
            UserGroups ret = _svr.GetDeptList(uTag, parentnode, start, count, Option);
            int deptcout = ret.Count;
            Assert.IsNotNull(ret, "执行失败");

            string ParentID = "";
            string deptname = Guid.NewGuid().ToString();
            string deptID = Guid.NewGuid().ToString();
            string Detail = "测试添加部门";
            int ret2 = _svr.AddDept(uTag, ParentID, deptID, deptname, Detail, Option);
            Assert.IsNotNull(ret2, "执行失败");

            UserGroupRec ret3 = _svr.GetDeptInfo(uTag, Option, deptID);
            Assert.IsNotNull(ret, "执行失败");
            ret3.Detail = "修改部门描述";

            int ret4 = _svr.UpdateDeptInfo(uTag, deptID, 0, ret3);
            UserGroupRec ret5 = _svr.GetDeptInfo(uTag, Option, deptID);
            Assert.AreEqual(ret5.Detail, "修改部门描述", "更新失败");


            string userids = "721,718,717";
            int ret6 = _svr.DeptAddUser(uTag, deptID, userids);
            UserGroupRec ret7 = _svr.GetDeptInfo(uTag, 0, deptID);
            Assert.AreEqual(ret7.UserList,new int[]{721,718,717}, "添加失败");

            string removeuser = "721,717";
            int ret8 = _svr.DeptRemoveUser(uTag, deptID, removeuser);
            UserGroupRec ret9 = _svr.GetDeptInfo(uTag, 0, deptID);            
            Assert.AreEqual(ret9.UserList, new int[] {718}, "移除人员失败");

            int ret10 = _svr.DelDept(uTag, deptID, Option);
            UserGroups ret11 = _svr.GetDeptList(uTag, parentnode, start, count, Option);
            int deptcout2 = ret11.Count;
            Assert.AreEqual(deptcout, deptcout2, "删除部门失败");

        }



        /// <summary>
        /// 角色测试   
        /// </summary>
        [Test]
       public void RoleTest()
        {
            string condition = "";
            int start = 0;
            int count = -1;
            int Option = 0;
            UserGroups ret = _svr.GetRoleList(uTag, condition, start, count, Option);
            Assert.IsNotNull(ret, "执行失败");
            int groupcount = ret.Count;

            string rolename = Guid.NewGuid().ToString();
            string Detail = "测试角色";
            int ret2 = _svr.AddRole(uTag, rolename, Detail, Option);
            Assert.IsNotNull(ret, "执行失败");


            string detail = "修改角色描述";
            _svr.UpdateRoleInfo(uTag, rolename, detail);
            UserGroupRec ret3 = _svr.GetRoleDetail(uTag, rolename, Option);
            Assert.IsNotNull(ret, "执行失败");
            Assert.AreEqual("修改角色描述", ret3.Detail, "修改角色描述失败");

            string userids = "721,718";
            _svr.RoleAddUsers(uTag, rolename, userids);

            string loginid = "718";
            UserGroupDefs ret4 = _svr.GetUserRoleByUserid(uTag, Option, loginid);
            UserGroupRec ret5 = _svr.GetRoleDetail(uTag, rolename, Option);
            Assert.IsTrue(ret4.Contains(ret5), "添加人员失败");

            string userIDs="718,120";
            _svr.RoleRemoveUser(uTag, rolename, userIDs);
            UserGroupDefs ret6 = _svr.GetUserRoleByUserid(uTag, Option, loginid);
            UserGroupRec ret7 = _svr.GetRoleDetail(uTag, rolename, Option);
            Assert.IsTrue (!ret6.Contains(ret7), "角色移除人员失败");

            _svr.DelRole(uTag, rolename, Option);
            UserGroups ret8 = _svr.GetRoleList(uTag, condition, start, count, Option);
            Assert.IsNotNull(ret, "删除失败");
            int groupcount2 = ret8.Count;
            Assert.AreEqual(groupcount, groupcount2, "执行失败");
        }

        /// <summary>
        /// 获取权限列表   
        /// </summary>
        [Test]
       public void RighstTest()
        {
           
            int level = 0;
            int Tag = 0;
            int start = 0;
            int len = 0;
            int Option = 0;
            UserRightRecs ret = _svr.GetRighstList(uTag, level, Tag, start, len, Option);
            Assert.IsNotNull(ret, "执行失败");
            int rightscount = ret.Count;

            int PosAct = 0;
            int ActID = 0;
            string ActName = Guid.NewGuid().ToString();
            string Detail = "";
            int ret2 = _svr.AddRights(uTag, PosAct, ActID, Option, ActName, Detail);
            Assert.AreNotEqual(ret,0, "执行失败");

            UserActionRec ret3 = _svr.GetRightDetail(uTag, ActName, Option);
            Assert.IsNotNull(ret, "执行失败");
            ret3.Detail = "修改权限描述";
            _svr.UpdateRightsInfo(uTag, ActName, ret3, Option);
            UserActionRec ret4 = _svr.GetRightDetail(uTag, ActName, Option);
            Assert.AreEqual(ret4.Detail, "修改权限描述", "修改失败");

            string userids = "luokun,yuezhongli,wangjin";
            _svr.RightsAddUsers(uTag, ActName, userids);


            UserActs ret11 = _svr.GetUserRightsListByUser(uTag, Option, "luokun");
            Assert.IsNotNull(ret11, "执行失败");


            Users ret5 = _svr.GetRightsUsers(uTag, ActName, Option);
            Assert.IsNotNull(ret5, "执行失败");

            string removeusers = "yuezhongli,wangjin,luokun";
            _svr.RightsRemoveUsers(uTag, ActName, removeusers);
            Users ret6 = _svr.GetRightsUsers(uTag, ActName, Option);
            Assert.IsNull(ret6, "移除人员失败");

            string roleids = "caiwu,check";
            _svr.RightsAddRoles(uTag, ActName, roleids);
            UserActionRec ret7 = _svr.GetRightDetail(uTag, ActName, Option);
            Users ret8 = _svr.GetRightsUsers(uTag, ActName, Option);
            Assert.IsNotNull(ret8, "执行失败");

            string removerolse = "caiwu,check";
            _svr.RightRemoveRoles(uTag, ActName, removerolse);
            Users ret9 = _svr.GetRightsUsers(uTag, ActName, Option);
            Assert.IsNull(ret9, "执行失败");

            int ret10 = _svr.DelRights(uTag, ActName, Option);
            Assert.AreEqual(ret10,1, "执行失败");

        }
         

        

    
        /// <summary>
       

        

        /// <summary>
        /// 获取权限子权限列表   
        /// </summary>
        [Test]
       public void GetRightListNode()
        {

            string Node = "鹏业内部管理系统";
            int start = 0;
            int len = -1;
            UserRightRecs ret = _svr.GetRightListNode(uTag, Node, start, len);
            Assert.IsNotNull(ret, "执行失败");
            
        }

        
    }
}
