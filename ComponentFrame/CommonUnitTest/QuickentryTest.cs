#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/19 15:18:26 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataAccess.Configuration;
using NUnit.Framework;
using PengeSoft.Data;
using PengeSoft.db;
using PengeSoft.CMS.BaseDatum;

namespace PengeSoft.CMS.BaseDatumTest 
{
    [TestFixture]
    public class QuickentryDaoTest
    {
        private IDaoManager _daoManager = null;
        private IQuickentryDao _dao = null;

        public QuickentryDaoTest()
        {
        }

        [SetUp]
        public void SetUp()
        {
            if (_daoManager == null)
            {
                //��Dao�����ô���ԭ����SqlMap��ʱ��ȡ������ע�Ϳɵõ���ϸԭ��
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                ISqlMapper mapper = builder.Configure(@"sqlMap.config");
                
                _daoManager = PengeSoft.db.IBatis.ServiceConfig.GetInstance(null).DaoManager;

                //DomDaoManagerBuilder Daobuilder = new DomDaoManagerBuilder();
                //Daobuilder.Configure(@"..\..\Files\Dao.config");
                //_daoManager = DaoManager.GetInstance("SqlMapDao");
            }
            _dao = (IQuickentryDao)_daoManager.GetDao(typeof(IQuickentryDao)); 
        }

        [TearDown]
        public void Finished()
        {
            _dao = null;
        }

        private void CheckList(DataList list)
        {
            CheckList(list, string.Empty, true);
        }

        private void CheckList(DataList list, string title, bool outKey)
        {
            Assert.IsNotNull(list, title + "δ�����б�");
            Assert.IsTrue(list.Count > 0, title + "�б�Ϊ��");
            Quickentry rec = (Quickentry)list[0];
            Assert.IsNotNull(rec, title + "�б�Ԫ��δ����");
            if (outKey)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine(title);
                }
                foreach (Quickentry item in list)
                {
                    Console.WriteLine("��¼ QId = " + item.QId.ToString());
                }
            }
        }

        private Quickentry CreateInsertRec()
        {
            Quickentry rec = new Quickentry();
            rec.QId = (new Random((int)DateTime.Now.Ticks)).Next();
            rec.QName = "��ҵ�����˾"+Guid.NewGuid().ToString();

            return rec;
        }

        /// <summary>
        /// ȡ��¼��
        /// </summary>
        [Test]
        public void GetCount()
        {
            int n = _dao.GetCount();
            Quickentry quicke = new Quickentry();
            quicke.QId = 1;
        
            QuickentryList l1 = new QuickentryList();
            l1.Add(quicke);
            QuickentryList l2 = new QuickentryList();
            Quickentry quicke2 = new Quickentry();
            quicke2.QId = 2;
            l2.Add(quicke2);
            l1.Add(l2);

            Console.WriteLine("��¼��: " + n.ToString());
            Assert.IsTrue(n > 0, "��¼��С�ڵ���0");
        }

        /// <summary>
        /// ȡ�б�
        /// </summary>
        [Test]
        public void GetList()
        {
            DataList list = _dao.GetList(0, 10, null);

            CheckList(list);
        }

        /// <summary>
        /// ��ѯ��¼��
        /// </summary>
        [Test]
        public void QueryCount()
        {
            int n = _dao.GetCount();
            int n1 = _dao.QueryCount(new Hashtable());

            Console.WriteLine("��¼��: " + n.ToString());
            Assert.IsTrue(n == n1, "��¼�������");

            Quickentry rec = CreateInsertRec();
            _dao.Insert(rec);

            n1 = _dao.QueryCount(rec);
            Assert.AreEqual(n1 , 1, "��¼��ֻ��Ϊ1");

            _dao.Delete(rec);
            n1 = _dao.QueryCount(new Hashtable());
            Assert.AreEqual(n , n1, "ɾ����¼�������");
        }

        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        [Test]
        public void QueryList()
        {
            DataList list = _dao.QueryList(null, 0, 10, null);
            CheckList(list);

            Quickentry para = new Quickentry();
            para.QName = "��%��%˾%";
            list = _dao.QueryList(para, 0, 10, null);
            CheckList(list, "����QName", true);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        [Test]
        public void Insert()
        {
            int n = _dao.GetCount();

            Quickentry rec = CreateInsertRec();
            rec.QName = "��ҵ�����˾"+Guid.NewGuid().ToString();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.IsTrue(n + 1 == n1, "������¼��δ����");
            
            if (n1 > 6)
            {
                _dao.Delete(rec);
            }
        }

        /// <summary>
        /// ���롢���¡���ȡ��ɾ����¼
        /// </summary>
        [Test]
        public void InsertUpdateGetDetailDelete()
        {
            int n = _dao.GetCount();

            Quickentry rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1 , n1, "������¼��δ����");

            rec.QName = "��ҵ�����˾"+Guid.NewGuid().ToString();
            _dao.Update(rec);

            Quickentry par = new Quickentry();
            par.QId = rec.QId;
            Quickentry rec1 = (Quickentry)_dao.GetDetail(par);
            Assert.IsNotNull(rec1, "GetDetail()Ԫ��δ����");
            Assert.AreEqual(rec.QName, rec1.QName, "ȡ�����ݴ�");
  
            _dao.Delete(rec1);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "ɾ�����¼��δ��");

            rec1 = (Quickentry)_dao.GetDetail(par);
            Assert.IsNull(rec1, "Ԫ��δɾ��");
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        [Test]
        public void Delete()
        {
            int n = _dao.GetCount();

            Quickentry rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1, n1, "������¼��δ����");

            Quickentry par = new Quickentry();
            par.QId = rec.QId;
            _dao.Delete(par);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "ɾ�����¼��δ��");

            Quickentry rec1 = (Quickentry)_dao.GetDetail(par);
            Assert.IsNull(rec1, "Ԫ��δɾ��");

        }
    }
}
