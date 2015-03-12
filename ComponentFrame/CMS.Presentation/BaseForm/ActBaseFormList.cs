using PengeSoft.CMS.BaseDatum;
using PengeSoft.db;
using PengeSoft.Web;
using PengeSoft.WorkFlow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace PengeSoft.CMS.Presentation
{
    public abstract class ActBaseFormList : PengeSoft.Web.AbstractWebAction
    {
        public IBaseFormDataServerSvr _baseformdata;
        protected IWorkFlowEngineOA _workflow;
        public string ReturnUC;
        public string ReturnUCdetail;
        public const string ActBase_ReturnUC_Key = "ActBase_ReturnUC";
        public const string ActReturnDetail = "ActReturnDetail";
        #region 属性
        /// <summary>
        /// 表单类型
        /// </summary>
        public int FormType { get; set; }
        /// <summary>
        /// 工作实例ID
        /// </summary>
        public string TaskID { get; set; }
        /// <summary>
        /// 表单ID
        /// </summary>
        public string BaseFormID { get; set; }
        /// <summary>
        /// 工作实例ID
        /// </summary>
        public string WorkID { get; set; }

        /// <summary>
        /// 页大小，如果小于等于0则不分页
        /// </summary>
        public int PageSize = 0;
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex = 0;
        /// <summary>
        /// 排序字段，如果为空则不排序
        /// </summary>
        public string OrderByField;
        /// <summary>
        /// 是否按降序排列
        /// </summary>
        public bool SortIsDesc = true;
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount;
        /// <summary>
        /// 选择项的主键
        /// </summary>
        public string SelectedKey;
        /// <summary>
        /// 查询关键字
        /// </summary>
        private string sKeyWord;        //查询关键字
        public string KeyWord
        {
            get { return sKeyWord; }
            set { sKeyWord = value; }
        }

        /// <summary>
        /// 是否用行政区域查询，要在UserControl的PageLoad事件进行设置
        /// </summary>
        public bool IsQueryConton = false;
        #endregion

        public ActBaseFormList(HttpContext ctx)
            : base(ctx)
        {
            _baseformdata = (IBaseFormDataServerSvr)WebObjManager.Container[typeof(IBaseFormDataServerSvr)];
            _workflow = (IWorkFlowEngineOA)WebObjManager.Container[typeof(IWorkFlowEngineOA)];

        }
        #region 重载
        public override void GetParameter(PengeSoft.Web.IStateSaver controller)
        {
            base.GetParameter(controller);

            PageIndex = controller.GetStateAsInt("ActBaseFormList_PageIndex");
            if (PageIndex < 0)
                PageIndex = 0;
            string sortisdesc = controller.GetStateAsString("ActBaseFormList_IsDesc");
            if (!string.IsNullOrEmpty(sortisdesc))
                SortIsDesc = sortisdesc.ToUpper() == "TRUE";
            string sortExpress = controller.GetStateAsString("ActBaseFormList_Express");
            if (!string.IsNullOrEmpty(sortExpress))
                OrderByField = sortExpress;
            int pageSize = controller.GetStateAsInt("ActBaseFormList_PageSize");
            if (pageSize > 0)
                PageSize = pageSize;
            PageCount = controller.GetStateAsInt("ActBaseFormList_PageCount");
            sKeyWord = controller.GetStateAsString("KeyWord");
            FormType = controller.GetStateAsInt("FormType", false);
            ReturnUC = controller.GetStateAsString(ActBase_ReturnUC_Key, false);
            BaseFormID = controller.GetStateAsString("BaseFormID", false);
            TaskID = controller.GetStateAsString("TaskID", false);
            WorkID = controller.GetStateAsString("WorkID", false);
        }

        public override void SetParameter(PengeSoft.Web.IStateSaver controller)
        {
            base.SetParameter(controller);

            controller.SetStateAsInt("ActBaseFormList_PageIndex", PageIndex);
            controller.SetStateAsString("ActBaseFormList_IsDesc", SortIsDesc.ToString().ToUpper());
            controller.SetStateAsString("ActBaseFormList_Express", OrderByField);
            controller.SetStateAsInt("ActBaseFormList_PageSize", PageSize);
            controller.SetStateAsInt("ActBaseFormList_PageCount", PageCount);
            controller.SetStateAsString("KeyWord", sKeyWord);
            controller.SetStateAsInt("FormType", FormType, false);
            controller.SetStateAsString(ActBase_ReturnUC_Key, ReturnUC, false);
            controller.SetStateAsString("BaseFormID", BaseFormID, false);
            controller.SetStateAsString("TaskID", TaskID, false);
            controller.SetStateAsString("WorkID", WorkID, false);
        }
        #endregion
        #region 子类实现
        /// <summary>
        /// 创建查询参数对像（只实例化）
        /// </summary>
        /// <returns></returns>
        protected virtual QueryParameter CreateQueryParamater()
        {
            return null;
        }
        /// <summary>
        /// 创建分页数据访问接口
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected abstract IPagedList CreatePagedList(QueryParameter param);
        #endregion
       

        #region  方法
        /// <summary>
        /// 添加新工作
        /// </summary>
        protected virtual void AddNewWork()
        {
            string taskname = GetTaskName();
            WorkID = addTask(HttpContext.Current.Server.MapPath("flowfile") + "\\" + Enum.GetName(typeof(EFormType), FormType) + ".wkf", taskname, GetCurUserID);
            NamedValue pa = new NamedValue();
            startwork(WorkID, pa, GetCurUserID, 0);
            RunTask runtask = GetCurrentTask();
            Controller.SetStateAsString(ActBase_ReturnUC_Key, "WorkManage/ucWorkManageList");
            Controller.SetStateAsInt("FormType", FormType, false);
            Controller.SetStateAsString("WorkID", WorkID, false);
            Controller.SetStateAsString("TaskID", runtask.TaskID.ToString(), false);
            Controller.SetStateAsString(ActBaseForm.ActReturnDetail, runtask.ActionPara);
            ActionFinishedWithNoState(runtask.ActionPara);
        }
        /// <summary>
        /// 查看信息
        /// </summary>
        /// <param name="FormID"></param>
        protected virtual void ShowDetail(string FormID)
        {
            Controller.SetStateAsString("BaseFormID", FormID, false);
            Controller.SetStateAsInt("FormType", FormType, false);
            Controller.SetStateAsString(ActBase_ReturnUC_Key, "WorkManage/ucWorkManageList");
            Controller.SetStateAsString(ActBaseForm.ActReturnDetail, GetViewByFormType(FormType));

            ActionFinishedWithNoState(GetViewByFormType(FormType));

        }
        /// <summary>
        /// 办理工作
        /// </summary>
        public virtual void DoWork(string FormID)
        {
            Controller.SetStateAsString("BaseFormID", FormID, false);
            Controller.SetStateAsInt("FormType", FormType, false);
            Controller.SetStateAsString(ActBase_ReturnUC_Key, "WorkManage/ucWorkManageList");
            Controller.SetStateAsString(ActBaseForm.ActReturnDetail, GetViewByFormType(FormType));

            ActionFinishedWithNoState(GetViewByFormType(FormType));

            //在此实现办理工作流程
        }
        private void SetSortOrConton(QueryParameter param)
        {
            if (param != null)
            {
                if (!string.IsNullOrEmpty(OrderByField))
                {
                    param.AddCondition("_OrderBy", OrderByField + (SortIsDesc ? "_D" : ""));
                }
                //增加对查询对象按行政区域查询的功能
                //if (IsQueryConton)
                //    param.AddCondition("ContonCode", "");
            }
        }
        /// <summary>
        /// 删除列表
        /// </summary>
        /// <param name="baselist"></param>
        public void deletebaseinfolist(BaseFormDataList baselist)
        {
            foreach (BaseFormData info in baselist)
            {
                _baseformdata.DelInfo(info.FormID);
            }
        }
        /// <summary>
        /// 取数据访问接口
        /// </summary>
        /// <returns></returns>
        public IPagedList GetPagedList()
        {
            QueryParameter param = CreateQueryParamater();
            SetSortOrConton(param);
            IPagedList pageList = CreatePagedList(param);

            if (pageList != null)
            {
                if (pageList.TotalSize == -1)
                {
                    this.PageCount = 300 / pageList.PageSize;
                    if (300 % pageList.PageSize > 0)
                    {
                        this.PageCount++;
                    }
                }
                else
                {
                    this.PageCount = pageList.PageCount;
                }
            }

            return pageList;
        }     

        public void GotoPage(int index)
        {
            PageIndex = index;
        }

        public void FirstPage()
        {
            PageIndex = 0;
        }

        public void NextPage()
        {
            PageIndex++;
        }

        public void PrePage()
        {
            PageIndex--;
        }
        public void LastPage()
        {
            PageIndex = PageCount - 1;
        }
        public void Sort(string express)
        {
            if (string.IsNullOrEmpty(express))
                return;
            if (express == OrderByField)
            {
                SortIsDesc = !SortIsDesc;
            }
            else
            {
                OrderByField = express;
                SortIsDesc = true;
            }
            PageIndex = 0;
        }     
        /// <summary>
        /// 查询分页列表（不包含附件和意见信息）
        /// </summary>
        /// <returns></returns>
        public IPagedList Getinfolist(BaseFormDataQueryPara param, int pageSize, int start)
        {
            return _baseformdata.GetBaseForminfoList(param, start, pageSize);
        }
        public IPagedList Getinfolistex(BaseFormDataQueryPara param, int pageSize, int start)
        {
            return _baseformdata.GetBaseForminfoListex(param, start, pageSize);
        }

        public int GetListCount(BaseFormDataQueryPara param, int pageSize, int start)
        {
            return _baseformdata.QueryListCount(param);
        }
        public string GetCurUserID
        {
            get
            {
                return WebObjManager.LoginID;
            }
        }
        public string GetTaskName()
        {
            DataTable DT = XmlHelper.GetNodeList(AppDomain.CurrentDomain.BaseDirectory + "App_Resources/Xml/FormTypeURL.xml", "FormURLS");
            foreach (DataRow dr in DT.Rows)
            {
                if (dr["Type"].ToString() == FormType.ToString())
                {
                    return dr["TaskName"].ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 添加新工作   
        /// </summary>
        /// <param name="templateFile">工作模板</param>
        /// <param name="workName">工作名称</param>
        /// <param name="owner">创建人</param>
        public string addTask(WorkInstance template, string workName, string owner)
        {
            return _workflow.AddNewWork(template, workName, owner);
        }
        /// <summary>
        /// 添加新工作   
        /// </summary>
        /// <param name="templateFile">工作模板文件</param>
        /// <param name="workName">工作名称</param>
        /// <param name="owner">创建人</param>
        public string addTask(string templateFile, string workName, string owner)
        {
            return _workflow.AddNewWork(templateFile, workName, owner);
        }
        public void deletework()
        {
            _workflow.RemoveWork(WorkID);
        }
        public void startwork(string workid, NamedValue npara)
        {
            _workflow.StartWork(workid, npara);
        }
        public void startwork(string workid, NamedValue npara, string nextOperators, double nextTimeLimite)
        {
            _workflow.StartWork(workid, npara, nextOperators, nextTimeLimite);
        }
        public RunTask GetCurrentTask()
        {
            return _workflow.GetCurrentTask(WorkID);
        }
        public RunTask GetTaskByWorkID(string workid)
        {
            return _workflow.GetCurrentTask(workid);
        }
        public void ActionFinishedWithNoState(string nextView)
        {
            Set_StateSet(AbstractWebAction.State_NextViewNotUseSavedState, true);
            ActionFinished(nextView);
        }
        public string GetViewByFormType(int SType)
        {
            DataTable DT = XmlHelper.GetNodeList(AppDomain.CurrentDomain.BaseDirectory + "App_Resources/Xml/FormTypeURL.xml", "FormURLS");
            foreach (DataRow dr in DT.Rows)
            {
                if (dr["Type"].ToString() == SType.ToString())
                {
                    return dr["URL"].ToString();
                }
            }
            return "";
        }
        #endregion
    }
}
