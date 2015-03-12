#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/19 13:56:15 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IQuickentryDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.QuickentryDao, PengeSoft.CMS.BaseDatum" />
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
    /// IQuickentryDao�ӿڶ����塣
    /// </summary>
    public interface IQuickentryDao : IDataProviderEx
    {
    }
    
    /// <summary>
    /// QuickentryDaoʵ��, ��BaseSqlMapDao�̳С�
    /// </summary>
    public class QuickentryDao : BaseSqlMapDao,IQuickentryDao 
    {
        #region ��������
        
        /// <summary>
        /// ������������ȡ������ Hashtable
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Order">�����ֶ�</param>
        /// <returns>����Hashtable</returns>
        public static QueryParameter GetParaHashTable(Quickentry Data, string Order)
        {
            return new QuickentryQueryPara(Data, Order);
        }

        #endregion

        #region IPagedDataProvider ��Ա

        /// <summary>
        /// ��ѯ��¼��,������μ� <see cref="PengeSoft.db.IDataProvider"/>
        /// </summary>
        /// <param name="queryPar">������</param>
        /// <returns>��¼��</returns>
        public int QueryCount(Hashtable queryPar)
        {
            return QueryCount("QueryQuickentryCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as Quickentry, null);

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
            Hashtable para = GetParaHashTable(Data as Quickentry, OrderByField);

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
                statementName = "QueryQuickentryList";
            else
                statementName = "QueryQuickentryList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertQuickentry", Data);
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
            ((Quickentry)Data).QId = (int)ret;

            return ret;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateQuickentry", Data);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateQuickentry", Data, detail);
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
                statementName = "GetQuickentry";
            else
                statementName = "GetQuickentry";
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
            return (Quickentry)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="Data">��������</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteQuickentry", Data);
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

        #endregion
    }
    
    /// <summary>
    /// Quickentry ��ѯ����
    /// </summary>
    public class QuickentryQueryPara : QueryParameter
    {
        #region ������
        
        /// <summary>��DefaultSort����</summary>
        public const string OrderByDefaultSort = "DefaultSort";
        /// <summary>��DefaultSort����,����</summary>
        public const string OrderByDefaultSort_desc = "DefaultSort_D";

        #endregion

        #region ��ѯ��������
        
        /// <summary>��ѯ QId ����������</summary>
        public const string QueryKey_QId = "QId";
        /// <summary>��ѯ QId ����IN������</summary>
        public const string QueryKey_QId_IN = "QId_IN";
        /// <summary>��ѯ QName ����������</summary>
        public const string QueryKey_QName = "QName";
        /// <summary>��ѯ QType ����������</summary>
        public const string QueryKey_QType = "QType";
        /// <summary>��ѯ QType ����IN������</summary>
        public const string QueryKey_QType_IN = "QType_IN";

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public QuickentryQueryPara()
        {
        }

        /// <summary>
        /// ���캯��,ָ���������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public QuickentryQueryPara(Quickentry data, string order)
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
        public void SetQueryPara(Quickentry data, string order)
        {
            if (data != null)
            {
                SetQId(data.QId);
                SetQName(data.QName);
                SetQType(data.QType);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// �� id ����ֵ����
        /// </summary>
        /// <param name="QId">id</param>
        public void SetQId(int QId)
        {
            AddConditionNonzero("QId", QId);
        }
        /// <summary>
        /// �� id ����(������ֵ)
        /// </summary>
        /// <param name="QId">id</param>
        public void SetQId_InZero(int QId)
        {
            AddCondition("QId", QId);
        }
        /// <summary>
        /// �� id ö��ֵ����
        /// </summary>
        /// <param name="QId">id</param>
        public void SetQId_In(int[] QIds)
        {
            string value = "";
            foreach(int val in QIds)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("QId_IN", value);
        }
        public void SetQId_NotIn(int[] QIds)
        {
            string value = "";
            foreach (int val in QIds)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("QId_NotIN", value);
        }

        /// <summary>
        /// �� ���� ����
        /// </summary>
        /// <param name="QName">����</param>
        public void SetQName(string QName)
        {
            AddCondition("QName", QName);
        }

        /// <summary>
        /// �� ���� ����ֵ����
        /// </summary>
        /// <param name="QType">����</param>
        public void SetQType(int QType)
        {
            AddConditionNonzero("QType", QType);
        }
        /// <summary>
        /// �� ���� ����(������ֵ)
        /// </summary>
        /// <param name="QType">����</param>
        public void SetQType_InZero(int QType)
        {
            AddCondition("QType", QType);
        }
        /// <summary>
        /// �� ���� ö��ֵ����
        /// </summary>
        /// <param name="QType">����</param>
        public void SetQType_In(int[] QTypes)
        {
            string value = "";
            foreach(int val in QTypes)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("QType_IN", value);
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
    /// Quickentry ����Ƚ���
    /// </summary>
    public class ComparerQuickentry : IComparer
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
        public ComparerQuickentry(string sortField)
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
            Quickentry x1, y1;

            x1 = (Quickentry)x;
            y1 = (Quickentry)y;

            switch (_sortField)
            {
                case QuickentryQueryPara.OrderByDefaultSort:
                    ret = Comparer.Default.Compare(x1.DefaultSort, y1.DefaultSort);
                    break;
                case QuickentryQueryPara.OrderByDefaultSort_desc:
                    ret = Comparer.Default.Compare(y1.DefaultSort, x1.DefaultSort);
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
