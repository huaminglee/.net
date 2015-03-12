using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public partial class SysManege_UserControls_ucEduQuestionList : System.Web.UI.UserControl
{
    PDTech.OA.BLL.OA_EDUQUESTION quesBll = new PDTech.OA.BLL.OA_EDUQUESTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int record = 0;
        IList<PDTech.OA.Model.OA_EDUQUESTION> quesList = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        string title = AidHelp.FilterSpecial(txtTitle.Text);
        if (!string.IsNullOrEmpty(title))
        {
            quesList = quesBll.Get_Paging_List(title, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        else
        {
            quesList = quesBll.Get_Paging_List(null, AspNetPager.PageSize, AspNetPager.CurrentPageIndex, out record);
        }
        rpt_QuestionList.DataSource = quesList;
        rpt_QuestionList.DataBind();
        AspNetPager.RecordCount = record;
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        string path = SaveExcel();
        if (!string.IsNullOrEmpty(path))
        {
            SaveData(path);
        }
    }

    private string SaveExcel()
    {
        string path = Server.MapPath("~/") + "\\Upload\\Excel";
        if ((!filePath.HasFile
            || filePath.FileName.Substring(filePath.FileName.LastIndexOf('.') + 1) != "xls") &&
            (!filePath.HasFile || filePath.FileName.Substring(filePath.FileName.LastIndexOf('.') + 1) != "xlsx"))
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据为空或导入的不是EXCEL文件.');</script>");
            return null;
        }
        else
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            filePath.SaveAs(path + "\\" + filePath.FileName);
            return path + "\\" + filePath.FileName;
        }
    }

    private void SaveData(string filePath)
    {
        List<PDTech.OA.Model.OA_EDUQUESTION> list = new List<PDTech.OA.Model.OA_EDUQUESTION>();
        try
        {
            DataTable dt = ImportExcel(filePath);
            foreach (DataRow dr in dt.Rows)
            {
                PDTech.OA.Model.OA_EDUQUESTION quesModel = new PDTech.OA.Model.OA_EDUQUESTION();
                quesModel.EDU_Q_GUID = System.Guid.NewGuid().ToString();
                quesModel.TITLE = dr.ItemArray.Count() > 0 ? dr.ItemArray[0].ToString() : "";
                quesModel.ANSWER = dr.ItemArray.Count() > 1 ? dr.ItemArray[1].ToString() : "";
                quesModel.OPTIONA = dr.ItemArray.Count() > 2 ? dr.ItemArray[2].ToString() : "";
                quesModel.OPTIONB = dr.ItemArray.Count() > 3 ? dr.ItemArray[3].ToString() : "";
                quesModel.OPTIONC = dr.ItemArray.Count() > 4 ? dr.ItemArray[4].ToString() : "";
                quesModel.OPTIOND = dr.ItemArray.Count() > 5 ? dr.ItemArray[5].ToString() : "";
                quesModel.CREATETIME = DateTime.Now;
                quesModel.SCORE = 1;
                quesModel.WEIGHT = 0;
                list.Add(quesModel);
                if (list.Count > 50)
                {
                    quesBll.BatchAdd(list);
                    list.Clear();
                }
            }
            if (list.Count > 0)
            {
                quesBll.BatchAdd(list);
                this.Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('导入成功！');doRefresh();</script>");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("导入失败！原因：" + ex.Message);
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>window.location.href='/DownLoad.aspx?file=/Upload/Template/在线考试试题模版.xls&fullName=在线考试试题模板.xls';</script>");
    }

    #region ImportExcel
    /// <summary>
    /// 导入 Excel
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns>DataTable</returns>
    public DataTable ImportExcel(string path)
    {
        string columnName;
        var dt = new DataTable();

        HSSFWorkbook workbook;
        using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            workbook = new HSSFWorkbook(file);
        }

        ISheet sheet = workbook.GetSheetAt(0);

        IRow headerRow = sheet.GetRow(0);
        int cellCount = headerRow.LastCellNum;

        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            if (headerRow.GetCell(i) == null)
            {
                columnName = Guid.NewGuid().ToString();
            }
            else
            {
                columnName = headerRow.GetCell(i).StringCellValue;
            }
            DataColumn column = new DataColumn(columnName);
            dt.Columns.Add(column);
        }

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            IRow row = sheet.GetRow(i);
            if (row != null)
            {
                DataRow dr = dt.NewRow();

                int k = 0;
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    dr[k] = row.GetCell(j);
                    k++;
                }

                dt.Rows.Add(dr);
            }
        }

        workbook = null;
        sheet = null;
        return dt;
    }

    public string GetExcelConnection(string strFilePath)
    {
        if (!File.Exists(strFilePath)) throw new Exception("指定的Excel文件不存在！");

        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended properties=\"Excel 8.0;Imex=1;HDR=Yes;\"";
    }
    #endregion
}