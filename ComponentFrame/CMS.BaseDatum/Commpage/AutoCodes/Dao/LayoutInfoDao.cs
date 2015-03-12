#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/11/27 14:13:52 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.ILayoutInfoDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.LayoutInfoDao, PengeSoft.CMS.BaseDatum" />
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
    /// ILayoutInfoDao接口定主义。
    /// </summary>
    public interface ILayoutInfoDao : IDataProviderEx
    {
    }

    /// <summary>
    /// LayoutInfoDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class LayoutInfoDao : BaseSqlMapDao, ILayoutInfoDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(LayoutInfo Data, string Order)
        {
            return new LayoutInfoQueryPara(Data, Order);
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
            return QueryCount("QueryLayoutInfoCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as LayoutInfo, null);

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
            Hashtable para = GetParaHashTable(Data as LayoutInfo, OrderByField);

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
                statementName = "QueryLayoutInfoList";
            else
                statementName = "QueryLayoutInfoList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertLayoutInfo", Data);
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
            ((LayoutInfo)Data).LID = (int)ret;

            return ret;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateLayoutInfo", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateLayoutInfo", Data, detail);
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
                statementName = "GetLayoutInfo";
            else
                statementName = "GetLayoutInfo";
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
            return (LayoutInfo)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteLayoutInfo", Data);
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
    /// LayoutInfo 查询参数
    /// </summary>
    public class LayoutInfoQueryPara : QueryParameter
    {
        #region 排序常量


        #endregion

        #region 查询条件常量

        /// <summary>查询 LName 条件键名称</summary>
        public const string QueryKey_LName = "LName";
        /// <summary>查询 LayType 条件键名称</summary>
        public const string QueryKey_LayType = "LayType";
        /// <summary>查询 TempType 条件键名称</summary>
        public const string QueryKey_TempType = "TempType";
        /// <summary>查询 Owner 条件键名称</summary>
        public const string QueryKey_Owner = "Owner";
        /// <summary>查询 BelongPage 条件键名称</summary>
        public const string QueryKey_BelongPage = "BelongPage";
        /// <summary>查询 Isusing 条件键名称</summary>
        public const string QueryKey_Isusing = "Isusing";
        /// <summary>查询 Isusing 条件IN键名称</summary>
        public const string QueryKey_Isusing_IN = "Isusing_IN";
        /// <summary>查询 ExtendFields1 条件键名称</summary>
        public const string QueryKey_ExtendFields1 = "ExtendFields1";
        /// <summary>查询 ExtendFields2 条件键名称</summary>
        public const string QueryKey_ExtendFields2 = "ExtendFields2";
        /// <summary>查询 ExtendFields3 条件键名称</summary>
        public const string QueryKey_ExtendFields3 = "ExtendFields3";
        /// <summary>查询 CreateTime 条件键名称</summary>
        public const string QueryKey_CreateTime = "CreateTime";
        /// <summary>查询 CreateTime 条件起始日期键名称</summary>
        public const string QueryKey_CreateTime_S = "CreateTime_S";
        /// <summary>查询 CreateTime 条件结束日期键名称</summary>
        public const string QueryKey_CreateTime_E = "CreateTime_E";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public LayoutInfoQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public LayoutInfoQueryPara(LayoutInfo data, string order)
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
        public void SetQueryPara(LayoutInfo data, string order)
        {
            if (data != null)
            {
                SetLName(data.LName);
                SetLayType(data.LayType);
                SetTempType(data.TempType);
                SetOwner(data.Owner);
                SetBelongPage(data.BelongPage);
                SetIsusing(data.Isusing);
                SetExtendFields1(data.ExtendFields1);
                SetExtendFields2(data.ExtendFields2);
                SetExtendFields3(data.ExtendFields3);
                SetCreateTime(data.CreateTime);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 布局名称 条件
        /// </summary>
        /// <param name="LName">布局名称</param>
        public void SetLName(string LName)
        {
            AddCondition("LName", LName);
        }

        /// <summary>
        /// 设 布局类型（区分详细模板和布局模板） 条件
        /// </summary>
        /// <param name="LayType">布局类型（区分详细模板和布局模板）</param>
        public void SetLayType(string LayType)
        {
            AddCondition("LayType", LayType);
        }

        /// <summary>
        /// 设 模板类型（区分默认和用户专有） 条件
        /// </summary>
        /// <param name="TempType">模板类型（区分默认和用户专有）</param>
        public void SetTempType(string TempType)
        {
            AddCondition("TempType", TempType);
        }

        /// <summary>
        /// 设 所属人员或权限 条件
        /// </summary>
        /// <param name="Owner">所属人员或权限</param>
        public void SetOwner(string Owner)
        {
            AddCondition("Owner", Owner);
        }

        /// <summary>
        /// 设 所属页面 条件
        /// </summary>
        /// <param name="BelongPage">所属页面</param>
        public void SetBelongPage(string BelongPage)
        {
            AddCondition("BelongPage", BelongPage);
        }

        /// <summary>
        /// 设 是否正在使用 非零值条件
        /// </summary>
        /// <param name="Isusing">是否正在使用</param>
        public void SetIsusing(int Isusing)
        {
            AddConditionNonzero("Isusing", Isusing);
        }
        /// <summary>
        /// 设 是否正在使用 条件(包含零值)
        /// </summary>
        /// <param name="Isusing">是否正在使用</param>
        public void SetIsusing_InZero(int Isusing)
        {
            AddCondition("Isusing", Isusing);
        }
        /// <summary>
        /// 设 是否正在使用 枚举值条件
        /// </summary>
        /// <param name="Isusing">是否正在使用</param>
        public void SetIsusing_In(int[] Isusings)
        {
            string value = "";
            foreach (int val in Isusings)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("Isusing_IN", value);
        }

        /// <summary>
        /// 设 扩展字段1 条件
        /// </summary>
        /// <param name="ExtendFields1">扩展字段1</param>
        public void SetExtendFields1(string ExtendFields1)
        {
            AddCondition("ExtendFields1", ExtendFields1);
        }

        /// <summary>
        /// 设 扩展字段2 条件
        /// </summary>
        /// <param name="ExtendFields2">扩展字段2</param>
        public void SetExtendFields2(string ExtendFields2)
        {
            AddCondition("ExtendFields2", ExtendFields2);
        }

        /// <summary>
        /// 设 扩展字段3 条件
        /// </summary>
        /// <param name="ExtendFields3">扩展字段3</param>
        public void SetExtendFields3(string ExtendFields3)
        {
            AddCondition("ExtendFields3", ExtendFields3);
        }

        /// <summary>
        /// 设 开始使用时间 条件
        /// </summary>
        /// <param name="CreateTime">开始使用时间</param>
        public void SetCreateTime(DateTime CreateTime)
        {
            AddCondition("CreateTime", CreateTime);
        }
        /// <summary>
        /// 设 开始使用时间 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetCreateTime(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("CreateTime", StartDate, EndDate);
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
    /// LayoutInfo 排序比较器
    /// </summary>
    public class ComparerLayoutInfo : IComparer
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
        public ComparerLayoutInfo(string sortField)
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
            LayoutInfo x1, y1;

            x1 = (LayoutInfo)x;
            y1 = (LayoutInfo)y;

            switch (_sortField)
            {
                default:
                    throw new Exception("未知的排序字段 " + _sortField);
                //break;
            }

            return ret;
        }

        #endregion
    }
}