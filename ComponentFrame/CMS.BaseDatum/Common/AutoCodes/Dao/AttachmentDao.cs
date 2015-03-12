#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 陈锐(开发) 
 * 创建时间 : 2010-4-27 下午 01:45:43 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
        interface="PengeSoft.CMS.BaseDatum.IAttachmentDao, PengeSoft.CMS.BaseDatum"
        implementation="PengeSoft.CMS.BaseDatum.AttachmentDao, PengeSoft.CMS.BaseDatum" />
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
    /// IAttachmentDao接口定主义。
    /// </summary>
    public interface IAttachmentDao : IDataProviderEx
    {
    }

    /// <summary>
    /// AttachmentDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class AttachmentDao : BaseSqlMapDao, IAttachmentDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(Attachment Data, string Order)
        {
            return new AttachmentQueryPara(Data, Order);
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
            return QueryCount("QueryAttachmentCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as Attachment, null);

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
            Hashtable para = GetParaHashTable(Data as Attachment, OrderByField);

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
                statementName = "QueryAttachmentList";
            else
                statementName = "QueryAttachmentList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertAttachment", Data);
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
            return Update("UpdateAttachment", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateAttachment", Data, detail);
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
                statementName = "GetAttachment";
            else
                statementName = "GetAttachment";
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
            return (Attachment)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteAttachment", Data);
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
    /// Attachment 查询参数
    /// </summary>
    public class AttachmentQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按CreateTime排序</summary>
        public const string OrderByCreateTime = "CreateTime";
        /// <summary>按CreateTime排序,降序</summary>
        public const string OrderByCreateTime_desc = "CreateTime_D";
        /// <summary>按Creator排序</summary>
        public const string OrderByCreator = "Creator";
        /// <summary>按Creator排序,降序</summary>
        public const string OrderByCreator_desc = "Creator_D";
        /// <summary>按FileName排序</summary>
        public const string OrderByFileName = "FileName";
        /// <summary>按FileName排序,降序</summary>
        public const string OrderByFileName_desc = "FileName_D";
        /// <summary>按FileSize排序</summary>
        public const string OrderByFileSize = "FileSize";
        /// <summary>按FileSize排序,降序</summary>
        public const string OrderByFileSize_desc = "FileSize_D";
        /// <summary>按RefID排序</summary>
        public const string OrderByRefID = "RefID";
        /// <summary>按RefID排序,降序</summary>
        public const string OrderByRefID_desc = "RefID_D";
        /// <summary>按RefType排序</summary>
        public const string OrderByRefType = "RefType";
        /// <summary>按RefType排序,降序</summary>
        public const string OrderByRefType_desc = "RefType_D";
        /// <summary>按FileId排序</summary>
        public const string OrderByFileId = "FileId";
        /// <summary>按FileId排序,降序</summary>
        public const string OrderByFileId_desc = "FileId_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 AttachmentId 条件键名称</summary>
        public const string QueryKey_AttachmentId = "AttachmentId";
        /// <summary>查询 CreateTime 条件键名称</summary>
        public const string QueryKey_CreateTime = "CreateTime";
        /// <summary>查询 CreateTime 条件起始日期键名称</summary>
        public const string QueryKey_CreateTime_S = "CreateTime_S";
        /// <summary>查询 CreateTime 条件结束日期键名称</summary>
        public const string QueryKey_CreateTime_E = "CreateTime_E";
        /// <summary>查询 Creator 条件键名称</summary>
        public const string QueryKey_Creator = "Creator";
        /// <summary>查询 FileName 条件键名称</summary>
        public const string QueryKey_FileName = "FileName";
        /// <summary>查询 FileSize 条件键名称</summary>
        public const string QueryKey_FileSize = "FileSize";
        /// <summary>查询 RefID 条件键名称</summary>
        public const string QueryKey_RefID = "RefID";
        /// <summary>查询 RefType 条件键名称</summary>
        public const string QueryKey_RefType = "RefType";
        /// <summary>查询 FileId 条件键名称</summary>
        public const string QueryKey_FileId = "FileId";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public AttachmentQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public AttachmentQueryPara(Attachment data, string order)
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
        public void SetQueryPara(Attachment data, string order)
        {
            if (data != null)
            {
                SetAttachmentId(data.AttachmentId);
                SetCreateTime(data.CreateTime);
                SetCreator(data.Creator);
                SetFileName(data.FileName);
                SetFileSize(data.FileSize);
                SetRefID(data.RefID);
                SetRefType(data.RefType);
                SetFileId(data.FileId);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 ID 条件
        /// </summary>
        /// <param name="AttachmentId">ID</param>
        public void SetAttachmentId(string AttachmentId)
        {
            AddCondition("AttachmentId", AttachmentId);
        }

        /// <summary>
        /// 设 添加时间 条件
        /// </summary>
        /// <param name="CreateTime">添加时间</param>
        public void SetCreateTime(DateTime CreateTime)
        {
            AddCondition("CreateTime", CreateTime);
        }
        /// <summary>
        /// 设 添加时间 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetCreateTime(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("CreateTime", StartDate, EndDate);
        }

        /// <summary>
        /// 设 添加人 条件
        /// </summary>
        /// <param name="Creator">添加人</param>
        public void SetCreator(string Creator)
        {
            AddCondition("Creator", Creator);
        }

        /// <summary>
        /// 设 文件名称 条件
        /// </summary>
        /// <param name="FileName">文件名称</param>
        public void SetFileName(string FileName)
        {
            AddCondition("FileName", FileName);
        }

        /// <summary>
        /// 设 文件大小 非零值条件
        /// </summary>
        /// <param name="FileSize">文件大小</param>
        public void SetFileSize(double FileSize)
        {
            AddConditionNonzero("FileSize", FileSize);
        }

        /// <summary>
        /// 设 外键标识 条件
        /// </summary>
        /// <param name="RefID">外键标识</param>
        public void SetRefID(string RefID)
        {
            AddCondition("RefID", RefID);
        }

        /// <summary>
        /// 设 外键类型 条件
        /// </summary>
        /// <param name="RefType">外键类型</param>
        public void SetRefType(string RefType)
        {
            AddCondition("RefType", RefType);
        }

        /// <summary>
        /// 设 文件ID 条件
        /// </summary>
        /// <param name="FileId">文件ID</param>
        public void SetFileId(string FileId)
        {
            AddCondition("FileId", FileId);
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
    /// Attachment 排序比较器
    /// </summary>
    public class ComparerAttachment : IComparer
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
        public ComparerAttachment(string sortField)
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
            Attachment x1, y1;

            x1 = (Attachment)x;
            y1 = (Attachment)y;

            switch (_sortField)
            {
                case AttachmentQueryPara.OrderByCreateTime:
                    ret = DateTime.Compare(x1.CreateTime, y1.CreateTime);
                    break;
                case AttachmentQueryPara.OrderByCreateTime_desc:
                    ret = DateTime.Compare(y1.CreateTime, x1.CreateTime);
                    break;
                case AttachmentQueryPara.OrderByCreator:
                    ret = string.Compare(x1.Creator, y1.Creator);
                    break;
                case AttachmentQueryPara.OrderByCreator_desc:
                    ret = string.Compare(y1.Creator, x1.Creator);
                    break;
                case AttachmentQueryPara.OrderByFileName:
                    ret = string.Compare(x1.FileName, y1.FileName);
                    break;
                case AttachmentQueryPara.OrderByFileName_desc:
                    ret = string.Compare(y1.FileName, x1.FileName);
                    break;
                case AttachmentQueryPara.OrderByFileSize:
                    ret = Comparer.Default.Compare(x1.FileSize, y1.FileSize);
                    break;
                case AttachmentQueryPara.OrderByFileSize_desc:
                    ret = Comparer.Default.Compare(y1.FileSize, x1.FileSize);
                    break;
                case AttachmentQueryPara.OrderByRefID:
                    ret = string.Compare(x1.RefID, y1.RefID);
                    break;
                case AttachmentQueryPara.OrderByRefID_desc:
                    ret = string.Compare(y1.RefID, x1.RefID);
                    break;
                case AttachmentQueryPara.OrderByRefType:
                    ret = string.Compare(x1.RefType, y1.RefType);
                    break;
                case AttachmentQueryPara.OrderByRefType_desc:
                    ret = string.Compare(y1.RefType, x1.RefType);
                    break;
                case AttachmentQueryPara.OrderByFileId:
                    ret = string.Compare(x1.FileId, y1.FileId);
                    break;
                case AttachmentQueryPara.OrderByFileId_desc:
                    ret = string.Compare(y1.FileId, x1.FileId);
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