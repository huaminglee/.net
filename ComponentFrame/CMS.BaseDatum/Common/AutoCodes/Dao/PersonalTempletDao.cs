#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 冯兴彬 
 * 创建时间 : 2010-5-27 10:23:16 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
        interface="PengeSoft.CMS.BaseDatum.IPersonalTempletDao, PengeSoft.CMS.BaseDatum"
        implementation="PengeSoft.CMS.BaseDatum.PersonalTempletDao, PengeSoft.CMS.BaseDatum" />
    </daoFactory>
*/
using System;
using System.Collections;
using System.Text;
using PengeSoft.Data;
using PengeSoft.db;
using PengeSoft.db.IBatis;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.DaoSessionHandlers;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.DataMapper;

namespace PengeSoft.CMS.BaseDatum
{
    /// <summary>
    /// IPersonalTempletDao接口定主义。
    /// </summary>
    public interface IPersonalTempletDao : IDataProviderEx
    {
    }

    /// <summary>
    /// PersonalTempletDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class PersonalTempletDao : BaseSqlMapDao, IPersonalTempletDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(PersonalTemplet Data, string Order)
        {
            return new PersonalTempletQueryPara(Data, Order);
        }

        #endregion

        #region IPagedDataProvider 成员

        /// <summary>
        /// 查询记录数,条件表参见 <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <returns>记录数</returns>
        public int QueryCount(Hashtable queryPar)
        {
            return QueryCount("QueryPersonalTempletCount", queryPar);
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="queryPara">查询条件对象</param>
        /// <returns>记录数</returns>
        public int QueryCount(string statementName, Hashtable queryPara)
        {
            return (int)ExecuteQueryForObject(statementName, queryPara);
        }

        /// <summary>
        /// 查询列表,条件表参见 <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <returns>列表</returns>
        public DataList QueryList(Hashtable queryPar, int Start, int PageSize)
        {
            return QueryList(queryPar, Start, PageSize, true);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="queryPara">查询条件对象</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <returns>列表</returns>
        public DataList QueryList(string statementName, Hashtable queryPara, int Start, int PageSize)
        {
            NorDataList list = (NorDataList)ExecuteQueryForList(statementName, queryPara, Start, PageSize);

            return list;
        }

        #endregion

        #region IDataProviderEx 成员

        /// <summary>
        /// 取记录数
        /// </summary>
        public int GetCount()
        {
            Hashtable para = GetParaHashTable(null, null);

            return QueryCount(para);
        }

        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <param name="OrderByField">排序字段</param>
        public DataList GetList(int Start, int PageSize, string OrderByField)
        {
            Hashtable para = GetParaHashTable(null, OrderByField);

            return QueryList(para, Start, PageSize);
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <returns>记录数</returns>
        public int QueryCount(DataPacket Data)
        {
            Hashtable para = GetParaHashTable(Data as PersonalTemplet, null);

            return QueryCount(para);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <returns>列表</returns>
        /// <param name="OrderByField">排序字段</param>
        public DataList QueryList(DataPacket Data, int Start, int PageSize, string OrderByField)
        {
            Hashtable para = GetParaHashTable(Data as PersonalTemplet, OrderByField);

            return QueryList(para, Start, PageSize);
        }

        /// <summary>
        /// 查询列表,条件表参见 <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <param name="detail">取明细数据</param>
        /// <returns>列表</returns>
        public DataList QueryList(Hashtable queryPar, int Start, int PageSize, bool detail)
        {
            string statementName;
            if (detail)
                statementName = "QueryPersonalTempletList";
            else
                statementName = "QueryPersonalTempletList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertPersonalTemplet", Data);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(string statementName, DataPacket Data)
        {
            object ret = ExecuteInsert(statementName, Data);

            return ret;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdatePersonalTemplet", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdatePersonalTemplet", Data, detail);
        }

        /// <summary>
        /// 更新记录, 指定 sqlMap 映射语句
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="Data">数据对象</param>
        /// <returns>更新记录数</returns>
        public int Update(string statementName, DataPacket Data)
        {
            return Update(statementName, Data, true);
        }

        /// <summary>
        /// 更新记录, 指定 sqlMap 映射语句
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>更新记录数</returns>
        public int Update(string statementName, DataPacket Data, bool detail)
        {
            int ret = ExecuteUpdate(statementName, Data);

            return ret;
        }

        /// <summary>
        /// 取详细数据
        /// </summary>
        /// <param name="data">条件对象</param>
        /// <returns>数据对象</returns>
        public DataPacket GetDetail(DataPacket data)
        {
            return GetDetail(data, true);
        }

        /// <summary>
        /// 取数据
        /// </summary>
        /// <param name="data">条件对象</param>
        /// <param name="detail">取明细数据</param>
        /// <returns>数据对象</returns>
        public DataPacket GetDetail(DataPacket data, bool detail)
        {
            string statementName;
            if (detail)
                statementName = "GetPersonalTemplet";
            else
                statementName = "GetPersonalTemplet";
            return GetDetail(statementName, data);
        }

        /// <summary>
        /// 取数据
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="data">条件对象</param>
        /// <returns>数据对象</returns>
        public DataPacket GetDetail(string statementName, DataPacket Data)
        {
            return (PersonalTemplet)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeletePersonalTemplet", Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="statementName">sqlMap 映射语句</param>
        /// <param name="Data">条件对象</param>
        public void Delete(string statementName, DataPacket Data)
        {
            ExecuteDelete(statementName, Data);
        }

        #endregion
    }

    /// <summary>
    /// PersonalTemplet 查询参数
    /// </summary>
    public class PersonalTempletQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按PersonalId排序</summary>
        public const string OrderByPersonalId = "PersonalId";
        /// <summary>按PersonalId排序,降序</summary>
        public const string OrderByPersonalId_desc = "PersonalId_D";
        /// <summary>按PersonalName排序</summary>
        public const string OrderByPersonalName = "PersonalName";
        /// <summary>按PersonalName排序,降序</summary>
        public const string OrderByPersonalName_desc = "PersonalName_D";
        /// <summary>按PersonType排序</summary>
        public const string OrderByPersonType = "PersonType";
        /// <summary>按PersonType排序,降序</summary>
        public const string OrderByPersonType_desc = "PersonType_D";
        /// <summary>按ID排序</summary>
        public const string OrderByID = "ID";
        /// <summary>按ID排序,降序</summary>
        public const string OrderByID_desc = "ID_D";
        /// <summary>按RefID排序</summary>
        public const string OrderByRefID = "RefID";
        /// <summary>按RefID排序,降序</summary>
        public const string OrderByRefID_desc = "RefID_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 PersonalId 条件键名称</summary>
        public const string QueryKey_PersonalId = "PersonalId";
        /// <summary>查询 PersonalName 条件键名称</summary>
        public const string QueryKey_PersonalName = "PersonalName";
        /// <summary>查询 PersonType 条件键名称</summary>
        public const string QueryKey_PersonType = "PersonType";
        /// <summary>查询 ID 条件键名称</summary>
        public const string QueryKey_ID = "ID";
        /// <summary>查询 RefID 条件键名称</summary>
        public const string QueryKey_RefID = "RefID";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonalTempletQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public PersonalTempletQueryPara(PersonalTemplet data, string order)
        {
            SetQueryPara(data, order);
        }

        #endregion

        #region 公共函数

        /// <summary>
        /// 指定查询参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public void SetQueryPara(PersonalTemplet data, string order)
        {
            if (data != null)
            {
                SetPersonalId(data.PersonalId);
                SetPersonalName(data.PersonalName);
                SetPersonType(data.PersonType);
                SetID(data.ID);
                SetRefID(data.RefID);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 人员模板ID 条件
        /// </summary>
        /// <param name="PersonalId">人员模板ID</param>
        public void SetPersonalId(string PersonalId)
        {
            AddCondition("PersonalId", PersonalId);
        }

        /// <summary>
        /// 设 人员名称 条件
        /// </summary>
        /// <param name="PersonalName">人员名称</param>
        public void SetPersonalName(string PersonalName)
        {
            AddCondition("PersonalName", PersonalName);
        }

        /// <summary>
        /// 设 人员类型 非零值条件
        /// </summary>
        /// <param name="PersonType">人员类型</param>
        public void SetPersonType(int PersonType)
        {
            AddConditionNonzero("PersonType", PersonType);
        }

        /// <summary>
        /// 设 主键 条件
        /// </summary>
        /// <param name="ID">主键</param>
        public void SetID(string ID)
        {
            AddCondition("ID", ID);
        }

        /// <summary>
        /// 设 引用标识 条件
        /// </summary>
        /// <param name="RefID">引用标识</param>
        public void SetRefID(string RefID)
        {
            AddCondition("RefID", RefID);
        }

        /// <summary>
        /// 设排序字段
        /// </summary>
        /// <param name="Order">排序字段</param>
        public void SetOrderByField(string Order)
        {
            if (!string.IsNullOrEmpty(Order))
            {
                Add("_OrderBy", Order);
            }
        }

        #endregion
    }

    /// <summary>
    /// PersonalTemplet 排序比较器
    /// </summary>
    public class ComparerPersonalTemplet : IComparer
    {
        #region 私有字段

        private string _sortField;

        #endregion

        #region 属性

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            get { return _sortField; }
            set { _sortField = value; }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建实例,并初始化排序字段
        /// </summary>
        /// <param name="sortField">排序字段</param>
        public ComparerPersonalTemplet(string sortField)
        {
            _sortField = sortField;
        }

        #endregion

        #region IComparer 成员

        /// <summary>
        /// 比较两个 <see cref="Zjjhxmmx"/> 对象并返回一个值，指示一个对象是小于、等于还是大于另一个对象。
        /// </summary>
        /// <param name="x">要比较的第一个对象。</param>
        /// <param name="y">要比较的第二个对象。</param>
        /// <returns>值 条件 小于零 x 小于 y。 零 x 等于 y。 大于零 x 大于 y。</returns>
        public int Compare(object x, object y)
        {
            int ret = 0;
            PersonalTemplet x1, y1;

            x1 = (PersonalTemplet)x;
            y1 = (PersonalTemplet)y;

            switch (_sortField)
            {
                case PersonalTempletQueryPara.OrderByPersonalId:
                    ret = string.Compare(x1.PersonalId, y1.PersonalId);
                    break;
                case PersonalTempletQueryPara.OrderByPersonalId_desc:
                    ret = string.Compare(y1.PersonalId, x1.PersonalId);
                    break;
                case PersonalTempletQueryPara.OrderByPersonalName:
                    ret = string.Compare(x1.PersonalName, y1.PersonalName);
                    break;
                case PersonalTempletQueryPara.OrderByPersonalName_desc:
                    ret = string.Compare(y1.PersonalName, x1.PersonalName);
                    break;
                case PersonalTempletQueryPara.OrderByPersonType:
                    ret = Comparer.Default.Compare(x1.PersonType, y1.PersonType);
                    break;
                case PersonalTempletQueryPara.OrderByPersonType_desc:
                    ret = Comparer.Default.Compare(y1.PersonType, x1.PersonType);
                    break;
                case PersonalTempletQueryPara.OrderByID:
                    ret = string.Compare(x1.ID, y1.ID);
                    break;
                case PersonalTempletQueryPara.OrderByID_desc:
                    ret = string.Compare(y1.ID, x1.ID);
                    break;
                case PersonalTempletQueryPara.OrderByRefID:
                    ret = string.Compare(x1.RefID, y1.RefID);
                    break;
                case PersonalTempletQueryPara.OrderByRefID_desc:
                    ret = string.Compare(y1.RefID, x1.RefID);
                    break;
                default:
                    throw new Exception("未知的排序字段 " + _sortField);
                //break;
            }

            return ret;
        }

        #endregion
    }
}
