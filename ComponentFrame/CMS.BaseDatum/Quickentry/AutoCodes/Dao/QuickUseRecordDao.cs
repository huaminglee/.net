#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2015/1/20 9:30:41 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IQuickUseRecordDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.QuickUseRecordDao, PengeSoft.CMS.BaseDatum" />
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
    /// IQuickUseRecordDao�ӿڶ����塣
    /// </summary>
    public interface IQuickUseRecordDao : IDataProviderEx
    {
    }

    /// <summary>
    /// QuickUseRecordDaoʵ��, ��BaseSqlMapDao�̳С�
    /// </summary>
    public class QuickUseRecordDao : BaseSqlMapDao, IQuickUseRecordDao
    {
        #region ��������

        /// <summary>
        /// ������������ȡ������ Hashtable
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Order">�����ֶ�</param>
        /// <returns>����Hashtable</returns>
        public static QueryParameter GetParaHashTable(QuickUseRecord Data, string Order)
        {
            return new QuickUseRecordQueryPara(Data, Order);
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
            return QueryCount("QueryQuickUseRecordCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as QuickUseRecord, null);

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
            Hashtable para = GetParaHashTable(Data as QuickUseRecord, OrderByField);

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
                statementName = "QueryQuickUseRecordList";
            else
                statementName = "QueryQuickUseRecordList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertQuickUseRecord", Data);
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

            return ret;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateQuickUseRecord", Data);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateQuickUseRecord", Data, detail);
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
                statementName = "GetQuickUseRecord";
            else
                statementName = "GetQuickUseRecord";
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
            return (QuickUseRecord)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="Data">��������</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteQuickUseRecord", Data);
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
    /// QuickUseRecord ��ѯ����
    /// </summary>
    public class QuickUseRecordQueryPara : QueryParameter
    {
        #region ������

        /// <summary>��UseTimes����</summary>
        public const string OrderByUseTimes = "UseTimes";
        /// <summary>��UseTimes����,����</summary>
        public const string OrderByUseTimes_desc = "UseTimes_D";

        #endregion

        #region ��ѯ��������

        /// <summary>��ѯ Uid ����������</summary>
        public const string QueryKey_Uid = "Uid";
        /// <summary>��ѯ Qid ����������</summary>
        public const string QueryKey_Qid = "Qid";
        /// <summary>��ѯ Qid ����IN������</summary>
        public const string QueryKey_Qid_IN = "Qid_IN";
        /// <summary>��ѯ UseTimes ����������</summary>
        public const string QueryKey_UseTimes = "UseTimes";
        /// <summary>��ѯ UseTimes ����IN������</summary>
        public const string QueryKey_UseTimes_IN = "UseTimes_IN";
        /// <summary>��ѯ Qtype ����������</summary>
        public const string QueryKey_Qtype = "Qtype";
        /// <summary>��ѯ Qtype ����IN������</summary>
        public const string QueryKey_Qtype_IN = "Qtype_IN";

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public QuickUseRecordQueryPara()
        {
        }

        /// <summary>
        /// ���캯��,ָ���������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public QuickUseRecordQueryPara(QuickUseRecord data, string order)
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
        public void SetQueryPara(QuickUseRecord data, string order)
        {
            if (data != null)
            {
                SetUid(data.Uid);
                SetQid(data.Qid);
                SetUseTimes(data.UseTimes);
                SetQtype(data.Qtype);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// �� �û�id ����
        /// </summary>
        /// <param name="Uid">�û�id</param>
        public void SetUid(string Uid)
        {
            AddCondition("Uid", Uid);
        }

        /// <summary>
        /// �� ���id ����ֵ����
        /// </summary>
        /// <param name="Qid">���id</param>
        public void SetQid(int Qid)
        {
            AddConditionNonzero("Qid", Qid);
        }
        /// <summary>
        /// �� ���id ����(������ֵ)
        /// </summary>
        /// <param name="Qid">���id</param>
        public void SetQid_InZero(int Qid)
        {
            AddCondition("Qid", Qid);
        }
        /// <summary>
        /// �� ���id ö��ֵ����
        /// </summary>
        /// <param name="Qid">���id</param>
        public void SetQid_In(int[] Qids)
        {
            string value = "";
            foreach (int val in Qids)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("Qid_IN", value);
        }

        /// <summary>
        /// �� ʹ�ô��� ����ֵ����
        /// </summary>
        /// <param name="UseTimes">ʹ�ô���</param>
        public void SetUseTimes(int UseTimes)
        {
            AddConditionNonzero("UseTimes", UseTimes);
        }
        /// <summary>
        /// �� ʹ�ô��� ����(������ֵ)
        /// </summary>
        /// <param name="UseTimes">ʹ�ô���</param>
        public void SetUseTimes_InZero(int UseTimes)
        {
            AddCondition("UseTimes", UseTimes);
        }
        /// <summary>
        /// �� ʹ�ô��� ö��ֵ����
        /// </summary>
        /// <param name="UseTimes">ʹ�ô���</param>
        public void SetUseTimes_In(int[] UseTimess)
        {
            string value = "";
            foreach (int val in UseTimess)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("UseTimes_IN", value);
        }

        /// <summary>
        /// �� ������� ����ֵ����
        /// </summary>
        /// <param name="Qtype">�������</param>
        public void SetQtype(int Qtype)
        {
            AddConditionNonzero("Qtype", Qtype);
        }
        /// <summary>
        /// �� ������� ����(������ֵ)
        /// </summary>
        /// <param name="Qtype">�������</param>
        public void SetQtype_InZero(int Qtype)
        {
            AddCondition("Qtype", Qtype);
        }
        /// <summary>
        /// �� ������� ö��ֵ����
        /// </summary>
        /// <param name="Qtype">�������</param>
        public void SetQtype_In(int[] Qtypes)
        {
            string value = "";
            foreach (int val in Qtypes)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("Qtype_IN", value);
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
    /// QuickUseRecord ����Ƚ���
    /// </summary>
    public class ComparerQuickUseRecord : IComparer
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
        public ComparerQuickUseRecord(string sortField)
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
            QuickUseRecord x1, y1;

            x1 = (QuickUseRecord)x;
            y1 = (QuickUseRecord)y;

            switch (_sortField)
            {
                case QuickUseRecordQueryPara.OrderByUseTimes:
                    ret = Comparer.Default.Compare(x1.UseTimes, y1.UseTimes);
                    break;
                case QuickUseRecordQueryPara.OrderByUseTimes_desc:
                    ret = Comparer.Default.Compare(y1.UseTimes, x1.UseTimes);
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