#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:31:16 
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
    public class ModelInfoServerSvrTest
    {
        private IWindsorContainer _container;
        private IModelInfoServerSvr _svr;
        private IRightCheck _auther;

        [SetUp]
        public void SetUp()
        {
            if (_container == null)
            {
                _container = ComponentManager.GetInstance();

                //_container.AddComponent("ModelInfoServer", typeof(IModelInfoServer), typeof(ModelInfoServer));
            }

            _auther = (IRightCheck)_container[typeof(IRightCheck)];
            _auther.Active = true;

            _svr = (IModelInfoServerSvr)_container[typeof(IModelInfoServerSvr)];

            //_auther = new AutherUseRightCheck();
            //_auther.Login("127.0.0.1", "zprk", "");
        }

        [TearDown]
        public void Finished()
        {
            _svr = null;
        }

        /// <summary>
        /// ��ȡģ���б�   
        /// </summary>
        [Test]
        void GetModelList()
        {
            Console.WriteLine("GetModelListδʵ��");
            /*
            string Uid = "";
            string PageName = "";
            ModelInfoList ret = _svr.GetModelList(Uid, PageName);
            //Assert.IsNotNull(ret, "ִ��ʧ��");
            */
        }
    }
}
