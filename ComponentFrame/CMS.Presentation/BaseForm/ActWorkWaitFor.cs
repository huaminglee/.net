using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PengeSoft.CMS.BaseDatum;
using PengeSoft.CMS.Presentation;
using System.Web;
using PengeSoft.db;
using PengeSoft.WorkFlow;

namespace PengeSoft.CMS.Presentation 
{
    public class ActWorkWaitFor : PengeSoft.Web.AbstractWebAction
    {
       protected IWorkFlowEngineOA _workflow;
        public ActWorkWaitFor(HttpContext ctx)
           : base(ctx)
        {
            _workflow = (IWorkFlowEngineOA)WebObjManager.Container[typeof(IWorkFlowEngineOA)];

        }
       
        
        /// <summary>
        /// 取任务列表   
        /// </summary>
        /// <param name="operators">操作者</param>
        /// <param name="opLevel">操作级别</param>
        /// <param name="state">状态</param>
        public RunTaskList gettastlist(string operators, int opLevel, int state)
        {
            return _workflow.GetTaskList(operators, opLevel, state);

        }
    }
}
