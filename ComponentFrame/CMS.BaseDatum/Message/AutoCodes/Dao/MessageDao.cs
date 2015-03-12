#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���� 
 * ����ʱ�� : 2015/1/23 11:25:03 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
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
    /// IMessageDao�ӿڶ����塣
    /// </summary>
    public interface IMessageDao : IDataProviderEx
    {
        /// <summary>
        /// ����ϵͳ��Ϣ
        /// </summary>
        /// <param name="insertPar">��������</param>
        /// <returns></returns>
        int InsertMessages(Hashtable insertPar);
        /// <summary>
        /// ��ѯָ��UID��״̬����Ϣ����
        /// </summary>
        /// <param name="queryPara">��ѯ����</param>
        /// <returns></returns>
        int QueryMessageCount(Hashtable queryPara);
        /// <summary>
        /// ��ҳ��ѯ��Ϣ�б�
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <returns>�б�</returns>
        DataList QueryMessageList(Hashtable queryPar, int Start, int PageSize);
        /// <summary>
        /// ��ǽ�����Ϣ
        /// </summary>
        /// <param name="dataPar"></param>
        /// <returns></returns>
        int UpdateMessage(Hashtable dataPar);
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="dataPar"></param>
        void DeleteMessage(Hashtable dataPar);
    }
    
    /// <summary>
    /// MessageDaoʵ��, ��BaseSqlMapDao�̳С�
    /// </summary>
    public class MessageDao : BaseSqlMapDao,IMessageDao 
    {
        #region ��������
        
        /// <summary>
        /// ������������ȡ������ Hashtable
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Order">�����ֶ�</param>
        /// <returns>����Hashtable</returns>
        public static QueryParameter GetParaHashTable(Message Data, string Order)
        {
            return new MessageQueryPara(Data, Order);
        }

        #endregion

        #region IPagedDataProvider ��Ա

        /// <summary>
        /// ��ѯָ��UID��״̬����Ϣ����
        /// </summary>
        /// <param name="queryPara">��ѯ����</param>
        /// <returns></returns>
        public int QueryMessageCount(Hashtable queryPara)
        {
            return QueryCount("QueryMessagesCount", queryPara);
        }

        /// <summary>
        /// ��ѯ��¼��,������μ� <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <returns>��¼��</returns>
        public int QueryCount(Hashtable queryPara)
        {
            return QueryCount("QueryMessageCount", queryPara);
        }

        /// <summary>
        /// ��ѯ��¼��
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="queryPara">��ѯ��������</param>
        /// <returns>��¼��</returns>
        public int QueryCount(string statementName, Hashtable queryPara)
        {
            return (int)ExecuteQueryForObject(statementName, queryPara);
        }

        /// <summary>
        /// ��ѯ�б�,������μ� <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <returns>�б�</returns>
        public DataList QueryList(Hashtable queryPar, int Start, int PageSize)
        {
            return QueryList(queryPar, Start, PageSize, true);
        }

        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="queryPara">��ѯ��������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <returns>�б�</returns>
        public DataList QueryList(string statementName, Hashtable queryPara, int Start, int PageSize)
        {
            NorDataList list = (NorDataList)ExecuteQueryForList(statementName, queryPara, Start, PageSize);

            return list;
        }

        #endregion

        #region IDataProviderEx ��Ա

        /// <summary>
        /// ȡ��¼��
        /// </summary>
        public int GetCount()
        {
            Hashtable para = GetParaHashTable(null, null);

            return QueryCount(para);
        }

        /// <summary>
        /// ȡ�б�
        /// </summary>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <param name="OrderByField">�����ֶ�</param>
        public DataList GetList(int Start, int PageSize, string OrderByField)
        {
            Hashtable para = GetParaHashTable(null, OrderByField);

            return QueryList(para, Start, PageSize);
        }

        /// <summary>
        /// ��ѯ��¼��
        /// </summary>
        /// <param name="Data">��������</param>
        /// <returns>��¼��</returns>
        public int QueryCount(DataPacket Data)
        {
            Hashtable para = GetParaHashTable(Data as Message, null);

            return QueryCount(para);
        }

        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <returns>�б�</returns>
        /// <param name="OrderByField">�����ֶ�</param>
        public DataList QueryList(DataPacket Data, int Start, int PageSize, string OrderByField)
        {
            Hashtable para = GetParaHashTable(Data as Message, OrderByField);

            return QueryList(para, Start, PageSize);
        }

        /// <summary>
        /// ��ѯ�б�,������μ� <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <param name="detail">ȡ��ϸ����</param>
        /// <returns>�б�</returns>
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
        /// ��ҳ��ѯ��Ϣ�б�
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <param name="Start">��ʼ��¼</param>
        /// <param name="PageSize">ҳ����</param>
        /// <returns>�б�</returns>
        public DataList QueryMessageList(Hashtable queryPar, int Start, int PageSize)
        {
            return QueryList("QueryMessagesList", queryPar, Start, PageSize);
        }
        /// <summary>
        /// ����ϵͳ��Ϣ
        /// </summary>
        /// <param name="insertPar">��������</param>
        /// <returns></returns>
        public int InsertMessages(Hashtable insertPar)
        {
            object ret = ExecuteInsert("InsertMessages", insertPar);
            return (int)ret;
        }
        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertMessage", Data);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(string statementName, DataPacket Data)
        {
            object ret = ExecuteInsert(statementName, Data);
            ((Message)Data).Guid = (int)ret;

            return ret;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateMessage", Data);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateMessage", Data, detail);
        }

        /// <summary>
        /// ���¼�¼, ָ�� sqlMap ӳ�����
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���¼�¼��</returns>
        public int Update(string statementName, DataPacket Data)
        {
            return Update(statementName, Data, true);
        }

        /// <summary>
        /// ���¼�¼, ָ�� sqlMap ӳ�����
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>���¼�¼��</returns>
        public int Update(string statementName, DataPacket Data, bool detail)
        {
            int ret = ExecuteUpdate(statementName, Data);

            return ret;
        }

        /// <summary>
        /// ��ǽ�����Ϣ
        /// </summary>
        /// <param name="dataPar"></param>
        /// <returns></returns>
        public int UpdateMessage(Hashtable dataPar)
        {
            int ret = ExecuteUpdate("UpdateMyMessage", dataPar);

            return ret;
        }


        /// <summary>
        /// ȡ��ϸ����
        /// </summary>
        /// <param name="data">��������</param>
        /// <returns>���ݶ���</returns>
        public DataPacket GetDetail(DataPacket data)
        {
            return GetDetail(data, true);
        }

        /// <summary>
        /// ȡ����
        /// </summary>
        /// <param name="data">��������</param>
        /// <param name="detail">ȡ��ϸ����</param>
        /// <returns>���ݶ���</returns>
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
        /// ȡ����
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="data">��������</param>
        /// <returns>���ݶ���</returns>
        public DataPacket GetDetail(string statementName, DataPacket Data)
        {
            return (Message)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="Data">��������</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteMessage", Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="statementName">sqlMap ӳ�����</param>
        /// <param name="Data">��������</param>
        public void Delete(string statementName, DataPacket Data)
        {
            ExecuteDelete(statementName, Data);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="dataPar"></param>
        public void DeleteMessage(Hashtable dataPar)
        {
            ExecuteDelete("DeleteMyMessage", dataPar);
        }
        #endregion
    }
    
    /// <summary>
    /// Message ��ѯ����
    /// </summary>
    public class MessageQueryPara : QueryParameter
    {
        #region ������
        
        /// <summary>��CreateDate����</summary>
        public const string OrderByCreateDate = "CreateDate";
        /// <summary>��CreateDate����,����</summary>
        public const string OrderByCreateDate_desc = "CreateDate_D";

        #endregion

        #region ��ѯ��������
        
        /// <summary>��ѯ Sender ����������</summary>
        public const string QueryKey_Sender = "Sender";

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public MessageQueryPara()
        {
        }

        /// <summary>
        /// ���캯��,ָ���������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public MessageQueryPara(Message data, string order)
        {
            SetQueryPara(data, order);
        }

        #endregion

        #region ��������
        
        /// <summary>
        /// ָ����ѯ�������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public void SetQueryPara(Message data, string order)
        {
            if (data != null)
            {
                SetSender(data.Sender);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// �� ������ ����
        /// </summary>
        /// <param name="Sender">������</param>
        public void SetSender(string Sender)
        {
            AddCondition("Sender", Sender);
        }

        /// <summary>
        /// �������ֶ�
        /// </summary>
        /// <param name="Order">�����ֶ�</param>
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
    /// Message ����Ƚ���
    /// </summary>
    public class ComparerMessage : IComparer
    {
        #region ˽���ֶ�
        
        private string _sortField;

        #endregion

        #region ����
        
        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string SortField
        {
            get { return _sortField; }
            set { _sortField = value; }
        }

        #endregion

        #region ���캯��
        
        /// <summary>
        /// ����ʵ��,����ʼ�������ֶ�
        /// </summary>
        /// <param name="sortField">�����ֶ�</param>
        public ComparerMessage(string sortField)
        {
            _sortField = sortField;
        }

        #endregion

        #region IComparer ��Ա

        /// <summary>
        /// �Ƚ����� <see cref="Zjjhxmmx"/> ���󲢷���һ��ֵ��ָʾһ��������С�ڡ����ڻ��Ǵ�����һ������
        /// </summary>
        /// <param name="x">Ҫ�Ƚϵĵ�һ������</param>
        /// <param name="y">Ҫ�Ƚϵĵڶ�������</param>
        /// <returns>ֵ ���� С���� x С�� y�� �� x ���� y�� ������ x ���� y��</returns>
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
                    throw new Exception("δ֪�������ֶ� " + _sortField);
                    //break;
            }

            return ret;
        }

        #endregion
    }
}
