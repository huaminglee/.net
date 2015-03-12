#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:29:55 
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
    public class LayoutInfoDaoTest
    {
        private IDaoManager _daoManager = null;
        private ILayoutInfoDao _dao = null;

        public LayoutInfoDaoTest()
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
            _dao = (ILayoutInfoDao)_daoManager.GetDao(typeof(ILayoutInfoDao)); 
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
            LayoutInfo rec = (LayoutInfo)list[0];
            Assert.IsNotNull(rec, title + "�б�Ԫ��δ����");
            if (outKey)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine(title);
                }
                foreach (LayoutInfo item in list)
                {
                    Console.WriteLine("��¼ LID = " + item.LID.ToString());
                }
            }
        }

        private LayoutInfo CreateInsertRec()
        {
            LayoutInfo rec = new LayoutInfo();
            rec.LID = (new Random((int)DateTime.Now.Ticks)).Next();
            rec.LName = "��ҵ�����˾"+Guid.NewGuid().ToString();
            rec.CreateTime = DateTime.Now;

            return rec;
        }

        /// <summary>
        /// ȡ��¼��
        /// </summary>
        [Test]
        public void GetCount()
        {
            int n = _dao.GetCount();

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

            LayoutInfo rec = CreateInsertRec();
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

            LayoutInfo para = new LayoutInfo();
            para.LName = "��%��%˾%";
            list = _dao.QueryList(para, 0, 10, null);
            CheckList(list, "����LName", true);

            para.Clear();
            para.CreateTime = DateTime.Now;
            list = _dao.QueryList(para, 0, 10, null);
            CheckList(list, "����CreateTime", false);

            para.LName = "��%��%˾%";
            list = _dao.QueryList(para, 0, 10, null);
            CheckList(list, "����LName+CreateTime", false);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        [Test]
        public void Insert()
        {
            int n = _dao.GetCount();

            LayoutInfo rec = CreateInsertRec();
            rec.LName = "��ҵ�����˾"+Guid.NewGuid().ToString();

            rec.Owner = "zcj";
            rec.BelongPage = "Default";
            ModelInfo m1 = new ModelInfo();
            m1.MName = "m1";
            ModelInfo m2 = new ModelInfo();
            m2.MName = "m2";
            ModelInfoList mlist = new ModelInfoList();
            mlist.Add(m1);
            mlist.Add(m2);
            rec.LModelList = mlist.JsonText;
            rec.CreateTime = DateTime.Now;
            string mjson = m1.JsonText;
            string recjson = rec.JsonText;
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

            LayoutInfo rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1 , n1, "������¼��δ����");

            rec.LName = "��ҵ�����˾"+Guid.NewGuid().ToString();
            _dao.Update(rec);

            LayoutInfo par = new LayoutInfo();
            par.LID = rec.LID;
            LayoutInfo rec1 = (LayoutInfo)_dao.GetDetail(par);
            Assert.IsNotNull(rec1, "GetDetail()Ԫ��δ����");
            Assert.AreEqual(rec.LName, rec1.LName, "ȡ�����ݴ�");
  
            _dao.Delete(rec1);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "ɾ�����¼��δ��");

            rec1 = (LayoutInfo)_dao.GetDetail(par);
            Assert.IsNull(rec1, "Ԫ��δɾ��");
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        [Test]
        public void Delete()
        {
            int n = _dao.GetCount();

            LayoutInfo rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1, n1, "������¼��δ����");

            LayoutInfo par = new LayoutInfo();
            par.LID = rec.LID;
            _dao.Delete(par);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "ɾ�����¼��δ��");

            LayoutInfo rec1 = (LayoutInfo)_dao.GetDetail(par);
            Assert.IsNull(rec1, "Ԫ��δɾ��");

        }
    }
}
