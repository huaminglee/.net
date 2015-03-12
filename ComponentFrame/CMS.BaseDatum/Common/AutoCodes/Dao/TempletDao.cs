#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 张李波 
 * 创建时间 : 2009-12-14 14:07:29 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
        interface="PengeSoft.CMS.BaseDatum.ITempletDao, PengeSoft.CMS.BaseDatum"
        implementation="PengeSoft.CMS.BaseDatum.TempletDao, PengeSoft.CMS.BaseDatum" />
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
    /// ITempletDao接口定主义。
    /// </summary>
    public interface ITempletDao : IDataProviderEx
    {
    }

    /// <summary>
    /// TempletDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class TempletDao : BaseSqlMapDao, ITempletDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(Templet Data, string Order)
        {
            return new TempletQueryPara(Data, Order);
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
            return QueryCount("QueryTempletCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as Templet, null);

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
            Hashtable para = GetParaHashTable(Data as Templet, OrderByField);

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
                statementName = "QueryTempletList";
            else
                statementName = "QueryTempletListBase";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertTemplet", Data);
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
            return Update("UpdateTemplet", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateTemplet", Data, detail);
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
                statementName = "GetTemplet";
            else
                statementName = "GetTempletBase";
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
            return (Templet)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteTemplet", Data);
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
    /// Templet 查询参数
    /// </summary>
    public class TempletQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按Owner排序</summary>
        public const string OrderByOwner = "Owner";
        /// <summary>按Owner排序,降序</summary>
        public const string OrderByOwner_desc = "Owner_D";
        /// <summary>按TempletName排序</summary>
        public const string OrderByTempletName = "TempletName";
        /// <summary>按TempletName排序,降序</summary>
        public const string OrderByTempletName_desc = "TempletName_D";
        /// <summary>按TempletProp排序</summary>
        public const string OrderByTempletProp = "TempletProp";
        /// <summary>按TempletProp排序,降序</summary>
        public const string OrderByTempletProp_desc = "TempletProp_D";
        /// <summary>按TempletType排序</summary>
        public const string OrderByTempletType = "TempletType";
        /// <summary>按TempletType排序,降序</summary>
        public const string OrderByTempletType_desc = "TempletType_D";
        /// <summary>按TempletContent排序</summary>
        public const string OrderByTempletContent = "TempletContent";
        /// <summary>按TempletContent排序,降序</summary>
        public const string OrderByTempletContent_desc = "TempletContent_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 TempletId 条件键名称</summary>
        public const string QueryKey_TempletId = "TempletId";
        /// <summary>查询 Owner 条件键名称</summary>
        public const string QueryKey_Owner = "Owner";
        /// <summary>查询 TempletName 条件键名称</summary>
        public const string QueryKey_TempletName = "TempletName";
        /// <summary>查询 TempletProp 条件键名称</summary>
        public const string QueryKey_TempletProp = "TempletProp";
        /// <summary>查询 TempletType 条件键名称</summary>
        public const string QueryKey_TempletType = "TempletType";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public TempletQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public TempletQueryPara(Templet data, string order)
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
        public void SetQueryPara(Templet data, string order)
        {
            if (data != null)
            {
                SetTempletId(data.TempletId);
                SetOwner(data.Owner);
                SetTempletName(data.TempletName);
                SetTempletProp(data.TempletProp);
                SetTempletType(data.TempletType);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 ID 条件
        /// </summary>
        /// <param name="TempletId">ID</param>
        public void SetTempletId(string TempletId)
        {
            AddCondition("TempletId", TempletId);
        }

        /// <summary>
        /// 设 所有者 条件
        /// </summary>
        /// <param name="Owner">所有者</param>
        public void SetOwner(string Owner)
        {
            AddCondition("Owner", Owner);
        }

        /// <summary>
        /// 设 模板名称 条件
        /// </summary>
        /// <param name="TempletName">模板名称</param>
        public void SetTempletName(string TempletName)
        {
            AddCondition("TempletName", TempletName);
        }

        /// <summary>
        /// 设 模板属性 非零值条件
        /// </summary>
        /// <param name="TempletProp">模板属性</param>
        public void SetTempletProp(int TempletProp)
        {
            AddConditionNonzero("TempletProp", TempletProp);
        }

        /// <summary>
        /// 设 模板类型 非零值条件
        /// </summary>
        /// <param name="TempletType">模板类型</param>
        public void SetTempletType(int TempletType)
        {
            AddConditionNonzero("TempletType", TempletType);
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
    /// Templet 排序比较器
    /// </summary>
    public class ComparerTemplet : IComparer
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
        public ComparerTemplet(string sortField)
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
            Templet x1, y1;

            x1 = (Templet)x;
            y1 = (Templet)y;

            switch (_sortField)
            {
                case TempletQueryPara.OrderByOwner:
                    ret = string.Compare(x1.Owner, y1.Owner);
                    break;
                case TempletQueryPara.OrderByOwner_desc:
                    ret = string.Compare(y1.Owner, x1.Owner);
                    break;
                case TempletQueryPara.OrderByTempletName:
                    ret = string.Compare(x1.TempletName, y1.TempletName);
                    break;
                case TempletQueryPara.OrderByTempletName_desc:
                    ret = string.Compare(y1.TempletName, x1.TempletName);
                    break;
                case TempletQueryPara.OrderByTempletProp:
                    ret = Comparer.Default.Compare(x1.TempletProp, y1.TempletProp);
                    break;
                case TempletQueryPara.OrderByTempletProp_desc:
                    ret = Comparer.Default.Compare(y1.TempletProp, x1.TempletProp);
                    break;
                case TempletQueryPara.OrderByTempletType:
                    ret = Comparer.Default.Compare(x1.TempletType, y1.TempletType);
                    break;
                case TempletQueryPara.OrderByTempletType_desc:
                    ret = Comparer.Default.Compare(y1.TempletType, x1.TempletType);
                    break;
                case TempletQueryPara.OrderByTempletContent:
                    ret = string.Compare(x1.TempletContent, y1.TempletContent);
                    break;
                case TempletQueryPara.OrderByTempletContent_desc:
                    ret = string.Compare(y1.TempletContent, x1.TempletContent);
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