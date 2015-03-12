using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengeSoft.CMS.BaseDatum;
using System.Web;
using PengeSoft.WorkFlow;
using PengeSoft.Data;
using System.IO;
using System.Collections;
using System.Data;
using PengeSoft.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PengeSoft.db;
using PengeSoft.Auther;
using PengeSoft.Auther.RightCheck;
using PengeSoft.WorkZoneData;

namespace PengeSoft.CMS.Presentation
{
    public class ActBaseForm : PengeSoft.Web.AbstractWebAction
    {
        public IBaseFormDataServerSvr _baseformdata;
        protected IWorkFlowEngineOA _workflow;
        protected IAttachmentServiceAllSvr _AttachmentServiceAllSvr;
        protected IUsedContactServerSvr _UsedContactSvr;
        protected ITempletServiceSvr _TempletSvr;
        protected IRightCheck _rightcheck;
        protected PengeSoft.Service.IDeptManSvr _DeptManSvr;

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
        /// 是否需要上传附件
        /// </summary>
        public bool AttachmentNeeded { get; set; }
        /// <summary>
        /// 当前步骤
        /// </summary>
        public string CurStep { get; set; }
        ///// <summary>
        ///// 表单基本信息
        ///// </summary>
        //  public BaseFormData baseforminfo { get; set; }
        ///// <summary>
        ///// 附件列表
        ///// </summary>
        //  public AttachmentList Attachments { get; set; }
        ///// <summary>
        ///// 意见列表
        ///// </summary>
        //  public DoAttitudeList Attitudes { get; set; }
        //  public NamedValue npara { get; set; }

        //  public string retValue { get; set; }
        //  /// <summary>
        //  /// 下步人
        //  /// </summary>
        //  public string nextOperators { get; set; }
        //  /// <summary>
        //  /// 下步期限
        //  /// </summary>
        //  public double nextTimeLimite { get; set; }
        //  /// <summary>
        //  /// 下步名称
        //  /// </summary>
        //  public string nextTaskName { get; set; }
        //  /// <summary>
        //  /// 下步抄送
        //  /// </summary>
        //  public string nextCC { get; set; }
        //  /// <summary>
        //  /// 执行人
        //  /// </summary>
        //  public string runner { get; set; }


        //控制是否为搜索人员
        private bool _IsSearch;
        public bool IsSearch
        {
            get { return _IsSearch; }
            set { _IsSearch = value; }
        }
        public string selnextstep { get; set; }
        #endregion
        public ActBaseForm(HttpContext ctx)
            : base(ctx)
        {
            _baseformdata = (IBaseFormDataServerSvr)WebObjManager.Container[typeof(IBaseFormDataServerSvr)];
            _workflow = (IWorkFlowEngineOA)WebObjManager.Container[typeof(IWorkFlowEngineOA)];
            _AttachmentServiceAllSvr = (AttachmentServiceAllSvr)WebObjManager.Container[typeof(AttachmentServiceAllSvr)];
            _TempletSvr = (ITempletServiceSvr)WebObjManager.Container[typeof(ITempletServiceSvr)];
            _UsedContactSvr = (IUsedContactServerSvr)WebObjManager.Container[typeof(IUsedContactServerSvr)];
            _rightcheck = WebObjManager.Auther;
            _DeptManSvr = (PengeSoft.Service.IDeptManSvr)WebObjManager.Container[typeof(PengeSoft.Service.IDeptManSvr)];
        }

        public override void GetParameter(PengeSoft.Web.IStateSaver controller)
        {
            base.GetParameter(controller);
            FormType = controller.GetStateAsInt("FormType", false);
            ReturnUC = controller.GetStateAsString(ActBase_ReturnUC_Key, false);
            BaseFormID = controller.GetStateAsString("BaseFormID", false);
            TaskID = controller.GetStateAsString("TaskID", false);
            WorkID = controller.GetStateAsString("WorkID", false);
            selnextstep = controller.GetStateAsString("selnextstep", false);
            CurStep = controller.GetStateAsString("CurStep", false);
            ReturnUCdetail = controller.GetStateAsString(ActReturnDetail, false);

        }
        public override void SetParameter(PengeSoft.Web.IStateSaver controller)
        {
            base.SetParameter(controller);
            controller.SetStateAsInt("FormType", FormType, false);
            controller.SetStateAsString(ActBase_ReturnUC_Key, ReturnUC, false);
            controller.SetStateAsString("BaseFormID", BaseFormID, false);
            controller.SetStateAsString("TaskID", TaskID, false);
            controller.SetStateAsString("WorkID", WorkID, false);
            controller.SetStateAsString("selnextstep", selnextstep, false);
            controller.SetStateAsString("CurStep", CurStep, false);
            controller.SetStateAsString(ActReturnDetail, ReturnUCdetail, false);

        }
        #region 表单相关

