using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PengeSoft.CMS.BaseDatum;


namespace PengeSoft.CMS.Presentation
{
    public class ActAttachmentDetail : ActBaseForm
    {
        //附件ID
        private string _AttachmentId;
        public string AttachmentId
        {
            get { return _AttachmentId; }
            set { _AttachmentId = value; }
        }

        //已经在ActBase中定义了
        //IAttachmentServiceSvr _AttachmentServiceAllSvr;
         public ActAttachmentDetail(HttpContext ctx)
            : base(ctx)
        {
           // _AttachmentServiceAllSvr = (IAttachmentServiceSvr)base.WebObjManager.Container[typeof(IAttachmentServiceSvr)];
        }

         public override string ActName
         {
             get
             {
                 return base.ActName;
             }
         }
       
        public override void Back()
        {
            base.Back();
        }

        public override void SetParameter(PengeSoft.Web.IStateSaver controller)
        {
            controller.SetStateAsString("AttachmentId", AttachmentId,false);
            base.SetParameter(controller);
        }

        public override void GetParameter(PengeSoft.Web.IStateSaver controller)
        {
           AttachmentId= controller.GetStateAsString("AttachmentId", false);
            base.GetParameter(controller);
        }
    }
}
