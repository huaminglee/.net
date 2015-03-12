using PengeSoft.CMS.BaseDatum;
using PengeSoft.Web;
using PengeSoft.WorkFlow;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace PengeSoft.CMS.Presentation
{
   public class ActSubmit:ActBaseForm
    {
        #region 私有字段

         
        #endregion

        #region 属性
        public string retValue { get; set; }
        /// <summary>
        /// 下步人
        /// </summary>
        public string nextOperators { get; set; }
        /// <summary>
        /// 下步期限
        /// </summary>
        public double nextTimeLimite { get; set; }
        /// <summary>
        /// 下步抄送
        /// </summary>
        public string nextCC { get; set; }
      
       /// <summary>
       /// 办理意见
       /// </summary>
        public string AttitudeContent { get; set; }

       
       
        #endregion

        #region 构造函数

        public ActSubmit(HttpContext ctx)
            : base(ctx)
        {
            
        }

        #endregion

        #region IWebAction 方法

        public override void SetParameter(IStateSaver stateSaver)
        {
            base.SetParameter(stateSaver);

        }

        public override void GetParameter(IStateSaver stateSaver)
        {
            base.GetParameter(stateSaver);

        }

        public void Submitf()
        {      
            BaseFormData baseforminfo = _baseformdata.GetinfoByID(BaseFormID);
            DoAttitude attitude=new DoAttitude();
            attitude.ArchiveContent=AttitudeContent;
            attitude.FormID = BaseFormID;
            attitude.Creator = GetCurUserName;
            attitude.Department = GetCurUserDept;
            attitude.AttitudeId=Guid.NewGuid().ToString();
            attitude.StateName = CurStep;
            attitude.TaskID = TaskID;
            attitude.WorkID = WorkID;
            attitude.CreateTime=DateTime.Now;

            Finishwork(CurStep, GetCurUserID, null, nextOperators, nextTimeLimite, selnextstep, nextCC, attitude, baseforminfo);
            Back();
        }
        public void SaveContact(string COwner, string contactid, string contactxm, string TaskName, string stepname,int Ctype)
        {
           _UsedContactSvr.AddRecord(COwner,contactid,contactxm,TaskName,stepname,Ctype);
       }
        public DataTable GetDataTableFromConfig(string sNodeName)
        {
            return XmlHelper.GetNodeList(AppDomain.CurrentDomain.BaseDirectory + "App_Resources/Xml/SiteConfig.xml", sNodeName);
        }
        
        #endregion

    }
}
