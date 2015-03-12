#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 罗坤 
 * 创建时间 : 2015/1/23 11:25:03 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IMessageDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.MessageDao, PengeSoft.CMS.BaseDatum" />
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
    /// IMessageDao接口定主义。
    /// </summary>
    public interface IMessageDao : IDataProviderEx
    {
        /// <summary>
        /// 插入系统消息
        /// </summary>
        /// <param name="insertPar">插入数据</param>
        /// <returns></returns>
        int InsertMessages(Hashtable insertPar);
        /// <summary>
        /// 查询指定UID和状态的消息总数
        /// </summary>
        /// <param name="queryPara">查询参数</param>
        /// <returns></returns>
        int QueryMessageCount(Hashtable queryPara);
        /// <summary>
        /// 分页查询消息列表
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <returns>列表</returns>
        DataList QueryMessageList(Hashtable queryPar, int Start, int PageSize);
        /// <summary>
        /// 标记接收消息
        /// </summary>
        /// <param name="dataPar"></param>
        /// <returns></returns>
        int UpdateMessage(Hashtable dataPar);
        /// <summary>
        /// 删除接收消息
        /// </summary>
        /// <param name="dataPar"></param>
        void DeleteMessage(Hashtable dataPar);
    }
    
    /// <summary>
    /// MessageDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class MessageDao : BaseSqlMapDao,IMessageDao 
    {
        #region 公共函数
        
        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(Message Data, string Order)
        {
            return new MessageQueryPara(Data, Order);
        }

        #endregion

        #region IPagedDataProvider 成员

        /// <summary>
        /// 查询指定UID和状态的消息总数
        /// </summary>
        /// <param name="queryPara">查询参数</param>
        /// <returns></returns>
        public int QueryMessageCount(Hashtable queryPara)
        {
            return QueryCount("QueryMessagesCount", queryPara);
        }

        /// <summary>
        /// 查询记录数,条件表参见 <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <returns>记录数</returns>
        public int QueryCount(Hashtable queryPara)
        {
            return QueryCount("QueryMessageCount", queryPara);
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
            Hashtable para = GetParaHashTable(Data as Message, null);

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
            Hashtable para = GetParaHashTable(Data as Message, OrderByField);

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
                statementName = "QueryMessageList";
            else
                statementName = "QueryMessageList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }
         /// <summary>
        /// 分页查询消息列表
        /// </summary>
        /// <param name="queryPar">条件表</param>
        /// <param name="Start">起始记录</param>
        /// <param name="PageSize">页长度</param>
        /// <returns>列表</returns>
        public DataList QueryMessageList(Hashtable queryPar, int Start, int PageSize)
        {
            return QueryList("QueryMessagesList", queryPar, Start, PageSize);
        }
        /// <summary>
        /// 插入系统消息
        /// </summary>
        /// <param name="insertPar">插入数据</param>
        /// <returns></returns>
        public int InsertMessages(Hashtable insertPar)
        {
            object ret = ExecuteInsert("InsertMessages", insertPar);
            return (int)ret;
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertMessage", Data);
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
            ((Message)Data).Guid = (int)ret;

            return ret;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateMessage", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateMessage", Data, detail);
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
        /// 标记接收消息
        /// </summary>
        /// <param name="dataPar"></param>
        /// <returns></returns>
        public int UpdateMessage(Hashtable dataPar)
        {
            int ret = ExecuteUpdate("UpdateMyMessage", dataPar);

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
                statementName = "GetMessage";
            else
                statementName = "GetMessage";
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
            return (Message)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteMessage", Data);
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

        /// <summary>
        /// 删除接收消息
        /// </summary>
        /// <param name="dataPar"></param>
        public void DeleteMessage(Hashtable dataPar)
        {
            ExecuteDelete("DeleteMyMessage", dataPar);
        }
        #endregion
    }
    
    /// <summary>
    /// Message 查询参数
    /// </summary>
    public class MessageQueryPara : QueryParameter
    {
        #region 排序常量
        
        /// <summary>按CreateDate排序</summary>
        public const string OrderByCreateDate = "CreateDate";
        /// <summary>按CreateDate排序,降序</summary>
        public const string OrderByCreateDate_desc = "CreateDate_D";

        #endregion

        #region 查询条件常量
        
        /// <summary>查询 Sender 条件键名称</summary>
        public const string QueryKey_Sender = "Sender";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MessageQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public MessageQueryPara(Message data, string order)
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
        public void SetQueryPara(Message data, string order)
        {
            if (data != null)
            {
                SetSender(data.Sender);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 发送人 条件
        /// </summary>
        /// <param name="Sender">发送人</param>
        public void SetSender(string Sender)
        {
            AddCondition("Sender", Sender);
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
    /// Message 排序比较器
    /// </summary>
    public class ComparerMessage : IComparer
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
        public ComparerMessage(string sortField)
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
            Message x1, y1;

            x1 = (Message)x;
            y1 = (Message)y;

            switch (_sortField)
            {
                case MessageQueryPara.OrderByCreateDate:
                    ret = DateTime.Compare(x1.CreateDate, y1.CreateDate);
                    break;
                case MessageQueryPara.OrderByCreateDate_desc:
                    ret = DateTime.Compare(y1.CreateDate, x1.CreateDate);
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
