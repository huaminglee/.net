#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/20 14:49:13 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IModelInfoDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.ModelInfoDao, PengeSoft.CMS.BaseDatum" />
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
    /// IModelInfoDao�ӿڶ����塣
    /// </summary>
    public interface IModelInfoDao : IDataProviderEx
    {
    }

    /// <summary>
    /// ModelInfoDaoʵ��, ��BaseSqlMapDao�̳С�
    /// </summary>
    public class ModelInfoDao : BaseSqlMapDao, IModelInfoDao
    {
        #region ��������

        /// <summary>
        /// ������������ȡ������ Hashtable
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Order">�����ֶ�</param>
        /// <returns>����Hashtable</returns>
        public static QueryParameter GetParaHashTable(ModelInfo Data, string Order)
        {
            return new ModelInfoQueryPara(Data, Order);
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
            return QueryCount("QueryModelInfoCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as ModelInfo, null);

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
            Hashtable para = GetParaHashTable(Data as ModelInfo, OrderByField);

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
                statementName = "QueryModelInfoList";
            else
                statementName = "QueryModelInfoList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertModelInfo", Data);
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
            ((ModelInfo)Data).MId = (int)ret;

            return ret;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateModelInfo", Data);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateModelInfo", Data, detail);
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
                statementName = "GetModelInfo";
            else
                statementName = "GetModelInfo";
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
            return (ModelInfo)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="Data">��������</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteModelInfo", Data);
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
    /// ModelInfo ��ѯ����
    /// </summary>
    public class ModelInfoQueryPara : QueryParameter
    {
        #region ������

        /// <summary>��MId����</summary>
        public const string OrderByMId = "MId";
        /// <summary>��MId����,����</summary>
        public const string OrderByMId_desc = "MId_D";

        #endregion

        #region ��ѯ��������

        /// <summary>��ѯ MName ����������</summary>
        public const string QueryKey_MName = "MName";
        /// <summary>��ѯ RightLevel ����������</summary>
        public const string QueryKey_RightLevel = "RightLevel";
        /// <summary>��ѯ BelongPage ����������</summary>
        public const string QueryKey_BelongPage = "BelongPage";
        /// <summary>��ѯ ExtendFields1 ����������</summary>
        public const string QueryKey_ExtendFields1 = "ExtendFields1";
        /// <summary>��ѯ ExtendFields2 ����������</summary>
        public const string QueryKey_ExtendFields2 = "ExtendFields2";
        /// <summary>��ѯ ExtendFields3 ����������</summary>
        public const string QueryKey_ExtendFields3 = "ExtendFields3";

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public ModelInfoQueryPara()
        {
        }

        /// <summary>
        /// ���캯��,ָ���������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public ModelInfoQueryPara(ModelInfo data, string order)
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
        public void SetQueryPara(ModelInfo data, string order)
        {
            if (data != null)
            {
                SetMName(data.MName);
                SetRightLevel(data.RightLevel);
                SetBelongPage(data.BelongPage);
                SetExtendFields1(data.ExtendFields1);
                SetExtendFields2(data.ExtendFields2);
                SetExtendFields3(data.ExtendFields3);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// �� ģ������ ����
        /// </summary>
        /// <param name="MName">ģ������</param>
        public void SetMName(string MName)
        {
            AddCondition("MName", MName);
        }

        /// <summary>
        /// �� Ȩ�޵ȼ� ����
        /// </summary>
        /// <param name="RightLevel">Ȩ�޵ȼ�</param>
        public void SetRightLevel(string RightLevel)
        {
            AddCondition("RightLevel", RightLevel);
        }

        /// <summary>
        /// �� ҳ�� ����
        /// </summary>
        /// <param name="BelongPage">ҳ��</param>
        public void SetBelongPage(string BelongPage)
        {
            AddCondition("BelongPage", BelongPage);
        }

        /// <summary>
        /// �� ��չ�ֶ�1 ����
        /// </summary>
        /// <param name="ExtendFields1">��չ�ֶ�1</param>
        public void SetExtendFields1(string ExtendFields1)
        {
            AddCondition("ExtendFields1", ExtendFields1);
        }

        /// <summary>
        /// �� ��չ�ֶ�2 ����
        /// </summary>
        /// <param name="ExtendFields2">��չ�ֶ�2</param>
        public void SetExtendFields2(string ExtendFields2)
        {
            AddCondition("ExtendFields2", ExtendFields2);
        }

        /// <summary>
        /// �� ��չ�ֶ�3 ����
        /// </summary>
        /// <param name="ExtendFields3">��չ�ֶ�3</param>
        public void SetExtendFields3(string ExtendFields3)
        {
            AddCondition("ExtendFields3", ExtendFields3);
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
    /// ModelInfo ����Ƚ���
    /// </summary>
    public class ComparerModelInfo : IComparer
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
        public ComparerModelInfo(string sortField)
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
            ModelInfo x1, y1;

            x1 = (ModelInfo)x;
            y1 = (ModelInfo)y;

            switch (_sortField)
            {
                case ModelInfoQueryPara.OrderByMId:
                    ret = Comparer.Default.Compare(x1.MId, y1.MId);
                    break;
                case ModelInfoQueryPara.OrderByMId_desc:
                    ret = Comparer.Default.Compare(y1.MId, x1.MId);
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