#region 版本说明
/*****************************************************************************
 * 
 * 项    目 : 
 * 作    者 : 李金坪 
 * 创建时间 : 2014/8/22 13:09:13 
 *
 * Copyright (C) 2008 - 鹏业软件公司
 * 
 *****************************************************************************/
#endregion

using System;
using System.Collections;
using System.Text;
using Castle.Windsor;
using NUnit.Framework;
using PengeSoft.Data;
using PengeSoft.Enterprise.Appication;
using PengeSoft.WorkZoneData;
using PengeSoft.Common;
using PengeSoft.Common.Exceptions;
using PengeSoft.Auther;
using PengeSoft.Auther.RightCheck;
using PengeSoft.WorkFlow;

namespace PengeSoft.WorkFlowTest
{
    [TestFixture]
    public class WorkFlowEngineOASvrTest
    {
        private IWindsorContainer _container;
        private IWorkFlowEngineOA _svr;
        private IWorkInstanceManager _workinstance;
       // private IRightCheck _auther;

        [SetUp]
        public void SetUp()
        {
            if (_container == null)
            {
                _container = ComponentManager.GetInstance();
                if (!_container.Kernel.HasComponent(typeof(IWorkInstanceManager)))
                {
                    _container.AddComponent("DefaultDataManager", typeof(IWorkInstanceManager), typeof(WorkInstanceManager));


                }
                                //_container.AddComponent("WorkFlowEngineOA", typeof(IWorkFlowEngineOA), typeof(WorkFlowEngineOA));
            }

            //_auther = (IRightCheck)_container[typeof(IRightCheck)];
            //_auther.Active = true;

            _svr = (IWorkFlowEngineOA)_container[typeof(IWorkFlowEngineOA)];
            _workinstance = (IWorkInstanceManager)_container[typeof(IWorkInstanceManager)];
            //_auther = new AutherUseRightCheck();
            //_auther.Login("127.0.0.1", "zprk", "");
        }

        [TearDown]
        public void Finished()
        {
            _svr = null;
        }

        /// <summary>
        /// 添加新工作   
        /// </summary>
        [Test]
      public  void AddNewWork()
        {

           // _svr.AddNewWork("testModel.wkf", "test", "test"); 
            
            WorkInstance template = new WorkInstance();
            string workName = "";
            string owner = "";
            string ret = _svr.AddNewWork(template, workName, owner);
            Assert.IsNotNull(ret, "执行失败");
            
        }

        /// <summary>
        /// 按文件添加新工作   
        /// </summary>
        [Test]
      public  void AddNewWorkFile()
        {
            Console.WriteLine("AddNewWorkFile未实现");

            string templateFile = "testflow.wkf";
            string workName = "";
            string owner = "";
            string ret = _svr.AddNewWork(templateFile, workName, owner);
            //Assert.IsNotNull(ret, "执行失败");
            
        }

        /// <summary>
        /// 删除工作   
        /// </summary>
        [Test]
        void RemoveWork()
        {
            Console.WriteLine("RemoveWork未实现");
            /*
            string workId = "";
            _svr.RemoveWork(workId);
            */
        }

        /// <summary>
        /// 启动工作   
        /// </summary>
        [Test]
      public  void StartWork()
        {
            //Console.WriteLine("StartWork未实现");

            string workId = "69CC73EE-3175-4614-AA0D-F27DB42B11EA";
            NamedValue para = new NamedValue();
            
            string operators = "0b14d5d2-eaa2-4c93-84c9-43cd28b5245b";
            double timeLimite = 0;
            NamedValue na=new NamedValue();
            //WorkInstance isn=new WorkInstance();
            //isn.WorkID=new Guid("9418AA66-9AAF-4734-ACC0-0AF7F9942561");
            //isn = _workinstance.GetDetail(isn) as WorkInstance;
            na.ObjValue=Guid.NewGuid().ToString();
           
           // _svr.StartWork(workId, na);
            _svr.StartWork(workId, para, operators, timeLimite);
            
        }

        /// <summary>
        /// 中止工作   
        /// </summary>
        [Test]
        void StopWork()
        {
            Console.WriteLine("StopWork未实现");
            /*
            string workId = "";
            _svr.StopWork(workId);
            */
        }

        /// <summary>
        /// 暂停工作   
        /// </summary>
        [Test]
        void PauseWork()
        {
            Console.WriteLine("PauseWork未实现");
            /*
            string workId = "";
            _svr.PauseWork(workId);
            */
        }

        /// <summary>
        /// 继续被暂停工作   
        /// </summary>
        [Test]
        void ContinueWork()
        {
            Console.WriteLine("ContinueWork未实现");
            /*
            string workId = "";
            _svr.ContinueWork(workId);
            */
        }

        /// <summary>
        /// 任务已完成通知, 任务输出参数或主参数的改变由任务执行程序处理   
        /// </summary>
        [Test]
      public  void TaskFinished()
        {


            string workId = "84EBFCBC-4AF1-405F-8EAC-A95C0FAAA8DA";
            string taskId = "6D582F30-5F4C-4853-A492-F017DABD1F92";
            string runner = "0a1223f6-58b4-4b5c-95b2-9cbf819f22d6";
            string retValue = "";
            string nextOperators = "0a1223f6-58b4-4b5c-95b2-9cbf819f22d6";
            double nextTimeLimite = 0;
            string nextTaskName = "领导批示";
            string nextCC = "";
            _svr.TaskFinished(workId, runner, retValue, nextOperators, nextTimeLimite, nextTaskName, nextCC);
           // _svr.TaskFinished(workId, "", runner, retValue, nextOperators, nextTimeLimite, nextTaskName, nextCC);
            
        }

        /// <summary>
        /// 获取下阶段任务名称表   
        /// </summary>
        [Test]
        void GetNextTasks()
        {
            Console.WriteLine("GetNextTasks未实现");
            /*
            string workId = "";
            int option = 0;
            TaskList ret = _svr.GetNextTasks(workId, option);
            //Assert.IsNotNull(ret, "执行失败");
            */
        }

        /// <summary>
        /// 取任务数据   
        /// </summary>
        [Test]
       public void GetTaskInfo()
        {


            string taskId = "7F6FB8CF-844F-4AAE-8391-B88180DB7A52";
            RunTask ret = _svr.GetTaskInfo(taskId);
            //Assert.IsNotNull(ret, "执行失败");
            
        }

        /// <summary>
        /// 取当前任务数据   
        /// </summary>
        [Test]
      public  void GetCurrentTask()
        {

            string workId = "0ED3C214-D6EE-4D2B-8982-9B335DE56E4C";
            RunTask ret = _svr.GetCurrentTask(workId);
            //Assert.IsNotNull(ret, "执行失败");
          
        }

        /// <summary>
        /// 取任务列表   
        /// </summary>
        [Test]
        void GetTaskList()
        {
            Console.WriteLine("GetTaskList未实现");
            /*
            string operators = "";
            int opLevel = 0;
            int state = 0;
            RunTaskList ret = _svr.GetTaskList(operators, opLevel, state);
            //Assert.IsNotNull(ret, "执行失败");
            */
        }
    }
}