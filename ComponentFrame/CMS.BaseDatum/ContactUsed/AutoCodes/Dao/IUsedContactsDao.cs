﻿#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/9/22 10:05:30 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IUsedContactsDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.UsedContactsDao, PengeSoft.CMS.BaseDatum" />
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
    /// IUsedContactsDao接口定主义。
    /// </summary>
    public interface IUsedContactsDao : IDataProviderEx
    {
    }

    /// <summary>
    /// UsedContactsDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class UsedContactsDao : BaseSqlMapDao, IUsedContactsDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(UsedContacts Data, string Order)
        {
            return new UsedContactsQueryPara(Data, Order);
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
            return QueryCount("QueryUsedContactsCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as UsedContacts, null);

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
            Hashtable para = GetParaHashTable(Data as UsedContacts, OrderByField);

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
                statementName = "QueryUsedContactsList";
            else
                statementName = "QueryUsedContactsList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertUsedContacts", Data);
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
            return Update("UpdateUsedContacts", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateUsedContacts", Data, detail);
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
                statementName = "GetUsedContacts";
            else
                statementName = "GetUsedContacts";
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
            return (UsedContacts)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteUsedContacts", Data);
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
    /// UsedContacts 查询参数
    /// </summary>
    public class UsedContactsQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按UseTimes排序</summary>
        public const string OrderByUseTimes = "UseTimes";
        /// <summary>按UseTimes排序,降序</summary>
        public const string OrderByUseTimes_desc = "UseTimes_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 COwner 条件键名称</summary>
        public const string QueryKey_COwner = "COwner";
        /// <summary>查询 ContactUserID 条件键名称</summary>
        public const string QueryKey_ContactUserID = "ContactUserID";
        /// <summary>查询 ContactUserXM 条件键名称</summary>
        public const string QueryKey_ContactUserXM = "ContactUserXM";
        /// <summary>查询 TaskName 条件键名称</summary>
        public const string QueryKey_TaskName = "TaskName";
        /// <summary>查询 StepName 条件键名称</summary>
        public const string QueryKey_StepName = "StepName";
        /// <summary>查询 CType 条件键名称</summary>
        public const string QueryKey_CType = "CType";
        /// <summary>查询 CType 条件IN键名称</summary>
        public const string QueryKey_CType_IN = "CType_IN";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UsedContactsQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public UsedContactsQueryPara(UsedContacts data, string order)
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
        public void SetQueryPara(UsedContacts data, string order)
        {
            if (data != null)
            {
                SetCOwner(data.COwner);
                SetContactUserID(data.ContactUserID);
                SetContactUserXM(data.ContactUserXM);
                SetTaskName(data.TaskName);
                SetStepName(data.StepName);
                SetCType(data.CType);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 所有人 条件
        /// </summary>
        /// <param name="COwner">所有人</param>
        public void SetCOwner(string COwner)
        {
            AddCondition("COwner", COwner);
        }

        /// <summary>
        /// 设 联系人ID 条件
        /// </summary>
        /// <param name="ContactUserID">联系人ID</param>
        public void SetContactUserID(string ContactUserID)
        {
            AddCondition("ContactUserID", ContactUserID);
        }

        /// <summary>
        /// 设 联系人姓名 条件
        /// </summary>
        /// <param name="ContactUserXM">联系人姓名</param>
        public void SetContactUserXM(string ContactUserXM)
        {
            AddCondition("ContactUserXM", ContactUserXM);
        }

        /// <summary>
        /// 设 任务名 条件
        /// </summary>
        /// <param name="TaskName">任务名</param>
        public void SetTaskName(string TaskName)
        {
            AddCondition("TaskName", TaskName);
        }

        /// <summary>
        /// 设 步骤名 条件
        /// </summary>
        /// <param name="StepName">步骤名</param>
        public void SetStepName(string StepName)
        {
            AddCondition("StepName", StepName);
        }

        /// <summary>
        /// 设 类型 非零值条件
        /// </summary>
        /// <param name="CType">类型</param>
        public void SetCType(int CType)
        {
            AddConditionNonzero("CType", CType);
        }
        /// <summary>
        /// 设 类型 条件(包含零值)
        /// </summary>
        /// <param name="CType">类型</param>
        public void SetCType_InZero(int CType)
        {
            AddCondition("CType", CType);
        }
        /// <summary>
        /// 设 类型 枚举值条件
        /// </summary>
        /// <param name="CType">类型</param>
        public void SetCType_In(int[] CTypes)
        {
            string value = "";
            foreach (int val in CTypes)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("CType_IN", value);
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
    /// UsedContacts 排序比较器
    /// </summary>
    public class ComparerUsedContacts : IComparer
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
        public ComparerUsedContacts(string sortField)
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
            UsedContacts x1, y1;

            x1 = (UsedContacts)x;
            y1 = (UsedContacts)y;

            switch (_sortField)
            {
                case UsedContactsQueryPara.OrderByUseTimes:
                    ret = Comparer.Default.Compare(x1.UseTimes, y1.UseTimes);
                    break;
                case UsedContactsQueryPara.OrderByUseTimes_desc:
                    ret = Comparer.Default.Compare(y1.UseTimes, x1.UseTimes);
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