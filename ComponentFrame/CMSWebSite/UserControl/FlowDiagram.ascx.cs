using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PengeSoft.Web;
using PengeSoft.WorkFlow;
using PengeSoft.Common;
using PengeSoft.WorkFlow.Diagram;
using System.Drawing;
using Syncfusion.Windows.Forms.Diagram;

public partial class UC_FlowDiagram : PengeSoft.Web.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /*
    private void CreateFlowDiagram()
    {
        IWorkFlowEngine workEng = (IWorkFlowEngine)this.WebObjManager.Container[typeof(IWorkFlowEngine)];
        string workId = this.CurrentController.GetStateAsString("WorkId", false);

        WorkInstance work = workEng.GetWorkInstance(workId);
        FlowModel.InitialModel(DiagramWebControl1.Model, work);
    }

    public override void DataBind()
    {
        this.CreateFlowDiagram();

        base.DataBind();
    }
    */

    public override void DataBind()
    {
        string path;

        base.DataBind();

        IWorkFlowEngine workEng = (IWorkFlowEngine)this.WebObjManager.Container[typeof(IWorkFlowEngine)];
        string workId = this.CurrentController.GetStateAsString("WorkId", false);

        WorkInstance work = workEng.GetWorkInstance(workId);
        if (work == null)
        {
            path = "outimage\\notfindwork.png";
        }
        else
        {
            // 下面语句只完成初始化环境的作用
            Syncfusion.Web.UI.WebControls.Diagram.DiagramWebControl diagram = new Syncfusion.Web.UI.WebControls.Diagram.DiagramWebControl();

            using (Bitmap bmp = FlowModel.CreateBitmap(work))
            {
                path = "outimage\\" + work.WorkID.ToString() + ".png";
                string fn = SysUtils.MakeFullPath("") + path;
                bmp.Save(fn);
            }
        }
        this.ImageMap1.ImageUrl = "~\\" + path;
    }
}