        /// <summary>
        /// 根据主键guid获取对象
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public virtual BaseFormData GetDetail(string BaseFormID)
        {
            return _baseformdata.GetinfoByID(BaseFormID);
        }
        public virtual BaseFormData GetDetailByWorkID(string WorkID)
        {
            return _baseformdata.GetinfoByWorkID(WorkID);
        }

        /// <summary>
        /// 保存新资料
        /// </summary>
        /// <param name="datum"></param>
        public virtual void SaveNew(BaseFormData baseforminfo)
        {
            _baseformdata.AddNewInfo(baseforminfo);
        }

        /// <summary>
        /// 保存对资料的变更
        /// </summary>
        /// <param name="datum"></param>
        public virtual void ChangeInfo(string baseformid, BaseFormData baseforminfo)
        {
            _baseformdata.UpdateInfo(baseformid, baseforminfo);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="baseinfo"></param>
        public void deletebaseinfo(string baseformid)
        {
            _baseformdata.DelInfo(baseformid);
        }



        #endregion
        #region 附件相关
        /// <summary>
        /// 取附件列表
        /// </summary>
        /// <param name="formid">表单ID</param>
        /// <param name="reftype">附件类型</param>
        /// <returns></returns>
        public AttachmentList GetAttachmentListByFormID(string formid, string reftype)
        {
            return _baseformdata.GetAttachments(formid, reftype);
        }
        /// <summary>
        /// 取附件列表(仅包含通用附件)
        /// </summary>
        /// <param name="formid">表单id</param>
        /// <returns></returns>
        public AttachmentList GetAttachmentListByFormID(string formid)
        {
            return _baseformdata.GetAttachments(formid, "oa_archive");
        }
        /// <summary>
        /// 取附件信息
        /// </summary>
        /// <param name="guid">附件id</param>
        /// <returns></returns>
        public Attachment GetAttachmentDetail(string guid)
        {
            return _AttachmentServiceAllSvr.GetAttachment(guid);
        }

        /// <summary>
        /// 取附件文件
        /// </summary>
        /// <param name="fileId">文件id</param>
        /// <returns></returns>
        public AttachmentFile GetAttachmentFileDetail(string fileId)
        {
            return _AttachmentServiceAllSvr.GetAttachmentFile(fileId);
        }
        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="guid">附件ID</param>
        /// <param name="fileid">文件id</param>
        public void DeleteAttachment(string guid, string fileid)
        {
            _AttachmentServiceAllSvr.DeleteAttachment(guid);
            _AttachmentServiceAllSvr.DeleteAttachmentFile(fileid);
        }

        /// <summary>
        /// 删除附件列表
        /// </summary>
        /// <param name="guids"></param>
        public void DeleteAttachmentList(StringList guids)
        {
            _AttachmentServiceAllSvr.DeleteAttachmentList(guids);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public string UploadAttachment(AttachmentFile attachmentFile)
        {
            attachmentFile.FileId = Guid.NewGuid().ToString();
            _AttachmentServiceAllSvr.AddAttachmentFile(attachmentFile);
            return attachmentFile.FileId;
        }

        //添加附件信息
        public void AddAttachmentInfo(Attachment data)
        {
            data.AttachmentId = Guid.NewGuid().ToString();
            _AttachmentServiceAllSvr.AddAttachment(data);
        }

        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="annexGuid"></param>
        public void DownAttachment(string fileId, string fileName)
        {
            AttachmentFile attachmentFile = GetAttachmentFileDetail(fileId);

            if (attachmentFile != null)
            {
                DownLoad(attachmentFile.FileContent, fileName, "attachment");
            }
        }
        /// <summary>
        ///  保存附件
        /// </summary>
        /// <param name="annexGuid"></param>
        public void SaveAttachment(string fileId, string fileName)
        {
            AttachmentFile attachmentFile = GetAttachmentFileDetail(fileId);

            if (attachmentFile != null)
            {
                SaveLoad(attachmentFile.FileContent, fileName, "attachment");
            }
        }
        /// <summary>
        /// 保存在本地
        /// </summary>
        /// <param name="content"></param>
        /// <param name="outFileName"></param>
        /// <param name="downType"></param>
        protected void SaveLoad(byte[] content, string outFileName, string downType)
        {
            using (Stream localFile = new FileStream(outFileName, FileMode.OpenOrCreate))
            {
                localFile.Write(content, 0, content.Length);
            }

        }
        /// <summary>
        /// 阅读附件
        /// </summary>
        /// <param name="annexGuid"></param>
        public void ReadAttachment(string fileId, string fileName)
        {
            AttachmentFile attachmentFile = GetAttachmentFileDetail(fileId);

            if (attachmentFile != null)
            {
                DownLoad(attachmentFile.FileContent, fileName, "inline");
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        protected void DownLoad(byte[] content, string outFileName, string downType)
        {
            //string filename = HttpUtility.UrlEncode(outFileName, System.Text.Encoding.UTF8);
            //filename = filename.Replace("+", "%20");
            if (!IsLogin)
            {
                return;
            }


            Context.Response.Clear();
            Encoding code = Encoding.GetEncoding("gb2312");
            Context.Response.ContentEncoding = code;
            Context.Response.HeaderEncoding = code;//这句很重要
            Context.Response.ContentType = "application/octet-stream";
            Context.Response.AddHeader("Content-Disposition", downType + "; filename=" + outFileName);
            Context.Response.AddHeader("Content-Length", content.Length.ToString());
            Context.Response.BinaryWrite(content);
            Context.Response.End();
        }

        /// <summary>
        /// 是否含有附件
        /// </summary>
        /// <param name="refid"></param>
        /// <returns></returns>
        public bool HasAttachment(string refid)
        {
            return _AttachmentServiceAllSvr.HasAttachment(refid);
        }

        #endregion

        #region 人员部门权限(通用)
        public UseContactList GetContact(string userid, string taskname, string stepname)
        {
            return _UsedContactSvr.GetContactsList(userid, taskname, stepname);
        }
        public bool IsLogin
        {
            get
            {
                return String.IsNullOrEmpty(WebObjManager.LoginID) ? false : true;
            }
        }
        public string GetCurUserID
        {
            get
            {
                return WebObjManager.LoginID;
            }
        }
        public string GetCurUserName
        {
            get
            {
                return WebObjManager.UserFullName;
            }
        }
        public string GetCurUserDept
        {
            get
            {
                PersonRec pers;
                WebObjManager.Auther.GetUserAttrib(GetCurUserID, out pers);
                return pers.Dept;
            }
        }
        public string GetUserFullNameByID(string loginName)
        {
            if (string.IsNullOrEmpty(loginName))
                return "";
            string result = loginName;
            PersonRec pers;
            WebObjManager.Auther.GetUserAttrib(loginName, out pers);

            result = pers.FullName;

            return result;
        }
        /// <summary>
        /// 取第一级部门
        /// </summary>
        /// <returns></returns>
        public DepartmentList GetFirstLevelDeptsList()
        {
            return _DeptManSvr.GetListNode(GetCurUserID, "", 0, -1);
        }
        /// <summary>
        /// 取子部门
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public DepartmentList GetChildsDeptList(string deptId)
        {
            return _DeptManSvr.GetListNode(GetCurUserID, deptId, 0, -1);
        }
        /// <summary>
        /// 取部门详细信息（递归取出所有子项）
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public Department GetDepartmentDetail(string deptid)
        {
            return _DeptManSvr.GetDetail(GetCurUserID, deptid, PengeSoft.Service.DeptManConst.GDOP_IncludeAllChilds);
        }
        /// <summary>
        /// 取部门详细信息（根据选项取出）
        /// </summary>
        /// <param name="deptid">部门id</param>
        /// <param name="option">选项取出数据深度</param>
        /// <returns></returns>
        public Department GetDepartmentDetail(string deptid, int option)
        {
            return _DeptManSvr.GetDetail(GetCurUserID, deptid, option);

        }
        /// <summary>
        /// 取部门下人员信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public string GetPersonsinDept(string deptid)
        {
            Department curdept = GetDepartmentDetail(deptid);
            if (curdept != null)
                return curdept.UserIds;
            return null;
        }
        public string GetUserIDbyids(string ids)
        {
            string ID = "";
            _rightcheck.GetIdNames(ids, out ID);
            return ID;
        }
        /// <summary>
        /// 获取用户权限列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserRightGroup(string userid)
        {
            string Rights;
         
            _rightcheck.GetUserRights(userid, AutherConst.GURT_NORMAL, AutherConst.RIGHT_READWRITE, 1, out Rights);
            
            if (!String.IsNullOrEmpty(Rights))
            {


                return Rights;
            }


            return null;
        }

        #endregion
        #region 意见相关
        /// <summary>
        /// 获取意见列表
        /// </summary>
        /// <param name="FormID"></param>
        /// <returns></returns>
        public DoAttitudeList getAttitudes()
        {
            return _baseformdata.GetAttitudelist(BaseFormID);
        }
        public void AddNewAttitude(DoAttitude attitude)
        {
            _baseformdata.AddAttitude(attitude);
        }
        #endregion
        #region 流程相关
        /// <summary>
        /// 完成处理
        /// </summary>
        /// <param name="workid">公文ID</param>
        /// <param name="taskname">当前步骤</param>
        /// <param name="runner">执行人</param>
        /// <param name="nextOperators">下阶段操作者</param>
        /// <param name="nextTimeLimite">下阶段工期</param>
        /// <param name="nextTaskName">下阶段任务名称</param>
        /// <param name="nextCC">下阶段抄送</param>
        /// <param name="attitude">意见类</param>
        /// <param name="baseforminfo">基本信息</param>
        protected void Finishwork(string taskname, string runner, string retValue, string nextOperators, double nextTimeLimite, string nextTaskName, string nextCC, DoAttitude attitude, BaseFormData baseforminfo)
        {
            if (nextTaskName == null || nextTaskName == "")
            {

            }
            else
            {
                _workflow.TaskFinished(TaskID, runner, "", nextOperators, nextTimeLimite, nextTaskName, nextCC);
                //_workflow.TaskFinished(workid, task.TaskName, "", runner, nextOperators, nextTimeLimite, nextTaskName, nextCC);

            }
            baseforminfo.CurStep = nextTaskName;
            baseforminfo.CurRunner = nextOperators;
            baseforminfo.TaskID = TaskID;
            baseforminfo.WorkID = WorkID;
            if (nextTaskName == "结束")
            {
                baseforminfo.FinishDate = DateTime.Now;
                baseforminfo.Status = 1;
            }
            ChangeInfo(baseforminfo.FormID, baseforminfo);
            AddNewAttitude(attitude);

        }
        protected void FinishCopyTask(string TaskID, string runner)
        {
            _workflow.TaskFinished(TaskID, runner, "", "", 0, "", "");
        }
        /// <summary>
        /// 取任务信息
        /// </summary>
        /// <returns></returns>
        public RunTask getflowinfo()
        {
            return _workflow.GetTaskInfo(TaskID);
        }
        /// <summary>
        /// 取下一站信息
        /// </summary>
        /// <returns></returns>
        public TaskList getNextStep()
        {
            return _workflow.GetNextTasks(TaskID, 0);
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
        public void stopwork(string workid)
        {
            _workflow.StopWork(workid);
        }
        public void pausework(string workid)
        {
            _workflow.PauseWork(workid);
        }
        public void continuework(string workid)
        {
            _workflow.ContinueWork(workid);
        }

        public TaskInstance getTaskinstance(string workid, string taskname)
        {
            return _workflow.GetTaskInstance(workid, taskname);
        }
        public RunTask GetCurrentTask()
        {
            return _workflow.GetCurrentTask(WorkID);
        }
        public RunTask GetTaskByWorkID(string workid)
        {
            return _workflow.GetCurrentTask(workid);
        }
        public RunTask GetTaskByTaskID(string taskid)
        {
            return _workflow.GetTaskInfo(taskid);
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



        #endregion
        #region 模板相关
        public void AddTemplet(Templet data)
        {

            _TempletSvr.AddTemplet(data);
        }
        #endregion
        #region 跳转
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
        /// <summary>
        /// 返回
        /// </summary>
        public virtual void Back()
        {
            if (!string.IsNullOrEmpty(ReturnUC))
            {
                ActionFinished(ReturnUC);
            }
            else
            {
                throw new Exception("未定义返回视图！");

            }
        }
        public void BackDetail()
        {
            ActionFinished(ReturnUCdetail);
        }
        public virtual int Submit(BaseFormData baseforminfo, string isnew)
        {
            RunTask runtask = GetTaskByTaskID(TaskID);
            if (runtask.RightMask == 0)  //抄送
            {
                FinishCopyTask(TaskID, GetCurUserID);
                ActionFinishedWithNoState(ReturnUC);
                return 1;
            }
            else
            {
                if (AttachmentNeeded != null && AttachmentNeeded)
                {
                    int attachcount = 0;
                    AttachmentQueryPara para = new AttachmentQueryPara();
                    para.SetRefID(BaseFormID);
                    para.SetRefType(TaskID);
                    attachcount = _AttachmentServiceAllSvr.QueryAttachmentCount(para);
                    if (attachcount == 0)
                        return 0;
                }
                if (isnew == "1")
                {
                    SaveNew(baseforminfo);
                }
                else
                {
                    ChangeInfo(baseforminfo.FormID, baseforminfo);
                }

                //SaveNew(baseforminfo);

                Controller.SetStateAsString("CurStep", runtask.TaskName, false);
                Controller.SetStateAsString("BaseFormID", BaseFormID, false);
                Controller.SetStateAsString("TaskID", TaskID, false);
                Controller.SetStateAsString("WorkID", WorkID, false);
                Controller.SetStateAsString("selnextstep", selnextstep, false);
                ActionFinishedWithNoState("SampleForm/ucSubmit");
                return 1;
            }
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="nextView"></param>
        public void ActionFinishedWithNoState(string nextView)
        {
            Set_StateSet(AbstractWebAction.State_NextViewNotUseSavedState, true);
            ActionFinished(nextView);
        }



        #endregion

    }
}
