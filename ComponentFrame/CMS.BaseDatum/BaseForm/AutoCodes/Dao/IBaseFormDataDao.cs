#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/12/29 16:48:01 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

/*
    <daoFactory assembly="PengeSoft.CMS.BaseDatum.dll">
      <dao
          interface="PengeSoft.CMS.BaseDatum.IBaseFormDataDao, PengeSoft.CMS.BaseDatum"
          implementation="PengeSoft.CMS.BaseDatum.BaseFormDataDao, PengeSoft.CMS.BaseDatum" />
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
    /// IBaseFormDataDao接口定主义。
    /// </summary>
    public interface IBaseFormDataDao : IDataProviderEx
    {
    }

    /// <summary>
    /// BaseFormDataDao实现, 从BaseSqlMapDao继承。
    /// </summary>
    public class BaseFormDataDao : BaseSqlMapDao, IBaseFormDataDao
    {
        #region 公共函数

        /// <summary>
        /// 根据条件对象取得条件 Hashtable
        /// </summary>
        /// <param name="Data">条件对象</param>
        /// <param name="Order">排序字段</param>
        /// <returns>条件Hashtable</returns>
        public static QueryParameter GetParaHashTable(BaseFormData Data, string Order)
        {
            return new BaseFormDataQueryPara(Data, Order);
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
            return QueryCount("QueryBaseFormDataCount", queryPar);
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
            Hashtable para = GetParaHashTable(Data as BaseFormData, null);

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
            Hashtable para = GetParaHashTable(Data as BaseFormData, OrderByField);

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
                statementName = "QueryBaseFormDataList";
            else
                statementName = "QueryBaseFormDataList";
            return QueryList(statementName, queryPar, Start, PageSize);
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <returns>返回对象</returns>
        public object Insert(DataPacket Data)
        {
            return Insert("InsertBaseFormData", Data);
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
            return Update("UpdateBaseFormData", Data);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="Data">数据对象</param>
        /// <param name="detail">更新明细数据</param>
        /// <returns>无</returns>
        public int Update(DataPacket Data, bool detail)
        {
            return Update("UpdateBaseFormData", Data, detail);
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
                statementName = "GetBaseFormData";
            else
                statementName = "GetBaseFormData";
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
            return (BaseFormData)ExecuteQueryForObject(statementName, Data);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Data">条件对象</param>
        public void Delete(DataPacket Data)
        {
            Delete("DeleteBaseFormData", Data);
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
    /// BaseFormData 查询参数
    /// </summary>
    public class BaseFormDataQueryPara : QueryParameter
    {
        #region 排序常量

        /// <summary>按Creator排序</summary>
        public const string OrderByCreator = "Creator";
        /// <summary>按Creator排序,降序</summary>
        public const string OrderByCreator_desc = "Creator_D";
        /// <summary>按CreateDate排序</summary>
        public const string OrderByCreateDate = "CreateDate";
        /// <summary>按CreateDate排序,降序</summary>
        public const string OrderByCreateDate_desc = "CreateDate_D";

        #endregion

        #region 查询条件常量

        /// <summary>查询 FormID 条件键名称</summary>
        public const string QueryKey_FormID = "FormID";
        /// <summary>查询 Creator 条件键名称</summary>
        public const string QueryKey_Creator = "Creator";
        /// <summary>查询 CreateDate 条件键名称</summary>
        public const string QueryKey_CreateDate = "CreateDate";
        /// <summary>查询 CreateDate 条件起始日期键名称</summary>
        public const string QueryKey_CreateDate_S = "CreateDate_S";
        /// <summary>查询 CreateDate 条件结束日期键名称</summary>
        public const string QueryKey_CreateDate_E = "CreateDate_E";
        /// <summary>查询 FinishDate 条件键名称</summary>
        public const string QueryKey_FinishDate = "FinishDate";
        /// <summary>查询 FinishDate 条件起始日期键名称</summary>
        public const string QueryKey_FinishDate_S = "FinishDate_S";
        /// <summary>查询 FinishDate 条件结束日期键名称</summary>
        public const string QueryKey_FinishDate_E = "FinishDate_E";
        /// <summary>查询 Status 条件键名称</summary>
        public const string QueryKey_Status = "Status";
        /// <summary>查询 Status 条件IN键名称</summary>
        public const string QueryKey_Status_IN = "Status_IN";
        /// <summary>查询 TaskID 条件键名称</summary>
        public const string QueryKey_TaskID = "TaskID";
        /// <summary>查询 WorkID 条件键名称</summary>
        public const string QueryKey_WorkID = "WorkID";
        /// <summary>查询 SType 条件键名称</summary>
        public const string QueryKey_SType = "SType";
        /// <summary>查询 SType 条件IN键名称</summary>
        public const string QueryKey_SType_IN = "SType_IN";
        /// <summary>查询 Uurgency 条件键名称</summary>
        public const string QueryKey_Uurgency = "Uurgency";
        /// <summary>查询 Uurgency 条件IN键名称</summary>
        public const string QueryKey_Uurgency_IN = "Uurgency_IN";
        /// <summary>查询 IsSecret 条件键名称</summary>
        public const string QueryKey_IsSecret = "IsSecret";
        /// <summary>查询 IsSecret 条件IN键名称</summary>
        public const string QueryKey_IsSecret_IN = "IsSecret_IN";
        /// <summary>查询 SecretLevel 条件键名称</summary>
        public const string QueryKey_SecretLevel = "SecretLevel";
        /// <summary>查询 FileNo 条件键名称</summary>
        public const string QueryKey_FileNo = "FileNo";
        /// <summary>查询 Title 条件键名称</summary>
        public const string QueryKey_Title = "Title";
        /// <summary>查询 SLevel 条件键名称</summary>
        public const string QueryKey_SLevel = "SLevel";
        /// <summary>查询 RequestFinishDate 条件键名称</summary>
        public const string QueryKey_RequestFinishDate = "RequestFinishDate";
        /// <summary>查询 RequestFinishDate 条件起始日期键名称</summary>
        public const string QueryKey_RequestFinishDate_S = "RequestFinishDate_S";
        /// <summary>查询 RequestFinishDate 条件结束日期键名称</summary>
        public const string QueryKey_RequestFinishDate_E = "RequestFinishDate_E";
        /// <summary>查询 ReceiveDate 条件键名称</summary>
        public const string QueryKey_ReceiveDate = "ReceiveDate";
        /// <summary>查询 ReceiveDate 条件起始日期键名称</summary>
        public const string QueryKey_ReceiveDate_S = "ReceiveDate_S";
        /// <summary>查询 ReceiveDate 条件结束日期键名称</summary>
        public const string QueryKey_ReceiveDate_E = "ReceiveDate_E";
        /// <summary>查询 IsSpecial 条件键名称</summary>
        public const string QueryKey_IsSpecial = "IsSpecial";
        /// <summary>查询 IsSpecial 条件IN键名称</summary>
        public const string QueryKey_IsSpecial_IN = "IsSpecial_IN";
        /// <summary>查询 SendUnit 条件键名称</summary>
        public const string QueryKey_SendUnit = "SendUnit";
        /// <summary>查询 DocType 条件键名称</summary>
        public const string QueryKey_DocType = "DocType";
        /// <summary>查询 Remark 条件键名称</summary>
        public const string QueryKey_Remark = "Remark";
        /// <summary>查询 CurStep 条件键名称</summary>
        public const string QueryKey_CurStep = "CurStep";
        /// <summary>查询 CurRunner 条件键名称</summary>
        public const string QueryKey_CurRunner = "CurRunner";
        /// <summary>查询 ExpanField 条件键名称</summary>
        public const string QueryKey_ExpanField = "ExpanField";

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFormDataQueryPara()
        {
        }

        /// <summary>
        /// 构造函数,指定参数对象及排序字段
        /// </summary>
        /// <param name="data">查询参数对象</param>
        /// <param name="order">排序字段</param>
        public BaseFormDataQueryPara(BaseFormData data, string order)
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
        public void SetQueryPara(BaseFormData data, string order)
        {
            if (data != null)
            {
                SetFormID(data.FormID);
                SetCreator(data.Creator);
                SetCreateDate(data.CreateDate);
                SetFinishDate(data.FinishDate);
                SetStatus(data.Status);
                SetTaskID(data.TaskID);
                SetWorkID(data.WorkID);
                SetSType(data.SType);
                SetUurgency(data.Uurgency);
                SetIsSecret(data.IsSecret);
                SetSecretLevel(data.SecretLevel);
                SetFileNo(data.FileNo);
                SetTitle(data.Title);
                SetSLevel(data.SLevel);
                SetRequestFinishDate(data.RequestFinishDate);
                SetReceiveDate(data.ReceiveDate);
                SetIsSpecial(data.IsSpecial);
                SetSendUnit(data.SendUnit);
                SetDocType(data.DocType);
                SetRemark(data.Remark);
                SetCurStep(data.CurStep);
                SetCurRunner(data.CurRunner);
                SetExpanField(data.ExpanField);
            }
            SetOrderByField(order);
        }

        /// <summary>
        /// 设 表单ID 条件
        /// </summary>
        /// <param name="FormID">表单ID</param>
        public void SetFormID(string FormID)
        {
            AddCondition("FormID", FormID);
        }

        /// <summary>
        /// 设 创建人 条件
        /// </summary>
        /// <param name="Creator">创建人</param>
        public void SetCreator(string Creator)
        {
            AddCondition("Creator", Creator);
        }

        /// <summary>
        /// 设 创建日期 条件
        /// </summary>
        /// <param name="CreateDate">创建日期</param>
        public void SetCreateDate(DateTime CreateDate)
        {
            AddCondition("CreateDate", CreateDate);
        }
        /// <summary>
        /// 设 创建日期 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetCreateDate(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("CreateDate", StartDate, EndDate);
        }

        /// <summary>
        /// 设 结案日期 条件
        /// </summary>
        /// <param name="FinishDate">结案日期</param>
        public void SetFinishDate(DateTime FinishDate)
        {
            AddCondition("FinishDate", FinishDate);
        }
        /// <summary>
        /// 设 结案日期 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetFinishDate(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("FinishDate", StartDate, EndDate);
        }

        /// <summary>
        /// 设 状态 非零值条件
        /// </summary>
        /// <param name="Status">状态</param>
        public void SetStatus(int Status)
        {
            AddConditionNonzero("Status", Status);
        }
        /// <summary>
        /// 设 状态 条件(包含零值)
        /// </summary>
        /// <param name="Status">状态</param>
        public void SetStatus_InZero(int Status)
        {
            AddCondition("Status", Status);
        }
        /// <summary>
        /// 设 状态 枚举值条件
        /// </summary>
        /// <param name="Status">状态</param>
        public void SetStatus_In(int[] Statuss)
        {
            string value = "";
            foreach (int val in Statuss)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("Status_IN", value);
        }

        /// <summary>
        /// 设 任务ID 条件
        /// </summary>
        /// <param name="TaskID">任务ID</param>
        public void SetTaskID(string TaskID)
        {
            AddCondition("TaskID", TaskID);
        }

        /// <summary>
        /// 设 工作流ID 条件
        /// </summary>
        /// <param name="WorkID">工作流ID</param>
        public void SetWorkID(string WorkID)
        {
            AddCondition("WorkID", WorkID);
        }

        /// <summary>
        /// 设 表单类型 非零值条件
        /// </summary>
        /// <param name="SType">表单类型</param>
        public void SetSType(int SType)
        {
            AddConditionNonzero("SType", SType);
        }
        /// <summary>
        /// 设 表单类型 条件(包含零值)
        /// </summary>
        /// <param name="SType">表单类型</param>
        public void SetSType_InZero(int SType)
        {
            AddCondition("SType", SType);
        }
        /// <summary>
        /// 设 表单类型 枚举值条件
        /// </summary>
        /// <param name="SType">表单类型</param>
        public void SetSType_In(int[] STypes)
        {
            string value = "";
            foreach (int val in STypes)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("SType_IN", value);
        }

        /// <summary>
        /// 设 紧急程度 非零值条件
        /// </summary>
        /// <param name="Uurgency">紧急程度</param>
        public void SetUurgency(int Uurgency)
        {
            AddConditionNonzero("Uurgency", Uurgency);
        }
        /// <summary>
        /// 设 紧急程度 条件(包含零值)
        /// </summary>
        /// <param name="Uurgency">紧急程度</param>
        public void SetUurgency_InZero(int Uurgency)
        {
            AddCondition("Uurgency", Uurgency);
        }
        /// <summary>
        /// 设 紧急程度 枚举值条件
        /// </summary>
        /// <param name="Uurgency">紧急程度</param>
        public void SetUurgency_In(int[] Uurgencys)
        {
            string value = "";
            foreach (int val in Uurgencys)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("Uurgency_IN", value);
        }

        /// <summary>
        /// 设 是否涉密 非零值条件
        /// </summary>
        /// <param name="IsSecret">是否涉密</param>
        public void SetIsSecret(int IsSecret)
        {
            AddConditionNonzero("IsSecret", IsSecret);
        }
        /// <summary>
        /// 设 是否涉密 条件(包含零值)
        /// </summary>
        /// <param name="IsSecret">是否涉密</param>
        public void SetIsSecret_InZero(int IsSecret)
        {
            AddCondition("IsSecret", IsSecret);
        }
        /// <summary>
        /// 设 是否涉密 枚举值条件
        /// </summary>
        /// <param name="IsSecret">是否涉密</param>
        public void SetIsSecret_In(int[] IsSecrets)
        {
            string value = "";
            foreach (int val in IsSecrets)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("IsSecret_IN", value);
        }

        /// <summary>
        /// 设 涉密等级 条件
        /// </summary>
        /// <param name="SecretLevel">涉密等级</param>
        public void SetSecretLevel(string SecretLevel)
        {
            AddCondition("SecretLevel", SecretLevel);
        }

        /// <summary>
        /// 设 文件编号 条件
        /// </summary>
        /// <param name="FileNo">文件编号</param>
        public void SetFileNo(string FileNo)
        {
            AddCondition("FileNo", FileNo);
        }

        /// <summary>
        /// 设 标题 条件
        /// </summary>
        /// <param name="Title">标题</param>
        public void SetTitle(string Title)
        {
            AddCondition("Title", Title);
        }

        /// <summary>
        /// 设 级别 条件
        /// </summary>
        /// <param name="SLevel">级别</param>
        public void SetSLevel(string SLevel)
        {
            AddCondition("SLevel", SLevel);
        }

        /// <summary>
        /// 设 完成时限 条件
        /// </summary>
        /// <param name="RequestFinishDate">完成时限</param>
        public void SetRequestFinishDate(DateTime RequestFinishDate)
        {
            AddCondition("RequestFinishDate", RequestFinishDate);
        }
        /// <summary>
        /// 设 完成时限 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetRequestFinishDate(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("RequestFinishDate", StartDate, EndDate);
        }

        /// <summary>
        /// 设 收文日期 条件
        /// </summary>
        /// <param name="ReceiveDate">收文日期</param>
        public void SetReceiveDate(DateTime ReceiveDate)
        {
            AddCondition("ReceiveDate", ReceiveDate);
        }
        /// <summary>
        /// 设 收文日期 范围条件
        /// </summary>
        /// <param name="StartDate">起始日期</param>
        /// <param name="EndDate">结束日期</param>
        public void SetReceiveDate(DateTime StartDate, DateTime EndDate)
        {
            AddDateRange("ReceiveDate", StartDate, EndDate);
        }

        /// <summary>
        /// 设 是否三重一大 非零值条件
        /// </summary>
        /// <param name="IsSpecial">是否三重一大</param>
        public void SetIsSpecial(int IsSpecial)
        {
            AddConditionNonzero("IsSpecial", IsSpecial);
        }
        /// <summary>
        /// 设 是否三重一大 条件(包含零值)
        /// </summary>
        /// <param name="IsSpecial">是否三重一大</param>
        public void SetIsSpecial_InZero(int IsSpecial)
        {
            AddCondition("IsSpecial", IsSpecial);
        }
        /// <summary>
        /// 设 是否三重一大 枚举值条件
        /// </summary>
        /// <param name="IsSpecial">是否三重一大</param>
        public void SetIsSpecial_In(int[] IsSpecials)
        {
            string value = "";
            foreach (int val in IsSpecials)
                value += val.ToString() + ",";
            value = value.Substring(0, value.Length - 1);
            AddCondition("IsSpecial_IN", value);
        }

        /// <summary>
        /// 设 来文单位 条件
        /// </summary>
        /// <param name="SendUnit">来文单位</param>
        public void SetSendUnit(string SendUnit)
        {
            AddCondition("SendUnit", SendUnit);
        }

        /// <summary>
        /// 设 文种 条件
        /// </summary>
        /// <param name="DocType">文种</param>
        public void SetDocType(string DocType)
        {
            AddCondition("DocType", DocType);
        }

        /// <summary>
        /// 设 备注 条件
        /// </summary>
        /// <param name="Remark">备注</param>
        public void SetRemark(string Remark)
        {
            AddCondition("Remark", Remark);
        }

        /// <summary>
        /// 设 当前状态 条件
        /// </summary>
        /// <param name="CurStep">当前状态</param>
        public void SetCurStep(string CurStep)
        {
            AddCondition("CurStep", CurStep);
        }

        /// <summary>
        /// 设 当前处理人员 条件
        /// </summary>
        /// <param name="CurRunner">当前处理人员</param>
        public void SetCurRunner(string CurRunner)
        {
            AddCondition("CurRunner", CurRunner);
        }

        /// <summary>
        /// 设 特殊字段 条件
        /// </summary>
        /// <param name="ExpanField">特殊字段</param>
        public void SetExpanField(string ExpanField)
        {
            AddCondition("ExpanField", ExpanField);
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
    /// BaseFormData 排序比较器
    /// </summary>
    public class ComparerBaseFormData : IComparer
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
        public ComparerBaseFormData(string sortField)
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
            BaseFormData x1, y1;

            x1 = (BaseFormData)x;
            y1 = (BaseFormData)y;

            switch (_sortField)
            {
                case BaseFormDataQueryPara.OrderByCreator:
                    ret = string.Compare(x1.Creator, y1.Creator);
                    break;
                case BaseFormDataQueryPara.OrderByCreator_desc:
                    ret = string.Compare(y1.Creator, x1.Creator);
                    break;
                case BaseFormDataQueryPara.OrderByCreateDate:
                    ret = DateTime.Compare(x1.CreateDate, y1.CreateDate);
                    break;
                case BaseFormDataQueryPara.OrderByCreateDate_desc:
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