#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:31:27 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
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
        /// ��ѯ�û�Ƥ����Ϣ   
        /// </summary>
        [Test]
        void GetUserSkinInfo()
        {
            Console.WriteLine("GetUserSkinInfoδʵ��");
            /*
            string UserID = "";
            SkinInfo ret = _svr.GetUserSkinInfo(UserID);
            //Assert.IsNotNull(ret, "ִ��ʧ��");
            */
        }

        /// <summary>
        /// ����û�Ƥ����Ϣ   
        /// </summary>
        [Test]
        void AddUserSkinInfo()
        {
            Console.WriteLine("AddUserSkinInfoδʵ��");
            /*
            string UserID = "";
            string TSkinInfo = "";
            _svr.AddUserSkinInfo(UserID, TSkinInfo);
            */
        }

        /// <summary>
        /// �����û�Ƥ����Ϣ   
        /// </summary>
        [Test]
        void UpdateUserSkinInfo()
        {
            Console.WriteLine("UpdateUserSkinInfoδʵ��");
            /*
            string TSkinInfo = "";
            string UserID = "";
            _svr.UpdateUserSkinInfo(TSkinInfo, UserID);
            */
        }
    }
}
