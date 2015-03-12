using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Admin_Archive_Print : System.Web.UI.Page
{
    public string t_rand = "";
    string contentArchive_Id = "";
    public string allSealdata = string.Empty;
    PDTech.OA.BLL.OA_ARCHIVE vArchiveBll = new PDTech.OA.BLL.OA_ARCHIVE();
    PDTech.OA.BLL.ATTRIBUTES attBll = new PDTech.OA.BLL.ATTRIBUTES();
    PDTech.OA.BLL.VIEW_PRINT_STEPDETAIL pBll = new PDTech.OA.BLL.VIEW_PRINT_STEPDETAIL();
    PDTech.OA.BLL.OA_ARCHIVE_TASK taskBll = new PDTech.OA.BLL.OA_ARCHIVE_TASK();
    protected void Page_Load(object sender, EventArgs e)
    {
        t_rand = DateTime.Now.ToString("yyyyMMddHHmmssff");
        if (Request.QueryString["Archive_Id"] != null)
        {
            contentArchive_Id = Request.QueryString["Archive_Id"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void BindData()
    {
        ArrayList arrPrintTitle = new ArrayList();
        IList<PDTech.OA.Model.ATTRIBUTES> attList = new List<PDTech.OA.Model.ATTRIBUTES>();
        IList<PDTech.OA.Model.VIEW_PRINT_STEPDETAIL> printList = new List<PDTech.OA.Model.VIEW_PRINT_STEPDETAIL>();
        PDTech.OA.Model.OA_ARCHIVE vArchive = new PDTech.OA.Model.OA_ARCHIVE();
        vArchive = vArchiveBll.GetArchiveInfo(decimal.Parse(contentArchive_Id));
        attList = attBll.get_AttInfoList(new PDTech.OA.Model.ATTRIBUTES() { LOG_ID = (decimal)vArchive.ATTRIBUTE_LOG });
        if (attList.Count > 0)
        {
            foreach (var item in attList)
            {
                switch (item.KEY)
                {
                    case "RECEIVE_TIME":
                        pdtInComingDate.Text = item.VALUE;
                        break;
                    case "DOCTYPE":
                        txtDocType.Text = item.VALUE;
                        break;
                    case "SENDUNIT":
                        txtSendUnit.Text = item.VALUE;
                        break;
                }
            }
        }
        txtRemark.Text = vArchive.ARCHIVE_CONTENT;
        txtTitle.Text = vArchive.ARCHIVE_TITLE;
        txtDocNo.Text = vArchive.ARCHIVE_NO ;
        txtArchiveNo.Text = vArchive.ARCHIVE_ID.ToString();
        if (vArchive.IS_SECRET!=null)
        lbSecret.Text = new ConvertHelper(Enum.Parse(typeof(EArchiveIsSecret), vArchive.IS_SECRET.ToString())).String;
        printList = pBll.get_PrintInfoList(new PDTech.OA.Model.VIEW_PRINT_STEPDETAIL() { ARCHIVE_ID = decimal.Parse(contentArchive_Id) });

        StringBuilder sList = new StringBuilder();
        int i = 0;
        foreach (var item in printList)
        {
            if (!arrPrintTitle.Contains(item.PRINT_TITLE))
            {
                arrPrintTitle.Add(item.PRINT_TITLE);
                sList.Append(" <tr>");
                sList.Append(" <td class=\"MCTableTr_Left\" valign=\"middle\">");
                sList.Append(" <span class=\"AttitudeBtn\">" + item.PRINT_TITLE + "：</span>");
                sList.Append(" </td>");
                sList.Append(" <td  colspan=\"3\" style=\" background-color: #f6f6f6\" valign=\"top\">");
                sList.Append(" <table width=\"100%\" class=\"main_tabPrint\" cellpadding=\"0px\" cellspacing=\"0px\">");

                //获得受保护的数据
                PDTech.OA.Model.OA_ARCHIVE oaArchive = vArchiveBll.GetArchiveInfo(item.ARCHIVE_ID.Value);
                string protectDatas = oaArchive.ARCHIVE_TITLE + "=&" + oaArchive.ARCHIVE_CONTENT + "=&";
                foreach (var items in printList)
                {
                    if (items.PRINT_TITLE == item.PRINT_TITLE)
                    {
                        sList.Append(" <tr>");
                        sList.Append(" <td align=\"center\" style=\"width:20%;\" >");
                        sList.Append(items.FULL_NAME);
                        sList.Append(" </td>");

                        sList.Append(" <td align=\"center\" style=\"width:60%;\" >");
                        sList.Append(items.TASK_REMARK);
                        sList.Append(" </td>");
                        sList.Append(" <td align=\"center\" style=\"width:20%;\">");
                        sList.Append(AidHelp.ShortTime(items.END_TIME));
                        sList.Append(" </td>");
                        sList.Append(" </tr>");

                        //查看盖章信息是否为空
                        PDTech.OA.Model.OA_ARCHIVE_TASK task = taskBll.GetTaskInfo(items.ARCHIVE_TASK_ID.Value);
                        if (task != null && !string.IsNullOrEmpty(task.Sing_data))
                        {
                            //得到受保护的数据
                            IList<PDTech.OA.Model.OA_ARCHIVE_TASK> list = taskBll.get_TaskInfoList(task.ARCHIVE_ID.Value, task.ARCHIVE_TASK_ID.Value);
                            foreach (PDTech.OA.Model.OA_ARCHIVE_TASK model in list)
                            {
                                protectDatas += model.ARCHIVE_TASK_ID + "=" + model.TASK_REMARK + "&";
                            }

                            sList.Append(" <tr style=\"height:140px\">");
                            sList.Append(" <td height=\"0\" width=\"0\"  id=\"name\" style=\"border-bottom:1px #d2d8dc solid; overflow:visible; POSITION: relative\" colspan=\"2\" align=\"center\">");
                            sList.Append(" <object id=sealobj classid=\"CLSID:C1FB7513-9A44-4C64-B653-63C6965D7F4C\" width=150 height=150 style=\"left:330px; position:absolute; top:-25px\">");
                            sList.Append(" <param name=Authority value=0 />");
                            sList.Append(" <param name=ProtectedData value=\"" + S_App.javaScriptFilter(protectDatas) + "\"/>");
                            sList.Append(" <param name=SignedDataStoreElement value=\"" + i + "\">");
                            sList.Append(" <param name=DrawMode value=18/>");
                            sList.Append(" <param name=DrawModeUnsign value=0/>");
                            sList.Append(" </object>");
                            sList.Append(" </td>");
                            sList.Append(" <input type=\"hidden\" id=" + i + " name=" + i + " value=" + task.Sing_data + ">");
                            sList.Append(" </tr>");

                            //sList.Append(" <div id=\"name\" style=\"height:150px; width:0px; border-bottom:1px #d2d8dc solid; POSITION:relative\" >");
                            //sList.Append(" <object id=sealobj classid=\"CLSID:C1FB7513-9A44-4C64-B653-63C6965D7F4C\" width=150 height=150 style=\"left:330px; position:absolute; top:0px\">");
                            //sList.Append(" <param name=Authority value=0 />");
                            //sList.Append(" <param name=OnGetProtectedData value=\"/inputnames:\"/>");
                            //sList.Append(" <param name=SignedDataStoreElement value=0>");
                            //sList.Append(" <param name=DrawMode value=18/>");
                            //sList.Append(" <param name=DrawModeUnsign value=8/>");
                            //sList.Append(" </object>");
                            //sList.Append(" <input type=\"hidden\" id=" + i + " name=" + i + " value=" + newTask.Sing_data + ">");
                            //sList.Append(" </div>");

                            i += 1;
                        }
                    }
                }

                sList.Append(" </table>");
                sList.Append(" </td>");
                sList.Append(" </tr>");
            }
        }
        ShowOpList.Text = sList.ToString();
    }
}