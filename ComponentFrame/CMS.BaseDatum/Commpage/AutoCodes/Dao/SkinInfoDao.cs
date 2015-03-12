#region �汾˵��
/*****************************************************************************
 * 
 * ��    Ŀ : 
 * ��    �� : ���ƺ 
 * ����ʱ�� : 2014/11/18 13:26:53 
 *
 * Copyright (C) 2008 - ��ҵ�����˾
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.ISkinInfoDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.SkinInfoDao, PengeSoft.CMS.BaseDatum" />
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
    /// ISkinInfoDao�ӿڶ����塣
    /// </summary>
    public interface ISkinInfoDao : IDataProviderEx
    {
    }

    /// <summary>
    /// SkinInfoDaoʵ��, ��BaseSqlMapDao�̳С�
    /// </summary>
    public class SkinInfoDao : BaseSqlMapDao, ISkinInfoDao
    {
        #region ��������

        /// <summary>
        /// ������������ȡ������ Hashtable
        /// </summary>
        /// <param name="Data">��������</param>
        /// <param name="Order">�����ֶ�</param>
        /// <returns>����Hashtable</returns>
        public static QueryParameter GetParaHashTable(SkinInfo Data, string Order)
        {
            return new SkinInfoQueryPara(Data, Order);
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
            return QueryCount("QuerySkinInfoCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as SkinInfo, null);

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
            Hashtable para = GetParaHashTable(Data as SkinInfo, OrderByField);

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
                statementName = "QuerySkinInfoList";
            else
                statementName = "QuerySkinInfoList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// ����¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>���ض���</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertSkinInfo", Data);
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
            ((SkinInfo)Data).SId = (int)ret;

            return ret;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data)
        {
            return Update("UpdateSkinInfo", Data);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="Data">���ݶ���</param>
        /// <param name="detail">������ϸ����</param>
        /// <returns>��</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateSkinInfo", Data, detail);
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
                statementName = "GetSkinInfo";
            else
                statementName = "GetSkinInfo";
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
            return (SkinInfo)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="Data">��������</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteSkinInfo", Data);
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
    /// SkinInfo ��ѯ����
    /// </summary>
    public class SkinInfoQueryPara : QueryParameter
    {
        #region ������

        /// <summary>��SId����</summary>
        public const string OrderBySId = "SId";
        /// <summary>��SId����,����</summary>
        public const string OrderBySId_desc = "SId_D";

        #endregion

        #region ��ѯ��������

        /// <summary>��ѯ Uid ����������</summary>
        public const string QueryKey_Uid = "Uid";
        /// <summary>��ѯ Sname ����������</summary>
        public const string QueryKey_Sname = "Sname";
        /// <summary>��ѯ CreateTime ����������</summary>
        public const string QueryKey_CreateTime = "CreateTime";
        /// <summary>��ѯ CreateTime ������ʼ���ڼ�����</summary>
        public const string QueryKey_CreateTime_S = "CreateTime_S";
        /// <summary>��ѯ CreateTime �����������ڼ�����</summary>
        public const string QueryKey_CreateTime_E = "CreateTime_E";
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
        public SkinInfoQueryPara()
        {
        }

        /// <summary>
        /// ���캯��,ָ���������������ֶ�
        /// </summary>
        /// <param name="data">��ѯ��������</param>
        /// <param name="order">�����ֶ�</param>
        public SkinInfoQueryPara(SkinInfo data, string order)
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
        public void SetQueryPara(SkinInfo data, string order)
        {
            if (data != null)
            {
                SetUid(data.Uid);
                SetSname(data.Sname);
                SetCreateTime(data.CreateTime);
                SetExtendFields1(data.ExtendFields1);
                SetExtendFields2(data.ExtendFields2);
                SetExtendFields3(data.ExtendFields3);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// �� �û� ����
        /// </summary>
        /// <param name="Uid">�û�</param>
        public void SetUid(string Uid)
        {
            AddCondition("Uid", Uid);
        }

        /// <summary>
        /// �� ʹ��Ƥ������ ����
        /// </summary>
        /// <param name="Sname">ʹ��Ƥ������</param>
        public void SetSname(string Sname)
        {
            AddCondition("Sname", Sname);
        }

        /// <summary>
        /// �� ��ʼʹ��ʱ�� ����
        /// </summary>
        /// <param name="CreateTime">��ʼʹ��ʱ��</param>
        public void SetCreateTime(DateTime CreateTime)
        {
            AddCondition("CreateTime", CreateTime);
        }
        /// <summary>
        /// �� ��ʼʹ��ʱ�� ��Χ����
        /// </summary>
        /// <param name="StartDate">��ʼ����</param>
        /// <param name="EndDate">��������</param>
        public void SetCreateTime(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("CreateTime", StartDate, EndDate);
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
    /// SkinInfo ����Ƚ���
    /// </summary>
    public class ComparerSkinInfo : IComparer
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
        public ComparerSkinInfo(string sortField)
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
            SkinInfo x1, y1;

            x1 = (SkinInfo)x;
            y1 = (SkinInfo)y;

            switch (_sortField)
            {
                case SkinInfoQueryPara.OrderBySId:
                    ret = Comparer.Default.Compare(x1.SId, y1.SId);
                    break;
                case SkinInfoQueryPara.OrderBySId_desc:
                    ret = Comparer.Default.Compare(y1.SId, x1.SId);
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