#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/18 13:21:26 
 *
 * Copyright (C) 2008 - 鹏业软件公司
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
    public class ModelInfoDaoTest
    {
        private IDaoManager _daoManager = null;
        private IModelInfoDao _dao = null;

        public ModelInfoDaoTest()
        {
        }

        [SetUp]
        public void SetUp()
        {
            if (_daoManager == null)
            {
                //当Dao报配置错，且原因在SqlMap中时，取消下面注释可得到详细原因
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                ISqlMapper mapper = builder.Configure(@"sqlMap.config");
                
                _daoManager = PengeSoft.db.IBatis.ServiceConfig.GetInstance(null).DaoManager;

                //DomDaoManagerBuilder Daobuilder = new DomDaoManagerBuilder();
                //Daobuilder.Configure(@"..\..\Files\Dao.config");
                //_daoManager = DaoManager.GetInstance("SqlMapDao");
            }
            _dao = (IModelInfoDao)_daoManager.GetDao(typeof(IModelInfoDao)); 
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
            Assert.IsNotNull(list, title + "未返回列表");
            Assert.IsTrue(list.Count > 0, title + "列表为空");
            ModelInfo rec = (ModelInfo)list[0];
            Assert.IsNotNull(rec, title + "列表元素未返回");
            if (outKey)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine(title);
                }
                foreach (ModelInfo item in list)
                {
                    Console.WriteLine("记录 MId = " + item.MId.ToString());
                }
            }
        }

        private ModelInfo CreateInsertRec()
        {
            ModelInfo rec = new ModelInfo();
            rec.MId = (new Random((int)DateTime.Now.Ticks)).Next();
            rec.MName = "鹏业软件公司"+Guid.NewGuid().ToString();

            return rec;
        }

        /// <summary>
        /// 取记录数
        /// </summary>
        [Test]
        public void GetCount()
        {
            int n = _dao.GetCount();

            Console.WriteLine("记录数: " + n.ToString());
            Assert.IsTrue(n > 0, "记录数小于等于0");
        }

        /// <summary>
        /// 取列表
        /// </summary>
        [Test]
        public void GetList()
        {
            DataList list = _dao.GetList(0, 10, null);
            
            CheckList(list);
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        [Test]
        public void QueryCount()
        {
            int n = _dao.GetCount();
            int n1 = _dao.QueryCount(new Hashtable());

            Console.WriteLine("记录数: " + n.ToString());
            Assert.IsTrue(n == n1, "记录数不相等");

            ModelInfo rec = CreateInsertRec();
            _dao.Insert(rec);

            n1 = _dao.QueryCount(rec);
            Assert.AreEqual(n1 , 1, "记录数只能为1");

            _dao.Delete(rec);
            n1 = _dao.QueryCount(new Hashtable());
            Assert.AreEqual(n , n1, "删除记录数不相等");
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        
        public void QueryList()
        {
            DataList list = _dao.QueryList(null, 0, 10, null);
            CheckList(list);

            ModelInfo para = new ModelInfo();
            para.MName = "鹏%软%司%";
            list = _dao.QueryList(para, 0, 10, null);
            CheckList(list, "条件MName", true);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        [Test]
        public void Insert()
        {
            int n = _dao.GetCount();

            ModelInfo rec = CreateInsertRec();
            rec.MName = "鹏业软件公司"+Guid.NewGuid().ToString();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.IsTrue(n + 1 == n1, "插入后记录数未増加");
            
            if (n1 > 6)
            {
                _dao.Delete(rec);
            }
        }

        /// <summary>
        /// 插入、更新、获取、删除记录
        /// </summary>
        [Test]
        public void InsertUpdateGetDetailDelete()
        {
            int n = _dao.GetCount();

            ModelInfo rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1 , n1, "插入后记录数未増加");

            rec.MName = "鹏业软件公司"+Guid.NewGuid().ToString();
            _dao.Update(rec);

            ModelInfo par = new ModelInfo();
            par.MId = rec.MId;
            ModelInfo rec1 = (ModelInfo)_dao.GetDetail(par);
            Assert.IsNotNull(rec1, "GetDetail()元素未返回");
            Assert.AreEqual(rec.MName, rec1.MName, "取出数据错");
  
            _dao.Delete(rec1);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "删除后记录数未变");

            rec1 = (ModelInfo)_dao.GetDetail(par);
            Assert.IsNull(rec1, "元素未删除");
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        [Test]
        public void Delete()
        {
            int n = _dao.GetCount();

            ModelInfo rec = CreateInsertRec();
            _dao.Insert(rec);

            int n1 = _dao.GetCount();
            Assert.AreEqual(n + 1, n1, "插入后记录数未増加");

            ModelInfo par = new ModelInfo();
            par.MId = rec.MId;
            _dao.Delete(par);
            n1 = _dao.GetCount();
            Assert.AreEqual(n, n1, "删除后记录数未变");

            ModelInfo rec1 = (ModelInfo)_dao.GetDetail(par);
            Assert.IsNull(rec1, "元素未删除");

        }
    }
}
