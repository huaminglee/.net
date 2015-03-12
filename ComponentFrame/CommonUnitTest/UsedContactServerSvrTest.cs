#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/22 9:09:29 
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
    public class UsedContactServerSvrTest
    {
        private IWindsorContainer _container;
        private IUsedContactServerSvr _svr;
        private IRightCheck _auther;

        [SetUp]
        public void SetUp()
        {
            if (_container == null)
            {
                _container = ComponentManager.GetInstance();

                //_container.AddComponent("UsedContactServer", typeof(IUsedContactServer), typeof(UsedContactServer));
            }
            _svr = (IUsedContactServerSvr)_container[typeof(IUsedContactServerSvr)];
            
            _auther = (IRightCheck)_container[typeof(IRightCheck)];
           // _auther.Active = true;

            //_auther = new AutherUseRightCheck();
            //_auther.Login("127.0.0.1", "zprk", "");
        }

        [TearDown]
        public void Finished()
        {
            _svr = null;
        }

        /// <summary>
        /// 添加记录   
        /// </summary>
        [Test]
      public  void AddRecord()
        {
             
            
            string COwner = "test";
            string ContactUserID = "zhd";
            string ContactUserXM = "sddsdfds";
            string TaskName = "test1";
            string StepName = "step1";
            int CType = 1;
            _svr.AddRecord(COwner, ContactUserID, ContactUserXM, TaskName, StepName, CType);
            
        }

        /// <summary>
        /// 获取常用联系人   
        /// </summary>
        [Test]
       public void GetContactsList()
        {
           
            string COwner = "test";
            string TaskName = "test1";
            string StepName = "step1";
            UseContactList ret = _svr.GetContactsList(COwner, TaskName, StepName);
            
        }
    }
}