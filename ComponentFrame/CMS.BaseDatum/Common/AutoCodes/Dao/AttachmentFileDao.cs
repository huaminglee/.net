#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 褚海峰 
 * 创建时间 : 2010-7-22 15:21:14 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
        interface="PengeSoft.CMS.BaseDatum.IAttachmentFileDao, PengeSoft.CMS.BaseDatum"
        implementation="PengeSoft.CMS.BaseDatum.AttachmentFileDao, PengeSoft.CMS.BaseDatum" />
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
    /// IAttachmentFileDao接口定主义。
    /// </summary>
    public interface IAttachmentFileDao : IDataProviderEx
    {
    }

    /// <summary>
    /// AttachmentFileDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class AttachmentFileDao : BaseSqlMapDao, IAttachmentFileDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(AttachmentFile Data, string Order)
        {
            return new AttachmentFileQueryPara(Data, Order);
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
            return QueryCount("QueryAttachmentFileCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as AttachmentFile, null);

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
            Hashtable para = GetParaHashTable(Data as AttachmentFile, OrderByField);

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
                statementName = "QueryAttachmentFileList";
            else
                statementName = "QueryAttachmentFileListBase";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertAttachmentFile", Data);
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
            return Update("UpdateAttachmentFile", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateAttachmentFile", Data, detail);
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
                statementName = "GetAttachmentFile";
            else
                statementName = "GetAttachmentFileBase";
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
            return (AttachmentFile)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteAttachmentFile", Data);
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
    /// AttachmentFile 查询参数
    /// </summary>
    public class AttachmentFileQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按FileId排序</summary>
        public const string OrderByFileId = "FileId";
        /// <summary>按FileId排序,降序</summary>
        public const string OrderByFileId_desc = "FileId_D";
        /// <summary>按FileContent排序</summary>
        public const string OrderByFileContent = "FileContent";
        /// <summary>按FileContent排序,降序</summary>
        public const string OrderByFileContent_desc = "FileContent_D";
        /// <summary>按OCRContent排序</summary>
        public const string OrderByOCRContent = "OCRContent";
        /// <summary>按OCRContent排序,降序</summary>
        public const string OrderByOCRContent_desc = "OCRContent_D";
        /// <summary>按FileType排序</summary>
        public const string OrderByFileType = "FileType";
        /// <summary>按FileType排序,降序</summary>
        public const string OrderByFileType_desc = "FileType_D";
        /// <summary>按IsOCRed排序</summary>
        public const string OrderByIsOCRed = "IsOCRed";
        /// <summary>按IsOCRed排序,降序</summary>
        public const string OrderByIsOCRed_desc = "IsOCRed_D";
        /// <summary>按CreateTime排序</summary>
        public const string OrderByCreateTime = "CreateTime";
        /// <summary>按CreateTime排序,降序</summary>
        public const string OrderByCreateTime_desc = "CreateTime_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 FileId 条件键名称</summary>
        public const string QueryKey_FileId = "FileId";
        /// <summary>查询 FileContent 条件键名称</summary>
        public const string QueryKey_FileContent = "FileContent";
        /// <summary>查询 OCRContent 条件键名称</summary>
        public const string QueryKey_OCRContent = "OCRContent";
        /// <summary>查询 FileType 条件键名称</summary>
        public const string QueryKey_FileType = "FileType";
        /// <summary>查询 IsOCRed 条件键名称</summary>
        public const string QueryKey_IsOCRed = "IsOCRed";
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
        public AttachmentFileQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public AttachmentFileQueryPara(AttachmentFile data, string order)
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
        public void SetQueryPara(AttachmentFile data, string order)
        {
            if (data != null)
            {
                SetFileId(data.FileId);
                SetFileContent(data.FileContent);
                SetOCRContent(data.OCRContent);
                SetFileType(data.FileType);
                SetIsOCRed(data.IsOCRed);
                SetCreateTime(data.CreateTime);
            }
            SetOrderByField(order);
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
        /// 设 文件内容 条件
        /// </summary>
        /// <param name="FileContent">文件内容</param>
        public void SetFileContent(byte[] FileContent)
        {
            AddCondition("FileContent", FileContent);
        }

        /// <summary>
        /// 设 OCR内容 条件
        /// </summary>
        /// <param name="OCRContent">OCR内容</param>
        public void SetOCRContent(string OCRContent)
        {
            AddCondition("OCRContent", OCRContent);
        }

        /// <summary>
        /// 设 文件类型 条件
        /// </summary>
        /// <param name="FileType">文件类型</param>
        public void SetFileType(string FileType)
        {
            AddCondition("FileType", FileType);
        }

        /// <summary>
        /// 设 是否OCR 非零值条件
        /// </summary>
        /// <param name="IsOCRed">是否OCR</param>
        public void SetIsOCRed(int IsOCRed)
        {
            AddConditionNonzero("IsOCRed", IsOCRed);
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
    /// AttachmentFile 排序比较器
    /// </summary>
    public class ComparerAttachmentFile : IComparer
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
        public ComparerAttachmentFile(string sortField)
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
            AttachmentFile x1, y1;

            x1 = (AttachmentFile)x;
            y1 = (AttachmentFile)y;

            switch (_sortField)
            {
                case AttachmentFileQueryPara.OrderByFileId:
                    ret = string.Compare(x1.FileId, y1.FileId);
                    break;
                case AttachmentFileQueryPara.OrderByFileId_desc:
                    ret = string.Compare(y1.FileId, x1.FileId);
                    break;
                case AttachmentFileQueryPara.OrderByFileContent:
                    ret = Comparer.Default.Compare(x1.FileContent, y1.FileContent);
                    break;
                case AttachmentFileQueryPara.OrderByFileContent_desc:
                    ret = Comparer.Default.Compare(y1.FileContent, x1.FileContent);
                    break;
                case AttachmentFileQueryPara.OrderByOCRContent:
                    ret = string.Compare(x1.OCRContent, y1.OCRContent);
                    break;
                case AttachmentFileQueryPara.OrderByOCRContent_desc:
                    ret = string.Compare(y1.OCRContent, x1.OCRContent);
                    break;
                case AttachmentFileQueryPara.OrderByFileType:
                    ret = string.Compare(x1.FileType, y1.FileType);
                    break;
                case AttachmentFileQueryPara.OrderByFileType_desc:
                    ret = string.Compare(y1.FileType, x1.FileType);
                    break;
                case AttachmentFileQueryPara.OrderByIsOCRed:
                    ret = Comparer.Default.Compare(x1.IsOCRed, y1.IsOCRed);
                    break;
                case AttachmentFileQueryPara.OrderByIsOCRed_desc:
                    ret = Comparer.Default.Compare(y1.IsOCRed, x1.IsOCRed);
                    break;
                case AttachmentFileQueryPara.OrderByCreateTime:
                    ret = DateTime.Compare(x1.CreateTime, y1.CreateTime);
                    break;
                case AttachmentFileQueryPara.OrderByCreateTime_desc:
                    ret = DateTime.Compare(y1.CreateTime, x1.CreateTime);
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