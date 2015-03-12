#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:31:27 
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
    public class SkinServerSvrTest
    {
        private IWindsorContainer _container;
        private ISkinServerSvr _svr;
        private IRightCheck _auther;

        [SetUp]
        public void SetUp()
        {
            if (_container == null)
            {
                _container = ComponentManager.GetInstance();

                //_container.AddComponent("SkinServer", typeof(ISkinServer), typeof(SkinServer));
            }

            _auther = (IRightCheck)_container[typeof(IRightCheck)];
            _auther.Active = true;

            _svr = (ISkinServerSvr)_container[typeof(ISkinServerSvr)];

            //_auther = new AutherUseRightCheck();
            //_auther.Login("127.0.0.1", "zprk", "");
        }

        [TearDown]
        public void Finished()
        {
            _svr = null;
        }

        /// <summary>
        /// 查询用户皮肤信息   
        /// </summary>
        [Test]
        void GetUserSkinInfo()
        {
            Console.WriteLine("GetUserSkinInfo未实现");
            /*
            string UserID = "";
            SkinInfo ret = _svr.GetUserSkinInfo(UserID);
            //Assert.IsNotNull(ret, "执行失败");
            */
        }

        /// <summary>
        /// 添加用户皮肤信息   
        /// </summary>
        [Test]
        void AddUserSkinInfo()
        {
            Console.WriteLine("AddUserSkinInfo未实现");
            /*
            string UserID = "";
            string TSkinInfo = "";
            _svr.AddUserSkinInfo(UserID, TSkinInfo);
            */
        }

        /// <summary>
        /// 更新用户皮肤信息   
        /// </summary>
        [Test]
        void UpdateUserSkinInfo()
        {
            Console.WriteLine("UpdateUserSkinInfo未实现");
            /*
            string TSkinInfo = "";
            string UserID = "";
            _svr.UpdateUserSkinInfo(TSkinInfo, UserID);
            */
        }
    }
}
